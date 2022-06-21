using Permaquim.Depositary.UI.Desktop.Components;
using Permaquim.Depositary.UI.Desktop.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Permaquim.Depositary.UI.Desktop
{
    public partial class OtherOperationsForm : Form
    {
        Device _device = null;
        public OtherOperationsForm()
        {
            InitializeComponent();
        }

        private void OtherOperationsForm_Load(object sender, EventArgs e)
        {
            _device = (Permaquim.Depositary.UI.Desktop.Components.Device)this.Tag;
            LoadStyles();
            CenterPanel();
            LoadTurnButton();
            LoadAccountClosingButton();
            LoadOperationsButton();
            LoadSupportButton();
            LoadBackButton();

        }
        private void LoadStyles()
        {
            this.BackColor = StyleController.GetColor(StyleController.ColorNameEnum.Contenido);
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
                "BackButton", MultilanguangeController.GetText("Salir"), MainPanel.Width);

            this.MainPanel.Controls.Add(backButton);
            backButton.Click += new System.EventHandler(BackButton_Click);
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            AppController.OpenChildForm(new OperationForm(),
              (Permaquim.Depositary.UI.Desktop.Components.Device)this.Tag);
        }
        #endregion

        #region Turn

        private void LoadTurnButton()
        {
            CustomButton TurnButton = ControlBuilder.BuildStandardbutton(
                "TurnButton", MultilanguangeController.GetText("CAMBIO_TURNO"), MainPanel.Width);

            this.MainPanel.Controls.Add(TurnButton);
            TurnButton.Click += new System.EventHandler(TurnButton_Click);
        }

        private void TurnButton_Click(object sender, EventArgs e)
        {
            //    AppController.OpenChildForm(new TurnForm(),
            //      (Permaquim.Depositary.UI.Desktop.Components.Device)this.Tag);
        }
        #endregion

        #region AccountClosing

        private void LoadAccountClosingButton()
        {
            CustomButton AccountClosingButton = ControlBuilder.BuildStandardbutton(
                "AccountClosingButton", MultilanguangeController.GetText("CIERRE_CONTABLE"), MainPanel.Width);

            this.MainPanel.Controls.Add(AccountClosingButton);
            AccountClosingButton.Click += new System.EventHandler(AccountClosingButton_Click);
        }

        private void AccountClosingButton_Click(object sender, EventArgs e)
        {
            //    AppController.OpenChildForm(new TurnForm(),
            //      (Permaquim.Depositary.UI.Desktop.Components.Device)this.Tag);
        }
        #endregion


        #region Operations

        private void LoadOperationsButton()
        {
            CustomButton OperationsButton = ControlBuilder.BuildStandardbutton(
                "OperationsButton", MultilanguangeController.GetText("HISTORICO_OPERACIONES"), MainPanel.Width);

            this.MainPanel.Controls.Add(OperationsButton);
            OperationsButton.Click += new System.EventHandler(OperationsButton_Click);
        }

        private void OperationsButton_Click(object sender, EventArgs e)
        {
            AppController.OpenChildForm(new OperationHistoryForm(),
              (Permaquim.Depositary.UI.Desktop.Components.Device)this.Tag);
        }
        #endregion

        #region Support

        private void LoadSupportButton()
        {
            CustomButton supportButton = ControlBuilder.BuildAlternateButton(
                "SupportButton", MultilanguangeController.GetText("SOPORTE"), MainPanel.Width);

            this.MainPanel.Controls.Add(supportButton);
            supportButton.Click += new System.EventHandler(SupportButton_Click);
        }

        private void SupportButton_Click(object sender, EventArgs e)
        {
            AppController.OpenChildForm(new SupportForm(),
              (Permaquim.Depositary.UI.Desktop.Components.Device)this.Tag);
        }
        #endregion

    }
}
