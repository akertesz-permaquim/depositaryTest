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
    public partial class SystemBlockingDialog : Form
    {
        /// <summary>
        /// Timer para la consulta del estado del dispositivo
        /// </summary>
        private System.Windows.Forms.Timer _pollingTimer = new System.Windows.Forms.Timer();
        /// <summary>
        /// Instancia del dispositivo
        /// </summary>
        public Device _device { get; set; }
        public SystemBlockingDialog()
        {
            InitializeComponent();
        }

        public void LoadStyles()
        {
            this.BackColor = StyleController.GetColor(StyleController.ColorNameEnum.Contenido);
            InformationLabel.Text= MultilanguangeController.GetText("PUERTA_ABIERTA");
            InformationLabel.ForeColor = StyleController.GetColor(StyleController.ColorNameEnum.TextoError);
        }

        private void SystemBlockingDialog_Load(object sender, EventArgs e)
        {

            _device = (Permaquim.Depositary.UI.Desktop.Components.Device)this.Tag;

            _pollingTimer = new System.Windows.Forms.Timer()
            {
                Interval = DeviceController.GetPollingInterval(),
                Enabled = true
            };
            _pollingTimer.Tick += PoolTimer_Tick;

            LoadStyles();
        }
        private void PoolTimer_Tick(object? sender, EventArgs e)
        {
            if (_device != null && _device.IoBoardConnected)
            {

                if (_device.IoBoardStatusProperty.GateState == IoBoardStatus.GATE_STATE.CLOSED)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }


            }
        }
    }
}
