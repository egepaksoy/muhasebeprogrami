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
            SuspendLayout();
            // 
            // btnKasaKaydet
            // 
            btnKasaKaydet.Location = new Point(102, 503);
            btnKasaKaydet.Name = "btnKasaKaydet";
            btnKasaKaydet.Size = new Size(75, 23);
            btnKasaKaydet.TabIndex = 7;
            btnKasaKaydet.Text = "button1";
            btnKasaKaydet.UseVisualStyleBackColor = true;
            // 
            // textBoxBakiye
            // 
            textBoxBakiye.Font = new Font("Segoe UI", 26F);
            textBoxBakiye.Location = new Point(102, 209);
            textBoxBakiye.Name = "textBoxBakiye";
            textBoxBakiye.Size = new Size(306, 54);
            textBoxBakiye.TabIndex = 5;
            // 
            // textBoxKasaAdi
            // 
            textBoxKasaAdi.Font = new Font("Segoe UI", 26F);
            textBoxKasaAdi.Location = new Point(102, 87);
            textBoxKasaAdi.Name = "textBoxKasaAdi";
            textBoxKasaAdi.Size = new Size(306, 54);
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
            // KasaEkleUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
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
    }
}
