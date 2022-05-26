using Newtonsoft.Json;
using Permaquim.Depositary.UI.Desktop.Components;
using Permaquim.Depositary.UI.Desktop.Controllers;

namespace Permaquim.Depositary.UI.Desktop
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
            _device.Sense();

            // Setea el estado de la contadora previo al inicio del pooling 
            _device.PreviousState = _device.StateResultProperty.StatusInformation.OperatingState;


            // Si el escrow está abierto se debe cerrar
            if (_device.StateResultProperty.StatusInformation.OperatingState ==
                    StatusInformation.State.EscrowOpen ||
                    _device.StateResultProperty.StatusInformation.OperatingState ==
                    StatusInformation.State.PQWaitingTocloseEscrow)

            _device.CloseEscrow();

            // si por algun motivo el equipo se recupera de una transacción fallida, se cancela la operación.
            if (_device.StateResultProperty.ModeStateInformation.ModeState ==  ModeStateInformation.Mode.DepositMode)
            {
                _device.RemoteCancel();
            }
                    
        }
        private void PoolingTimer_Tick(object? sender, EventArgs e)
        {
            DateTimeLabel.Text = DateTime.Now.ToString("dd MM yyyy - HH mm ss");

            _device.Sense();
            _device.Status();

            if (_device.CounterConnected)
            {
                labelContadora.Text = "Contadora online";
                labelContadora.ForeColor = Color.Green;
            }
            if (_device.IoBoardConnected)
            {
                labelIoboard.Text = "IO board online";
                labelIoboard.ForeColor = Color.Green;
            }
        }

        private void SetOwnerData()
        {
            OwnerDataLabel.Text = "Permaquim :.: Depositario. Versión 0.1";
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

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
