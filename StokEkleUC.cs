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
    public partial class StokEkleUC : UserControl
    {
        public StokEkleUC()
        {
            InitializeComponent();
        }
        private void ChangeVisible(bool alim)
        {
            textBoxFaturaNo.Enabled = alim;
            textBoxFaturaNo.Visible = alim;
        }

        private void comboBoxStokTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool alim = comboBoxStokTuru.Text == "Alım";

            ChangeVisible(alim);
        }
    }
}
