﻿using Permaquim.Depositary.UI.Desktop.Builders;
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
            TimeOutController.Reset();
        }
        public void LoadStyles()
        {
            this.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.FondoFormulario);

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
                    InformationLabel.Text = MultilanguangeController.GetText(MultiLanguageEnum.SIN_TURNO);
                    InformationLabel.ForeColor = StyleController.GetColor(Enumerations.ColorNameEnum.TextoError);
                    break;
                case OperationblockingReasonEnum.NoBag:
                    InformationLabel.Text = MultilanguangeController.GetText(MultiLanguageEnum.SIN_BOLSA_ACTIVA);
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
                "BackButton", MultilanguangeController.GetText(MultiLanguageEnum.VOLVER), MainPanel.Width);

            this.MainPanel.Controls.Add(backButton);
            backButton.Click += new System.EventHandler(BackButton_Click);
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            FormsController.HideInstance(this);
        }
        #endregion
    }
}