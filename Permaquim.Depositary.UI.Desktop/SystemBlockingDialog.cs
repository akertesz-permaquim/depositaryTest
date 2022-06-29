using Permaquim.Depositary.UI.Desktop.Components;
using Permaquim.Depositary.UI.Desktop.Controllers;
using Permaquim.Depositary.UI.Desktop.Global;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
        public Device _device { get; set; }
        public SystemBlockingDialog()
        {
            InitializeComponent();
            TimeOutController.Reset();
        }

        public void LoadStyles()
        {
            this.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.FondoFormulario);
            InformationLabel.ForeColor = StyleController.GetColor(Enumerations.ColorNameEnum.TextoError);
        }
        public void LoadLanguageItems()
        {
            InformationLabel.Text = MultilanguangeController.GetText(MultiLanguageEnum.PUERTA_ABIERTA);
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
