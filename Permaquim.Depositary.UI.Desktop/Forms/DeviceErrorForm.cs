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
using static Permaquim.Depositary.UI.Desktop.Global.Enumerations;

namespace Permaquim.Depositary.UI.Desktop.Forms
{
    public partial class DeviceErrorForm : Form
    {
        private const string D50 = "D50";
        private const string D70 = "D70";
        private const string ABNORMALDEVICE = "AbnormalDevice; ";
        private const string ABNORMALSTORAGE = "AbnormalStorage; ";
        private const string COUNTINGERROR = "CountingError; ";
        private const string JAMMING = "Jamming; ";
        private const string ESCROWBILLPRESENT = "EscrowBillPresent; ";

        string _errorInformation = String.Empty;
        CustomButton _resetButton = null;

        private CounterDevice _device = null;
        private System.Windows.Forms.Timer _pollingTimer = new System.Windows.Forms.Timer();
        public DeviceErrorForm()
        {
            InitializeComponent();
            CenterPanel();

            LoadStyles();
            LoadResetButton();

            TimeOutController.Reset();
            _pollingTimer = new System.Windows.Forms.Timer()
            {
                Interval = DeviceController.GetPollingInterval()
            };
            _pollingTimer.Tick += PollingTimer_Tick;
            _pollingTimer.Enabled = true;
            InformationLabel.Text = String.Empty;
        }
        private void LoadDeviceImage()
        {
            MainPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            MainPictureBox.Image = StyleController.GetDeviceImage();

        }
        private void DeviceErrorForm_Load(object sender, EventArgs e)
        {
            _device = (Permaquim.Depositary.UI.Desktop.Components.CounterDevice)this.Tag;
        }

          private void PollingTimer_Tick(object? sender, EventArgs e)
        {
            VerifyStatus();
        }

        private void VerifyStatus()
        {
            if (_device.StateResultProperty != null)
            {

                _errorInformation = String.Empty;

                if (_device.StateResultProperty.ErrorStateInformation.AbnormalDevice)
                    _errorInformation += ABNORMALDEVICE;
                if (_device.StateResultProperty.ErrorStateInformation.AbnormalStorage)
                    _errorInformation += ABNORMALSTORAGE;
                if (_device.StateResultProperty.ErrorStateInformation.CountingError)
                    _errorInformation += COUNTINGERROR;
                if (_device.StateResultProperty.ErrorStateInformation.Jamming)
                    _errorInformation += JAMMING;
                if (_device.StateResultProperty.DeviceStateInformation.EscrowBillPresent)
                    _errorInformation += ESCROWBILLPRESENT;

                InformationLabel.Text = _errorInformation;

                if (!_device.StateResultProperty.DeviceStateInformation.EscrowBillPresent
                    && _device.StateResultProperty.DoorStateInformation.Escrow)
                {
                    _device.CloseEscrow();
                    _device.Sleep();
                }
            }
        }

        private void CenterPanel()
        {

            MainPanel.Location = new Point()
            {
                X = this.Width / 2 - MainPanel.Width / 2,
                Y = MainPanel.Location.Y
            };
            //

            MainPictureBox.Location = new Point()
            {
                X = this.Width / 2 - MainPictureBox.Width / 2,
                Y = MainPictureBox.Location.Y
            };
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
            InformationLabel.ForeColor = StyleController.GetColor(Enumerations.ColorNameEnum.TextoError);
            InformationLabel.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.Breadcrumb);
            LoadDeviceImage();

        }
        #region Back button
        private void LoadResetButton()
        {
             _resetButton = ControlBuilder.BuildStandardButton(
                "ResetButton", MultilanguangeController.GetText(MultiLanguageEnum.RESET), MainPanel.Width);

            this.MainPanel.Controls.Add(_resetButton);
            _resetButton.Click += new System.EventHandler(ResetButton_Click);
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            TimeOutController.Reset();
            _resetButton.Enabled = false;
            if (ParameterController.UsesShutter)
                _device.Open();

            if (_device.StateResultProperty.ErrorStateInformation.AbnormalDevice)   // TODO: Unificar

                switch ((DatabaseController.CurrentDepositary.
                      ListOf_DepositarioContadora_DepositarioId.FirstOrDefault().TipoContadoraId.Nombre))
                {
                    case D50:
                        _device.UnJam();
                        break;
                    case D70:
                        _device.ResetFF0x();
                        break;
                    default:
                        break;
                }
           
            if (_device.StateResultProperty.ErrorStateInformation.AbnormalStorage)
                switch ((DatabaseController.CurrentDepositary.
                         ListOf_DepositarioContadora_DepositarioId.FirstOrDefault().TipoContadoraId.Nombre))
                {
                    case D50:
                        _device.UnJam();
                        break;
                    case D70:
                        _device.ResetFF0x();
                        break;
                    default:
                        break;
                }
            if (_device.StateResultProperty.ErrorStateInformation.CountingError)
                return;
            if (_device.StateResultProperty.ErrorStateInformation.Jamming)
                switch ((DatabaseController.CurrentDepositary.
                         ListOf_DepositarioContadora_DepositarioId.FirstOrDefault().TipoContadoraId.Nombre))
                {
                    case D50:
                        _device.UnJam();
                        break;
                    case D70:
                        _device.ResetFF0x();
                        break;
                    default:
                        break;
                }
            this.DialogResult = DialogResult.OK;

         }
        #endregion

        private void DeviceErrorForm_VisibleChanged(object sender, EventArgs e)
        {
            _resetButton.Enabled = this.Visible;
            _pollingTimer.Enabled = this.Visible;
        }
    }
}
