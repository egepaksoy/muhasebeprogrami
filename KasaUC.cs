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
        List<Button> StokButtons = new List<Button>();
        DesignEditor designEditor;

        EkScreen formStokEkle = new EkScreen(new StokEkleUC());

        public KasaUC()
        {
            InitializeComponent();
        }

        private void KasaUC_Load(object sender, EventArgs e)
        {
            designEditor = new DesignEditor();

            Color foreColor = Color.White;

            Color backColor = Color.FromArgb(0x4E, 0x5D, 0x6B);
            Color mouseOverColor = Color.FromArgb(0xB3, 0xBE, 0xC7);
            Color mouseDownColor = Color.FromArgb(0x4E, 0x5D, 0x6B);
            designEditor.BtnEditor(btnKasaEkle, foreColor, backColor, mouseOverColor, mouseDownColor);
        }

        private void btnKasaEkle_Click(object sender, EventArgs e)
        {
            if (!formStokEkle.Created)
            {
                formStokEkle = new EkScreen(new KasaEkleUC());
                formStokEkle.ShowDialog();
            }
        }
    }
}
