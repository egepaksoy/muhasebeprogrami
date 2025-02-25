using Muhasebe_Programı;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProgramLibrary
{
    public class DesignEditor
    {
        public Panel mainPanel = null;
        public List<Button> sideBarButtons = null;
        public Dictionary<string, Func<UserControl>> UserControlCreators;

        public DesignEditor(Panel mainPanel, List<Button> sideBarButtons, Dictionary<string, Func<UserControl>> UserControlCreators)
        {
            this.mainPanel = mainPanel;
            this.sideBarButtons = sideBarButtons;
            this.UserControlCreators = UserControlCreators;
        }

        public DesignEditor()
        {
        }

        public void BtnEditor(Button btn, Color ForeColor, Color BackColor, Color MouseOverColor, Color mouseDownColor)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = BackColor;

            btn.ForeColor = ForeColor;

            btn.FlatAppearance.MouseDownBackColor = mouseDownColor;
            btn.FlatAppearance.MouseOverBackColor = MouseOverColor;
        }

        public void BtnEditor(List<Button> btns, Color ForeColor, Color BackColor, Color MouseOverColor, Color mouseDownColor)
        {
            foreach (var btn in btns)
            {
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.BackColor = BackColor;

                btn.ForeColor = ForeColor;

                btn.FlatAppearance.MouseDownBackColor = mouseDownColor;
                btn.FlatAppearance.MouseOverBackColor = MouseOverColor;
            }
        }

        public void BtnEditor()
        {
            Color foreColor = Color.White;

            Color backColor = Color.Transparent;
            Color mouseOverColor = Color.FromArgb(0x4E, 0x5D, 0x6B);
            Color mouseDownColor = Color.FromArgb(0xB3, 0xBE, 0xC7);

            for (int i = 0; i < this.sideBarButtons.Count; i++)
            {
                BtnEditor(this.sideBarButtons[i], foreColor, backColor, mouseOverColor, mouseDownColor);
            }
        }

        public void SwitchSide(Button btn)
        {
            string ucName = btn.Name.Split("btn")[1].ToLower();

            if (UserControlCreators.ContainsKey(ucName))
            {
                UserControl uc = UserControlCreators[ucName](); // Yeni nesne oluştur
                LoadUserControl(uc, this.mainPanel);
            }
        }

        public static void LoadUserControl(UserControl uc, Panel mainPanel)
        {
            mainPanel.Controls.Clear();
            uc.BackColor = Color.Transparent;
            uc.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(uc);
        }
    }
}
