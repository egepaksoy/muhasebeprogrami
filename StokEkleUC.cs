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
    public partial class StokEkleUC : UserControl
    {
        SQLController sqlController = new SQLController("D:\\PROJELER\\Muhasebe Programı\\muhasebe.db");

        string urun_adi;
        long urunId;

        bool duzenlemeModu = false;

        public StokEkleUC()
        {
            InitializeComponent();
        }
        public StokEkleUC(string urun_adi)
        {
            InitializeComponent();
            this.urun_adi = urun_adi.Trim();

            List<string> urun = sqlController.GetStok(urun_adi);

            urunId = Convert.ToInt64(urun[0]);
            textBoxUrunAdi.Text = urun[1];
            textBoxAdet.Text = urun[2];
            textBoxBirimFiyat.Text = urun[3];

            duzenlemeModu = true;
        }

        private void ChangeVisible(bool alim)
        {
            textBoxFaturaNo.Enabled = alim;
            textBoxFaturaNo.Visible = alim;

            labelFaturaNo.Enabled = alim;
            labelFaturaNo.Visible = alim;

            if (alim)
            {
                textBoxFaturaNo.Text = "";
            }
        }

        private void comboBoxStokTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool alim = comboBoxStokTuru.Text == "Alım";

            ChangeVisible(alim);
        }

        private bool CheckValuesValid(TextBox textBoxUrunAdi, TextBox textBoxAdet, TextBox textBoxBirimFiyat, ComboBox comboBoxStokTuru, TextBox textBoxFaturaNo)
        {
            string urunAdi = textBoxUrunAdi.Text;

            int adet;
            int.TryParse(textBoxAdet.Text, out adet);
            double fiyat;
            double.TryParse(textBoxBirimFiyat.Text, out fiyat);

            bool alim = comboBoxStokTuru.Text == "Alım";
            string faturaNo = textBoxFaturaNo.Text;

            string Err = null;

            if (duzenlemeModu)
            {
                if (sqlController.GetStok(urunAdi) != null && urunAdi != urun_adi) Err = "Ürün mevcut";
            }
            else
            {
                if (sqlController.GetStok(urunAdi) != null) Err = "Ürün mevcut";
            }
            if (adet <= 0) Err = "Adedi doğru giriniz";
            if (fiyat <= 0) Err = "Fiyatı doğru giriniz";
            if (alim && string.IsNullOrEmpty(faturaNo)) Err = "Faturo no giriniz";

            if (!string.IsNullOrEmpty(Err))
            {
                MessageBox.Show(Err);
                return false;
            }
            return true;
        }

        private void btnStokKaydet_Click(object sender, EventArgs e)
        {
            if (!duzenlemeModu)
            {
                if (CheckValuesValid(textBoxUrunAdi, textBoxAdet, textBoxBirimFiyat, comboBoxStokTuru, textBoxFaturaNo))
                {
                    string stokTuru = "sayim";
                    if (comboBoxStokTuru.Text == "Alım")
                        stokTuru = "alim";

                    string err = sqlController.NewStok(textBoxUrunAdi.Text, Convert.ToInt32(textBoxAdet.Text), Convert.ToDouble(textBoxBirimFiyat.Text), textBoxFaturaNo.Text, stokTuru);
                    if (!string.IsNullOrEmpty(err))
                        MessageBox.Show(err);
                    else
                        MessageBox.Show("Ürün Başarıyla Eklendi");
                }
            }
            else
            {
                if (CheckValuesValid(textBoxUrunAdi, textBoxAdet, textBoxBirimFiyat, comboBoxStokTuru, textBoxFaturaNo))
                {
                    string stokTuru = "sayim";
                    if (comboBoxStokTuru.Text == "Alım")
                        stokTuru = "alim";

                    string err = sqlController.UpdateStok(urunId, textBoxUrunAdi.Text, Convert.ToInt32(textBoxAdet.Text), Convert.ToDouble(textBoxBirimFiyat.Text), textBoxFaturaNo.Text, stokTuru);
                    if (!string.IsNullOrEmpty(err))
                        MessageBox.Show(err);
                    else
                        MessageBox.Show("Ürün Başarıyla Eklendi");
                }
            }
        }

        private void StokEkleUC_Load(object sender, EventArgs e)
        {
            comboBoxStokTuru.SelectedIndex = 0;
        }
    }
}
