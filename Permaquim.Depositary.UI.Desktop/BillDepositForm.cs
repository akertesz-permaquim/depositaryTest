using Newtonsoft.Json;
using Permaquim.Depositary.UI.Desktop.Components;
using Permaquim.Depositary.UI.Desktop.Controllers;
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
        private List<PQDepositario.Entities.Tables.Valor.Denominacion> _denominaciones = new();
        /// <summary>
        /// Denominacines detectadas por la contadora
        /// </summary>
        private List<DenominationItem> _detectedDenominations = new();
        /// <summary>
        /// Estado previo al actual
        /// </summary>
        private System.Windows.Forms.Timer _poolingTimer = new System.Windows.Forms.Timer();

        // Variables que contienen los datos del conteo en curso
        private Double currentCountingAmount = 0;
        private int currentCountingQuantity = 0;

        private const int FIRST_COLUMN = 1;
        private const int SECOND_COLUMN = 2;

        private ImageList _imageList = new ImageList();
        public BillDepositForm()
        {
            InitializeComponent();
        }
        private void BillDepositForm_Load(object sender, EventArgs e)
        {
            _device = (Permaquim.Depositary.UI.Desktop.Components.Device)this.Tag;
            _poolingTimer = new System.Windows.Forms.Timer()
            {
                Interval = 200,
                Enabled = true
            };
            _poolingTimer.Tick += PoolTimer_Tick;

            _operationStatus = new();

            if (_device.StateResultProperty != null)
            {
                // Para operar debe estar en "DepositMode"
                if (_device.StateResultProperty.ModeStateInformation.ModeState !=
                    ModeStateInformation.Mode.DepositMode)
                    _device.DepositMode();
                LoadDenominations();
            }
            else
            {
                MessageBox.Show("No conectado");
            }
        }

        private void PoolTimer_Tick(object? sender, EventArgs e)
        {
 
            // muestra el estado del hardware
            ShowHardwareMonitorData();
            // Procesa los estados 
            ProcessDeviceStatus();
        }

        private void ProcessDeviceStatus()
        {
            // Asigna a la máquina el valor del estado de la contadora en este ciclo
            _operationStatus.GeneralStatus = _device.CurrentStatus;

            // Marca en la máquina de estado que se detectó el máximo de billetes
            if (GetDenominationsCount() == 100 && _device.StateResultProperty.DeviceStateInformation.EscrowBillPresent)
                _operationStatus.StackerFull = true;

            //if(_device.StateResultProperty.DeviceStateInformation.StackerFull)
            //    _operationStatus.StackerFull = true;

            _device.CountingDataRequest();

            VerifyStackerFullCondition();

            VerifySavetoDatabase();

            VerifyStartCounting();

            VerifyEscrowEmpty();

            VerifyLoadDetectedBills();

            VerifyButtonsVisibility();
            //EnableOrdisableButtons();
        }

        /// <summary>
        /// Habilita la visualización de los botones de acuerdo a los estados del hardware
        /// </summary>
        private void VerifyButtonsVisibility()
        {
            //Solo se habilita el botón de volver si no hay dinero en el escrow

            BackButton.Visible = (
                !_device.StateResultProperty.DeviceStateInformation.HopperBillPresent
                ||
                !_device.StateResultProperty.DeviceStateInformation.EscrowBillPresent
                );

            ConfirmAndExitDepositButton.Visible = 
                _device.StateResultProperty.DeviceStateInformation.EscrowBillPresent 
                && _device.StateResultProperty.DoorStateInformation.Escrow
                && !_device.StateResultProperty.DeviceStateInformation.RejectedBillPresent
                && !_device.StateResultProperty.DeviceStateInformation.HopperBillPresent
                && _device.StateResultProperty.StatusInformation.OperatingState 
                    != StatusInformation.State.PQWaitingToRemoveBankNotes;

            CancelDepositButton.Visible = 
                _device.StateResultProperty.DeviceStateInformation.EscrowBillPresent
                &&  _device.StateResultProperty.DoorStateInformation.Escrow
                && _device.StateResultProperty.StatusInformation.OperatingState != StatusInformation.State.PQWaitingToRemoveBankNotes;

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
                _poolingTimer.Enabled = false;
                // Cambia el estado 
                _device.PreviousState = _device.StateResultProperty.StatusInformation.OperatingState;
                _device.RemoteCancel();
                _device.CloseEscrow();

                _device.DepositMode();
                _poolingTimer.Enabled = true;
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

        private void VerifyStackerFullCondition()
        {
            if (_operationStatus.StackerFull 
                && _operationStatus.StackerFullTreated == false)
            {
                _operationStatus.StackerFullTreated = true;

                StackerFullDialog stackerFullDialog = new();
                stackerFullDialog.ShowDialog();

                switch (stackerFullDialog.DialogResult)
                {
                    case DialogResult.None:
                        // No implementado
                        break;
                    case DialogResult.OK:
                        // Finaliza el depósito
                        ConfirmDeposit();
                        break;
                    case DialogResult.Cancel:
                        // Cancela el depósito
                        CancelDeposit();
                        break;
                    case DialogResult.Abort:
                        // No implementado
                        break;
                    case DialogResult.Retry:
                        // No implementado
                        break;
                    case DialogResult.Ignore:
                        // No implementado
                        break;
                    case DialogResult.Yes:
                        // No implementado
                        break;
                    case DialogResult.No:
                        // No implementado
                        break;
                    case DialogResult.TryAgain:
                        // No implementado
                        break;
                    case DialogResult.Continue:
                        // solo espera mas billetines
                        SaveAndContinueDeposit();
                        break;
                    default:
                        break;
                }
              
            }
        }

        private void EnableOrdisableButtons()
        {
            //Solo se habilita el botón de volver si no hay dinero en el escrow
            BackButton.Visible = !_device.StateResultProperty.DeviceStateInformation.EscrowBillPresent;

            // Se habilita el boton de confirmar depósito cuando hay billetes en el escrow, pero no
            // en el reject
            ConfirmAndExitDepositButton.Visible =
                _device.StateResultProperty.DeviceStateInformation.EscrowBillPresent
                && !_device.StateResultProperty.DeviceStateInformation.RejectedBillPresent
                && _device.StateResultProperty.StatusInformation.OperatingState != StatusInformation.State.PQCounting
                && _device.StateResultProperty.DoorStateInformation.Escrow == true
                && _device.StateResultProperty.StatusInformation.OperatingState != StatusInformation.State.PQWaitingToRemoveBankNotes;
            // Se habiita cancelar, una vez que haya terminado la lectura de billetes 
            // y esten los mismos en el escrow 
            CancelDepositButton.Visible =
                _device.StateResultProperty.StatusInformation.OperatingState != StatusInformation.State.PQCounting
                && _device.StateResultProperty.DeviceStateInformation.EscrowBillPresent
                && _device.StateResultProperty.StatusInformation.OperatingState != StatusInformation.State.PQWaitingToRemoveBankNotes; ;
        }

        private void WaitEmptyEscrow()
        {
            _poolingTimer.Enabled = false;
            // Cambia el estado 
            _device.PreviousState = _device.StateResultProperty.StatusInformation.OperatingState;
            _device.RemoteCancel();
            _device.CloseEscrow();
            CleanDetectedBills();
            _device.DepositMode();
            _poolingTimer.Enabled = true;
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
                        CantidadDetectada = value
                    });
                }
            }

            if (_detectedDenominations.Count > 0)
            {
                // Actualiza las denominaciones con el valor detectado 
                foreach (var denomination in _detectedDenominations)
                {
                    if (BillCountingListview.Items.Count > 0)
                    {
                        BillCountingListview.Items[(int)denomination.Id]
                            .SubItems[FIRST_COLUMN].Text = denomination.CantidadDetectada.ToString();
                        BillCountingListview.Items[(int)denomination.Id]
                            .SubItems[SECOND_COLUMN].Text = (denomination.CantidadDetectada * Convert.ToInt32(denomination.Unidades)).ToString();

                        currentCountingAmount += Convert.ToInt32(denomination.Unidades) * denomination.CantidadDetectada;
                        currentCountingQuantity += denomination.CantidadDetectada;
                    }
                }
                
                //Totales
                if (BillCountingListview.Items.Count > 0)
                {
                    BillCountingListview.Items[BillCountingListview.Items.Count - 1]
                    .SubItems[FIRST_COLUMN].Text = (currentCountingQuantity + _operationStatus.CurrentTransactionQuantity).ToString();
                    BillCountingListview.Items[BillCountingListview.Items.Count - 1]
                        .SubItems[SECOND_COLUMN].Text = (currentCountingAmount + _operationStatus.CurrentTransactionAmount).ToString();
                
                }
            }
            else
            {
                foreach (ListViewItem item in BillCountingListview.Items)
                {
                    item.SubItems[FIRST_COLUMN].Text = "0";
                }
                currentCountingAmount = 0;
            }

            SubtotalLabel.Text = "Sub Total: " + _operationStatus.CurrentTransactionAmount.ToString();

            CancelDepositButton.Visible = true;
        }
        private void CancelDepositButton_Click(object sender, EventArgs e)
        {
            CancelDeposit();
        }

        private void CancelDeposit()
        {
            //_operationStatus.Initialize();
            _operationStatus.StackerFull = false;
            _device.OpenEscrow();
            _device.PreviousState = StatusInformation.State.PQWaitingToRemoveBankNotes;
        }

        private void ConfirmAndExitDepositButton_Click(object sender, EventArgs e)
        {
            _operationStatus.DepositConfirmed = true;
            ConfirmDeposit();
        }

        private void ConfirmDeposit()
        {
            _operationStatus.DepositConfirmed = true;
            CancelDepositButton.Visible = false;
            BackButton.Visible = false;
            _device.StoringStart();

            _device.PreviousState = StatusInformation.State.PQStoring;
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            _device.RemoteCancel();
            _poolingTimer.Enabled = false;
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
            _poolingTimer.Enabled = false;

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
            BillCountingListview.Visible = false;
            BackButton.Visible = false;
            CancelDepositButton.Visible = false;
            ConfirmAndExitDepositButton.Visible = false;

        }

        private void InitializeBillCountingListview()
        {
            BillCountingListview.SmallImageList = _imageList;
            foreach (var denomination in _denominaciones)
            {
                ListViewItem item = new();
                item.ImageIndex = (int)denomination.Id;
                item.Text = denomination.Nombre;
                item.SubItems.Add("0");
                item.SubItems.Add("0");
                BillCountingListview.Items.Add(item);

            }
            ListViewItem totalItem = new();
            totalItem.Text = "Totales";
            totalItem.SubItems.Add("0");
            totalItem.SubItems.Add("0");
            BillCountingListview.Items.Add(totalItem);

            BillCountingListview.Visible = true;

        }

        #region Database Access
        public void LoadDenominations()
        {
            PQDepositario.Business.Tables.Valor.Denominacion denominacion = new();
            _denominaciones = denominacion.Items();

            _imageList.Images.Clear();
            _imageList.ImageSize = new Size(64, 32);
            _imageList.ColorDepth = ColorDepth.Depth32Bit;

            foreach (var item in _denominaciones)
            {
                byte[] bytes = Convert.FromBase64String(item.Imagen
                    .Replace("data:image/jpeg;base64,",String.Empty)
                    .Replace("data:image/webp;base64,", String.Empty));
            
                using (MemoryStream ms = new MemoryStream(bytes))
                {
                    _imageList.Images.Add(Image.FromStream(ms));
                }
            }
            InitializeBillCountingListview();
        }

        /// <summary>
        /// Graba el depósito en base de datos
        /// </summary>
        private void SaveTransaction()
        {
            _operationStatus.CurrentTransactionAmount += currentCountingAmount;

            PQDepositario.Business.Tables.Operacion.Sesion sesiones = new();
            sesiones.Items(null, DatabaseController.CurrentUser.Id, null, null,null);


            PQDepositario.Business.Tables.Operacion.Transaccion transactions = new();
            PQDepositario.Business.Tables.Operacion.TransaccionDetalle transactionDetails = new();

            if (_operationStatus.CurrentTransactionId == 0)
            {
                PQDepositario.Entities.Tables.Operacion.Transaccion transaction = new()
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

            foreach (var item in _detectedDenominations)
            {
                if (item.CantidadDetectada > 0)
                {
                    PQDepositario.Entities.Tables.Operacion.TransaccionDetalle transactionDetail = new()
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
        public  bool DepositEnded { get; set; } = false;
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

    public class DenominationItem : PQDepositario.Entities.Tables.Valor.Denominacion
    {
        public int CantidadDetectada { get; set; }
    }
}
