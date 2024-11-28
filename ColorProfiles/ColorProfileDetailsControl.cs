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
            if (float.TryParse(textBox.Text, out float res))
            {
                ColorProfile.RedX = res;
            }
            else
            {
                MessageBox.Show("Invalid value. Could not convert to float. ", "Invalid value", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxRY_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (float.TryParse(textBox.Text, out float res))
            {
                ColorProfile.RedY = res;
            }
            else
            {
                MessageBox.Show("Invalid value. Could not convert to float. ", "Invalid value",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxGX_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (float.TryParse(textBox.Text, out float res))
            {
                ColorProfile.GreenX = res;
            }
            else
            {
                MessageBox.Show("Invalid value. Could not convert to float. ", "Invalid value",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxGY_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (float.TryParse(textBox.Text, out float res))
            {
                ColorProfile.GreenY = res;
            }
            else
            {
                MessageBox.Show("Invalid value. Could not convert to float. ", "Invalid value",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxBX_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (float.TryParse(textBox.Text, out float res))
            {
                ColorProfile.BlueX = res;
            }
            else
            {
                MessageBox.Show("Invalid value. Could not convert to float. ", "Invalid value",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void textBoxBY_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if(float.TryParse(textBox.Text, out float res))
            {
                ColorProfile.BlueY = res;
            }
            else
            {
                MessageBox.Show("Invalid value. Could not convert to float. ", "Invalid value",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (float.TryParse(textBox.Text, out float res))
            {
                ColorProfile.WhitePoint.WhiteX = res;
            }
            else
            {
                MessageBox.Show("Invalid value. Could not convert to float. ", "Invalid value",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (float.TryParse(textBox.Text, out float res))
            {
                ColorProfile.WhitePoint.WhiteY = res;
            }
            else
            {
                MessageBox.Show("Invalid value. Could not convert to float. ", "Invalid value",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxGamma_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (float.TryParse(textBox.Text, out float res))
            {
                ColorProfile.Gamma = res;
            }
            else
            {
                MessageBox.Show("Invalid value. Could not convert to float. ", "Invalid value",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
