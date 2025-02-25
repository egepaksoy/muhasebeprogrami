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
    public partial class KasaUC : UserControl
    {
        SQLController sqlController = new SQLController();
        DesignEditor designEditor;

        List<Button> KasaButtons = new List<Button>();
        List<string> Kasalar = new List<string>();

        Color foreColor = Color.White;

        Color backColor = Color.FromArgb(0x4E, 0x5D, 0x6B);
        Color mouseOverColor = Color.FromArgb(0xB3, 0xBE, 0xC7);
        Color mouseDownColor = Color.FromArgb(0x4E, 0x5D, 0x6B);

        int butonGenislik = 170;
        int butonYukseklik = 170;
        int baslangicX = 82;
        int baslangicY = 108;
        int butonlarArasiBosluk = 0;
        int satirlarArasiBosluk = 50;
        int panelGenislik = 995;
        int sutunSayisi = 4;

        EkScreen formKasaEkle = new EkScreen(new KasaEkleUC());

        public KasaUC()
        {
            InitializeComponent();
        }

        private void RemoveButtons()
        {
            foreach (Control btn in KasaButtons)
            {
                this.Controls.Remove(btn);
                btn.Dispose();
            }
        }

        private void RenderKasalar()
        {
            RemoveButtons();
            if (KasaButtons != null)
                KasaButtons.Clear();
            if (Kasalar != null)
                Kasalar.Clear();

            Kasalar = sqlController.LoadKasalar();

            int toplamButonGenislik = sutunSayisi * butonGenislik;
            butonlarArasiBosluk = (panelGenislik - (2 * baslangicX) - toplamButonGenislik) / (sutunSayisi - 1);

            string kasaAdi;
            if (Kasalar == null)
                return;

            for (int i = 1; i <= Kasalar.Count; i++)
            {
                kasaAdi = Kasalar[i - 1];
                Button btn = new Button();
                btn.Name = $"btnKasa{kasaAdi}";
                btn.Text = kasaAdi;
                btn.Size = new Size(butonGenislik, butonYukseklik);
                btn.Font = new Font("Segoe UI", 20, FontStyle.Regular);
                btn.Click += (s, e) => btnKasa_Click(s, e);

                int x = baslangicX + (i % sutunSayisi) * (butonGenislik + butonlarArasiBosluk);
                int y = baslangicY + (i / sutunSayisi) * (butonYukseklik + satirlarArasiBosluk);
                btn.Location = new Point(x, y);

                this.Controls.Add(btn);
                KasaButtons.Add(btn);
            }
            designEditor.BtnEditor(KasaButtons, foreColor, backColor, mouseOverColor, mouseDownColor);
        }

        private void KasaUC_Load(object sender, EventArgs e)
        {
            designEditor = new DesignEditor();
            designEditor.BtnEditor(btnKasaEkle, foreColor, backColor, mouseOverColor, mouseDownColor);

            RenderKasalar();
        }

        private void btnKasa_Click(object sender, EventArgs e)
        {
            string kasa_adi = (sender as Button).Text;

            if (!formKasaEkle.Created)
            {
                formKasaEkle = new EkScreen(new KasaEkleUC(kasa_adi));
                formKasaEkle.ShowDialog();
            }

            RenderKasalar();
        }

        private void btnKasaEkle_Click(object sender, EventArgs e)
        {
            if (!formKasaEkle.Created)
            {
                formKasaEkle = new EkScreen(new KasaEkleUC());
                formKasaEkle.ShowDialog();
            }

            RenderKasalar();
        }
    }
}
