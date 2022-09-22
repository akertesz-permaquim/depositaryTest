using Permaquim.Depositary.UI.Desktop.Builders;
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

namespace Permaquim.Depositary.UI.Desktop.Forms
{
    public partial class DeviceErrorForm : Form
    {
        CounterDevice _device = null;
        private System.Windows.Forms.Timer _pollingTimer = new System.Windows.Forms.Timer();
        public DeviceErrorForm()
        {
            InitializeComponent();
            CenterPanel();

            LoadStyles();
            LoadUnJamButton();

            TimeOutController.Reset();
            _pollingTimer = new System.Windows.Forms.Timer()
            {
                Interval = DeviceController.GetPollingInterval()
            };
            _pollingTimer.Tick += PollingTimer_Tick;
            _pollingTimer.Enabled = false;
        }

        private void DeviceErrorForm_Load(object sender, EventArgs e)
        {
            _device = (Permaquim.Depositary.UI.Desktop.Components.CounterDevice)this.Tag;
        }
        private void PollingTimer_Tick(object? sender, EventArgs e)
        {
  

            if (!_device.StateResultProperty.ErrorStateInformation.AbnormalDevice
                && !_device.StateResultProperty.ErrorStateInformation.AbnormalStorage
                && !_device.StateResultProperty.ErrorStateInformation.CountingError
                && !_device.StateResultProperty.ErrorStateInformation.Jamming
                )
            {
                this.DialogResult = DialogResult.None;
                FormsController.HideInstance(this);
            }
            else
            {
                if (!_device.StateResultProperty.DeviceStateInformation.EscrowBillPresent 
                    && _device.StateResultProperty.DoorStateInformation.Escrow)
                {
                    _device.CloseEscrow();
                    Thread.Sleep(500);
                }

                if (!_device.StateResultProperty.DoorStateInformation.Escrow)
                {
                    _device.NormalErrorRecoveryMode();
                    Thread.Sleep(500);
                   // _device.StoringErrorRecoveryMode();
                    Thread.Sleep(500);
                    _device.DeviceReset();
                }
            }

        }
        private void CenterPanel()
        {

            MainPanel.Location = new Point()
            {
                X = this.Width / 2 - MainPanel.Width / 2,
                Y = MainPanel.Location.Y
            };
            //

            MainPictureBox.Location = new Point()
            {
                X = this.Width / 2 - MainPictureBox.Width / 2,
                Y = MainPictureBox.Location.Y
            };
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
            this.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.FondoFormulario);

        }
        #region Back button
        private void LoadUnJamButton()
        {
            CustomButton unJamButton = ControlBuilder.BuildStandardButton(
                "UnJamButton", MultilanguangeController.GetText(MultiLanguageEnum.VOLVER), MainPanel.Width);

            this.MainPanel.Controls.Add(unJamButton);
            unJamButton.Click += new System.EventHandler(UnJamButton_Click);
        }

        private void UnJamButton_Click(object sender, EventArgs e)
        {
            _pollingTimer.Enabled = true;

            if (_device.StateResultProperty.DeviceStateInformation.EscrowBillPresent)
            {
                _device.OpenEscrow();
            }
           
        }
        #endregion
    }
}
