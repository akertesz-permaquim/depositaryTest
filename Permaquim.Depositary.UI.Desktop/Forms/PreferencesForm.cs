using Permaquim.Depositary.UI.Desktop.Controllers;
using Permaquim.Depositary.UI.Desktop.Model;

namespace Permaquim.Depositary.UI.Desktop
{
    public partial class PreferencesForm : Form
    {
        SettingsModel _model = new();
        private System.Windows.Forms.Timer _pollingTimer = new System.Windows.Forms.Timer();
        public PreferencesForm()
        {
            InitializeComponent();
            CenterPanel();
            LoadSettings();

        }

        private void LoadSettings()
        {

            
            MainPropertyGrid.SelectedObject = _model;
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams CP = base.CreateParams;
                CP.ExStyle = CP.ExStyle | 0x02000000; // WS_EX_COMPOSITED
                return CP;
            }
        }
        private void PollingTimer_Tick(object? sender, EventArgs e)
        {
            if (TimeOutController.IsTimeOut())
            {
                _pollingTimer.Enabled = false;
                DatabaseController.LogOff(true);
                FormsController.LogOff();
            }
        }
        private void CenterPanel()
        {

            //MainPanel.Location = new Point()
            //{
            //    X = this.Width / 2 - MainPanel.Width / 2,
            //    Y = this.Height / 2 - MainPanel.Height / 2
            //};
        }

        private void LoadLanguages()
        {
            //LanguageComboBox.Items.Clear();
            //LanguageComboBox.DisplayMember = "Nombre";
            //LanguageComboBox.ValueMember = "Id";
            //LanguageComboBox.DataSource = DatabaseController.GetLanguageList();

            //LanguageComboBox.SelectedIndex = (int)DatabaseController.CurrentUser.LenguajeId.Id;


        }

        private void LanguageComboBox_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            //DatabaseController.SetLanguageId(LanguageComboBox.SelectedIndex);
        }

        private void CancelDepositButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ConfirmAndContinueDepositButton_Click(object sender, EventArgs e)
        {
            LoginModel loginModel = new()
            {
                UserName = _model.CodigoDepositario,
                Password = _model.ClaveDepositario
            };

            InitializationController.InitializeDepositary(loginModel, _model.WebApiUrl);
               
         
        }
    }
}
