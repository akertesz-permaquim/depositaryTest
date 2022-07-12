using Permaquim.Depositary.UI.Desktop.Builders;
using Permaquim.Depositary.UI.Desktop.Components;
using Permaquim.Depositary.UI.Desktop.Controllers;
using Permaquim.Depositary.UI.Desktop.Global;
using static Permaquim.Depositary.UI.Desktop.Global.Enumerations;

namespace Permaquim.Depositary.UI.Desktop
{
    public partial class OperationForm : Form
    {

        private List<Permaquim.Depositario.Entities.Relations.Operacion.TipoTransaccion> _transactions = DatabaseController.GetTransactionTypes();
        private System.Windows.Forms.Timer _pollingTimer = new System.Windows.Forms.Timer();

        Device _device = null;
        public OperationForm()
        {
            InitializeComponent();
            TimeOutController.Reset();
            _pollingTimer = new System.Windows.Forms.Timer()
            {
                Interval = DeviceController.GetPollingInterval()
            };
            _pollingTimer.Tick += PollingTimer_Tick;
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
        private void OperationForm_Load(object sender, EventArgs e)
        {
            _device = (Permaquim.Depositary.UI.Desktop.Components.Device)this.Tag;
            LoadStyles();
            CenterPanel();
            if (_device.CounterConnected)
                SetDeviceToNeutralMode();
            LoadTransactionButtons();
            LoadOtherOperationsButton();
            LoadBackButton();

        }
        private void LoadStyles()
        {
            this.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.FondoFormulario);
        }
        private void CenterPanel()
        {

            MainPanel.Location = new Point()
            {
                X = this.Width / 2 - MainPanel.Width / 2,
                Y = this.Height / 2 - MainPanel.Height / 2
            };
        }
        private void LoadTransactionButtons()
        {
            this.MainPanel.Controls.Clear();

            foreach (var item in _transactions)
            {

                if (SecurityController.IsFunctionenabled((long)item.FuncionId))
                {
                    CustomButton newButton = ControlBuilder.BuildStandardButton(
                        "TransactionButton" + item.Id.ToString(),
                        MultilanguangeController.GetText(item.Nombre), MainPanel.Width);

                    newButton.Click += new System.EventHandler(TransactionButton_Click);

                    newButton.Tag = item;

                    this.MainPanel.Controls.Add(newButton);
                }
            }
        }
        private void TransactionButton_Click(object sender, EventArgs e)
        {
            DatabaseController.CurrentOperation = (Permaquim.Depositario.Entities.Relations.Operacion.TipoTransaccion)((CustomButton)sender).Tag;

            switch ((int)DatabaseController.CurrentOperation.Id)
            {

                case (int)OperationTypeEnum.BillDeposit:
                case (int)OperationTypeEnum.EnvelopeDeposit:
                    _device.RemoteCancel();
                    FormsController.OpenChildForm(this, new CurrencySelectorForm(),
                    (Permaquim.Depositary.UI.Desktop.Components.Device)this.Tag);
                    break;
                case (int)OperationTypeEnum.ValueExtraction:
                    FormsController.OpenChildForm(this, new BagExtractionForm(),
                        (Permaquim.Depositary.UI.Desktop.Components.Device)this.Tag);
                    break;
                default:
                    break;
            }
        }
        private void LoadBackButton()
        {
            CustomButton backButton = ControlBuilder.BuildExitButton(
                "BackButton", MultilanguangeController.GetText(MultiLanguageEnum.EXIT_BUTTON), MainPanel.Width);

            this.MainPanel.Controls.Add(backButton);
            backButton.Click += new System.EventHandler(BackButton_Click);
        }

        #region Other Operations
        private void LoadOtherOperationsButton()
        {
            if (SecurityController.IsFunctionenabled(FunctionEnum.OtherOperations))
            {
                CustomButton otherOperationsButton = ControlBuilder.BuildAlternateButton(
                    "OtherOperationsButton", MultilanguangeController.GetText(MultiLanguageEnum.OTRAS_OPERACIONES), MainPanel.Width);

                this.MainPanel.Controls.Add(otherOperationsButton);
                otherOperationsButton.Click += new System.EventHandler(OtherOperationButton_Click);
            }
        }

        private void OtherOperationButton_Click(object sender, EventArgs e)
        {
            FormsController.OpenChildForm(this, new OtherOperationsForm(),
              (Permaquim.Depositary.UI.Desktop.Components.Device)this.Tag);
        }
        # endregion

        private void BackButton_Click(object sender, EventArgs e)
        {
            DatabaseController.LogOff(false);
            MultilanguangeController.ResetLanguage();
            FormsController.HideInstance(this);
        }
        private void SetDeviceToNeutralMode()
        {
            // si por algun motivo el equipo se recupera de una transacción fallida,
            // se cancela la operación.
            if (_device.StateResultProperty.ModeStateInformation.ModeState
                == ModeStateInformation.Mode.DepositMode
                || _device.StateResultProperty.ModeStateInformation.ModeState
                == ModeStateInformation.Mode.ManualMode)
            {
                _device.RemoteCancel();
            }
        }

        private void OperationForm_MouseClick(object sender, MouseEventArgs e)
        {
            TimeOutController.Reset();
        }

        private void OperationForm_VisibleChanged(object sender, EventArgs e)
        {
            _pollingTimer.Enabled = this.Visible;
            if (!this.Visible)
                InitializeLocals();
            else
            {
                _transactions = DatabaseController.GetTransactionTypes();
                LoadTransactionButtons();
                LoadOtherOperationsButton();
                LoadBackButton();
            }
        }
        private void InitializeLocals()
        {
            _transactions = new();
        }
    }
}
