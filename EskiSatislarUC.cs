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
    public partial class EskiSatislarUC : UserControl
    {
        List<List<string>> Satislar = new List<List<string>>();
        List<Button> satisButonlari = new List<Button>();

        SQLController sqlController = new SQLController();
        DesignEditor designEditor = new DesignEditor();

        Color foreColor = Color.White;

        Color backColor = Color.FromArgb(44, 62, 80);
        Color mouseOverColor = Color.FromArgb(0x4E, 0x5D, 0x6B);
        Color mouseDownColor = Color.FromArgb(44, 62, 80);

        int butonGenislik = 860;
        int butonYukseklik = 50;
        int baslangicX = 20;
        int baslangicY = 20;
        int satirlarArasiBosluk = 10;

        EkScreen formSatisGoruntule = new EkScreen(new EskiSatisGoruntuleUC());

        public EskiSatislarUC()
        {
            InitializeComponent();
        }

        private void RemovePanels()
        {
            foreach (Control btn in satisButonlari)
            {
                this.Controls.Remove(btn);
                btn.Dispose();
            }
        }

        private void RenderSatislar()
        {
            string cariAdi;
            string urunAdi;
            string tarih;
            string tutar;

            RemovePanels();
            if (Satislar != null)
                Satislar.Clear();
            if (satisButonlari != null)
                satisButonlari.Clear();

            Satislar = sqlController.LoadSatislar();

            if (Satislar == null)
                return;

            Satislar.Reverse();

            for (int i = 0; i < Satislar.Count; i++)
            {
                cariAdi = "Silinmiş";
                urunAdi = "Silinmiş";
                tarih = null;
                tutar = null;

                List<string> cariBilgiler = sqlController.GetCari(Convert.ToInt64(Satislar[i][1]));
                List<string> urunBilgiler = sqlController.GetStok(Convert.ToInt64(Satislar[i][2]));

                if (cariBilgiler != null)
                    cariAdi = cariBilgiler[1];
                if (urunBilgiler != null)
                    urunAdi = urunBilgiler[1];

                tarih = Satislar[i][6];
                tutar = Satislar[i][5] + " ₺";

                if (string.IsNullOrEmpty(cariAdi) || string.IsNullOrEmpty(urunAdi) || string.IsNullOrEmpty(tarih) || string.IsNullOrEmpty(tutar))
                {
                    MessageBox.Show($"Satışın bilgilerini getirmede hata çıktı {Satislar[0]}");
                    return;
                }

                Button btn = new Button();
                btn.Name = $"btnSatis{Satislar[i][0]}";
                btn.Text = cariAdi;
                btn.Size = new Size(butonGenislik, butonYukseklik);
                btn.Font = new Font("Segoe UI", 12, FontStyle.Regular);
                btn.Click += (s, e) => btnSatis_Click(s, e);

                int x = baslangicX;
                int y = baslangicY + (i * (satirlarArasiBosluk + butonYukseklik));
                btn.Location = new Point(x, y);

                satisButonlari.Add(btn);
                panelToplamSatislar.Controls.Add(btn);
            }

            if (satisButonlari != null)
                designEditor.BtnEditor(satisButonlari, foreColor, backColor, mouseOverColor, mouseDownColor);

        }

        private void btnSatis_Click(object sender, EventArgs e)
        {
            long satisID = Convert.ToInt64((sender as Button).Name.Split("btnSatis")[1]);

            if (!formSatisGoruntule.Created)
            {
                formSatisGoruntule = new EkScreen(new EskiSatisGoruntuleUC(satisID));
                formSatisGoruntule.ShowDialog();
            }

            RenderSatislar();
        }

        private void EskiSatislarUC_Load(object sender, EventArgs e)
        {
            RemovePanels();
            RenderSatislar();
        }
    }
}
