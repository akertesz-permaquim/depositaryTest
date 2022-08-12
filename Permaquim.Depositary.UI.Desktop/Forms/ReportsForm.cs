using Permaquim.Depositary.UI.Desktop.Builders;
using Permaquim.Depositary.UI.Desktop.Components;
using Permaquim.Depositary.UI.Desktop.Controllers;
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


            if (SecurityController.IsFunctionenabled(FunctionEnum.Transactions))
                LoadOperationsHistoryButton();
            if (SecurityController.IsFunctionenabled(FunctionEnum.BagContent))
                LoadBagContentButton();
            if (SecurityController.IsFunctionenabled(FunctionEnum.BagHistory))
                LoadBagHistoryButton();

            LoadBackButton();
        }
        #region Operations

        private void LoadOperationsHistoryButton()
        {
            CustomButton OperationsButton = ControlBuilder.BuildStandardButton(
                "OperationsButton", MultilanguangeController.GetText(MultiLanguageEnum.HISTORICO_OPERACIONES), MainPanel.Width);

            this.MainPanel.Controls.Add(OperationsButton);
            OperationsButton.Click += new System.EventHandler(OperationsButton_Click);
        }

        private void OperationsButton_Click(object sender, EventArgs e)
        {
            FormsController.OpenChildForm(this, new OperationsHistoryform(),
              (Permaquim.Depositary.UI.Desktop.Components.CounterDevice)this.Tag);
        }
        #endregion

        #region BagContent
        private void LoadBagContentButton()
        {
            CustomButton OperationsButton = ControlBuilder.BuildStandardButton(
                "BagContentButton", MultilanguangeController.GetText(MultiLanguageEnum.CONTENIDO_BOLSA), MainPanel.Width);

            this.MainPanel.Controls.Add(OperationsButton);
            OperationsButton.Click += new System.EventHandler(BagContentButton_Click);
        }
        private void BagContentButton_Click(object sender, EventArgs e)
        {
            FormsController.OpenChildForm(this, new BagContentForm(),
              (Permaquim.Depositary.UI.Desktop.Components.CounterDevice)this.Tag);
        }
        #endregion
        #region Baghistory
        private void LoadBagHistoryButton()
        {
            CustomButton OperationsButton = ControlBuilder.BuildStandardButton(
                "BagHistoryButton", MultilanguangeController.GetText(MultiLanguageEnum.HISTORICO_BOLSA), MainPanel.Width);

            this.MainPanel.Controls.Add(OperationsButton);
            OperationsButton.Click += new System.EventHandler(BagHistoryButton_Click);
        }
        private void BagHistoryButton_Click(object sender, EventArgs e)
        {
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
            CustomButton backButton = ControlBuilder.BuildExitButton(
                "BackButton", MultilanguangeController.GetText(MultiLanguageEnum.VOLVER), MainPanel.Width);

            this.MainPanel.Controls.Add(backButton);
            backButton.Click += new System.EventHandler(BackButton_Click);
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            FormsController.OpenChildForm(this, new OtherOperationsForm(),
              (Permaquim.Depositary.UI.Desktop.Components.CounterDevice)this.Tag);
        }
        #endregion
    }
}
