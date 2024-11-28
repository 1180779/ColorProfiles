namespace ColorProfiles
{
    partial class ColorProfileControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Colors.ColorProfile colorProfile1 = new Colors.ColorProfile();
            colorProfileDetailsControl1 = new ColorProfileDetailsControl();
            comboBoxColorProfiles = new ComboBox();
            comboBoxWhitePoint = new ComboBox();
            SuspendLayout();
            // 
            // colorProfileDetailsControl1
            // 
            colorProfile1.BlueX = 0F;
            colorProfile1.BlueY = 0F;
            colorProfile1.Gamma = 0F;
            colorProfile1.GreenX = 0F;
            colorProfile1.GreenY = 0F;
            colorProfile1.RedX = 0F;
            colorProfile1.RedY = 0F;
            colorProfileDetailsControl1.ColorProfile = colorProfile1;
            colorProfileDetailsControl1.Location = new Point(3, 37);
            colorProfileDetailsControl1.Name = "colorProfileDetailsControl1";
            colorProfileDetailsControl1.Size = new Size(471, 165);
            colorProfileDetailsControl1.TabIndex = 0;
            // 
            // comboBoxColorProfiles
            // 
            comboBoxColorProfiles.FormattingEnabled = true;
            comboBoxColorProfiles.Location = new Point(3, 3);
            comboBoxColorProfiles.Name = "comboBoxColorProfiles";
            comboBoxColorProfiles.Size = new Size(472, 28);
            comboBoxColorProfiles.TabIndex = 1;
            comboBoxColorProfiles.SelectedIndexChanged += comboBoxColorProfiles_SelectedIndexChanged;
            // 
            // comboBoxWhitePoint
            // 
            comboBoxWhitePoint.FormattingEnabled = true;
            comboBoxWhitePoint.Location = new Point(3, 126);
            comboBoxWhitePoint.Name = "comboBoxWhitePoint";
            comboBoxWhitePoint.Size = new Size(61, 28);
            comboBoxWhitePoint.TabIndex = 2;
            comboBoxWhitePoint.SelectedIndexChanged += comboBoxWhitePoint_SelectedIndexChanged;
            // 
            // ColorProfileControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(comboBoxWhitePoint);
            Controls.Add(comboBoxColorProfiles);
            Controls.Add(colorProfileDetailsControl1);
            Name = "ColorProfileControl";
            Size = new Size(478, 201);
            ResumeLayout(false);
        }

        #endregion

        private ColorProfileDetailsControl colorProfileDetailsControl1;
        private ComboBox comboBoxColorProfiles;
        private ComboBox comboBoxWhitePoint;
    }
}
