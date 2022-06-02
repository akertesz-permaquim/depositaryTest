using Newtonsoft.Json;
using Permaquim.Depositary.UI.Desktop.Components;
using Permaquim.Depositary.UI.Desktop.Controllers;

namespace Permaquim.Depositary.UI.Desktop // 31/5/2022
{
    public partial class MainForm : System.Windows.Forms.Form
    {
        private const string LOGO_IMAGE_FILE = @"\Resources\Images\Logo.png";
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
            this.Text = "Device: " + device.DeviceName;
            _device = new Device(device);

            this.Tag = _device;

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
                    MessageBox.Show("El dispositivo contador no está conectado!","No conectado.",MessageBoxButtons.OK,
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
            DateTimeLabel.Text = DateTime.Now.ToString("dd MM yyyy - HH mm ss");

            // consulta el estado de la contadora
            _device.Sense();
            // consulta el estado de la ioboard
            _device.Status();


            if (_device.CounterConnected)
            {
                CounterLabel.Text = "Contadora online";
                CounterLabel.ForeColor = Color.Green;
            }
            if (_device.IoBoardConnected)
            {
                IoBoardLabel.Text = "IO board online";
                IoBoardLabel.ForeColor = Color.Green;
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
                UserLabel.Text = "Usuario: " +
                DatabaseController.CurrentUser.Apellido + " " + DatabaseController.CurrentUser.Nombre;
                EnterpriseLabel.Text = "Empresa: " + 
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
             AppController.OpenChildForm(new KeyboardInputForm(), 
                 (Permaquim.Depositary.UI.Desktop.Components.Device)this.Tag);
        }
       
        private void LoadLogo()
        {
            LogoPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            var appPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            LogoPictureBox.Load(appPath + LOGO_IMAGE_FILE);
        }

        private void LoadAvatar()
        {
            if (DatabaseController.CurrentUser != null)
            {
                byte[] bytes = Convert.FromBase64String(DatabaseController.CurrentUser.Avatar
                    .Replace("data:image/png;base64,", String.Empty)
                    .Replace("data:image/jpeg;base64,", String.Empty)
                    .Replace("data:image/webp;base64,", String.Empty));

                using (MemoryStream ms = new MemoryStream(bytes))
                {
                    AvatarPicturebox.Image = Image.FromStream(ms);
                }
            }
        }
        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
