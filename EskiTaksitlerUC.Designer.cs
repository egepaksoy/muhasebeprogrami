namespace Muhasebe_Programı
{
    partial class EskiTaksitlerUC
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
            panelTaksitler = new Panel();
            labelEskiTaksitler = new Label();
            SuspendLayout();
            // 
            // panelTaksitler
            // 
            panelTaksitler.AutoScroll = true;
            panelTaksitler.BackColor = Color.FromArgb(217, 217, 217);
            panelTaksitler.Location = new Point(72, 80);
            panelTaksitler.Margin = new Padding(0);
            panelTaksitler.Name = "panelTaksitler";
            panelTaksitler.Size = new Size(850, 546);
            panelTaksitler.TabIndex = 13;
            // 
            // labelEskiTaksitler
            // 
            labelEskiTaksitler.AutoSize = true;
            labelEskiTaksitler.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point, 162);
            labelEskiTaksitler.Location = new Point(72, 35);
            labelEskiTaksitler.Name = "labelEskiTaksitler";
            labelEskiTaksitler.Size = new Size(205, 45);
            labelEskiTaksitler.TabIndex = 12;
            labelEskiTaksitler.Text = "Eski Taksitler";
            // 
            // EskiTaksitlerUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(labelEskiTaksitler);
            Controls.Add(panelTaksitler);
            Name = "EskiTaksitlerUC";
            Size = new Size(995, 681);
            Load += EskiTaksitlerUC_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelTaksitler;
        private Label labelEskiTaksitler;
    }
}
