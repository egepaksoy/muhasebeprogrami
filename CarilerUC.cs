using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProgramLibrary;

namespace Muhasebe_Programı
{
    public partial class CarilerUC : UserControl
    {
        SQLController sqlController = new SQLController("D:\\PROJELER\\Muhasebe Programı\\muhasebe.db");
        List<string> Cariler = new List<string>();
        List<Button> cariButonlar = new List<Button>();
        DesignEditor designEditor = new DesignEditor();

        Color foreColor = Color.White;

        Color backColor = Color.FromArgb(44, 62, 80);
        Color mouseOverColor = Color.FromArgb(0x4E, 0x5D, 0x6B);
        Color mouseDownColor = Color.FromArgb(44, 62, 80);

        int butonGenislik = 310;
        int butonYukseklik = 33;
        int baslangicX = 25;
        int baslangicY = 27;
        int satirlarArasiBosluk = 10;

        Size EkScreenSize = new Size(995, 720);

        EkScreen formCariEkle = new EkScreen(new KasaEkleUC());

        public CarilerUC()
        {
            InitializeComponent();
        }

        private void CarilerUC_Load(object sender, EventArgs e)
        {
            RemoveButtons();
            RenderKasalar();
        }

        private void RemoveButtons()
        {
            foreach (Control btn in cariButonlar)
            {
                this.Controls.Remove(btn);
                btn.Dispose();
            }
        }

        private void RenderKasalar()
        {
            RemoveButtons();
            if (cariButonlar != null)
                cariButonlar.Clear();
            if (Cariler != null)
                Cariler.Clear();

            Cariler = sqlController.LoadCariler();

            string cariAdi;
            if (Cariler == null)
                return;

            for (int i = 0; i < Cariler.Count; i++)
            {
                cariAdi = Cariler[i];
                Button btn = new Button();
                btn.Name = $"btnCari{cariAdi.ToLower().Split()[0]}";
                btn.Text = cariAdi;
                btn.Size = new Size(butonGenislik, butonYukseklik);
                btn.Font = new Font("Segoe UI", 12, FontStyle.Regular);
                btn.Click += (s, e) => btnCari_Click(s, e);

                int x = baslangicX;
                int y = baslangicY + (i * (satirlarArasiBosluk + butonYukseklik));
                btn.Location = new Point(x, y);

                cariButonlar.Add(btn);
                panelCariler.Controls.Add(btn);
            }
            if (cariButonlar != null)
                designEditor.BtnEditor(cariButonlar, foreColor, backColor, mouseOverColor, mouseDownColor);
        }

        public bool CheckValues(string ad, string telefon, string adres)
        {
            string Err = null;

            if (sqlController.GetCari(ad) != null)
                Err = "Cari mevcut";

            if (Err != null)
            {
                MessageBox.Show(Err);
                return false;
            }
            return true;
        }

        private void ClearForm()
        {
            textBoxCariAdi.Text = "";
            textBoxTelefonu.Text = "";
            textBoxAdresi.Text = "";
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            string cari_adi = (sender as Button).Text;

            if (!formCariEkle.Created)
            {
                formCariEkle = new EkScreen(new CariDuzenleUC(cari_adi), EkScreenSize);
                formCariEkle.ShowDialog();
            }

            RenderKasalar();
        }

        private void btnCariKaydet_Click(object sender, EventArgs e)
        {
            string cariAdi = textBoxCariAdi.Text;
            string cariTelefon = textBoxTelefonu.Text;
            string cariAdres = textBoxAdresi.Text;

            if (CheckValues(cariAdi, cariTelefon, cariAdres))
            {
                string errMessage = sqlController.NewCari(cariAdi, cariTelefon, cariAdres);

                if (errMessage != null)
                {
                    MessageBox.Show(errMessage);
                }
                else
                {
                    MessageBox.Show($"Cari {cariAdi} başarıyla kaydedildi");
                    ClearForm();
                }
            }
        }
    }
}
