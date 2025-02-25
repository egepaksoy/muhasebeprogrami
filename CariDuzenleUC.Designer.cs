namespace Muhasebe_Programı
{
    partial class CariDuzenleUC
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
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            btnCariGuncelle = new Button();
            textBoxAdresi = new TextBox();
            textBoxTelefonu = new TextBox();
            textBoxCariAdi = new TextBox();
            label2 = new Label();
            label1 = new Label();
            panelTaksitler = new Panel();
            label6 = new Label();
            panelSatislar = new Panel();
            btnSil = new Button();
            SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(61, 358);
            label5.Name = "label5";
            label5.Size = new Size(54, 21);
            label5.TabIndex = 20;
            label5.Text = "Adresi";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(61, 227);
            label4.Name = "label4";
            label4.Size = new Size(131, 21);
            label4.TabIndex = 19;
            label4.Text = "Telefon Numarası";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(61, 105);
            label3.Name = "label3";
            label3.Size = new Size(65, 21);
            label3.TabIndex = 18;
            label3.Text = "Cari Adı";
            // 
            // btnCariGuncelle
            // 
            btnCariGuncelle.Location = new Point(61, 589);
            btnCariGuncelle.Name = "btnCariGuncelle";
            btnCariGuncelle.Size = new Size(380, 42);
            btnCariGuncelle.TabIndex = 17;
            btnCariGuncelle.Text = "Güncelle";
            btnCariGuncelle.UseVisualStyleBackColor = true;
            btnCariGuncelle.Click += btnCariGuncelle_Click;
            // 
            // textBoxAdresi
            // 
            textBoxAdresi.BackColor = Color.FromArgb(203, 216, 228);
            textBoxAdresi.BorderStyle = BorderStyle.None;
            textBoxAdresi.Font = new Font("Segoe UI", 12F);
            textBoxAdresi.Location = new Point(61, 382);
            textBoxAdresi.Multiline = true;
            textBoxAdresi.Name = "textBoxAdresi";
            textBoxAdresi.Size = new Size(380, 57);
            textBoxAdresi.TabIndex = 16;
            // 
            // textBoxTelefonu
            // 
            textBoxTelefonu.BackColor = Color.FromArgb(203, 216, 228);
            textBoxTelefonu.BorderStyle = BorderStyle.None;
            textBoxTelefonu.Font = new Font("Segoe UI", 32F);
            textBoxTelefonu.Location = new Point(61, 251);
            textBoxTelefonu.Name = "textBoxTelefonu";
            textBoxTelefonu.Size = new Size(380, 57);
            textBoxTelefonu.TabIndex = 15;
            // 
            // textBoxCariAdi
            // 
            textBoxCariAdi.BackColor = Color.FromArgb(203, 216, 228);
            textBoxCariAdi.BorderStyle = BorderStyle.None;
            textBoxCariAdi.Font = new Font("Segoe UI", 32F);
            textBoxCariAdi.Location = new Point(61, 129);
            textBoxCariAdi.Name = "textBoxCariAdi";
            textBoxCariAdi.Size = new Size(380, 57);
            textBoxCariAdi.TabIndex = 14;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label2.Location = new Point(154, 30);
            label2.Name = "label2";
            label2.Size = new Size(204, 45);
            label2.TabIndex = 22;
            label2.Text = "Cari Düzenle";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.Location = new Point(573, 30);
            label1.Name = "label1";
            label1.Size = new Size(140, 45);
            label1.TabIndex = 21;
            label1.Text = "Taksitler";
            // 
            // panelTaksitler
            // 
            panelTaksitler.AutoScroll = true;
            panelTaksitler.BackColor = Color.FromArgb(217, 217, 217);
            panelTaksitler.Location = new Point(573, 75);
            panelTaksitler.Margin = new Padding(0);
            panelTaksitler.Name = "panelTaksitler";
            panelTaksitler.Size = new Size(360, 243);
            panelTaksitler.TabIndex = 23;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label6.Location = new Point(573, 358);
            label6.Margin = new Padding(0);
            label6.Name = "label6";
            label6.Size = new Size(125, 45);
            label6.TabIndex = 24;
            label6.Text = "Satışlar";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panelSatislar
            // 
            panelSatislar.AutoScroll = true;
            panelSatislar.BackColor = Color.FromArgb(217, 217, 217);
            panelSatislar.Location = new Point(573, 403);
            panelSatislar.Margin = new Padding(0);
            panelSatislar.Name = "panelSatislar";
            panelSatislar.Size = new Size(360, 228);
            panelSatislar.TabIndex = 24;
            // 
            // btnSil
            // 
            btnSil.Location = new Point(61, 496);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(84, 33);
            btnSil.TabIndex = 25;
            btnSil.Text = "Cariyi Sil";
            btnSil.UseVisualStyleBackColor = true;
            btnSil.Click += btnSil_Click;
            // 
            // CariDuzenleUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 231, 239);
            Controls.Add(btnSil);
            Controls.Add(panelSatislar);
            Controls.Add(label6);
            Controls.Add(panelTaksitler);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(btnCariGuncelle);
            Controls.Add(textBoxAdresi);
            Controls.Add(textBoxTelefonu);
            Controls.Add(textBoxCariAdi);
            Name = "CariDuzenleUC";
            Size = new Size(995, 681);
            Load += CariDuzenleUC_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label5;
        private Label label4;
        private Label label3;
        private Button btnCariGuncelle;
        private TextBox textBoxAdresi;
        private TextBox textBoxTelefonu;
        private TextBox textBoxCariAdi;
        private Label label2;
        private Label label1;
        private Panel panelTaksitler;
        private Label label6;
        private Panel panelSatislar;
        private Button btnSil;
    }
}
