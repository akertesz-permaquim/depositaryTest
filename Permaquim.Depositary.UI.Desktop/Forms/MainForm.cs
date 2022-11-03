using Newtonsoft.Json;
using Permaquim.Depositary.UI.Desktop.Components;
using Permaquim.Depositary.UI.Desktop.Controllers;
using Permaquim.Depositary.UI.Desktop.Global;
using Permaquim.Depositary.UI.Desktop.Helpers;
using Permaquim.Depositary.UI.Desktop.CustomExceptions;
using static Permaquim.Depositary.UI.Desktop.Global.Enumerations;
using Permaquim.Depositary.UI.Desktop.Forms;
using System.Windows.Forms;
using Permaquim.Depositary.UI.Desktop.Entities;
using System.Reflection;

namespace Permaquim.Depositary.UI.Desktop // 31/5/2022
{
    public partial class MainForm : System.Windows.Forms.Form
    {
        private const string DEPOSITARIO_NO_INICIALIZADO = "Depositario no inicializado.";
        private const string RETIRO_DE_VALORES_SIN_USUARIO = "Retiro de valres sin usuario.";
        private const string ERROR = "Error";

        private const string GREENLED = "GREENLED";
        private const string REDLED = "REDLED";
        private const string PRESENTACION = "Presentacion.gif";

        private const string ERROR_COMUNICACION_CONTADORA = "Error de comunicación de la contadora";
        private const string ERROR_COMUNICACION_PLACA = "Error de comunicación de la placa";
        private const string ERROR_CONTENEDOR = "Error de contenedor";
        private const string ERROR_IMPRESORA = "Error de impresora";

        private System.Windows.Forms.Timer _pollingTimer = new System.Windows.Forms.Timer();

        private int closingcombination = 0;
        private Color _defaultColor = Color.SteelBlue;

        StatesResult _counterStatesResult;
        IoBoardStatus _ioBoardStatus;

        private Image _greenLedImage;
        private Image _redLedImage;

        private Image _avatarImage;

        private int _greenStatusIndicator;
        private int _yellowStatusIndicator;
        private int _redStatusIndicator;
        private string _remainingTimeText;


        private bool _bagRemoved = false;

        /// <summary>
        /// Instancias de los componentes que gestionan dispositivos
        /// </summary>
        CounterDevice _device = new();
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

                if (DatabaseController.CurrentDepositary == null)
                {
                    LoadDefaultStyles();
                    InformationLabel.BackColor = Color.Red;
                    InformationLabel.Text = DEPOSITARIO_NO_INICIALIZADO;
                    Application.Exit();
                    return;
                }
                else
                {

                    _pollingTimer = new System.Windows.Forms.Timer()
                    {
                        Interval = DeviceController.GetPollingInterval(),
                        Enabled = false
                    };
                    _pollingTimer.Tick += PollingTimer_Tick;

                    LoadLogo();

                    _remainingTimeText = MultilanguangeController.GetText(MultiLanguageEnum.TIEMPO_RESTANTE);

                    this.DoubleBuffered = true;

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
            if (DatabaseController.CurrentDepositary != null)
            {
                if (CheckLicensefile())
                {
                    if (CheckLicense())
                    {
                        InitializeDevices();
                        LoadLedImages();
                        VerifyUserData();
                        LoadParameters();
                        LoadLanguageItems();
                    }
                    else
                    {
                        LoadStyles();
                    }
                }else
                {
                    string message = MultilanguangeController.GetText(MultiLanguageEnum.LICENCIA_NO_VALIDA);
                    MessageBox.Show(message, message, MessageBoxButtons.OK);
                    Clipboard.SetText(LicenseController.GetHardwareId());
                }
            }
            else
            {
                InformationLabel.BackColor = Color.Red;
                InformationLabel.Text = DEPOSITARIO_NO_INICIALIZADO;
            }
        }
        private void DeviceErrorEventReceived(object sender, DeviceErrorEventArgs args)
        {
            DatabaseController.CreateEvent(EventTypeEnum.Estado_Fuera_De_Servicio, args.ErrorCode, args.ErrorDescription);
            
            AuditController.Log(LogTypeEnum.Exception, args.ErrorCode, args.ErrorDescription);

            //DeviceController.CounterIssue = true;

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
            return true;
            return File.Exists((Directory.GetCurrentDirectory() + @"\APP0STOL.License"));
        }

            /// <summary>
            /// Chequeo de licencia
            /// </summary>
            private bool CheckLicense()
        {
            return true; // TODO: ELIMINAR EN PRODUCCIÓN

            if (LicenseController.IsValidLicenseAvailable())
            {
                double remainingDays = LicenseController.GetLicenseRemainingDays();
                if (remainingDays <= 7) {
                    SetInformationMessage(InformationTypeEnum.Error, 
                        MultilanguangeController.GetText(MultiLanguageEnum.DIAS_RESTANTES_LICENCIA) 
                        + " " + ((int)remainingDays).ToString());
                }
                if (!LicenseController.CheckLicenseAttributes())
                {
                    SetInformationMessage(InformationTypeEnum.Error,
                 MultilanguangeController.GetText(MultiLanguageEnum.LICENCIA_NO_VALIDA));
                    return false;
                }

                return true;
            }
            else
            {
                SetInformationMessage(InformationTypeEnum.Error, 
                    MultilanguangeController.GetText(MultiLanguageEnum.LICENCIA_NO_VALIDA));
                return false;
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
            _greenLedImage = StyleController.GetImageResource(GREENLED);
            _redLedImage = StyleController.GetImageResource(REDLED);
        }
        private void InitializeDevices()
        {

            DEXDevice device = DeviceController.InitializeDevice();

            _deXDevice = device;

            this.Text = MultilanguangeController.GetText(MultiLanguageEnum.DISPOSITIVO)
                + ": " + DatabaseController.CurrentDepositary.ModeloId.Nombre;

            LoadStyles();

            try
            {
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
            VerifyIssues();

            VerifyForcedValueExtraction();

            VerifyConnections();

            VerifyUserData();

            VerifyTimeout();

            VerifyAvatar();

            VerifyOpenDoor();

            VerifyBagExtracted();

            VerifyPreviousFailedoperation();


        }

        private void VerifyIssues()
        {
            if (DeviceController.HasAnyIssue)
            {
                OperationblockingReasonEnum operationblockingReason = OperationblockingReasonEnum.None;

                if (DeviceController.CounterIssue)
                {
                    operationblockingReason = OperationblockingReasonEnum.CounterCommunicationError;
                    DatabaseController.CreateEvent(EventTypeEnum.Estado_Fuera_De_Servicio, ERROR_COMUNICACION_CONTADORA, String.Empty);
                }
                if (DeviceController.IoBoardIssue)
                {
                    operationblockingReason = OperationblockingReasonEnum.IoBoardCommunicationError;
                    DatabaseController.CreateEvent(EventTypeEnum.Estado_Fuera_De_Servicio,ERROR_COMUNICACION_PLACA, String.Empty);
                }
                if (DeviceController.BagIssue)
                {
                    operationblockingReason = OperationblockingReasonEnum.ContainerError;
                    DatabaseController.CreateEvent(EventTypeEnum.Estado_Fuera_De_Servicio, ERROR_CONTENEDOR, String.Empty);
                }

                if (DeviceController.PrinterIssue)
                {
                    operationblockingReason = OperationblockingReasonEnum.PrinterError;
                    DatabaseController.CreateEvent(EventTypeEnum.Estado_Fuera_De_Servicio, ERROR_IMPRESORA, String.Empty);

                }
                if (_operationBlockingForm == null)
                {
                    _operationBlockingForm = new OperationBlockingForm()
                    {
                         OperationBlockingReason = operationblockingReason,
                         Tag = this.Tag
                    };
                    _operationBlockingForm.LoadStyles();
                    _operationBlockingForm.ShowDialog();
                    _operationBlockingForm = null;
                }

            }
        }

        private void VerifyForcedValueExtraction()
        {
            if(DeviceController.BagRemovedForcefully )
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

                    DatabaseController.CreateEvent(EventTypeEnum.Estado_Fuera_De_Servicio, message, message);

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
        private void VerifyOpenDoor()
        {

            try
            {

                if (_device.IoBoardConnected)
                {
                    if (_device.IoBoardStatusProperty.GateState == IoBoardStatus.GATE_STATE.OPEN)

                    {

                        if (_blockingDialog == null &&
                            (DatabaseController.CurrentOperation == null ||
                            DatabaseController.CurrentOperation.Id != (long)OperationTypeEnum.ValueExtraction))
                        {
                            string message = MultilanguangeController.GetText(MultiLanguageEnum.PUERTA_ABIERTA);
                            AuditController.Log(LogTypeEnum.Exception, message, message);

                            DatabaseController.CreateEvent(EventTypeEnum.Apertura_de_Puerta, message, message);

                            _blockingDialog = new SystemBlockingDialog()
                            {
                                Tag = this.Tag,
                                MessageText = MultilanguangeController.GetText(MultiLanguageEnum.PUERTA_ABIERTA)
                            };
                            _blockingDialog.LoadStyles();
                            _blockingDialog.ShowDialog();
                            _blockingDialog = null;
                        }
                    }
                    else
                    {
                        VerifyConnections();
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
                                // Se asume retiro de bolsa
                                DatabaseController.CreateContainer();

                                PrintBagTicket();
                                _bagRemoved = true;
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
            return _device.IoBoardStatusProperty.BagState ==
                IoBoardStatus.BAG_STATE.BAG_STATE_INPLACE;
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
                            }

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
                    CounterPictureBox.Image = _greenLedImage;
                    DeviceController.CounterIssue = false;
                }
                else
                {
                    CounterPictureBox.Image = _redLedImage;
                    _device.CounterBoardReconnect();
                    DeviceController.CounterIssue = true;
                }

                _ioBoardStatus = _device.Status();

                // consulta el estado de la ioboard  si está conectada
                if (_device.IoBoardConnected)
                {
                    IoBoardPictureBox.Image = _greenLedImage;
                    //DeviceController.IoBoardIssue = false;
                }
                else
                {
                    IoBoardPictureBox.Image = _redLedImage;
                    _device.IoBoardReconnect();
                    DeviceController.IoBoardIssue = true;
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
            long remainingTime = TimeOutController.GetRemainingtime();

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

                    SucursalInfoLabel.Text =
                        MultilanguangeController.GetText(MultiLanguageEnum.SUCURSAL) + ": "
                        + DatabaseController.CurrentDepositary.SectorId.SucursalId.Nombre + Environment.NewLine
                        + MultilanguangeController.GetText(MultiLanguageEnum.SECTOR) + ": "
                        + DatabaseController.CurrentDepositary.SectorId.Nombre;

                    DepositaryLabel.Text = MultilanguangeController.GetText(MultiLanguageEnum.DEPOSITARIO) + ": "
                     + DatabaseController.CurrentDepositary.Nombre + Environment.NewLine
                     + MultilanguangeController.GetText(MultiLanguageEnum.CODIGO) + ": "
                     + DatabaseController.CurrentDepositary.CodigoExterno;

                    SetTurnAndDateTimeLabel();
                }

            }
            else
            {
                UserLabel.Text = String.Empty;
                EnterpriseLabel.Text = String.Empty;
                SucursalInfoLabel.Text = String.Empty;
                RemainingTimeLabel.Text = String.Empty;
                DepositaryLabel.Text = String.Empty;
                TurnAndDateTimeLabel.Text = String.Empty;
            }

        }

        private void SetTurnAndDateTimeLabel()
        {
            TurnAndDateTimeLabel.Text = MultilanguangeController.GetText(MultiLanguageEnum.TURNO) + " : ";

            if (DatabaseController.CurrentTurn == null)
            {
                TurnAndDateTimeLabel.Text += MultilanguangeController.GetText(MultiLanguageEnum.SIN_TURNO);
                AuditController.Log(LogTypeEnum.Exception,
                  MultilanguangeController.GetText(MultiLanguageEnum.SIN_TURNO),
                  MultilanguangeController.GetText(MultiLanguageEnum.SIN_TURNO));
            }
            else
            {
                string turnDate = string.Empty;
                if (DatabaseController.CurrentTurn.Fecha != null)
                    turnDate = " - " + ((DateTime)DatabaseController.CurrentTurn.Fecha).ToString("dd/MM/yyyy");
                TurnAndDateTimeLabel.Text += DatabaseController.CurrentTurn.TurnoDepositarioId.
                EsquemaDetalleTurnoId.Nombre + turnDate;
            }


            TurnAndDateTimeLabel.Text += Environment.NewLine + DateTime.Now.ToString("dd/MM/yyyy - HH:mm:ss");
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
                FormsController.OpenChildForm(new KeyboardInputForm(),
                    (Permaquim.Depositary.UI.Desktop.Components.CounterDevice)this.Tag);

        }

        private void LoadLanguageItems()
        {
            BreadCrumbText = MultilanguangeController.GetText(this.Name) +
                " - Version: " + Assembly.GetExecutingAssembly().GetName().Version.ToString();
            SetInformationMessage(InformationTypeEnum.None,
                MultilanguangeController.GetText(MultiLanguageEnum.TOQUE_PANTALLA_PARA_INICIAR));
        }

        private void LoadStyles()
        {
            HeadPanel.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.CabeceraAplicacion);
            MainPanel.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.FondoFormulario);
            BottomPanel.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.PieAplicacion);
            MainPictureBox.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.FondoFormulario);
            InformationLabel.ForeColor = StyleController.GetColor(Enumerations.ColorNameEnum.FuenteContraste);
            UserLabel.ForeColor = StyleController.GetColor(Enumerations.ColorNameEnum.FuenteContraste);
            EnterpriseLabel.ForeColor = StyleController.GetColor(Enumerations.ColorNameEnum.FuenteContraste);
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

            if (ConfigurationController.IsDevelopment())
                Login();
            else
            {

                //if (VerifySchedule())
                if (_device.CounterConnected && _device.IoBoardConnected)
                {
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
                            DatabaseController.CreateEvent(EventTypeEnum.Estado_Fuera_De_Servicio, message, message);
                            DeviceController.BagIssue = true;

                        }
                    }
                    else
                    {
                        Login();
                    }
                }
                else
                {
                    string message = MultilanguangeController.GetText(MultiLanguageEnum.ERROR_PUERTO);
                    SetInformationMessage(InformationTypeEnum.Error, message);
                    AuditController.Log(LogTypeEnum.Exception, message, message);
                    DatabaseController.CreateEvent(EventTypeEnum.Estado_Fuera_De_Servicio, message, message);
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
            if (closingcombination == 3)
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
            if (closingcombination == 3)
            {
                Application.Exit();
                AuditController.Log(LogTypeEnum.Information,
            MultilanguangeController.GetText(MultiLanguageEnum.APLICACION_CERRADA_MANUALMENTE),
            MultilanguangeController.GetText(MultiLanguageEnum.APLICACION_CERRADA_MANUALMENTE));

            }
        }
        private void PrintBagTicket()
        {
            if (ParameterController.PrintsBagExtraction)
            {
                for (int i = 0; i < ParameterController.PrintBagExtractionQuantity; i++)
                {
                    ReportController.PrintReport(ReportTypeEnum.ValueExtraction,
                        DatabaseController.GetEnvelopeLastContainerContentItems(),
                        DatabaseController.GetBillLastContainerContentItems(), i);
                }
            }
        }
    }
}

