using ColorProfiles.Colors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorProfiles
{
    public partial class ColorProfileDetailsControl : UserControl
    {
        public ColorProfile ColorProfile { get; set; }
        public ColorProfileDetailsControl()
        {
            InitializeComponent();
            ColorProfile = new ColorProfile();
        }

        public void PolluteControls()
        {
            textBoxRX.Text = ColorProfile.RedX.ToString();
            textBoxRY.Text = ColorProfile.RedY.ToString();
            textBoxGX.Text = ColorProfile.GreenX.ToString();
            textBoxGY.Text = ColorProfile.GreenY.ToString();
            textBoxBX.Text = ColorProfile.BlueX.ToString();
            textBoxBY.Text = ColorProfile.BlueY.ToString();

            textBoxWhiteX.Text = ColorProfile.WhitePoint.WhiteX.ToString();
            textBoxWhiteY.Text = ColorProfile.WhitePoint.WhiteY.ToString();

            textBoxGamma.Text = ColorProfile.Gamma.ToString();
        }
        private void textBoxRX_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            ColorProfile.RedX = float.Parse(textBox.Text);
        }

        private void textBoxRY_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            ColorProfile.RedY = float.Parse(textBox.Text);
        }

        private void textBoxGX_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            ColorProfile.GreenX = float.Parse(textBox.Text);
        }

        private void textBoxGY_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            ColorProfile.GreenY = float.Parse(textBox.Text);
        }

        private void textBoxBX_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            ColorProfile.BlueX = float.Parse(textBox.Text);
        }

        private void textBoxBY_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            ColorProfile.BlueY = float.Parse(textBox.Text);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            ColorProfile.WhitePoint.WhiteX = float.Parse(textBox.Text);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            ColorProfile.WhitePoint.WhiteY = float.Parse(textBox.Text);
        }

        private void textBoxGamma_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            ColorProfile.Gamma = float.Parse(textBox.Text);
        }
    }
}
