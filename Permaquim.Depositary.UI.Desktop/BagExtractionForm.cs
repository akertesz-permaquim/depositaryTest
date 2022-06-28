﻿using Permaquim.Depositary.UI.Desktop.Builders;
using Permaquim.Depositary.UI.Desktop.Components;
using Permaquim.Depositary.UI.Desktop.Controllers;
using Permaquim.Depositary.UI.Desktop.Global;
using static Permaquim.Depositary.UI.Desktop.Global.Enumerations;

namespace Permaquim.Depositary.UI.Desktop
{
    public partial class BagExtractionForm : Form
    {
        public Device _device { get; set; }

 

        /// <summary>
        /// Timer para la consulta del estado del dispositivo
        /// </summary>
        private System.Windows.Forms.Timer _pollingTimer = new System.Windows.Forms.Timer();

        private BagExtractionProcessEnum _bagExtractionProcess = BagExtractionProcessEnum.None;
               CustomButton _gateButton = new CustomButton();
        CustomButton _backButton = new CustomButton();
        CustomButton _confirmButton = new CustomButton();
        CustomTextBox _containerTextBox = new CustomTextBox();

        public BagExtractionForm()
        {
            InitializeComponent();
            TimeOutController.Reset();
        }

        private void BagExtractionForm_Load(object sender, EventArgs e)
        {
             _device = (Permaquim.Depositary.UI.Desktop.Components.Device)this.Tag;

            _pollingTimer = new System.Windows.Forms.Timer()
            {
                Interval = DeviceController.GetPollingInterval(),
                Enabled = true
            };
            _pollingTimer.Tick += PollTimer_Tick;
            CenterPanel();

            LoadStyles();
            LoadGateButton();
            LoadConfirmButton();
            LoadBackButton();
            LoadContainerTextbox();
        }
        private void CenterPanel()
        {

            MainPanel.Location = new Point()
            {
                X = this.Width / 2 - MainPanel.Width / 2,
                Y = this.Height / 2 - MainPanel.Height / 2
            };

            NumberPanel.Location = new Point()
            {
                X = this.Width / 2 - NumberPanel.Width / 2,
                Y = NumberPanel.Location.Y
            };

        }

        private void PollTimer_Tick(object? sender, EventArgs e)
        {
            if (TimeOutController.IsTimeOut())
            {
                _pollingTimer.Enabled = false;
                DatabaseController.LogOff(true);
                AppController.HideInstance(this);
            }

            if (_device != null && _device.IoBoardConnected)
            {
                // Muestra el estado del hardware
                ShowHardwareMonitorData();
                // Procesa los estados 
                ProcessDeviceStatus();
                ShowInformation();
            }
        }
        private void ShowHardwareMonitorData()
        {
            BagStatusLabel.Text = "BagStatus: " + Enum.GetName(typeof(IoBoardStatus.BAG_STATE), 
                _device.IoBoardStatusProperty.BagState);
            ShutterStatusLabel.Text = "Shutter Status: " + Enum.GetName(typeof(IoBoardStatus.SHUTTER_STATE), 
                _device.IoBoardStatusProperty.ShutterState);
            BagAproveStatelabel.Text = "Bag Aprove Status: " + Enum.GetName(typeof(IoBoardStatus.BAG_APROVE_STATE), 
                _device.IoBoardStatusProperty.BagAproveState);
            LockStateLabel.Text = "Lock Status: " + Enum.GetName(typeof(IoBoardStatus.LOCK_STATE), 
                _device.IoBoardStatusProperty.LockState);
            GatelStatusLabel.Text = "Gate Status: " + Enum.GetName(typeof(IoBoardStatus.GATE_STATE), 
                _device.IoBoardStatusProperty.GateState);
        }
        private void ProcessDeviceStatus()
        {
            if ((_device.IoBoardStatusProperty.GateState == IoBoardStatus.GATE_STATE.CLOSED
                || _device.IoBoardStatusProperty.GateState == IoBoardStatus.GATE_STATE.STATE_0)
                && _bagExtractionProcess == BagExtractionProcessEnum.ProcessFinished)
            {
                _pollingTimer.Enabled = false;
                AppController.OpenChildForm(this,new OperationForm(), _device);
            }
            

            if (_device.IoBoardStatusProperty.LockState == IoBoardStatus.LOCK_STATE.UNLOCKED)
                _bagExtractionProcess = BagExtractionProcessEnum.GateUnlocked;

            // si se detecta la apertura de la puerta, y el contenedor se encuentra colocado,
            // se asume que se inicia el proceso.
            if (_device.IoBoardStatusProperty.GateState == IoBoardStatus.GATE_STATE.OPEN
                && _device.IoBoardStatusProperty.BagState == IoBoardStatus.BAG_STATE.BAG_STATE_INPLACE 
                && ( _bagExtractionProcess == BagExtractionProcessEnum.None
                || _bagExtractionProcess == BagExtractionProcessEnum.GateWaitingToRelease))
                    _bagExtractionProcess = BagExtractionProcessEnum.GateReleased;

            // Este dato lo informa cuando está esperando para abrir la puerta
            if (_device.IoBoardStatusProperty.GateState == IoBoardStatus.GATE_STATE.STATE_0 
                && _bagExtractionProcess != BagExtractionProcessEnum.ProcessFinished)
                _bagExtractionProcess = BagExtractionProcessEnum.GateWaitingToRelease;

            if (_device.IoBoardStatusProperty.GateState == IoBoardStatus.GATE_STATE.STATE_1
                || _device.IoBoardStatusProperty.GateState == IoBoardStatus.GATE_STATE.STATE_1
                || _device.IoBoardStatusProperty.GateState == IoBoardStatus.GATE_STATE.STATE_2
                || _device.IoBoardStatusProperty.GateState == IoBoardStatus.GATE_STATE.STATE_4
                || _device.IoBoardStatusProperty.GateState == IoBoardStatus.GATE_STATE.STATE_5
                || _device.IoBoardStatusProperty.GateState == IoBoardStatus.GATE_STATE.STATE_6
                || _device.IoBoardStatusProperty.GateState == IoBoardStatus.GATE_STATE.STATE_8
                || _device.IoBoardStatusProperty.GateState == IoBoardStatus.GATE_STATE.STATE_9
                || _device.IoBoardStatusProperty.GateState == IoBoardStatus.GATE_STATE.STATE_10
                )
                System.Diagnostics.Debug.Print("");

            if (_device.IoBoardStatusProperty.BagState == IoBoardStatus.BAG_STATE.BAG_STATE_REMOVED)
                _bagExtractionProcess = BagExtractionProcessEnum.BagExtracted;

            if (_device.IoBoardStatusProperty.BagState == IoBoardStatus.BAG_STATE.BAG_STATE_PUTTING_START)
                _bagExtractionProcess = BagExtractionProcessEnum.BagPuttingStart;

            if (_device.IoBoardStatusProperty.BagState == IoBoardStatus.BAG_STATE.BAG_STATE_PUTTING_1
                || _device.IoBoardStatusProperty.BagState == IoBoardStatus.BAG_STATE.BAG_STATE_PUTTING_2
                || _device.IoBoardStatusProperty.BagState == IoBoardStatus.BAG_STATE.BAG_STATE_PUTTING_3
                || _device.IoBoardStatusProperty.BagState == IoBoardStatus.BAG_STATE.BAG_STATE_PUTTING_4
                || _device.IoBoardStatusProperty.BagState == IoBoardStatus.BAG_STATE.BAG_STATE_PUTTING_5
                || _device.IoBoardStatusProperty.BagState == IoBoardStatus.BAG_STATE.BAG_STATE_PUTTING_6
                )
                _bagExtractionProcess = BagExtractionProcessEnum.BagPuttingStart;

            if (_device.IoBoardStatusProperty.BagState == IoBoardStatus.BAG_STATE.BAG_STATE_INPLACE 
                && (_bagExtractionProcess == BagExtractionProcessEnum.BagExtracted 
                || _bagExtractionProcess == BagExtractionProcessEnum.BagExtracting)
                || _bagExtractionProcess == BagExtractionProcessEnum.BagPuttingStart)
            {
                _bagExtractionProcess = BagExtractionProcessEnum.IdentifierPending;
            }
            // El sensor de la puerta está bloqueado durante la extracción y reinserción del 
            // contenedor, por lo cual ha que evaluar además el sensor respectivo
            if (_device.IoBoardStatusProperty.BagState == IoBoardStatus.BAG_STATE.BAG_STATE_TAKING_START
                || _device.IoBoardStatusProperty.BagState == IoBoardStatus.BAG_STATE.BAG_STATE_TAKING_STEP1
                || _device.IoBoardStatusProperty.BagState == IoBoardStatus.BAG_STATE.BAG_STATE_TAKING_STEP2)
                _bagExtractionProcess = BagExtractionProcessEnum.BagExtracting;


            // Es un  estado intermedio ? problemas con los sensores?
            //if (_device.IoBoardStatusProperty.BagState == IoBoardStatus.BAG_STATE.BAG_STATE_ERROR)
            //    _bagExtractionProcess = BagExtractionProcessEnum.BagError;

            VerifyButtonsVisibility();
            VerifyContainerCodeVisibility();

        }
        private void ShowInformation()
        {

            switch (_bagExtractionProcess)
            {

                case BagExtractionProcessEnum.BagError:
                    InformationLabel.Text = MultilanguangeController.GetText(MultilanguageConstants.ERROR_POSICION_BOLSA);
                    InformationLabel.ForeColor = StyleController.GetColor(Enumerations.ColorNameEnum.TextoError);
                    break;
                case BagExtractionProcessEnum.None:
                    InformationLabel.Text = MultilanguangeController.GetText(MultilanguageConstants.PRESIONAR_BOTON_INICIAR);
                    InformationLabel.ForeColor = StyleController.GetColor(Enumerations.ColorNameEnum.TextoInformacion);
                    break;
                case BagExtractionProcessEnum.GateWaitingToRelease:
                    InformationLabel.Text = MultilanguangeController.GetText(MultilanguageConstants.ESPERANDO_APERTURA_PUERTA);
                    InformationLabel.ForeColor = StyleController.GetColor(Enumerations.ColorNameEnum.TextoInformacion);
                    break;
                case BagExtractionProcessEnum.GateUnlocked:
                    InformationLabel.Text = MultilanguangeController.GetText(MultilanguageConstants.PUERTA_LIBERADA);
                    InformationLabel.ForeColor = StyleController.GetColor(Enumerations.ColorNameEnum.TextoInformacion);
                    break;
                case BagExtractionProcessEnum.GateReleased:
                    InformationLabel.Text = MultilanguangeController.GetText(MultilanguageConstants.PUEDE_RETIRAR_BOLSA) + DatabaseController.CurrentContainer.Nombre;
                    InformationLabel.ForeColor = StyleController.GetColor(Enumerations.ColorNameEnum.TextoInformacion);
                    break;
                case BagExtractionProcessEnum.BagExtracting:
                    InformationLabel.Text = MultilanguangeController.GetText(MultilanguageConstants.EXTRAYENDO_BOLSA).Replace("@@BOLSA@@", DatabaseController.CurrentContainer.Nombre);
                    InformationLabel.ForeColor = StyleController.GetColor(Enumerations.ColorNameEnum.TextoInformacion);
                    break;
                case BagExtractionProcessEnum.BagExtracted:
                    InformationLabel.Text = MultilanguangeController.GetText(MultilanguageConstants.BOLSA_EXTRAIDA);
                    InformationLabel.ForeColor = StyleController.GetColor(Enumerations.ColorNameEnum.TextoInformacion);
                    break;
                case BagExtractionProcessEnum.BagPuttingStart:
                    InformationLabel.Text = MultilanguangeController.GetText(MultilanguageConstants.INGRESANDO_BOLSA);
                    InformationLabel.ForeColor = StyleController.GetColor(Enumerations.ColorNameEnum.TextoInformacion);
                    break;
                case BagExtractionProcessEnum.ProcessFinished:
                    InformationLabel.Text = MultilanguangeController.GetText(MultilanguageConstants.PROCESO_BOLSA_FINALIZADO);
                    InformationLabel.ForeColor = StyleController.GetColor(Enumerations.ColorNameEnum.TextoInformacion);
                    break;
                case BagExtractionProcessEnum.IdentifierPending:
                    InformationLabel.Text = MultilanguangeController.GetText(MultilanguageConstants.INDICAR_CODIGO_BOLSA);
                    InformationLabel.ForeColor = StyleController.GetColor(Enumerations.ColorNameEnum.TextoInformacion);
                    break;
                default:
                    break;
            }
        }
        private void VerifyContainerCodeVisibility()
        {
            _containerTextBox.Visible = _bagExtractionProcess == BagExtractionProcessEnum.IdentifierPending;
            NumberPanel.Visible = _containerTextBox.Visible;
        }
        private void VerifyButtonsVisibility()
        {
  
            _gateButton.Visible = _bagExtractionProcess == BagExtractionProcessEnum.None;
            _backButton.Visible = _bagExtractionProcess == BagExtractionProcessEnum.None 
                || _bagExtractionProcess == BagExtractionProcessEnum.BagError;
            _confirmButton.Visible = _bagExtractionProcess == BagExtractionProcessEnum.IdentifierPending;

        }
        private void LoadGateButton()
        {
            _gateButton = ControlBuilder.BuildStandardButton(
            "GateButton", MultilanguangeController.GetText("ABRIR_PUERTA"), MainPanel.Width);

            _gateButton.Visible = false;


            this.MainPanel.Controls.Add(_gateButton);


            _gateButton.Click += new System.EventHandler(GateButton_Click);
        }
        private void LoadConfirmButton()
        {

            _confirmButton = ControlBuilder.BuildStandardButton(
            "GateButton", MultilanguangeController.GetText("ACCEPT_BUTTON"), MainPanel.Width);

            _confirmButton.Visible = false;

            this.MainPanel.Controls.Add(_confirmButton);


            _confirmButton.Click += new System.EventHandler(ConfirmButton_Click);
        }

        private void LoadBackButton()
        {

             _backButton = ControlBuilder.BuildExitButton(
            "BackButton", MultilanguageConstants.SALIR, MainPanel.Width);

            this.MainPanel.Controls.Add(_backButton);

            _backButton.Click += new System.EventHandler(BackButton_Click);
        }
        private void GateButton_Click(object sender, EventArgs e)
        {
            _device.Unlock();
        }

        private void LoadContainerTextbox()
        {
           _containerTextBox =  ControlBuilder.BuildStandardTextBox("ContainerTextbox",
                MultilanguangeController.GetText("INGRESE_CODIGO_CONTENEDOR"),MainPanel.Width);
            _containerTextBox.Visible = false;

            MainPanel.Controls.Add(_containerTextBox);
        }
        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            DatabaseController.UpdateandCreateContainer(_containerTextBox.Texts.Trim());
            _bagExtractionProcess = BagExtractionProcessEnum.ProcessFinished;
        }
        private void BagButton_Click(object sender, EventArgs e)
        {
            _bagExtractionProcess = BagExtractionProcessEnum.BagExtracting;
        }
        private void BackButton_Click(object sender, EventArgs e)
        {
            AppController.OpenChildForm(this,new OperationForm(), _device);
        }
        private void LoadStyles()
        {
            this.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.FondoFormulario);
        }

        private void EventCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            MonitorGroupBox.Visible = EventCheckbox.Checked;
        }

        private void Keys(object sender, EventArgs e)
        {
            _containerTextBox.Focus();
            SendKeys.Send(((CustomButton)sender).Tag.ToString());
        }
    }
}
