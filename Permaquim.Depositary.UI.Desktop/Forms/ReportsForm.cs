using Permaquim.Depositary.UI.Desktop.Builders;
using Permaquim.Depositary.UI.Desktop.Components;
using Permaquim.Depositary.UI.Desktop.Controllers;
using Permaquim.Depositary.UI.Desktop.Forms;
using Permaquim.Depositary.UI.Desktop.Global;
using static Permaquim.Depositary.UI.Desktop.Global.Enumerations;

namespace Permaquim.Depositary.UI.Desktop
{
    public partial class ReportsForm : Form
    {
        CounterDevice _device = null;
        private System.Windows.Forms.Timer _pollingTimer = new System.Windows.Forms.Timer();
        public ReportsForm()
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
        private void PollingTimer_Tick(object? sender, EventArgs e)
        {
            if (TimeOutController.IsTimeOut())
            {
                _pollingTimer.Enabled = false;
                DatabaseController.LogOff(true);
                FormsController.LogOff();
            }
        }

        private void ReportsForm_Load(object sender, EventArgs e)
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
        private void ReportsForm_VisibleChanged(object sender, EventArgs e)
        {

            _pollingTimer.Enabled = this.Visible;
            if (!this.Visible)
                InitializeLocals();
            else
                LoadFunctionButtons();
        }


        private void LoadFunctionButtons()
        {
            this.MainPanel.Controls.Clear();


            if (SecurityController.IsFunctionEnabled(FunctionEnum.HistoricoTransacciones))
                LoadOperationsHistoryButton();

            if (SecurityController.IsFunctionEnabled(FunctionEnum.HistoricoTransaccionesUsuario))
                LoadOperationsSingleUserHistoryButton();

            if (SecurityController.IsFunctionEnabled(FunctionEnum.ContenidoDeBolsa))
                LoadBagContentButton();

            if (SecurityController.IsFunctionEnabled(FunctionEnum.HistoricoDeBolsas))
                LoadBagHistoryButton();

            if (SecurityController.IsFunctionEnabled(FunctionEnum.HistoricoDeTurnos))
                LoadTurnsHistoryButton();

            if (SecurityController.IsFunctionEnabled(FunctionEnum.HistoricoDeCierreDiario))
                LoadDailyClosingHistoryButton();

            LoadBackButton();
        }

        #region DailyClosingHistory
        private void LoadDailyClosingHistoryButton()
        {
            System.Windows.Forms.Button OperationsButton = ControlBuilder.BuildStandardButton(
                "DailyClosingHistoryButton", MultilanguangeController.GetText(MultiLanguageEnum.HISTORICO_CIERRE_DIARIO), MainPanel.Width);

            this.MainPanel.Controls.Add(OperationsButton);
            OperationsButton.Click += new System.EventHandler(DailyClosingHistoryButton_Click);
        }
        private void DailyClosingHistoryButton_Click(object sender, EventArgs e)
        {
            TimeOutController.Reset();
            FormsController.OpenChildForm(this, new DailyClosingHistoryForm(),
              (Permaquim.Depositary.UI.Desktop.Components.CounterDevice)this.Tag);
        }
        #endregion

        #region TurnsHistory
        private void LoadTurnsHistoryButton()
        {
            System.Windows.Forms.Button OperationsButton = ControlBuilder.BuildStandardButton(
                "TurnsHistoryButton", MultilanguangeController.GetText(MultiLanguageEnum.HISTORICO_TURNO), MainPanel.Width);

            this.MainPanel.Controls.Add(OperationsButton);
            OperationsButton.Click += new System.EventHandler(TurnsHistoryButton_Click);
        }
        private void TurnsHistoryButton_Click(object sender, EventArgs e)
        {
            TimeOutController.Reset();
            FormsController.OpenChildForm(this, new TurnsHistoryForm(),
              (Permaquim.Depositary.UI.Desktop.Components.CounterDevice)this.Tag);
        }
        #endregion

        #region Operations

        private void LoadOperationsHistoryButton()
        {
            System.Windows.Forms.Button OperationsButton = ControlBuilder.BuildStandardButton(
                "OperationsButton", MultilanguangeController.GetText(MultiLanguageEnum.HISTORICO_OPERACIONES), MainPanel.Width);

            this.MainPanel.Controls.Add(OperationsButton);
            OperationsButton.Click += new System.EventHandler(OperationsButton_Click);
        }

        private void OperationsButton_Click(object sender, EventArgs e)
        {
            TimeOutController.Reset();
            FormsController.OpenChildForm(this, new OperationsHistoryForm(),
              (Permaquim.Depositary.UI.Desktop.Components.CounterDevice)this.Tag);
        }
        #endregion
        #region Operations single user

        private void LoadOperationsSingleUserHistoryButton()
        {
            System.Windows.Forms.Button OperationsSingleUserButton = ControlBuilder.BuildStandardButton(
                "OperationsSingleUserButton", MultilanguangeController.GetText(MultiLanguageEnum.HISTORICO_OPERACIONES), MainPanel.Width);

            this.MainPanel.Controls.Add(OperationsSingleUserButton);
            OperationsSingleUserButton.Click += new System.EventHandler(OperationsSingleUserButton_Click);
        }

        private void OperationsSingleUserButton_Click(object sender, EventArgs e)
        {
            TimeOutController.Reset();
            FormsController.OpenChildForm(this, new OperationsHistoryForm(true),
              (Permaquim.Depositary.UI.Desktop.Components.CounterDevice)this.Tag);
        }
        #endregion
        #region BagContent
        private void LoadBagContentButton()
        {
            System.Windows.Forms.Button OperationsButton = ControlBuilder.BuildStandardButton(
                "BagContentButton", MultilanguangeController.GetText(MultiLanguageEnum.CONTENIDO_BOLSA), MainPanel.Width);

            this.MainPanel.Controls.Add(OperationsButton);
            OperationsButton.Click += new System.EventHandler(BagContentButton_Click);
        }
        private void BagContentButton_Click(object sender, EventArgs e)
        {
            TimeOutController.Reset();
            FormsController.OpenChildForm(this, new BagContentForm(),
              (Permaquim.Depositary.UI.Desktop.Components.CounterDevice)this.Tag);
        }
        #endregion
        #region Baghistory
        private void LoadBagHistoryButton()
        {
            System.Windows.Forms.Button OperationsButton = ControlBuilder.BuildStandardButton(
                "BagHistoryButton", MultilanguangeController.GetText(MultiLanguageEnum.HISTORICO_BOLSA), MainPanel.Width);

            this.MainPanel.Controls.Add(OperationsButton);
            OperationsButton.Click += new System.EventHandler(BagHistoryButton_Click);
        }
        private void BagHistoryButton_Click(object sender, EventArgs e)
        {
            TimeOutController.Reset();
            FormsController.OpenChildForm(this, new BagHistoryForm(),
              (Permaquim.Depositary.UI.Desktop.Components.CounterDevice)this.Tag);
        }
        #endregion

        private void InitializeLocals()
        {
            // inicializar variables locales
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
            TimeOutController.Reset();
            FormsController.OpenChildForm(this, new OperationForm(),
              (Permaquim.Depositary.UI.Desktop.Components.CounterDevice)this.Tag);
        }
        #endregion

        private void ReportsForm_Click(object sender, EventArgs e)
        {
            TimeOutController.Reset();
        }

        private void MainPanel_Click(object sender, EventArgs e)
        {
            TimeOutController.Reset();
        }
    }
}
