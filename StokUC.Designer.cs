namespace Muhasebe_Programı
{
    partial class StokUC
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
            btnStokEkle = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnStokEkle
            // 
            btnStokEkle.Font = new Font("Segoe UI", 64F);
            btnStokEkle.Location = new Point(82, 108);
            btnStokEkle.Margin = new Padding(0);
            btnStokEkle.Name = "btnStokEkle";
            btnStokEkle.Size = new Size(170, 170);
            btnStokEkle.TabIndex = 1;
            btnStokEkle.TabStop = false;
            btnStokEkle.Text = "+";
            btnStokEkle.UseVisualStyleBackColor = true;
            btnStokEkle.Click += btnStokEkle_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.Location = new Point(432, 30);
            label1.Name = "label1";
            label1.Size = new Size(130, 45);
            label1.TabIndex = 2;
            label1.Text = "Ürünler";
            // 
            // StokUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(224, 231, 239);
            Controls.Add(label1);
            Controls.Add(btnStokEkle);
            Name = "StokUC";
            Size = new Size(995, 681);
            Load += StokUC_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnStokEkle;
        private Label label1;
    }
}
