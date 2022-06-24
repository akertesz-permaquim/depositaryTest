﻿using Newtonsoft.Json;
using Permaquim.Depositary.UI.Desktop.Components;
using Permaquim.Depositary.UI.Desktop.Controllers;
using Permaquim.Depositary.UI.Desktop.Global;
using Permaquim.Depositary.UI.Desktop.Helpers;

namespace Permaquim.Depositary.UI.Desktop // 31/5/2022
{
    public partial class MainForm : System.Windows.Forms.Form
    {
        private const int VALUE_EXTRACT_OPERATION = 7;
        private System.Windows.Forms.Timer _pollingTimer = new System.Windows.Forms.Timer();
        private int closingcombination = 0;

        /// <summary>
        /// Instancias de los componentes que gestionan dispositivos
        /// </summary>
        Device _device = null;
        DE50Device? _de50Device = null;

        SystemBlockingDialog _blockingDialog;

        public MainForm()
        {
            InitializeComponent();

            AppController.MainFormInstance = this;

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
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            InitializeDevices();
        }

        private void InitializeDevices()
        {
            // TODO: Obtener de la DB
            string str = File.ReadAllText(Directory.GetCurrentDirectory() + @"\Devices\DE50.Json");

            var device = JsonConvert.DeserializeObject<DE50Device>(str);

            _de50Device = device;
            this.Text =  MultilanguangeController.GetText("DISPOSITIVO") + ": " + device.DeviceName;
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
            
            _device.Status();
            if (_device.IoBoardConnected)
            {
                if (_device.IoBoardStatusProperty.GateState == IoBoardStatus.GATE_STATE.CLOSED)
                {

                    _device.Sense();
                    // consulta el estado de la contadora si está conectada
                    if (_device.CounterConnected)
                    {
                        CounterPictureBox.Image = StyleController.GetImageResource("GREENLED");
                    }
                    else
                    {
                        CounterPictureBox.Image = StyleController.GetImageResource("REDLED");
                        _device.CounterBoardReconnect();
                    }

                    IoBoardStatus ioBoardStatus = _device.Status();

                    // consulta el estado de la ioboard  si está conectada
                    if (_device.IoBoardConnected)
                    {
                        IoBoardPictureBox.Image = StyleController.GetImageResource("GREENLED");
                    }
                    else
                    {
                        IoBoardPictureBox.Image = StyleController.GetImageResource("REDLED");
                        _device.IoBoardReconnect();
                    }

                }
                else
                {
                    if (_blockingDialog == null &&
                        (DatabaseController.CurrentOperation == null ||
                        DatabaseController.CurrentOperation.Id != VALUE_EXTRACT_OPERATION))
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
            LoadAvatar();
            SetUserData();
        }

        private void SetUserData()
        {
            if (DatabaseController.CurrentUser != null)
            {
                UserLabel.Text = MultilanguangeController.GetText("USUARIO") + ": " +
                DatabaseController.CurrentUser.Apellido + " " + DatabaseController.CurrentUser.Nombre;
                EnterpriseLabel.Text = MultilanguangeController.GetText("EMPRESA") + ": " + 
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
                AppController.OpenChildForm(new OperationBlockingForm() 
                { OperationBlockingReason = Enumerations.OperationblockingReasonEnum.NoTurn},
                    (Permaquim.Depositary.UI.Desktop.Components.Device)this.Tag);
        }

        private void Login()
        {
            if (DatabaseController.CurrentUser != null)
                AppController.OpenChildForm(new OperationForm(),
                    (Permaquim.Depositary.UI.Desktop.Components.Device)this.Tag);

            else
                AppController.OpenChildForm(new KeyboardInputForm(),
                    (Permaquim.Depositary.UI.Desktop.Components.Device)this.Tag);
            MainPictureBox.Image = null;

        }

        private void LoadStyles()
        {
            HeadPanel.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.Cabecera);
            MainPanel.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.Contenido);
            BottomPanel.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.Pie);
            MainPictureBox.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.Contenido);
            StartMessageLabel.ForeColor = StyleController.GetColor(Enumerations.ColorNameEnum.FuenteContraste);
            UserLabel.ForeColor = StyleController.GetColor(Enumerations.ColorNameEnum.FuenteContraste);
            EnterpriseLabel.ForeColor = StyleController.GetColor(Enumerations.ColorNameEnum.FuenteContraste);
            DateTimeLabel.ForeColor = StyleController.GetColor(Enumerations.ColorNameEnum.FuenteContraste);

            //MainPictureBox.Image = StyleController.GetImageResource("Presentacion");
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
                AppController.OpenChildForm(new OperationBlockingForm()
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
            closingcombination += 1;
            if (closingcombination == 4)
                Application.Exit();
        }
    }
}
