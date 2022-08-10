﻿using Permaquim.Depositary.UI.Desktop.Components;
using Permaquim.Depositary.UI.Desktop.Controllers;
using Permaquim.Depositary.UI.Desktop.Global;
using static Permaquim.Depositary.UI.Desktop.Global.Enumerations;

namespace Permaquim.Depositary.UI.Desktop
{
    public partial class SystemBlockingDialog : Form
    {
         /// <summary>
        /// Timer para la consulta del estado del dispositivo
        /// </summary>
        private System.Windows.Forms.Timer _pollingTimer = new System.Windows.Forms.Timer();
        /// <summary>
        /// Instancia del dispositivo
        /// </summary>
        public CounterDevice _device { get; set; }
        public SystemBlockingDialog()
        {
            InitializeComponent();
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
        public void LoadStyles()
        {
            this.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.BotonCancelar);
            InformationLabel.ForeColor = StyleController.GetColor(Enumerations.ColorNameEnum.FuenteContraste);
        }
        public void LoadLanguageItems()
        {
            InformationLabel.Text = MultilanguangeController.GetText(MultiLanguageEnum.PUERTA_ABIERTA);
        }
        private void SystemBlockingDialog_Load(object sender, EventArgs e)
        {

            _device = (Permaquim.Depositary.UI.Desktop.Components.CounterDevice)this.Tag;

            _pollingTimer = new System.Windows.Forms.Timer()
            {
                Interval = DeviceController.GetPollingInterval(),
                Enabled = true
            };
            _pollingTimer.Tick += PoolTimer_Tick;

            LoadStyles();
            LoadLanguageItems();
        }
        private void PoolTimer_Tick(object? sender, EventArgs e)
        {

            if (_device != null && _device.IoBoardConnected)
            {

                if (_device.IoBoardStatusProperty.GateState == IoBoardStatus.GATE_STATE.CLOSED)
                {
                    this.DialogResult = DialogResult.OK;
                    FormsController.HideInstance(this);
                }


            }
        }
    }
}
