using ColorProfiles.Colors;
using System.Numerics;

namespace ColorProfiles
{
    public partial class Form1 : Form
    {
        private Bitmap? _pictureLoaded;
        private Vector3[,]? _pictureXYZ;
        private Vector3[,]? _pictureXYZAdapted;
        private Bitmap? _pictureConverted;
        private bool _colorProfileChanged = true;
        public Form1()
        {
            InitializeComponent();
            ChromaticAdapter adapter = new(WhitePoint.Illuminats.D65, WhitePoint.Illuminats.D50);

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
            for (int i = 0; i < _pictureLoaded.Width; i++)
            {
                for (int j = 0; j < _pictureLoaded.Height; j++)
                {
                    _pictureXYZ[i, j] = toXYZconverter.XYZ(_pictureLoaded.GetPixel(i, j));
                }
            }
        }
        private void wczytajZdjêcieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog pictureDialog = new();
            pictureDialog.Filter = "pictures (*.png;*.jpeg;*.jpg;*.bmp)|*.png;*.jpeg;*.jpg;*.bmp|All files (*.*)|*.*";
            if (pictureDialog.ShowDialog() == DialogResult.OK)
            {
                _pictureLoaded = new Bitmap(pictureDialog.FileName);
                pictureBoxLoaded.Image = _pictureLoaded;
                _pictureXYZ = null;
            }
        }

        private async void generujToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_pictureLoaded == null) 
            {
                return;
            }

            var busy = new BusyForm();
            Task busyTask = Task.Run(() => busy.ShowDialog());
            await busy.WaitForReadyAsync();

            if ( _pictureXYZ == null || _colorProfileChanged)
            {
                CalculateXYZ();
                _colorProfileChanged = false;
            }
            if(_pictureConverted == null || 
                _pictureConverted.Size != _pictureLoaded.Size)
            {
                _pictureConverted = new Bitmap(_pictureLoaded.Width, _pictureLoaded.Height);
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
            for (int i = 0; i < _pictureLoaded.Width; i++)
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
            }
            pictureBoxChanged.Image = _pictureConverted;

            Invoke((Action)(() => Application.OpenForms["BusyForm"]?.Close()));
            await busyTask;
            busy.Dispose();
        }
    }
}
