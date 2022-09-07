using Permaquim.Depositary.UI.Desktop.Builders;
using Permaquim.Depositary.UI.Desktop.Components;
using Permaquim.Depositary.UI.Desktop.Controllers;
using Permaquim.Depositary.UI.Desktop.Global;
using static Permaquim.Depositary.UI.Desktop.Global.Enumerations;

namespace Permaquim.Depositary.UI.Desktop
{
    public partial class ValueOriginSelectorForm : Form
    {
        private List<Permaquim.Depositario.Entities.Relations.Valor.OrigenValor> _valueOrigins = DatabaseController.GetDepositOrigin();
        private System.Windows.Forms.Timer _pollingTimer = new System.Windows.Forms.Timer();
        public ValueOriginSelectorForm()
        {
            InitializeComponent();

            CenterPanel();
            LoadValueOriginsButtons();
            LoadBackButton();
            LoadStyles();

            TimeOutController.Reset();
            _pollingTimer = new System.Windows.Forms.Timer()
            {
                Interval = DeviceController.GetPollingInterval()
            };
            _pollingTimer.Tick += PollingTimer_Tick;
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

            MainPanel.Location = new Point()
            {
                X = this.Width / 2 - MainPanel.Width / 2,
                Y = this.Height / 2 - MainPanel.Height / 2
            };
        }
        private void LoadStyles()
        {
            this.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.FondoFormulario);
        }

        private void LoadValueOriginsButtons()
        {


            foreach (var item in _valueOrigins)
            {

                CustomButton newButton = ControlBuilder.BuildStandardButton(
                "ValueOriginButton" + item.Id.ToString(),
                item.Nombre 
                , MainPanel.Width);

                newButton.Click += new System.EventHandler(ValueOriginButton_Click);

                newButton.Tag = item;

                this.MainPanel.Controls.Add(newButton);

            }
        }
        private void LoadBackButton()
        {
            CustomButton backButton = ControlBuilder.BuildStandardButton(
                "BackButton", MultilanguangeController.GetText(MultiLanguageEnum.VOLVER), MainPanel.Width);


            this.MainPanel.Controls.Add(backButton);

            backButton.Click += new System.EventHandler(BackButton_Click);
        }
        private void ValueOriginButton_Click(object sender, EventArgs e)
        {
            DatabaseController.CurrentDepositOrigin = (Permaquim.Depositario.Entities.Relations.Valor.OrigenValor)((CustomButton)sender).Tag;

            ValidateUserBankAccount();

        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            FormsController.OpenChildForm(this, new CurrencySelectorForm(),
                  (Permaquim.Depositary.UI.Desktop.Components.CounterDevice)this.Tag);
        }

        private void ValueOriginSelectorForm_VisibleChanged(object sender, EventArgs e)
        {
            _pollingTimer.Enabled = this.Visible;
            if (!this.Visible)
                InitializeLocals();
            FormsController.SetInformationMessage(InformationTypeEnum.None, string.Empty);
        }

        private void InitializeLocals()
        {
            _valueOrigins = new();

        }

        private void ValueOriginSelectorForm_MouseClick(object sender, MouseEventArgs e)
        {
            TimeOutController.Reset();
        }
        private void ValidateUserBankAccount()
        {
            if (ParameterController.UsesBankAccount == true)
            {

                var _userBankAccounts = DatabaseController.GetUserBankAccounts();

                if (_userBankAccounts.Count != 0)
                {
                    if (_userBankAccounts.Count == 1)
                    {
                        DatabaseController.CurrentUserBankAccount = _userBankAccounts.FirstOrDefault();
                        string billDepositFormBreadcrumbText = " - " +
                              MultilanguangeController.GetText(MultiLanguageEnum.USUARIOCUENTA) +
                          ":" + DatabaseController.CurrentUserBankAccount.CuentaId.Numero;
                        if (DatabaseController.CurrentOperation.Id == (int)OperationTypeEnum.BillDeposit)
                            FormsController.OpenChildForm(this, new BillDepositForm(),
                            (CounterDevice)this.Tag, billDepositFormBreadcrumbText);
                        if (DatabaseController.CurrentOperation.Id == (int)OperationTypeEnum.EnvelopeDeposit)
                            FormsController.OpenChildForm(this, new EnvelopeDepositForm(),
                            (CounterDevice)this.Tag, billDepositFormBreadcrumbText);
                    }
                    else
                    {
                        FormsController.OpenChildForm(this, new BankAccountSelectorForm(),
                        (Permaquim.Depositary.UI.Desktop.Components.CounterDevice)this.Tag);
                    }
                }
                else
                {
                    FormsController.SetInformationMessage(InformationTypeEnum.Error,
                         MultilanguangeController.GetText(MultiLanguageEnum.CUENTA_BANCARIA_OBLIGATORIA));
                }
            }
            else
            {
                FormsController.OpenChildForm(this, new BillDepositForm(),
                (Permaquim.Depositary.UI.Desktop.Components.CounterDevice)this.Tag);
            }
        }
    }
}
