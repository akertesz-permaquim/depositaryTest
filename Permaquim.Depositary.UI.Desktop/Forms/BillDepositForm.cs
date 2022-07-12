using Newtonsoft.Json;
using Permaquim.Depositary.UI.Desktop.Components;
using Permaquim.Depositary.UI.Desktop.Controllers;
using Permaquim.Depositary.UI.Desktop.Global;
using System.Text;
using static Permaquim.Depositary.UI.Desktop.Global.Enumerations;

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
        private Double _currentCountingAmount = 0;
        private int _currentCountingQuantity = 0;
        private int _countingCycle = 1;


        public BillDepositForm()
        {
            InitializeComponent();
            LoadStyles();
            CenterPanel();
            TimeOutController.Reset();
        }
        private void BillDepositForm_Load(object sender, EventArgs e)
        {
             _device = (Permaquim.Depositary.UI.Desktop.Components.Device)this.Tag;

            _detectedDenominations = new();

            _pollingTimer = new System.Windows.Forms.Timer()
            {
                Interval = DeviceController.GetPollingInterval(),
                Enabled = true
            };
            _pollingTimer.Tick += PollTimer_Tick;

            _operationStatus = new();


        }
        private void BillDepositForm_VisibleChanged(object sender, EventArgs e)
        {
            _pollingTimer.Enabled = this.Visible;

            MonitorGroupcheckbox.Visible = SecurityController.IsFunctionenabled(FunctionEnum.ViewEvents);

            if (this.Visible)
            {
                LoadCurrentContainer();
                LoadLanguageItems();
                EnableDisableControls(false);
                LoadDenominations();
                if (_device != null)
                {
                    if (_device.StateResultProperty != null)
                    {
                        if (!_device.StateResultProperty.DeviceStateInformation.EscrowBillPresent)
                            ButtonsPanel.Visible = true;
                    }
                }
                _countingCycle = 1;
            }
            else
            {
                InitializeLocals();
            }
        }

        private void InitializeLocals()
        {
            _operationStatus = new();
            _denominaciones = new();
            _detectedDenominations = new();
            _depositItems = new();
            _currentCountingAmount = 0;
            _currentCountingQuantity = 0;
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
                X = 0,
                Y = 0
            };

            CurrencyLabel.Left = DenominationsGridView.Left;
            
        }
        private void LoadLanguageItems()
        {
            CurrencyLabel.Text = DatabaseController.CurrentCurrency.Nombre;
            ConfirmAndExitDepositButton.Text = MultilanguangeController.GetText(MultiLanguageEnum.ACCEPT_BUTTON);
            ConfirmAndContinueDepositButton.Text = MultilanguangeController.GetText(MultiLanguageEnum.CONTINUE_BUTTON);
            CancelDepositButton.Text = MultilanguangeController.GetText(MultiLanguageEnum.CANCEL_BUTTON);
            BackButton.Text = MultilanguangeController.GetText(MultiLanguageEnum.VOLVER);
            RemainingTimeLabel.Text = MultilanguangeController.GetText(MultiLanguageEnum.TIEMPO_RESTANTE);
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

            RemainingTimeLabel.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.SegundaCabeceraGrilla);
            RemainingTimeLabel.ForeColor = StyleController.GetColor(Enumerations.ColorNameEnum.FuenteContraste);

            ConfirmAndExitDepositButton.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.BotonAceptar);
            ConfirmAndExitDepositButton.ForeColor = StyleController.GetColor(Enumerations.ColorNameEnum.FuenteContraste);
            ConfirmAndContinueDepositButton.BackgroundColor = StyleController.GetColor(Enumerations.ColorNameEnum.BotonAceptar);
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
                if (_device.StateResultProperty != null &&_device.StateResultProperty.DeviceStateInformation.EscrowBillPresent
                    || _currentCountingAmount > 0)
                {
                    ConfirmDeposit();
                    _operationStatus.DepositConfirmed = true;

                    DatabaseController.LogOff(true);
                    FormsController.LogOff();
                }
                else
                {
                    DatabaseController.LogOff(true);
                    FormsController.LogOff();
                }
            }
            else
            {
                EvaluateTimeout();
                if (_device != null && _device.CounterConnected)
                {
                    if (_device.StateResultProperty.ModeStateInformation.ModeState == ModeStateInformation.Mode.Neutral_SettingMode)
                    {
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
        private void EvaluateTimeout()
        {

            RemainingTimeLabel.Text = MultilanguangeController.GetText(MultiLanguageEnum.TIEMPO_RESTANTE) +
                TimeOutController.GetRemainingtime().ToString();
            if (TimeOutController.GetRemainingtime() > ParameterController.GreenStatusIndicator)
                RemainingTimeLabel.ForeColor = Color.Green;
            if (TimeOutController.GetRemainingtime() < ParameterController.YellowStatusIndicator)
                RemainingTimeLabel.ForeColor = Color.Yellow;
            if (TimeOutController.GetRemainingtime() < ParameterController.RedStatusIndicator)
                RemainingTimeLabel.ForeColor = Color.Red;
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

            VerifySaveToDatabase();

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
                    && !_device.StateResultProperty.DeviceStateInformation.StackerFull
                    && _device.StateResultProperty.StatusInformation.OperatingState
                        != StatusInformation.State.PQCounting
                    && !_device.StateResultProperty.DeviceStateInformation.HopperBillPresent
                    && _operationStatus.DepositCancelled == false;

                ConfirmAndExitDepositButton.Visible =
                    (_device.StateResultProperty.DeviceStateInformation.EscrowBillPresent
                    && _operationStatus.DepositConfirmed == false)
                    && _device.StateResultProperty.DoorStateInformation.Escrow == false
                    && _device.StateResultProperty.StatusInformation.OperatingState
                    == StatusInformation.State.BeingReset
                    && _device.StateResultProperty.DeviceStateInformation.EscrowBillPresent
                ;
                //&& _device.StateResultProperty.DoorStateInformation.Escrow
                //&& !_device.StateResultProperty.DeviceStateInformation.RejectedBillPresent
                //&& !_device.StateResultProperty.DeviceStateInformation.HopperBillPresent
                //&& _device.StateResultProperty.StatusInformation.OperatingState
                //    != StatusInformation.State.PQWaitingToRemoveBankNotes
                //&& _device.StateResultProperty.StatusInformation.OperatingState
                //    != StatusInformation.State.EscrowOpen)
                //    || _device.StateResultProperty.DeviceStateInformation.StackerFull
                //       && _device.StateResultProperty.StatusInformation.OperatingState
                //!= StatusInformation.State.PQStoring;



                ConfirmAndContinueDepositButton.Visible =
                        _device.StateResultProperty.DeviceStateInformation.StackerFull
                        && _device.StateResultProperty.StatusInformation.OperatingState != StatusInformation.State.PQStoring;

                CancelDepositButton.Visible =
                    (_device.StateResultProperty.DeviceStateInformation.EscrowBillPresent
                    && _operationStatus.DepositConfirmed == false)
                    && _device.StateResultProperty.DoorStateInformation.Escrow == false
                && _device.StateResultProperty.StatusInformation.OperatingState
                == StatusInformation.State.BeingReset;
                //&& _device.StateResultProperty.StatusInformation.OperatingState
                //!= StatusInformation.State.PQWaitingToRemoveBankNotes
                //&& _device.StateResultProperty.StatusInformation.OperatingState
                //!= StatusInformation.State.PQStoring;


                ButtonsPanel.Visible = true;
                    //_device.StateResultProperty.StatusInformation.OperatingState
                    //!= StatusInformation.State.PQCounting;
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
                    InformationLabel.Text = MultilanguangeController.GetText(MultiLanguageEnum.INGRESAR_BILLETES);
                    InformationLabel.ForeColor = Color.Green;
                }

                if (_device.StateResultProperty.StatusInformation.OperatingState == StatusInformation.State.PQCounting)
                {
                    InformationLabel.Text = MultilanguangeController.GetText(MultiLanguageEnum.CONTANDO);
                    InformationLabel.ForeColor = Color.Blue;
                    TimeOutController.Reset();
                }

                if (_device.StateResultProperty.StatusInformation.OperatingState == StatusInformation.State.PQStoring)
                {
                    InformationLabel.Text = MultilanguangeController.GetText(MultiLanguageEnum.AGUARDE_DEPOSITO);
                    InformationLabel.ForeColor = Color.Blue;
                    TimeOutController.Reset();
                }

                if (_device.StateResultProperty.DeviceStateInformation.RejectedBillPresent)
                {
                    InformationLabel.Text = MultilanguangeController.GetText(MultiLanguageEnum.RETIRAR_BILLETES_RECHAZADOS);
                    InformationLabel.ForeColor = Color.Red;
                }
                if (_device.StateResultProperty.DeviceStateInformation.EscrowBillPresent
                     && _operationStatus.CurrentTransactionQuantity == 0
                     && !_device.StateResultProperty.DeviceStateInformation.RejectedBillPresent)
                {
                    InformationLabel.Text = MultilanguangeController.GetText(MultiLanguageEnum.CONTINUAR_INGRESANDO_BILLETES);
                    InformationLabel.ForeColor = Color.Green;
                }
                if (_device.StateResultProperty.DeviceStateInformation.EscrowBillPresent
                        && _operationStatus.CurrentTransactionQuantity > 0)
                {
                    InformationLabel.Text = MultilanguangeController.GetText(MultiLanguageEnum.ACEPTAR_O_CANCELAR_DEPOSITO);
                    InformationLabel.ForeColor = Color.Green;
                }
                if (_device.StateResultProperty.DeviceStateInformation.EscrowBillPresent
                    && _operationStatus.CurrentTransactionQuantity == 0
                    && _device.StateResultProperty.StatusInformation.OperatingState == StatusInformation.State.PQWaitingToRemoveBankNotes)
                {
                    InformationLabel.Text = MultilanguangeController.GetText(MultiLanguageEnum.CANCELAR_DEPOSITO);
                    InformationLabel.ForeColor = Color.Red;
                }

                if (_device.StateResultProperty.DeviceStateInformation.StackerFull)
                {
                    _countingCycle+=1;
                    InformationLabel.Text = MultilanguangeController.GetText(MultiLanguageEnum.ESCROW_LLENO);
                    InformationLabel.ForeColor = Color.Red;
                }

                if (_device.StateResultProperty.EndInformation.StoreEnd)
                {
                    InformationLabel.Text = "fin de depósito";
                    InformationLabel.ForeColor = Color.Red;
                }
            }
            else
            {
                if (_device.IoBoardStatusProperty.GateState == IoBoardStatus.GATE_STATE.OPEN)
                {
                    InformationLabel.Text = MultilanguangeController.GetText(MultiLanguageEnum.PUERTA_ABIERTA);
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

                //_device.DepositMode();
                //_pollingTimer.Enabled = true;
                //_operationStatus.StackerFull = false;
                //_operationStatus.StackerFullTreated = false;
                FormsController.OpenChildForm(this, new OperationForm(), _device);
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
                ExitBillDepositForm();
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

        }
        /// <summary>
        /// Si existen denominaciones detectadas carga la grilla
        /// </summary>
        private void VerifyLoadDetectedBills()
        {
            _currentCountingAmount = 0;
            _currentCountingQuantity = 0;

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

                        _currentCountingAmount += Convert.ToInt32(denomination.Unidades) * denomination.CantidadDetectada;
                        _currentCountingQuantity += denomination.CantidadDetectada;
                    }
                }
            }
            else
            {
                _currentCountingAmount = 0;
            }
            
            SetTotals();

            CancelDepositButton.Visible = true;
        }

        private void SetTotals()
        {
            SubtotalLabel.Text = MultilanguangeController.GetText(MultiLanguageEnum.SUB_TOTAL) +
                DatabaseController.CurrentCurrency.Simbolo + " "
                + _operationStatus.CurrentTransactionAmount.ToString();

        }
        private void SetSubTotalsValues()
        {
            if (DenominationsGridView.Rows.Count > 0)
            {
                //Totales
                DenominationsGridView.Rows[DenominationsGridView.Rows.Count - 1].Cells["Quantity"].Value =
                    (_currentCountingQuantity + _operationStatus.CurrentTransactionQuantity).ToString();
                DenominationsGridView.Rows[DenominationsGridView.Rows.Count - 1].Cells["Amount"].Value =
                    DatabaseController.CurrentCurrency.Simbolo + " " +
                        (_currentCountingAmount + _operationStatus.CurrentTransactionAmount).ToString();
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
            TimeOutController.Stop();
            CancelDeposit();
            ButtonsPanel.Visible = true;
        }

        private void CancelDeposit()
        {
            _operationStatus.DepositConfirmed = false;
            _operationStatus.DepositCancelled = true;
            ConfirmAndExitDepositButton.Visible = false;
            _operationStatus.StackerFull = false;
            _device.OpenEscrow();
            _device.PreviousState = StatusInformation.State.PQWaitingToRemoveBankNotes;
        }

        private void ConfirmAndExitDepositButton_Click(object sender, EventArgs e)
        {
            TimeOutController.Reset();
            ButtonsPanel.Visible = false;
            ConfirmDeposit();
            _operationStatus.DepositConfirmed = true;
        }

        private void ConfirmDeposit()
        {
            _operationStatus.DepositConfirmed = true;
            CancelDepositButton.Visible = false;
            _device.StoringStart();
            _device.PreviousState = StatusInformation.State.PQStoring;
            SaveTransaction();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            if(_device != null){
                if (_device.CounterConnected)
                    _device.RemoteCancel();
            }
            FormsController.OpenChildForm(this,new OperationForm(), _device);

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

            EnableDisableControls(false);

            SaveTransaction();

            _device.RemoteCancel();
            _operationStatus.DepositEnded = false;
            CleanDetectedBills();
            FormsController.OpenChildForm(this,new OperationForm(), _device);
        }

        private void SaveAndContinueDeposit()
        {
            _device.PreviousState = StatusInformation.State.PQStoring; 
            ButtonsPanel.Visible = false;
            TimeOutController.Reset();
            _device.StoringStart();
            SaveTransaction();
            //ButtonsPanel.Visible = true;
        }

        private void EnableDisableControls(bool value)
        {
            DenominationsGridView.Visible = value;
            CancelDepositButton.Visible = value;
            ConfirmAndExitDepositButton.Visible = value;
            CurrencyLabel.Visible = value;
            SubtotalLabel.Visible = value;
            RemainingTimeLabel.Visible = value;

        }

        private void EnableDisableLabelsAndGrid(bool value)
        {
            DenominationsGridView.Visible = value;
            CurrencyLabel.Visible = value;
            SubtotalLabel.Visible = value;
            RemainingTimeLabel.Visible = value;

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
            _depositItems.Add(new() { 
                Denomination = "Total",
                Amount = "0",
                Image= StyleController.GetCellStyleBitmap(),
                Quantity=0
            });
            DenominationsGridView.DataSource = _depositItems;
            EnableDisableLabelsAndGrid(true);
            SetcolumnsAlignment();
            StyleController.SetControlFooterStyle(DenominationsGridView);
        }

        /// <summary>
        /// Graba el depósito en base de datos
        /// </summary>
        private void SaveTransaction()
        {
            _operationStatus.CurrentTransactionAmount += _currentCountingAmount;


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
                    MonedaId = DatabaseController.CurrentCurrency.Id,
                    SectorId = DatabaseController.CurrentDepositary.SectorId.Id,
                    SesionId = DatabaseController.CurrentSession.Id,
                    SucursalId = DatabaseController.CurrentDepositary.SectorId.SucursalId.Id,
                    TipoId = (long)OperationTypeEnum.BillDeposit,// Depósito de Billete
                    TotalAValidar = 0,
                    TotalValidado = _operationStatus.CurrentTransactionAmount,
                    TurnoId = DatabaseController.CurrentTurn.Id,
                    UsuarioCuentaId = DatabaseController.CurrentUserBankAccount == null ? 0 : 
                    DatabaseController.CurrentUserBankAccount.CuentaId.Id,
                    UsuarioId = DatabaseController.CurrentUser.Id,
                   

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
            if (e.RowIndex >= 0 && e.RowIndex < DenominationsGridView.Rows.Count-1 && e.ColumnIndex >= 0)
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