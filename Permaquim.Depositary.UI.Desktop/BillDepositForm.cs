﻿using Newtonsoft.Json;
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
        private List<DenominationItem> _denominacionesDetectadas = new();
        /// <summary>
        /// Estado previo al actual
        /// </summary>
        private System.Windows.Forms.Timer _poolingTimer = new System.Windows.Forms.Timer();


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
                Interval = 100,
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

        /// <summary>
        /// 
        /// </summary>
        /* private void ProcessDeviceStatus()
         {
             // Marca en la máquina de estado que se detectó el máximo de billetes
             // en el escrow, ya que esto modifica el comportamiento de la aplicación
             // en base al comportamiento de la contadora cuendo esto sucede
             if (_device.StateResultProperty.DeviceStateInformation.StackerFull)
                 _operationStatus.StackerFull = true;

             // Esto le indica al sistema que en el proximo ciclo debe salir a la pantalla anterior 
             if (_device.StateResultProperty.EndInformation.StoreEnd == true)
                 _operationStatus.DepositEnded = true;

             if (
                     _operationStatus.DepositEnded && 
                     _device.StateResultProperty.StatusInformation.OperatingState
                     == StatusInformation.State.Waiting &&
                     _operationStatus.CurrentTransactionId == 0 
                 )
             {
                 ExitBillDepositForm();
             }

             if (_device.CurrentStatus == StatusInformation.State.BeingSet
                 || _device.CurrentStatus == StatusInformation.State.BeingReset)
             {
                 if (BillResumeListview.Items.Count > 0 && CancelDepositButton.Visible == false)
                 {
                      CancelDepositButton.Visible = true;
                     BackButton.Visible = true;
                 }

                 if(!_operationStatus.DepositEnded)
                     // Comando para que cuente el dinero presente en el hopper
                     _device.BatchDataTransmission();
             }



             // Si se canceló la operación, debe esperar a que el operador quite el dinero del escrow
             if (
                 _device.PreviousState == StatusInformation.State.PQWaitingToRemoveBankNotes &&
                 (_device.CurrentStatus != StatusInformation.State.PQWaitingTocloseEscrow
                 || _device.CurrentStatus != StatusInformation.State.PQClosingEscrow)
                 && _device.StateResultProperty.DeviceStateInformation.EscrowBillPresent == false
                 )
             {
                 WaitEmptyEscrow();
             }
             else
             {
                 if(_device.StateResultProperty.DeviceStateInformation.EscrowBillPresent == false)
                     _device.CloseEscrow();
             }
             if(_device.DenominationResultProperty.DenominationArray.Length > 0)
                 LoadDetectedBills();

             EnableOrdisableButtons();
         }*/
        private void ProcessDeviceStatus()
        {
            //// Consulta el buffer de denominaciones etectadas
            _device.CountingDataRequest();

            // Se evalúa si se debe grabar en base de datos cuando finaliza la operación
            if (
                _operationStatus.DepositConfirmed &&
                !_device.StateResultProperty.DeviceStateInformation.EscrowBillPresent
                )
            {
                ExitBillDepositForm();
                _operationStatus.DepositEnded = true;
            }


            StatusInformation.State generalStatus = _device.CurrentStatus;

            if (generalStatus == StatusInformation.State.BeingSet
                || generalStatus == StatusInformation.State.BeingReset)
            {
                if (BillResumeListview.Items.Count > 0 && CancelDepositButton.Enabled == false)
                {
                    CancelDepositButton.Enabled = true;
                    BackButton.Enabled = true;
                }
                // Comando para que cuente el dinero presente en el hopper
                _device.BatchDataTransmission();
            }

            // Si el estado pasa de Contando a BeingReset, se pone en modo Neutral y sale de la pantalla
            if (_device.PreviousState == StatusInformation.State.PQCounting &&
                generalStatus != StatusInformation.State.PQCounting)
            {
                _device.RemoteCancel();

                _device.PreviousState = StatusInformation.State.Waiting;
                AppController.OpenChildForm(new OperationForm(), _device);
                this.Close();
            }

            // Si se canceló la operación, debe esperar a que el operador quite el dinero del escrow
            if (
                _device.PreviousState == StatusInformation.State.PQWaitingToRemoveBankNotes &&
                (generalStatus != StatusInformation.State.PQWaitingTocloseEscrow
                || generalStatus != StatusInformation.State.PQClosingEscrow)
                && _device.StateResultProperty.DeviceStateInformation.EscrowBillPresent == false
                )
            {
                _poolingTimer.Enabled = false;
                // Cambia el estado 
                _device.PreviousState = _device.StateResultProperty.StatusInformation.OperatingState;
                _device.RemoteCancel();
                _device.CloseEscrow();
                CleanDetectedBills();

                _device.DepositMode();
                _poolingTimer.Enabled = true;
            }

            // si existen denominaciones leídas carga el Listview
            if (_device.DenominationResultProperty.DenominationArray.Length > 0)
                LoadDetectedBills();

            //Solo se habilita el botón de volver si no hay dinero en el escrow
            BackButton.Enabled = !_device.StateResultProperty.DeviceStateInformation.EscrowBillPresent;

            ConfirmAndExitDepositButton.Enabled = _device.StateResultProperty.DeviceStateInformation.EscrowBillPresent
                && !_device.StateResultProperty.DeviceStateInformation.RejectedBillPresent
                && !_device.StateResultProperty.DeviceStateInformation.HopperBillPresent;
            CancelDepositButton.Enabled = _device.StateResultProperty.DeviceStateInformation.EscrowBillPresent;
        }

        private void ResolveStackerFullCondition()
        {
            _poolingTimer.Enabled = false;

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
            _poolingTimer.Enabled = true;
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
        private void LoadDetectedBills()
        {
            if (_device.DenominationResultProperty.DenominationArray != null 
                && _device.DenominationResultProperty.DenominationArray.Length == 96)
            {
                _denominacionesDetectadas = new List<DenominationItem>();
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

                    _denominacionesDetectadas.Add(new DenominationItem()
                    {
                        Id = item.Id,
                        Nombre = item.Nombre,
                        Unidades = item.Unidades,
                        CantidadDetectada = value
                    });
                }
            }

            Decimal amount = 0;
            int quantity = 0;

            if (_denominacionesDetectadas.Count > 0)
            {
                // Actualiza las denominaciones con el valor detectado 
                foreach (var denomination in _denominacionesDetectadas)
                {
                    if (BillResumeListview.Items.Count > 0)
                    {
                        BillResumeListview.Items[(int)denomination.Id]
                            .SubItems[1].Text = denomination.CantidadDetectada.ToString();
                        BillResumeListview.Items[(int)denomination.Id]
                            .SubItems[2].Text = (denomination.CantidadDetectada * Convert.ToInt32(denomination.Unidades)).ToString();
          
                        amount += Convert.ToInt32(denomination.Unidades) * denomination.CantidadDetectada;
                        quantity += denomination.CantidadDetectada;
                    }
                }
                
                //Totales
                if (BillResumeListview.Items.Count > 0)
                {
                    BillResumeListview.Items[BillResumeListview.Items.Count - 1]
                    .SubItems[1].Text = quantity.ToString();
                    BillResumeListview.Items[BillResumeListview.Items.Count - 1]
                        .SubItems[2].Text = amount.ToString();
                }
            }
            else
            {
                foreach (ListViewItem item in BillResumeListview.Items)
                {
                    item.SubItems[1].Text = "0";
                }
                amount = 0;
            }

            CancelDepositButton.Visible = true;
        }
        private void CancelDepositButton_Click(object sender, EventArgs e)
        {
            CancelDeposit();
        }

        private void CancelDeposit()
        {
            _operationStatus.Initialize();
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
            DisableControls();
            SaveTransaction();
        }

        private void DisableControls()
        {
            BillResumeListview.Visible = false;
            BackButton.Visible = false;
            CancelDepositButton.Visible = false;
            ConfirmAndExitDepositButton.Visible = false;

        }

        private void SetBackButtonEnabled()
        {
            BackButton.Visible = (
                _device.StateResultProperty.DeviceStateInformation.HopperBillPresent == false
                ||
                _device.StateResultProperty.DeviceStateInformation.EscrowBillPresent == false

                );

        }
        private void LoadBillListview()
        {
            BillResumeListview.SmallImageList = _imageList;
            foreach (var denomination in _denominaciones)
            {
                ListViewItem item = new();
                item.ImageIndex = (int)denomination.Id;
                item.Text = denomination.Nombre;
                item.SubItems.Add("0");
                item.SubItems.Add("0");
                BillResumeListview.Items.Add(item);

            }
            ListViewItem totalItem = new();
            totalItem.Text = "Totales";
            totalItem.SubItems.Add("0");
            totalItem.SubItems.Add("0");
            BillResumeListview.Items.Add(totalItem);

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
            LoadBillListview();
        }

        /// <summary>
        /// Graba el depósito en base de datos
        /// </summary>
        private void SaveTransaction()
        {
            Double amount = 0;
            foreach (var item in _denominacionesDetectadas)
            {
                amount +=  Convert.ToDouble(item.CantidadDetectada * item.Unidades);
            }

                PQDepositario.Business.Tables.Operacion.Sesion sesiones = new();
            sesiones.Items(null, 0, null, null,null);


            PQDepositario.Business.Tables.Operacion.Transaccion transactions = new();
            PQDepositario.Business.Tables.Operacion.TransaccionDetalle transactionDetails = new();

            // Se almacena en esta variable, para el caso en que la cantidad de billetes en la
            // pre bóveda exceda el límite. Se deben agragar los sucesivos detalles con el mismo
            // Id de transacción

            //if (_currentTransactionId == 0)
            //{
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
                    TotalValidado = amount,
                    TurnoId = 0,
                    UsuarioCuentaId = 0,
                    UsuarioId = 0

                };
                transactions.Add(transaction);
                _operationStatus.CurrentTransactionId = transaction.Id;
            //}


            foreach (var item in _denominacionesDetectadas)
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
