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

        bool datePicked = false;

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
            textBoxVadeMiktari.Visible = taksit;
            textBoxVadeMiktari.Enabled = taksit;
            labelVadeMiktari.Visible = taksit;
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

        private void NakitSatis()
        {

        }

        private void btnSatis_Click(object sender, EventArgs e)
        {
            string cari = comboBoxCari.Text;
            string kasa = comboBoxKasa.Text;
            string urun = comboBoxUrun.Text;
            string adet = textBoxAdet.Text;
            string fiyat = labelToplamFiyat.Text;
            string onOdeme = textBoxOdenenTutar.Text;
            string vadeMiktari = textBoxVadeMiktari.Text;
            string vadeTipi = comboBoxTaksitDonemi.Text;

            int adet_sayi;
            double onOdeme_sayi = 0;
            int vadeMiktari_sayi = 0;

            List<string> urunBilgisi = sqlController.GetStok(urun);
            List<string> kasaBilgisi = sqlController.GetKasa(kasa);

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
                int urunAdedi = Convert.ToInt32(urunBilgisi[2]);

                if (urunAdedi - adet_sayi < 0)
                {
                    DialogResult result = MessageBox.Show("Stokta yeterli miktarda urun yok stok miktari eksi'ye düşücektir devam etmek istiyor musunuz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No)
                        return;
                }
            }

            long cari_id = Convert.ToInt64(sqlController.GetCari(cari)[0]);
            long urun_id = Convert.ToInt64(urunBilgisi[0]);
            long kasa_id = Convert.ToInt64(kasaBilgisi[0]);
            double fiyat_sayi = Convert.ToDouble(fiyat);
            string odeme_turu = comboBoxOdemeTuru.Text.ToLower();

            string Err = null;

            if (odeme_turu == "taksit")
            {
                if (double.TryParse(onOdeme, out onOdeme_sayi) == false && string.IsNullOrEmpty(onOdeme) == false)
                    Err = "Ön ödeme miktarı geçersiz";
                if (datePicked == false)
                    Err = "İlk taksit tarihi seçiniz";
                if (int.TryParse(vadeMiktari, out vadeMiktari_sayi) == false && string.IsNullOrEmpty(vadeMiktari) == false)
                    Err = "Vade miktarı geçersiz";
                if (string.IsNullOrEmpty(vadeTipi))
                    Err = "Taksit dönemi seçiniz";
            }

            if (Err != null)
            {
                MessageBox.Show(Err);
                return;
            }

            Err = sqlController.NewSatis(cari_id, urun_id, kasa_id, adet_sayi, fiyat_sayi, odeme_turu);

            if (Err != null)
                MessageBox.Show(Err);
            else
            {
                if (odeme_turu == "taksit")
                {
                    double kalan_tutar = fiyat_sayi - onOdeme_sayi;
                    int taksit_sayisi = Convert.ToInt32(kalan_tutar / vadeMiktari_sayi) + (kalan_tutar % vadeMiktari_sayi == 0 ? 0 : 1);
                    vadeTipi = (vadeTipi == "Aylık" ? "aylik" : "haftalik");

                    string hata = sqlController.NewTaksit(cari_id, fiyat_sayi, dateTimePickerIlkOdeme, kalan_tutar, taksit_sayisi, vadeTipi);

                    if (!string.IsNullOrEmpty(hata))
                    {
                        MessageBox.Show(hata);
                        return;
                    }

                    fiyat_sayi = onOdeme_sayi;
                }

                int kalanUrun = Convert.ToInt32(urunBilgisi[2]) - adet_sayi;
                sqlController.SatisStok(urun_id, kalanUrun);

                double satisMiktari = fiyat_sayi + Convert.ToDouble(kasaBilgisi[2]);
                sqlController.SatisKasa(kasa_id, satisMiktari);

                MessageBox.Show("Satış yapıldı");
            }
        }

        private void dateTimePickerIlkOdeme_ValueChanged(object sender, EventArgs e)
        {
            datePicked = true;
        }
    }
}
