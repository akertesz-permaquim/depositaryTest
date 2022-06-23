using Permaquim.Depositary.UI.Desktop.Builders;
using Permaquim.Depositary.UI.Desktop.Components;
using Permaquim.Depositary.UI.Desktop.Controllers;
using Permaquim.Depositary.UI.Desktop.Global;
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
            CenterPanel();
            LoadStyles();
            LoadTurnButton();
            LoadDailyClosingButton();
            LoadOperationsButton();
            LoadSupportButton();
            LoadBackButton();
        }
        private void OtherOperationsForm_Load(object sender, EventArgs e)
        {
            _device = (Permaquim.Depositary.UI.Desktop.Components.Device)this.Tag;
        }
        private void LoadStyles()
        {
            this.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.Contenido);
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
                "BackButton", MultilanguageConstants.SALIR, MainPanel.Width);

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
            CustomButton TurnButton = ControlBuilder.BuildStandardButton(
                "TurnButton", MultilanguangeController.GetText("CAMBIO_TURNO"), MainPanel.Width);

            this.MainPanel.Controls.Add(TurnButton);
            TurnButton.Click += new System.EventHandler(TurnButton_Click);
        }

        private void TurnButton_Click(object sender, EventArgs e)
        {
            AppController.OpenChildForm(new TurnChangeForm(),
              (Permaquim.Depositary.UI.Desktop.Components.Device)this.Tag);
        }
        #endregion

        #region DailyClosing

        private void LoadDailyClosingButton()
        {
            CustomButton AccountClosingButton = ControlBuilder.BuildStandardButton(
                "DailyClosingButton", MultilanguangeController.GetText("CIERRE_DIARIO"), MainPanel.Width);

            this.MainPanel.Controls.Add(AccountClosingButton);
            AccountClosingButton.Click += new System.EventHandler(DailyClosingButton_Click);
        }

        private void DailyClosingButton_Click(object sender, EventArgs e)
        {
            AppController.OpenChildForm(new DailyClosingForm(),
              (Permaquim.Depositary.UI.Desktop.Components.Device)this.Tag);
        }
        #endregion


        #region Operations

        private void LoadOperationsButton()
        {
            CustomButton OperationsButton = ControlBuilder.BuildStandardButton(
                "OperationsButton", MultilanguangeController.GetText("HISTORICO_OPERACIONES"), MainPanel.Width);

            this.MainPanel.Controls.Add(OperationsButton);
            OperationsButton.Click += new System.EventHandler(OperationsButton_Click);
        }

        private void OperationsButton_Click(object sender, EventArgs e)
        {
            AppController.OpenChildForm(new OperationsHistoryform(),
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
