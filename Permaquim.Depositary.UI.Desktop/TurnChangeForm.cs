using Permaquim.Depositary.UI.Desktop.Builders;
using Permaquim.Depositary.UI.Desktop.Components;
using Permaquim.Depositary.UI.Desktop.Controllers;
using Permaquim.Depositary.UI.Desktop.Global;
using static Permaquim.Depositary.UI.Desktop.Global.Enumerations;

namespace Permaquim.Depositary.UI.Desktop
{
    public partial class TurnChangeForm : Form
    {
        public Device _device { get; set; }
        private System.Windows.Forms.Timer _pollingTimer = new System.Windows.Forms.Timer();

        public TurnChangeForm()
        {
            InitializeComponent();
            CenterPanel();
            LoadStyles();
            LoadMultiLangiageItems();
            LoadTurnChangeButton();
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
        private void TurnChangeForm_Load(object sender, EventArgs e)
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
            InformationLabel.ForeColor = StyleController.GetColor(Enumerations.ColorNameEnum.TextoInformacion);
        }
        private void LoadMultiLangiageItems()
        {
            InformationLabel.Text = MultilanguangeController.GetText(MultiLanguageEnum.CONFIRMA_CIERRE_TURNO);
            InformationLabel.Text += Environment.NewLine + "Turno actual: "
                + DatabaseController.CurrentTurn.TurnoDepositarioId.Nombre;
        }


        #region TurnchangeButton
        private void LoadTurnChangeButton()
        {
            CustomButton backButton = ControlBuilder.BuildExitButton(
                "TurnchangeButton", MultilanguangeController.GetText(MultiLanguageEnum.ACCEPT_BUTTON), MainPanel.Width);

            this.MainPanel.Controls.Add(backButton);

            backButton.Click += new System.EventHandler(TurnchangeButton_Click);
        }
        private void TurnchangeButton_Click(object sender, EventArgs e)
        {
            DatabaseController.CloseCurrentTurn();

            FormsController.OpenChildForm(this,new OtherOperationsForm(), _device);
        }
        #endregion

        #region BackButton
        private void LoadBackButton()
        {
            CustomButton backButton = ControlBuilder.BuildCancelButton(
                "BackButton", MultilanguangeController.GetText(MultiLanguageEnum.CANCEL_BUTTON), MainPanel.Width);

            this.MainPanel.Controls.Add(backButton);

            backButton.Click += new System.EventHandler(BackButton_Click);
        }
        private void BackButton_Click(object sender, EventArgs e)
        {
            FormsController.OpenChildForm(this,new OtherOperationsForm(), _device);
        }
        #endregion

        private void TurnChangeForm_VisibleChanged(object sender, EventArgs e)
        {
            _pollingTimer.Enabled = this.Visible;
            if (!this.Visible)
                InitializeLocals();
        }
        private void InitializeLocals()
        {
            // inicializar variables locales.
        }
    }
}
