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
        string cari_adi = null;
        List<string> cari;

        public CariDuzenleUC(string cari_adi)
        {
            InitializeComponent();

            this.cari_adi = cari_adi;
            cari = sqlController.GetCari(cari_adi);
        }

        private void CariDuzenleUC_Load(object sender, EventArgs e)
        {
            textBoxCariAdi.Text = cari[1];
            textBoxTelefonu.Text = cari[2];
            textBoxAdresi.Text = cari[3];
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
