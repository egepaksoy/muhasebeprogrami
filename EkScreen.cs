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
    public partial class EkScreen : Form
    {
        UserControl userControl = null;

        public EkScreen(UserControl UC)
        {
            InitializeComponent();
            userControl = UC;
        }

        public EkScreen(UserControl UC, Size size)
        {
            InitializeComponent();
            userControl = UC;
            this.Size = size;
        }

        private void EkScreen_Load(object sender, EventArgs e)
        {
            mainPanel.Visible = true;
            mainPanel.Enabled = true;

            DesignEditor.LoadUserControl(userControl, mainPanel);
        }
    }
}
