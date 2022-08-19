using Permaquim.Depositary.UI.Desktop.Builders;
using Permaquim.Depositary.UI.Desktop.Components;
using Permaquim.Depositary.UI.Desktop.Controllers;
using Permaquim.Depositary.UI.Desktop.Global;
using static Permaquim.Depositary.UI.Desktop.Global.Enumerations;

namespace Permaquim.Depositary.UI.Desktop
{
    public partial class CurrencySelectorForm : Form
    {
        public CounterDevice _device { get; set; }

        private List<Permaquim.Depositario.Entities.Relations.Valor.Moneda> _currencies = DatabaseController.GetCurrencies();
        private System.Windows.Forms.Timer _pollingTimer = new System.Windows.Forms.Timer();
        public CurrencySelectorForm()
        {
            InitializeComponent();
            CenterPanel();
            LoadCurrencyButtons();
            LoadBackButton();
            _pollingTimer = new System.Windows.Forms.Timer()
            {
                Interval = DeviceController.GetPollingInterval()
            };
            _pollingTimer.Tick += PollingTimer_Tick;
            TimeOutController.Reset();
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

        private void CurrencySelectorForm_Load(object sender, EventArgs e)
        {
            _device = (Permaquim.Depositary.UI.Desktop.Components.CounterDevice)this.Tag;
            LoadStyles();
        }
        private void LoadStyles()
        {
            this.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.FondoFormulario);
        }
        #region CurrencyButtons

       private void LoadCurrencyButtons()
        {

            this.MainPanel.Controls.Clear();

            foreach (var item in _currencies)
            {

                CustomButton newButton = ControlBuilder.BuildStandardButton(
                    "CurrencyButton" + item.Id.ToString(), 
                    MultilanguangeController.GetText(item.Nombre), MainPanel.Width);

                newButton.Click += new System.EventHandler(CurrencyButton_Click);

                newButton.Tag = item;

                this.MainPanel.Controls.Add(newButton);
            
            }
        }
        private void CurrencyButton_Click(object sender, EventArgs e)
        {
            // Resetea al timeout por actividad
            TimeOutController.Reset();
            
            // Obtiene la moneda que seleccionó el usuario
            DatabaseController.CurrentCurrency = (Permaquim.Depositario.Entities.Relations.Valor.Moneda)((CustomButton)sender).Tag;

            // Valida que la moneda seleccionada eista en la plantilla del modelo del depositario
            // para evitar inconsistencia

            if (DatabaseController.IsCurrencyInTemplate)
            {
                // Luego valida que tenga denominaciones configuradas para dicha moneda

                if (DatabaseController.CurrencyHasDenominations)
                {
                    if (_device != null)
                        _device.SwitchCurrency(DatabaseController.GetCurrencySequence());

                    if (DatabaseController.CurrentOperation.Id == (int)OperationTypeEnum.BillDeposit)
                    {
                        if (DatabaseController.GetUserBankAccounts().Count == 0 && ParameterController.UsesBankAccount == false)
                        {
                            FormsController.OpenChildForm(this, new BillDepositForm(),
                           (Permaquim.Depositary.UI.Desktop.Components.CounterDevice)this.Tag);
                        }
                        else
                        {
                            FormsController.OpenChildForm(this, new BankAccountSelectorForm(),
                            (Permaquim.Depositary.UI.Desktop.Components.CounterDevice)this.Tag);
                        }
                    }
                    if (DatabaseController.CurrentOperation.Id == (int)OperationTypeEnum.EnvelopeDeposit)
                    {

                        if (DatabaseController.GetUserBankAccounts().Count == 0 && ParameterController.UsesBankAccount == false)
                        {

                            FormsController.OpenChildForm(this, new EnvelopeDepositForm(),
                            (Permaquim.Depositary.UI.Desktop.Components.CounterDevice)this.Tag);
                        }
                        else
                        {
                            FormsController.OpenChildForm(this, new BankAccountSelectorForm(),
                            (Permaquim.Depositary.UI.Desktop.Components.CounterDevice)this.Tag);
                        }
                    }
                }
                else
                {
                    FormsController.SetInformationMessage(InformationTypeEnum.Error,
                        MultilanguangeController.GetText(MultiLanguageEnum.MONEDA_SIN_DENOMINACIONES));
                }
            }
            else
            {
                FormsController.SetInformationMessage(InformationTypeEnum.Error,
                    MultilanguangeController.GetText(MultiLanguageEnum.MONEDA_NO_EXISTENTE_EN_DEPOSITARIO));
            }
        }
        #endregion

        #region BackButton
        private void LoadBackButton()
        {
            CustomButton backButton = ControlBuilder.BuildExitButton(
                "BackButton", MultilanguangeController.GetText(MultiLanguageEnum.VOLVER), MainPanel.Width);

            this.MainPanel.Controls.Add(backButton);

            backButton.Click += new System.EventHandler(BackButton_Click);
        }
        private void BackButton_Click(object sender, EventArgs e)
        {
            FormsController.OpenChildForm(this,new OperationForm(), _device);
        }
        #endregion

        private void CurrencySelectorForm_VisibleChanged(object sender, EventArgs e)
        {
            _pollingTimer.Enabled = this.Visible;
            if (!this.Visible)
            {
                InitializeLocals();
            }
            else
            {
                _currencies = DatabaseController.GetCurrencies();
                LoadCurrencyButtons();
                LoadBackButton();
            }
            FormsController.SetInformationMessage(InformationTypeEnum.None, string.Empty);
        }
        private void InitializeLocals()
        {
            _currencies = new();

        }

        private void CurrencySelectorForm_MouseClick(object sender, MouseEventArgs e)
        {
            TimeOutController.Reset();
        }
    }
}
