using Newtonsoft.Json;
using Permaquim.Depositary.UI.Desktop.Components;
using Permaquim.Depositary.UI.Desktop.Controllers;
using Permaquim.Depositary.UI.Desktop.Global;
using Permaquim.Depositary.UI.Desktop.Helpers;
using static Permaquim.Depositary.UI.Desktop.Global.Enumerations;

namespace Permaquim.Depositary.UI.Desktop // 31/5/2022
{
    public partial class MainForm : System.Windows.Forms.Form
    {
        private System.Windows.Forms.Timer _pollingTimer = new System.Windows.Forms.Timer();
        private int closingcombination = 0;
        private Image _greenLedImage;
        private Image _redLedImage;
        private string _remainingTimeText;

        /// <summary>
        /// Instancias de los componentes que gestionan dispositivos
        /// </summary>
        Device _device = null;
        DE50Device? _de50Device = null;

        SystemBlockingDialog _blockingDialog;

        public MainForm()
        {
            InitializeComponent();

            FormsController.MainFormInstance = this;

            StartMessageLabel.Parent = MainPictureBox;

            // StartPosition was set to FormStartPosition.Manual in the properties window.
            Rectangle screen = Screen.PrimaryScreen.WorkingArea;
            this.Location = new Point(0,0);
            this.Size = new Size(screen.Width, screen.Height);
            _pollingTimer = new System.Windows.Forms.Timer()
            {
                Interval = DeviceController.GetPollingInterval(),
                Enabled = true
            };
            _pollingTimer.Tick += PollingTimer_Tick;

            LoadLogo();
            _remainingTimeText = MultilanguangeController.GetText(MultiLanguageEnum.TIEMPO_RESTANTE);
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            InitializeDevices();
            LoadLedImages();
        }
        private void LoadLedImages()
        {
            _greenLedImage = StyleController.GetImageResource("GREENLED");
            _redLedImage = StyleController.GetImageResource("REDLED");
        }
        private void InitializeDevices()
        {
            // TODO: Obtener de la DB
            string str = File.ReadAllText(Directory.GetCurrentDirectory() + @"\Devices\DE50.Json");

            var device = JsonConvert.DeserializeObject<DE50Device>(str);

            _de50Device = device;
            this.Text =  MultilanguangeController.GetText(MultiLanguageEnum.DISPOSITIVO) + ": " + device.DeviceName;
            _device = new Device(device);

            this.Tag = _device;

            LoadStyles();

            // Evaluación de estado de la contadora y el ioBoard
            // Si está todo en órden, se libera la aplicación

            InformationPanel.SendToBack();
            MainPanel.BringToFront();

            // Ejecuto la primera consulta al dispositivo. 
            // Puede que se encuentre en un estado intermedio en donde no se haya finalizado la 
            // Operación anterior.
            try
            {
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
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
        private void PollingTimer_Tick(object? sender, EventArgs e)
        {

            DateTimeLabel.Text = DateTime.Now.ToString("dd/MM/yyyy - HH:mm:ss");
            EvaluateTimeout();

            _device.Status();
            if (_device.IoBoardConnected)
            {
                if (_device.IoBoardStatusProperty.GateState == IoBoardStatus.GATE_STATE.CLOSED)
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
                        _device.CounterBoardReconnect();
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
                        _device.IoBoardReconnect();
                    }

                }
                else
                {
                    if (_blockingDialog == null &&
                        (DatabaseController.CurrentOperation == null ||
                        DatabaseController.CurrentOperation.Id != (long)OperationTypeEnum.ValueExtraction))
                    {
                        _blockingDialog = new SystemBlockingDialog()
                        {
                            Tag = this.Tag
                        };
                        _blockingDialog.LoadStyles();
                        _blockingDialog.ShowDialog();
                        _blockingDialog = null;
                    }


                }
            }

        }

        private void EvaluateTimeout()
        {
            long remainingTime = TimeOutController.GetRemainingtime();
            RemainingTimeLabel.Visible = remainingTime > 0;

            RemainingTimeLabel.Text = _remainingTimeText +
                remainingTime.ToString();
            if (remainingTime > 10)
                RemainingTimeLabel.ForeColor = Color.Green;
            if (remainingTime < 10)
                RemainingTimeLabel.ForeColor = Color.Yellow;
            if (remainingTime < 5)
                RemainingTimeLabel.ForeColor = Color.Red;
        }

        private void SetUserData()
        {
            if (DatabaseController.CurrentUser != null)
            {
                UserLabel.Text = MultilanguangeController.GetText(MultiLanguageEnum.USUARIO) + ": " +
                DatabaseController.CurrentUser.Apellido + " " + DatabaseController.CurrentUser.Nombre;
                EnterpriseLabel.Text = MultilanguangeController.GetText(MultiLanguageEnum.EMPRESA) + ": " + 
                DatabaseController.CurrentUser.EmpresaId.Nombre;
            }
            else
            {
                UserLabel.Text = String.Empty;
                EnterpriseLabel.Text = String.Empty;
            }
        }

        private void MainPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (VerifySchedule())
                Login();
            else
                FormsController.OpenChildForm(new OperationBlockingForm() 
                { OperationBlockingReason = Enumerations.OperationblockingReasonEnum.NoTurn},
                    (Permaquim.Depositary.UI.Desktop.Components.Device)this.Tag);
        }

        private void Login()
        {
            MainPictureBox.Image = null;
            if (DatabaseController.CurrentUser != null)
                FormsController.OpenChildForm(new OperationForm(),
                    (Permaquim.Depositary.UI.Desktop.Components.Device)this.Tag);

            else
                FormsController.OpenChildForm(new KeyboardInputForm(),
                    (Permaquim.Depositary.UI.Desktop.Components.Device)this.Tag);

        }

        private void LoadStyles()
        {
            HeadPanel.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.CabeceraAplicacion);
            MainPanel.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.FondoFormulario);
            BottomPanel.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.PieAplicacion);
            MainPictureBox.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.FondoFormulario);
            StartMessageLabel.ForeColor = StyleController.GetColor(Enumerations.ColorNameEnum.FuenteContraste);
            UserLabel.ForeColor = StyleController.GetColor(Enumerations.ColorNameEnum.FuenteContraste);
            EnterpriseLabel.ForeColor = StyleController.GetColor(Enumerations.ColorNameEnum.FuenteContraste);
            DateTimeLabel.ForeColor = StyleController.GetColor(Enumerations.ColorNameEnum.FuenteContraste);

            MainPictureBox.Image = StyleController.GetImageResource("Presentacion");
            LoadAvatar();
            SetUserData();
        }
        private void LoadLogo()
        {
            LogoPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            LogoPictureBox.Image = StyleController.GetLogo();
        }

        private void LoadAvatar()
        {
            if (DatabaseController.CurrentUser != null)
            {
                AvatarPicturebox.Image = ImageFromBase64Helper.
                    GetImageFromBase64String(DatabaseController.CurrentUser.Avatar);
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
            if (VerifySchedule())
                Login();
            else
                FormsController.OpenChildForm(new OperationBlockingForm()
                { OperationBlockingReason = Enumerations.OperationblockingReasonEnum.NoTurn },
                    (Permaquim.Depositary.UI.Desktop.Components.Device)this.Tag);
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

        }
    }
}
