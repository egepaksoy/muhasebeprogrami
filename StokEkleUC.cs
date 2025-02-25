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
        SQLController sqlController = new SQLController();

        long urunId;

        string UrunAdi = "";
        string UrunAdedi = "";
        string UrunFiyati = "";
        string FaturaNo = "";

        bool duzenlemeModu = false;

        public StokEkleUC()
        {
            InitializeComponent();

            btnSil.Enabled = false;
            btnSil.Visible = false;

            btnStokKaydet.Size = new Size(352, 49);
        }
        public StokEkleUC(string urun_adi)
        {
            InitializeComponent();
            List<string> urun = sqlController.GetStok(urun_adi.Trim());

            UrunAdi = urun[1];
            UrunAdedi = urun[2];
            UrunFiyati = urun[3];

            urunId = Convert.ToInt64(urun[0]);
            textBoxUrunAdi.Text = UrunAdi;
            textBoxAdet.Text = UrunAdedi;
            textBoxBirimFiyat.Text = UrunFiyati;

            btnSil.Enabled = true;
            btnSil.Visible = true;

            btnStokKaydet.Size = new Size(297, 49);

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
            string urunAdi = textBoxUrunAdi.Text.ToLower();

            int adet;
            int.TryParse(textBoxAdet.Text, out adet);
            double fiyat;
            double.TryParse(textBoxBirimFiyat.Text, out fiyat);

            bool alim = comboBoxStokTuru.Text == "Alım";
            string faturaNo = textBoxFaturaNo.Text;

            string Err = null;

            if (duzenlemeModu)
            {
                if (sqlController.GetStok(urunAdi) != null && urunAdi != UrunAdi.ToLower()) Err = "Ürün mevcut";
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

                    string err = sqlController.NewStok(textBoxUrunAdi.Text.ToLower(), Convert.ToInt32(textBoxAdet.Text), Convert.ToDouble(textBoxBirimFiyat.Text), textBoxFaturaNo.Text, stokTuru);
                    if (!long.TryParse(err, out long res))
                        MessageBox.Show(err);
                    else
                        ReturnOrigin();
                }
            }
            else
            {
                if (CheckValuesValid(textBoxUrunAdi, textBoxAdet, textBoxBirimFiyat, comboBoxStokTuru, textBoxFaturaNo))
                {
                    string stokTuru = "sayim";
                    if (comboBoxStokTuru.Text == "Alım")
                        stokTuru = "alim";

                    string err = sqlController.UpdateStok(urunId, textBoxUrunAdi.Text.ToLower(), Convert.ToInt32(textBoxAdet.Text), Convert.ToDouble(textBoxBirimFiyat.Text), textBoxFaturaNo.Text, stokTuru);
                    if (!long.TryParse(err, out long res))
                        MessageBox.Show(err);
                }
            }
        }

        private void StokEkleUC_Load(object sender, EventArgs e)
        {
            comboBoxStokTuru.SelectedIndex = 0;
        }

        private void ReturnOrigin()
        {
            textBoxUrunAdi.Text = "";
            textBoxAdet.Text = "";
            textBoxBirimFiyat.Text = "";
            
            comboBoxStokTuru.SelectedIndex = 0;
        }

        private void CloseScreen()
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == "EkScreen")
                {
                    form.Close();
                    break;
                }
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Ürümü silmek istiyor musunuz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                bool basarili = sqlController.DeleteStok(urunId);

                if (basarili)
                    CloseScreen();
                else
                    MessageBox.Show("Ürün bulunamadı!!");
            }
        }
    }
}
