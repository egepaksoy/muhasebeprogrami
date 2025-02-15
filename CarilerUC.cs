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

        public CarilerUC()
        {
            InitializeComponent();
        }

        private void CarilerUC_Load(object sender, EventArgs e)
        {

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
