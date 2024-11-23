namespace ColorProfiles
{
    partial class UserControl1
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            textBoxRX = new TextBox();
            textBoxRY = new TextBox();
            textBoxGY = new TextBox();
            textBoxGX = new TextBox();
            textBoxBY = new TextBox();
            textBoxBX = new TextBox();
            label6 = new Label();
            textBoxGamma = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(379, 5);
            label1.Name = "label1";
            label1.Size = new Size(18, 20);
            label1.TabIndex = 0;
            label1.Text = "X";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(455, 5);
            label2.Name = "label2";
            label2.Size = new Size(17, 20);
            label2.TabIndex = 1;
            label2.Text = "Y";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(260, 43);
            label3.Name = "label3";
            label3.Size = new Size(73, 20);
            label3.TabIndex = 2;
            label3.Text = "Czerwony";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(259, 83);
            label4.Name = "label4";
            label4.Size = new Size(58, 20);
            label4.TabIndex = 3;
            label4.Text = "Zielony";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(259, 128);
            label5.Name = "label5";
            label5.Size = new Size(70, 20);
            label5.TabIndex = 4;
            label5.Text = "Niebieski";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBoxRX
            // 
            textBoxRX.Location = new Point(355, 40);
            textBoxRX.Name = "textBoxRX";
            textBoxRX.Size = new Size(61, 27);
            textBoxRX.TabIndex = 5;
            // 
            // textBoxRY
            // 
            textBoxRY.Location = new Point(436, 40);
            textBoxRY.Name = "textBoxRY";
            textBoxRY.Size = new Size(61, 27);
            textBoxRY.TabIndex = 6;
            // 
            // textBoxGY
            // 
            textBoxGY.Location = new Point(436, 83);
            textBoxGY.Name = "textBoxGY";
            textBoxGY.Size = new Size(61, 27);
            textBoxGY.TabIndex = 8;
            // 
            // textBoxGX
            // 
            textBoxGX.Location = new Point(355, 83);
            textBoxGX.Name = "textBoxGX";
            textBoxGX.Size = new Size(61, 27);
            textBoxGX.TabIndex = 7;
            // 
            // textBoxBY
            // 
            textBoxBY.Location = new Point(436, 128);
            textBoxBY.Name = "textBoxBY";
            textBoxBY.Size = new Size(61, 27);
            textBoxBY.TabIndex = 10;
            // 
            // textBoxBX
            // 
            textBoxBX.Location = new Point(355, 128);
            textBoxBX.Name = "textBoxBX";
            textBoxBX.Size = new Size(61, 27);
            textBoxBX.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(13, 15);
            label6.Name = "label6";
            label6.Size = new Size(61, 20);
            label6.TabIndex = 11;
            label6.Text = "Gamma";
            // 
            // textBoxGamma
            // 
            textBoxGamma.Location = new Point(89, 12);
            textBoxGamma.Name = "textBoxGamma";
            textBoxGamma.Size = new Size(107, 27);
            textBoxGamma.TabIndex = 12;
            // 
            // UserControl1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(textBoxGamma);
            Controls.Add(label6);
            Controls.Add(textBoxBY);
            Controls.Add(textBoxBX);
            Controls.Add(textBoxGY);
            Controls.Add(textBoxGX);
            Controls.Add(textBoxRY);
            Controls.Add(textBoxRX);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "UserControl1";
            Size = new Size(500, 314);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox textBoxRX;
        private TextBox textBoxRY;
        private TextBox textBoxGY;
        private TextBox textBoxGX;
        private TextBox textBoxBY;
        private TextBox textBoxBX;
        private Label label6;
        private TextBox textBoxGamma;
    }
}
