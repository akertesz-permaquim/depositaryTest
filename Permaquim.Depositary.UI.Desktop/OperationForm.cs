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
    public partial class OperationForm : Form
    {
        Device _device = null;
        public OperationForm()
        {
            InitializeComponent();
        }

        private void OperationForm_Load(object sender, EventArgs e)
        {
            _device = (Permaquim.Depositary.UI.Desktop.Components.Device)this.Tag;

            SetDeviceNeutralMode();

        }

        private void SetDeviceNeutralMode()
        {
            // si por algun motivo el equipo se recupera de una transacción fallida, se cancela la operación.
            if (_device.StateResultProperty.ModeStateInformation.ModeState == ModeStateInformation.Mode.DepositMode)
            {
                _device.RemoteCancel();
            }
        }

        private void BillDepositButton_Click(object sender, EventArgs e)
        {
            AppController.OpenChildForm(new BillDepositForm()
                , (Permaquim.Depositary.UI.Desktop.Components.Device)this.Tag);
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainPanel_Paint(object sender, PaintEventArgs e)
        {
            SetDeviceNeutralMode();
        }

    }
}
