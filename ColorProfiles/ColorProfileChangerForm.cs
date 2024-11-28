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
        private DirectBitmap? _pictureCouldNotConvert;
        private bool _colorProfileChanged = true;
        private bool _viewNotChanged = false;
        public ColorProfileChangerForm()
        {
            InitializeComponent();
            // chromatic adapter test
            //ChromaticAdapter adapter = new(WhitePoint.Illuminats.A, WhitePoint.Illuminats.D65);
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
                _pictureCouldNotConvert = new DirectBitmap(_pictureLoaded.Width, _pictureLoaded.Height);
                _pictureConverted = new DirectBitmap(_pictureLoaded.Width, _pictureLoaded.Height);
            }

            ChromaticAdapter adapter = new(colorProfileControlLoaded.ColorProfile.WhitePoint,
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

                    int nr = rgb.X is float.NaN || rgb.X > 255f ? 255 : 0;
                    int ng = rgb.Y is float.NaN || rgb.Y > 255f ? 255 : 0;
                    int nb = rgb.Z is float.NaN || rgb.Z > 255f ? 255 : 0;
                    _pictureCouldNotConvert!.SetPixel(i, j, Color.FromArgb(nr, ng, nb));

                    int R = Math.Max(0, Math.Min(255, (int)rgb.X));
                    int G = Math.Max(0, Math.Min(255, (int)rgb.Y));
                    int B = Math.Max(0, Math.Min(255, (int)rgb.Z));
                    _pictureConverted.SetPixel(i, j, Color.FromArgb(R, G, B));
                }
            });
            if (_viewNotChanged)
            {
                pictureBoxChanged.Image = _pictureCouldNotConvert!.Bitmap;
            }
            else
            {
                pictureBoxChanged.Image = _pictureConverted.Bitmap;
            }

            Invoke((Action)(() => Application.OpenForms[nameof(BusyConvertingForm)]?.Close()));
            await busyTask;
            busy.Dispose();
        }

        private void zapiszWynikToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_pictureConverted == null)
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

        private void nieprzekonwertowanePikseleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var strip = (ToolStripMenuItem)menuStripOptions.Items[4];
            ((ToolStripMenuItem)strip.DropDownItems[0]).Checked = false;
            ((ToolStripMenuItem)strip.DropDownItems[1]).Checked = true;
            if (_pictureCouldNotConvert != null)
                pictureBoxChanged.Image = _pictureCouldNotConvert!.Bitmap;
            _viewNotChanged = true;
        }

        private void wynikToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var strip = (ToolStripMenuItem)menuStripOptions.Items[4];
            ((ToolStripMenuItem)strip.DropDownItems[0]).Checked = true;
            ((ToolStripMenuItem)strip.DropDownItems[1]).Checked = false;
            if (_pictureConverted != null)
                pictureBoxChanged.Image = _pictureConverted!.Bitmap;
            _viewNotChanged = false;
        }

        private void oryginalneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBoxLoaded.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxChanged.SizeMode = PictureBoxSizeMode.Zoom;

            var strip = (ToolStripMenuItem)menuStripOptions.Items[5];
            ((ToolStripMenuItem)strip.DropDownItems[0]).Checked = true;
            ((ToolStripMenuItem)strip.DropDownItems[1]).Checked = false;
            ((ToolStripMenuItem)strip.DropDownItems[2]).Checked = false;
        }

        private void rozci¹niêcieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBoxLoaded.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxChanged.SizeMode = PictureBoxSizeMode.StretchImage;

            var strip = (ToolStripMenuItem)menuStripOptions.Items[5];
            ((ToolStripMenuItem)strip.DropDownItems[0]).Checked = false;
            ((ToolStripMenuItem)strip.DropDownItems[1]).Checked = true;
            ((ToolStripMenuItem)strip.DropDownItems[2]).Checked = false;
        }

        private void originToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBoxLoaded.SizeMode = PictureBoxSizeMode.Normal;
            pictureBoxChanged.SizeMode = PictureBoxSizeMode.Normal;

            var strip = (ToolStripMenuItem)menuStripOptions.Items[5];
            ((ToolStripMenuItem)strip.DropDownItems[0]).Checked = false;
            ((ToolStripMenuItem)strip.DropDownItems[1]).Checked = false;
            ((ToolStripMenuItem)strip.DropDownItems[2]).Checked = true;
        }
    }
}
