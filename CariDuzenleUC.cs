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
    }
}
