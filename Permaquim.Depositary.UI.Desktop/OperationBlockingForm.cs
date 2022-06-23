using Permaquim.Depositary.UI.Desktop.Builders;
using Permaquim.Depositary.UI.Desktop.Components;
using Permaquim.Depositary.UI.Desktop.Controllers;
using Permaquim.Depositary.UI.Desktop.Global;
using static Permaquim.Depositary.UI.Desktop.Global.Enumerations;

namespace Permaquim.Depositary.UI.Desktop
{
    public partial class OperationBlockingForm : Form
    {

        public OperationblockingReasonEnum OperationBlockingReason { get; set; } = OperationblockingReasonEnum.None;
        /// <summary>
        /// Instancia del dispositivo
        /// </summary>
        public Device _device { get; set; }
        public OperationBlockingForm()
        {
            InitializeComponent();
            LoadBackButton();
        }
        public void LoadStyles()
        {
            this.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.Contenido);

        }

        private void OperationBlockingForm_Load(object sender, EventArgs e)
        {
            _device = (Permaquim.Depositary.UI.Desktop.Components.Device)this.Tag;

            LoadStyles();

            switch (OperationBlockingReason)
            {
                case OperationblockingReasonEnum.None:
                    break;
                case OperationblockingReasonEnum.NoTurn:
                    InformationLabel.Text = MultilanguangeController.GetText(MultilanguageConstants.SIN_TURNO);
                    InformationLabel.ForeColor = StyleController.GetColor(Enumerations.ColorNameEnum.TextoError);
                    break;
                default:
                    break;
            }
        }
        #region Back button
        private void LoadBackButton()
        {
            CustomButton backButton = ControlBuilder.BuildExitButton(
                "BackButton", MultilanguageConstants.SALIR, MainPanel.Width);

            this.MainPanel.Controls.Add(backButton);
            backButton.Click += new System.EventHandler(BackButton_Click);
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
