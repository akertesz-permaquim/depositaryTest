﻿using Newtonsoft.Json;
using Permaquim.Depositary.UI.Desktop.Components;
using Permaquim.Depositary.UI.Desktop.Controllers;
using Permaquim.Depositary.UI.Desktop.Global;
using System.Text;

namespace Permaquim.Depositary.UI.Desktop
{
    public partial class BillDepositForm : Form
    {

        /// <summary>
        /// Instancia del dispositivo
        /// </summary>
        public Device _device { get; set; }

        /// <summary>
        /// Máquina de estado
        /// </summary>
        private Operationstatus _operationStatus = new();

        /// <summary>
        /// Denominaciones registradas en la db
        /// </summary>
        private List<Permaquim.Depositario.Entities.Relations.Valor.Denominacion> _denominaciones = new();
        /// <summary>
        /// Denominacines detectadas por la contadora
        /// </summary>
        private List<DenominationItem> _detectedDenominations = new();
        /// <summary>
        /// Timer para la consulta del estado del dispositivo
        /// </summary>
        private System.Windows.Forms.Timer _pollingTimer = new System.Windows.Forms.Timer();


        private List<DepositItem> _depositItems = new();

        // Variables que contienen los datos del conteo en curso
        private Double currentCountingAmount = 0;
        private int currentCountingQuantity = 0;

        private int _remainingTime = 60;

  

        public BillDepositForm()
        {
            InitializeComponent();
        }
        private void BillDepositForm_Load(object sender, EventArgs e)
        {
            this.SuspendLayout();
            _device = (Permaquim.Depositary.UI.Desktop.Components.Device)this.Tag;

            _detectedDenominations = new();

            _pollingTimer = new System.Windows.Forms.Timer()
            {
                Interval = DeviceController.GetPollingInterval(),
                Enabled = true
            };
            _pollingTimer.Tick += PollTimer_Tick;

            _operationStatus = new();

            LoadCurrentContainer();
            LoadDenominations();
            LoadStyles();
            CenterPanel();
            CurrencyLabel.Text = DatabaseController.CurrentCurrency.Nombre;
            this.ResumeLayout();
        }
        private void CenterPanel()
        {

            MainPanel.Location = new Point()
            {
                X = this.Width / 2 - MainPanel.Width / 2,
                Y = this.Height / 2 - MainPanel.Height / 2
            };
        }
        private void LoadStyles()
        {
            this.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.Contenido);

             CurrencyLabel.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.Cabecera);
            SubtotalLabel.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.Cabecera);
            DenominationsGridView.ColumnHeadersDefaultCellStyle.BackColor =
                StyleController.GetColor(Enumerations.ColorNameEnum.Cabecera);

            ConfirmAndExitDepositButton.Text = MultilanguangeController.GetText("ACCEPT_BUTTON");
            ConfirmAndContinueDepositButton.Text = MultilanguangeController.GetText("CONTINUE_BUTTON");
            CancelDepositButton.Text = MultilanguangeController.GetText("CANCEL_BUTTON");
            BackButton.Text = MultilanguangeController.GetText("EXIT_BUTTON");
            RemainingTimeLabel.Text = MultilanguangeController.GetText("TIEMPO_RESTANTE");
            DenominationsGridView.Columns["Image"].HeaderText = MultilanguangeController.GetText("IMAGEN");
            DenominationsGridView.Columns["Denomination"].HeaderText = MultilanguangeController.GetText("DENOMINACION");
            DenominationsGridView.Columns["Quantity"].HeaderText = MultilanguangeController.GetText("CANTIDAD");
            DenominationsGridView.Columns["Amount"].HeaderText = MultilanguangeController.GetText("IMPORTE");

        }
        private void PollTimer_Tick(object? sender, EventArgs e)
        {
            if (_device != null && _device.CounterConnected)
            {
                if (_device.StateResultProperty.ModeStateInformation.ModeState == ModeStateInformation.Mode.Neutral_SettingMode)
                {
                    _device.DepositMode();
                }
                else { 
                    // Muestra el estado del hardware
                    ShowHardwareMonitorData();
                    // Procesa los estados 
                    ProcessDeviceStatus();
                }
            }
 

        }
        public bool EsMultiplo(int numero,int multiplo)
        {
            if (numero % multiplo == 0)
            {
                return true;
            }
            else
                return false;
        }
        private void ProcessDeviceStatus()
        {
            // Asigna a la máquina el valor del estado de la contadora en este ciclo
            _operationStatus.GeneralStatus = _device.CurrentStatus;


            _device.CountingDataRequest();

             VerifySavetoDatabase();

            VerifyStartCounting();

            VerifyEscrowEmpty();

            VerifyLoadDetectedBills();

            VerifyButtonsVisibility();

            ShowInformation();
        }

        /// <summary>
        /// Habilita la visualización de los botones de acuerdo a los estados del hardware
        /// </summary>
        private void VerifyButtonsVisibility()
        {

            if (_device.IoBoardStatusProperty.GateState == IoBoardStatus.GATE_STATE.CLOSED)
            {

                BackButton.Visible =
                    !_device.StateResultProperty.DeviceStateInformation.EscrowBillPresent
                    && _operationStatus.CurrentTransactionAmount == 0
                    && !_device.StateResultProperty.DeviceStateInformation.StackerFull;

                ConfirmAndExitDepositButton.Visible =
                    (_device.StateResultProperty.DeviceStateInformation.EscrowBillPresent
                    && _device.StateResultProperty.DoorStateInformation.Escrow
                    && !_device.StateResultProperty.DeviceStateInformation.RejectedBillPresent
                    && !_device.StateResultProperty.DeviceStateInformation.HopperBillPresent
                    && _device.StateResultProperty.StatusInformation.OperatingState
                        != StatusInformation.State.PQWaitingToRemoveBankNotes
                    && _device.StateResultProperty.StatusInformation.OperatingState
                        != StatusInformation.State.EscrowOpen)
                        || _device.StateResultProperty.DeviceStateInformation.StackerFull;

                ConfirmAndContinueDepositButton.Visible =
                        _device.StateResultProperty.DeviceStateInformation.StackerFull;

                CancelDepositButton.Visible =
                    _device.StateResultProperty.DeviceStateInformation.EscrowBillPresent
                    && _device.StateResultProperty.DoorStateInformation.Escrow
                    && _device.StateResultProperty.StatusInformation.OperatingState != StatusInformation.State.PQWaitingToRemoveBankNotes;
            }
            else
            {
                BackButton.Visible = true;
                ConfirmAndExitDepositButton.Visible = false;
                ConfirmAndContinueDepositButton.Visible = false;
                CancelDepositButton.Visible = false;
            }

        }
        private void ShowInformation()
        {
            InformationLabel.Text = String.Empty;

            if (_device.IoBoardStatusProperty.GateState == IoBoardStatus.GATE_STATE.CLOSED)
            {


                if (!_device.StateResultProperty.DeviceStateInformation.EscrowBillPresent
             && _operationStatus.CurrentTransactionQuantity == 0)
                {
                    InformationLabel.Text = MultilanguangeController.GetText("INGRESAR_BILLETES");
                    InformationLabel.ForeColor = Color.Green;
                }

                if (_device.StateResultProperty.StatusInformation.OperatingState == StatusInformation.State.PQCounting)
                {
                    InformationLabel.Text = MultilanguangeController.GetText("CONTANDO");
                    InformationLabel.ForeColor = Color.Blue;
                }

                if (_device.StateResultProperty.DeviceStateInformation.RejectedBillPresent)
                {
                    InformationLabel.Text = MultilanguangeController.GetText("RETIRAR_BILLETES_RECHAZADOS");
                    InformationLabel.ForeColor = Color.Red;
                }
                if (_device.StateResultProperty.DeviceStateInformation.EscrowBillPresent
                     && _operationStatus.CurrentTransactionQuantity == 0
                     && !_device.StateResultProperty.DeviceStateInformation.RejectedBillPresent)
                {
                    InformationLabel.Text = MultilanguangeController.GetText("CONTINUAR_INGRESANDO_BILLETES");
                    InformationLabel.ForeColor = Color.Green;
                }
                if (_device.StateResultProperty.DeviceStateInformation.EscrowBillPresent
                        && _operationStatus.CurrentTransactionQuantity > 0)
                {
                    InformationLabel.Text = MultilanguangeController.GetText("ACEPTAR_O_CANCELAR_DEPOSITO");
                    InformationLabel.ForeColor = Color.Green;
                }
                if (_device.StateResultProperty.DeviceStateInformation.EscrowBillPresent
                    && _operationStatus.CurrentTransactionQuantity == 0
                    && _device.StateResultProperty.StatusInformation.OperatingState == StatusInformation.State.PQWaitingToRemoveBankNotes)
                {
                    InformationLabel.Text = MultilanguangeController.GetText("CANCELAR_DEPOSITO");
                    InformationLabel.ForeColor = Color.Red;
                }

                if (_device.StateResultProperty.DeviceStateInformation.StackerFull)
                {
                    InformationLabel.Text = MultilanguangeController.GetText("ESCROW_LLENO");
                    InformationLabel.ForeColor = Color.Red;
                }
            }
            else
            {
                if (_device.IoBoardStatusProperty.GateState == IoBoardStatus.GATE_STATE.OPEN)
                {
                    InformationLabel.Text = MultilanguangeController.GetText("PUERTA_ABIERTA");
                    InformationLabel.ForeColor = Color.Red;
                }
            }
        }

        private int GetDenominationsCount()
        {
            int returnValue = 0;
            foreach (var item in _detectedDenominations)
            {
                returnValue += item.CantidadDetectada;
            }
            return returnValue;
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
                _pollingTimer.Enabled = false;
                // Cambia el estado 
                _device.PreviousState = _device.StateResultProperty.StatusInformation.OperatingState;
                _device.RemoteCancel();
                _device.CloseEscrow();

                _device.DepositMode();
                _pollingTimer.Enabled = true;
                _operationStatus.StackerFull = false;
                _operationStatus.StackerFullTreated = false;
            }
        }
        /// <summary>
        /// Ejecuta el comando para que cuente el dinero presente en el hopper
        /// si el estado es  BeingSet o BeingReset
        /// </summary>
        private void VerifyStartCounting()
        {
            if (_operationStatus.GeneralStatus == StatusInformation.State.BeingSet
                || _operationStatus.GeneralStatus == StatusInformation.State.BeingReset)
            {
                _device.BatchDataTransmission();
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

   
        private void WaitEmptyEscrow()
        {
            _pollingTimer.Enabled = false;
            // Cambia el estado 
            _device.PreviousState = _device.StateResultProperty.StatusInformation.OperatingState;
            _device.RemoteCancel();
            _device.CloseEscrow();
            CleanDetectedBills();
            _device.DepositMode();
            _pollingTimer.Enabled = true;
            // inicializa el flag de stacker lleno 

        }

        private void CleanDetectedBills()
        {
            _device.DenominationResultProperty.Denominations = new Dictionary<string, int>();

        }

        private void ShowHardwareMonitorData()
        {

            int generalStatus = (int)_device.StateResultProperty.StatusInformation.OperatingState;
            GeneralStatusLabel.Text = Enum.GetName(typeof(StatusInformation.State), generalStatus);

            int deviceMode = (int)_device.StateResultProperty.ModeStateInformation.ModeState;
            DeviceModeLabel.Text = Enum.GetName(typeof(ModeStateInformation.Mode), deviceMode);
            CurrencyStatusLabel.Text = _device.StateResultProperty.CountryCode.CurrencyStateInformation.ToString();

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
        /// <summary>
        /// Si existen denominaciones detectadas carga el Listview
        /// </summary>
        private void VerifyLoadDetectedBills()
        {
            currentCountingAmount = 0;
            currentCountingQuantity = 0;

            if (_device.DenominationResultProperty.DenominationArray != null
                && _device.DenominationResultProperty.DenominationArray.Length == 96)
            {
                _detectedDenominations = new List<DenominationItem>();
                foreach (var item in _denominaciones)
                {
                    var readQuantity = string.Join<char>("",
                       (IEnumerable<char>)Encoding.ASCII.GetChars(new byte[3]
                    {
                        _device.DenominationResultProperty.DenominationArray[item.Posicion],
                        _device.DenominationResultProperty.DenominationArray[item.Posicion + 1],
                        _device.DenominationResultProperty.DenominationArray[item.Posicion + 2]
                    }));
                    int value = 0;
                    int.TryParse(readQuantity, out value);

                    _detectedDenominations.Add(new DenominationItem()
                    {
                        Id = item.Id,
                        Nombre = item.Nombre,
                        Unidades = item.Unidades,
                        CantidadDetectada = value,
                        Indice = _detectedDenominations.Count
                    });
                }
            }

            if (_detectedDenominations.Count > 0 && DenominationsGridView.Rows.Count > 0)
            {

                // Actualiza las denominaciones con el valor detectado 
                foreach (var denomination in _detectedDenominations)
                {
                    if (DenominationsGridView.Rows.Count > 0)
                    {
                        DenominationsGridView.Rows[(int)denomination.Indice]
                            .Cells["Quantity"].Value = denomination.CantidadDetectada.ToString();
                        DenominationsGridView.Rows[(int)denomination.Indice]
                            .Cells["Amount"].Value = DatabaseController.CurrentCurrency.Simbolo + " " +
                            (denomination.CantidadDetectada * Convert.ToInt32(denomination.Unidades)).ToString();

                        currentCountingAmount += Convert.ToInt32(denomination.Unidades) * denomination.CantidadDetectada;
                        currentCountingQuantity += denomination.CantidadDetectada;
                    }
                }

                SetTotalRowStyle();

            }
            else
            {
                foreach (DataGridViewRow item in DenominationsGridView.Rows)
                {
                    //item.Cells[IMAGE_COLUMN].Value = "0";
                }
                currentCountingAmount = 0;
            }

            SubtotalLabel.Text = "Sub Total: " + _operationStatus.CurrentTransactionAmount.ToString();

            CancelDepositButton.Visible = true;
        }

        private void SetTotalRowStyle()
        {
            DenominationsGridView.Rows[DenominationsGridView.Rows.Count - 1].DefaultCellStyle.BackColor = Color.SteelBlue;
            DenominationsGridView.Rows[DenominationsGridView.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.White;
            DenominationsGridView.Rows[DenominationsGridView.Rows.Count - 1].DefaultCellStyle.Font = new Font("Verdana", 16);
            DenominationsGridView.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DenominationsGridView.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            DenominationsGridView.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DenominationsGridView.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            //Totales
            DenominationsGridView.Rows[DenominationsGridView.Rows.Count - 1].Cells["Quantity"].Value =
                (currentCountingQuantity + _operationStatus.CurrentTransactionQuantity).ToString();
            DenominationsGridView.Rows[DenominationsGridView.Rows.Count - 1].Cells["Amount"].Value =
                DatabaseController.CurrentCurrency.Simbolo + " " +
                    (currentCountingAmount + _operationStatus.CurrentTransactionAmount).ToString(); ;
        }

        private void DenominationsGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex == DenominationsGridView.Rows.Count - 1)
            {
                e.PaintBackground(e.ClipBounds, true);
                e.Handled = true;
            }
        }
        private void CancelDepositButton_Click(object sender, EventArgs e)
        {
            CancelDeposit();
        }

        private void CancelDeposit()
        {
            ConfirmAndExitDepositButton.Visible = false;
            _operationStatus.StackerFull = false;
            _device.OpenEscrow();
            _device.PreviousState = StatusInformation.State.PQWaitingToRemoveBankNotes;
        }

        private void ConfirmAndExitDepositButton_Click(object sender, EventArgs e)
        {
            ConfirmDeposit();
            _operationStatus.DepositConfirmed = true;
        }

        private void ConfirmDeposit()
        {
            _operationStatus.DepositConfirmed = true;
            CancelDepositButton.Visible = false;
            _device.StoringStart();

            _device.PreviousState = StatusInformation.State.PQStoring;
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            if (_device.CounterConnected)
                _device.RemoteCancel();
            _pollingTimer.Enabled = false;
            AppController.OpenChildForm(new OperationForm(), _device);

        }
        /// <summary>
        /// Esta operación raliza lo siguiente: 
        /// Graba en la db la operación realizada
        /// Inicializa el modo de la contadora
        /// Sale a la pantalla del menú de operaciones
        /// </summary>
        private void ExitBillDepositForm()
        {
            // Ya que se debe salir del form, se 
            _pollingTimer.Enabled = false;

            DisableControls();

            SaveTransaction();

            _device.RemoteCancel();
            _operationStatus.DepositEnded = false;
            CleanDetectedBills();

            this.Close();
            AppController.OpenChildForm(new OperationForm(), _device);
        }

        private void SaveAndContinueDeposit()
        {
            //DisableControls();
            _device.StoringStart();
            SaveTransaction();
        }

        private void DisableControls()
        {
            DenominationsGridView.Visible = false;
            CancelDepositButton.Visible = false;
            ConfirmAndExitDepositButton.Visible = false;

        }


        #region Database Access

        public void LoadCurrentContainer()
        {
            var x = DatabaseController.CurrentContainer;
        }
        public void LoadDenominations()
        {
            Permaquim.Depositario.Business.Relations.Valor.Denominacion denominacion = new();
            denominacion.Where.Add(Permaquim.Depositario.Business.Relations.Valor.Denominacion.ColumnEnum.MonedaId,
                Permaquim.Depositario.sqlEnum.OperandEnum.Equal, DatabaseController.CurrentCurrency.Id);
            denominacion.OrderByParameter.Add(Depositario.Business.Relations.Valor.Denominacion.ColumnEnum.Unidades);

            _denominaciones = denominacion.Items();

            var bitmap = new Bitmap(640, 480);

            for (var x = 0; x < bitmap.Width; x++)
            {
                for (var y = 0; y < bitmap.Height; y++)
                {
                    bitmap.SetPixel(x, y, Color.SteelBlue);
                }
            }


            foreach (var item in _denominaciones)
            {
                byte[] bytes = Convert.FromBase64String(item.Imagen
                    .Replace("data:image/jpeg;base64,", String.Empty)
                    .Replace("data:image/webp;base64,", String.Empty));

                _depositItems.Add(new DepositItem()
                {
                    Amount = "0",
                    Denomination =item.MonedaId.Codigo + " " +  item.Nombre,
                    Quantity = 0,
                    Image = System.Drawing.Image.FromStream(new MemoryStream(bytes))
                });

            }
            _depositItems.Add(new() { Denomination = "Total",Amount = "0",Image= bitmap, Quantity=0});
            DenominationsGridView.DataSource = _depositItems;

            SetTotalRowStyle();
        }

        /// <summary>
        /// Graba el depósito en base de datos
        /// </summary>
        private void SaveTransaction()
        {
            _operationStatus.CurrentTransactionAmount += currentCountingAmount;




            Permaquim.Depositario.Business.Tables.Operacion.Transaccion transactions = new();
            Permaquim.Depositario.Business.Tables.Operacion.TransaccionDetalle transactionDetails = new();

            if (_operationStatus.CurrentTransactionId == 0)
            {
                Permaquim.Depositario.Entities.Tables.Operacion.Transaccion transaction = new()
                {
                    CierreDiarioId = 0,
                    ContenedorId = DatabaseController.CurrentContainer.Id,
                    DepositarioId = DatabaseController.CurrentDepositary.Id,
                    Fecha = DateTime.Now,
                    Finalizada = true,
                    SectorId = DatabaseController.CurrentDepositary.SectorId.Id,
                    SesionId = DatabaseController.CurrentSession.Id,
                    SucursalId = DatabaseController.CurrentDepositary.SectorId.SucursalId.Id,
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

            foreach (var item in _detectedDenominations)
            {
                if (item.CantidadDetectada > 0)
                {
                    Permaquim.Depositario.Entities.Tables.Operacion.TransaccionDetalle transactionDetail = new()
                    {
                        CantidadUnidades = item.CantidadDetectada,
                        DenominacionId = item.Id,
                        Fecha = DateTime.Now,
                        TransaccionId = _operationStatus.CurrentTransactionId

                    };
                    transactionDetails.Add(transactionDetail);
                }
            }

        }
        #endregion


        #region Listview Owner Drawn
        private void BillCountingListview_DrawColumnHeader(object sender,
                                           DrawListViewColumnHeaderEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.SteelBlue, e.Bounds);
            e.DrawText();
        }
        #endregion

        private void EventCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            MonitorGroupBox.Visible = EventCheckbox.Checked;
        }

         private void ConfirmAndContinueDepositButton_Click(object sender, EventArgs e)
        {
            SaveAndContinueDeposit();
        }
    }

    public class Operationstatus
    {
        /// <summary>
        /// Estados que informa la contadora
        /// </summary>
        public StatesResult OperationDeviceStatesResult { get; set; }
        /// <summary>
        /// Ya que el estado de transacción finalizada es volátil,
        /// Se almacena si la contadora considera fnalizado el depósito
        /// </summary>
        public bool DepositEnded { get; set; } = false;
        /// <summary>
        /// Indica que el usuario confirmó el depósito
        /// </summary>
        public bool DepositConfirmed { get; set; }

        public bool StackerFullTreated { get; set; }
        /// <summary>
        /// Indica que la contadora detectó un escrow lleno, y esto
        /// provoca que la contadora siga contando luego de enviar 
        /// el dinero en escrow al contenedor, detecte o no  billetes 
        /// (sensor del hopper)
        /// </summary>
        public bool StackerFull { get; set; }
        /// <summary>
        /// Id de transacción necesaria para asociar detalles de distintas 
        /// operaciones de conteo a un mismo depósito (caso escrow lleno) 
        /// </summary>
        public long CurrentTransactionId { get; set; }

        public Double CurrentTransactionAmount { get; set; }

        public int CurrentTransactionQuantity { get; set; }

        public StatusInformation.State GeneralStatus { get; set; }

        public void Initialize()
        {
            OperationDeviceStatesResult = new();
            DepositEnded = false;
            StackerFull = false;
            CurrentTransactionId = 0;
            DepositConfirmed = false;
        }

    }
    public class DepositItem
    {
        public string Denomination { get; set; }
        public Int64 Quantity { get; set; }
        public string Amount { get; set; }
        public Image Image { get; set; }
    }
    public class DenominationItem : Permaquim.Depositario.Entities.Tables.Valor.Denominacion
    {
        public int CantidadDetectada { get; set; }
        public int Indice { get; set; }
    }
}