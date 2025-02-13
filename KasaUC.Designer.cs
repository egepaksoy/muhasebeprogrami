namespace Muhasebe_Programı
{
    partial class KasaUC
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
            btnKasaEkle = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnKasaEkle
            // 
            btnKasaEkle.Font = new Font("Segoe UI", 64F);
            btnKasaEkle.Location = new Point(82, 108);
            btnKasaEkle.Margin = new Padding(0);
            btnKasaEkle.Name = "btnKasaEkle";
            btnKasaEkle.Size = new Size(170, 170);
            btnKasaEkle.TabIndex = 2;
            btnKasaEkle.TabStop = false;
            btnKasaEkle.Text = "+";
            btnKasaEkle.UseVisualStyleBackColor = true;
            btnKasaEkle.Click += btnKasaEkle_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.Location = new Point(432, 50);
            label1.Name = "label1";
            label1.Size = new Size(125, 45);
            label1.TabIndex = 3;
            label1.Text = "Kasalar";
            // 
            // KasaUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label1);
            Controls.Add(btnKasaEkle);
            Name = "KasaUC";
            Size = new Size(995, 681);
            Load += KasaUC_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnKasaEkle;
        private Label label1;
    }
}
