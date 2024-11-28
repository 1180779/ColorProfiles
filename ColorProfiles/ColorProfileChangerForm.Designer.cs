namespace ColorProfiles
{
    partial class ColorProfileChangerForm
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
            menuStripOptions = new MenuStrip();
            wczytajZdjęcieToolStripMenuItem = new ToolStripMenuItem();
            generujToolStripMenuItem = new ToolStripMenuItem();
            zapiszWynikToolStripMenuItem = new ToolStripMenuItem();
            szarośćToolStripMenuItem = new ToolStripMenuItem();
            wynikKonwersjiToolStripMenuItem = new ToolStripMenuItem();
            wynikToolStripMenuItem = new ToolStripMenuItem();
            nieprzekonwertowanePikseleToolStripMenuItem = new ToolStripMenuItem();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLoaded).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxChanged).BeginInit();
            menuStripOptions.SuspendLayout();
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
            // menuStripOptions
            // 
            menuStripOptions.ImageScalingSize = new Size(20, 20);
            menuStripOptions.Items.AddRange(new ToolStripItem[] { wczytajZdjęcieToolStripMenuItem, generujToolStripMenuItem, zapiszWynikToolStripMenuItem, szarośćToolStripMenuItem, wynikKonwersjiToolStripMenuItem });
            menuStripOptions.Location = new Point(0, 0);
            menuStripOptions.Name = "menuStripOptions";
            menuStripOptions.Size = new Size(997, 28);
            menuStripOptions.TabIndex = 4;
            menuStripOptions.Text = "menuStrip1";
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
            zapiszWynikToolStripMenuItem.Click += zapiszWynikToolStripMenuItem_Click;
            // 
            // szarośćToolStripMenuItem
            // 
            szarośćToolStripMenuItem.Name = "szarośćToolStripMenuItem";
            szarośćToolStripMenuItem.Size = new Size(14, 24);
            // 
            // wynikKonwersjiToolStripMenuItem
            // 
            wynikKonwersjiToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { wynikToolStripMenuItem, nieprzekonwertowanePikseleToolStripMenuItem });
            wynikKonwersjiToolStripMenuItem.Name = "wynikKonwersjiToolStripMenuItem";
            wynikKonwersjiToolStripMenuItem.Size = new Size(129, 24);
            wynikKonwersjiToolStripMenuItem.Text = "Wynik konwersji";
            // 
            // wynikToolStripMenuItem
            // 
            wynikToolStripMenuItem.Checked = true;
            wynikToolStripMenuItem.CheckState = CheckState.Checked;
            wynikToolStripMenuItem.Name = "wynikToolStripMenuItem";
            wynikToolStripMenuItem.Size = new Size(291, 26);
            wynikToolStripMenuItem.Text = "Wynik";
            wynikToolStripMenuItem.Click += wynikToolStripMenuItem_Click;
            // 
            // nieprzekonwertowanePikseleToolStripMenuItem
            // 
            nieprzekonwertowanePikseleToolStripMenuItem.Name = "nieprzekonwertowanePikseleToolStripMenuItem";
            nieprzekonwertowanePikseleToolStripMenuItem.Size = new Size(291, 26);
            nieprzekonwertowanePikseleToolStripMenuItem.Text = "Nieprzekonwertowane piksele";
            nieprzekonwertowanePikseleToolStripMenuItem.Click += nieprzekonwertowanePikseleToolStripMenuItem_Click;
            // 
            // ColorProfileChangerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(997, 724);
            Controls.Add(menuStripOptions);
            Controls.Add(pictureBoxChanged);
            Controls.Add(pictureBoxLoaded);
            Controls.Add(colorProfileControlChanged);
            Controls.Add(colorProfileControlLoaded);
            MainMenuStrip = menuStripOptions;
            Name = "ColorProfileChangerForm";
            Text = "ColorProfilesChanger";
            ((System.ComponentModel.ISupportInitialize)pictureBoxLoaded).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxChanged).EndInit();
            menuStripOptions.ResumeLayout(false);
            menuStripOptions.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ColorProfileControl colorProfileControlLoaded;
        private ColorProfileControl colorProfileControlChanged;
        private PictureBox pictureBoxLoaded;
        private PictureBox pictureBoxChanged;
        private MenuStrip menuStripOptions;
        private ToolStripMenuItem wczytajZdjęcieToolStripMenuItem;
        private ToolStripMenuItem generujToolStripMenuItem;
        private ToolStripMenuItem zapiszWynikToolStripMenuItem;
        private ToolStripMenuItem szarośćToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private ToolStripMenuItem wynikKonwersjiToolStripMenuItem;
        private ToolStripMenuItem wynikToolStripMenuItem;
        private ToolStripMenuItem nieprzekonwertowanePikseleToolStripMenuItem;
    }
}
