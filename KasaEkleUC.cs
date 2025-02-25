using ProgramLibrary;
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
    public partial class KasaEkleUC : UserControl
    {
        SQLController sqlController = new SQLController();
        bool duzenlemeModu = false;

        string kasa_adi;
        long KasaId;

        public KasaEkleUC()
        {
            InitializeComponent();

            btnSil.Enabled = false;
            btnSil.Visible = false;

            btnKasaKaydet.Size = new Size(352, 49);
        }

        public KasaEkleUC(string kasa_adi)
        {
            InitializeComponent();

            List<string> kasa = sqlController.GetKasa(kasa_adi);
            this.kasa_adi = kasa[1];

            KasaId = Convert.ToInt64(kasa[0]);
            textBoxKasaAdi.Text = kasa[1];
            textBoxBakiye.Text = kasa[2];

            btnSil.Enabled = true;
            btnSil.Visible = true;

            btnKasaKaydet.Size = new Size(297, 49);

            duzenlemeModu = true;
        }

        private bool CheckValuesValid(TextBox KasaAdi, TextBox KasaBakiye)
        {
            string Err = null;
            string kasaAdi = KasaAdi.Text.ToLower();
            double kasaBakiye;

            if (string.IsNullOrEmpty(kasaAdi)) Err = "Kasa adını girin";
            else if (duzenlemeModu == true)
            {
                if (sqlController.GetKasa(kasaAdi) != null && kasa_adi.ToLower() != kasaAdi) Err = "Kasa mevcut";
            }
            else if (duzenlemeModu == false)
            {
                if (sqlController.GetKasa(kasaAdi) != null) Err = "Kasa mevcut";
            }
            else if (double.TryParse(KasaBakiye.Text, out kasaBakiye) == false) Err = "Bakiyeyi kontrol edin";

            if (!string.IsNullOrEmpty(Err))
            {
                MessageBox.Show(Err);
                return false;
            }
            return true;
        }

        private void btnKasaKaydet_Click(object sender, EventArgs e)
        {
            if (!duzenlemeModu)
            {
                if (CheckValuesValid(textBoxKasaAdi, textBoxBakiye))
                {
                    string err = sqlController.NewKasa(textBoxKasaAdi.Text.ToLower(), Convert.ToDouble(textBoxBakiye.Text));
                    if (long.TryParse(err, out long l) == false)
                        MessageBox.Show(err);
                    else
                        ReturnOrigin();
                }
            }
            else
            {
                if (CheckValuesValid(textBoxKasaAdi, textBoxBakiye))
                {
                    if (CheckValuesValid(textBoxKasaAdi, textBoxBakiye))
                    {
                        string err = sqlController.UpdateKasa(KasaId, textBoxKasaAdi.Text.ToLower(), Convert.ToDouble(textBoxBakiye.Text));
                        if (!string.IsNullOrEmpty(err))
                            MessageBox.Show(err);
                    }
                }
            }
        }

        private void ReturnOrigin()
        {
            textBoxKasaAdi.Text = "";
            textBoxBakiye.Text = "";
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
            DialogResult result = MessageBox.Show("Kasayı silmek istiyor musunuz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                bool basarili = sqlController.DeleteKasa(KasaId);

                if (basarili)
                    CloseScreen();
                else
                    MessageBox.Show("Kasa Bulunamadı!!");
            }
        }
    }
}
