namespace Muhasebe_Programı
{
    partial class StokEkleUC
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
            textBoxUrunAdi = new TextBox();
            textBoxAdet = new TextBox();
            textBoxBirimFiyat = new TextBox();
            btnStokKaydet = new Button();
            label1 = new Label();
            comboBoxStokTuru = new ComboBox();
            textBoxFaturaNo = new TextBox();
            label2 = new Label();
            labelFaturaNo = new Label();
            label4 = new Label();
            label5 = new Label();
            btnSil = new Button();
            SuspendLayout();
            // 
            // textBoxUrunAdi
            // 
            textBoxUrunAdi.Font = new Font("Segoe UI", 26F);
            textBoxUrunAdi.Location = new Point(94, 129);
            textBoxUrunAdi.Name = "textBoxUrunAdi";
            textBoxUrunAdi.Size = new Size(352, 54);
            textBoxUrunAdi.TabIndex = 0;
            // 
            // textBoxAdet
            // 
            textBoxAdet.Font = new Font("Segoe UI", 26F);
            textBoxAdet.Location = new Point(94, 223);
            textBoxAdet.Name = "textBoxAdet";
            textBoxAdet.Size = new Size(352, 54);
            textBoxAdet.TabIndex = 1;
            // 
            // textBoxBirimFiyat
            // 
            textBoxBirimFiyat.Font = new Font("Segoe UI", 26F);
            textBoxBirimFiyat.Location = new Point(94, 318);
            textBoxBirimFiyat.Name = "textBoxBirimFiyat";
            textBoxBirimFiyat.Size = new Size(352, 54);
            textBoxBirimFiyat.TabIndex = 2;
            // 
            // btnStokKaydet
            // 
            btnStokKaydet.Location = new Point(94, 560);
            btnStokKaydet.Name = "btnStokKaydet";
            btnStokKaydet.Size = new Size(297, 49);
            btnStokKaydet.TabIndex = 3;
            btnStokKaydet.Text = "Kaydet";
            btnStokKaydet.UseVisualStyleBackColor = true;
            btnStokKaydet.Click += btnStokKaydet_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.Location = new Point(205, 20);
            label1.Name = "label1";
            label1.Size = new Size(161, 45);
            label1.TabIndex = 4;
            label1.Text = "Ürün Ekle";
            // 
            // comboBoxStokTuru
            // 
            comboBoxStokTuru.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxStokTuru.FormattingEnabled = true;
            comboBoxStokTuru.Items.AddRange(new object[] { "Sayım", "Alım" });
            comboBoxStokTuru.Location = new Point(94, 391);
            comboBoxStokTuru.Name = "comboBoxStokTuru";
            comboBoxStokTuru.Size = new Size(352, 23);
            comboBoxStokTuru.TabIndex = 5;
            comboBoxStokTuru.SelectedIndexChanged += comboBoxStokTuru_SelectedIndexChanged;
            // 
            // textBoxFaturaNo
            // 
            textBoxFaturaNo.Enabled = false;
            textBoxFaturaNo.Font = new Font("Segoe UI", 26F);
            textBoxFaturaNo.Location = new Point(94, 447);
            textBoxFaturaNo.Name = "textBoxFaturaNo";
            textBoxFaturaNo.Size = new Size(352, 54);
            textBoxFaturaNo.TabIndex = 6;
            textBoxFaturaNo.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(94, 105);
            label2.Name = "label2";
            label2.Size = new Size(72, 21);
            label2.TabIndex = 7;
            label2.Text = "Ürün Adı";
            // 
            // labelFaturaNo
            // 
            labelFaturaNo.AutoSize = true;
            labelFaturaNo.Enabled = false;
            labelFaturaNo.Font = new Font("Segoe UI", 12F);
            labelFaturaNo.Location = new Point(94, 423);
            labelFaturaNo.Name = "labelFaturaNo";
            labelFaturaNo.Size = new Size(78, 21);
            labelFaturaNo.TabIndex = 8;
            labelFaturaNo.Text = "Fatura No";
            labelFaturaNo.Visible = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(94, 294);
            label4.Name = "label4";
            label4.Size = new Size(88, 21);
            label4.TabIndex = 9;
            label4.Text = "Birim Fiyatı";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(94, 199);
            label5.Name = "label5";
            label5.Size = new Size(89, 21);
            label5.TabIndex = 10;
            label5.Text = "Ürün Adedi";
            // 
            // btnSil
            // 
            btnSil.Location = new Point(397, 560);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(49, 49);
            btnSil.TabIndex = 11;
            btnSil.Text = "Sil";
            btnSil.UseVisualStyleBackColor = true;
            btnSil.Click += btnSil_Click;
            // 
            // StokEkleUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnSil);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(labelFaturaNo);
            Controls.Add(label2);
            Controls.Add(textBoxFaturaNo);
            Controls.Add(comboBoxStokTuru);
            Controls.Add(label1);
            Controls.Add(btnStokKaydet);
            Controls.Add(textBoxBirimFiyat);
            Controls.Add(textBoxAdet);
            Controls.Add(textBoxUrunAdi);
            Name = "StokEkleUC";
            Size = new Size(540, 680);
            Load += StokEkleUC_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxUrunAdi;
        private TextBox textBoxAdet;
        private TextBox textBoxBirimFiyat;
        private Button btnStokKaydet;
        private Label label1;
        private ComboBox comboBoxStokTuru;
        private TextBox textBoxFaturaNo;
        private Label label2;
        private Label labelFaturaNo;
        private Label label4;
        private Label label5;
        private Button btnSil;
    }
}
