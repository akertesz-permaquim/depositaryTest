using Newtonsoft.Json;
using Permaquim.Depositary.UI.Desktop.Components;
using Permaquim.Depositary.UI.Desktop.Controllers;
using Permaquim.Depositary.UI.Desktop.Helpers;

namespace Permaquim.Depositary.UI.Desktop // 31/5/2022
{
    public partial class MainForm : System.Windows.Forms.Form
    {

        private System.Windows.Forms.Timer _poolingTimer = new System.Windows.Forms.Timer();

        /// <summary>
        /// Instancias de los componentes que gestionan dispositivos
        /// </summary>
        Device _device = null;
        DE50Device? _de50Device = null;

        public MainForm()
        {
            InitializeComponent();

            AppController.MainFormInstance = this;

            // StartPosition was set to FormStartPosition.Manual in the properties window.
            Rectangle screen = Screen.PrimaryScreen.WorkingArea;
            this.Location = new Point(0,0);
            this.Size = new Size(screen.Width, screen.Height);
            _poolingTimer = new System.Windows.Forms.Timer()
            {
                Interval = 200,
                Enabled = true
            };
            _poolingTimer.Tick += PoolingTimer_Tick;

            LoadLogo();

            SetOwnerData();
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
            this.Text =  MultilanguangeController.GetText("DEVICE") + ": " + device.DeviceName;
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
                    _device.PreviousState = _device.Sense().StatusInformation.OperatingState;

                    // Setea el estado de la contadora previo al inicio del pooling 
                    //_device.PreviousState = _device.StateResultProperty.StatusInformation.OperatingState;

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
                else
                {
                    MessageBox.Show(MultilanguangeController.GetText("DEVICE_NOT_CONNECTED"), 
                        MultilanguangeController.GetText("DEVICE_NOT_CONNECTED"), MessageBoxButtons.OK,
                        MessageBoxIcon.Error,MessageBoxDefaultButton.Button1);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
        private void PoolingTimer_Tick(object? sender, EventArgs e)
        {
            DateTimeLabel.Text = DateTime.Now.ToString("dd/MM/yyyy - HH:mm:ss");

  
            // consulta el estado de la contadora si está conectada
            if (_device.CounterConnected)
            {
                CounterLabel.Text = MultilanguangeController.GetText("COUNTER_ONLINE");
                CounterLabel.ForeColor = Color.Green;
                _device.Sense();
            }

            // consulta el estado de la ioboard  si está conectada
            if (_device.IoBoardConnected)
            {
                IoBoardLabel.Text = MultilanguangeController.GetText("IO_BOARD_ONLINE");
                IoBoardLabel.ForeColor = Color.Green;
                _device.Status();
            }
            LoadAvatar();
            SetUserData();
        }

        private void SetOwnerData()
        {
            OwnerDataLabel.Text = "Permaquim :.: Depositario. Versión 0.1";
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
            if (DatabaseController.CurrentUser != null)
                AppController.OpenChildForm(new OperationForm(),
                    (Permaquim.Depositary.UI.Desktop.Components.Device)this.Tag);

            else
                AppController.OpenChildForm(new KeyboardInputForm(),
                    (Permaquim.Depositary.UI.Desktop.Components.Device)this.Tag);
        }
       private void LoadStyles()
        {
            TopPanel.BackColor = StyleController.GetColor("Cabecera");
            HeadPanel.BackColor = StyleController.GetColor("Color2");
            MainPanel.BackColor = StyleController.GetColor("Contenido");
            BottomPanel.BackColor = StyleController.GetColor("Pie");
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
        }
        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
