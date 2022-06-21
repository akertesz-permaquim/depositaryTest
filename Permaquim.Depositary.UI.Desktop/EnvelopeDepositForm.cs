﻿using Permaquim.Depositary.UI.Desktop.Components;
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


        private enum SelectedEditElementEnum
        {
            Ninguno = 0,
            Celda = 1,
            CodigoSobre = 2
        }

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
            _selectedEditElement = SelectedEditElementEnum.Celda;
        }

        //////////////////////////////////////////////////////////////////////
        public EnvelopeDepositForm()
        {
            InitializeComponent();
            LoadStyles();
            CenterPanel();
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
            this.BackColor = StyleController.GetColor(StyleController.ColorNameEnum.Contenido);

            Button_0.BackColor = StyleController.GetColor(StyleController.ColorNameEnum.FuentePrincipal);
            Button_1.BackColor = StyleController.GetColor(StyleController.ColorNameEnum.FuentePrincipal);
            Button_2.BackColor = StyleController.GetColor(StyleController.ColorNameEnum.FuentePrincipal);
            Button_3.BackColor = StyleController.GetColor(StyleController.ColorNameEnum.FuentePrincipal);
            Button_4.BackColor = StyleController.GetColor(StyleController.ColorNameEnum.FuentePrincipal);
            Button_5.BackColor = StyleController.GetColor(StyleController.ColorNameEnum.FuentePrincipal);
            Button_6.BackColor = StyleController.GetColor(StyleController.ColorNameEnum.FuentePrincipal);
            Button_7.BackColor = StyleController.GetColor(StyleController.ColorNameEnum.FuentePrincipal);
            Button_8.BackColor = StyleController.GetColor(StyleController.ColorNameEnum.FuentePrincipal);
            Button_9.BackColor = StyleController.GetColor(StyleController.ColorNameEnum.FuentePrincipal);
            Button_Dot.BackColor = StyleController.GetColor(StyleController.ColorNameEnum.FuentePrincipal);
            Button_BackSpace.BackColor = StyleController.GetColor(StyleController.ColorNameEnum.FuentePrincipal);
            CurrencyLabel.BackColor = StyleController.GetColor(StyleController.ColorNameEnum.Cabecera);
            SubtotalLabel.BackColor = StyleController.GetColor(StyleController.ColorNameEnum.Cabecera);
            
            DenominationsGridView.ColumnHeadersDefaultCellStyle.BackColor = StyleController.GetColor(StyleController.ColorNameEnum.Cabecera);

            ConfirmAndExitDepositButton.Text = MultilanguangeController.GetText("ACCEPT_BUTTON");
            CancelDepositButton.Text = MultilanguangeController.GetText("CANCEL_BUTTON");
            BackButton.Text = MultilanguangeController.GetText("EXIT_BUTTON");
            RemainingTimeLabel.Text = MultilanguangeController.GetText("TIEMPO_RESTANTE");

            DenominationsGridView.Columns["Denomination"].HeaderText = MultilanguangeController.GetText("DENOMINACION");
            DenominationsGridView.Columns["Quantity"].HeaderText = MultilanguangeController.GetText("CANTIDAD");
            DenominationsGridView.Columns["Amount"].HeaderText = MultilanguangeController.GetText("IMPORTE");
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


            LoadDenominations();

            CurrencyLabel.Text = DatabaseController.CurrentCurrency.Nombre;
        }
        public void LoadDenominations()
        {
            
            foreach (var item in DatabaseController.GetEnvelopeValues())
            {
                byte[] bytes = Convert.FromBase64String(item.TipoValorId.Imagen
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
                Image = null,
                Denomination = "Total",
                Quantity = 0,
                Amount = 0,
                Id = -1,
            });

            DenominationsGridView.DataSource = _envelopeDepositItems;
            UpdateTotals();


        }

        private void PollTimer_Tick(object? sender, EventArgs e)
        {

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

            UpdateTotals();
        }

        private void UpdateTotals()
        {
            try
            {
                DenominationsGridView.Rows[DenominationsGridView.Rows.Count - 1].DefaultCellStyle.BackColor = Color.SteelBlue;
                DenominationsGridView.Rows[DenominationsGridView.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.White;
                DenominationsGridView.Rows[DenominationsGridView.Rows.Count - 1].DefaultCellStyle.Font = new Font("Verdana", 16);

                for (int i = 2; i < DenominationsGridView.Columns.Count; i++)
                {
                    DenominationsGridView.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    DenominationsGridView.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                SumValues();
                DenominationsGridView.Rows[DenominationsGridView.Rows.Count - 1].Selected = true;
            }
            catch (Exception)
            {
            }

        }

        private void DenominationsGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == 4 && e.RowIndex == DenominationsGridView.Rows.Count - 1)
            {
                e.PaintBackground(e.ClipBounds, true);
                e.Handled = true;
            }
        }


        private void DenominationsGridView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void SumValues()
        {
            _totalQuantity = 0;
            _totalAmount = 0;
            foreach (var item in DenominationsGridView.Rows)
            {
                if (((long)((DataGridViewRow)item).Cells["Id"].Value) > -1)
                {
                    _totalQuantity += (long)((DataGridViewRow)item).Cells["Quantity"].Value;
                    _totalAmount  += (double)((DataGridViewRow)item).Cells["Amount"].Value;
                }
            }

            DenominationsGridView.Rows[DenominationsGridView.Rows.Count - 1].Cells["Quantity"].Value = _totalQuantity;
            DenominationsGridView.Rows[DenominationsGridView.Rows.Count - 1].Cells["Amount"].Value = _totalAmount;

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
                        this.Close();
                        AppController.OpenChildForm(new OperationForm(), _device);
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

            // Si el esrcrow está aberto, y el sensor detecta presencia, se asume que es un sobre y se 
            // completa el depósito
            if (
                _operationStatus.GeneralStatus == StatusInformation.State.PQWaitingTocloseEscrow
                && _device.StateResultProperty.DeviceStateInformation.EscrowBillPresent == true
                && _device.PreviousState == StatusInformation.State.PQWaitingEnvelope)
             {
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
            BackButton.Visible =
                !_device.StateResultProperty.DeviceStateInformation.EscrowBillPresent
                && _totalQuantity == 0 && _totalAmount == 0;

            //Solo se habilita el botón de volver si no hay dinero en el escrow
            ConfirmAndExitDepositButton.Visible =
                !_device.StateResultProperty.DeviceStateInformation.EscrowBillPresent
                && _totalQuantity > 0 && _totalAmount > 0;

            CancelDepositButton.Visible =
           !_device.StateResultProperty.DeviceStateInformation.EscrowBillPresent
                && _totalQuantity > 0 && _totalAmount > 0;

          

        }
        private void ShowInformation()
        {
            InformationLabel.Text = String.Empty;

            if (!_device.StateResultProperty.DeviceStateInformation.EscrowBillPresent
             && _operationStatus.CurrentTransactionQuantity == 0)
            {
                InformationLabel.Text = MultilanguangeController.GetText("INGRESAR_VALORES_SOBRE");
                InformationLabel.ForeColor = Color.Green;
            }

            if (_device.StateResultProperty.DeviceStateInformation.EscrowBillPresent
                && _operationStatus.CurrentTransactionQuantity == 0
                && _device.StateResultProperty.StatusInformation.OperatingState == StatusInformation.State.PQWaitingToRemoveBankNotes)
            {
                InformationLabel.Text = MultilanguangeController.GetText("RETIRAR_SOBRE");
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

            SaveTransaction();

           _operationStatus.DepositEnded = true;

        }
        /// <summary>
        /// Graba el depósito en base de datos
        /// </summary>
        private void SaveTransaction()
        {
            NumberPanel.Visible = false;
            DenominationsGridView.Visible = false;
            InformationLabel.Text = MultilanguangeController.GetText("AGUARDE_DEPOSITO");
            InformationLabel.ForeColor = Color.Green;

            Permaquim.Depositario.Business.Tables.Operacion.Sesion sesiones = new();
            sesiones.Items(null, DatabaseController.CurrentUser.Id, null, null, null);


            Permaquim.Depositario.Business.Tables.Operacion.Transaccion transactions = new();
    
            Permaquim.Depositario.Entities.Tables.Operacion.Transaccion transaction = new()
                {
                    CierreDiarioId = 0,
                    ContenedorId = DatabaseController.CurrentContainer.Id,
                    DepositarioId = DatabaseController.CurrentDepositary.Id,
                    Fecha = DateTime.Now,
                    Finalizada = true,
                    SectorId = DatabaseController.CurrentDepositary.SectorId.Id,
                    SesionId = sesiones.Result.FirstOrDefault().Id,
                    SucursalId = DatabaseController.CurrentDepositary.SectorId.SucursalId.Id,
                    TipoId = 3,             // Depósito de Sobre
                    TotalAValidar = 0,
                    TotalValidado = 0,
                    TurnoId = 0,
                    UsuarioCuentaId = 0,
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
                if (item.Id > -1)
                {
                    Permaquim.Depositario.Entities.Tables.Operacion.TransaccionSobreDetalle transactionEnvelopeDetail = new()
                    {
                        
                        CantidadDeclarada = item.Quantity,
                        RelacionMonedaTipoValorId = item.Id,
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
            _pollingTimer.Enabled = false;
            AppController.OpenChildForm(new OperationForm(), _device);
        }

        private void EventCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            MonitorGroupBox.Visible = EventCheckbox.Checked;
        }

        private void ConfirmAndExitDepositButton_Click(object sender, EventArgs e)
        {
            _device.OpenEscrow();
            _device.PreviousState = StatusInformation.State.PQWaitingEnvelope;

        }

        #region Number Keyboard buttons
        private void Keys(object sender, EventArgs e)
        {

            if (_selectedEditElement == SelectedEditElementEnum.Celda)
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
                SumValues();
            }
            if (_selectedEditElement == SelectedEditElementEnum.CodigoSobre)
            {
                EnvelopeTextBox.Focus();
                SendKeys.Send(((CustomButton)sender).Tag.ToString());
            }
        }
        #endregion

  
        private void EnvelopeTextBox_Enter(object sender, EventArgs e)
        {
            _selectedEditElement = SelectedEditElementEnum.CodigoSobre;
        }

        private void DenominationsGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            System.Diagnostics.Debug.Print(e.Exception.Message);
        }

        private void DenominationsGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            activatedCell = ((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex];
            _selectedEditElement = SelectedEditElementEnum.Celda;
            DenominationsGridView.BeginEdit(true);
        }

        private void DenominationsGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
          
        }
    }
}
