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
        public CounterDevice _device { get; set; }
        public OperationBlockingForm()
        {
            InitializeComponent();
            LoadBackButton();
            LoadOkButton();
            TimeOutController.Reset();
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
        public void LoadStyles()
        {
            this.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.FondoFormulario);

        }

        private void OperationBlockingForm_Load(object sender, EventArgs e)
        {
            _device = (Permaquim.Depositary.UI.Desktop.Components.CounterDevice)this.Tag;

            LoadStyles();

            switch (OperationBlockingReason)
            {
                case OperationblockingReasonEnum.None:
                    break;
                case OperationblockingReasonEnum.NoTurn:
                    InformationLabel.Text = MultilanguangeController.GetText(MultiLanguageEnum.SIN_TURNO);
                    InformationLabel.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.FuenteContraste);
                    InformationLabel.ForeColor = StyleController.GetColor(Enumerations.ColorNameEnum.TextoError);
                    break;

                case OperationblockingReasonEnum.NoBag:
                    InformationLabel.Text = MultilanguangeController.GetText(MultiLanguageEnum.SIN_BOLSA_ACTIVA);
                    InformationLabel.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.FuenteContraste);
                    InformationLabel.ForeColor = StyleController.GetColor(Enumerations.ColorNameEnum.TextoError);
                    break;

                case OperationblockingReasonEnum.PortError:
                    InformationLabel.Text = MultilanguangeController.GetText(MultiLanguageEnum.ERROR_PUERTO);
                    InformationLabel.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.FuenteContraste);
                    InformationLabel.ForeColor = StyleController.GetColor(Enumerations.ColorNameEnum.TextoError);
                    break;

                case OperationblockingReasonEnum.CounterCommunicationError:
                    InformationLabel.Text = MultilanguangeController.GetText(MultiLanguageEnum.ERROR_COMUNICACION_CONTADORA);
                    InformationLabel.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.FuenteContraste);
                    InformationLabel.ForeColor = StyleController.GetColor(Enumerations.ColorNameEnum.TextoError);
                    break;

                case OperationblockingReasonEnum.IoBoardCommunicationError:
                    InformationLabel.Text = MultilanguangeController.GetText(MultiLanguageEnum.ERROR_COMUNICACION_PLACA);
                    InformationLabel.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.FuenteContraste);
                    InformationLabel.ForeColor = StyleController.GetColor(Enumerations.ColorNameEnum.TextoError);
                    break;

                case OperationblockingReasonEnum.ContainerMaxVolumeReached:
                    InformationLabel.Text = MultilanguangeController.GetText(MultiLanguageEnum.LIMITE_CONTENEDOR_ALCANZADO);
                    InformationLabel.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.FuenteContraste);
                    InformationLabel.ForeColor = StyleController.GetColor(Enumerations.ColorNameEnum.TextoError);
                    break;

                case OperationblockingReasonEnum.CurrentContainerIsClosed:
                    InformationLabel.Text = MultilanguangeController.GetText(MultiLanguageEnum.CONTENEDOR_CERRADO);
                    InformationLabel.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.FuenteContraste);
                    InformationLabel.ForeColor = StyleController.GetColor(Enumerations.ColorNameEnum.TextoError);
                    break;

                case OperationblockingReasonEnum.DepositaryDisabled:

                    InformationLabel.Text = MultilanguangeController.GetText(MultiLanguageEnum.CONTENEDOR_CERRADO);
                    InformationLabel.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.FuenteContraste);
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
                "BackButton", MultilanguangeController.GetText(MultiLanguageEnum.VOLVER), MainPanel.Width / 2 -5 );

            this.MainPanel.Controls.Add(backButton);
            backButton.Click += new System.EventHandler(BackButton_Click);
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            FormsController.HideInstance(this);
        }
        #endregion

        #region OK button
        private void LoadOkButton()
        {
            CustomButton backButton = ControlBuilder.BuildStandardButton(
                "OkButton", MultilanguangeController.GetText(
                    MultiLanguageEnum.ELIMINAR_ERRORES), MainPanel.Width / 2 - 5);

            this.MainPanel.Controls.Add(backButton);
            backButton.Click += new System.EventHandler(OkButton_Click);
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            DeviceController.ResetIssues();
            FormsController.HideInstance(this);
        }
        #endregion

        private void InformationLabel_Paint(object sender, PaintEventArgs e)
        {
            //ControlPaint.DrawBorder(e.Graphics, InformationLabel.DisplayRectangle, InformationLabel.ForeColor, ButtonBorderStyle.Solid);
        }
    }
}
