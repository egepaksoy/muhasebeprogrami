using ProgramLibrary;

namespace Muhasebe_Programı
{
    public partial class MainScreen : Form
    {
        List<Button> SideBarButtons = new List<Button>();
        List<UserControl> UserControls = new List<UserControl>();
        DesignEditor designEditor;

        public MainScreen()
        {
            InitializeComponent();
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {
            SideBarButtons = [btnCariler, btnKasa, btnSatis, btnStok, btnTaksitler, btnEskiTaksitler, btnEskiSatislar];
            UserControls = [new KasaUC(), new CarilerUC(), new StokUC(), new SatisUC(), new TaksitlerUC(), new EskiTaksitlerUC(), new EskiSatislarUC()];

            designEditor = new DesignEditor(mainPanel, SideBarButtons, UserControls);

            designEditor.BtnEditor();

            designEditor.BtnEditor(btnSatis, Color.White, Color.Green, Color.DarkGreen, Color.DarkSeaGreen);
        }

        private void ChangePanel(object sender, EventArgs e)
        {
            designEditor.SwitchSide(sender as Button);
        }
    }
}
