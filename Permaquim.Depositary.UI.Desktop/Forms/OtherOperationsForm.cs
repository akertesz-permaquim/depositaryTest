using Permaquim.Depositary.UI.Desktop.Builders;
using Permaquim.Depositary.UI.Desktop.Components;
using Permaquim.Depositary.UI.Desktop.Controllers;
using Permaquim.Depositary.UI.Desktop.Global;
using static Permaquim.Depositary.UI.Desktop.Global.Enumerations;

namespace Permaquim.Depositary.UI.Desktop
{
    public partial class OtherOperationsForm : Form
    {
        CounterDevice _device = null;
        private System.Windows.Forms.Timer _pollingTimer = new System.Windows.Forms.Timer();
        public OtherOperationsForm()
        {
            InitializeComponent();

            CenterPanel();

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
        private void LoadFunctionButtons()
        {
            this.MainPanel.Controls.Clear();

            if (SecurityController.IsFunctionEnabled(FunctionEnum.CambioDeTurno))
                LoadTurnButton();
            if (SecurityController.IsFunctionEnabled(FunctionEnum.CierreDiario))
                LoadDailyClosingButton();
            if (SecurityController.IsFunctionEnabled(FunctionEnum.Soporte))
                LoadSupportButton();
            if (SecurityController.IsFunctionEnabled(FunctionEnum.Reset))
                LoadResetButton();

            LoadBackButton();
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
        private void OtherOperationsForm_Load(object sender, EventArgs e)
        {
            _device = (Permaquim.Depositary.UI.Desktop.Components.CounterDevice)this.Tag;
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

        #region Back button
        private void LoadBackButton()
        {
            System.Windows.Forms.Button backButton = ControlBuilder.BuildExitButton(
                "BackButton", MultilanguangeController.GetText(MultiLanguageEnum.VOLVER), MainPanel.Width);

            this.MainPanel.Controls.Add(backButton);
            backButton.Click += new System.EventHandler(BackButton_Click);
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            FormsController.OpenChildForm(this,new OperationForm(),
              (Permaquim.Depositary.UI.Desktop.Components.CounterDevice)this.Tag);
        }
        #endregion

        #region Turn

        private void LoadTurnButton()
        {
            System.Windows.Forms.Button TurnButton = ControlBuilder.BuildStandardButton(
                "TurnButton", MultilanguangeController.GetText(MultiLanguageEnum.CAMBIO_TURNO), MainPanel.Width);

            this.MainPanel.Controls.Add(TurnButton);
            TurnButton.Click += new System.EventHandler(TurnButton_Click);
        }

        private void TurnButton_Click(object sender, EventArgs e)
        {
            if (DatabaseController.GetAvailableTurns() > 0 || DatabaseController.GetPreviousDaysTurns() > 0 )
            {
                FormsController.OpenChildForm(this, new TurnChangeForm(),
                  (Permaquim.Depositary.UI.Desktop.Components.CounterDevice)this.Tag);
            }
            else
            {
                FormsController.SetInformationMessage(InformationTypeEnum.Error, MultilanguangeController.GetText(MultiLanguageEnum.SIN_TURNO));
            }
        }
        #endregion

        #region DailyClosing

        private void LoadDailyClosingButton()
        {
            System.Windows.Forms.Button AccountClosingButton = ControlBuilder.BuildStandardButton(
                "DailyClosingButton", MultilanguangeController.GetText(MultiLanguageEnum.CIERRE_DIARIO), MainPanel.Width);

            this.MainPanel.Controls.Add(AccountClosingButton);
            AccountClosingButton.Click += new System.EventHandler(DailyClosingButton_Click);
        }

        private void DailyClosingButton_Click(object sender, EventArgs e)
        {

            if (DatabaseController.CurrentDailyClosing == null)
            {
                if (DatabaseController.GetAvailableTurns() == 0)
                {
                    FormsController.OpenChildForm(this, new DailyClosingForm(),
                  (Permaquim.Depositary.UI.Desktop.Components.CounterDevice)this.Tag);
                }
                else
                {
                    FormsController.SetInformationMessage(InformationTypeEnum.Error,
                        MultilanguangeController.GetText(MultiLanguageEnum.EXISTEN_TURNOS_ABIERTOS));
                }
            }
            else
            {
                FormsController.SetInformationMessage(InformationTypeEnum.Error,
                    MultilanguangeController.GetText(MultiLanguageEnum.CIERRE_DIARIO_REALIZADO));
            }
        }
        #endregion

        #region Support

        private void LoadSupportButton()
        {
            System.Windows.Forms.Button supportButton = ControlBuilder.BuildAlternateButton(
                "SupportButton", MultilanguangeController.GetText(MultiLanguageEnum.SOPORTE), MainPanel.Width);

            this.MainPanel.Controls.Add(supportButton);
            supportButton.Click += new System.EventHandler(SupportButton_Click);
        }

        private void SupportButton_Click(object sender, EventArgs e)
        {
            FormsController.OpenChildForm(this, new SupportForm(),
              (Permaquim.Depositary.UI.Desktop.Components.CounterDevice)this.Tag);
        }
        #endregion



        #region Reset

        private void LoadResetButton()
        {
            System.Windows.Forms.Button supportButton = ControlBuilder.BuildAlternateButton(
                "ResetButton", MultilanguangeController.GetText(MultiLanguageEnum.RESET), MainPanel.Width);

            this.MainPanel.Controls.Add(supportButton);
            supportButton.Click += new System.EventHandler(ResetButton_Click);
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            if (_device != null && _device.CounterConnected)
            {
                _device.NormalErrorRecoveryMode();
                System.Threading.Thread.Sleep(500);
                _device.StoringErrorRecoveryMode();
                System.Threading.Thread.Sleep(500);
                _device.DeviceReset();
            }
        }
        #endregion

        private void OtherOperationsForm_VisibleChanged(object sender, EventArgs e)
        {
            _pollingTimer.Enabled = this.Visible;
            if (!this.Visible)
                InitializeLocals();
            else
                LoadFunctionButtons();
            FormsController.SetInformationMessage(InformationTypeEnum.None, string.Empty);
        }
        private void InitializeLocals()
        {
            // inicializar variables locales
        }

        private void OtherOperationsForm_MouseClick(object sender, MouseEventArgs e)
        {
            TimeOutController.Reset();
        }
    }
}
