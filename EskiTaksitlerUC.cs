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
    public partial class EskiTaksitlerUC : UserControl
    {
        public EskiTaksitlerUC()
        {
            InitializeComponent();
        }

        List<List<string>> TumTaksitler = new List<List<string>>();

        List<Button> TaksitButonlari = new List<Button>();

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

        private void RemoveButtons()
        {
            foreach (Control btn in TaksitButonlari)
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
            if (TumTaksitler != null)
                TumTaksitler.Clear();
            if (TaksitButonlari != null)
                TaksitButonlari.Clear();


            TumTaksitler = sqlController.LoadTaksitler(aktif: false);

            if (TumTaksitler != null)
            {
                for (int i = 0; i < TumTaksitler.Count; i++)
                {
                    cariAdi = "Silinmiş";

                    List<string> cariBilgiler = sqlController.GetCari(Convert.ToInt64(TumTaksitler[i][2]));

                    if (cariBilgiler != null)
                        cariAdi = cariBilgiler[1];

                    Button btn = new Button();
                    btn.Name = $"btnSatis{TumTaksitler[i][0]}";
                    btn.Text = cariAdi;
                    btn.Size = new Size(butonGenislik, butonYukseklik);
                    btn.Font = new Font("Segoe UI", 12, FontStyle.Regular);
                    btn.Click += (s, e) => btnTaksit_Click(s, e);

                    int x = baslangicX;
                    int y = baslangicY + (i * (satirlarArasiBosluk + butonYukseklik));
                    btn.Location = new Point(x, y);

                    TaksitButonlari.Add(btn);
                    panelTaksitler.Controls.Add(btn);
                }

                if (TaksitButonlari != null)
                    designEditor.BtnEditor(TaksitButonlari, foreColor, backColor, mouseOverColor, mouseDownColor);
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

        private void EskiTaksitlerUC_Load(object sender, EventArgs e)
        {
            RemoveButtons();
            RenderTaksitler();
        }
    }
}
