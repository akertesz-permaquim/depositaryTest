using Newtonsoft.Json;
using Permaquim.Depositary.UI.Desktop.Components;
using Permaquim.Depositary.UI.Desktop.Controllers;
using Permaquim.Depositary.UI.Desktop.Global;
using Permaquim.Depositary.UI.Desktop.Helpers;
using Permaquim.Depositary.UI.Desktop.CustomExceptions;
using static Permaquim.Depositary.UI.Desktop.Global.Enumerations;
using Permaquim.Depositary.UI.Desktop.Forms;

namespace Permaquim.Depositary.UI.Desktop // 31/5/2022
{
    public partial class MainForm : System.Windows.Forms.Form
    {
        private const string DEPOSITARIO_NO_INICIALIZADO = "Depositario no inicializado.";
        private System.Windows.Forms.Timer _pollingTimer = new System.Windows.Forms.Timer();
        private int closingcombination = 0;
        private Image _greenLedImage;
        private Image _redLedImage;
        private Image _avatarImage;

        private int _greenStatusIndicator;
        private int _yellowStatusIndicator;
        private int _redStatusIndicator;
        private string _remainingTimeText;

        /// <summary>
        /// Instancias de los componentes que gestionan dispositivos
        /// </summary>
        CounterDevice _device = new();
        DEXDevice? _deXDevice = null;

        SystemBlockingDialog _blockingDialog = null;
 

        public string BreadCrumbText
        {
            get { return BreadcrumbLabel.Text; }
            set { BreadcrumbLabel.Text = value; }
        }


        public MainForm()
        {
            try
            {

                InitializeComponent();

                this.MainPanel.Width = this.Width;

                FormsController.MainFormInstance = this;

                // StartPosition was set to FormStartPosition.Manual in the properties window.
                Rectangle screen = Screen.PrimaryScreen.WorkingArea;
                this.Location = new Point(0, 0);
                this.Size = new Size(screen.Width, screen.Height);

                _pollingTimer = new System.Windows.Forms.Timer()
                {
                    Interval = DeviceController.GetPollingInterval(),
                    Enabled = false
                };
                _pollingTimer.Tick += PollingTimer_Tick;

                LoadLogo();
                _remainingTimeText = MultilanguangeController.GetText(MultiLanguageEnum.TIEMPO_RESTANTE);

            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show(ex.Message,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetInformationMessage(InformationTypeEnum.Error, ex.Message);
            }
            catch (System.FormatException ex)
            {
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                SetInformationMessage(InformationTypeEnum.Error, ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                AuditController.Log(ex);
                SetInformationMessage(InformationTypeEnum.Error, ex.Message);
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

                InitializeDevices();
                LoadLedImages();
                VerifyUserData();
                LoadParameters();
                LoadLanguageItems();
            }
            else
            {
                AuditController.Log(LogTypeEnum.Information, DEPOSITARIO_NO_INICIALIZADO, DEPOSITARIO_NO_INICIALIZADO);
                SetInformationMessage(InformationTypeEnum.Error, DEPOSITARIO_NO_INICIALIZADO);
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
            _greenLedImage = StyleController.GetImageResource("GREENLED");
            _redLedImage = StyleController.GetImageResource("REDLED");
        }
        private void InitializeDevices()
        {

            DEXDevice device = DeviceController.InitializeDevice();

            _deXDevice = device;

            this.Text = MultilanguangeController.GetText(MultiLanguageEnum.DISPOSITIVO) + ": " + device.DeviceName;
            
            LoadStyles();

            try
            {
                _device = new CounterDevice(device);
                _pollingTimer.Enabled = true;

                _device.SleepTimeout = DeviceController.GetSleepInterval();

                this.Tag = _device;


                // Evaluación de estado de la contadora y el ioBoard
                // Si está todo en órden, se libera la aplicación

                MainPanel.BringToFront();

                // Ejecuto la primera consulta al dispositivo. 
                // Puede que se encuentre en un estado intermedio en donde no se haya finalizado la 
                // Operación anterior.

                if (_device.CounterConnected)
                {
                    StatesResult statesResult = _device.Sense();
                    if (statesResult != null)
                    {
                        _device.PreviousState = statesResult.StatusInformation.OperatingState;

                        // Si el escrow está abierto se debe cerrar
                        if (_device.StateResultProperty.StatusInformation.OperatingState ==
                                StatusInformation.State.EscrowOpen ||
                                _device.StateResultProperty.StatusInformation.OperatingState ==
                                StatusInformation.State.PQWaitingTocloseEscrow)

                            _device.CloseEscrow();

                        // si por algun motivo el equipo se recupera de una transacción fallida, se cancela la operación.
                        if (_device.StateResultProperty.ModeStateInformation.ModeState == ModeStateInformation.Mode.DepositMode)
                        {
                             _device.RemoteCancel();
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

            VerifyUserData();

            VerifyBasicConfigurations();

            VerifyTimeout();

            VerifyAvatar();

            _device.Status();
            if (_device.IoBoardConnected)
            {
                VerifyOpenDoor();

                VerifyConnections();

                VerifyPreviousFailedoperation();
            }

        }
        private void VerifyBasicConfigurations()
        {
            string message = DatabaseController.GetBasicconfigurationMessage();
            if(message.Length > 0)
            {
                {
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
        }
        private void VerifyOpenDoor()
        {
            if (_device.IoBoardStatusProperty.GateState == IoBoardStatus.GATE_STATE.CLOSED)
            {
                VerifyConnections();
            }
            else
            {
                if (_blockingDialog == null &&
                    (DatabaseController.CurrentOperation == null ||
                    DatabaseController.CurrentOperation.Id != (long)OperationTypeEnum.ValueExtraction))
                {
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
        }

        private void VerifyPreviousFailedoperation()
        {
            if(FormsController.ActiveFormscount == 0)
            {
                // si quedó contenido en el escrow debe ser retirado
                if (_device.StateResultProperty.DeviceStateInformation.EscrowBillPresent)
                {
                    _device.OpenEscrow();
                    _pollingTimer.Enabled = false;
                    if (MessageBox.Show(
                        "Retire el contenido de la pre-bóveda para poder iniciar la operación",
                        "Error en operación previa", 
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        _pollingTimer.Enabled = false;
                        _device.CloseEscrow();
                    }

                }
                _device.RemoteCancel();
            }
        }

        private void VerifyConnections()
        {
         
            _device.Sense();
            // consulta el estado de la contadora si está conectada

            if (_device.CounterConnected)
            {
                CounterPictureBox.Image = _greenLedImage;
            }
            else
            {
                CounterPictureBox.Image = _redLedImage;
                //_device.CounterBoardReconnect();
            }

            IoBoardStatus ioBoardStatus = _device.Status();

            // consulta el estado de la ioboard  si está conectada
            if (_device.IoBoardConnected)
            {
                IoBoardPictureBox.Image = _greenLedImage;
            }
            else
            {
                IoBoardPictureBox.Image = _redLedImage;
                //_device.IoBoardReconnect();
            }
        }

        private void VerifyTimeout()
        {
            long remainingTime = TimeOutController.GetRemainingtime();

            if (remainingTime > 0)
            {
                RemainingTimeLabel.Visible = remainingTime > 0;

                RemainingTimeLabel.Text = _remainingTimeText +
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
            
            SetTurnAndDateTimeLabel();
        }

        private void SetTurnAndDateTimeLabel()
        {
            TurnAndDateTimeLabel.Text = MultilanguangeController.GetText(MultiLanguageEnum.TURNO) + " : ";

            if (DatabaseController.CurrentTurn == null)
                TurnAndDateTimeLabel.Text += MultilanguangeController.GetText(MultiLanguageEnum.SIN_TURNO);
            else
                TurnAndDateTimeLabel.Text += DatabaseController.CurrentTurn.TurnoDepositarioId.
                EsquemaDetalleTurnoId.Nombre;

            TurnAndDateTimeLabel.Text += Environment.NewLine +  DateTime.Now.ToString("dd/MM/yyyy - HH:mm:ss");
        }

        private void MainPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (VerifySchedule())
                Login();
            else
                SetInformationMessage(InformationTypeEnum.Error,
                    MultilanguangeController.GetText(MultiLanguageEnum.SIN_TURNO));
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
            BreadCrumbText = MultilanguangeController.GetText(this.Name);
            SetInformationMessage(InformationTypeEnum.None, MultilanguangeController.GetText(MultiLanguageEnum.TOQUE_PANTALLA_PARA_INICIAR));
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

            MainPictureBox.Image = StyleController.GetImageResource("Presentacion");
        }
        private void LoadLogo()
        {
            LogoPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            LogoPictureBox.Image = StyleController.GetLogo();
        }

        private void VerifyAvatar()
        {
            if (DatabaseController.CurrentUser != null )
            {
                if (AvatarPicturebox.Image == null)
                {
                    _avatarImage = ImageFromBase64Helper.
                        GetImageFromBase64String(DatabaseController.CurrentUser.Avatar);
                    AvatarPicturebox.Image = _avatarImage;
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

                if (VerifySchedule())
                    if (_device.CounterConnected && _device.IoBoardConnected)
                    {
                        Login();
                    }
                    else
                    {


                        SetInformationMessage(InformationTypeEnum.Error,
                                MultilanguangeController.GetText(MultiLanguageEnum.ERROR_PUERTO));
                    }
                else
                    SetInformationMessage(InformationTypeEnum.Error,
                    MultilanguangeController.GetText(MultiLanguageEnum.SIN_TURNO));
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
        public void SetInformationMessage(InformationTypeEnum type,string message)
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
    }
}
