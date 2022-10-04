using Permaquim.Depositary.UI.Desktop.Components;
using Permaquim.Depositary.UI.Desktop.Controllers;
using Permaquim.Depositary.UI.Desktop.Forms;
using Permaquim.Depositary.UI.Desktop.Global;
using static Permaquim.Depositary.UI.Desktop.Global.Enumerations;

namespace Permaquim.Depositary.UI.Desktop
{
    public partial class EnvelopeDepositForm : Form
    {
        /// <summary>
        /// Instancia del dispositivo
        /// </summary>
        public CounterDevice _device { get; set; }

        private SelectedEditElementEnum _selectedEditElement;

        private List<EnvelopeDepositItem> _envelopeDepositItems = new();

        private long _totalQuantity = 0;
        private double _totalAmount = 0;
        private int _greenStatusIndicator;
        private int _yellowStatusIndicator;
        private int _redStatusIndicator;

        private const string DEPOSITO_SOBRE_CANCELADO = "Deposito de sobre Cancelado";

        private bool _alreadyPrinted = false;
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
                Y = (this.Height / 2 - MainPanel.Height / 2 ) + 50
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
        private void EnvelopeDepositForm_VisibleChanged(object sender, EventArgs e)
        {
            MonitorGroupcheckbox.Visible = true;// SecurityController.IsFunctionenabled(FunctionEnum.ViewEvents);

            _pollingTimer.Enabled = this.Visible;
            if (this.Visible)
            {
                LoadDenominations();
                LoadLanguageItems();
                DenominationsGridView.Enabled = true;
                DenominationsGridView.Visible = true;
                CurrencyLabel.Enabled = true;
                RemainingTimeLabel.Enabled = true;
                SubtotalLabel.Enabled = true;
            }
            else
            {
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
            }

            FormsController.SetInformationMessage(InformationTypeEnum.None, string.Empty);

        }
        private void InitializeLocals()
        {
            _envelopeDepositItems = new();
            _totalQuantity = 0;
            _totalAmount = 0;
            _operationStatus = new();
            _alreadyPrinted = false;
        
        }
        public void LoadDenominations()
        {

            _envelopeDepositItems = new();

            foreach (var item in DatabaseController.GetEnvelopeValues())
            {
                byte[] bytes = Convert.FromBase64String(item.TipoValorId.Imagen
               .Replace("data:image/png;base64,", String.Empty)
               .Replace("data:image/jpeg;base64,", String.Empty)
               .Replace("data:image/webp;base64,", String.Empty));

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
                _pollingTimer.Enabled = false;
                FormsController.SetInformationMessage(InformationTypeEnum.None, String.Empty);

                DatabaseController.LogOff(true);
                FormsController.LogOff();
            }
            else
            {
                EvaluateTimeout();

                // Asigna a la máquina el valor del estado de la contadora en este ciclo
                if (_device != null && _device.CounterConnected)
                {
                    _operationStatus.GeneralStatus = _device.CurrentStatus;

                    if (_device != null && _device.CounterConnected)
                    {
                        if (_device.StateResultProperty.ModeStateInformation.ModeState != ModeStateInformation.Mode.ManualMode
                            && _device.StateResultProperty.StatusInformation.OperatingState == StatusInformation.State.Waiting)
                        {
                            _device.ManualDepositMode();
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
                else
                {
                    VerifyButtonsVisibility();
                }


                SetTotals();
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
                    if (_operationStatus.DepositConfirmed == true 
                        && _device.StateResultProperty.StatusInformation.OperatingState == StatusInformation.State.Waiting)
                    {
                        _device.RemoteCancel();
                        _pollingTimer.Enabled = false;
                        FormsController.OpenChildForm(this,new OperationForm(), _device);
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
                && _device.StateResultProperty.DeviceStateInformation.EscrowBillPresent == true
                && _device.PreviousState == StatusInformation.State.PQWaitingEnvelope)
             {
                _operationStatus.DepositConfirmed = true;
                _device.CloseEscrow();
                PrintTicket(TicketTypeEnum.Second);
                _device.PreviousState = StatusInformation.State.PQClosingEscrow;

                ButtonsPanel.Visible = false;
            }


            // Si el escrow está cerrado y no tiene contenido, se debe volver a abrid
            //if (
            //    _operationStatus.GeneralStatus == StatusInformation.State.PQClosingEscrow
            //    && _device.StateResultProperty.DeviceStateInformation.EscrowBillPresent == false
            //    && _device.PreviousState == StatusInformation.State.PQWaitingEnvelope)
            //{
            //    _operationStatus.DepositConfirmed = false;
            //    _device.OpenEscrow();
            //    _device.PreviousState = StatusInformation.State.PQWaitingEnvelope;
            //    ButtonsPanel.Visible = true;
            //}

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
                        !_device.StateResultProperty.DeviceStateInformation.EscrowBillPresent
                        && _totalQuantity > 0 && !_device.StateResultProperty.DoorStateInformation.Escrow;
                }
                CancelDepositButton.Visible = true;

                EnvelopeTextBox.Visible = ParameterController.RequiresEnvelopeIdentifier
                    && ConfirmAndExitDepositButton.Visible;

                ButtonsPanel.Visible = _totalQuantity > 0;

                BackButton.Visible = !ButtonsPanel.Visible;
            }
            else
            {
                EnableDisableControls(false);
            }

        }
        private void ShowInformation()
        {

            if (!_device.StateResultProperty.DeviceStateInformation.EscrowBillPresent
             && _operationStatus.CurrentTransactionQuantity == 0)
            {
                FormsController.SetInformationMessage(InformationTypeEnum.Information,
                     MultilanguangeController.GetText(MultiLanguageEnum.INGRESAR_VALORES_SOBRE));
            }

            if (_device.StateResultProperty.DeviceStateInformation.EscrowBillPresent
                && _operationStatus.CurrentTransactionQuantity == 0
                && _device.StateResultProperty.StatusInformation.OperatingState == StatusInformation.State.PQWaitingToRemoveBankNotes)
            {
                FormsController.SetInformationMessage(InformationTypeEnum.Error,
                MultilanguangeController.GetText(MultiLanguageEnum.RETIRAR_SOBRE));
            }

            if(_operationStatus.DepositConfirmed)
            {
                FormsController.SetInformationMessage(InformationTypeEnum.Event,
                                MultilanguangeController.GetText(MultiLanguageEnum.AGUARDE_DEPOSITO));
            }

            if (_device.StateResultProperty.EndInformation.StoreEnd)
            {
                FormsController.SetInformationMessage(InformationTypeEnum.Information,
                    MultilanguangeController.GetText(MultiLanguageEnum.FIN_DEPOSITO));
            }

        }

        /// <summary>
        /// Se evalúa si se debe grabar en base de datos cuando finaliza la operación
        /// </summary>
        private void VerifyStoring()
        {
            if (
                _operationStatus.DepositConfirmed &&
                _device.StateResultProperty.DeviceStateInformation.EscrowBillPresent &&
                _device.PreviousState == StatusInformation.State.PQClosingEscrow
                )
            {
                if (ParameterController.UsesShutter)
                    _device.Open();

                _device.StoringStart();
                _device.PreviousState = StatusInformation.State.PQStoring;
                ExitEnvelopeDepositForm();

            }
        }
        private void ExitEnvelopeDepositForm()
        {

            EnableDisableControls(false);

            PrintTicket(TicketTypeEnum.Second);

            //SaveTransaction();
            _device.RemoteCancel();

            _operationStatus.DepositEnded = true;

        }
        /// <summary>
        /// Graba el depósito en base de datos
        /// </summary>
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

                Permaquim.Depositario.Entities.Tables.Operacion.Transaccion transaction = new()
                {
                    CierreDiarioId = DatabaseController.CurrentDailyClosing.Id,
                    ContenedorId = DatabaseController.CurrentContainer.Id,
                    DepositarioId = DatabaseController.CurrentDepositary.Id,
                    MonedaId = DatabaseController.CurrentCurrency.Id,
                    Fecha = DateTime.Now,
                    Finalizada = true,
                    SectorId = DatabaseController.CurrentDepositary.SectorId.Id,
                    SesionId = sesiones.Result.FirstOrDefault().Id,
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
                    OrigenValorId = DatabaseController.CurrentDepositOrigin == null ? 0 :
                        DatabaseController.CurrentDepositOrigin.Id
                };
                transactions.Add(transaction);
                _operationStatus.CurrentTransactionId = transaction.Id;

                Permaquim.Depositario.Business.Tables.Operacion.TransaccionSobre transactionEnvelopes = new(transactions);
                Permaquim.Depositario.Entities.Tables.Operacion.TransaccionSobre transactionEnvelope = new()
                {
                    CodigoSobre = EnvelopeTextBox.Texts.Trim(),
                    TransaccionId = _operationStatus.CurrentTransactionId,
                    Fecha = DateTime.Now
                };
                transactionEnvelopes.Add(transactionEnvelope);

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

                        transaction.TotalAValidar += item.Amount;
                        transactionenvelopeDetails.Add(transactionEnvelopeDetail);
                    }
                }
                transactions.Update(transaction);

                transactions.EndTransaction(true);

                PrintTicket(TicketTypeEnum.First);

            }
            catch (Exception ex)
            {
                AuditController.Log(ex);
                transactions.EndTransaction(false);
            }

        }
        
        private void DeleteTransaction()
        {
            Permaquim.Depositario.Business.Tables.Operacion.Transaccion transactions = new();

            transactions.Where.Add(Depositario.Business.Tables.Operacion.Transaccion.ColumnEnum.Id,
                Depositario.sqlEnum.OperandEnum.Equal, _operationStatus.CurrentTransactionId);
            transactions.Items();
            if (transactions.Result.Count > 0)
            {
                var previousTransacion = transactions.Result.FirstOrDefault();

                previousTransacion.Finalizada = false;

                transactions.Update(previousTransacion);

            }



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
            public long Id  { get; set; }
            public string Denomination { get; set; }
            public long Quantity { get; set; }
            public double Amount { get; set; }
            public Image? Image { get; set; }
        }

        private void ConfirmAndExitDepositButton_Click(object sender, EventArgs e)
        {

            TimeOutController.Reset();

            if (ParameterController.RequiresEnvelopeIdentifier && EnvelopeTextBox.Texts.Trim().Equals(String.Empty))
            {
                FormsController.SetInformationMessage(InformationTypeEnum.Error,
                MultilanguangeController.GetText(MultiLanguageEnum.REQUIERE_IDENTIFICADOR_SOBRE));
            }
            else
            {
                SaveTransaction();

                TimeOutController.Reset();
                _device.OpenEscrow();
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
                SendKeys.Send(((CustomButton)sender).Tag.ToString());
            }
        }
        #endregion

  
        private void EnvelopeTextBox_Enter(object sender, EventArgs e)
        {
            TimeOutController.Reset();
            _selectedEditElement = SelectedEditElementEnum.EnvelopeCode;
            InputBoxForm inputForm = new InputBoxForm();

            if(EnvelopeTextBox.Texts.Equals(EnvelopeTextBox.PlaceholderText))
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
            System.Diagnostics.Debug.Print(e.ToString());
        }
        private void EvaluateTimeout()
        {

            RemainingTimeLabel.Text = MultilanguangeController.GetText(MultiLanguageEnum.TIEMPO_RESTANTE) +
                TimeOutController.GetRemainingtime().ToString();
            if (TimeOutController.GetRemainingtime() > _greenStatusIndicator)
                RemainingTimeLabel.ForeColor = StyleController.GetColor(ColorNameEnum.TextoInformacion);
            if (TimeOutController.GetRemainingtime() < _yellowStatusIndicator)
                RemainingTimeLabel.ForeColor = StyleController.GetColor(ColorNameEnum.TextoAlerta);
            if (TimeOutController.GetRemainingtime() < _redStatusIndicator)
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
            TimeOutController.Reset();

            _operationStatus.DepositConfirmed = false;
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
                    .Replace("{ENTER}","");
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


            if (ParameterController.PrintsEnvelopeDeposit)
            {
                var _header = DatabaseController.GetTransactionHeader(_operationStatus.CurrentTransactionId);
                var _details = _header.ListOf_TransaccionSobre_TransaccionId;

                //if (!_alreadyPrinted)
                //{
                    for (int i = 0; i < ParameterController.PrintEnvelopeDepositQuantity; i++)
                    {

                        switch (ticketType)
                        {
                            case TicketTypeEnum.First:
                                ReportController.PrintReport(ReportTypeEnum.EnvelopeDepositFirstReport,
                                _header,_details, i);
                                _alreadyPrinted = true;
                                break;
                            case TicketTypeEnum.Second:
                                ReportController.PrintReport(ReportTypeEnum.EnvelopeDepositSecondReport,
                                _header, _details, i);
                                _alreadyPrinted = true;
                                break;
                            default:
                                break;
                        }

                    }
                //}
            }
        }
    }
}
