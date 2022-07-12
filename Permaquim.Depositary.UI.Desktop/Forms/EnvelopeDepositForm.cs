﻿using Permaquim.Depositary.UI.Desktop.Components;
using Permaquim.Depositary.UI.Desktop.Controllers;
using Permaquim.Depositary.UI.Desktop.Global;
using static Permaquim.Depositary.UI.Desktop.Global.Enumerations;

namespace Permaquim.Depositary.UI.Desktop
{
    public partial class EnvelopeDepositForm : Form
    {
        /// <summary>
        /// Instancia del dispositivo
        /// </summary>
        public Device _device { get; set; }

        private SelectedEditElementEnum _selectedEditElement;

        private List<EnvelopeDepositItem> _envelopeDepositItems = new();

        private long _totalQuantity = 0;
        private double _totalAmount = 0;

        /// <summary>
        /// Máquina de estado
        /// </summary>
        private Operationstatus _operationStatus = new();
        /// <summary>
        /// Timer para la consulta del estado del dispositivo
        /// </summary>
        private System.Windows.Forms.Timer _pollingTimer = new System.Windows.Forms.Timer();

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
        }
        private void CenterPanel()
        {

            MainPanel.Location = new Point()
            {
                X = this.Width / 2 - MainPanel.Width / 2,
                Y = this.Height / 2 - MainPanel.Height / 2
            };

            ButtonsPanel.Location = new Point()
            {
                X = DenominationsGridView.Location.X,
                Y = ButtonsPanel.Location.Y
            };

        }
        private void LoadStyles()
        {
            this.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.FondoFormulario);

            Button_0.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.FuentePrincipal);
            Button_1.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.FuentePrincipal);
            Button_2.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.FuentePrincipal);
            Button_3.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.FuentePrincipal);
            Button_4.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.FuentePrincipal);
            Button_5.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.FuentePrincipal);
            Button_6.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.FuentePrincipal);
            Button_7.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.FuentePrincipal);
            Button_8.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.FuentePrincipal);
            Button_9.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.FuentePrincipal);
            Button_Dot.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.FuentePrincipal);
            Button_BackSpace.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.FuentePrincipal);

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
            ConfirmAndExitDepositButton.Text = MultilanguangeController.GetText(MultiLanguageEnum.ACCEPT_BUTTON);
            CancelDepositButton.Text = MultilanguangeController.GetText(MultiLanguageEnum.CANCEL_BUTTON);
            BackButton.Text = MultilanguangeController.GetText(MultiLanguageEnum.VOLVER);
            RemainingTimeLabel.Text = MultilanguangeController.GetText(MultiLanguageEnum.TIEMPO_RESTANTE);

            DenominationsGridView.Columns["Denomination"].HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.DESCRIPCION);
            DenominationsGridView.Columns["Quantity"].HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.CANTIDAD);
            DenominationsGridView.Columns["Amount"].HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.IMPORTE);
            EnvelopeTextBox.PlaceholderText = MultilanguangeController.GetText(MultiLanguageEnum.ENVELOPE_TEXTBOX_PLACEHOLDER);

        }

            private void EnvelopeDepositForm_Load(object sender, EventArgs e)
        {
            _device = (Permaquim.Depositary.UI.Desktop.Components.Device)this.Tag;
            _pollingTimer = new System.Windows.Forms.Timer()
            {
                Interval = DeviceController.GetPollingInterval(),
                Enabled = true
            };
            _pollingTimer.Tick += PollTimer_Tick;

            _operationStatus = new();
            CurrencyLabel.Text = DatabaseController.CurrentCurrency.Nombre;
        }
        private void EnvelopeDepositForm_VisibleChanged(object sender, EventArgs e)
        {
            MonitorGroupcheckbox.Visible = SecurityController.IsFunctionenabled(FunctionEnum.ViewEvents);

            _pollingTimer.Enabled = this.Visible;
            if (this.Visible)
            {
                LoadDenominations();
                LoadLanguageItems();
                NumberPanel.Visible = true;
                DenominationsGridView.Visible = true;
                CurrencyLabel.Visible = true;
                RemainingTimeLabel.Visible = true;
                SubtotalLabel.Visible = true;
                ButtonsPanel.Visible = true;
            }
            else
                InitializeLocals();

        }
        private void InitializeLocals()
        {
            _envelopeDepositItems = new();
            _totalQuantity = 0;
            _totalAmount = 0;
            _operationStatus = new();
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

        private void PollTimer_Tick(object? sender, EventArgs e)
        {
            if (TimeOutController.IsTimeOut())
            {
                _pollingTimer.Enabled = false;
                DatabaseController.LogOff(true);
                FormsController.LogOff();
            }
            EvaluateTimeout();

            // Asigna a la máquina el valor del estado de la contadora en este ciclo
            if (_device.CounterConnected)
            {
                _operationStatus.GeneralStatus = _device.CurrentStatus;

                if (_device != null && _device.CounterConnected)
                {
                    if (_device.StateResultProperty.ModeStateInformation.ModeState != ModeStateInformation.Mode.ManualMode)
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

            SetTotals();
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

            // Si el esrcrow está abierto, y el sensor detecta presencia, se asume que es un sobre y se 
            // completa el depósito
            if (
                _operationStatus.GeneralStatus == StatusInformation.State.PQWaitingTocloseEscrow
                && _device.StateResultProperty.DeviceStateInformation.EscrowBillPresent == true
                && _device.PreviousState == StatusInformation.State.PQWaitingEnvelope)
             {
                _operationStatus.DepositConfirmed = true;
                _device.CloseEscrow();
                _device.PreviousState = StatusInformation.State.PQClosingEscrow;
                ButtonsPanel.Visible = false;
            }
        }
        /// <summary>
        /// Habilita la visualización de los botones de acuerdo a los estados del hardware
        /// </summary>
        private void VerifyButtonsVisibility()
        {
            BackButton.Visible =
                !_device.StateResultProperty.DeviceStateInformation.EscrowBillPresent
                && _totalQuantity == 0;// && _totalAmount == 0;

            //Solo se habilita el botón de volver si no hay dinero en el escrow
            ConfirmAndExitDepositButton.Visible =
                !_device.StateResultProperty.DeviceStateInformation.EscrowBillPresent
                && _totalQuantity > 0;//&& _totalAmount > 0;

            CancelDepositButton.Visible =
           !_device.StateResultProperty.DeviceStateInformation.EscrowBillPresent
                && _totalQuantity > 0;//&& _totalAmount > 0;

        }
        private void ShowInformation()
        {
            InformationLabel.Text = String.Empty;

            if (!_device.StateResultProperty.DeviceStateInformation.EscrowBillPresent
             && _operationStatus.CurrentTransactionQuantity == 0)
            {
                InformationLabel.Text = MultilanguangeController.GetText(MultiLanguageEnum.INGRESAR_VALORES_SOBRE);
                InformationLabel.ForeColor = Color.Green;
            }

            if (_device.StateResultProperty.DeviceStateInformation.EscrowBillPresent
                && _operationStatus.CurrentTransactionQuantity == 0
                && _device.StateResultProperty.StatusInformation.OperatingState == StatusInformation.State.PQWaitingToRemoveBankNotes)
            {
                InformationLabel.Text = MultilanguangeController.GetText(MultiLanguageEnum.RETIRAR_SOBRE);
                InformationLabel.ForeColor = Color.Red;
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
                _device.StoringStart();
                _device.PreviousState = StatusInformation.State.PQStoring;
                ExitEnvelopeDepositForm();

            }
        }
        private void ExitEnvelopeDepositForm()
        {

            DisableControls();

            SaveTransaction(false);

           _operationStatus.DepositEnded = true;

        }
        /// <summary>
        /// Graba el depósito en base de datos
        /// </summary>
        private void SaveTransaction(bool IsAutoclose)
        {
            NumberPanel.Visible = false;
            DenominationsGridView.Visible = false;
            CurrencyLabel.Visible = false;
            RemainingTimeLabel.Visible = false;
            SubtotalLabel.Visible = false;
            InformationLabel.Text = MultilanguangeController.GetText(MultiLanguageEnum.AGUARDE_DEPOSITO);
            InformationLabel.ForeColor = Color.Green;

            Permaquim.Depositario.Business.Tables.Operacion.Sesion sesiones = new();
            sesiones.Items(null, DatabaseController.CurrentUser.Id, null, null, null, IsAutoclose);


            Permaquim.Depositario.Business.Tables.Operacion.Transaccion transactions = new();
    
            Permaquim.Depositario.Entities.Tables.Operacion.Transaccion transaction = new()
                {
                    CierreDiarioId = 0,
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
                    UsuarioCuentaId = DatabaseController.CurrentUserBankAccount == null ? 0 :
                    DatabaseController.CurrentUserBankAccount.CuentaId.Id,
                    UsuarioId = DatabaseController.CurrentUser.Id

                };
                transactions.Add(transaction);
                _operationStatus.CurrentTransactionId = transaction.Id;

            Permaquim.Depositario.Business.Tables.Operacion.TransaccionSobre transactionEnvelopes = new();
            Permaquim.Depositario.Entities.Tables.Operacion.TransaccionSobre transactionEnvelope = new()
            {
                CodigoSobre = EnvelopeTextBox.Texts.Trim(),
                TransaccionId = _operationStatus.CurrentTransactionId,
                Fecha = DateTime.Now
            };
            transactionEnvelopes.Add(transactionEnvelope);

            Permaquim.Depositario.Business.Tables.Operacion.TransaccionSobreDetalle transactionenvelopeDetails = new();
            foreach (var item in _envelopeDepositItems)
            {
                if (item.Id > -1  && item.Quantity > 0)
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
        }
        private void DisableControls()
        {
            DenominationsGridView.Visible = false;
            CancelDepositButton.Visible = false;
            ConfirmAndExitDepositButton.Visible = false;
            EnvelopeTextBox.Visible = false;

        }
        private class EnvelopeDepositItem
        {
            public long Id  { get; set; }
            public string Denomination { get; set; }
            public long Quantity { get; set; }
            public double Amount { get; set; }
            public Image? Image { get; set; }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            if (_device.CounterConnected)
                _device.RemoteCancel();
            FormsController.OpenChildForm(this,new OperationForm(), _device);
        }

        private void ConfirmAndExitDepositButton_Click(object sender, EventArgs e)
        {
            TimeOutController.Reset();
            _device.OpenEscrow();
            _device.PreviousState = StatusInformation.State.PQWaitingEnvelope;

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
        }

        private void DenominationsGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            System.Diagnostics.Debug.Print(e.Exception.Message);
        }

        private void DenominationsGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            activatedCell = ((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex];
            _selectedEditElement = SelectedEditElementEnum.Cell;
            DenominationsGridView.BeginEdit(false);
        }

        private void DenominationsGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            System.Diagnostics.Debug.Print(e.ToString());
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
    }
}