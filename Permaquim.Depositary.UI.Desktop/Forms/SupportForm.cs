﻿using Permaquim.Depositary.UI.Desktop.Components;
using Permaquim.Depositary.UI.Desktop.Controllers;
using Permaquim.Depositary.UI.Desktop.Global;
using static Permaquim.Depositary.UI.Desktop.Global.Enumerations;

namespace Permaquim.Depositary.UI.Desktop
{
    public partial class SupportForm : Form
    {
        public CounterDevice _device { get; set; }

        private const string COMANDO_SOPORTE = "Comando ejecutado por soporte";
        private const string COMANDO_EJECUTADO = "Se ejecutó el comando : ";
        private const string INGRESO_SOPORTE = "Ingreso a pantalla de soporte";

        /// <summary>
        /// Timer para la consulta del estado del dispositivo
        /// </summary>
        private System.Windows.Forms.Timer _pollingTimer = new System.Windows.Forms.Timer();
        public SupportForm()
        {
            InitializeComponent();
            LoadStyles();
            CenterPanel();
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
        }

        private void SupportForm_Load(object sender, EventArgs e)
        {
            _device = (Permaquim.Depositary.UI.Desktop.Components.CounterDevice)this.Tag;
            _pollingTimer = new System.Windows.Forms.Timer()
            {
                Interval = DeviceController.GetPollingInterval(),
                Enabled = true
            };
            _pollingTimer.Tick += PollTimer_Tick;
            _device.CounterDeviceDataReceived += CounterDeviceDataReceived;
            _device.IOboardDeviceDataReceived += IOboardDeviceDataReceived;

            TimeOutController.Reset();
        }

        private void PollTimer_Tick(object? sender, EventArgs e)
        {

            if (TimeOutController.IsTimeOut())
            {
                _pollingTimer.Enabled = false;
                DatabaseController.LogOff(true);
                FormsController.LogOff();
            }
            else
            {
                _device.Sense();
                if (_device.StateResultProperty != null)
                {
                    SetCounterPropertyGridValue();
                }

                IoBoardStatusPropertyGrid.SelectedObject = _device.Status();
                SetCounterPropertyGridValue();
            }
        }
        private void ExecuteIoBoardComandButton_Click(object sender, EventArgs e)
        {
            TimeOutController.Reset();

            switch (IoboardCommandComboBox.SelectedItem.ToString().Trim())
            {
                case "Open":
                    _device.OpenShutter();
                    break;
                case "Close":
                    _device.CloseShutter();
                    break;
                case "UnLock":
                    _device.Unlock();
                    break;
                case "Status":
                    _device.Status();
                    break;
                case "Empty":
                    //_device.Empty();
                    break;
                case "Approve":
                    _device.ApproveBag();
                    break;
                default:
                    break;
            }
        }

        private void SetCounterPropertyGridValue()
        {
            if (CounterComboBox.SelectedItem == null)
                return;

            switch (CounterComboBox.SelectedItem.ToString().Trim())
            {
                case "StatusInformation":
                    CounterStatusPropertyGrid.SelectedObject = _device.StateResultProperty.StatusInformation;
                    break;
                case "EndInformation":
                    CounterStatusPropertyGrid.SelectedObject = _device.StateResultProperty.EndInformation;
                    break;
                case "DeviceStateInformation":
                    CounterStatusPropertyGrid.SelectedObject = _device.StateResultProperty.DeviceStateInformation;
                    break;
                case "ErrorStateInformation":
                    CounterStatusPropertyGrid.SelectedObject = _device.StateResultProperty.ErrorStateInformation;
                    break;
                case "ModeStateInformation":
                    CounterStatusPropertyGrid.SelectedObject = _device.StateResultProperty.ModeStateInformation;
                    break;
                case "DoorStateInformation":
                    CounterStatusPropertyGrid.SelectedObject = _device.StateResultProperty.DoorStateInformation;
                    break;
                default:
                    break;
            }
        }

        private void ExecuteCounterComandButton_Click(object sender, EventArgs e)
        {
            TimeOutController.Reset();

            switch (CounterCommandComboBox.SelectedItem.ToString().Trim())
            {
                case "OpenEscrow":
                    _device.OpenEscrow();
                    break;
                case "CloseEscrow":
                    _device.CloseEscrow();
                    break;
                case "StopCounting":
                    _device.StopCounting();
                    break;
                case "StoringStart":
                    _device.StoringStart();
                    break;
                case "BatchDataTransmission":
                    _device.BatchDataTransmission();
                    break;
                case "Sense":
                    _device.Sense();
                    break;
                case "CountingDataRequest":
                    _device.CountingDataRequest();
                    break;
                case "DepositMode":
                    _device.DepositMode();
                    break;
                case "ManualDepositMode":
                    _device.ManualDepositMode();
                    break;
                case "NormalErrorRecoveryMode":
                    _device.NormalErrorRecoveryMode();
                    break;
                case "StoringErrorRecoveryMode":
                    _device.StoringErrorRecoveryMode();
                    break;
                case "CollectMode":
                    _device.CollectMode();
                    break;
                case "Reset":
                    _device.DeviceReset();
                    break;
                case "RemoteCancel":
                    _device.RemoteCancel();
                    break;
                case "DenominationDataRequest":
                    _device.DenominationDataRequest();
                    break;
                case "UnJam":
                    _device.UnJam();
                    break;
                case "SwitchToFirstCurrency":
                    _device.SwitchToCurrency(1);
                    break;
                case "SwitchToSecondCurrency":
                    _device.SwitchToCurrency(2);
                    break;
                case "SwitchToThirdCurrency":
                    _device.SwitchToCurrency(3);
                    break;
                case "SwitchToFourthCurrency":
                    _device.SwitchToCurrency(4);
                    break;
                case "SwitchToFifthCurrency":
                    _device.SwitchToCurrency(5);
                    break;
                case "SwitchToSixthCurrency":
                    _device.SwitchToCurrency(6);
                    break;
                case "SwitchToSeventhCurrency":
                    _device.SwitchToCurrency(7);
                    break;
                default:
                    break;
            }

            AuditController.Log(LogTypeEnum.Information
             , COMANDO_SOPORTE
             , COMANDO_EJECUTADO + CounterCommandComboBox.SelectedItem.ToString().Trim()
             );
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            _pollingTimer.Enabled = false;
            FormsController.OpenChildForm(this,new OperationForm(),
            (Permaquim.Depositary.UI.Desktop.Components.CounterDevice)this.Tag);
        }

        private void CounterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void IOboardDeviceDataReceived(object sender, DeviceDataReceivedEventArgs args)
        {
            try
            {
                this.Invoke((MethodInvoker)delegate ()
                {
                    if (ModeCheckBox.Checked)
                        IoBoardResponseTextBox.Text = IoBoardResponseTextBox.Text + Environment.NewLine + args.Message;
                    else
                        IoBoardResponseTextBox.Text = args.Message;
                });
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CounterDeviceDataReceived(object sender, DeviceDataReceivedEventArgs args)
        {
            try
            {
                this.Invoke((MethodInvoker)delegate ()
                {
                    if (ModeCheckBox.Checked)
                        CounterResponseTextBox.Text = CounterResponseTextBox.Text + Environment.NewLine + args.Message;
                    else
                    {
                        if (args.Message.Length > 0)
                            CounterResponseTextBox.Text = args.Message;
                    }

                });
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MainPanel_VisibleChanged(object sender, EventArgs e)
        {
            if(this.Visible)
                AuditController.Log(LogTypeEnum.Navigation, INGRESO_SOPORTE, INGRESO_SOPORTE);
        }

        private void SupportForm_VisibleChanged(object sender, EventArgs e)
        {
            if (!this.Visible)
                InitializeLocals();
            FormsController.SetInformationMessage(InformationTypeEnum.None, string.Empty);
        }
        private void InitializeLocals()
        {
            // inicializar variables locales.
            TimeOutController.Reset();
        }

        private void MainPanel_MouseClick(object sender, MouseEventArgs e)
        {
            TimeOutController.Reset();
        }

        private void CounterStatusPropertyGrid_MouseClick(object sender, MouseEventArgs e)
        {
            TimeOutController.Reset();
        }

        private void IoBoardStatusPropertyGrid_MouseClick(object sender, MouseEventArgs e)
        {
            TimeOutController.Reset();
        }

        private void CounterResponseTextBox_Click(object sender, EventArgs e)
        {
            TimeOutController.Reset();
        }

        private void IoBoardResponseTextBox_Click(object sender, EventArgs e)
        {
            TimeOutController.Reset();
        }

        private void EscrowButton_Click(object sender, EventArgs e)
        {
            if (_device.StateResultProperty != null)
            {
                if (!_device.StateResultProperty.DoorStateInformation.Escrow)
                    _device.OpenEscrow();
                else
                    _device.CloseEscrow();
            }
        }
    }
}

