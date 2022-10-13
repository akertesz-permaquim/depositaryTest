using Permaquim.Depositary.UI.Desktop.Builders;
using Permaquim.Depositary.UI.Desktop.Components;
using Permaquim.Depositary.UI.Desktop.Controllers;
using Permaquim.Depositary.UI.Desktop.Entities;
using Permaquim.Depositary.UI.Desktop.Forms;
using Permaquim.Depositary.UI.Desktop.Global;
using System.Diagnostics;
using static Permaquim.Depositary.UI.Desktop.Global.Enumerations;

namespace Permaquim.Depositary.UI.Desktop
{
    public partial class BagExtractionForm : Form
    {
        public CounterDevice _device { get; set; }

        private bool _bagAlreadyInserted = false;

        private enum BagSensorBehaviourEnum
        {
            Ninguno,
            Argentina,
            Chile
        }

        /// <summary>
        /// Timer para la consulta del estado del dispositivo
        /// </summary>
        private System.Windows.Forms.Timer _pollingTimer = new System.Windows.Forms.Timer();

        private BagExtractionProcessEnum _bagExtractionProcess = BagExtractionProcessEnum.None;

        private Permaquim.Depositario.Entities.Tables.Operacion.Contenedor _newContainer;

               CustomButton _gateButton = new CustomButton();
        CustomButton _backButton = new CustomButton();
        CustomButton _confirmButton = new CustomButton();
        CustomTextBox _containerTextBox = new CustomTextBox();

        public BagExtractionForm()
        {
            InitializeComponent();
            EventCheckbox.Visible = SecurityController.IsFunctionEnabled(FunctionEnum.VerEventos);

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
        private void BagExtractionForm_Load(object sender, EventArgs e)
        {
             _device = (Permaquim.Depositary.UI.Desktop.Components.CounterDevice)this.Tag;

            _pollingTimer = new System.Windows.Forms.Timer()
            {
                Interval = DeviceController.GetPollingInterval()
            };
            _pollingTimer.Tick += PollTimer_Tick;
            
            _pollingTimer.Enabled = true;

            CenterPanel();

            LoadStyles();
            LoadGateButton();
            LoadContainerTextbox();
            LoadConfirmButton();
            LoadBackButton();
        }
        private void CenterPanel()
        {

            MainPanel.Location = new Point()
            {
                X = this.Width / 2 - MainPanel.Width / 2,
                Y = this.Height / 2 - MainPanel.Height / 2
            };

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
                if (_device != null && _device.IoBoardConnected)
                {
                    // Muestra el estado del hardware
                    ShowHardwareMonitorData();
                    // Procesa los estados 
                    ProcessDeviceStatus();
                    ShowInformation();
                }
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

            if (_bagExtractionProcess == BagExtractionProcessEnum.BagExtracted)
                TimeOutController.Reset();

            if ((_device.IoBoardStatusProperty.GateState == IoBoardStatus.GATE_STATE.CLOSED
                || _device.IoBoardStatusProperty.GateState == IoBoardStatus.GATE_STATE.STATE_0)
                && _bagExtractionProcess == BagExtractionProcessEnum.ProcessFinished)
            {
                _pollingTimer.Enabled = false;
                _bagExtractionProcess = BagExtractionProcessEnum.None;
                PrintTicket();
                FormsController.OpenChildForm(this,new OperationForm(), _device);
            }
 
            if (_device.IoBoardStatusProperty.LockState == IoBoardStatus.LOCK_STATE.UNLOCKED)
                _bagExtractionProcess = BagExtractionProcessEnum.GateUnlocked;

            // si se detecta la apertura de la puerta, y el contenedor se encuentra colocado,
            // se asume que se inicia el proceso.
            if (_device.IoBoardStatusProperty.GateState == IoBoardStatus.GATE_STATE.OPEN
                && _device.IoBoardStatusProperty.BagState == IoBoardStatus.BAG_STATE.BAG_STATE_INPLACE
                && (_bagExtractionProcess == BagExtractionProcessEnum.None
                || _bagExtractionProcess == BagExtractionProcessEnum.GateWaitingToRelease))
            {
                _bagExtractionProcess = BagExtractionProcessEnum.GateReleased;
                TimeOutController.Reset();
            }

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
                || _device.IoBoardStatusProperty.GateState == IoBoardStatus.GATE_STATE.OPEN
                )
    

            if (_device.IoBoardStatusProperty.BagState == IoBoardStatus.BAG_STATE.BAG_STATE_REMOVED)
            {
                _bagExtractionProcess = BagExtractionProcessEnum.BagExtracted;
                    // Debido a que los sensores pueden disparar la extracción más de una vez durante el proceso,
                    // Se marca con este flag el 
                    if (!_bagAlreadyInserted)
                    {
                        TimeOutController.Reset();
                        DatabaseController.CreateContainer();
                        _bagAlreadyInserted = true;
                    }
            }

            if (_device.IoBoardStatusProperty.BagState == IoBoardStatus.BAG_STATE.BAG_STATE_PUTTING_START)
            {
                _bagExtractionProcess = BagExtractionProcessEnum.BagPuttingStart;
                TimeOutController.Reset();
            }

            if (_device.IoBoardStatusProperty.BagState == IoBoardStatus.BAG_STATE.BAG_STATE_PUTTING_1
                || _device.IoBoardStatusProperty.BagState == IoBoardStatus.BAG_STATE.BAG_STATE_PUTTING_2
                || _device.IoBoardStatusProperty.BagState == IoBoardStatus.BAG_STATE.BAG_STATE_PUTTING_3
                || _device.IoBoardStatusProperty.BagState == IoBoardStatus.BAG_STATE.BAG_STATE_PUTTING_4
                || _device.IoBoardStatusProperty.BagState == IoBoardStatus.BAG_STATE.BAG_STATE_PUTTING_5
                || _device.IoBoardStatusProperty.BagState == IoBoardStatus.BAG_STATE.BAG_STATE_PUTTING_6
                )
            {
                _bagExtractionProcess = BagExtractionProcessEnum.BagPuttingStart;
                TimeOutController.Reset();
            }

            if (_device.IoBoardStatusProperty.BagState == IoBoardStatus.BAG_STATE.BAG_STATE_INPLACE 
                && (_bagExtractionProcess == BagExtractionProcessEnum.BagExtracted 
                || _bagExtractionProcess == BagExtractionProcessEnum.BagExtracting)
                || _bagExtractionProcess == BagExtractionProcessEnum.BagPuttingStart)
            {
                _bagExtractionProcess = BagExtractionProcessEnum.IdentifierPending;
                TimeOutController.Reset();
            }
            // El sensor de la puerta está bloqueado durante la extracción y reinserción del 
            // contenedor, por lo cual ha que evaluar además el sensor respectivo
            if (_device.IoBoardStatusProperty.BagState == IoBoardStatus.BAG_STATE.BAG_STATE_TAKING_START
                || _device.IoBoardStatusProperty.BagState == IoBoardStatus.BAG_STATE.BAG_STATE_TAKING_STEP1
                || _device.IoBoardStatusProperty.BagState == IoBoardStatus.BAG_STATE.BAG_STATE_TAKING_STEP2)
            {
                _bagExtractionProcess = BagExtractionProcessEnum.BagExtracting;
                TimeOutController.Reset();
            }


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
                    FormsController.SetInformationMessage(InformationTypeEnum.Error,
                    MultilanguangeController.GetText(MultiLanguageEnum.ERROR_POSICION_BOLSA));
                    break;
                case BagExtractionProcessEnum.None:
                    FormsController.SetInformationMessage(InformationTypeEnum.Information,
                    MultilanguangeController.GetText(MultiLanguageEnum.PRESIONAR_BOTON_INICIAR));
                    break;
                case BagExtractionProcessEnum.GateWaitingToRelease:
                    FormsController.SetInformationMessage(InformationTypeEnum.Information,
                    MultilanguangeController.GetText(MultiLanguageEnum.ESPERANDO_APERTURA_PUERTA));
                    break;
                case BagExtractionProcessEnum.GateUnlocked:
                    FormsController.SetInformationMessage(InformationTypeEnum.Information,
                    MultilanguangeController.GetText(MultiLanguageEnum.PUERTA_LIBERADA));
                    break;
                case BagExtractionProcessEnum.GateReleased:
                    FormsController.SetInformationMessage(InformationTypeEnum.Information,
                    MultilanguangeController.GetText(MultiLanguageEnum.PUEDE_RETIRAR_BOLSA) 
                    + " : " + DatabaseController.CurrentContainer.Nombre);
                    break;
                case BagExtractionProcessEnum.BagExtracting:
                    FormsController.SetInformationMessage(InformationTypeEnum.Information,
                    MultilanguangeController.GetText(MultiLanguageEnum.EXTRAYENDO_BOLSA)
                    .Replace("@@BOLSA@@", " " + DatabaseController.CurrentContainer.Nombre));
                    break;
                case BagExtractionProcessEnum.BagExtracted:
                    FormsController.SetInformationMessage(InformationTypeEnum.Information,
                    MultilanguangeController.GetText(MultiLanguageEnum.BOLSA_EXTRAIDA));
                    break;
                case BagExtractionProcessEnum.BagPuttingStart:
                    FormsController.SetInformationMessage(InformationTypeEnum.Information,
                    MultilanguangeController.GetText(MultiLanguageEnum.INGRESANDO_BOLSA));
                    break;
                case BagExtractionProcessEnum.ProcessFinished:
                    FormsController.SetInformationMessage(InformationTypeEnum.Information,
                    MultilanguangeController.GetText(MultiLanguageEnum.PROCESO_BOLSA_FINALIZADO));
                    break;
                case BagExtractionProcessEnum.IdentifierPending:
                    FormsController.SetInformationMessage(InformationTypeEnum.Information,
                   MultilanguangeController.GetText(MultiLanguageEnum.INDICAR_CODIGO_BOLSA));
                    break;
                default:
                    break;
            }
        }
        private void VerifyContainerCodeVisibility()
        {
            if(ParameterController.BagSensorBehaviour == (int)BagSensorBehaviourEnum.Argentina)
                _containerTextBox.Visible = _bagExtractionProcess == BagExtractionProcessEnum.IdentifierPending;
            if (ParameterController.BagSensorBehaviour == (int)BagSensorBehaviourEnum.Chile)
                _containerTextBox.Visible = _bagExtractionProcess == BagExtractionProcessEnum.BagExtracted;
        }
        private void VerifyButtonsVisibility()
        {
  
            _gateButton.Visible = _bagExtractionProcess == BagExtractionProcessEnum.None;
            _backButton.Visible = _bagExtractionProcess == BagExtractionProcessEnum.None 
                || _bagExtractionProcess == BagExtractionProcessEnum.BagError
                || _device.IoBoardStatusProperty.BagState == IoBoardStatus.BAG_STATE.BAG_STATE_ERROR;

            if (ParameterController.BagSensorBehaviour == (int)BagSensorBehaviourEnum.Argentina)
            {
                _confirmButton.Visible = _bagExtractionProcess == BagExtractionProcessEnum.IdentifierPending
                 && ParameterController.RequiresContainerIdentifier;
            }
            if (ParameterController.BagSensorBehaviour == (int)BagSensorBehaviourEnum.Chile)
            {
                _confirmButton.Visible = _bagExtractionProcess == BagExtractionProcessEnum.BagExtracted
                && ParameterController.RequiresContainerIdentifier;
            }

        }
        private void LoadGateButton()
        {
            _gateButton = ControlBuilder.BuildStandardButton(
            "GateButton", MultilanguangeController.GetText(MultiLanguageEnum.ABRIR_PUERTA), MainPanel.Width);

            _gateButton.Visible = false;


            this.MainPanel.Controls.Add(_gateButton);


            _gateButton.Click += new System.EventHandler(GateButton_Click);
        }
        private void LoadConfirmButton()
        {

            _confirmButton = ControlBuilder.BuildStandardButton(
            "GateButton", MultilanguangeController.GetText(MultiLanguageEnum.BOTON_ACEPTAR_OPERACION), MainPanel.Width,55);

            _confirmButton.Visible = false;

            this.MainPanel.Controls.Add(_confirmButton);


            _confirmButton.Click += new System.EventHandler(ConfirmButton_Click);
        }

        private void LoadBackButton()
        {

             _backButton = ControlBuilder.BuildExitButton(
            "BackButton", MultilanguangeController.GetText(MultiLanguageEnum.VOLVER), MainPanel.Width);

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
                MultilanguangeController.GetText(MultiLanguageEnum.INGRESE_CODIGO_CONTENEDOR),MainPanel.Width);
            _containerTextBox.Visible = false;

            _containerTextBox.Click += _containerTextBox_Click;

            MainPanel.Controls.Add(_containerTextBox);
        }

        private void _containerTextBox_Click(object? sender, EventArgs e)
        {
            InputBoxForm inputForm = new InputBoxForm();

            if (_containerTextBox.Texts.Equals(_containerTextBox.PlaceholderText))
                inputForm.InputTexboxPlaceholder = _containerTextBox.PlaceholderText;
            else
                inputForm.InputTexboxPlaceholder = MultilanguangeController.GetText(MultiLanguageEnum.PLACEHOLDER_CODIGO_CONTENEDOR);

            inputForm.ReturnTextValue = _containerTextBox.Texts;
            if (inputForm.ShowDialog() == DialogResult.OK)
            {
                _containerTextBox.Texts = inputForm.ReturnTextValue;
            }
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            DatabaseController.UpdateContainerIdentifier(_containerTextBox.Texts.Trim());
            _bagExtractionProcess = BagExtractionProcessEnum.ProcessFinished;
        }
        private void BagButton_Click(object sender, EventArgs e)
        {
            _bagExtractionProcess = BagExtractionProcessEnum.BagExtracting;
        }
        private void BackButton_Click(object sender, EventArgs e)
        {
            FormsController.OpenChildForm(this,new OperationForm(), _device);
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

        private void BagExtractionForm_VisibleChanged(object sender, EventArgs e)
        {
            _pollingTimer.Enabled = this.Visible;

            FormsController.SetInformationMessage(InformationTypeEnum.None, string.Empty);
            if (!this.Visible)
                _bagAlreadyInserted = false;
            
        }

        private void BagExtractionForm_MouseClick(object sender, MouseEventArgs e)
        {
            TimeOutController.Reset();
        }
        private void PrintTicket()
        {

            if (ParameterController.PrintsBagExtraction)
            {
                for (int i = 0; i < ParameterController.PrintBagExtractionQuantity; i++)
                {
                    ReportController.PrintReport(ReportTypeEnum.ValueExtraction,
                        DatabaseController.GetEnvelopeBagContentItems(), 
                        DatabaseController.GetBillBagContentItems(), i);
                }
            }
        }        
    }
}
