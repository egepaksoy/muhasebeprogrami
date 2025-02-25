using ProgramLibrary;

namespace Muhasebe_Programı
{
    public partial class MainScreen : Form
    {
        List<Button> SideBarButtons = new List<Button>();
        DesignEditor designEditor;

        public MainScreen()
        {
            InitializeComponent();
        }

        private Dictionary<string, Func<UserControl>> UserControlCreators = new Dictionary<string, Func<UserControl>>()
        {
            { "kasa", () => new KasaUC() },
            { "cariler", () => new CarilerUC() },
            { "stok", () => new StokUC() },
            { "satis", () => new SatisUC() },
            { "taksitler", () => new TaksitlerUC() },
            { "eskitaksitler", () => new EskiTaksitlerUC() },
            { "eskisatislar", () => new EskiSatislarUC() }
        };

        private void MainScreen_Load(object sender, EventArgs e)
        {
            SideBarButtons = [btnCariler, btnKasa, btnSatis, btnStok, btnTaksitler, btnEskiTaksitler, btnEskiSatislar];

            designEditor = new DesignEditor(mainPanel, SideBarButtons, UserControlCreators);

            designEditor.BtnEditor();

            designEditor.BtnEditor(btnSatis, Color.White, Color.Green, Color.DarkGreen, Color.DarkSeaGreen);
        }

        private void ChangePanel(object sender, EventArgs e)
        {
            designEditor.SwitchSide(sender as Button);
        }
    }
}
