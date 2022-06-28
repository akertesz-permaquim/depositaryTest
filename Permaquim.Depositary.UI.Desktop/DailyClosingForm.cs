using Permaquim.Depositary.UI.Desktop.Builders;
using Permaquim.Depositary.UI.Desktop.Components;
using Permaquim.Depositary.UI.Desktop.Controllers;
using Permaquim.Depositary.UI.Desktop.Global;

namespace Permaquim.Depositary.UI.Desktop
{
    public partial class DailyClosingForm : Form
    {
        public Device _device { get; set; }
        private System.Windows.Forms.Timer _pollingTimer = new System.Windows.Forms.Timer();
        public DailyClosingForm()
        {
            InitializeComponent();
            CenterPanel();
            LoadStyles();
            LoadDailyClosingButton();
            LoadBackButton();
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
        private void DailyClosingForm_Load(object sender, EventArgs e)
        {
            _device = (Permaquim.Depositary.UI.Desktop.Components.Device)this.Tag;

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
            InformationLabel.Text = MultilanguangeController.GetText("CONFIRMA_CIERRE_DIARIO");
            InformationLabel.ForeColor = StyleController.GetColor(Enumerations.ColorNameEnum.TextoInformacion);
        }


        #region DailyClosingButton
        private void LoadDailyClosingButton()
        {
            CustomButton backButton = ControlBuilder.BuildStandardButton(
                "DailyClosingButton", MultilanguangeController.GetText("ACCEPT_BUTTON"), MainPanel.Width);

            this.MainPanel.Controls.Add(backButton);

            backButton.Click += new System.EventHandler(DailyClosingButton_Click);
        }
        private void DailyClosingButton_Click(object sender, EventArgs e)
        {
            DatabaseController.CloseCurrentDay();
            AppController.OpenChildForm(this,new OtherOperationsForm(), _device);
        }
        #endregion

        #region BackButton
        private void LoadBackButton()
        {
            CustomButton backButton = ControlBuilder.BuildCancelButton(
                "BackButton", MultilanguangeController.GetText("CANCEL_BUTTON"), MainPanel.Width);

            this.MainPanel.Controls.Add(backButton);

            backButton.Click += new System.EventHandler(BackButton_Click);
        }
        private void BackButton_Click(object sender, EventArgs e)
        {
            AppController.OpenChildForm(this,new OtherOperationsForm(), _device);
        }
        #endregion

    }
}

