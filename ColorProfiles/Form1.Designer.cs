namespace ColorProfiles
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            colorProfileControlLoaded = new ColorProfileControl();
            colorProfileControlChanged = new ColorProfileControl();
            pictureBoxLoaded = new PictureBox();
            pictureBoxChanged = new PictureBox();
            menuStrip1 = new MenuStrip();
            wczytajZdjęcieToolStripMenuItem = new ToolStripMenuItem();
            generujToolStripMenuItem = new ToolStripMenuItem();
            zapiszWynikToolStripMenuItem = new ToolStripMenuItem();
            szarośćToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLoaded).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxChanged).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // colorProfileControlLoaded
            // 
            colorProfileControlLoaded.Location = new Point(12, 27);
            colorProfileControlLoaded.Name = "colorProfileControlLoaded";
            colorProfileControlLoaded.Size = new Size(478, 202);
            colorProfileControlLoaded.TabIndex = 0;
            // 
            // colorProfileControlChanged
            // 
            colorProfileControlChanged.Location = new Point(509, 27);
            colorProfileControlChanged.Name = "colorProfileControlChanged";
            colorProfileControlChanged.Size = new Size(478, 202);
            colorProfileControlChanged.TabIndex = 1;
            // 
            // pictureBoxLoaded
            // 
            pictureBoxLoaded.Location = new Point(12, 235);
            pictureBoxLoaded.Name = "pictureBoxLoaded";
            pictureBoxLoaded.Size = new Size(478, 478);
            pictureBoxLoaded.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxLoaded.TabIndex = 2;
            pictureBoxLoaded.TabStop = false;
            // 
            // pictureBoxChanged
            // 
            pictureBoxChanged.Location = new Point(509, 235);
            pictureBoxChanged.Name = "pictureBoxChanged";
            pictureBoxChanged.Size = new Size(478, 477);
            pictureBoxChanged.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxChanged.TabIndex = 3;
            pictureBoxChanged.TabStop = false;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { wczytajZdjęcieToolStripMenuItem, generujToolStripMenuItem, zapiszWynikToolStripMenuItem, szarośćToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(997, 28);
            menuStrip1.TabIndex = 4;
            menuStrip1.Text = "menuStrip1";
            // 
            // wczytajZdjęcieToolStripMenuItem
            // 
            wczytajZdjęcieToolStripMenuItem.Name = "wczytajZdjęcieToolStripMenuItem";
            wczytajZdjęcieToolStripMenuItem.Size = new Size(125, 24);
            wczytajZdjęcieToolStripMenuItem.Text = "Wczytaj zdjęcie";
            wczytajZdjęcieToolStripMenuItem.Click += wczytajZdjęcieToolStripMenuItem_Click;
            // 
            // generujToolStripMenuItem
            // 
            generujToolStripMenuItem.Name = "generujToolStripMenuItem";
            generujToolStripMenuItem.Size = new Size(74, 24);
            generujToolStripMenuItem.Text = "Generuj";
            generujToolStripMenuItem.Click += generujToolStripMenuItem_Click;
            // 
            // zapiszWynikToolStripMenuItem
            // 
            zapiszWynikToolStripMenuItem.Name = "zapiszWynikToolStripMenuItem";
            zapiszWynikToolStripMenuItem.Size = new Size(110, 24);
            zapiszWynikToolStripMenuItem.Text = "Zapisz Wynik";
            // 
            // szarośćToolStripMenuItem
            // 
            szarośćToolStripMenuItem.Name = "szarośćToolStripMenuItem";
            szarośćToolStripMenuItem.Size = new Size(73, 24);
            szarośćToolStripMenuItem.Text = "Szarość";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(997, 724);
            Controls.Add(menuStrip1);
            Controls.Add(pictureBoxChanged);
            Controls.Add(pictureBoxLoaded);
            Controls.Add(colorProfileControlChanged);
            Controls.Add(colorProfileControlLoaded);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "ColorProfilesChanger";
            ((System.ComponentModel.ISupportInitialize)pictureBoxLoaded).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxChanged).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ColorProfileControl colorProfileControlLoaded;
        private ColorProfileControl colorProfileControlChanged;
        private PictureBox pictureBoxLoaded;
        private PictureBox pictureBoxChanged;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem wczytajZdjęcieToolStripMenuItem;
        private ToolStripMenuItem generujToolStripMenuItem;
        private ToolStripMenuItem zapiszWynikToolStripMenuItem;
        private ToolStripMenuItem szarośćToolStripMenuItem;
    }
}
