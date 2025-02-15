namespace Muhasebe_Programı
{
    partial class CarilerUC
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
            textBoxCariAdi = new TextBox();
            textBoxTelefonu = new TextBox();
            textBoxAdresi = new TextBox();
            btnCariKaydet = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            panelCariler = new Panel();
            SuspendLayout();
            // 
            // textBoxCariAdi
            // 
            textBoxCariAdi.BackColor = Color.FromArgb(203, 216, 228);
            textBoxCariAdi.BorderStyle = BorderStyle.None;
            textBoxCariAdi.Font = new Font("Segoe UI", 32F);
            textBoxCariAdi.Location = new Point(61, 129);
            textBoxCariAdi.Name = "textBoxCariAdi";
            textBoxCariAdi.Size = new Size(380, 57);
            textBoxCariAdi.TabIndex = 1;
            // 
            // textBoxTelefonu
            // 
            textBoxTelefonu.BackColor = Color.FromArgb(203, 216, 228);
            textBoxTelefonu.BorderStyle = BorderStyle.None;
            textBoxTelefonu.Font = new Font("Segoe UI", 32F);
            textBoxTelefonu.Location = new Point(61, 251);
            textBoxTelefonu.Name = "textBoxTelefonu";
            textBoxTelefonu.Size = new Size(380, 57);
            textBoxTelefonu.TabIndex = 2;
            // 
            // textBoxAdresi
            // 
            textBoxAdresi.BackColor = Color.FromArgb(203, 216, 228);
            textBoxAdresi.BorderStyle = BorderStyle.None;
            textBoxAdresi.Font = new Font("Segoe UI", 18F);
            textBoxAdresi.Location = new Point(61, 382);
            textBoxAdresi.Multiline = true;
            textBoxAdresi.Name = "textBoxAdresi";
            textBoxAdresi.Size = new Size(380, 57);
            textBoxAdresi.TabIndex = 3;
            // 
            // btnCariKaydet
            // 
            btnCariKaydet.Location = new Point(61, 589);
            btnCariKaydet.Name = "btnCariKaydet";
            btnCariKaydet.Size = new Size(380, 42);
            btnCariKaydet.TabIndex = 5;
            btnCariKaydet.Text = "Kaydet";
            btnCariKaydet.UseVisualStyleBackColor = true;
            btnCariKaydet.Click += btnCariKaydet_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.Location = new Point(695, 30);
            label1.Name = "label1";
            label1.Size = new Size(114, 45);
            label1.TabIndex = 9;
            label1.Text = "Cariler";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label2.Location = new Point(186, 30);
            label2.Name = "label2";
            label2.Size = new Size(145, 45);
            label2.TabIndex = 10;
            label2.Text = "Cari Ekle";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(61, 105);
            label3.Name = "label3";
            label3.Size = new Size(65, 21);
            label3.TabIndex = 11;
            label3.Text = "Cari Adı";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(61, 227);
            label4.Name = "label4";
            label4.Size = new Size(131, 21);
            label4.TabIndex = 12;
            label4.Text = "Telefon Numarası";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(61, 358);
            label5.Name = "label5";
            label5.Size = new Size(54, 21);
            label5.TabIndex = 13;
            label5.Text = "Adresi";
            // 
            // panelCariler
            // 
            panelCariler.BackColor = Color.FromArgb(217, 217, 217);
            panelCariler.Location = new Point(573, 105);
            panelCariler.Margin = new Padding(0);
            panelCariler.Name = "panelCariler";
            panelCariler.Size = new Size(360, 526);
            panelCariler.TabIndex = 6;
            // 
            // CarilerUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 231, 239);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(panelCariler);
            Controls.Add(btnCariKaydet);
            Controls.Add(textBoxAdresi);
            Controls.Add(textBoxTelefonu);
            Controls.Add(textBoxCariAdi);
            Name = "CarilerUC";
            Size = new Size(995, 681);
            Load += CarilerUC_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxCariAdi;
        private TextBox textBoxTelefonu;
        private TextBox textBoxAdresi;
        private Button btnCariKaydet;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Panel panelCariler;
    }
}
