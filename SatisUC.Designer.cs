namespace Muhasebe_Programı
{
    partial class SatisUC
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
            panel3 = new Panel();
            textBoxVadeMiktari = new TextBox();
            labelVadeMiktari = new Label();
            label6 = new Label();
            textBoxUrunFiyati = new TextBox();
            label8 = new Label();
            textBoxAdet = new TextBox();
            labelOdenen = new Label();
            labelIlkOdemeTarihi = new Label();
            labelTaksitDonemi = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            comboBoxCari = new ComboBox();
            comboBoxUrun = new ComboBox();
            label2 = new Label();
            comboBoxKasa = new ComboBox();
            dateTimePickerIlkOdeme = new DateTimePicker();
            comboBoxTaksitDonemi = new ComboBox();
            btnSatis = new Button();
            textBoxOdenenTutar = new TextBox();
            comboBoxOdemeTuru = new ComboBox();
            labelToplamFiyat = new Label();
            label1 = new Label();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(44, 62, 80);
            panel3.Controls.Add(textBoxVadeMiktari);
            panel3.Controls.Add(labelVadeMiktari);
            panel3.Controls.Add(label6);
            panel3.Controls.Add(textBoxUrunFiyati);
            panel3.Controls.Add(label8);
            panel3.Controls.Add(textBoxAdet);
            panel3.Controls.Add(labelOdenen);
            panel3.Controls.Add(labelIlkOdemeTarihi);
            panel3.Controls.Add(labelTaksitDonemi);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(comboBoxCari);
            panel3.Controls.Add(comboBoxUrun);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(comboBoxKasa);
            panel3.Controls.Add(dateTimePickerIlkOdeme);
            panel3.Controls.Add(comboBoxTaksitDonemi);
            panel3.Controls.Add(btnSatis);
            panel3.Controls.Add(textBoxOdenenTutar);
            panel3.Controls.Add(comboBoxOdemeTuru);
            panel3.Controls.Add(labelToplamFiyat);
            panel3.Location = new Point(217, 61);
            panel3.Name = "panel3";
            panel3.Size = new Size(573, 583);
            panel3.TabIndex = 2;
            // 
            // textBoxVadeMiktari
            // 
            textBoxVadeMiktari.Font = new Font("Segoe UI", 15F);
            textBoxVadeMiktari.Location = new Point(322, 302);
            textBoxVadeMiktari.Name = "textBoxVadeMiktari";
            textBoxVadeMiktari.Size = new Size(178, 34);
            textBoxVadeMiktari.TabIndex = 26;
            textBoxVadeMiktari.Visible = false;
            // 
            // labelVadeMiktari
            // 
            labelVadeMiktari.AutoSize = true;
            labelVadeMiktari.Font = new Font("Segoe UI", 12F);
            labelVadeMiktari.ForeColor = Color.White;
            labelVadeMiktari.Location = new Point(322, 278);
            labelVadeMiktari.Name = "labelVadeMiktari";
            labelVadeMiktari.Size = new Size(71, 21);
            labelVadeMiktari.TabIndex = 25;
            labelVadeMiktari.Text = "Vade ayı:";
            labelVadeMiktari.Visible = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.ForeColor = Color.White;
            label6.Location = new Point(55, 353);
            label6.Name = "label6";
            label6.Size = new Size(46, 21);
            label6.TabIndex = 23;
            label6.Text = "Fiyat:";
            // 
            // textBoxUrunFiyati
            // 
            textBoxUrunFiyati.Font = new Font("Segoe UI", 15F);
            textBoxUrunFiyati.Location = new Point(55, 377);
            textBoxUrunFiyati.Name = "textBoxUrunFiyati";
            textBoxUrunFiyati.Size = new Size(178, 34);
            textBoxUrunFiyati.TabIndex = 22;
            textBoxUrunFiyati.TextChanged += totalHesapla;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F);
            label8.ForeColor = Color.White;
            label8.Location = new Point(55, 279);
            label8.Name = "label8";
            label8.Size = new Size(45, 21);
            label8.TabIndex = 21;
            label8.Text = "Adet:";
            // 
            // textBoxAdet
            // 
            textBoxAdet.Font = new Font("Segoe UI", 15F);
            textBoxAdet.Location = new Point(55, 303);
            textBoxAdet.Name = "textBoxAdet";
            textBoxAdet.Size = new Size(178, 34);
            textBoxAdet.TabIndex = 20;
            textBoxAdet.TextChanged += totalHesapla;
            // 
            // labelOdenen
            // 
            labelOdenen.AutoSize = true;
            labelOdenen.Font = new Font("Segoe UI", 12F);
            labelOdenen.ForeColor = Color.White;
            labelOdenen.Location = new Point(322, 338);
            labelOdenen.Name = "labelOdenen";
            labelOdenen.Size = new Size(130, 21);
            labelOdenen.TabIndex = 19;
            labelOdenen.Text = "Ön Ödeme Tutarı";
            labelOdenen.Visible = false;
            // 
            // labelIlkOdemeTarihi
            // 
            labelIlkOdemeTarihi.AutoSize = true;
            labelIlkOdemeTarihi.Font = new Font("Segoe UI", 12F);
            labelIlkOdemeTarihi.ForeColor = Color.White;
            labelIlkOdemeTarihi.Location = new Point(322, 229);
            labelIlkOdemeTarihi.Name = "labelIlkOdemeTarihi";
            labelIlkOdemeTarihi.Size = new Size(125, 21);
            labelIlkOdemeTarihi.TabIndex = 18;
            labelIlkOdemeTarihi.Text = "İlk Ödeme Tarihi:";
            labelIlkOdemeTarihi.Visible = false;
            // 
            // labelTaksitDonemi
            // 
            labelTaksitDonemi.AutoSize = true;
            labelTaksitDonemi.Font = new Font("Segoe UI", 12F);
            labelTaksitDonemi.ForeColor = Color.White;
            labelTaksitDonemi.Location = new Point(322, 173);
            labelTaksitDonemi.Name = "labelTaksitDonemi";
            labelTaksitDonemi.Size = new Size(110, 21);
            labelTaksitDonemi.TabIndex = 17;
            labelTaksitDonemi.Text = "Taksit Dönemi:";
            labelTaksitDonemi.Visible = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.ForeColor = Color.White;
            label5.Location = new Point(322, 65);
            label5.Name = "label5";
            label5.Size = new Size(100, 21);
            label5.TabIndex = 16;
            label5.Text = "Ödeme Türü:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.ForeColor = Color.White;
            label4.Location = new Point(55, 205);
            label4.Name = "label4";
            label4.Size = new Size(48, 21);
            label4.TabIndex = 15;
            label4.Text = "Ürün:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.ForeColor = Color.White;
            label3.Location = new Point(55, 65);
            label3.Name = "label3";
            label3.Size = new Size(41, 21);
            label3.TabIndex = 14;
            label3.Text = "Cari:";
            // 
            // comboBoxCari
            // 
            comboBoxCari.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCari.Font = new Font("Segoe UI", 15F);
            comboBoxCari.FormattingEnabled = true;
            comboBoxCari.Location = new Point(55, 89);
            comboBoxCari.Name = "comboBoxCari";
            comboBoxCari.Size = new Size(178, 36);
            comboBoxCari.TabIndex = 13;
            comboBoxCari.TabStop = false;
            // 
            // comboBoxUrun
            // 
            comboBoxUrun.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxUrun.Font = new Font("Segoe UI", 15F);
            comboBoxUrun.FormattingEnabled = true;
            comboBoxUrun.Location = new Point(55, 229);
            comboBoxUrun.Name = "comboBoxUrun";
            comboBoxUrun.Size = new Size(178, 36);
            comboBoxUrun.TabIndex = 12;
            comboBoxUrun.TabStop = false;
            comboBoxUrun.SelectedIndexChanged += comboBoxUrun_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.ForeColor = Color.White;
            label2.Location = new Point(322, 438);
            label2.Name = "label2";
            label2.Size = new Size(45, 21);
            label2.TabIndex = 11;
            label2.Text = "Kasa:";
            // 
            // comboBoxKasa
            // 
            comboBoxKasa.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxKasa.Font = new Font("Segoe UI", 12F);
            comboBoxKasa.FormattingEnabled = true;
            comboBoxKasa.Location = new Point(373, 435);
            comboBoxKasa.Name = "comboBoxKasa";
            comboBoxKasa.Size = new Size(127, 29);
            comboBoxKasa.TabIndex = 10;
            comboBoxKasa.TabStop = false;
            // 
            // dateTimePickerIlkOdeme
            // 
            dateTimePickerIlkOdeme.CalendarFont = new Font("Segoe UI", 12F);
            dateTimePickerIlkOdeme.Enabled = false;
            dateTimePickerIlkOdeme.Location = new Point(322, 253);
            dateTimePickerIlkOdeme.Name = "dateTimePickerIlkOdeme";
            dateTimePickerIlkOdeme.Size = new Size(178, 23);
            dateTimePickerIlkOdeme.TabIndex = 8;
            dateTimePickerIlkOdeme.TabStop = false;
            dateTimePickerIlkOdeme.Visible = false;
            dateTimePickerIlkOdeme.ValueChanged += dateTimePickerIlkOdeme_ValueChanged;
            // 
            // comboBoxTaksitDonemi
            // 
            comboBoxTaksitDonemi.Enabled = false;
            comboBoxTaksitDonemi.Font = new Font("Segoe UI", 12F);
            comboBoxTaksitDonemi.FormattingEnabled = true;
            comboBoxTaksitDonemi.Items.AddRange(new object[] { "Aylık", "Haftalık" });
            comboBoxTaksitDonemi.Location = new Point(322, 197);
            comboBoxTaksitDonemi.Name = "comboBoxTaksitDonemi";
            comboBoxTaksitDonemi.Size = new Size(178, 29);
            comboBoxTaksitDonemi.TabIndex = 7;
            comboBoxTaksitDonemi.TabStop = false;
            comboBoxTaksitDonemi.Visible = false;
            // 
            // btnSatis
            // 
            btnSatis.Font = new Font("Segoe UI", 15F);
            btnSatis.Location = new Point(322, 510);
            btnSatis.Name = "btnSatis";
            btnSatis.Size = new Size(178, 38);
            btnSatis.TabIndex = 5;
            btnSatis.Text = "Satış";
            btnSatis.UseVisualStyleBackColor = true;
            btnSatis.Click += btnSatis_Click;
            // 
            // textBoxOdenenTutar
            // 
            textBoxOdenenTutar.Font = new Font("Segoe UI", 15F);
            textBoxOdenenTutar.Location = new Point(322, 362);
            textBoxOdenenTutar.Name = "textBoxOdenenTutar";
            textBoxOdenenTutar.Size = new Size(178, 34);
            textBoxOdenenTutar.TabIndex = 2;
            textBoxOdenenTutar.Visible = false;
            // 
            // comboBoxOdemeTuru
            // 
            comboBoxOdemeTuru.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxOdemeTuru.Font = new Font("Segoe UI", 15F);
            comboBoxOdemeTuru.FormattingEnabled = true;
            comboBoxOdemeTuru.Items.AddRange(new object[] { "Nakit", "Taksit" });
            comboBoxOdemeTuru.Location = new Point(322, 89);
            comboBoxOdemeTuru.Name = "comboBoxOdemeTuru";
            comboBoxOdemeTuru.Size = new Size(178, 36);
            comboBoxOdemeTuru.TabIndex = 1;
            comboBoxOdemeTuru.TabStop = false;
            comboBoxOdemeTuru.SelectedIndexChanged += comboBoxOdemeTuru_SelectedIndexChanged;
            // 
            // labelToplamFiyat
            // 
            labelToplamFiyat.BackColor = Color.FromArgb(224, 231, 239);
            labelToplamFiyat.Font = new Font("Segoe UI", 18F);
            labelToplamFiyat.Location = new Point(322, 475);
            labelToplamFiyat.Name = "labelToplamFiyat";
            labelToplamFiyat.Size = new Size(178, 32);
            labelToplamFiyat.TabIndex = 0;
            labelToplamFiyat.Text = "Toplam Fiyat";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.Location = new Point(453, 13);
            label1.Name = "label1";
            label1.Size = new Size(88, 45);
            label1.TabIndex = 3;
            label1.Text = "Satış";
            // 
            // SatisUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 231, 239);
            Controls.Add(label1);
            Controls.Add(panel3);
            Name = "SatisUC";
            Size = new Size(995, 681);
            Load += SatisUC_Load;
            Enter += LoadDB;
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panel3;
        private ComboBox comboBoxOdemeTuru;
        private Label labelToplamFiyat;
        private Button btnSatis;
        private TextBox textBoxOdenenTutar;
        private DateTimePicker dateTimePickerIlkOdeme;
        private ComboBox comboBoxTaksitDonemi;
        private Label label1;
        private Label label2;
        private ComboBox comboBoxKasa;
        private Label label4;
        private Label label3;
        private ComboBox comboBoxCari;
        private ComboBox comboBoxUrun;
        private Label label5;
        private Label labelTaksitDonemi;
        private Label labelIlkOdemeTarihi;
        private Label labelOdenen;
        private Label label8;
        private TextBox textBoxAdet;
        private Label label6;
        private TextBox textBoxUrunFiyati;
        private Label labelVadeMiktari;
        private TextBox textBoxVadeMiktari;
    }
}
