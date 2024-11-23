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
        public ColorProfileControl()
        {
            InitializeComponent();

            comboBoxColorProfiles.Items.Add(ColorProfile.Predefined.sRGB);
            comboBoxColorProfiles.Items.Add(ColorProfile.Predefined.AdobeRGB);
            comboBoxColorProfiles.Items.Add(ColorProfile.Predefined.WideGamut);

            comboBoxColorProfiles.SelectedIndex = 0;
            ColorProfile cp = (ColorProfile)comboBoxColorProfiles.SelectedItem!;
            colorProfileDetailsControl1.ColorProfile = (ColorProfile)cp.Clone();
            colorProfileDetailsControl1.PolluteControls();
        }
        private void comboBoxColorProfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            ColorProfile cp = (ColorProfile)comboBoxColorProfiles.SelectedItem!;
            colorProfileDetailsControl1.ColorProfile = (ColorProfile)cp.Clone();
            colorProfileDetailsControl1.PolluteControls();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ColorProfile)));
        }
    }
}
