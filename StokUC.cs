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
using System.Reflection;

namespace Muhasebe_Programı
{
    public partial class StokUC : UserControl
    {
        SQLController sqlController = new SQLController();
        DesignEditor designEditor;

        List<Button> StokButtons = new List<Button>();
        List<string> Urunler = new List<string>();

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

        EkScreen formStokEkle = new EkScreen(new StokEkleUC());

        public StokUC()
        {
            InitializeComponent();
        }

        private void RemoveButtons()
        {
            foreach (Control btn in StokButtons)
            {
                this.Controls.Remove(btn);
                btn.Dispose();
            }
        }

        private void RenderStok()
        {
            RemoveButtons();
            if (StokButtons != null)
                StokButtons.Clear();
            if (Urunler != null)
                Urunler.Clear();

            Urunler = sqlController.LoadStoklar();

            int toplamButonGenislik = sutunSayisi * butonGenislik;
            butonlarArasiBosluk = (panelGenislik - (2 * baslangicX) - toplamButonGenislik) / (sutunSayisi - 1);

            string urunAdi;

            if (Urunler == null)
                return;
            for (int i = 1; i <= Urunler.Count; i++)
            {
                urunAdi = Urunler[i - 1];
                Button btn = new Button();
                btn.Name = $"btnUrun{urunAdi}";
                btn.Text = urunAdi;
                btn.Size = new Size(butonGenislik, butonYukseklik);
                btn.Font = new Font("Segoe UI", 20, FontStyle.Regular);
                btn.Click += (s, e) => btnUrun_Click(s, e);

                int x = baslangicX + (i % sutunSayisi) * (butonGenislik + butonlarArasiBosluk);
                int y = baslangicY + (i / sutunSayisi) * (butonYukseklik + satirlarArasiBosluk);
                btn.Location = new Point(x, y);

                this.Controls.Add(btn);
                StokButtons.Add(btn);
            }
            designEditor.BtnEditor(StokButtons, foreColor, backColor, mouseOverColor, mouseDownColor);
        }

        private void StokUC_Load(object sender, EventArgs e)
        {
            designEditor = new DesignEditor();
            designEditor.BtnEditor(btnStokEkle, foreColor, backColor, mouseOverColor, mouseDownColor);

            RenderStok();
        }

        private void btnUrun_Click(object sender, EventArgs e)
        {
            string urun_adi = (sender as Button).Text;

            if (!formStokEkle.Created)
            {
                formStokEkle = new EkScreen(new StokEkleUC(urun_adi));
                formStokEkle.ShowDialog();
            }

            RenderStok();
        }

        private void btnStokEkle_Click(object sender, EventArgs e)
        {
            if (!formStokEkle.Created)
            {
                formStokEkle = new EkScreen(new StokEkleUC());
                formStokEkle.ShowDialog();
            }

            RenderStok();
        }
    }
}
