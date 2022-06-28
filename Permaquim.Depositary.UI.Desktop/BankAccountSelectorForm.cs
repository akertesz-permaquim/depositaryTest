using Permaquim.Depositary.UI.Desktop.Builders;
using Permaquim.Depositary.UI.Desktop.Controllers;
using Permaquim.Depositary.UI.Desktop.Global;

namespace Permaquim.Depositary.UI.Desktop
{
    public partial class BankAccountSelectorForm : Form
    {
        private List<Permaquim.Depositario.Entities.Relations.Banca.UsuarioCuenta> _userBankAccounts = DatabaseController.GetUserBankAccounts();
        private System.Windows.Forms.Timer _pollingTimer = new System.Windows.Forms.Timer();
        public BankAccountSelectorForm()
        {
            InitializeComponent();

            CenterPanel();
            LoadBankAccountsButtons();
            LoadBackButton();
            ChechSingleAccount();

            TimeOutController.Reset();
            _pollingTimer = new System.Windows.Forms.Timer()
            {
                Interval = DeviceController.GetPollingInterval(),
                Enabled = true
            };
            _pollingTimer.Tick += PollingTimer_Tick;
        }
        private void PollingTimer_Tick(object? sender, EventArgs e)
        {
            if (TimeOutController.IsTimeOut())
            {
                _pollingTimer.Enabled = false;
                DatabaseController.LogOff(true);
                AppController.HideInstance(this);
            }
        }
        private void ChechSingleAccount()
        {
            if (_userBankAccounts.Count <= 1)
                   DatabaseController.CurrentUserBankAccount = _userBankAccounts.FirstOrDefault();
                AppController.OpenChildForm(this,new BillDepositForm(),
                 (Permaquim.Depositary.UI.Desktop.Components.Device)this.Tag);
          
        }

        private void CenterPanel()
        {

            MainPanel.Location = new Point()
            {
                X = this.Width / 2 - MainPanel.Width / 2,
                Y = this.Height / 2 - MainPanel.Height / 2
            };
        }
        private void LoadBankAccountsButtons()
        {


            foreach (var item in _userBankAccounts)
            {

                CustomButton newButton = ControlBuilder.BuildStandardButton(
                "BankAccountButton" + item.Id.ToString(),
                item.CuentaId.Nombre + " - " + item.CuentaId.Numero + " (" + item.CuentaId.BancoId.Nombre + ")"
                , MainPanel.Width);

                 newButton.Click += new System.EventHandler(BankAccountButton_Click);

                newButton.Tag = item;

                this.MainPanel.Controls.Add(newButton);

            }
        }
        private void LoadBackButton()
        {
            CustomButton backButton = ControlBuilder.BuildStandardButton(
                "BackButton", MultilanguageConstants.SALIR, MainPanel.Width);


            this.MainPanel.Controls.Add(backButton);

            backButton.Click += new System.EventHandler(BackButton_Click);
        }
        private void BankAccountButton_Click(object sender, EventArgs e)
        {
            DatabaseController.CurrentUserBankAccount = (Permaquim.Depositario.Entities.Relations.Banca.UsuarioCuenta)((CustomButton)sender).Tag;

            AppController.OpenChildForm(this,new BillDepositForm(),
            (Permaquim.Depositary.UI.Desktop.Components.Device)this.Tag);

        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            AppController.OpenChildForm(this,new CurrencySelectorForm(),
                  (Permaquim.Depositary.UI.Desktop.Components.Device)this.Tag);
        }
    }
}
