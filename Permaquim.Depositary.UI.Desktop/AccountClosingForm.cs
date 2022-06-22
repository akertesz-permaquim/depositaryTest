using Permaquim.Depositary.UI.Desktop.Builders;
using Permaquim.Depositary.UI.Desktop.Components;
using Permaquim.Depositary.UI.Desktop.Controllers;
using Permaquim.Depositary.UI.Desktop.Global;

namespace Permaquim.Depositary.UI.Desktop
{
    public partial class AccountClosingForm : Form
    {
        public Device _device { get; set; }

        public AccountClosingForm()
        {
            InitializeComponent();
            CenterPanel();
            LoadStyles();
            LoadAccountClosingButton();
            LoadBackButton();
        }

        private void AccountClosingForm_Load(object sender, EventArgs e)
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
            this.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.Contenido);
            InformationLabel.Text = MultilanguangeController.GetText("CONFIRMA_CIERRE_CONTABLE");
            InformationLabel.ForeColor = StyleController.GetColor(Enumerations.ColorNameEnum.TextoInformacion);
        }


        #region AccountClosingButton
        private void LoadAccountClosingButton()
        {
            CustomButton backButton = ControlBuilder.BuildStandardButton(
                "AccountClosingButton", MultilanguangeController.GetText("ACCEPT_BUTTON"), MainPanel.Width);

            this.MainPanel.Controls.Add(backButton);

            backButton.Click += new System.EventHandler(AccountClosingButton_Click);
        }
        private void AccountClosingButton_Click(object sender, EventArgs e)
        {
            AppController.OpenChildForm(new OtherOperationsForm(), _device);
            this.Close();
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
            AppController.OpenChildForm(new OtherOperationsForm(), _device);
            this.Close();
        }
        #endregion
    }
}
