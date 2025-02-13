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
            SuspendLayout();
            // 
            // textBoxUrunAdi
            // 
            textBoxUrunAdi.Font = new Font("Segoe UI", 26F);
            textBoxUrunAdi.Location = new Point(94, 81);
            textBoxUrunAdi.Name = "textBoxUrunAdi";
            textBoxUrunAdi.Size = new Size(352, 54);
            textBoxUrunAdi.TabIndex = 0;
            // 
            // textBoxAdet
            // 
            textBoxAdet.Font = new Font("Segoe UI", 26F);
            textBoxAdet.Location = new Point(94, 179);
            textBoxAdet.Name = "textBoxAdet";
            textBoxAdet.Size = new Size(352, 54);
            textBoxAdet.TabIndex = 1;
            // 
            // textBoxBirimFiyat
            // 
            textBoxBirimFiyat.Font = new Font("Segoe UI", 26F);
            textBoxBirimFiyat.Location = new Point(94, 269);
            textBoxBirimFiyat.Name = "textBoxBirimFiyat";
            textBoxBirimFiyat.Size = new Size(352, 54);
            textBoxBirimFiyat.TabIndex = 2;
            // 
            // btnStokKaydet
            // 
            btnStokKaydet.Location = new Point(94, 560);
            btnStokKaydet.Name = "btnStokKaydet";
            btnStokKaydet.Size = new Size(352, 49);
            btnStokKaydet.TabIndex = 3;
            btnStokKaydet.Text = "button1";
            btnStokKaydet.UseVisualStyleBackColor = true;
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
            comboBoxStokTuru.Location = new Point(94, 362);
            comboBoxStokTuru.Name = "comboBoxStokTuru";
            comboBoxStokTuru.Size = new Size(352, 23);
            comboBoxStokTuru.TabIndex = 5;
            comboBoxStokTuru.SelectedIndexChanged += comboBoxStokTuru_SelectedIndexChanged;
            // 
            // textBoxFaturaNo
            // 
            textBoxFaturaNo.Enabled = false;
            textBoxFaturaNo.Font = new Font("Segoe UI", 26F);
            textBoxFaturaNo.Location = new Point(94, 413);
            textBoxFaturaNo.Name = "textBoxFaturaNo";
            textBoxFaturaNo.Size = new Size(352, 54);
            textBoxFaturaNo.TabIndex = 6;
            textBoxFaturaNo.Visible = false;
            // 
            // StokEkleUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(textBoxFaturaNo);
            Controls.Add(comboBoxStokTuru);
            Controls.Add(label1);
            Controls.Add(btnStokKaydet);
            Controls.Add(textBoxBirimFiyat);
            Controls.Add(textBoxAdet);
            Controls.Add(textBoxUrunAdi);
            Name = "StokEkleUC";
            Size = new Size(540, 680);
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
    }
}
