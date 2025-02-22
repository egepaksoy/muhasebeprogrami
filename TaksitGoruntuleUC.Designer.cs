namespace Muhasebe_Programı
{
    partial class TaksitGoruntuleUC
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
            labelCariAdi = new Label();
            labelSatisTarihi = new Label();
            labelUrunAdi = new Label();
            labelToplamTutar = new Label();
            labelKalanTaksitTutar = new Label();
            labelSonrakiOdemeTarihi = new Label();
            btnOdendi = new Button();
            SuspendLayout();
            // 
            // labelCariAdi
            // 
            labelCariAdi.AutoSize = true;
            labelCariAdi.Font = new Font("Segoe UI", 25F);
            labelCariAdi.Location = new Point(69, 62);
            labelCariAdi.Name = "labelCariAdi";
            labelCariAdi.Size = new Size(137, 46);
            labelCariAdi.TabIndex = 0;
            labelCariAdi.Text = "Cari Adı";
            // 
            // labelSatisTarihi
            // 
            labelSatisTarihi.AutoSize = true;
            labelSatisTarihi.Font = new Font("Segoe UI", 18F);
            labelSatisTarihi.Location = new Point(69, 127);
            labelSatisTarihi.Name = "labelSatisTarihi";
            labelSatisTarihi.Size = new Size(124, 32);
            labelSatisTarihi.TabIndex = 1;
            labelSatisTarihi.Text = "Satış tarihi";
            // 
            // labelUrunAdi
            // 
            labelUrunAdi.AutoSize = true;
            labelUrunAdi.Font = new Font("Segoe UI", 25F);
            labelUrunAdi.Location = new Point(69, 225);
            labelUrunAdi.Name = "labelUrunAdi";
            labelUrunAdi.Size = new Size(152, 46);
            labelUrunAdi.TabIndex = 2;
            labelUrunAdi.Text = "Ürün Adı";
            // 
            // labelToplamTutar
            // 
            labelToplamTutar.AutoSize = true;
            labelToplamTutar.Font = new Font("Segoe UI", 25F);
            labelToplamTutar.Location = new Point(69, 271);
            labelToplamTutar.Name = "labelToplamTutar";
            labelToplamTutar.Size = new Size(216, 46);
            labelToplamTutar.TabIndex = 3;
            labelToplamTutar.Text = "Toplam Tutar";
            // 
            // labelKalanTaksitTutar
            // 
            labelKalanTaksitTutar.AutoSize = true;
            labelKalanTaksitTutar.Font = new Font("Segoe UI", 18F);
            labelKalanTaksitTutar.Location = new Point(69, 327);
            labelKalanTaksitTutar.Name = "labelKalanTaksitTutar";
            labelKalanTaksitTutar.Size = new Size(278, 32);
            labelKalanTaksitTutar.TabIndex = 4;
            labelKalanTaksitTutar.Text = "Kalan Taksit / kalan Tutar";
            // 
            // labelSonrakiOdemeTarihi
            // 
            labelSonrakiOdemeTarihi.AutoSize = true;
            labelSonrakiOdemeTarihi.Font = new Font("Segoe UI", 18F);
            labelSonrakiOdemeTarihi.Location = new Point(69, 359);
            labelSonrakiOdemeTarihi.Name = "labelSonrakiOdemeTarihi";
            labelSonrakiOdemeTarihi.Size = new Size(242, 32);
            labelSonrakiOdemeTarihi.TabIndex = 5;
            labelSonrakiOdemeTarihi.Text = "Sonraki Ödeme Tarihi";
            // 
            // btnOdendi
            // 
            btnOdendi.Font = new Font("Segoe UI", 16F);
            btnOdendi.Location = new Point(69, 453);
            btnOdendi.Name = "btnOdendi";
            btnOdendi.Size = new Size(384, 55);
            btnOdendi.TabIndex = 6;
            btnOdendi.Text = "Ödeme Yapıldı";
            btnOdendi.UseVisualStyleBackColor = true;
            btnOdendi.Click += btnOdendi_Click;
            // 
            // TaksitGoruntuleUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnOdendi);
            Controls.Add(labelSonrakiOdemeTarihi);
            Controls.Add(labelKalanTaksitTutar);
            Controls.Add(labelToplamTutar);
            Controls.Add(labelUrunAdi);
            Controls.Add(labelSatisTarihi);
            Controls.Add(labelCariAdi);
            Name = "TaksitGoruntuleUC";
            Size = new Size(524, 642);
            Load += TaksitGoruntuleUC_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelCariAdi;
        private Label labelSatisTarihi;
        private Label labelUrunAdi;
        private Label labelToplamTutar;
        private Label labelKalanTaksitTutar;
        private Label labelSonrakiOdemeTarihi;
        private Button btnOdendi;
    }
}
