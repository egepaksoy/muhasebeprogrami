namespace Muhasebe_Programı
{
    partial class TaksitlerUC
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
            labelAktifTaksitler = new Label();
            panelAktifTaksitler = new Panel();
            panelGelecekTaksitler = new Panel();
            labelGelecekTaksitler = new Label();
            SuspendLayout();
            // 
            // labelAktifTaksitler
            // 
            labelAktifTaksitler.AutoSize = true;
            labelAktifTaksitler.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point, 162);
            labelAktifTaksitler.Location = new Point(72, 35);
            labelAktifTaksitler.Name = "labelAktifTaksitler";
            labelAktifTaksitler.Size = new Size(320, 45);
            labelAktifTaksitler.TabIndex = 11;
            labelAktifTaksitler.Text = "Tarihi Gelen Taksitler";
            // 
            // panelAktifTaksitler
            // 
            panelAktifTaksitler.AutoScroll = true;
            panelAktifTaksitler.BackColor = Color.FromArgb(217, 217, 217);
            panelAktifTaksitler.Location = new Point(72, 80);
            panelAktifTaksitler.Margin = new Padding(0);
            panelAktifTaksitler.Name = "panelAktifTaksitler";
            panelAktifTaksitler.Size = new Size(850, 240);
            panelAktifTaksitler.TabIndex = 12;
            // 
            // panelGelecekTaksitler
            // 
            panelGelecekTaksitler.AutoScroll = true;
            panelGelecekTaksitler.BackColor = Color.FromArgb(217, 217, 217);
            panelGelecekTaksitler.Location = new Point(72, 386);
            panelGelecekTaksitler.Margin = new Padding(0);
            panelGelecekTaksitler.Name = "panelGelecekTaksitler";
            panelGelecekTaksitler.Size = new Size(850, 240);
            panelGelecekTaksitler.TabIndex = 14;
            // 
            // labelGelecekTaksitler
            // 
            labelGelecekTaksitler.AutoSize = true;
            labelGelecekTaksitler.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point, 162);
            labelGelecekTaksitler.Location = new Point(72, 341);
            labelGelecekTaksitler.Name = "labelGelecekTaksitler";
            labelGelecekTaksitler.Size = new Size(262, 45);
            labelGelecekTaksitler.TabIndex = 13;
            labelGelecekTaksitler.Text = "Gelecek Taksitler";
            // 
            // TaksitlerUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(224, 231, 239);
            Controls.Add(panelGelecekTaksitler);
            Controls.Add(labelGelecekTaksitler);
            Controls.Add(panelAktifTaksitler);
            Controls.Add(labelAktifTaksitler);
            Name = "TaksitlerUC";
            Size = new Size(995, 681);
            Load += TaksitlerUC_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelAktifTaksitler;
        private Panel panelAktifTaksitler;
        private Panel panelGelecekTaksitler;
        private Label labelGelecekTaksitler;
    }
}
