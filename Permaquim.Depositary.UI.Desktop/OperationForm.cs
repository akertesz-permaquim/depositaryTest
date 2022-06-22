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

namespace Permaquim.Depositary.UI.Desktop
{
    public partial class OperationForm : Form
    {
        private const int BILL_DEPOSIT = 1;
        private const int ENVELOPE_DEPOSIT = 3;
        private const int BAG_EXTRACTION = 7;
        private List<Permaquim.Depositario.Entities.Relations.Operacion.TipoTransaccion> _transactions = DatabaseController.GetTransactionTypes();

        Device _device = null;
        public OperationForm()
        {
            InitializeComponent();
        }

        private void OperationForm_Load(object sender, EventArgs e)
        {
            _device = (Permaquim.Depositary.UI.Desktop.Components.Device)this.Tag;
            LoadStyles();
            CenterPanel();
            if(_device.CounterConnected)
                SetDeviceToNeutralMode();
            LoadTransactionButtons();
            LoadOtherOperationsButton();
            LoadBackButton();

        }
        private void LoadStyles()
        {
            this.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.Contenido);
        }
        private void CenterPanel()
        {

            MainPanel.Location = new Point()
            {
                X = this.Width / 2 - MainPanel.Width / 2,
                Y = this.Height / 2 - MainPanel.Height / 2
            };
        }
        private void LoadTransactionButtons()
        {


            foreach (var item in _transactions)
            {

                CustomButton newButton = ControlBuilder.BuildStandardButton(
                    "TransactionButton" + item.Id.ToString(), 
                    MultilanguangeController.GetText(item.Nombre), MainPanel.Width);

                newButton.Click += new System.EventHandler(TransactionButton_Click);

                newButton.Tag = item;

                this.MainPanel.Controls.Add(newButton);

            }
        }
        private void TransactionButton_Click(object sender, EventArgs e)
        {
            DatabaseController.CurrentOperation = (Permaquim.Depositario.Entities.Relations.Operacion.TipoTransaccion)((CustomButton)sender).Tag;


            switch (DatabaseController.CurrentOperation.Id)
            {

                case BILL_DEPOSIT:
                case ENVELOPE_DEPOSIT:
                AppController.OpenChildForm(new CurrencySelectorForm(),
                (Permaquim.Depositary.UI.Desktop.Components.Device)this.Tag);
                    break;
                case BAG_EXTRACTION:
                    AppController.OpenChildForm(new BagExtractionForm(),
                        (Permaquim.Depositary.UI.Desktop.Components.Device)this.Tag);
                    break;
                default:
                    break;
            }


        }
        private void LoadBackButton()
        {
            CustomButton backButton = ControlBuilder.BuildExitButton(
                "BackButton", MultilanguangeController.GetText("Salir"),MainPanel.Width);

            this.MainPanel.Controls.Add(backButton);
            backButton.Click += new System.EventHandler(BackButton_Click);
        }

        #region Other Operations
        private void LoadOtherOperationsButton()
        {
            CustomButton otherOperationsButton = ControlBuilder.BuildAlternateButton(
                "OtherOperationsButton", MultilanguangeController.GetText("OTRAS_OPERACIONES"), MainPanel.Width);

            this.MainPanel.Controls.Add(otherOperationsButton);
            otherOperationsButton.Click += new System.EventHandler(OtherOperationButton_Click);
        }

        private void OtherOperationButton_Click(object sender, EventArgs e)
        {
            AppController.OpenChildForm(new OtherOperationsForm(),
              (Permaquim.Depositary.UI.Desktop.Components.Device)this.Tag);
        }
        # endregion

        private void BackButton_Click(object sender, EventArgs e)
        {
            DatabaseController.LogOff();
            this.Close();
        }
        private void SetDeviceToNeutralMode()
        {
            // si por algun motivo el equipo se recupera de una transacción fallida,
            // se cancela la operación.
            if (_device.StateResultProperty.ModeStateInformation.ModeState
                == ModeStateInformation.Mode.DepositMode 
                || _device.StateResultProperty.ModeStateInformation.ModeState
                == ModeStateInformation.Mode.ManualMode)
            {
                _device.RemoteCancel();
            }
        }
    }
}
