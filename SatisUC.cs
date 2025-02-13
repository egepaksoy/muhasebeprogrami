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
    public partial class SatisUC : UserControl
    {
        bool nakit = false;
        bool taksit = false;

        public SatisUC()
        {
            InitializeComponent();
        }

        private void ChangeVisible(bool nakit, bool taksit)
        {
            textBoxOdenenTutar.Enabled = nakit;
            textBoxOdenenTutar.Visible = nakit;
            labelParaUstu.Enabled = nakit;
            labelParaUstu.Visible = nakit;

            comboBoxTaksitDonemi.Visible = taksit;
            dateTimePickerIlkOdeme.Visible = taksit;
            textBoxOnOdeme.Visible = taksit;
            comboBoxTaksitDonemi.Enabled = taksit;
            dateTimePickerIlkOdeme.Enabled= taksit;
            textBoxOnOdeme.Enabled = taksit;
        }

        private void comboBoxOdemeTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            nakit = comboBoxOdemeTuru.Text == "Nakit";
            taksit = comboBoxOdemeTuru.Text == "Taksit";

            ChangeVisible(nakit, taksit);
        }
    }
}
