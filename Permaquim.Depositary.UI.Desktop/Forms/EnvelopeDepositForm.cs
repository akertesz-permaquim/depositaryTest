﻿using Permaquim.Depositary.UI.Desktop.Components;
using Permaquim.Depositary.UI.Desktop.Controllers;
using Permaquim.Depositary.UI.Desktop.Forms;
using Permaquim.Depositary.UI.Desktop.Global;
using System.Buffers;
using System.Diagnostics;
using System.Transactions;
using static Permaquim.Depositary.UI.Desktop.Global.Enumerations;

namespace Permaquim.Depositary.UI.Desktop
{
    public partial class EnvelopeDepositForm : Form
    {
        /// <summary>
        /// Instancia del dispositivo
        /// </summary>
        public CounterDevice _device { get; set; }

        private bool _maintainButtonUnvisible = false;

        private SelectedEditElementEnum _selectedEditElement;

        private List<EnvelopeDepositItem> _envelopeDepositItems = new();

        Permaquim.Depositario.Entities.Tables.Operacion.Transaccion _transaction = null;
        Permaquim.Depositario.Entities.Tables.Operacion.TransaccionSobre _transactionEnvelope = null;
        List<Permaquim.Depositario.Entities.Tables.Operacion.TransaccionSobreDetalle> _transactionenvelopeDetails = null;

        private long _totalQuantity = 0;
        private double _totalAmount = 0;
        private int _greenStatusIndicator;
        private int _yellowStatusIndicator;
        private int _redStatusIndicator;

        private bool _requiresEnvelopeIdentifier = ParameterController.RequiresEnvelopeIdentifier;
        private const string DEPOSITO_SOBRE_CANCELADO = "Deposito de sobre Cancelado";
        private const string DEPOSITO_SOBRE = "Deposito de sobre";
        private const string WAITING = "WAITING";
        private const string STORINGERROR = "STORINGERROR";

        List<Permaquim.Depositario.Entities.Tables.Operacion.Transaccion> _headerTransaction = new();
        List<Permaquim.Depositario.Entities.Tables.Operacion.TransaccionDetalle> _detailTransactions = new();

        private enum TicketTypeEnum
        {
            First,
            Second
        }

        /// <summary>
        /// Máquina de estado
        /// </summary>
        private Operationstatus _operationStatus = new();
        /// <summary>
        /// Timer para la consulta del estado del dispositivo
        /// </summary>
        private System.Windows.Forms.Timer _pollingTimer = new System.Windows.Forms.Timer();

        CustomNumericInputboxKeyboard _numericInputForm = null;
        InputBoxForm _inputForm = null;

        //////////////////////////////////////////////////////////////////////
        DataGridViewCell activatedCell;
        private void CellClicked(object sender, DataGridViewCellEventArgs e)
        {
            activatedCell = ((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex];
            _selectedEditElement = SelectedEditElementEnum.Cell;
        }

        //////////////////////////////////////////////////////////////////////
        public EnvelopeDepositForm()
        {
            InitializeComponent();
            LoadStyles();
            CenterPanel();
            TimeOutController.Reset();
            Loadparameters();
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
        private void CenterPanel()
        {

            MainPanel.Location = new Point()
            {
                X = this.Width / 2 - MainPanel.Width / 2,
                Y = (this.Height / 2 - MainPanel.Height / 2) + 50
            };

            ButtonsPanel.Location = new Point()
            {
                X = DenominationsGridView.Location.X,
                Y = ButtonsPanel.Location.Y
            };
            BackButton.Location = new Point()
            {
                X = MainPanel.Width / 2 - BackButton.Width / 2,
                Y = ButtonsPanel.Location.Y
            };

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

            EnvelopeTextBox.ForeColor = StyleController.GetColor(Enumerations.ColorNameEnum.FuentePrincipal);

            StyleController.SetControlStyle(DenominationsGridView);


            ConfirmAndExitDepositButton.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.BotonAceptar);
            ConfirmAndExitDepositButton.ForeColor = StyleController.GetColor(Enumerations.ColorNameEnum.FuenteContraste);
            CancelDepositButton.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.BotonCancelar);
            CancelDepositButton.ForeColor = StyleController.GetColor(Enumerations.ColorNameEnum.FuenteContraste);

            BackButton.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.BotonSalir);
            BackButton.ForeColor = StyleController.GetColor(Enumerations.ColorNameEnum.FuenteContraste);


        }
        private void LoadLanguageItems()
        {
            ConfirmAndExitDepositButton.Text = MultilanguangeController.GetText(MultiLanguageEnum.BOTON_ACEPTAR_OPERACION);
            CancelDepositButton.Text = MultilanguangeController.GetText(MultiLanguageEnum.BOTON_CANCELAR_OPERACION);
            RemainingTimeLabel.Text = MultilanguangeController.GetText(MultiLanguageEnum.TIEMPO_RESTANTE);

            DenominationsGridView.Columns["Denomination"].HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.DESCRIPCION);
            DenominationsGridView.Columns["Quantity"].HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.CANTIDAD);
            DenominationsGridView.Columns["Amount"].HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.IMPORTE);
            EnvelopeTextBox.PlaceholderText = MultilanguangeController.GetText(MultiLanguageEnum.ENVELOPE_TEXTBOX_PLACEHOLDER);
            BackButton.Text = MultilanguangeController.GetText(MultiLanguageEnum.VOLVER);

        }

        private void EnvelopeDepositForm_Load(object sender, EventArgs e)
        {
            _device = (Permaquim.Depositary.UI.Desktop.Components.CounterDevice)this.Tag;

            _pollingTimer = new System.Windows.Forms.Timer()
            {
                Interval = DeviceController.GetPollingInterval(),
                Enabled = true
            };
            _pollingTimer.Tick += PollTimer_Tick;

            _operationStatus = new();
            CurrencyLabel.Text = DatabaseController.CurrentCurrency.Nombre;

            // Le agrega el número de cuenta bancaria al texto del breadcrumb 
            if (DatabaseController.CurrentUserBankAccount != null)
            {
                FormsController.AppendtoBreadcrumbText(" - " +
                    MultilanguangeController.GetText(MultiLanguageEnum.USUARIOCUENTA) +
                    ":" + DatabaseController.CurrentUserBankAccount.CuentaId.Numero
                    );
            }
        }

        private void DeviceStateChange(object sender, DeviceStateChangeEventArgs args)
        {
            if (args.StateName.Equals(Global.Constants.PQCOMMUNICATIONERROR))
                AuditController.Log(LogTypeEnum.Navigation, args.StateName, args.StateName);

            if (args.StateName.ToUpper().Equals(STORINGERROR))
            {
                FormsController.SetInformationMessage(InformationTypeEnum.Event,
                    MultilanguangeController.GetText(MultiLanguageEnum.DEPOSITO_FINALIZADO_CON_ERROR));
                    _device.PreviousState = StatusInformation.State.StoringError;
                return;
            }

            if (args.StateName.ToUpper().Equals(WAITING))
            {
                if (_device.PreviousState == StatusInformation.State.PQStoring
                    || _device.PreviousState == StatusInformation.State.StoringError)
                {
                    if(_device.PreviousState != StatusInformation.State.StoringError)
                        _device.PreviousState = StatusInformation.State.Waiting;
                    FormsController.SetInformationMessage(InformationTypeEnum.Event,
                        MultilanguangeController.GetText(MultiLanguageEnum.FIN_DEPOSITO));
                    ExitForm();
                }
            }
        }
        private void EnvelopeDepositForm_VisibleChanged(object sender, EventArgs e)
        {
            MonitorGroupcheckbox.Visible = ConfigurationController.IsDevelopment();

            _pollingTimer.Enabled = this.Visible;
            if (this.Visible)
            {
                if (ParameterController.UsesShutter)
                    _device.OpenShutter();

                _device.DeviceStateChange += DeviceStateChange;

                if (_device.StateResultProperty.ModeStateInformation.ModeState != ModeStateInformation.Mode.ManualMode)
                {
                    _device.ManualDepositMode();

                }
                if (_device.StateResultProperty.DoorStateInformation.Escrow)
                    _device.CloseEscrow();


                    AuditController.Log(LogTypeEnum.Navigation, DEPOSITO_SOBRE, DEPOSITO_SOBRE);
                LoadDenominations();
                LoadLanguageItems();
                DenominationsGridView.Enabled = true;
                DenominationsGridView.Visible = true;
                CurrencyLabel.Enabled = true;
                RemainingTimeLabel.Enabled = true;
                SubtotalLabel.Enabled = true;
                EnvelopeTextBox.Enabled = true;
            }
            else
            {
                _device.DeviceStateChange -= DeviceStateChange;

                if (_numericInputForm != null)
                {
                    _numericInputForm.Close();
                    _numericInputForm = null;
                }
                if (_inputForm != null)
                {
                    _inputForm.Close();
                    _inputForm = null;
                }

                InitializeLocals();
                if (ParameterController.UsesShutter)
                    _device.CloseShutter();
            }

            FormsController.SetInformationMessage(InformationTypeEnum.None, string.Empty);

        }
        private void InitializeLocals()
        {
            EnvelopeTextBox.Visible = false;
            ButtonsPanel.Visible = false;
            _envelopeDepositItems = new();
            _totalQuantity = 0;
            _totalAmount = 0;
            _operationStatus = new();
            _maintainButtonUnvisible = false;
            ConfirmAndExitDepositButton.Enabled = true;

        }
        public void LoadDenominations()
        {

            _envelopeDepositItems = new();

            foreach (var item in DatabaseController.GetEnvelopeValues())
            {
                byte[] bytes = null;
                if (item.TipoValorId.Imagen.Length > 0)
                {
                    bytes = Convert.FromBase64String(item.TipoValorId.Imagen
                   .Replace("data:image/png;base64,", String.Empty)
                   .Replace("data:image/jpeg;base64,", String.Empty)
                   .Replace("data:image/webp;base64,", String.Empty));
                }
                else
                {
                    ImageConverter converter = new ImageConverter();
                    bytes = (byte[])converter.ConvertTo(StyleController.CreateWhiteBitmap(), typeof(byte[]));
                }
                _envelopeDepositItems.Add(new EnvelopeDepositItem()
                {
                    Image = System.Drawing.Image.FromStream(new MemoryStream(bytes)),
                    Denomination = item.MonedaId.Nombre + " - " + item.TipoValorId.Nombre,
                    Quantity = 0,
                    Amount = 0,
                    Id = item.Id,
                });
            }

            // Row Totales
            _envelopeDepositItems.Add(new EnvelopeDepositItem()
            {
                Image = StyleController.GetCellStyleBitmap(),
                Denomination = "Total",
                Quantity = 0,
                Amount = 0,
                Id = -1,
            });

            DenominationsGridView.DataSource = _envelopeDepositItems;
            SetTotalRowStyle();
            SetTotals();
        }
        private void Loadparameters()
        {
            _greenStatusIndicator = ParameterController.GreenStatusIndicator;
            _yellowStatusIndicator = ParameterController.YellowStatusIndicator;
            _redStatusIndicator = ParameterController.RedStatusIndicator;
        }
        private void PollTimer_Tick(object? sender, EventArgs e)
        {
            if (TimeOutController.IsTimeOut())
            {
                _operationStatus.IsAutoDeposit = true;

                _pollingTimer.Enabled = false;
                _device.CloseEscrow();
                FormsController.SetInformationMessage(InformationTypeEnum.None, String.Empty);

                DatabaseController.LogOff(true);
                FormsController.LogOff();
            }
            else
            {
                EvaluateTimeout();

                if (_device.CurrentStatus == StatusInformation.State.PQStoring)
                {
                    FormsController.SetInformationMessage(InformationTypeEnum.Event,
                                    MultilanguangeController.GetText(MultiLanguageEnum.AGUARDE_DEPOSITO));
                    TimeOutController.Reset();
                    return;
                }

                if (_device.PreviousState == StatusInformation.State.StoringError && 
                    _device.CurrentStatus== StatusInformation.State.Waiting) { 
                    _pollingTimer.Enabled=false;
                    ExitForm();
                }

                // Asigna a la máquina el valor del estado de la contadora en este ciclo

                if (_device != null && _device.CounterConnected)
                {
                    _operationStatus.GeneralStatus = _device.CurrentStatus;

                    if (_device.StateResultProperty.ModeStateInformation.ModeState != ModeStateInformation.Mode.ManualMode
                        && _device.StateResultProperty.StatusInformation.OperatingState == StatusInformation.State.Waiting)
                    {
                        if(_device.StateResultProperty.ModeStateInformation.ModeState != ModeStateInformation.Mode.ManualMode)
                        {
                            _device.ManualDepositMode();

                        }
                    }
                    else
                    {
                        // Muestra el estado del hardware
                        ShowHardwareMonitorData();
                        // Procesa los estados 
                        ProcessDeviceStatus();

                        VerifyButtonsVisibility();

                        SetTotals();
                    }
                }
            }
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
        private void SetTotalRowStyle()
        {
            StyleController.SetControlFooterStyle(DenominationsGridView);

            for (int i = 2; i < DenominationsGridView.Columns.Count; i++)
            {
                DenominationsGridView.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                DenominationsGridView.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            DenominationsGridView.Rows[DenominationsGridView.Rows.Count - 1].Selected = true;

            SetTotals();

        }

        private void DenominationsGridView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void SetTotals()
        {
            if (DenominationsGridView.Rows.Count > 0)
            {
                _totalQuantity = 0;
                _totalAmount = 0;
                foreach (var item in DenominationsGridView.Rows)
                {
                    if (((long)((DataGridViewRow)item).Cells["Id"].Value) > -1)
                    {
                        _totalQuantity += (long)((DataGridViewRow)item).Cells["Quantity"].Value;
                        _totalAmount += (double)((DataGridViewRow)item).Cells["Amount"].Value;
                    }
                }

                DenominationsGridView.Rows[DenominationsGridView.Rows.Count - 1].Cells["Quantity"].Value = _totalQuantity;
                DenominationsGridView.Rows[DenominationsGridView.Rows.Count - 1].Cells["Amount"].Value = _totalAmount;
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
            if (_device.CurrentStatus != StatusInformation.State.PQClosingEscrow)
            {
                VerifyStoring();

                VerifyEscrowEmpty();

                VerifyButtonsVisibility();

                ShowInformation();

                VerifyExitForm();
            }

        }
        private void VerifyExitForm()
        {

            switch (_device.StateResultProperty.ModeStateInformation.ModeState)
            {
                case ModeStateInformation.Mode.Neutral_SettingMode:

                    _device.RemoteCancel();
                    break;
                case ModeStateInformation.Mode.InitialMode:
                    break;
                case ModeStateInformation.Mode.DepositMode:
                    break;
                case ModeStateInformation.Mode.ManualMode:
                    if (_operationStatus.DepositEnded == true
                        && _device.StateResultProperty.StatusInformation.OperatingState == StatusInformation.State.Waiting)
                    {
                        _device.RemoteCancel();
                        _pollingTimer.Enabled = false;
                        FormsController.OpenChildForm(this, new OperationForm(), _device);
                    }
                    break;
                case ModeStateInformation.Mode.NormalErrorRecoveryMode:
                    break;
                case ModeStateInformation.Mode.StoringErrorRecoveryMode:
                    break;
                case ModeStateInformation.Mode.CorrectMode:
                    break;
                case ModeStateInformation.Mode.Unknow:
                    break;
                default:
                    break;
            }

        }
        private void VerifyEscrowEmpty()
        {


            // Si el escrow está abierto, y el sensor detecta presencia, se asume que es un sobre y se 
            // completa el depósito
            if (
                _operationStatus.GeneralStatus == StatusInformation.State.PQWaitingTocloseEscrow
                && _device.StateResultProperty.DeviceStateInformation.EscrowBillPresent == true)
            {
                ButtonsPanel.Visible = false;
                CancelDepositButton.Visible = false;

                _operationStatus.DepositConfirmed = true;
                
                _device.CloseEscrow();
                _device.PreviousState = StatusInformation.State.PQClosingEscrow;

            }

        }
        /// <summary>
        /// Habilita la visualización de los botones de acuerdo a los estados del hardware
        /// </summary>
        private void VerifyButtonsVisibility()
        {
            if (!_operationStatus.DepositConfirmed)
            {
                if (_device != null)
                {
                    //Solo se habilita el botón de volver si no hay dinero en el escrow
                    ConfirmAndExitDepositButton.Visible =
                        _totalQuantity > 0 && !_maintainButtonUnvisible;
                CancelDepositButton.Visible = true;
                }

                ButtonsPanel.Visible = _totalQuantity > 0;

                BackButton.Visible = !ButtonsPanel.Visible;

                EnvelopeTextBox.Visible = _requiresEnvelopeIdentifier
                    && ConfirmAndExitDepositButton.Visible && _totalQuantity > 0;


            }
            else
            {

                EnvelopeTextBox.Visible = false;
                ConfirmAndExitDepositButton.Visible = false;
                if (!_maintainButtonUnvisible)
                    CancelDepositButton.Visible = true;
            }
            if (_device != null)
            {
                // en el D70, se cierra solo el escrow al no detectar sobre.
                if (_device.StateResultProperty.DoorStateInformation.Escrow == true
                    && _operationStatus.DepositConfirmed)
                {
                    ButtonsPanel.Visible = true;
                }
            }


        }
        private void ShowInformation()
        {
            if(_device.CurrentStatus == StatusInformation.State.StoringError)
            {
                return;
            }


            if (_requiresEnvelopeIdentifier && _totalQuantity > 0 
                && EnvelopeTextBox.Texts.Trim().Equals(String.Empty))
            {
                FormsController.SetInformationMessage(InformationTypeEnum.Error,
                MultilanguangeController.GetText(MultiLanguageEnum.REQUIERE_IDENTIFICADOR_SOBRE));
                return;
            }
            if (_device.CurrentStatus != StatusInformation.State.PQWaitingEnvelope 
                && _totalQuantity > 0 && (_requiresEnvelopeIdentifier
                && !EnvelopeTextBox.Texts.Trim().Equals(String.Empty)))
            {
                FormsController.SetInformationMessage(InformationTypeEnum.Information,
                         MultilanguangeController.GetText(MultiLanguageEnum.ACEPTAR_O_CANCELAR_DEPOSITO));
                return;
            }

            if (_device.CurrentStatus == StatusInformation.State.PQWaitingEnvelope)
            {
                FormsController.SetInformationMessage(InformationTypeEnum.Information,
                          MultilanguangeController.GetText(MultiLanguageEnum.INGRESE_SOBRE));
                return;
            }



            if (!_device.StateResultProperty.DeviceStateInformation.EscrowBillPresent
             && _operationStatus.CurrentTransactionQuantity == 0)
            {
                FormsController.SetInformationMessage(InformationTypeEnum.Information,
                     MultilanguangeController.GetText(MultiLanguageEnum.INGRESAR_VALORES_SOBRE));
                return;
            }

            if (_device.StateResultProperty.DeviceStateInformation.EscrowBillPresent
                && _operationStatus.CurrentTransactionQuantity == 0
                && _device.StateResultProperty.StatusInformation.OperatingState == StatusInformation.State.PQWaitingToRemoveBankNotes)
            {
                FormsController.SetInformationMessage(InformationTypeEnum.Error,
                MultilanguangeController.GetText(MultiLanguageEnum.RETIRAR_SOBRE));
                return;
            }

            if (_device.StateResultProperty.EndInformation.StoreEnd)
            {
                FormsController.SetInformationMessage(InformationTypeEnum.Information,
                    MultilanguangeController.GetText(MultiLanguageEnum.FIN_DEPOSITO));
                return;
            }

        }

        /// <summary>
        /// Se evalúa si se debe grabar en base de datos cuando finaliza la operación
        /// </summary>
        private void VerifyStoring()
        {
            if (_device.StateResultProperty.DoorStateInformation.Escrow == false && _operationStatus.DepositConfirmed)
            {
                if (
                    _operationStatus.DepositConfirmed &&
                    _device.StateResultProperty.DeviceStateInformation.EscrowBillPresent &&
                    _device.PreviousState == StatusInformation.State.PQClosingEscrow
                    && !_operationStatus.DepositEnded
                    )
                {
                    ButtonsPanel.Visible = false;
                    CancelDepositButton.Visible = false;

                    _device.StoringStart();
                    _device.PreviousState = StatusInformation.State.PQStoring;
                    //ExitEnvelopeDepositForm();
                }
                if (
                _operationStatus.DepositConfirmed &&
                !_device.StateResultProperty.DeviceStateInformation.EscrowBillPresent &&
                _device.PreviousState == StatusInformation.State.PQClosingEscrow
                )
                {
                    if (!_operationStatus.DepositEnded)
                    {
                        ButtonsPanel.Visible = true;
                        CancelDepositButton.Visible = true;
                        TimeOutController.Reset();
                        _device.OpenEscrow();
                        _device.PreviousState = StatusInformation.State.PQWaitingEnvelope;
                    }
                }

            }
        }
        private void ExitForm()
        {

            EnableDisableControls(false);
            if (_device.PreviousState == StatusInformation.State.StoringError)
            {
                string message = MultilanguangeController.GetText(MultiLanguageEnum.DEPOSITO_FINALIZADO_CON_ERROR);
                AuditController.Log(LogTypeEnum.Information,
                    message, message);
            }
            else
            {
                SaveTransaction();
                PrintTicket(TicketTypeEnum.Second);
            }


            _device.RemoteCancel();
            _device.PreviousState = StatusInformation.State.Waiting;

            _operationStatus.DepositEnded = true;

            FormsController.OpenChildForm(this, new OperationForm(), _device);

        }
        /// <summary>
        /// Crea el registro de depósito en memoria
        /// </summary>
        private long CreateTransaction()
        {

            DenominationsGridView.Enabled = false;
            CurrencyLabel.Enabled = false;
            RemainingTimeLabel.Enabled = false;
            SubtotalLabel.Enabled = false;

            FormsController.SetInformationMessage(InformationTypeEnum.Information,
            MultilanguangeController.GetText(MultiLanguageEnum.AGUARDE_DEPOSITO));

            try
            {

                _transaction = new()
                {
                    CierreDiarioId = null,
                    ContenedorId = DatabaseController.CurrentContainer.Id,
                    DepositarioId = DatabaseController.CurrentDepositary.Id,
                    MonedaId = DatabaseController.CurrentCurrency.Id,
                    Fecha = DateTime.Now,
                    Finalizada = true,
                    SectorId = DatabaseController.CurrentDepositary.SectorId.Id,
                    SesionId = DatabaseController.CurrentSession.Id,
                    SucursalId = DatabaseController.CurrentDepositary.SectorId.SucursalId.Id,
                    TipoId = (long)OperationTypeEnum.EnvelopeDeposit,             // Depósito de Sobre
                    TotalAValidar = _totalQuantity,
                    TotalValidado = 0,
                    TurnoId = DatabaseController.CurrentTurn.Id,
                    CuentaId = DatabaseController.CurrentUserBankAccount == null ? null :
                                DatabaseController.CurrentUserBankAccount.CuentaId.Id,
                    UsuarioId = DatabaseController.CurrentUser.Id,
                    CodigoOperacion =
                                DatabaseController.CurrentDepositary.CodigoExterno + "-" + DateTime.Now.ToString("yyMMdd"),
                    OrigenValorId = DatabaseController.CurrentDepositOrigin == null ? null :
                                DatabaseController.CurrentDepositOrigin.Id,
                    UsuarioCreacion = DatabaseController.CurrentUser.Id,
                    UsuarioModificacion = null,
                    FechaModificacion = null
                };

                _transactionEnvelope = new()
                {
                    CodigoSobre = EnvelopeTextBox.Texts.Trim(),
                    TransaccionId = _operationStatus.CurrentTransactionId,
                    Fecha = DateTime.Now
                };

                _transactionenvelopeDetails = new();

                foreach (var item in _envelopeDepositItems)
                {
                    if (item.Id > -1 && item.Quantity > 0)
                    {

                        _transactionenvelopeDetails.Add(new Depositario.Entities.Tables.Operacion.TransaccionSobreDetalle()
                        {
                            CantidadDeclarada = item.Quantity,
                            RelacionMonedaTipoValorId = item.Id,
                            ValorDeclarado = item.Amount,
                            Fecha = DateTime.Now,
                            SobreId = 0
                        });

                    }
                }


                PrintTicket(TicketTypeEnum.First);

                return _transaction.Id;

            }
            catch (Exception ex)
            {
                AuditController.Log(ex);
                return -1;
            }

        }

        private void SaveTransaction()
        {
            DenominationsGridView.Enabled = false;
            CurrencyLabel.Enabled = false;
            RemainingTimeLabel.Enabled = false;
            SubtotalLabel.Enabled = false;

            FormsController.SetInformationMessage(InformationTypeEnum.Information,
            MultilanguangeController.GetText(MultiLanguageEnum.AGUARDE_DEPOSITO));


            Permaquim.Depositario.Business.Tables.Operacion.Sesion sesiones = new();
            sesiones.Items(null, DatabaseController.CurrentDepositary.Id,
                DatabaseController.CurrentUser.Id, null, null, null);


            Permaquim.Depositario.Business.Tables.Operacion.Transaccion transactions = new();

            try
            {
                transactions.BeginTransaction();
                //Depósito
                _transaction.FechaCreacion = DateTime.Now;
                var currentTransaction = transactions.Add(_transaction);
                _operationStatus.CurrentTransactionId = currentTransaction.Id;
                // Depósito sobre
                Permaquim.Depositario.Business.Tables.Operacion.TransaccionSobre transactionEnvelopes = new(transactions);
                Permaquim.Depositario.Entities.Tables.Operacion.TransaccionSobre transactionEnvelope = new()
                {
                    CodigoSobre = EnvelopeTextBox.Texts.Trim(),
                    TransaccionId = currentTransaction.Id,
                    Fecha = DateTime.Now
                };
                transactionEnvelopes.Add(transactionEnvelope);

                // Depósito sobre detalle

                Permaquim.Depositario.Business.Tables.Operacion.TransaccionSobreDetalle transactionenvelopeDetails = new(transactions);
                foreach (var item in _envelopeDepositItems)
                {
                    if (item.Id > -1 && item.Quantity > 0)
                    {
                        Permaquim.Depositario.Entities.Tables.Operacion.TransaccionSobreDetalle transactionEnvelopeDetail = new()
                        {
                            CantidadDeclarada = item.Quantity,
                            RelacionMonedaTipoValorId = item.Id,
                            ValorDeclarado = item.Amount,
                            Fecha = DateTime.Now,
                            SobreId = transactionEnvelope.Id
                        };

                        currentTransaction.TotalAValidar += item.Amount;
                        transactionenvelopeDetails.Add(transactionEnvelopeDetail);
                    }
                }
                transactions.Update(currentTransaction);

                transactions.EndTransaction(true);

             }
            catch (Exception ex)
            {
                AuditController.Log(ex);

            }
        }
        /// <summary>
        /// inicializa las estructuras de transacción de sobre
        /// </summary>
        private void DeleteTransaction()
        {
            _transaction = null;
            _transactionEnvelope = null;
            _transactionenvelopeDetails = null;

        }


        private void EnableDisableControls(bool value)
        {
            DenominationsGridView.Visible = value;
            CancelDepositButton.Visible = value;
            ConfirmAndExitDepositButton.Visible = value;
            EnvelopeTextBox.Visible = value;
            CurrencyLabel.Visible = value;
            RemainingTimeLabel.Visible = value;
            SubtotalLabel.Visible = value;
            ButtonsPanel.Visible = value;

        }
        private class EnvelopeDepositItem
        {
            public long Id { get; set; }
            public string Denomination { get; set; }
            public long Quantity { get; set; }
            public double Amount { get; set; }
            public Image? Image { get; set; }
        }

        private void ConfirmAndExitDepositButton_Click(object sender, EventArgs e)
        {

            TimeOutController.Reset();

            if (_requiresEnvelopeIdentifier && EnvelopeTextBox.Texts.Trim().Equals(String.Empty))
            {
                FormsController.SetInformationMessage(InformationTypeEnum.Error,
                MultilanguangeController.GetText(MultiLanguageEnum.REQUIERE_IDENTIFICADOR_SOBRE));
                return;
            }
            else
            {
                ConfirmAndExitDepositButton.Enabled = false;
                ConfirmAndExitDepositButton.Visible = false;
                EnvelopeTextBox.Visible = false;

                _maintainButtonUnvisible = true;
            }
            if (!DeviceController.HasAnyIssue)
            {
                TimeOutController.Reset();
                _device.OpenEscrow();
                _operationStatus.CurrentTransactionId = CreateTransaction();
                _device.PreviousState = StatusInformation.State.PQWaitingEnvelope;
            }
        }

        #region Number Keyboard buttons
        private void Keys(object sender, EventArgs e)
        {
            TimeOutController.Reset();

            if (_selectedEditElement == SelectedEditElementEnum.Cell)
            {
                if (activatedCell == null) { return; }

                if (activatedCell.Value != null)
                {
                    if (((Button)sender).Tag.ToString().Equals("{BACKSPACE}"))
                    {
                        if (activatedCell.Value.ToString().Length > 1)
                        {
                            activatedCell.Value = Convert.ToDouble(activatedCell.Value.ToString()
                                .Substring(0, activatedCell.Value.ToString().Length - 1));
                        }
                        else
                        {
                            activatedCell.Value = null;
                        }
                    }
                    else
                    {
                        activatedCell.Value =
                            Convert.ToDouble((activatedCell.Value) +
                            ((Button)sender).Tag.ToString());
                    }

                }
                else
                {
                    activatedCell.Value = Convert.ToDouble(((Button)sender).Tag);

                    DenominationsGridView.Refresh();
                    DenominationsGridView.Invalidate();
                    DenominationsGridView.ClearSelection();
                }
                SetTotals();
            }
            if (_selectedEditElement == SelectedEditElementEnum.EnvelopeCode)
            {
                EnvelopeTextBox.Focus();
                SendKeys.Send(((Button)sender).Tag.ToString());
            }
        }
        #endregion


        private void EnvelopeTextBox_Enter(object sender, EventArgs e)
        {
            TimeOutController.Reset();
            _selectedEditElement = SelectedEditElementEnum.EnvelopeCode;
            InputBoxForm inputForm = new InputBoxForm();

            if (EnvelopeTextBox.Texts.Equals(EnvelopeTextBox.PlaceholderText))
                inputForm.InputTexboxPlaceholder = EnvelopeTextBox.PlaceholderText;
            ButtonsPanel.Visible = false;
            inputForm.ReturnTextValue = EnvelopeTextBox.Texts;
            if (inputForm.ShowDialog() == DialogResult.OK)
            {
                EnvelopeTextBox.Texts = inputForm.ReturnTextValue;
            }
            ButtonsPanel.Visible = true;
        }

        private void DenominationsGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            System.Diagnostics.Debug.Print(e.Exception.Message);
        }

        private void DenominationsGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                try
                {
                    activatedCell = ((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex];
                    _selectedEditElement = SelectedEditElementEnum.Cell;
                    DenominationsGridView.BeginEdit(false);

                    _numericInputForm = new CustomNumericInputboxKeyboard();

                    _numericInputForm.NumericInputBoxPlaceholder =
                        ((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                    if (_numericInputForm.ShowDialog(this) == DialogResult.OK)
                    {
                        ((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex].Value = _numericInputForm.ReturnValue;
                    }
                }
                catch (Exception ex)
                {
                    AuditController.Log(ex);
                }
            }
        }

        private void DenominationsGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            System.Diagnostics.Debug.Print(e.ToString()); // Evita error al momento de editar.
        }
        private void EvaluateTimeout()
        {

            RemainingTimeLabel.Text = MultilanguangeController.GetText(MultiLanguageEnum.TIEMPO_RESTANTE) +
                TimeOutController.GetRemainingTime().ToString();
            if (TimeOutController.GetRemainingTime() > _greenStatusIndicator)
                RemainingTimeLabel.ForeColor = StyleController.GetColor(ColorNameEnum.TextoInformacion);
            if (TimeOutController.GetRemainingTime() < _yellowStatusIndicator)
                RemainingTimeLabel.ForeColor = StyleController.GetColor(ColorNameEnum.TextoAlerta);
            if (TimeOutController.GetRemainingTime() < _redStatusIndicator)
                RemainingTimeLabel.ForeColor = StyleController.GetColor(ColorNameEnum.TextoError);
        }

        private void RemainingTimeLabel_Click(object sender, EventArgs e)
        {
            TimeOutController.Reset();
        }

        private void MonitorGroupcheckbox_CheckStateChanged(object sender, EventArgs e)
        {
            MonitorGroupBox.Visible = MonitorGroupcheckbox.Checked;
        }

        private void EnvelopeDepositForm_MouseClick(object sender, MouseEventArgs e)
        {
            TimeOutController.Reset();
        }

        private void CancelDepositButton_Click(object sender, EventArgs e)
        {
            Canceloperation();

        }

        private void Canceloperation()
        {
            TimeOutController.Reset();

            DeleteTransaction();

            _operationStatus.DepositConfirmed = false;
            if(_device!= null)
                _device.CloseEscrow();
            AuditController.Log(LogTypeEnum.Information,
                DEPOSITO_SOBRE_CANCELADO,
                DEPOSITO_SOBRE_CANCELADO);
            ButtonsPanel.Visible = true;

            if (_device.CounterConnected)
                _device.RemoteCancel();

            FormsController.OpenChildForm(this, new OperationForm(), _device);
        }

        private void EnvelopeTextBox_Click(object sender, EventArgs e)
        {
            TimeOutController.Reset();
            _selectedEditElement = SelectedEditElementEnum.EnvelopeCode;
            _inputForm = new InputBoxForm();
            
            if (EnvelopeTextBox.Texts.Equals(EnvelopeTextBox.PlaceholderText))
                _inputForm.InputTexboxPlaceholder = EnvelopeTextBox.PlaceholderText;
            else
                _inputForm.InputTexboxPlaceholder = MultilanguangeController.GetText(MultiLanguageEnum.ENVELOPE_TEXTBOX_PLACEHOLDER);

            _inputForm.ReturnTextValue = EnvelopeTextBox.Texts;
            if (_inputForm.ShowDialog(this) == DialogResult.OK)
            {
                EnvelopeTextBox.Texts = _inputForm.ReturnTextValue
                    .Replace("{ENTER}", "");
            }
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
        private void PrintTicket(TicketTypeEnum ticketType)
        {
            if (ConfigurationController.IsDevelopment())
                return;

                if (ParameterController.PrintsEnvelopeDeposit)
            {
                for (int i = 0; i < ParameterController.PrintEnvelopeDepositQuantity; i++)
                {
                    switch (ticketType)
                    {
                        case TicketTypeEnum.First:
                            ReportController.PrintReport(ReportTypeEnum.EnvelopeDepositFirstReport,
                            _transaction, _transactionenvelopeDetails, i, _transactionEnvelope.CodigoSobre);
                            break;
                        case TicketTypeEnum.Second:
                            var _header = DatabaseController.GetTransactionHeader(_transaction.Id);
                            var _details = _header.ListOf_TransaccionSobre_TransaccionId; ReportController.PrintReport(ReportTypeEnum.EnvelopeDepositSecondReport,
                                _header, _details, i);
                            break;
                        default:
                            break;
                    }

                }
            }
        }

        private void EnvelopeDepositForm_EnabledChanged(object sender, EventArgs e)
        {
            if (this.Enabled)
            {
                TimeOutController.Reset();
            }
            else
            {
                if (_totalQuantity > 0)
                {
                    SaveTransaction();
                    PrintTicket(TicketTypeEnum.Second);
                }
            }
        }
    }
}
