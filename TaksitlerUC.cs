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

namespace Muhasebe_Programı
{
    public partial class TaksitlerUC : UserControl
    {
        List<List<string>> TumTaksitler = new List<List<string>>();
        List<List<string>> AktifTaksitler = new List<List<string>>();
        List<List<string>> GelecekTaksitler = new List<List<string>>();

        List<Button> AktifTaksitButonlari = new List<Button>();
        List<Button> GelecekTaksitButonlari = new List<Button>();

        SQLController sqlController = new SQLController();
        DesignEditor designEditor = new DesignEditor();

        Color foreColor = Color.White;

        Color backColor = Color.FromArgb(44, 62, 80);
        Color mouseOverColor = Color.FromArgb(0x4E, 0x5D, 0x6B);
        Color mouseDownColor = Color.FromArgb(44, 62, 80);

        int butonGenislik = 810;
        int butonYukseklik = 50;
        int baslangicX = 20;
        int baslangicY = 20;
        int satirlarArasiBosluk = 10;

        EkScreen formTaksitGoruntuleme = new EkScreen(new EskiSatisGoruntuleUC());

        public TaksitlerUC()
        {
            InitializeComponent();
        }

        private List<List<string>> GetAktifler(bool aktif, List<List<string>> TumTaksitler)
        {
            List<List<string>> Taksitler = new List<List<string>>();

            DateTime todayDate = DateTime.Today;
            DateTime taksitDate;

            int eklemeGunu = 30;

            if (TumTaksitler != null)
            {
                foreach (var Taksit in TumTaksitler)
                {
                    if (aktif)
                    {
                        taksitDate = Convert.ToDateTime(Taksit[4]);
                        eklemeGunu = Taksit[8] == "aylik" ? 30 : 7;

                        while (taksitDate <= todayDate)
                            taksitDate.AddDays(eklemeGunu);
                        if (taksitDate == todayDate)
                            Taksitler.Add(Taksit);
                    }
                    else
                    {
                        taksitDate = Convert.ToDateTime(Taksit[4]);
                        eklemeGunu = Taksit[8] == "aylik" ? 30 : 7;

                        while (taksitDate <= todayDate)
                            taksitDate.AddDays(eklemeGunu);
                        if (taksitDate != todayDate)
                            Taksitler.Add(Taksit);
                    }
                }
            }

            if (Taksitler.Count > 0)
                return Taksitler;
            return null;
        }

        private void RemoveButtons()
        {
            foreach (Control btn in AktifTaksitButonlari)
            {
                this.Controls.Remove(btn);
                btn.Dispose();
            }
            foreach (Control btn in GelecekTaksitButonlari)
            {
                this.Controls.Remove(btn);
                btn.Dispose();
            }
        }

        private void RenderTaksitler()
        {
            string cariAdi;
            string urunAdi;
            string tarih;
            string tutar;

            RemoveButtons();
            if (AktifTaksitler != null)
                AktifTaksitler.Clear();
            if (AktifTaksitButonlari != null)
                AktifTaksitButonlari.Clear();

            if (GelecekTaksitler != null)
                GelecekTaksitler.Clear();
            if (GelecekTaksitButonlari != null)
                GelecekTaksitButonlari.Clear();

            TumTaksitler = sqlController.LoadTaksitler(aktif: true);
            AktifTaksitler = GetAktifler(true, TumTaksitler);
            GelecekTaksitler = GetAktifler(false, TumTaksitler);

            if (AktifTaksitler != null)
            {
                for (int i = 0; i < AktifTaksitler.Count; i++)
                {
                    cariAdi = "Silinmiş";

                    List<string> cariBilgiler = sqlController.GetCari(Convert.ToInt64(AktifTaksitler[i][2]));

                    if (cariBilgiler != null)
                        cariAdi = cariBilgiler[1];

                    Button btn = new Button();
                    btn.Name = $"btnSatis{AktifTaksitler[i][0]}";
                    btn.Text = cariAdi;
                    btn.Size = new Size(butonGenislik, butonYukseklik);
                    btn.Font = new Font("Segoe UI", 12, FontStyle.Regular);
                    btn.Click += (s, e) => btnTaksit_Click(s, e);

                    int x = baslangicX;
                    int y = baslangicY + (i * (satirlarArasiBosluk + butonYukseklik));
                    btn.Location = new Point(x, y);

                    AktifTaksitButonlari.Add(btn);
                    panelAktifTaksitler.Controls.Add(btn);
                }

                if (AktifTaksitButonlari != null)
                    designEditor.BtnEditor(AktifTaksitButonlari, foreColor, backColor, mouseOverColor, mouseDownColor);
            }
            
            if (GelecekTaksitler != null)
            {
                for (int i = 0; i < GelecekTaksitler.Count; i++)
                {
                    cariAdi = "Silinmiş";

                    List<string> cariBilgiler = sqlController.GetCari(Convert.ToInt64(GelecekTaksitler[i][2]));

                    if (cariBilgiler != null)
                        cariAdi = cariBilgiler[1];

                    Button btn = new Button();
                    btn.Name = $"btnSatis{GelecekTaksitler[i][0]}";
                    btn.Text = cariAdi;
                    btn.Size = new Size(butonGenislik, butonYukseklik);
                    btn.Font = new Font("Segoe UI", 12, FontStyle.Regular);
                    btn.Click += (s, e) => btnTaksit_Click(s, e);

                    int x = baslangicX;
                    int y = baslangicY + (i * (satirlarArasiBosluk + butonYukseklik));
                    btn.Location = new Point(x, y);

                    GelecekTaksitButonlari.Add(btn);
                    panelGelecekTaksitler.Controls.Add(btn);
                }

                if (GelecekTaksitButonlari != null)
                    designEditor.BtnEditor(GelecekTaksitButonlari, foreColor, backColor, mouseOverColor, mouseDownColor);
            }
        }

        private void btnTaksit_Click(object sender, EventArgs e)
        {
            long taksitId = Convert.ToInt64((sender as Button).Name.Split("btnSatis")[1]);

            if (!formTaksitGoruntuleme.Created)
            {
                formTaksitGoruntuleme = new EkScreen(new TaksitGoruntuleUC(taksitId));
                formTaksitGoruntuleme.ShowDialog();
            }

            RenderTaksitler();
        }

        private void TaksitlerUC_Load(object sender, EventArgs e)
        {
            RemoveButtons();
            RenderTaksitler();
        }
    }
}
