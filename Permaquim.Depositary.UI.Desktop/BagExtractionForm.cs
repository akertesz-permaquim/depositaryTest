using Permaquim.Depositary.UI.Desktop.Components;
using Permaquim.Depositary.UI.Desktop.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Permaquim.Depositary.UI.Desktop
{
    public partial class BagExtractionForm : Form
    {
        private enum BagExtractionProcessEnum
        {
            None = 0,
            GateReleased = 1,
            BagExtracting = 2,
            BagExtracted = 3,
            ProcessFinished = 4
        }
        public Device _device { get; set; }
        /// <summary>
        /// Timer para la consulta del estado del dispositivo
        /// </summary>
        private System.Windows.Forms.Timer _pollingTimer = new System.Windows.Forms.Timer();

        private BagExtractionProcessEnum _bagExtractionProcess = BagExtractionProcessEnum.None;

        CustomButton _gateButton = new CustomButton();
        CustomButton _bagButton = new CustomButton();
        CustomButton _confirmButton = new CustomButton();

        public BagExtractionForm()
        {
            InitializeComponent();
        }

        private void BagExtractionForm_Load(object sender, EventArgs e)
        {
             _device = (Permaquim.Depositary.UI.Desktop.Components.Device)this.Tag;

            _pollingTimer = new System.Windows.Forms.Timer()
            {
                Interval = 200,
                Enabled = true
            };
            _pollingTimer.Tick += PollTimer_Tick;

            LoadStyles();
            LoadGateButton();
            LoadBagButton();
            LoadBackButton();
        }
        private void PollTimer_Tick(object? sender, EventArgs e)
        {
            if (_device != null && _device.IoBoardConnected)
            {
                // Muestra el estado del hardware
                ShowHardwareMonitorData();
                // Procesa los estados 
                ProcessDeviceStatus();
            }
        }
        private void ShowHardwareMonitorData()
        {

        }
        private void ProcessDeviceStatus()
        {

            BagStatusLabel.Text = "BagStatus: " + Enum.GetName(typeof(IoBoardStatus.BAG_STATE), 
                _device.IoBoardStatusProperty.BagState);
            ShutterStatusLabel.Text = "Shutter Status: " + Enum.GetName(typeof(IoBoardStatus.SHUTTER_STATE), 
                _device.IoBoardStatusProperty.ShutterState);
            BagAproveStatelabel.Text = "Bag Aprove Status: " + Enum.GetName(typeof(IoBoardStatus.BAG_APROVE_STATE), 
                _device.IoBoardStatusProperty.BagAproveState);
            LockStateLabel.Text = "Lock Status: " + Enum.GetName(typeof(IoBoardStatus.LOCK_STATE), 
                _device.IoBoardStatusProperty.LockState);
            GatelStatusLabel.Text = "BagStatus: " + Enum.GetName(typeof(IoBoardStatus.GATE_STATE), 
                _device.IoBoardStatusProperty.GateState);
            
            // si se detecta la apertura de la puerta, se asume que se inicia el proceso
            if (_device.IoBoardStatusProperty.GateState == IoBoardStatus.GATE_STATE.OPEN)
                _bagExtractionProcess = BagExtractionProcessEnum.GateReleased;
            if (_device.IoBoardStatusProperty.BagState == IoBoardStatus.BAG_STATE.BAG_STATE_REMOVED)
                _bagExtractionProcess = BagExtractionProcessEnum.BagExtracted;
            if (_device.IoBoardStatusProperty.BagState == IoBoardStatus.BAG_STATE.BAG_STATE_INPLACE &&
                _bagExtractionProcess == BagExtractionProcessEnum.BagExtracted)
                _bagExtractionProcess = BagExtractionProcessEnum.ProcessFinished;

            VerifButtonsVisibility();

        }

        private void VerifButtonsVisibility()
        {
  
            _gateButton.Visible = _bagExtractionProcess == BagExtractionProcessEnum.None;
            _bagButton.Visible = _bagExtractionProcess == BagExtractionProcessEnum.GateReleased;
            _confirmButton.Visible = _bagExtractionProcess == BagExtractionProcessEnum.ProcessFinished;

        }
        private void LoadGateButton()
        {
           
            _gateButton.BackColor = StyleController.GetColor(StyleController.ColorNameEnum.BotonAceptar);
            _gateButton.BackgroundColor = StyleController.GetColor(StyleController.ColorNameEnum.BotonAceptar);
            _gateButton.BorderColor = StyleController.GetColor(StyleController.ColorNameEnum.BotonAceptar);
            _gateButton.BorderRadius = 5;
            _gateButton.BorderSize = 0;
            _gateButton.FlatAppearance.BorderSize = 0;
            _gateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            _gateButton.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            _gateButton.ForeColor = StyleController.GetColor(StyleController.ColorNameEnum.FuenteContraste);
            _gateButton.Location = new System.Drawing.Point(3, 3);
            _gateButton.Name = "GateButton";
            _gateButton.Size = new System.Drawing.Size(293, 77);
            _gateButton.TabIndex = 3;
            _gateButton.Text = MultilanguangeController.GetText("ABRIR_PUERTA");
            _gateButton.TextColor = StyleController.GetColor(StyleController.ColorNameEnum.FuenteContraste);
            _gateButton.UseVisualStyleBackColor = false;
            _gateButton.Visible = false;


            this.MainPanel.Controls.Add(_gateButton);


            _gateButton.Click += new System.EventHandler(GateButton_Click);
        }

        private void LoadConfirmButton()
        {

            _confirmButton.BackColor = StyleController.GetColor(StyleController.ColorNameEnum.BotonAceptar);
            _confirmButton.BackgroundColor = StyleController.GetColor(StyleController.ColorNameEnum.BotonAceptar);
            _confirmButton.BorderColor = StyleController.GetColor(StyleController.ColorNameEnum.BotonAceptar);
            _confirmButton.BorderRadius = 5;
            _confirmButton.BorderSize = 0;
            _confirmButton.FlatAppearance.BorderSize = 0;
            _confirmButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            _confirmButton.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            _confirmButton.ForeColor = StyleController.GetColor(StyleController.ColorNameEnum.FuenteContraste);
            _confirmButton.Location = new System.Drawing.Point(3, 3);
            _confirmButton.Name = "ConfirmButton";
            _confirmButton.Size = new System.Drawing.Size(293, 77);
            _confirmButton.TabIndex = 3;
            _confirmButton.Text = MultilanguangeController.GetText("CONFIRMAR_BOLSA");
            _confirmButton.TextColor = StyleController.GetColor(StyleController.ColorNameEnum.FuenteContraste);
            _confirmButton.UseVisualStyleBackColor = false;
            _confirmButton.Visible = false;


            this.MainPanel.Controls.Add(_gateButton);


            _gateButton.Click += new System.EventHandler(GateButton_Click);
        }
        private void LoadBagButton()
        {
           
            _bagButton.BackColor = StyleController.GetColor(StyleController.ColorNameEnum.BotonAceptar);
            _bagButton.BackgroundColor = StyleController.GetColor(StyleController.ColorNameEnum.BotonAceptar);
            _bagButton.BorderColor = StyleController.GetColor(StyleController.ColorNameEnum.BotonAceptar);
            _bagButton.BorderRadius = 5;
            _bagButton.BorderSize = 0;
            _bagButton.FlatAppearance.BorderSize = 0;
            _bagButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            _bagButton.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            _bagButton.ForeColor = StyleController.GetColor(StyleController.ColorNameEnum.FuenteContraste);
            _bagButton.Location = new System.Drawing.Point(3, 3);
            _bagButton.Name = "GayButton";
            _bagButton.Size = new System.Drawing.Size(293, 77);
            _bagButton.TabIndex = 3;
            _bagButton.Text = MultilanguangeController.GetText("EXTRAER_CONTENEDOR");
            _bagButton.TextColor = StyleController.GetColor(StyleController.ColorNameEnum.FuenteContraste);
            _bagButton.UseVisualStyleBackColor = false;
            _bagButton.Visible = false;

            this.MainPanel.Controls.Add(_bagButton);

            _bagButton.Click += new System.EventHandler(BagButton_Click);
        }

        private void LoadBackButton()
        {
            CustomButton backButton = new CustomButton();
            backButton.BackColor = StyleController.GetColor(StyleController.ColorNameEnum.BotonEstandar);
            backButton.BackgroundColor = StyleController.GetColor(StyleController.ColorNameEnum.BotonEstandar);
            backButton.BorderColor = StyleController.GetColor(StyleController.ColorNameEnum.BotonEstandar);
            backButton.BorderRadius = 5;
            backButton.BorderSize = 0;
            backButton.FlatAppearance.BorderSize = 0;
            backButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            backButton.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            backButton.ForeColor = StyleController.GetColor(StyleController.ColorNameEnum.FuenteContraste);
            backButton.Location = new System.Drawing.Point(3, 3);
            backButton.Name = "BackButton";
            backButton.Size = new System.Drawing.Size(293, 77);
            backButton.TabIndex = 3;
            backButton.Text = MultilanguangeController.GetText("Salir");
            backButton.TextColor = StyleController.GetColor(StyleController.ColorNameEnum.FuenteContraste);
            backButton.UseVisualStyleBackColor = false;

            this.MainPanel.Controls.Add(backButton);

            backButton.Click += new System.EventHandler(BackButton_Click);
        }
        private void GateButton_Click(object sender, EventArgs e)
        {
            _device.Unlock();
            _bagExtractionProcess = BagExtractionProcessEnum.GateReleased;
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            DatabaseController.UpdateContainer(ContainerTextBox.Texts.Trim());
        }
        private void BagButton_Click(object sender, EventArgs e)
        {

            _bagExtractionProcess = BagExtractionProcessEnum.BagExtracting;
        }
        private void BackButton_Click(object sender, EventArgs e)
        {
            AppController.OpenChildForm(new OperationForm(), _device);
            this.Close();
        }
        private void LoadStyles()
        {
            this.BackColor = StyleController.GetColor(StyleController.ColorNameEnum.Contenido);
        }
    }
}
