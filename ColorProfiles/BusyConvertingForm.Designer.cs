﻿namespace ColorProfiles
{
    partial class BusyConvertingForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 27);
            label1.Name = "label1";
            label1.Size = new Size(253, 20);
            label1.TabIndex = 0;
            label1.Text = "Generowanie obrazu. Proszę czekać...";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // BusyConvertingForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(337, 78);
            ControlBox = false;
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "BusyConvertingForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Generowanie";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
    }
}