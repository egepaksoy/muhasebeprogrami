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
    public partial class TaksitGoruntuleUC : UserControl
    {
        long taksitId;

        SQLController sqlController = new SQLController();
        List<string> TaksitBilgileri = new List<string>();

        List<string> Cari = new List<string>();
        List<string> Satis = new List<string>();
        List<string> Urun = new List<string>();

        public TaksitGoruntuleUC(long taksitId)
        {
            InitializeComponent();

            this.taksitId = taksitId;
        }

        private List<string> ParseOdemeler(string Odemeler)
        {
            List<string> ListedOdemeler = Odemeler.Split("/").ToList();
            List<string> result = new List<string>();

            foreach (var Odeme in ListedOdemeler)
            {
                if (!string.IsNullOrEmpty(Odeme))
                    result.Add(Odeme);
            }

            return result;
        }

        private void RenderTaksit()
        {
            string CariAdi = "Silinmiş Cari";
            string SatisTarihi = "Silinmiş Kayıt";
            string UrunAdi = "Silinmiş Ürün";
            string ToplamTutar = "";
            string KalanTaksitKalanTutar = "/";
            string SonrakiOdemeTarihi = "";

            int odenenTaksitSayisi = 0;
            List<string> odenenTaksitler = new List<string>();

            TaksitBilgileri.Clear();

            TaksitBilgileri = sqlController.GetTaksit(taksitId);

            if (TaksitBilgileri == null)
            {
                MessageBox.Show("Taksit Bulunamadı");
                return;
            }

            Cari = sqlController.GetCari(Convert.ToInt64(TaksitBilgileri[2]));
            if (Cari != null)
                CariAdi = Cari[1];

            Satis = sqlController.GetSatis(Convert.ToInt64(TaksitBilgileri[1]));
            if (Satis != null)
            {
                Urun = sqlController.GetStok(Convert.ToInt64(Satis[2]));
                if (Urun != null)
                    UrunAdi = Urun[1];

                SatisTarihi = Satis[6].Split()[0];
            }

            ToplamTutar = TaksitBilgileri[3];

            odenenTaksitler = ParseOdemeler(TaksitBilgileri[5]);
            odenenTaksitSayisi = odenenTaksitler.Count;

            KalanTaksitKalanTutar = $"{Convert.ToInt32(TaksitBilgileri[7]) - odenenTaksitSayisi} / {TaksitBilgileri[6]}";

            SonrakiOdemeTarihi = TaksitBilgileri[4].Split(",")[odenenTaksitSayisi];

            labelCariAdi.Text = CariAdi;
            labelSatisTarihi.Text = SatisTarihi;
            labelUrunAdi.Text = UrunAdi;
            labelToplamTutar.Text = ToplamTutar;
            labelKalanTaksitTutar.Text = KalanTaksitKalanTutar;
            labelSonrakiOdemeTarihi.Text = SonrakiOdemeTarihi;
        }

        private void TaksitGoruntuleUC_Load(object sender, EventArgs e)
        {
            RenderTaksit();
        }

        private void btnOdendi_Click(object sender, EventArgs e)
        {
            sqlController.TaksitOde(taksitId);
        }
    }
}
