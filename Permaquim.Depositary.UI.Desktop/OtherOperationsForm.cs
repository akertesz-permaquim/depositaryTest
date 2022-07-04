using Permaquim.Depositary.UI.Desktop.Builders;
using Permaquim.Depositary.UI.Desktop.Components;
using Permaquim.Depositary.UI.Desktop.Controllers;
using Permaquim.Depositary.UI.Desktop.Global;
using static Permaquim.Depositary.UI.Desktop.Global.Enumerations;

namespace Permaquim.Depositary.UI.Desktop
{
    public partial class OtherOperationsForm : Form
    {
        Device _device = null;
        private System.Windows.Forms.Timer _pollingTimer = new System.Windows.Forms.Timer();
        public OtherOperationsForm()
        {
            InitializeComponent();
            CenterPanel();
            LoadStyles();
            LoadTurnButton();
            LoadDailyClosingButton();
            LoadOperationsButton();
            LoadReportssButton();
            LoadSupportButton();
            LoadBackButton();
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
        private void OtherOperationsForm_Load(object sender, EventArgs e)
        {
            _device = (Permaquim.Depositary.UI.Desktop.Components.Device)this.Tag;
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
            CustomButton backButton = ControlBuilder.BuildExitButton(
                "BackButton", MultilanguangeController.GetText(MultiLanguageEnum.EXIT_BUTTON), MainPanel.Width);

            this.MainPanel.Controls.Add(backButton);
            backButton.Click += new System.EventHandler(BackButton_Click);
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            FormsController.OpenChildForm(this,new OperationForm(),
              (Permaquim.Depositary.UI.Desktop.Components.Device)this.Tag);
        }
        #endregion

        #region Turn

        private void LoadTurnButton()
        {
            CustomButton TurnButton = ControlBuilder.BuildStandardButton(
                "TurnButton", MultilanguangeController.GetText(MultiLanguageEnum.CAMBIO_TURNO), MainPanel.Width);

            this.MainPanel.Controls.Add(TurnButton);
            TurnButton.Click += new System.EventHandler(TurnButton_Click);
        }

        private void TurnButton_Click(object sender, EventArgs e)
        {
            FormsController.OpenChildForm(this,new TurnChangeForm(),
              (Permaquim.Depositary.UI.Desktop.Components.Device)this.Tag);
        }
        #endregion

        #region DailyClosing

        private void LoadDailyClosingButton()
        {
            CustomButton AccountClosingButton = ControlBuilder.BuildStandardButton(
                "DailyClosingButton", MultilanguangeController.GetText(MultiLanguageEnum.CIERRE_DIARIO), MainPanel.Width);

            this.MainPanel.Controls.Add(AccountClosingButton);
            AccountClosingButton.Click += new System.EventHandler(DailyClosingButton_Click);
        }

        private void DailyClosingButton_Click(object sender, EventArgs e)
        {
            FormsController.OpenChildForm(this, new DailyClosingForm(),
              (Permaquim.Depositary.UI.Desktop.Components.Device)this.Tag);
        }
        #endregion


        #region Operations

        private void LoadOperationsButton()
        {
            CustomButton OperationsButton = ControlBuilder.BuildStandardButton(
                "OperationsButton", MultilanguangeController.GetText(MultiLanguageEnum.HISTORICO_OPERACIONES), MainPanel.Width);

            this.MainPanel.Controls.Add(OperationsButton);
            OperationsButton.Click += new System.EventHandler(OperationsButton_Click);
        }

        private void OperationsButton_Click(object sender, EventArgs e)
        {
            FormsController.OpenChildForm(this, new OperationsHistoryform(),
              (Permaquim.Depositary.UI.Desktop.Components.Device)this.Tag);
        }
        #endregion

        #region Reports
        private void LoadReportssButton()
        {
            CustomButton OperationsButton = ControlBuilder.BuildStandardButton(
                "ReportsButton", MultilanguangeController.GetText(MultiLanguageEnum.REPORTES), MainPanel.Width);

            this.MainPanel.Controls.Add(OperationsButton);
            OperationsButton.Click += new System.EventHandler(ReportsButton_Click);
        }
        private void ReportsButton_Click(object sender, EventArgs e)
        {
            FormsController.OpenChildForm(this, new OperationsHistoryform(),
              (Permaquim.Depositary.UI.Desktop.Components.Device)this.Tag);
        }
        #endregion

        #region Support

        private void LoadSupportButton()
        {
            CustomButton supportButton = ControlBuilder.BuildAlternateButton(
                "SupportButton", MultilanguangeController.GetText(MultiLanguageEnum.SOPORTE), MainPanel.Width);

            this.MainPanel.Controls.Add(supportButton);
            supportButton.Click += new System.EventHandler(SupportButton_Click);
        }

        private void SupportButton_Click(object sender, EventArgs e)
        {
            FormsController.OpenChildForm(this, new SupportForm(),
              (Permaquim.Depositary.UI.Desktop.Components.Device)this.Tag);
        }
        #endregion

        private void OtherOperationsForm_VisibleChanged(object sender, EventArgs e)
        {
            _pollingTimer.Enabled = this.Visible;
            if (!this.Visible)
                InitializeLocals();
        }
        private void InitializeLocals()
        {
            // inicializar variables locales
        }
    }
}
