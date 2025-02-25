namespace Muhasebe_Programı
{
    partial class EskiSatislarUC
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
            panelToplamSatislar = new Panel();
            label1 = new Label();
            SuspendLayout();
            // 
            // panelToplamSatislar
            // 
            panelToplamSatislar.AutoScroll = true;
            panelToplamSatislar.BackColor = Color.FromArgb(217, 217, 217);
            panelToplamSatislar.Location = new Point(47, 89);
            panelToplamSatislar.Name = "panelToplamSatislar";
            panelToplamSatislar.Size = new Size(900, 540);
            panelToplamSatislar.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.Location = new Point(402, 22);
            label1.Name = "label1";
            label1.Size = new Size(190, 45);
            label1.TabIndex = 4;
            label1.Text = "Eski Satışlar";
            // 
            // EskiSatislarUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 231, 239);
            Controls.Add(label1);
            Controls.Add(panelToplamSatislar);
            Name = "EskiSatislarUC";
            Size = new Size(995, 681);
            Load += EskiSatislarUC_Load;
            Enter += EskiSatislarUC_Load;
            Leave += EskiSatislarUC_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelToplamSatislar;
        private Label label1;
    }
}
