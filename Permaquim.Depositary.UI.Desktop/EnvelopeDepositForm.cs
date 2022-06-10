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
    public partial class EnvelopeDepositForm : Form
    {
        /// <summary>
        /// Instancia del dispositivo
        /// </summary>
        public Device _device { get; set; }

        private List<EnvelopeDepositItem> _envelopeDepositItems = new();

        /// <summary>
        /// Máquina de estado
        /// </summary>
        private Operationstatus _operationStatus = new();
        /// <summary>
        /// Timer para la consulta del estado del dispositivo
        /// </summary>
        private System.Windows.Forms.Timer _poolingTimer = new System.Windows.Forms.Timer();

        public EnvelopeDepositForm()
        {
            InitializeComponent();
        }

        private void EnvelopeDepositForm_Load(object sender, EventArgs e)
        {
            _device = (Permaquim.Depositary.UI.Desktop.Components.Device)this.Tag;
            _poolingTimer = new System.Windows.Forms.Timer()
            {
                Interval = 200,
                Enabled = true
            };
            _poolingTimer.Tick += PoolTimer_Tick;

            _operationStatus = new();


            if (_device != null && _device.CounterConnected && _device.StateResultProperty != null)
            {
                _device.DepositMode();
            }

            LoadDenominations();

            CurrencyLabel.Text = DatabaseController.CurrentCurrency.Nombre;
        }
        public void LoadDenominations()
        {
            Permaquim.Depositario.Business.Relations.Valor.RelacionMonedaTipoValor entities = new();


            foreach (var item in entities.Items())
            {
                _envelopeDepositItems.Add(new EnvelopeDepositItem()
                {
                    Amount = 0,
                    Denomination = item.MonedaId.Nombre + "( " + item.TipoValorId.Nombre + " )",
                    Selected = false
                }); 
            }
            
            DenominationsGridView.DataSource = _envelopeDepositItems;

        }

        private void PoolTimer_Tick(object? sender, EventArgs e)
        {
            if (_device != null && _device.CounterConnected)
            {
                // Muestra el estado del hardware
                ShowHardwareMonitorData();
                // Procesa los estados 
                ProcessDeviceStatus();
            }

            Random rnd = new Random();
            int value = rnd.Next(1, 999);
            
            foreach (var item in DenominationsGridView.Rows)
            {
                int times = rnd.Next(1, 10);
                ((DataGridViewRow)item).Cells[2].Value = (times * value).ToString();
            }

            DenominationsGridView.Rows[DenominationsGridView.Rows.Count -1].DefaultCellStyle.BackColor = Color.SteelBlue;
            DenominationsGridView.Rows[DenominationsGridView.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.White;
            DenominationsGridView.Rows[DenominationsGridView.Rows.Count - 1].DefaultCellStyle.Font = new Font("Verdana", 16);
            DenominationsGridView.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            
            DenominationsGridView.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        private void DenominationsGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // I suppose your check box is at column index 0
            if (e.ColumnIndex == 0 && e.RowIndex == DenominationsGridView.Rows.Count -1)
            {
                e.PaintBackground(e.ClipBounds, true);
                e.Handled = true;
            }
        }
        private void ShowHardwareMonitorData()
        {

            int generalStatus = (int)_device.StateResultProperty.StatusInformation.OperatingState;
            GeneralStatusLabel.Text = Enum.GetName(typeof(StatusInformation.State), generalStatus);

            int deviceMode = (int)_device.StateResultProperty.ModeStateInformation.ModeState;
            DeviceModeLabel.Text = Enum.GetName(typeof(ModeStateInformation.Mode), deviceMode);

            StackerFullCheckBox.Checked = _device.StateResultProperty.DeviceStateInformation.StackerFull;
            RejectFullCheckBox.Checked = _device.StateResultProperty.DeviceStateInformation.RejectFull;
            RejectedBillPresentCheckBox.Checked = _device.StateResultProperty.DeviceStateInformation.RejectedBillPresent;
            DischargingFailureCheckBox.Checked = _device.StateResultProperty.DeviceStateInformation.DischargingFailure;
            EscrowBillPresentCheckBox.Checked = _device.StateResultProperty.DeviceStateInformation.EscrowBillPresent;
            HopperBillPresentCheckBox.Checked = _device.StateResultProperty.DeviceStateInformation.HopperBillPresent;
            DepositFinishedCheckbox.Checked = _device.StateResultProperty.EndInformation.StoreEnd;
            CountingErrorCheckBox.Checked = _device.StateResultProperty.ErrorStateInformation.CountingError;
            JammingCheckBox.Checked = _device.StateResultProperty.ErrorStateInformation.Jamming;

        }
        private void ProcessDeviceStatus()
        {
            // Asigna a la máquina el valor del estado de la contadora en este ciclo
            _operationStatus.GeneralStatus = _device.CurrentStatus;

            _device.CountingDataRequest();

            VerifySavetoDatabase();

            VerifyEscrowEmpty();


            VerifyButtonsVisibility();


            ShowInformation();
        }
        private void VerifyEscrowEmpty()
        {

            // Si se canceló la operación, debe esperar  que el operador quite el dinero del escrow
            if (
                _device.PreviousState == StatusInformation.State.PQWaitingToRemoveBankNotes &&
                (_operationStatus.GeneralStatus != StatusInformation.State.PQWaitingTocloseEscrow
                || _operationStatus.GeneralStatus != StatusInformation.State.PQClosingEscrow)
                && _device.StateResultProperty.DeviceStateInformation.EscrowBillPresent == false
                )
            {
                _poolingTimer.Enabled = false;
                // Cambia el estado 
                _device.PreviousState = _device.StateResultProperty.StatusInformation.OperatingState;
                _device.RemoteCancel();
                _device.CloseEscrow();

                _device.DepositMode();
                _poolingTimer.Enabled = true;
                _operationStatus.StackerFull = false;
                //_operationStatus.StackerFullTreated = false;
            }
        }
        /// <summary>
        /// Habilita la visualización de los botones de acuerdo a los estados del hardware
        /// </summary>
        private void VerifyButtonsVisibility()
        {

            BackButton.Visible =
                !_device.StateResultProperty.DeviceStateInformation.EscrowBillPresent
                && _operationStatus.CurrentTransactionAmount == 0;


            //Solo se habilita el botón de volver si no hay dinero en el escrow
            ConfirmAndExitDepositButton.Visible =
                _device.StateResultProperty.DeviceStateInformation.EscrowBillPresent
                && _device.StateResultProperty.DoorStateInformation.Escrow
                && !_device.StateResultProperty.DeviceStateInformation.RejectedBillPresent
                && !_device.StateResultProperty.DeviceStateInformation.HopperBillPresent
                && _device.StateResultProperty.StatusInformation.OperatingState
                    != StatusInformation.State.PQWaitingToRemoveBankNotes;

            CancelDepositButton.Visible =
                _device.StateResultProperty.DeviceStateInformation.EscrowBillPresent
                && _device.StateResultProperty.DoorStateInformation.Escrow
                && _device.StateResultProperty.StatusInformation.OperatingState != StatusInformation.State.PQWaitingToRemoveBankNotes;

        }
        private void ShowInformation()
        {
            InformationLabel.Text = String.Empty;

            if (!_device.StateResultProperty.DeviceStateInformation.EscrowBillPresent
             && _operationStatus.CurrentTransactionQuantity == 0)
            {
                InformationLabel.Text = "Ingrese los billetes para depositar";
                InformationLabel.ForeColor = Color.Green;
            }

            if (_device.StateResultProperty.StatusInformation.OperatingState == StatusInformation.State.PQCounting)
            {
                InformationLabel.Text = "Contando...";
                InformationLabel.ForeColor = Color.Blue;
            }

            if (_device.StateResultProperty.DeviceStateInformation.RejectedBillPresent)
            {
                InformationLabel.Text = "Retire los billetes rechazados para continuar.";
                InformationLabel.ForeColor = Color.Red;
            }
            if (_device.StateResultProperty.DeviceStateInformation.EscrowBillPresent
                 && _operationStatus.CurrentTransactionQuantity == 0
                 && !_device.StateResultProperty.DeviceStateInformation.RejectedBillPresent)
            {
                InformationLabel.Text = "Ingrese los billetes para continuar depositando";
                InformationLabel.ForeColor = Color.Green;
            }
            if (_device.StateResultProperty.DeviceStateInformation.EscrowBillPresent
                    && _operationStatus.CurrentTransactionQuantity > 0)
            {
                InformationLabel.Text = "Presione 'Confirmar' para depositar o 'Cancelar' para anular el depósito";
                InformationLabel.ForeColor = Color.Green;
            }
            if (_device.StateResultProperty.DeviceStateInformation.EscrowBillPresent
                && _operationStatus.CurrentTransactionQuantity == 0
                && _device.StateResultProperty.StatusInformation.OperatingState == StatusInformation.State.PQWaitingToRemoveBankNotes)
            {
                InformationLabel.Text = "Retire los billetes para cancelar la operación.";
                InformationLabel.ForeColor = Color.Red;
            }


        }

        /// <summary>
        /// Se evalúa si se debe grabar en base de datos cuando finaliza la operación
        /// </summary>
        private void VerifySavetoDatabase()
        {
            if (
                _operationStatus.DepositConfirmed &&
                !_device.StateResultProperty.DeviceStateInformation.EscrowBillPresent
                )
            {
                ExitBillDepositForm();
                _operationStatus.DepositEnded = true;
            }
        }
        private void ExitBillDepositForm()
        {
            // Ya que se debe salir del form, se 
            _poolingTimer.Enabled = false;

            DisableControls();

            SaveTransaction();

            _device.RemoteCancel();
            _operationStatus.DepositEnded = false;

            this.Close();
            AppController.OpenChildForm(new OperationForm(), _device);
        }
        /// <summary>
        /// Graba el depósito en base de datos
        /// </summary>
        private void SaveTransaction()
        {

            Permaquim.Depositario.Business.Tables.Operacion.Sesion sesiones = new();
            sesiones.Items(null, DatabaseController.CurrentUser.Id, null, null, null);


            Permaquim.Depositario.Business.Tables.Operacion.Transaccion transactions = new();
            Permaquim.Depositario.Business.Tables.Operacion.TransaccionDetalle transactionDetails = new();

            if (_operationStatus.CurrentTransactionId == 0)
            {
                Permaquim.Depositario.Entities.Tables.Operacion.Transaccion transaction = new()
                {
                    CierreDiarioId = 0,
                    ContenedorId = 3,
                    DepositarioId = 1,
                    Fecha = DateTime.Now,
                    Finalizada = true,
                    SectorId = 0,
                    SesionId = sesiones.Result.FirstOrDefault().Id,
                    SucursalId = 0,
                    TipoId = 1,             // Depósito de Billete
                    TotalAValidar = 0,
                    TotalValidado = _operationStatus.CurrentTransactionAmount,
                    TurnoId = 0,
                    UsuarioCuentaId = 0,
                    UsuarioId = DatabaseController.CurrentUser.Id

                };
                transactions.Add(transaction);
                _operationStatus.CurrentTransactionId = transaction.Id;
            }
            else
            {
                transactions.Items(_operationStatus.CurrentTransactionId);
                if (transactions.Result.Count > 0)
                {
                    var previousTransaction = transactions.Result.FirstOrDefault();
                    previousTransaction.TotalValidado = _operationStatus.CurrentTransactionAmount;

                    transactions.Update(previousTransaction);
                }
            }

            //foreach (var item in _detectedDenominations)
            //{
            //    if (item.CantidadDetectada > 0)
            //    {
            //        Permaquim.Depositario.Entities.Tables.Operacion.TransaccionDetalle transactionDetail = new()
            //        {
            //            CantidadUnidades = item.CantidadDetectada,
            //            DenominacionId = item.Id,
            //            Fecha = DateTime.Now,
            //            TransaccionId = _operationStatus.CurrentTransactionId

            //        };
            //        transactionDetails.Add(transactionDetail);
            //    }
            //}

        }
        private void DisableControls()
        {
            DenominationsGridView.Visible = false;
            CancelDepositButton.Visible = false;
            ConfirmAndExitDepositButton.Visible = false;

        }
        private class EnvelopeDepositItem
        {
            public bool Selected { get; set; }
            public string Denomination { get; set; }
            public double Amount { get; set; }
        }
    }
}
