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
    public partial class CariDuzenleUC : UserControl
    {
        SQLController sqlController = new SQLController("D:\\PROJELER\\Muhasebe Programı\\muhasebe.db");
        DesignEditor designEditor = new DesignEditor();

        string cari_adi = null;
        List<string> cari;
        List<List<string>> Satislar;
        List<List<string>> Taksitler;

        List<Button> satisButonlar = new List<Button>();
        List<Button> taksitButonlar = new List<Button>();

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
        EkScreen formSatisGoruntule = new EkScreen(new EskiSatisGoruntuleUC());

        public CariDuzenleUC(string cari_adi)
        {
            InitializeComponent();

            this.cari_adi = cari_adi;
            cari = sqlController.GetCari(cari_adi);
        }

        private void RemoveButtons()
        {
            foreach (Control btn in satisButonlar)
            {
                this.Controls.Remove(btn);
                btn.Dispose();
            }
            foreach (Control btn in taksitButonlar)
            {
                this.Controls.Remove(btn);
                btn.Dispose();
            }
        }

        private void RenderButtons()
        {
            RemoveButtons();
            if (satisButonlar != null)
                satisButonlar.Clear();
            if (taksitButonlar != null)
                taksitButonlar.Clear();

            if (Satislar != null)
                Satislar.Clear();
            if (Taksitler != null)
                Taksitler.Clear();

            Satislar = sqlController.GetCariSatislari(Convert.ToInt64(cari[0]));
            Taksitler = sqlController.GetCariTaksitleri(Convert.ToInt64(cari[0]));

            string satisAdi;
            if (Satislar == null)
                return;
            for (int i = 0; i < Satislar.Count; i++)
            {
                Button btn = new Button();
                btn.Name = $"btnSatis{Satislar[i][0]}";
                btn.Text = Satislar[i][6].Split()[0];
                btn.Size = new Size(butonGenislik, butonYukseklik);
                btn.Font = new Font("Segoe UI", 12, FontStyle.Regular);
                btn.Click += (s, e) => btnSatis_Click(s, e);

                int x = baslangicX;
                int y = baslangicY + (i * (satirlarArasiBosluk + butonYukseklik));
                btn.Location = new Point(x, y);

                satisButonlar.Add(btn);
                panelSatislar.Controls.Add(btn);
            }
            if (satisButonlar != null)
                designEditor.BtnEditor(satisButonlar, foreColor, backColor, mouseOverColor, mouseDownColor);

            string taksitAdi;
            if (Taksitler == null)
                return;
            for (int i = 0; i < Taksitler.Count; i++)
            {
                Button btn = new Button();
                btn.Name = $"btnTaksit{Taksitler[i][0]}";
                btn.Text = Taksitler[i][4].Split()[0];
                btn.Size = new Size(butonGenislik, butonYukseklik);
                btn.Font = new Font("Segoe UI", 12, FontStyle.Regular);
                btn.Click += (s, e) => btnTaksit_Click(s, e);

                int x = baslangicX;
                int y = baslangicY + (i * (satirlarArasiBosluk + butonYukseklik));
                btn.Location = new Point(x, y);

                taksitButonlar.Add(btn);
                panelTaksitler.Controls.Add(btn);
            }
            if (taksitButonlar != null)
                designEditor.BtnEditor(taksitButonlar, foreColor, backColor, mouseOverColor, mouseDownColor);
        }

        private void btnSatis_Click(object sender, EventArgs e)
        {
            long satisId = Convert.ToInt64((sender as Button).Name.Split("btnSatis")[1]);

            if (!formSatisGoruntule.Created)
            {
                formSatisGoruntule = new EkScreen(new EskiSatisGoruntuleUC(satisId));
                formSatisGoruntule.ShowDialog();
            }

            RenderButtons();
        }

        private void btnTaksit_Click(object sender, EventArgs e)
        {
            long taksitId = Convert.ToInt64((sender as Button).Text.Split("btnTaksit")[1]);
        }

        private void CariDuzenleUC_Load(object sender, EventArgs e)
        {
            textBoxCariAdi.Text = cari[1];
            textBoxTelefonu.Text = cari[2];
            textBoxAdresi.Text = cari[3];

            RenderButtons();
        }

        private bool CheckValues(string cariAdi, string cariTelefon, string cariAdres)
        {
            string Err = null;

            if (string.IsNullOrEmpty(cariAdi))
                Err = "Cari adını giriniz";
            else if (sqlController.GetCari(cariAdi) != null && cariAdi != cari_adi)
                Err = $"Cari {cariAdi} mevcut";

            if (Err != null)
            {
                MessageBox.Show(Err);
                return false;
            }

            return true;
        }

        private void ReturnOrigin()
        {
            textBoxCariAdi.Text = cari[1];
            textBoxTelefonu.Text = cari[2];
            textBoxAdresi.Text = cari[3];
        }

        private void btnCariGuncelle_Click(object sender, EventArgs e)
        {
            string cariAdi = textBoxCariAdi.Text;
            string telefon = textBoxTelefonu.Text;
            string adres = textBoxAdresi.Text;

            if (CheckValues(cariAdi, telefon, adres))
                sqlController.UpdateCari(Convert.ToInt64(cari[0]), cariAdi, telefon, adres);
            else
                ReturnOrigin();
        }
    }
}
