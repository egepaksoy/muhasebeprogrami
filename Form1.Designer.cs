namespace Muhasebe_Programı
{
    partial class MainScreen
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnCariler = new Button();
            panel1 = new Panel();
            btnEskiSatislar = new Button();
            btnSatis = new Button();
            btnTaksitler = new Button();
            btnStok = new Button();
            btnKasa = new Button();
            mainPanel = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnCariler
            // 
            btnCariler.Font = new Font("Segoe UI", 18F);
            btnCariler.Location = new Point(35, 315);
            btnCariler.Name = "btnCariler";
            btnCariler.Size = new Size(200, 45);
            btnCariler.TabIndex = 0;
            btnCariler.TabStop = false;
            btnCariler.Text = "Cariler";
            btnCariler.UseVisualStyleBackColor = true;
            btnCariler.Click += ChangePanel;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(44, 62, 80);
            panel1.Controls.Add(btnEskiSatislar);
            panel1.Controls.Add(btnSatis);
            panel1.Controls.Add(btnTaksitler);
            panel1.Controls.Add(btnStok);
            panel1.Controls.Add(btnKasa);
            panel1.Controls.Add(btnCariler);
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(270, 681);
            panel1.TabIndex = 4;
            // 
            // btnEskiSatislar
            // 
            btnEskiSatislar.Font = new Font("Segoe UI", 18F);
            btnEskiSatislar.Location = new Point(35, 381);
            btnEskiSatislar.Name = "btnEskiSatislar";
            btnEskiSatislar.Size = new Size(200, 45);
            btnEskiSatislar.TabIndex = 7;
            btnEskiSatislar.TabStop = false;
            btnEskiSatislar.Text = "Eski Satışlar";
            btnEskiSatislar.UseVisualStyleBackColor = true;
            btnEskiSatislar.Click += ChangePanel;
            // 
            // btnSatis
            // 
            btnSatis.Font = new Font("Segoe UI", 18F);
            btnSatis.Location = new Point(35, 52);
            btnSatis.Name = "btnSatis";
            btnSatis.Size = new Size(200, 45);
            btnSatis.TabIndex = 6;
            btnSatis.TabStop = false;
            btnSatis.Text = "Satış";
            btnSatis.UseVisualStyleBackColor = true;
            btnSatis.Click += ChangePanel;
            // 
            // btnTaksitler
            // 
            btnTaksitler.Font = new Font("Segoe UI", 18F);
            btnTaksitler.Location = new Point(35, 249);
            btnTaksitler.Name = "btnTaksitler";
            btnTaksitler.Size = new Size(200, 45);
            btnTaksitler.TabIndex = 5;
            btnTaksitler.TabStop = false;
            btnTaksitler.Text = "Taksitler";
            btnTaksitler.UseVisualStyleBackColor = true;
            btnTaksitler.Click += ChangePanel;
            // 
            // btnStok
            // 
            btnStok.Font = new Font("Segoe UI", 18F);
            btnStok.Location = new Point(35, 183);
            btnStok.Name = "btnStok";
            btnStok.Size = new Size(200, 45);
            btnStok.TabIndex = 2;
            btnStok.TabStop = false;
            btnStok.Text = "Stok";
            btnStok.UseVisualStyleBackColor = true;
            btnStok.Click += ChangePanel;
            // 
            // btnKasa
            // 
            btnKasa.Font = new Font("Segoe UI", 18F);
            btnKasa.Location = new Point(35, 117);
            btnKasa.Name = "btnKasa";
            btnKasa.Size = new Size(200, 45);
            btnKasa.TabIndex = 1;
            btnKasa.TabStop = false;
            btnKasa.Text = "Kasa";
            btnKasa.UseVisualStyleBackColor = true;
            btnKasa.Click += ChangePanel;
            // 
            // mainPanel
            // 
            mainPanel.Location = new Point(270, 0);
            mainPanel.Margin = new Padding(0);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(995, 681);
            mainPanel.TabIndex = 5;
            // 
            // MainScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 231, 239);
            ClientSize = new Size(1264, 681);
            Controls.Add(mainPanel);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MainScreen";
            Text = "Muhasebe Programı";
            Load += MainScreen_Load;
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Button btnCariler;
        private Panel panel1;
        private Panel mainPanel;
        private Button btnStok;
        private Button btnKasa;
        private Button btnTaksitler;
        private Button btnSatis;
        private Button btnEskiSatislar;
    }
}
