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
            LoadBackButton();

        }
        private void LoadStyles()
        {
            this.BackColor = StyleController.GetColor(StyleController.ColorNameEnum.Contenido);
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

                CustomButton newButton = new CustomButton();

                newButton.BackColor = StyleController.GetColor(StyleController.ColorNameEnum.BotonAceptar);
                newButton.BackgroundColor = StyleController.GetColor(StyleController.ColorNameEnum.BotonAceptar);
                newButton.BorderColor = StyleController.GetColor(StyleController.ColorNameEnum.BotonAceptar);
                newButton.BorderRadius = 5;
                newButton.BorderSize = 0;
                newButton.FlatAppearance.BorderSize = 0;
                newButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                newButton.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
                newButton.ForeColor = StyleController.GetColor(StyleController.ColorNameEnum.FuenteContraste);
                newButton.Location = new System.Drawing.Point(3, 3);
                newButton.Name = "TransactionButton" + item.Id.ToString();
                newButton.Size = new System.Drawing.Size(293, 77);
                newButton.TabIndex = 0;
                newButton.Text = MultilanguangeController.GetText(item.Nombre);
                newButton.TextColor = StyleController.GetColor(StyleController.ColorNameEnum.FuenteContraste);
                newButton.UseVisualStyleBackColor = false;

                newButton.Click += new System.EventHandler(TransactionButton_Click);

                newButton.Tag = item;

                this.MainPanel.Controls.Add(newButton);

            }
        }
        private void TransactionButton_Click(object sender, EventArgs e)
        {
            DatabaseController.CurrentOperation = (Permaquim.Depositario.Entities.Relations.Operacion.TipoTransaccion)((CustomButton)sender).Tag;
    
            if (DatabaseController.CurrentOperation.Id == 1
                || DatabaseController.CurrentOperation.Id == 3)
            {
                AppController.OpenChildForm(new CurrencySelectorForm(),
                (Permaquim.Depositary.UI.Desktop.Components.Device)this.Tag);
            }

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
            
            this.ExitPanel.Controls.Add(backButton);
            backButton.Dock = DockStyle.Bottom;

            backButton.Click += new System.EventHandler(BackButton_Click);
        }
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

        private void BillDepositButton_Click(object sender, EventArgs e)
        {
            AppController.OpenChildForm(new CurrencySelectorForm()
                , (Permaquim.Depositary.UI.Desktop.Components.Device)this.Tag);

        }

    }
}
