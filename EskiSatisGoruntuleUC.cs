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
    public partial class EskiSatisGoruntuleUC : UserControl
    {
        long SatisId;
        long TaksitId = -1;

        List<string> Satis;
        SQLController sqlController = new SQLController();

        EkScreen formTaksitGoruntuleme = new EkScreen(new TaksitGoruntuleUC());

        public EskiSatisGoruntuleUC(long satisId)
        {
            InitializeComponent();

            this.SatisId = satisId;
        }

        public EskiSatisGoruntuleUC()
        {
            InitializeComponent();
        }

        private void RenderSatis()
        {
            string Err = null;
            Satis = sqlController.GetSatis(SatisId);

            if (Satis == null)
            {
                MessageBox.Show("Satış getirilirken bir sorun oluştu");
                return;
            }

            List<string> urun;
            List<string> cari;
            List<string> kasa;

            string urunAdi;
            string cariAdi;
            string kasaAdi;
            string tutar;
            string tarih;
            string odemeTuru;
            string satisAdedi;
            bool taksitli;

            urun = sqlController.GetStok(Convert.ToInt64(Satis[2]));
            cari = sqlController.GetCari(Convert.ToInt64(Satis[1]));
            kasa = sqlController.GetKasa(Convert.ToInt64(Satis[3]));
            taksitli = Satis[7] == "taksit";

            if (urun == null)
                urunAdi = "Silinmiş Ürün";
            else
                urunAdi = urun[1];

            if (cari == null)
                cariAdi = "Silinmiş Cari";
            else
                cariAdi = cari[1];

            if (kasa == null)
                kasaAdi = "Silinmiş Kasa";
            else
                kasaAdi = kasa[1];

            tutar = Satis[5] + " ₺";
            tarih = Satis[6].Split()[0];
            odemeTuru = Satis[7];
            satisAdedi = Satis[4];

            labelUrunAdi.Text = urunAdi;
            labelCariAdi.Text = cariAdi;
            labelKasaAdi.Text = kasaAdi;
            labelTutar.Text = tutar;
            labelTarih.Text = tarih;
            labelOdemeTipi.Text = odemeTuru;
            labelAdet.Text = satisAdedi;

            if (taksitli)
                TaksitId = Convert.ToInt64(sqlController.GetSatisTaksit(SatisId)[0]);

            TaksitButonuKontrolu(taksitli);
        }

        private void TaksitButonuKontrolu(bool taksit)
        {
            btnTaksitler.Visible = taksit;
            btnTaksitler.Enabled = taksit;
        }

        private void EskiSatisGoruntuleUC_Load(object sender, EventArgs e)
        {
            RenderSatis();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (TaksitId == -1)
                return;

            if (!formTaksitGoruntuleme.Created)
            {
                formTaksitGoruntuleme = new EkScreen(new TaksitGoruntuleUC(TaksitId));
                formTaksitGoruntuleme.ShowDialog();
            }

            RenderSatis();
        }
    }
}
