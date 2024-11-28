using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ColorProfiles.Colors;

namespace ColorProfiles
{
    public partial class ColorProfileControl : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public ColorProfile ColorProfile => colorProfileDetailsControl1.ColorProfile;
        private readonly Dictionary<string, int> _whitePointNameToIndex;
        public ColorProfileControl()
        {
            InitializeComponent();

            comboBoxWhitePoint.Items.Add(WhitePoint.Illuminats.A);
            comboBoxWhitePoint.Items.Add(WhitePoint.Illuminats.B);
            comboBoxWhitePoint.Items.Add(WhitePoint.Illuminats.C);
            comboBoxWhitePoint.Items.Add(WhitePoint.Illuminats.D50);
            comboBoxWhitePoint.Items.Add(WhitePoint.Illuminats.D55);
            comboBoxWhitePoint.Items.Add(WhitePoint.Illuminats.D65);
            comboBoxWhitePoint.Items.Add(WhitePoint.Illuminats.D75);
            comboBoxWhitePoint.Items.Add(WhitePoint.Illuminats.D93);
            comboBoxWhitePoint.Items.Add(WhitePoint.Illuminats.E);
            comboBoxWhitePoint.Items.Add(WhitePoint.Illuminats.F2);
            comboBoxWhitePoint.Items.Add(WhitePoint.Illuminats.F7);
            comboBoxWhitePoint.Items.Add(WhitePoint.Illuminats.F11);

            _whitePointNameToIndex = new();
            for (int i = 0; i < comboBoxWhitePoint.Items.Count; ++i)
            {
                _whitePointNameToIndex.Add(comboBoxWhitePoint.Items[i]!.ToString()!, i);
            }

            comboBoxColorProfiles.Items.Add(ColorProfile.Predefined.sRGB);
            comboBoxColorProfiles.Items.Add(ColorProfile.Predefined.AdobeRGB);
            comboBoxColorProfiles.Items.Add(ColorProfile.Predefined.WideGamut);

            comboBoxColorProfiles.SelectedIndex = 0;
            colorProfileDetailsControl1.ColorProfile = 
                (ColorProfile)((ColorProfile)comboBoxColorProfiles.SelectedItem!).Clone();
            colorProfileDetailsControl1.PolluteControls();
        }
        private void comboBoxColorProfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            colorProfileDetailsControl1.ColorProfile = 
                (ColorProfile)((ColorProfile)comboBoxColorProfiles.SelectedItem!).Clone();
            comboBoxWhitePoint.SelectedIndex = _whitePointNameToIndex[ColorProfile.WhitePoint.Name];
            colorProfileDetailsControl1.PolluteControls();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ColorProfile)));
        }

        private void comboBoxWhitePoint_SelectedIndexChanged(object sender, EventArgs e)
        {
            ColorProfile.WhitePoint = 
                (WhitePoint)((WhitePoint)comboBoxWhitePoint.SelectedItem!).Clone();
            colorProfileDetailsControl1.PolluteControls();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ColorProfile)));
        }
    }
}
