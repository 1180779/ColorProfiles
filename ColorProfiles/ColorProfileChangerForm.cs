using ColorProfiles.Colors;
using System.Numerics;

namespace ColorProfiles
{
    public partial class ColorProfileChangerForm : Form
    {
        private DirectBitmap? _pictureLoaded;
        private Vector3[,]? _pictureXYZ;
        private Vector3[,]? _pictureXYZAdapted;
        private DirectBitmap? _pictureConverted;
        private bool _colorProfileChanged = true;
        public ColorProfileChangerForm()
        {
            InitializeComponent();
            ChromaticAdapter adapter = new(WhitePoint.Illuminats.A, WhitePoint.Illuminats.D65);

        }
        private void OnProfileChange(object sender, PropertyTabChangedEventArgs e)
        {
            _colorProfileChanged = true;
        }
        private void CalculateXYZ()
        {
            if (_pictureLoaded == null)
                return;
            RGBtoCIEXYZ toXYZconverter = new(colorProfileControlLoaded.ColorProfile);
            _pictureXYZ = new Vector3[_pictureLoaded.Width, _pictureLoaded.Height];
            int height = _pictureLoaded.Height;
            Parallel.ForEach(Enumerable.Range(0, _pictureLoaded.Width), i =>
            {
                for (int j = 0; j < height; j++)
                {
                    _pictureXYZ[i, j] = toXYZconverter.XYZ(_pictureLoaded.GetPixel(i, j));
                }
            });
        }
        private async void wczytajZdjêcieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog pictureDialog = new();
            pictureDialog.Filter = "pictures (*.png;*.jpeg;*.jpg;*.bmp)|*.png;*.jpeg;*.jpg;*.bmp|All files (*.*)|*.*";
            if (pictureDialog.ShowDialog() == DialogResult.OK)
            {
                var busy = new BusyLoadingForm();
                Task busyTask = Task.Run(() => busy.ShowDialog());
                await busy.WaitForReadyAsync();

                Bitmap bmp = new Bitmap(pictureDialog.FileName);
                _pictureLoaded = new DirectBitmap(bmp.Width, bmp.Height);
                for (int i = 0; i < bmp.Width; ++i)
                {
                    for (int j = 0; j < bmp.Height; ++j)
                    {
                        _pictureLoaded.SetPixel(i, j, bmp.GetPixel(i, j));
                    }
                }
                pictureBoxLoaded.Image = _pictureLoaded.Bitmap;
                _pictureXYZ = null;

                Invoke((Action)(() => Application.OpenForms[nameof(BusyLoadingForm)]?.Close()));
                await busyTask;
                busy.Dispose();
            }
        }

        private async void generujToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_pictureLoaded == null)
            {
                var msg = MessageBox.Show("Brak obrazu wejœciowego. Przed generowaniem wczytaj zdjêcie.", "Brak zdjêcia",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var busy = new BusyConvertingForm();
            Task busyTask = Task.Run(() => busy.ShowDialog());
            await busy.WaitForReadyAsync();

            //if (_pictureXYZ == null || _colorProfileChanged)
            //{
            //    CalculateXYZ();
            //    _colorProfileChanged = false;
            //}
            CalculateXYZ();
            if (_pictureConverted == null ||
                _pictureConverted.Bitmap.Size != _pictureLoaded.Bitmap.Size)
            {
                _pictureConverted = new DirectBitmap(_pictureLoaded.Width, _pictureLoaded.Height);
            }

            ChromaticAdapterPrecalculated adapter = new(colorProfileControlLoaded.ColorProfile.WhitePoint,
                colorProfileControlChanged.ColorProfile.WhitePoint);
            _pictureXYZAdapted = new Vector3[_pictureLoaded.Width, _pictureLoaded.Height];
            for (int i = 0; i < _pictureLoaded.Width; i++)
            {
                for (int j = 0; j < _pictureLoaded.Height; ++j)
                {
                    _pictureXYZAdapted[i, j] = adapter.Adapt(_pictureXYZ[i, j]);
                }
            }

            CIEXYZtoRGB toRGBconverter = new(colorProfileControlChanged.ColorProfile);
            Parallel.ForEach(Enumerable.Range(0, _pictureLoaded.Width), i =>
            {
                for (int j = 0; j < _pictureLoaded.Height; j++)
                {
                    var rgb = toRGBconverter.RGB(_pictureXYZAdapted[i, j]);
                    int R = Math.Max(0, Math.Min(255, (int)rgb.X));
                    int G = Math.Max(0, Math.Min(255, (int)rgb.Y));
                    int B = Math.Max(0, Math.Min(255, (int)rgb.Z));
                    Color c = Color.FromArgb(R, G, B);
                    _pictureConverted.SetPixel(i, j, c);
                }
            });
            pictureBoxChanged.Image = _pictureConverted.Bitmap;

            Invoke((Action)(() => Application.OpenForms[nameof(BusyConvertingForm)]?.Close()));
            await busyTask;
            busy.Dispose();
        }

        private void zapiszWynikToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(_pictureConverted == null)
            {
                var msg = MessageBox.Show("Brak obrazu do zapisania.", "Brak zdjêcia", 
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var saveDialog = new SaveFileDialog();
            saveDialog.Filter = "png|*.png";
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                _pictureConverted.Bitmap.Save(saveDialog.FileName);
            }
        }
    }
}
