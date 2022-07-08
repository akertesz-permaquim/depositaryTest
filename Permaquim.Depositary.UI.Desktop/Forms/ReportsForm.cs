using Permaquim.Depositary.UI.Desktop.Builders;
using Permaquim.Depositary.UI.Desktop.Components;
using Permaquim.Depositary.UI.Desktop.Controllers;
using Permaquim.Depositary.UI.Desktop.Global;
using static Permaquim.Depositary.UI.Desktop.Global.Enumerations;

namespace Permaquim.Depositary.UI.Desktop
{
    public partial class ReportsForm : Form
    {
        Device _device = null;
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
        private void ReportsForm_VisibleChanged(object sender, EventArgs e)
        {
            _pollingTimer.Enabled = this.Visible;
            if (!this.Visible)
                InitializeLocals();
        }
        private void InitializeLocals()
        {
            // inicializar variables locales
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
            FormsController.OpenChildForm(this, new OtherOperationsForm(),
              (Permaquim.Depositary.UI.Desktop.Components.Device)this.Tag);
        }
        #endregion
    }
}
