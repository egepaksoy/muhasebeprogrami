namespace Muhasebe_Programı
{
    partial class KasaEkleUC
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
            btnKasaKaydet = new Button();
            textBoxBakiye = new TextBox();
            textBoxKasaAdi = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnSil = new Button();
            SuspendLayout();
            // 
            // btnKasaKaydet
            // 
            btnKasaKaydet.Location = new Point(94, 560);
            btnKasaKaydet.Name = "btnKasaKaydet";
            btnKasaKaydet.Size = new Size(297, 49);
            btnKasaKaydet.TabIndex = 7;
            btnKasaKaydet.Text = "Kaydet";
            btnKasaKaydet.UseVisualStyleBackColor = true;
            btnKasaKaydet.Click += btnKasaKaydet_Click;
            // 
            // textBoxBakiye
            // 
            textBoxBakiye.Font = new Font("Segoe UI", 26F);
            textBoxBakiye.Location = new Point(94, 303);
            textBoxBakiye.Name = "textBoxBakiye";
            textBoxBakiye.Size = new Size(352, 54);
            textBoxBakiye.TabIndex = 5;
            // 
            // textBoxKasaAdi
            // 
            textBoxKasaAdi.Font = new Font("Segoe UI", 26F);
            textBoxKasaAdi.Location = new Point(94, 166);
            textBoxKasaAdi.Name = "textBoxKasaAdi";
            textBoxKasaAdi.Size = new Size(352, 54);
            textBoxKasaAdi.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.Location = new Point(190, 20);
            label1.Name = "label1";
            label1.Size = new Size(156, 45);
            label1.TabIndex = 8;
            label1.Text = "Kasa Ekle";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(102, 142);
            label2.Name = "label2";
            label2.Size = new Size(69, 21);
            label2.TabIndex = 9;
            label2.Text = "Kasa Adı";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(94, 279);
            label3.Name = "label3";
            label3.Size = new Size(55, 21);
            label3.TabIndex = 10;
            label3.Text = "Bakiye";
            // 
            // btnSil
            // 
            btnSil.Location = new Point(397, 560);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(49, 49);
            btnSil.TabIndex = 12;
            btnSil.Text = "Sil";
            btnSil.UseVisualStyleBackColor = true;
            btnSil.Click += btnSil_Click;
            // 
            // KasaEkleUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnSil);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnKasaKaydet);
            Controls.Add(textBoxBakiye);
            Controls.Add(textBoxKasaAdi);
            Name = "KasaEkleUC";
            Size = new Size(540, 680);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnKasaKaydet;
        private TextBox textBoxBakiye;
        private TextBox textBoxKasaAdi;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnSil;
    }
}
