﻿using Permaquim.Depositary.UI.Desktop.Components;
using Permaquim.Depositary.UI.Desktop.Controllers;
using Permaquim.Depositary.UI.Desktop.CustomExceptions;
using Permaquim.Depositary.UI.Desktop.Forms;
using Permaquim.Depositary.UI.Desktop.Global;
using Permaquim.Depositary.UI.Desktop.Helpers;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;
using static Permaquim.Depositary.UI.Desktop.Controllers.DatabaseController;
using static Permaquim.Depositary.UI.Desktop.Global.Enumerations;

namespace Permaquim.Depositary.UI.Desktop // 31/5/2022
{
    public partial class MainForm : System.Windows.Forms.Form
    {
        private int _counterReconnectRetrials = 0;

        private const string DEPOSITARIO_NO_INICIALIZADO = "Depositario no inicializado.";
        private const string BASE_SIN_CONEXION = "Sin conexión con la base de datos.";
        private const string RETIRO_DE_VALORES_SIN_USUARIO = "Retiro de valores sin usuario.";
        private const string ERROR = "Error";
        private const string LOGIN = "Login";

        private const string GREENLED_COUNTER = "GREENLED_COUNTER";
        private const string REDLED_COUNTER = "REDLED_COUNTER";
        private const string GREENLED_IOBOARD = "GREENLED_IOBOARD";
        private const string REDLED_IOBOARD = "REDLED_IOBOARD";

        private const string PRESENTACION = "Presentacion.gif";

        private const int WEEK_DAYS = 7;
        private const string VERSION = " - Version: ";
        private const int CLOSING_COMBINATION = 3;
        private const string ABNORMALDEVICE = "AbnormalDevice";
        private const string JAMMING = "Jamming";
        private const string ABNORMALSTORAGE = "AbnormalStorage";
        private const string COUNTINGERROR = "CountingError";
        private const string CASETTEFULL = "CassetteFull";
        private System.Windows.Forms.Timer _pollingTimer = new System.Windows.Forms.Timer();

        private int closingcombination = 0;
        private Color _defaultColor = Color.SteelBlue;

        StatesResult _counterStatesResult;
        IoBoardStatus _ioBoardStatus;

        private Image _greenLedImageCounter;
        private Image _redLedImageCounter;
        private Image _greenLedImageIoboard;
        private Image _redLedImageIoboard;

        private Image _avatarImage;

        private int _greenStatusIndicator;
        private int _yellowStatusIndicator;
        private int _redStatusIndicator;
        private string _remainingTimeText;

        private bool _isLicensed = false;

        private bool _bagRemoved = false;
        private bool _turnAutoClose = false;

        // Variables de información de errores 
        private string _counterCommunicationError = string.Empty;
        private string _ioboardCommunicationError = string.Empty;
        private string _containerError = string.Empty;
        private string _printerError = string.Empty;
        private string _touchScreenToStart = string.Empty;
        ConnectionStatusEnum connectionStatusEnum = ConnectionStatusEnum.None;


        /// <summary>
        /// Instancias de los componentes que gestionan dispositivos
        /// </summary>
        CounterDevice _device = null;
        DEXDevice? _deXDevice = null;

        SystemBlockingDialog _blockingDialog = null;
        PermissionUnlockForm _permissionUnlockForm = null;
        DeviceErrorForm _errorForm = null;
        OperationBlockingForm _operationBlockingForm = null;

        public string BreadCrumbText
        {
            get { return BreadcrumbLabel.Text; }
            set
            {
                BreadcrumbLabel.Text = value;
                BreadcrumbLabel.Refresh();
            }
        }


        public MainForm()
        {
            try
            {

                InitializeComponent();

                this.MainPanel.Width = this.Width;

                FormsController.MainFormInstance = this;

                Rectangle screen = Screen.PrimaryScreen.WorkingArea;
                this.Location = new Point(0, 0);
                this.Size = new Size(screen.Width, screen.Height);

                connectionStatusEnum = DatabaseController.IsInitialized();


                switch (connectionStatusEnum)
                {
                    case ConnectionStatusEnum.None:
                        break;
                    case ConnectionStatusEnum.Connected:
                        DatabaseController.SetDepositaryStatus(true);
                        _device = new();
                        _turnAutoClose = ParameterController.TurnAutoClose;
                        // Variables de información de errores 
                        _counterCommunicationError = MultilanguangeController.GetText(MultiLanguageEnum.ERROR_COMUNICACION_CONTADORA);
                        _ioboardCommunicationError = MultilanguangeController.GetText(MultiLanguageEnum.ERROR_COMUNICACION_PLACA);
                        _containerError = MultilanguangeController.GetText(MultiLanguageEnum.ERROR_CONTENEDOR);
                        _printerError = MultilanguangeController.GetText(MultiLanguageEnum.ERROR_IMPRESORA);
                        _touchScreenToStart = MultilanguangeController.GetText(MultiLanguageEnum.TOQUE_PANTALLA_PARA_INICIAR);

                        _pollingTimer = new System.Windows.Forms.Timer()
                        {
                            Interval = DeviceController.GetPollingInterval(),
                            Enabled = false
                        };
                        _pollingTimer.Tick += PollingTimer_Tick;

                        LoadLogo();

                        _remainingTimeText = MultilanguangeController.GetText(MultiLanguageEnum.TIEMPO_RESTANTE);

                        this.DoubleBuffered = true;
                        break;
                    case ConnectionStatusEnum.Disconnected:
                        LoadDefaultStyles();
                        InformationLabel.BackColor = Color.Red;
                        InformationLabel.Text = BASE_SIN_CONEXION;

                        break;
                    case ConnectionStatusEnum.UnInitialized:

                        LoadDefaultStyles();
                        InformationLabel.BackColor = Color.Red;
                        InformationLabel.Text = DEPOSITARIO_NO_INICIALIZADO;
                        break;
                    default:
                        break;
                }

 

            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show(ex.Message, ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetInformationMessage(InformationTypeEnum.Error, ex.Message);
                AuditController.Log(ex);
            }
            catch (System.FormatException ex)
            {
                MessageBox.Show(ex.Message, ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetInformationMessage(InformationTypeEnum.Error, ex.Message);
                AuditController.Log(ex);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                AuditController.Log(ex);
                SetInformationMessage(InformationTypeEnum.Error, ex.Message);
                AuditController.Log(ex);
            }
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
        private void MainForm_Load(object sender, EventArgs e)
        {
            int retries = 1;

            if (connectionStatusEnum == ConnectionStatusEnum.Connected)
            {
                while (DatabaseController.CurrentDepositary == null)
                {
                    LoadDefaultStyles();
                    InformationLabel.BackColor = Color.Red;
                    InformationLabel.Text = DEPOSITARIO_NO_INICIALIZADO + " (" + retries.ToString() + ")";
                    InformationLabel.Refresh();
                    retries++;
                    Thread.Sleep(5000);
                }

                if (DatabaseController.CurrentDepositary != null)
                {
                    DatabaseController.SetDepositaryStatus(true);

                    _pollingTimer = new System.Windows.Forms.Timer()
                    {
                        Interval = DeviceController.GetPollingInterval(),
                        Enabled = false
                    };
                    _pollingTimer.Tick += PollingTimer_Tick;

                    LoadLogo();

                    _remainingTimeText = MultilanguangeController.GetText(MultiLanguageEnum.TIEMPO_RESTANTE);

                    this.DoubleBuffered = true;

                    LoadStyles();


                    if (CheckLicensefile())
                    {
                        if (CheckLicense())
                        {
                            _isLicensed = true;
                            InitializeDevices();
                            LoadLedImages();
                            VerifyUserData();
                            LoadParameters();
                            LoadLanguageItems();
                            SetDepositaryInformation();
                            SetTurnAndDateTimeLabel();
                        }

                    }
                    else
                    {
                        _isLicensed = false;
                        SetInformationMessage(InformationTypeEnum.Error,
                        MultilanguangeController.GetText(MultiLanguageEnum.LICENCIA_NO_VALIDA));
                        Clipboard.SetText(LicenseController.GetHardwareId());

                    }
                }
                else
                {
                    LoadDefaultStyles();
                    InformationLabel.BackColor = Color.Red;
                    InformationLabel.Text = DEPOSITARIO_NO_INICIALIZADO;
                }
            }
            else
            {
                InformationLabel.BackColor = Color.Red;
                InformationLabel.Text = BASE_SIN_CONEXION;
            }
        }
        private void DeviceErrorEventReceived(object sender, DeviceErrorEventArgs args)
        {
            EventController.CreateEvent(EventTypeEnum.Estado_Fuera_De_Servicio, args.ErrorCode, args.ErrorDescription);
            
            AuditController.Log(LogTypeEnum.Exception, args.ErrorCode, args.ErrorDescription);

            //DeviceController.CounterIssue = true;
            switch (args.ErrorDescription)
            {
                case ABNORMALDEVICE:
                    if (!ParameterController.ShowsAbnormalDevice)
                        return;
                    break;
                case JAMMING:
                    if (!ParameterController.ShowsJamming)
                        return;
                    break;
                case ABNORMALSTORAGE:
                    if (!ParameterController.ShowsAbnormalStorage)
                        return;
                    break;
                case COUNTINGERROR:
                    if (!ParameterController.ShowsCountingError)
                        return;
                    break;
                case CASETTEFULL:
                    if (!ParameterController.ShowsCassetteFull)
                        return;
                    break;
                default:
                    break;
            }
 
            if (_errorForm == null)
            {
                _errorForm = new DeviceErrorForm();
                _errorForm.Tag = _device;
                _errorForm.ShowDialog();
                _errorForm = null;
            }
        }

        /// <summary>
        /// Chequeo de licencia
        /// </summary>
        private bool CheckLicensefile()
        {
            if (ConfigurationController.IsDevelopment())
                return true;
            else
                return File.Exists((AppDomain.CurrentDomain.BaseDirectory + @"\APP.0.STOL.License"));
        }

        /// <summary>
        /// Chequeo de licencia
        /// </summary>
        private bool CheckLicense()
        {
            if (ConfigurationController.IsDevelopment())
                return true;
            else
            {
                if (LicenseController.IsValidLicenseAvailable())
                {
                    double remainingDays = LicenseController.GetLicenseRemainingDays();
                    if (remainingDays <= WEEK_DAYS)
                    {
                        SetInformationMessage(InformationTypeEnum.Error,
                            MultilanguangeController.GetText(MultiLanguageEnum.DIAS_RESTANTES_LICENCIA)
                            + " " + ((int)remainingDays).ToString());
                    }
                    if (!LicenseController.CheckLicenseAttributes())
                    {
                        SetInformationMessage(InformationTypeEnum.Error,
                     MultilanguangeController.GetText(MultiLanguageEnum.LICENCIA_NO_VALIDA) + 
                     " HWID= " + LicenseController.GetHardwareId()
                     );
                        Clipboard.SetText(LicenseController.GetHardwareId());
                        return false;
                    }

                    return true;
                }
                else
                {
                    SetInformationMessage(InformationTypeEnum.Error,
                        MultilanguangeController.GetText(MultiLanguageEnum.LICENCIA_NO_VALIDA));
                    Clipboard.SetText(LicenseController.GetHardwareId());
                    return false;
                }
            }
        }
        private void LoadParameters()
        {
            _greenStatusIndicator = ParameterController.GreenStatusIndicator;
            _yellowStatusIndicator = ParameterController.YellowStatusIndicator;
            _redStatusIndicator = ParameterController.RedStatusIndicator;
        }
        private void LoadLedImages()
        {
            _greenLedImageCounter = StyleController.GetImageResource(GREENLED_COUNTER);
            _redLedImageCounter = StyleController.GetImageResource(REDLED_COUNTER);
            _greenLedImageIoboard = StyleController.GetImageResource(GREENLED_IOBOARD);
            _redLedImageIoboard = StyleController.GetImageResource(REDLED_IOBOARD);
        }
        private void InitializeDevices()
        {

            try
            {

                DEXDevice device = DeviceController.InitializeDevice();

                _deXDevice = device;

                this.Text = MultilanguangeController.GetText(MultiLanguageEnum.DISPOSITIVO)
                    + ": " + DatabaseController.CurrentDepositary.ModeloId.Nombre;

                LoadStyles();

                _device = new CounterDevice(device);

                _device.DeviceErrorReceived += DeviceErrorEventReceived;

                _pollingTimer.Enabled = true;

                _device.SleepTimeout = DeviceController.GetSleepInterval();

                this.Tag = _device;


                // Evaluación de estado de la contadora y el ioBoard
                // Si está todo en órden, se libera la aplicación
                if (VerifyBasicConfigurations())
                {
                    MainPanel.BringToFront();

                    // Ejecuto la primera consulta al dispositivo. 
                    // Puede que se encuentre en un estado intermedio en donde no se haya finalizado la 
                    // Operación anterior.

                    _counterStatesResult = _device.Sense();

                    if (_device.CounterConnected)
                    {
                        if (_counterStatesResult != null)
                        {
                            _device.PreviousState = _counterStatesResult.StatusInformation.OperatingState;

                            // Si el escrow está abierto se debe cerrar
                            if (_device.StateResultProperty.StatusInformation.OperatingState ==
                                    StatusInformation.State.EscrowOpen ||
                                    _device.StateResultProperty.StatusInformation.OperatingState ==
                                    StatusInformation.State.PQWaitingTocloseEscrow)

                                _device.CloseEscrow();

                            // si por algun motivo el equipo se recupera de una transacción fallida, se cancela la operación.
                            if (_device.StateResultProperty.ModeStateInformation.ModeState == ModeStateInformation.Mode.DepositMode
                                || _device.StateResultProperty.ModeStateInformation.ModeState == ModeStateInformation.Mode.InitialMode)
                            {
                                _device.RemoteCancel();
                            }
                        }
                    }
                }
            }
            catch (CommPortException ex)
            {
                SetInformationMessage(InformationTypeEnum.Error, ex.ExceptionMessage);
                AuditController.Log(ex);
            }
            catch (Exception ex)
            {
                SetInformationMessage(InformationTypeEnum.Error, ex.Message);
                AuditController.Log(ex);
            }

        }


        private void PollingTimer_Tick(object? sender, EventArgs e)
        {
            try
            {
                if (_device == null)
                {
                    DeviceController.IsOutOfService = true;
                    DeviceController.ContainerStatus = Global.Constants.COUNTER_DISCONNECTED;
                    DeviceController.IoBoardStatus = Global.Constants.IOBOARD_DISCONNECTED;

                    InitializeDevices();
                }

                SetTurnAndDateTimeLabel();

                VerifyIssues();

                VerifyForcedValueExtraction();

                VerifyConnections();

                VerifyUserData();

                VerifyTimeout();

                VerifyAvatar();

                VerifyOpenDoor();

                VerifyBagExtracted();

                //VerifyPreviousFailedoperation();

            }
            catch (Exception ex)
            {
                AuditController.Log(ex);
                SetInformationMessage(InformationTypeEnum.Error, ex.Message);
            }

        }

        private void VerifyIssues()
        {
            if (DeviceController.HasAnyIssue)
            {
                string message = string.Empty;


                OperationblockingReasonEnum operationblockingReason = OperationblockingReasonEnum.None;

                if (DeviceController.CounterIssue)
                {
                    message += _counterCommunicationError + ";";
                    operationblockingReason = OperationblockingReasonEnum.CounterCommunicationError;
                    EventController.CreateEvent(EventTypeEnum.Estado_Fuera_De_Servicio, message, String.Empty);
                }
                if (DeviceController.IoBoardIssue)
                {
                    message += _ioboardCommunicationError + ";";
                    operationblockingReason = OperationblockingReasonEnum.IoBoardCommunicationError;
                    EventController.CreateEvent(EventTypeEnum.Estado_Fuera_De_Servicio, message, String.Empty);
                }
                if (DeviceController.BagIssue)
                {
                    message += _containerError + ";";
                    operationblockingReason = OperationblockingReasonEnum.ContainerError;
                    EventController.CreateEvent(EventTypeEnum.Estado_Fuera_De_Servicio, message, String.Empty);
                }

                if (DeviceController.PrinterIssue)
                {
                    message += _printerError + ";";
                    operationblockingReason = OperationblockingReasonEnum.PrinterError;
                    EventController.CreateEvent(EventTypeEnum.Estado_Fuera_De_Servicio, message, String.Empty);

                }

                SetInformationMessage(InformationTypeEnum.Error, message);

            }
            else
            {
                string currentinformationMessage = GetinformationMessage();

                if (currentinformationMessage.Equals(string.Empty) && DatabaseController.CurrentUser == null)
                {
                    SetInformationMessage(InformationTypeEnum.None, _touchScreenToStart);
                }

                if (
                    currentinformationMessage.IndexOf(_counterCommunicationError) > -1 ||
                    currentinformationMessage.IndexOf(_ioboardCommunicationError) > -1 ||
                    currentinformationMessage.IndexOf(_containerError) > -1 ||
                    currentinformationMessage.IndexOf(_printerError) > -1
                    )
                {
                    if (DatabaseController.CurrentUser == null)
                        SetInformationMessage(InformationTypeEnum.None, _touchScreenToStart);
                    else
                        SetInformationMessage(InformationTypeEnum.None, string.Empty);
                }
            }

        }

        private void VerifyForcedValueExtraction()
        {
            if(DeviceController.BagRemovedForcefully )
            {
                if (ParameterController.ForcedValueExtractionNeedsAuthorization)
                {
                    if (_permissionUnlockForm == null)
                    {
                        AuditController.Log(LogTypeEnum.Exception, RETIRO_DE_VALORES_SIN_USUARIO, RETIRO_DE_VALORES_SIN_USUARIO);
                        _permissionUnlockForm = new PermissionUnlockForm()
                        {
                            Tag = this.Tag
                        };
                        _permissionUnlockForm.LoadStyles();
                        _permissionUnlockForm.ShowDialog();
                        _permissionUnlockForm = null;
                        DeviceController.BagRemovedForcefully = false;
                        Login();

                    }
                }
            }
        }

        private bool VerifyBasicConfigurations()
        {
            string message = DatabaseController.GetBasicConfigurationMessage();
            if (message.Length > 0)
            {
                {
                    AuditController.Log(LogTypeEnum.Exception, message, message);

                    EventController.CreateEvent(EventTypeEnum.Estado_Fuera_De_Servicio, message, message);

                    if (_blockingDialog == null)
                    {
                        _blockingDialog = new SystemBlockingDialog()
                        {
                            Tag = this.Tag,
                            MessageText = message
                        };
                        _blockingDialog.LoadStyles();
                        _blockingDialog.ShowDialog();
                        _blockingDialog = null;
                    }

                }
            }
            return message.Length == 0;
        }

        private void VerifyCassetteFull()
        {
            if (_device.CounterConnected)
            {
                if (_device.StateResultProperty.DoorStateInformation.CassetteFull)
                {
                    string message = MultilanguangeController.GetText(MultiLanguageEnum.CASSETTE_FULL);
                    EventController.CreateEvent(EventTypeEnum.Cassette_Full, message, message);
                }
            }
        }

        private void VerifyOpenDoor()
        {

            try
            {

                if (_device.IoBoardConnected)
                {
                    if (_device.IoBoardStatusProperty.GateState == IoBoardStatus.GATE_STATE.OPEN)

                    {

                        DeviceController.IsOutOfService = true;

                        if (_blockingDialog == null &&
                            (DatabaseController.CurrentOperation == null ||
                            DatabaseController.CurrentOperation.Id != (long)OperationTypeEnum.ValueExtraction))
                        {
                            string message = MultilanguangeController.GetText(MultiLanguageEnum.PUERTA_ABIERTA);
                            AuditController.Log(LogTypeEnum.Exception, message, message);

                            DeviceController.GateStatus = Global.Constants.OPEN_GATE;

     
                            EventController.CreateEvent(EventTypeEnum.Apertura_de_Puerta, message, message);

                            _blockingDialog = new SystemBlockingDialog()
                            {
                                Tag = this.Tag,
                                MessageText = MultilanguangeController.GetText(MultiLanguageEnum.PUERTA_ABIERTA)
                            };
                            _blockingDialog.LoadStyles();
                            //if (!ConfigurationController.IsDevelopment())
                                _blockingDialog.ShowDialog();

                                _blockingDialog = null;
                            DeviceController.GateStatus = Global.Constants.NORMAL;
                        }
                    }
                    else
                    {
                        DeviceController.GateStatus = Global.Constants.NORMAL;
                        DeviceController.IsOutOfService = false;
                    }
                }
            }
            catch (Exception ex)
            {
                AuditController.Log(ex);
                SetInformationMessage(InformationTypeEnum.Error, ex.Message);
            }
        }
        private void VerifyBagExtracted()
        {

            try
            {

                 if (DatabaseController.CurrentOperation == null ||
                         DatabaseController.CurrentOperation.Id != (long)OperationTypeEnum.ValueExtraction)
                {
                    if (_device.IoBoardConnected)
                    {
                        if (_device.IoBoardStatusProperty.BagState == IoBoardStatus.BAG_STATE.BAG_STATE_REMOVED)
                        {
                            if (!_bagRemoved)
                            {
                                DeviceController.BagRemovedForcefully = true;
                                _bagRemoved = true;
                                // Se asume retiro de bolsa
                                DatabaseController.CreateContainer();

                                PrintBagTicket();
                            }
                        }
                        if (_device.IoBoardStatusProperty.BagState == IoBoardStatus.BAG_STATE.BAG_STATE_INPLACE)
                        {
                            _bagRemoved = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                AuditController.Log(ex);
                SetInformationMessage(InformationTypeEnum.Error, ex.Message);
            }
        }

        private bool VerifyBagInplace()
        {
            if (_device!= null && _device.IoBoardConnected)
                return _device.IoBoardStatusProperty.BagState == IoBoardStatus.BAG_STATE.BAG_STATE_INPLACE;
            else
                return false;
        }

        private void VerifyPreviousFailedoperation()
        {
            try
            {

                if (FormsController.ActiveFormscount == 0)
                {
                    // si quedó contenido en el escrow debe ser retirado
                    if (_device.CounterConnected)
                    {
                        if (_device.StateResultProperty.DeviceStateInformation.EscrowBillPresent)
                        {

                            AuditController.Log(LogTypeEnum.Exception,
                                MultilanguangeController.GetText(MultiLanguageEnum.RETIRE_VALORES_ESCROW),
                                MultilanguangeController.GetText(MultiLanguageEnum.ERROR_OPERACION_PREVIA));

                            _device.OpenEscrow();
                            _pollingTimer.Enabled = false;
                            if (MessageBox.Show(
                                //"Retire el contenido de la pre-bóveda para poder iniciar la operación",
                                MultilanguangeController.GetText(MultiLanguageEnum.RETIRE_VALORES_ESCROW),
                                //"Error en operación previa", 
                                MultilanguangeController.GetText(MultiLanguageEnum.ERROR_OPERACION_PREVIA),
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation) == DialogResult.OK)
                            {
                                _pollingTimer.Enabled = false;

                                _device.CloseEscrow();
                                Thread.Sleep(3000);
                                _device.RemoteCancel();
                            }
                            _device.RemoteCancel();
                        }
                        else
                        {

                        }
                        if (_device.StateResultProperty.ModeStateInformation.ModeState == ModeStateInformation.Mode.DepositMode
                            || _device.StateResultProperty.ModeStateInformation.ModeState == ModeStateInformation.Mode.ManualMode
                            || _device.StateResultProperty.ModeStateInformation.ModeState == ModeStateInformation.Mode.InitialMode)
                        {
                            _device.RemoteCancel();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                AuditController.Log(ex);
                SetInformationMessage(InformationTypeEnum.Error, ex.Message);
            }
        }

        private void VerifyConnections()
        {

            try
            {
                // consulta el estado de la contadora si está conectada
                _counterStatesResult = _device.Sense();

                if (_device.CounterConnected)
                {
                    _counterReconnectRetrials = 0;
                    FormsController.EnableDisableForms(true);
                    if(CounterPictureBox.Image != _greenLedImageCounter)
                        CounterPictureBox.Image = _greenLedImageCounter;
                    DeviceController.CounterIssue = false;
                    DeviceController.CounterStatus = Global.Constants.NORMAL;
                    DeviceController.IsOutOfService = false;
                }
                else
                {
                    _counterReconnectRetrials += 1;

                    if (_counterReconnectRetrials >= ParameterController.CounterReconnectRetrials)
                    {
                        if (DatabaseController.CurrentOperation != null && (
                       (int)DatabaseController.CurrentOperation.Id == (int)OperationTypeEnum.BillDeposit ||
                       (int)DatabaseController.CurrentOperation.Id == (int)OperationTypeEnum.EnvelopeDeposit))
                        {

                            FormsController.EnableDisableForms(false);
                            DatabaseController.LogOff(true);
                            FormsController.LogOff();
                        }
                    }
                    if(CounterPictureBox.Image != _redLedImageCounter)
                        CounterPictureBox.Image = _redLedImageCounter;
                    DeviceController.CounterIssue = true;
                    DeviceController.IsOutOfService = true;
                    DeviceController.CounterStatus = Global.Constants.COUNTER_DISCONNECTED;
                    _device.CounterBoardReconnect();
                }

                _ioBoardStatus = _device.Status();
 
                // consulta el estado de la ioboard  si está conectada
                if (_device.IoBoardConnected)
                {
                    if(IoBoardPictureBox.Image != _greenLedImageIoboard)
                        IoBoardPictureBox.Image = _greenLedImageIoboard;
                    DeviceController.IoBoardIssue = false;
                    DeviceController.IoBoardStatus = Global.Constants.NORMAL;
                    DeviceController.IsOutOfService = false;
                }
                else
                {
                    if (IoBoardPictureBox.Image != _redLedImageIoboard)
                        IoBoardPictureBox.Image = _redLedImageIoboard;
                    DeviceController.IoBoardIssue = true;
                    DeviceController.IsOutOfService = true;
                    DeviceController.IoBoardStatus = Global.Constants.IOBOARD_DISCONNECTED;
                    _device.IoBoardReconnect();
                }

            }
            catch (Exception ex)
            {
                AuditController.Log(ex);
                SetInformationMessage(InformationTypeEnum.Error, ex.Message);
            }
        }

        private void VerifyTimeout()
        {
            if (!TimeOutController.IsActive())
                return;

            long remainingTime = TimeOutController.GetRemainingTime();

            if (remainingTime > 0)
            {
                RemainingTimeLabel.Visible = remainingTime > 0;

                RemainingTimeLabel.Text = " " + _remainingTimeText +
                    remainingTime.ToString();
                if (remainingTime > _greenStatusIndicator)
                    RemainingTimeLabel.ForeColor = StyleController.GetColor(ColorNameEnum.TextoInformacion);
                if (remainingTime < _yellowStatusIndicator)
                    RemainingTimeLabel.ForeColor = StyleController.GetColor(ColorNameEnum.TextoAlerta);
                if (remainingTime < _redStatusIndicator)
                {
                    RemainingTimeLabel.ForeColor = StyleController.GetColor(ColorNameEnum.TextoError);
                    RemainingTimeLabel.Text += " * " +
                        MultilanguangeController.GetText(MultiLanguageEnum.SOLICITAR_MAS_TIEMPO);
                    RemainingTimeLabel.Visible = ((remainingTime % 2) == 0);
                }
            }
        }

        public void VerifyUserData()
        {
            if (DatabaseController.CurrentUser != null)
            {
                if (DatabaseController.UserAllowedInSector())
                {
                    UserLabel.Text = MultilanguangeController.GetText(MultiLanguageEnum.USUARIO) + ": " +
                        DatabaseController.CurrentUser.Apellido + " " + DatabaseController.CurrentUser.Nombre;

                    EnterpriseLabel.Text = MultilanguangeController.GetText(MultiLanguageEnum.EMPRESA) + ": " +
                    DatabaseController.CurrentUser.EmpresaId.Nombre;

                    SetTurnAndDateTimeLabel();
                }

            }
            else
            {
                UserLabel.Text = String.Empty;
                EnterpriseLabel.Text = String.Empty;
                RemainingTimeLabel.Text = String.Empty;
                //TurnAndDateTimeLabel.Text = String.Empty;
            }

        }

        private void SetDepositaryInformation()
        {
            SucursalInfoLabel.Text =
              MultilanguangeController.GetText(MultiLanguageEnum.SUCURSAL) + ": "
              + DatabaseController.CurrentDepositary.SectorId.SucursalId.Nombre + Environment.NewLine
              + MultilanguangeController.GetText(MultiLanguageEnum.SECTOR) + ": "
              + DatabaseController.CurrentDepositary.SectorId.Nombre;

            DepositaryLabel.Text = MultilanguangeController.GetText(MultiLanguageEnum.DEPOSITARIO) + ": "
              + DatabaseController.CurrentDepositary.Nombre + Environment.NewLine
              + MultilanguangeController.GetText(MultiLanguageEnum.CODIGO) + ": "
              + DatabaseController.CurrentDepositary.CodigoExterno;
        }

        private void SetTurnAndDateTimeLabel()
        {
 
            TurnAndDateTimeLabel.Text = MultilanguangeController.GetText(MultiLanguageEnum.TURNO) + " : ";

            if (DatabaseController.CurrentTurn == null)
            {
                if(DatabaseController.CurrentUser != null)
                    TurnAndDateTimeLabel.Text += MultilanguangeController.GetText(MultiLanguageEnum.SIN_TURNO);
            }
            else
            {
                VerifyDayclosing();

                string turnDate = string.Empty;
                if (DatabaseController.CurrentTurn.Fecha != null)
                    turnDate = " - " + ((DateTime)DatabaseController.CurrentTurn.Fecha).ToString(MultilanguangeController.GetText(MultiLanguageEnum.FORMATO_FECHA));
                TurnAndDateTimeLabel.Text += DatabaseController.CurrentTurn.TurnoDepositarioId.
                EsquemaDetalleTurnoId.Nombre + turnDate;
            }


            TurnAndDateTimeLabel.Text += Environment.NewLine + DateTime.Now.ToString("dd/MM/yyyy - HH:mm:ss");
        }

        private void VerifyDayclosing()
        {
            // Chequeo de cambio de fecha
            if (DateTime.Today > DatabaseController.CurrentTurn.Fecha)
            {
                if (_turnAutoClose)
                {
                    _pollingTimer.Enabled = false;
                    DatabaseController.ClosePendingTurns();
                    _pollingTimer.Enabled = true;
                }
            }
        }

        private void MainPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (VerifySchedule())
                Login();
            else
            {
                SetInformationMessage(InformationTypeEnum.Error,
                    MultilanguangeController.GetText(MultiLanguageEnum.SIN_TURNO));
                AuditController.Log(LogTypeEnum.Exception,
                            MultilanguangeController.GetText(MultiLanguageEnum.SIN_TURNO),
                            MultilanguangeController.GetText(MultiLanguageEnum.SIN_TURNO));

            }
        }

        private void Login()
        {
            MainPictureBox.Image = null;
            if (DatabaseController.CurrentUser != null)
                FormsController.OpenChildForm(new OperationForm(),
                    (Permaquim.Depositary.UI.Desktop.Components.CounterDevice)this.Tag);

            else
            {
                AuditController.Log(LogTypeEnum.Navigation, LOGIN, LOGIN);
                FormsController.OpenChildForm(new KeyboardInputForm(),
                    (Permaquim.Depositary.UI.Desktop.Components.CounterDevice)this.Tag);
            }

        }

        private void LoadLanguageItems()
        {
            BreadCrumbText = MultilanguangeController.GetText(this.Name) +
                VERSION + Assembly.GetExecutingAssembly().GetName().Version.ToString();
            SetInformationMessage(InformationTypeEnum.None,
                _touchScreenToStart);
        }

        private void LoadStyles()
        {
            HeadPanel.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.CabeceraAplicacion);
            MainPanel.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.FondoFormulario);
            BottomPanel.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.PieAplicacion);
            MainPictureBox.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.FondoFormulario);
            InformationLabel.ForeColor = StyleController.GetColor(Enumerations.ColorNameEnum.FuenteContraste);
            
            EnterpriseLabel.ForeColor = StyleController.GetColor(Enumerations.ColorNameEnum.FuenteContraste);
            UserLabel.ForeColor = StyleController.GetColor(Enumerations.ColorNameEnum.FuenteContraste);
            
            SucursalInfoLabel.ForeColor = StyleController.GetColor(Enumerations.ColorNameEnum.FuenteContraste);
            DepositaryLabel.ForeColor = StyleController.GetColor(Enumerations.ColorNameEnum.FuenteContraste);
            TurnAndDateTimeLabel.ForeColor = StyleController.GetColor(Enumerations.ColorNameEnum.FuenteContraste);

            BreadcrumbLabel.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.Breadcrumb);
            BreadcrumbLabel.ForeColor = StyleController.GetColor(Enumerations.ColorNameEnum.FuenteContraste);

            LoadPresentation();
        }
        private void LoadDefaultStyles()
        {
            HeadPanel.BackColor = _defaultColor;
             MainPanel.BackColor = _defaultColor;
            BottomPanel.BackColor = _defaultColor;
            MainPictureBox.BackColor = _defaultColor;
            UserLabel.ForeColor = _defaultColor;
            EnterpriseLabel.ForeColor = _defaultColor;
            TurnAndDateTimeLabel.ForeColor = _defaultColor; 
            BreadcrumbLabel.BackColor = _defaultColor;
            BreadcrumbLabel.ForeColor = Color.White;
            InformationLabel.ForeColor = Color.White; 
        }

        public void LoadPresentation()
        {
            MainPictureBox.Image = StyleController.GetImageResourceFromfile(PRESENTACION);

        }
        private void LoadLogo()
        {
            LogoPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            LogoPictureBox.Image = StyleController.GetLogo();
        }

        private void VerifyAvatar()
        {
            if (DatabaseController.CurrentUser != null)
            {
                if (DatabaseController.UserAllowedInSector())
                {
                    if (AvatarPicturebox.Image == null)
                    {
                        _avatarImage = ImageFromBase64Helper.
                            GetImageFromBase64String(DatabaseController.CurrentUser.Avatar);
                        AvatarPicturebox.Image = _avatarImage;
                    }
                }
            }
            else
            {
                AvatarPicturebox.Image = null;
            }
        }
        private bool VerifySchedule()
        {
            return DatabaseController.VerifySchedule();
        }
        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainPictureBox_Click(object sender, EventArgs e)
        {
            if (_isLicensed)
            {
                if (ConfigurationController.IsDevelopment())
                    Login();
                else
                {
                    if (!_device.CounterConnected || !_device.IoBoardConnected)
                    {
                        string message = MultilanguangeController.GetText(MultiLanguageEnum.ERROR_PUERTO);
                        SetInformationMessage(InformationTypeEnum.Error, message);
                        AuditController.Log(LogTypeEnum.Exception, message, message);
                        EventController.CreateEvent(EventTypeEnum.Estado_Fuera_De_Servicio, message, message);
                        Login();
                    }
                    if (ParameterController.ValidatesBagInplace)
                    {
                        if (VerifyBagInplace())
                        {
                            Login();
                        }
                        else
                        {
                            string message = MultilanguangeController.GetText(MultiLanguageEnum.SIN_BOLSA_ACTIVA);
                            SetInformationMessage(InformationTypeEnum.Error, message);
                            AuditController.Log(LogTypeEnum.Exception, message, message);
                            EventController.CreateEvent(EventTypeEnum.Estado_Fuera_De_Servicio, message, message);
                            DeviceController.BagIssue = true;
                        }
                    }
                    else
                    {
                        Login();
                    }
                }
            }
        }

        private void LogoPictureBox_Click(object sender, EventArgs e)
        {
            closingcombination = 1;
        }

        private void AvatarPicturebox_Click(object sender, EventArgs e)
        {
            closingcombination += 1;
        }

        private void DateTimeLabel_Click(object sender, EventArgs e)
        {

            // solo sale de la aplicación si el usuario está deslogueado
            if (closingcombination == CLOSING_COMBINATION && DatabaseController.CurrentUser == null)
                Application.Exit();

        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void MainPictureBox_VisibleChanged(object sender, EventArgs e)
        {
            //System.Diagnostics.Debug.Print(
            //    _counterDevice.StateResultProperty.StatusInformation.OperatingState.ToString());
        }
        public string GetinformationMessage()
        {
            return InformationLabel.Text.Trim();
        }
        public void SetInformationMessage(InformationTypeEnum type, string message)
        {

            switch (type)
            {
                case InformationTypeEnum.None:
                    InformationLabel.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.Breadcrumb);
                    break;
                case InformationTypeEnum.Information:
                    InformationLabel.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.TextoInformacion);
                    break;
                case InformationTypeEnum.Alert:
                    InformationLabel.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.TextoAlerta);
                    break;
                case InformationTypeEnum.Error:
                    InformationLabel.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.TextoError);
                    break;
                case InformationTypeEnum.Event:
                    InformationLabel.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.TextoEvento);
                    break;
                default:
                    InformationLabel.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.Breadcrumb);
                    break;
            }

            this.InformationLabel.Text = message;
            this.InformationLabel.Refresh();
        }

        private void TurnAndDateTimeLabel_Click(object sender, EventArgs e)
        {
            if (closingcombination == CLOSING_COMBINATION && DatabaseController.CurrentUser == null)
            {
                AuditController.Log(LogTypeEnum.Information,
                MultilanguangeController.GetText(MultiLanguageEnum.APLICACION_CERRADA_MANUALMENTE),
                MultilanguangeController.GetText(MultiLanguageEnum.APLICACION_CERRADA_MANUALMENTE));
                Application.Exit();
            }
        }
        private void PrintBagTicket()
        {
            if (ParameterController.PrintsBagExtraction)
            {
                for (int i = 0; i < ParameterController.PrintBagExtractionQuantity; i++)
                {
                    ReportController.ContainerToPrint = DatabaseController.LastContainer;
                    ReportController.PrintReport(ReportTypeEnum.ValueExtraction,
                        DatabaseController.GetEnvelopeLastContainerContentItems(),
                        DatabaseController.GetBillLastContainerContentItems(), i);
                }
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (closingcombination != 3)

                e.Cancel = true;
        }
    }
}

