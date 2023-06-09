﻿using Newtonsoft.Json;
using Permaquim.Depositario.Entities.Tables.Operacion;
using Permaquim.Depositary.UI.Desktop.Components;
using Permaquim.Depositary.UI.Desktop.Controllers;
using Permaquim.Depositary.UI.Desktop.Global;
using System.Buffers;
using System.Diagnostics;
using System.Text;
using static Permaquim.Depositary.UI.Desktop.Global.Enumerations;

namespace Permaquim.Depositary.UI.Desktop
{
    public partial class BillDepositForm : Form
    {

        /// <summary>
        /// Instancia del dispositivo
        /// </summary>
        public CounterDevice _device { get; set; }
        private const string DEPOSITO_BILLETE = "Deposito de billete";
        private const string DEPOSITO_BILLETE_CANCELADO = "Deposito de billete Cancelado";
        private const string WAITING = "WAITING";
        private const string STORINGERROR = "STORINGERROR";
        private const string CONTINUACION_DEPOSITO = "Continuación de depósito de billetes";
        private const string DETECCION_BILLETES = "Detección de billetes";
        

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


        private int _countingCycle = 1;
        private int _greenStatusIndicator;
        private int _yellowStatusIndicator;
        private int _redStatusIndicator;

        List<Permaquim.Depositario.Entities.Tables.Operacion.Transaccion> _headerTransaction = new();
        List<Permaquim.Depositario.Entities.Tables.Operacion.TransaccionDetalle> _detailTransactions = new();

        public BillDepositForm()
        {
            InitializeComponent();

            LoadStyles();
            CenterPanel();
            Loadparameters();
            TimeOutController.Reset();


        }
        private void DeviceStateChange(object sender, DeviceStateChangeEventArgs args)
        {
            if (args.StateName.Equals( Global.Constants.PQCOMMUNICATIONERROR))
                AuditController.Log(LogTypeEnum.Navigation, args.StateName, args.StateName);

            if (_operationStatus.StackerFullCondition)
            {
                FormsController.SetInformationMessage(InformationTypeEnum.Information,
                         MultilanguangeController.GetText(MultiLanguageEnum.CONTINUAR_INGRESANDO_BILLETES));
                return; ;
            }

            if (args.StateName.ToUpper().Equals(STORINGERROR))
            {
                FormsController.SetInformationMessage(InformationTypeEnum.Event,
                    MultilanguangeController.GetText(MultiLanguageEnum.DEPOSITO_FINALIZADO_CON_ERROR));
                return;
            }

            if (args.StateName.ToUpper().Equals(WAITING))
            {
                if (_device.PreviousState == StatusInformation.State.PQStoring 
                    && _operationStatus.DepositConfirmed)
                {
                    _device.PreviousState = StatusInformation.State.BeingSet;
                    FormsController.SetInformationMessage(InformationTypeEnum.Event, 
                        MultilanguangeController.GetText(MultiLanguageEnum.DEPOSITO_FINALIZADO_CORRECTAMENTE));
                    ExitForm();
                }

            }
        }

        private void BillDepositForm_Load(object sender, EventArgs e)
        {
            _device = (Permaquim.Depositary.UI.Desktop.Components.CounterDevice)this.Tag;

                        _detectedDenominations = new();

            _pollingTimer = new System.Windows.Forms.Timer()
            {
                Interval = DeviceController.GetPollingInterval(),
                Enabled = true
            };
            _pollingTimer.Tick += PollTimer_Tick;

            _operationStatus = new();
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
        private void Loadparameters()
        {
            _greenStatusIndicator = ParameterController.GreenStatusIndicator;
            _yellowStatusIndicator = ParameterController.YellowStatusIndicator;
            _redStatusIndicator = ParameterController.RedStatusIndicator;
        }
        private void BillDepositForm_VisibleChanged(object sender, EventArgs e)
        {

            MonitorGroupcheckbox.Visible = ConfigurationController.IsDevelopment();

            if (this.Visible)
            {
                if (ParameterController.UsesShutter)
                    _device.OpenShutter();

                _device.DeviceStateChange += DeviceStateChange;

                AuditController.Log(LogTypeEnum.Navigation, DEPOSITO_BILLETE, DEPOSITO_BILLETE);
                LoadCurrentContainer();
                LoadLanguageItems();
                EnableDisableControls(false);
                LoadDenominations();
                if (_device != null)
                {
                    if (_device.StateResultProperty != null)
                    {
                        _device.PreviousState = StatusInformation.State.Waiting;
                        if (!_device.StateResultProperty.DeviceStateInformation.EscrowBillPresent)
                            ButtonsPanel.Visible = true;
                        if (_device.StateResultProperty.DoorStateInformation.Escrow)
                            _device.CloseEscrow();
                    }
                }
                _countingCycle = 1;
            }
            else
            {
                _device.DeviceStateChange -= DeviceStateChange;
                InitializeLocals();
                _device.RemoteCancel();
                if (ParameterController.UsesShutter)
                    _device.CloseShutter();
            }
            _pollingTimer.Enabled = this.Visible;

            FormsController.SetInformationMessage(InformationTypeEnum.None, string.Empty);
        }

        private void InitializeLocals()
        {
            _operationStatus = new();
            _denominaciones = new();
            _detectedDenominations = new();
            _depositItems = new();


            FormsController.SetInformationMessage(InformationTypeEnum.None, string.Empty);
        }
        private void CenterPanel()
        {
            MainPanel.Location = new Point()
            {
                X = this.Width / 2 - MainPanel.Width / 2,
                Y = this.Height / 2 - MainPanel.Height / 2
            };
            DenominationsGridView.Location = new Point()
            {
                X = MainPanel.Width / 2 - DenominationsGridView.Width / 2,
                Y = DenominationsGridView.Location.Y
            };

            BackButton.Location = new Point()
            {
                X = MainPanel.Width / 2 - BackButton.Width / 2,
                Y = BackButton.Location.Y
            };

            ButtonsPanel.Location = new Point()
            {
                X = DenominationsGridView.Location.X,
                Y = ButtonsPanel.Location.Y
            };

            CancelDepositButton.Location = new Point()
            {
                X = CancelDepositButton.Location.X,
                Y = CancelDepositButton.Location.Y
            };

            CurrencyLabel.Left = DenominationsGridView.Left;

        }
        private void LoadLanguageItems()
        {
            CurrencyLabel.Text = DatabaseController.CurrentCurrency.Nombre;
            ConfirmAndExitDepositButton.Text = MultilanguangeController.GetText(MultiLanguageEnum.BOTON_ACEPTAR_OPERACION);
            ConfirmAndContinueDepositButton.Text = MultilanguangeController.GetText(MultiLanguageEnum.BOTON_CONTINUAR);
            CancelDepositButton.Text = MultilanguangeController.GetText(MultiLanguageEnum.BOTON_CANCELAR_OPERACION);
            BackButton.Text = MultilanguangeController.GetText(MultiLanguageEnum.VOLVER);
            GrandTotalLabel.Text = MultilanguangeController.GetText(MultiLanguageEnum.TOTAL_GENERAL);

            DenominationsGridView.Columns["Image"].HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.IMAGEN);
            DenominationsGridView.Columns["Denomination"].HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.DENOMINACION);
            DenominationsGridView.Columns["Quantity"].HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.CANTIDAD);
            DenominationsGridView.Columns["Amount"].HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.IMPORTE);
        }
        private void LoadStyles()
        {
            this.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.FondoFormulario);

            CurrencyLabel.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.SegundaCabeceraGrilla);
            CurrencyLabel.ForeColor = StyleController.GetColor(Enumerations.ColorNameEnum.FuenteContraste);

            SubtotalLabel.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.SegundaCabeceraGrilla);
            SubtotalLabel.ForeColor = StyleController.GetColor(Enumerations.ColorNameEnum.FuenteContraste);

            GrandTotalLabel.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.SegundaCabeceraGrilla);
            GrandTotalLabel.ForeColor = StyleController.GetColor(Enumerations.ColorNameEnum.FuenteContraste);

            ConfirmAndExitDepositButton.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.BotonAceptar);
            ConfirmAndExitDepositButton.ForeColor = StyleController.GetColor(Enumerations.ColorNameEnum.FuenteContraste);

            ConfirmAndContinueDepositButton.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.BotonAceptar);
            ConfirmAndContinueDepositButton.ForeColor = StyleController.GetColor(Enumerations.ColorNameEnum.FuenteContraste);

            CancelDepositButton.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.BotonCancelar);
            CancelDepositButton.ForeColor = StyleController.GetColor(Enumerations.ColorNameEnum.FuenteContraste);

            BackButton.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.BotonSalir);
            BackButton.ForeColor = StyleController.GetColor(Enumerations.ColorNameEnum.FuenteContraste);


            StyleController.SetControlStyle(DenominationsGridView);

        }
        private void PollTimer_Tick(object? sender, EventArgs e)
        {
            if (TimeOutController.IsTimeOut())
            {
                // si existe dinero en el hopper, se asume que el usuario desea
                // seguir depositando
                if (_device.StateResultProperty.DeviceStateInformation.HopperBillPresent)
                {
                    TimeOutController.Reset();
                    return;
                }

                _operationStatus.IsAutoDeposit = true;

                if (_device.StateResultProperty != null
                    && _device.StateResultProperty.DeviceStateInformation.EscrowBillPresent
                    //|| _currentCountingAmount > 0)
                    || _operationStatus.CurrentTransactionAmount > 0)

                {
                    _operationStatus.DepositConfirmed = true;
                    ConfirmAndExitDeposit();
                }
                else
                {
                    if (_device.StateResultProperty != null && _operationStatus.CurrentTransactionId != 0)
                    {
                        PrintTicket();
                    }
                    if (!_device.StateResultProperty.DeviceStateInformation.EscrowBillPresent)
                    {
                        _device.CloseEscrow();
                        DatabaseController.LogOff(true);
                        FormsController.LogOff();
                    }
                    else
                    {
                        TimeOutController.Reset();
                    }
                }
            }
            else
            {
                if (_device != null && _device.CounterConnected)
                {
                    if (_device.StateResultProperty.ModeStateInformation.ModeState 
                        != ModeStateInformation.Mode.DepositMode)
                    {
                        _device.RemoteCancel();
                        _device.Sleep();
                        _device.DepositMode();
                    }
                    else
                    {
                        // Muestra el estado del hardware
                        ShowHardwareMonitorData();
                        // Procesa los estados 
                        ProcessDeviceStatus();
                    }
                }
            }
            SetSubTotalsValues();
        }

        public bool EsMultiplo(int numero, int multiplo)
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


            if (_device.StateResultProperty.DeviceStateInformation.HopperBillPresent)
                TimeOutController.Reset();

            VerifySaveToDatabase();
            if(!_operationStatus.DepositConfirmed)
            {
                VerifyStartCounting();
            }

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
                    && !_device.StateResultProperty.DeviceStateInformation.StackerFull
                    && _device.StateResultProperty.StatusInformation.OperatingState
                        != StatusInformation.State.PQCounting
                    && !_device.StateResultProperty.DeviceStateInformation.HopperBillPresent
                    && _operationStatus.DepositCancelled == false
                    && _operationStatus.DepositConfirmed == false;

                if ((_device.StateResultProperty.DeviceStateInformation.StackerFull
                    || _operationStatus.StackerFullCondition)
                    && _device.StateResultProperty.DeviceStateInformation.HopperBillPresent)
                {
                    ConfirmAndExitDepositButton.Visible = false;
                }
                else
                {
                    ConfirmAndExitDepositButton.Visible =
                    (
                        (_device.StateResultProperty.DeviceStateInformation.EscrowBillPresent
                        && _operationStatus.DepositConfirmed == false
                        && _operationStatus.DepositCancelled == false)
                        && _device.StateResultProperty.DoorStateInformation.Escrow == false
                        && (_device.StateResultProperty.StatusInformation.OperatingState
                        == StatusInformation.State.BeingReset ||
                        _device.StateResultProperty.StatusInformation.OperatingState
                        == StatusInformation.State.BeingReset)
                        && _device.StateResultProperty.DeviceStateInformation.EscrowBillPresent
                            && !_device.StateResultProperty.DeviceStateInformation.RejectedBillPresent
                        );
                }

                CancelDepositButton.Visible =
                    (_device.StateResultProperty.DeviceStateInformation.EscrowBillPresent
                    && _operationStatus.DepositConfirmed == false
                    && _operationStatus.DepositCancelled == false)
                    && _device.StateResultProperty.DoorStateInformation.Escrow == false
                    && (_device.StateResultProperty.StatusInformation.OperatingState
                    == StatusInformation.State.BeingReset ||
                    _device.StateResultProperty.StatusInformation.OperatingState
                    == StatusInformation.State.BeingSet)
                    // Se agrega la condición en el caso de depósito subsecuente
                    || (!_device.StateResultProperty.DeviceStateInformation.EscrowBillPresent
                    && _device.StateResultProperty.StatusInformation.OperatingState
                    == StatusInformation.State.Waiting
                     //&& _device.StateResultProperty.DeviceStateInformation.StackerFull
                     && _operationStatus.StackerFullCondition == true
                    );

                ConfirmAndContinueDepositButton.Visible =
                        _device.StateResultProperty.DeviceStateInformation.StackerFull
                        && _device.StateResultProperty.StatusInformation.OperatingState
                        == StatusInformation.State.BeingReset
                        && !_device.StateResultProperty.DeviceStateInformation.RejectedBillPresent
                        && _operationStatus.DepositCancelled == false
                        && _operationStatus.DepositConfirmed == false
                        ;


                ButtonsPanel.Visible = true;

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

            if (_device.IoBoardStatusProperty.GateState == IoBoardStatus.GATE_STATE.CLOSED)
            {


                if (!_device.StateResultProperty.DeviceStateInformation.EscrowBillPresent
                    && _operationStatus.CurrentTransactionQuantity == 0
                    && _device.StateResultProperty.StatusInformation.OperatingState != StatusInformation.State.PQWaitingTocloseEscrow
                    && _device.StateResultProperty.StatusInformation.OperatingState != StatusInformation.State.PQCounting
                    && !_operationStatus.DepositEnded)
                {
                    FormsController.SetInformationMessage(InformationTypeEnum.Information,
                        MultilanguangeController.GetText(MultiLanguageEnum.INGRESAR_BILLETES));
                    return;
                }


                if(_device.StateResultProperty.DeviceStateInformation.EscrowBillPresent
                    && _operationStatus.DepositCancelled
                    && _device.StateResultProperty.StatusInformation.OperatingState != StatusInformation.State.PQWaitingTocloseEscrow)
                {
                    FormsController.SetInformationMessage(InformationTypeEnum.Alert,
                         MultilanguangeController.GetText(MultiLanguageEnum.RETIRE_VALORES_ESCROW));
                    return;
                }

                if (_device.StateResultProperty.StatusInformation.OperatingState == StatusInformation.State.PQCounting)
                {
                    FormsController.SetInformationMessage(InformationTypeEnum.Event,
                        MultilanguangeController.GetText(MultiLanguageEnum.CONTANDO));
                    TimeOutController.Reset();
                    return;
                }

                if (_device.StateResultProperty.StatusInformation.OperatingState == StatusInformation.State.PQStoring)
                {
                    FormsController.SetInformationMessage(InformationTypeEnum.Information,
                    MultilanguangeController.GetText(MultiLanguageEnum.AGUARDE_DEPOSITO));
                    TimeOutController.Reset();
                    return;
                }

                if (_device.StateResultProperty.DeviceStateInformation.RejectedBillPresent)
                {
                    FormsController.SetInformationMessage(InformationTypeEnum.Error,
                        MultilanguangeController.GetText(MultiLanguageEnum.RETIRAR_BILLETES_RECHAZADOS));
                    return;
                }
                if (_device.StateResultProperty.DeviceStateInformation.EscrowBillPresent
                     && _operationStatus.CurrentTransactionQuantity == 0
                     && !_device.StateResultProperty.DeviceStateInformation.RejectedBillPresent
                     && _device.StateResultProperty.StatusInformation.OperatingState != StatusInformation.State.PQCounting)
                {
                    if (_device.StateResultProperty.DeviceStateInformation.StackerFull)
                    {
                        FormsController.SetInformationMessage(InformationTypeEnum.Information,
                        MultilanguangeController.GetText(MultiLanguageEnum.ESCROW_LLENO));
                        return;
                    }
                    else
                    {
                        FormsController.SetInformationMessage(InformationTypeEnum.Information,
                            MultilanguangeController.GetText(MultiLanguageEnum.ACEPTAR_O_CANCELAR_DEPOSITO));
                        return;
                    }
                }
                if (_device.StateResultProperty.DeviceStateInformation.EscrowBillPresent
                        && _operationStatus.CurrentTransactionQuantity > 0)
                {
                    FormsController.SetInformationMessage(InformationTypeEnum.Information,
                    MultilanguangeController.GetText(MultiLanguageEnum.ACEPTAR_O_CANCELAR_DEPOSITO));
                    return;
                }
                if (_device.StateResultProperty.DeviceStateInformation.EscrowBillPresent
                    && _operationStatus.CurrentTransactionQuantity == 0
                    && _device.StateResultProperty.StatusInformation.OperatingState == StatusInformation.State.PQWaitingToRemoveBankNotes)
                {
                    FormsController.SetInformationMessage(InformationTypeEnum.Error,
                        MultilanguangeController.GetText(MultiLanguageEnum.CANCELAR_DEPOSITO));
                    return;

                }

                if (_device.StateResultProperty.DeviceStateInformation.StackerFull)
                {
                    _countingCycle += 1;
                    FormsController.SetInformationMessage(InformationTypeEnum.Error,
                    MultilanguangeController.GetText(MultiLanguageEnum.ESCROW_LLENO));
                    return;
                }

                if (_device.StateResultProperty.EndInformation.StoreEnd)
                {
                    FormsController.SetInformationMessage(InformationTypeEnum.Information,
                        MultilanguangeController.GetText(MultiLanguageEnum.FIN_DEPOSITO));
                    return;
                }
            }
            else
            {
                if (_device.IoBoardStatusProperty.GateState == IoBoardStatus.GATE_STATE.OPEN)
                {
                    FormsController.SetInformationMessage(InformationTypeEnum.Error,
                        MultilanguangeController.GetText(MultiLanguageEnum.PUERTA_ABIERTA));
                    return;
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
                 ExitForm();
                
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
        private void VerifySaveToDatabase()
        {
            if (
                _operationStatus.DepositConfirmed &&
                !_device.StateResultProperty.DeviceStateInformation.EscrowBillPresent
                )
            {
                //ExitBillDepositForm();
                _operationStatus.DepositEnded = true;
            }
        }

        private void CleanDetectedBills()
        {
            _device.DenominationResultProperty.Denominations = new Dictionary<string, int>();

        }

        private void ShowHardwareMonitorData()
        {

            int generalStatus = (int)_device.StateResultProperty.StatusInformation.OperatingState;
            GeneralStatusLabel.Text = Enum.GetName(typeof(StatusInformation.State), generalStatus);

            PreviousStatusLabel.Text = Enum.GetName(typeof(StatusInformation.State), _device.PreviousState);

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

            BatchEndCheckBox.Checked = _device.StateResultProperty.EndInformation.BatchEnd;
            CountEndCheckBox.Checked = _device.StateResultProperty.EndInformation.CountEnd;
            StoreEndCheckBox.Checked = _device.StateResultProperty.EndInformation.StoreEnd;
            CollectEndCheckBox.Checked = _device.StateResultProperty.EndInformation.CollectEnd;
            checkBoxEscrow.Checked = _device.StateResultProperty.DoorStateInformation.Escrow;

        }
        /// <summary>
        /// Si existen denominaciones detectadas carga la grilla
        /// </summary>
        private void VerifyLoadDetectedBills()
        {

            if (!_operationStatus.DepositConfirmed)
            {
                //_currentCountingAmount = 0;
                //_currentCountingQuantity = 0;
                _operationStatus.CurrentTransactionPartialAmount= 0;
                _operationStatus.CurrentTransactionPartialQuantity = 0;

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

                        if(value > 0)
                        {
                            Debug.Print("");
                        }

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
                    string denominationsData = JsonConvert.SerializeObject(_detectedDenominations, Formatting.Indented);

                    AuditController.Log(LogTypeEnum.Information, DETECCION_BILLETES, denominationsData);

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

                            //_currentCountingAmount += Convert.ToInt32(denomination.Unidades) * denomination.CantidadDetectada;
                            //_currentCountingQuantity += denomination.CantidadDetectada;

                           _operationStatus.CurrentTransactionPartialAmount += 
                                Convert.ToInt32(denomination.Unidades) * denomination.CantidadDetectada;
                            _operationStatus.CurrentTransactionPartialQuantity += denomination.CantidadDetectada;
                        }
                    }
                }
                else
                {
                    //_currentCountingAmount = 0;
                    _operationStatus.CurrentTransactionPartialAmount = 0;
                }

                SetTotals();

                CancelDepositButton.Visible = true;
            }
        }

        private void SetTotals()
        {
            SubtotalLabel.Text = MultilanguangeController.GetText(MultiLanguageEnum.SUB_TOTAL) +
                DatabaseController.CurrentCurrency.Simbolo + " "
                + _operationStatus.CurrentTransactionAmount.ToString();
            if (_operationStatus.CurrentTransactionId != 0)
                Debug.Print("");
            //if (_operationStatus.CurrentTransactionAmount != _currentCountingAmount)
            if (_operationStatus.CurrentTransactionAmount != _operationStatus.CurrentTransactionPartialAmount)
            {
                GrandTotalLabel.Text = MultilanguangeController.GetText(MultiLanguageEnum.TOTAL_GENERAL) +
                    DatabaseController.CurrentCurrency.Simbolo + " "
                    //+ (_operationStatus.CurrentTransactionAmount + _currentCountingAmount).ToString();
                +(_operationStatus.CurrentTransactionAmount + _operationStatus.CurrentTransactionPartialAmount).ToString();
            }

        }
        private void SetSubTotalsValues()
        {
            if (DenominationsGridView.Rows.Count > 0)
            {
                //Totales
                DenominationsGridView.Rows[DenominationsGridView.Rows.Count - 1].Cells["Quantity"].Value =
                (_operationStatus.CurrentTransactionPartialQuantity).ToString();
                DenominationsGridView.Rows[DenominationsGridView.Rows.Count - 1].Cells["Amount"].Value =
                    DatabaseController.CurrentCurrency.Simbolo + " " +
                        //_currentCountingAmount.ToString();
                    _operationStatus.CurrentTransactionPartialAmount.ToString();
            }
        }

        private void SetcolumnsAlignment()
        {

            DenominationsGridView.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DenominationsGridView.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            DenominationsGridView.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DenominationsGridView.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            SetTotals();
        }

        private void CancelDepositButton_Click(object sender, EventArgs e)
        {
            ButtonsPanel.Visible = false;
            TimeOutController.Reset();
            CancelDeposit();
            AuditController.Log(LogTypeEnum.Information,
                DEPOSITO_BILLETE_CANCELADO,
                DEPOSITO_BILLETE_CANCELADO);
            CancelDepositButton.Visible = false;
            ButtonsPanel.Visible = true;
        }

        private void CancelDeposit()
        {
            // Si se cancela luego de haber depositado  billetes
            // se imprimer el ticket de lo depositado hasta este momento
            if (_operationStatus.CurrentTransactionAmount != 0)
            {
                ConfirmEndTransaction(true);
                if(!_device.StateResultProperty.DeviceStateInformation.EscrowBillPresent)
                    ExitForm();
            }

            _operationStatus.DepositConfirmed = false;
            _operationStatus.DepositCancelled = true;
            ConfirmAndExitDepositButton.Visible = false;
            _operationStatus.StackerFull = false;
            if (_device.StateResultProperty.DeviceStateInformation.EscrowBillPresent)
            {
                _device.OpenEscrow();
                _device.PreviousState = StatusInformation.State.PQWaitingToRemoveBankNotes;
            }
        }
        /// <summary>
        /// Setea como finalizada = false;
        /// </summary>
        private void ConfirmEndTransaction(bool finished , bool isAutoDeposit = false)
        {
            Permaquim.Depositario.Business.Tables.Operacion.Transaccion transactions = new();

            transactions.Items(_operationStatus.CurrentTransactionId);
            if (transactions.Result.Count > 0)
            {
                var previousTransacion = transactions.Result.FirstOrDefault();

                previousTransacion.Finalizada = finished;
                previousTransacion.EsDepositoAutomatico = isAutoDeposit;

                transactions.Update(previousTransacion);

            }

        }
        private void ConfirmAndExitDepositButton_Click(object sender, EventArgs e)
        {
            if (_device.CounterConnected)
            {
                _operationStatus.IsAutoDeposit = false;
                ConfirmAndExitDeposit();
            }
        }
        private void ConfirmAndExitDeposit()
        {
            _device.RemoteCancel();
            _operationStatus.StackerFullCondition = false;

            _operationStatus.CurrentTransactionAmount += _operationStatus.CurrentTransactionPartialAmount;

            TimeOutController.Reset();
            ButtonsPanel.Visible = false;
            _operationStatus.DepositConfirmed = true;
            ConfirmDeposit();

        }

        private void ConfirmDeposit()
        {
            TimeOutController.Reset();
            CancelDepositButton.Visible = false;
            _device.StoringStart();

            _device.PreviousState = StatusInformation.State.PQStoring;
        }


        private void BackButton_Click(object sender, EventArgs e)
        {
            TimeOutController.Reset();
            if (_device != null)
            {
                if (_device.CounterConnected)
                    _device.RemoteCancel();
            }
            FormsController.OpenChildForm(this, new OperationForm(), _device);

        }
        /// <summary>
        /// Esta operación raliza lo siguiente: 
        /// Si es un depósito simple
        /// graba en la db la operación realizada
        /// Inicializa el modo de la contadora
        /// Sale a la pantalla del menú de operaciones
        /// si es multiple (más de la capacidad del stacker
        /// Graba en la db la operación realizada y continúa
        /// </summary>
        private void ExitForm()
        {
            _pollingTimer.Enabled = false;
            

            if (!_operationStatus.StackerFullCondition && _operationStatus.CurrentTransactionAmount > 0)
            {
                SaveTransaction(true, _operationStatus.IsAutoDeposit);
            }

            ConfirmEndTransaction(true, _operationStatus.IsAutoDeposit);
           

            if(_operationStatus.CurrentTransactionAmount > 0)
            {
                PrintTicket();
            }


            EnableDisableControls(false);
            _device.RemoteCancel();
            CleanDetectedBills();
            FormsController.SetInformationMessage(InformationTypeEnum.Information,
                 MultilanguangeController.GetText(MultiLanguageEnum.FIN_DEPOSITO));

            _operationStatus.DepositCancelled = false;

            _operationStatus.DepositEnded = true;

            if (_operationStatus.IsAutoDeposit)
            {
                DatabaseController.LogOff(true);
                FormsController.LogOff();
            }
            else
            {
                FormsController.OpenChildForm(this, new OperationForm(), _device);
            }
        }
        private void SaveAndContinueDeposit()
        {
            if (_device.CounterConnected)
            {
                _operationStatus.StackerFullCondition = true;

                _operationStatus.CurrentTransactionAmount += _operationStatus.CurrentTransactionPartialAmount;
                _operationStatus.CurrentTransactionQuantity = _operationStatus.CurrentTransactionPartialQuantity;

                SaveTransaction(false, _operationStatus.IsAutoDeposit);

                _device.PreviousState = StatusInformation.State.PQStoring;
                ButtonsPanel.Visible = false;
                _operationStatus.IsAutoDeposit = false;
                _operationStatus.StackerFullCondition = true;
                TimeOutController.Reset();
                if (ParameterController.UsesShutter)
                    _device.OpenShutter();
                _device.StoringStart();
            }
        }
       

        private void EnableDisableControls(bool value)
        {
            DenominationsGridView.Visible = value;
            CancelDepositButton.Visible = value;
            ConfirmAndExitDepositButton.Visible = value;
            CurrencyLabel.Visible = value;
            SubtotalLabel.Visible = value;
            GrandTotalLabel.Visible = value;

        }

        private void EnableDisableLabelsAndGrid(bool value)
        {
            DenominationsGridView.Visible = value;
            CurrencyLabel.Visible = value;
            SubtotalLabel.Visible = value;
            GrandTotalLabel.Visible = value;

        }
        #region Database Access

        public void LoadCurrentContainer()
        {
            var x = DatabaseController.CurrentContainer;
        }
        public void LoadDenominations()
        {

            _denominaciones = DatabaseController.GetCurrentCurrencyDenominations();

            _depositItems = new();

            foreach (var item in _denominaciones)
            {
                byte[] bytes = null;
                if (item.TipoValorId.Imagen.Length > 0)
                {
                    bytes = Convert.FromBase64String(item.Imagen
                    .Replace("data:image/jpeg;base64,", String.Empty)
                    .Replace("data:image/webp;base64,", String.Empty));
                }
                else
                {
                    ImageConverter converter = new ImageConverter();
                    bytes = (byte[])converter.ConvertTo(StyleController.CreateWhiteBitmap(), typeof(byte[]));
                }


                _depositItems.Add(new DepositItem()
                {
                    Amount = "0",
                    Denomination = item.MonedaId.Codigo + " " + item.Nombre,
                    Quantity = 0,
                    Image = System.Drawing.Image.FromStream(new MemoryStream(bytes))
                });

            }
            _depositItems.Add(new()
            {
                Denomination = "Total",
                Amount = "0",
                Image = StyleController.GetCellStyleBitmap(),
                Quantity = 0
            });
            DenominationsGridView.DataSource = _depositItems;
            EnableDisableLabelsAndGrid(true);
            SetcolumnsAlignment();
            StyleController.SetControlFooterStyle(DenominationsGridView);
        }

        /// <summary>
        /// Graba el depósito en base de datos
        /// </summary>
        private void SaveTransaction(bool finished = false, bool isAutoDeposit = false)
        {
            _operationStatus.CurrentTransactionPartialAmount = 0;

            Depositario.Business.Tables.Operacion.Transaccion transactions = new();

            try
            {

                string denominationsData = JsonConvert.SerializeObject(_detectedDenominations, Formatting.Indented);

                transactions.BeginTransaction();

                if (_operationStatus.CurrentTransactionId == 0)
                {

                    AuditController.Log(LogTypeEnum.Information, "Inicio de depósito de billetes", denominationsData);

                    Transaccion transaction = new()
                    {
                        CierreDiarioId = null,
                        ContenedorId = DatabaseController.CurrentContainer.Id,
                        DepositarioId = DatabaseController.CurrentDepositary.Id,
                        Fecha = DateTime.Now,
                        MonedaId = DatabaseController.CurrentCurrency.Id,
                        SectorId = DatabaseController.CurrentDepositary.SectorId.Id,
                        SesionId = DatabaseController.CurrentSession.Id,
                        SucursalId = DatabaseController.CurrentDepositary.SectorId.SucursalId.Id,
                        TipoId = (long)OperationTypeEnum.BillDeposit,// Depósito de Billete
                        TotalAValidar = 0,
                        TotalValidado = _operationStatus.CurrentTransactionAmount,
                        TurnoId = DatabaseController.CurrentTurn.Id,
                        CuentaId = DatabaseController.CurrentUserBankAccount == null ? null :
                            DatabaseController.CurrentUserBankAccount.CuentaId.Id,
                        UsuarioId = DatabaseController.CurrentUser.Id,
                        CodigoOperacion =
                            DatabaseController.CurrentDepositary.CodigoExterno + "-" + DateTime.Now.ToString("yyMMdd"),
                        OrigenValorId = DatabaseController.CurrentDepositOrigin == null ? null :
                            DatabaseController.CurrentDepositOrigin.Id,
                        Finalizada = finished,
                        EsDepositoAutomatico = isAutoDeposit,
                        UsuarioCreacion = DatabaseController.CurrentUser.Id,
                        UsuarioModificacion = null,
                        FechaCreacion = DateTime.Now,
                        FechaModificacion = null

                    };
                    _headerTransaction.Add(transactions.Add(transaction));
                    _operationStatus.CurrentTransactionId = transaction.Id;

                }
                else
                {

                    AuditController.Log(LogTypeEnum.Information, CONTINUACION_DEPOSITO, denominationsData);

                    transactions.Items(_operationStatus.CurrentTransactionId);
                    if (transactions.Result.Count > 0)
                    {
                        var previousTransaction = transactions.Result.FirstOrDefault();
                        previousTransaction.TotalValidado = _operationStatus.CurrentTransactionAmount;
                        previousTransaction.Finalizada = finished;
                        previousTransaction.EsDepositoAutomatico = isAutoDeposit;
                        previousTransaction.UsuarioModificacion = DatabaseController.CurrentUser.Id;
                        previousTransaction.FechaModificacion = DateTime.Now;

                        transactions.Update(previousTransaction);
                    }
                }

                Depositario.Business.Tables.Operacion.TransaccionDetalle transactionDetails = new(transactions);

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
                        _detailTransactions.Add(
                        transactionDetails.Add(transactionDetail)
                        );
                    }
                }


                Permaquim.Depositario.Business.Tables.Operacion.TransaccionDetalle _savedDetails = new(transactions);
                _savedDetails.Where.Add(Depositario.Business.Tables.Operacion.TransaccionDetalle.ColumnEnum.TransaccionId,
                    Depositario.sqlEnum.OperandEnum.Equal, _operationStatus.CurrentTransactionId);
                _savedDetails.Items();
                decimal detailsQuantity = 0;
                if (_savedDetails.Result.Count > 0)
                {
                    foreach (var item in _savedDetails.Result)
                    {
                        Permaquim.Depositario.Business.Tables.Valor.Denominacion _denimonations = new(transactions);
                        var units = _denimonations.Items(item.DenominacionId).FirstOrDefault().Unidades;

                        detailsQuantity += (units * item.CantidadUnidades);
                    }
                }

                if (detailsQuantity != (decimal)_operationStatus.CurrentTransactionAmount)
                {
                    transactions.Items(_operationStatus.CurrentTransactionId);
                    if (transactions.Result.Count > 0)
                    {
                        var previousTransaction = transactions.Result.FirstOrDefault();
                        previousTransaction.TotalValidado = (double)detailsQuantity;

                        transactions.Update(previousTransaction);
                    }
                }

                transactions.EndTransaction(true);

            }
            catch (Exception ex)
            {
                AuditController.Log(ex);
                transactions.EndTransaction(false);
            }

        }

        private void PrintTicket()
        {

            if (ConfigurationController.IsDevelopment())
            {
                MessageBox.Show("Ticket: " + _operationStatus.CurrentTransactionAmount.ToString("C2"));
                return;
            }

            if (ParameterController.PrintsBillDeposit)
            {
                var _header = DatabaseController.GetTransactionHeader(_operationStatus.CurrentTransactionId);
                var _details = DatabaseController.GetTransactionDetails(_operationStatus.CurrentTransactionId);

                //Consolidamos el detalle 
                List<Entities.BillDepositDetail> _consolidatedDetailsList = new List<Entities.BillDepositDetail>();
                foreach (var detailReportItem in _details)
                {
                    var detailExists = _consolidatedDetailsList.FirstOrDefault(x => x.DenominacionId == detailReportItem._DenominacionId);

                    if (detailExists != null)
                    {
                        detailExists.CantidadUnidades += detailReportItem.CantidadUnidades;
                    }
                    else
                    {
                        Entities.BillDepositDetail billDepositDetail = new();

                        billDepositDetail.CantidadUnidades = detailReportItem.CantidadUnidades;
                        billDepositDetail.Unidades = detailReportItem.DenominacionId.Unidades;
                        billDepositDetail.DenominacionId = detailReportItem._DenominacionId;
                        billDepositDetail.DenominacionNombre = detailReportItem.DenominacionId.Nombre;
                        billDepositDetail.MonedaCodigo = detailReportItem.DenominacionId.MonedaId.Codigo;

                        _consolidatedDetailsList.Add(billDepositDetail);
                    }
                }

                //Thread thread = new Thread(() =>
                //{
                for (int i = 0; i < ParameterController.PrintBillDepositQuantity; i++)
                {
                    ReportController.PrintReport(ReportTypeEnum.BillDeposit, _header, _consolidatedDetailsList, i);
                }

                //});
                //thread.Start();


            }
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

        private void RemainingTimeLabel_Click(object sender, EventArgs e)
        {
            TimeOutController.Reset();
        }

        private void MonitorGroupcheckbox_CheckStateChanged(object sender, EventArgs e)
        {
            MonitorGroupBox.Visible = MonitorGroupcheckbox.Checked;
        }

        private void DenominationsGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < DenominationsGridView.Rows.Count - 1 && e.ColumnIndex >= 0)
            {

                e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.Border);
                using (Pen p = new Pen(StyleController.GetColor(Enumerations.ColorNameEnum.ColorBordesCeldasGrilla), 1))
                {
                    Rectangle rect = e.CellBounds;
                    rect.Width -= 1;
                    rect.Height -= 1;
                    e.Graphics.DrawRectangle(p, rect);
                }
                e.Handled = true;

            }
        }

        private void BillDepositForm_MouseClick(object sender, MouseEventArgs e)
        {
            TimeOutController.Reset();
        }

        private void BillDepositForm_EnabledChanged(object sender, EventArgs e)
        {
            if(this.Enabled) {
                TimeOutController.Reset();
            }
            else
            {
                if (_operationStatus.CurrentTransactionAmount > 0)
                {
                    ConfirmEndTransaction(true, false);
                    PrintTicket();
                }
            }
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

        /// <summary>
        /// Indica que el usuario canceló el depósito
        /// </summary>
        public bool DepositCancelled { get; set; }
        public bool StackerFullCondition { get; set; }
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

        public Double CurrentTransactionPartialAmount { get; set; }

        public int CurrentTransactionPartialQuantity { get; set; }

        public StatusInformation.State GeneralStatus { get; set; }

        public bool IsAutoDeposit { get; set; }


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