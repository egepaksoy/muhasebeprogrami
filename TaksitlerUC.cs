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

        Point labelAktifTaksitler_Konum = new Point(72, 35);
        Point panelAktifTaksitler_Konum = new Point(72, 80);

        Point labelGelecekTaksitler_Konum = new Point(72, 341);
        Point panelGelecekTaksitler_Konum = new Point(72, 386);

        Size panelOriginSize = new Size(850, 240);
        Size panelWideSize = new Size(850, 546);

        public TaksitlerUC()
        {
            InitializeComponent();
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

        private void ParseTaksitler(List<List<string>> TumTaksitler)
        {
            List<List<string>> Taksitler = new List<List<string>>();

            DateTime todayDate = DateTime.Today;

            int AktifTaksitler_len = 0;

            if (TumTaksitler != null)
            {
                foreach (var Taksit in TumTaksitler)
                {
                    List<string> Tarihler = Taksit[4].Split(",").ToList();
                    int OdenenTaksitSayisi = ParseOdemeler(Taksit[5]).Count;

                    AktifTaksitler_len = AktifTaksitler.Count;

                    while (OdenenTaksitSayisi < Tarihler.Count)
                    {
                        if (Tarihler[OdenenTaksitSayisi] == todayDate.ToString().Split()[0])
                        {
                            AktifTaksitler.Add(Taksit);
                            break;
                        }

                        OdenenTaksitSayisi++;
                    }

                    if (AktifTaksitler_len == AktifTaksitler.Count)
                        GelecekTaksitler.Add(Taksit);
                }
            }
        }

        private void ShowPanels()
        {
            bool showGelecekTaksitler = false;
            bool showAktifTaksitler = false;

            labelAktifTaksitler.Visible = true;
            labelAktifTaksitler.Location = labelAktifTaksitler_Konum;

            labelGelecekTaksitler.Visible = true;
            labelGelecekTaksitler.Location = labelGelecekTaksitler_Konum;
            
            panelAktifTaksitler.Visible = true;
            panelAktifTaksitler.Enabled = true;
            panelAktifTaksitler.Location = panelAktifTaksitler_Konum;
            panelAktifTaksitler.Size = panelOriginSize;

            panelGelecekTaksitler.Visible = true;
            panelGelecekTaksitler.Enabled = true;
            panelGelecekTaksitler.Location = panelGelecekTaksitler_Konum;
            panelGelecekTaksitler.Size = panelOriginSize;

            if (GelecekTaksitler != null)
            {
                if (GelecekTaksitler.Count > 0)
                    showGelecekTaksitler = true;
            }

            if (AktifTaksitler != null)
            {
                if (AktifTaksitler.Count > 0)
                    showAktifTaksitler = true;
            }

            if (showAktifTaksitler && showGelecekTaksitler)
                return;

            if (showAktifTaksitler && showGelecekTaksitler == false)
            {
                labelGelecekTaksitler.Visible = false;
                panelGelecekTaksitler.Enabled = false;
                panelGelecekTaksitler.Visible = false;

                panelAktifTaksitler.Size = panelWideSize;
            }
            else if (showGelecekTaksitler && showAktifTaksitler == false)
            {
                labelAktifTaksitler.Visible = false;
                panelAktifTaksitler.Enabled = false;
                panelAktifTaksitler.Visible = false;

                panelGelecekTaksitler.Size = panelWideSize;
                panelGelecekTaksitler.Location = panelAktifTaksitler_Konum;
                labelGelecekTaksitler.Location = labelAktifTaksitler_Konum;
            }
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
            ParseTaksitler(TumTaksitler);
            ShowPanels();

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
