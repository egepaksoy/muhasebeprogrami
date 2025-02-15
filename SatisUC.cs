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
    public partial class SatisUC : UserControl
    {
        List<string> Urunler = new List<string>();
        List<string> Kasalar = new List<string>();
        List<string> Cariler = new List<string>();

        string UrunAdi;
        string UrunAdedi;
        string UrunFiyati;

        string CariAdi;

        string KasaAdi;

        int UrunAdedi_Sayi;
        double UrunFiyati_Sayi;
        double ToplamFiyat = 0;

        SQLController sqlController = new SQLController();

        bool nakit = false;
        bool taksit = false;

        public SatisUC()
        {
            InitializeComponent();
        }

        private void ChangeVisible()
        {
            nakit = comboBoxOdemeTuru.Text == "Nakit";
            taksit = comboBoxOdemeTuru.Text == "Taksit";

            labelOdenen.Visible = taksit;
            textBoxOdenenTutar.Enabled = taksit;
            textBoxOdenenTutar.Visible = taksit;
            comboBoxTaksitDonemi.Visible = taksit;
            dateTimePickerIlkOdeme.Visible = taksit;
            comboBoxTaksitDonemi.Enabled = taksit;
            dateTimePickerIlkOdeme.Enabled = taksit;
            labelIlkOdemeTarihi.Visible = taksit;
            labelTaksitDonemi.Visible = taksit;
        }

        private void comboBoxOdemeTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeVisible();
        }

        private void LoadDB()
        {
            Urunler = sqlController.LoadStoklar();
            Kasalar = sqlController.LoadKasalar();
            Cariler = sqlController.LoadCariler();

            comboBoxUrun.Items.Clear();
            comboBoxCari.Items.Clear();
            comboBoxKasa.Items.Clear();

            if (Urunler != null)
                foreach (var item in Urunler)
                    comboBoxUrun.Items.Add(item);
            if (Cariler != null)
                foreach (var item in Cariler)
                    comboBoxCari.Items.Add(item);
            if (Kasalar != null)
                foreach (var item in Kasalar)
                    comboBoxKasa.Items.Add(item);
        }

        private void SatisUC_Load(object sender, EventArgs e)
        {
            comboBoxOdemeTuru.SelectedIndex = 0;

            ChangeVisible();

            LoadDB();
        }

        private void LoadDB(object sender, EventArgs e)
        {
            LoadDB();
        }

        private void comboBoxUrun_SelectedIndexChanged(object sender, EventArgs e)
        {
            string urunadi = comboBoxUrun.Text;
            List<string> urun = sqlController.GetStok(urunadi);

            if (urun != null)
            {
                UrunAdi = urun[1];
                UrunAdedi = urun[2];
                UrunFiyati = urun[3];

                textBoxUrunFiyati.Text = UrunFiyati;
            }
        }

        private bool CheckAdetFiyat(string adet, string fiyat)
        {
            if (!float.TryParse(fiyat, out float val))
                return false;

            if (!int.TryParse(adet, out int res))
                return false;

            return true;
        }

        private bool CheckNakitOdeme(string cari, string kasa)
        {
            string Err = null;

            if (string.IsNullOrEmpty(cari)) Err = "Cari Seçin";
            else if (string.IsNullOrEmpty(kasa)) Err = "Kasa Seçin";

            if (Err != null)
            {
                MessageBox.Show(Err);
                return false;
            }
            return true;
        }

        private void totalHesapla(object sender, EventArgs e)
        {
            string adet = textBoxAdet.Text;
            string fiyat = textBoxUrunFiyati.Text;

            if (string.IsNullOrEmpty(adet))
                labelToplamFiyat.Text = "";
            if (string.IsNullOrEmpty(fiyat))
                labelToplamFiyat.Text = "";

            if (CheckAdetFiyat(adet, fiyat))
            {
                UrunFiyati_Sayi = Convert.ToDouble(textBoxUrunFiyati.Text);
                UrunAdedi_Sayi = Convert.ToInt32(textBoxAdet.Text);

                ToplamFiyat = UrunFiyati_Sayi * UrunAdedi_Sayi;

                labelToplamFiyat.Text = ToplamFiyat.ToString();
            }
        }

        private void btnSatis_Click(object sender, EventArgs e)
        {
            string cari = comboBoxCari.Text;
            string kasa = comboBoxKasa.Text;
            string urun = comboBoxUrun.Text;
            string adet = textBoxAdet.Text;
            string fiyat = textBoxUrunFiyati.Text;

            int adet_sayi;

            List<string> urunBilgisi = sqlController.GetStok(urun);

            if (!CheckAdetFiyat(adet, fiyat))
                return;
            if (!CheckNakitOdeme(cari, kasa))
                return;

            adet_sayi = Convert.ToInt32(adet);

            if (urunBilgisi == null)
            {
                DialogResult result = MessageBox.Show("Ürün stokta mevcut değil fakat yinede devam etmek istiyor musunuz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                    return;
            }

            else
            {
                int urunAdedi = Convert.ToInt32(urunBilgisi[3]);

                if (urunAdedi - adet_sayi < 0)
                {
                    DialogResult result = MessageBox.Show("Stokta yeterli miktarda urun yok stok miktari eksi'ye düşücektir devam etmek istiyor musunuz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No)
                        return;
                }
            }


        }
    }
}
