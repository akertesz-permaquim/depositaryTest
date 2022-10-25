using Permaquim.Depositary.UI.Desktop.Builders;
using Permaquim.Depositary.UI.Desktop.Components;
using Permaquim.Depositary.UI.Desktop.Controllers;
using Permaquim.Depositary.UI.Desktop.Entities;
using Permaquim.Depositary.UI.Desktop.Global;
using static Permaquim.Depositary.UI.Desktop.Global.Enumerations;

namespace Permaquim.Depositary.UI.Desktop
{
    public partial class OperationForm : Form
    {

        private List<Permaquim.Depositario.Entities.Relations.Operacion.TipoTransaccion> _transactions = DatabaseController.GetTransactionTypes();
        private System.Windows.Forms.Timer _pollingTimer = new System.Windows.Forms.Timer();

        private CustomButton _backButton;

        CounterDevice _device = null;
        public OperationForm()
        {
            InitializeComponent();
            TimeOutController.Reset();
            _pollingTimer = new System.Windows.Forms.Timer()
            {
                Interval = DeviceController.GetPollingInterval()
            };
            _pollingTimer.Tick += PollingTimer_Tick;
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
        private void PollingTimer_Tick(object? sender, EventArgs e)
        {
            if (!ConfigurationController.IsDevelopment())
            {
                MainPanel.Enabled = _device.StateResultProperty.ModeStateInformation.ModeState
                == ModeStateInformation.Mode.Neutral_SettingMode;
            }
            else
            {
                MainPanel.Enabled = true;

            }
            _backButton.Enabled = true;

            if (TimeOutController.IsTimeOut())
            {
                _pollingTimer.Enabled = false;
                DatabaseController.LogOff(true);
                FormsController.LogOff();
            }

            if (!ConfigurationController.IsDevelopment())
            {
                if (_device.StateResultProperty.DoorStateInformation.Escrow)
                    _device.CloseEscrow();

                if (_device.StateResultProperty.ModeStateInformation.ModeState != ModeStateInformation.Mode.Neutral_SettingMode)
                {
                    _device.RemoteCancel();
                    FormsController.SetInformationMessage(InformationTypeEnum.None, String.Empty);

                }
            }


        }
        private void OperationForm_Load(object sender, EventArgs e)
        {
            _device = (Permaquim.Depositary.UI.Desktop.Components.CounterDevice)this.Tag;
            LoadStyles();
            CenterPanel();
            if (_device != null && _device.CounterConnected)
                SetDeviceToNeutralMode();
            LoadTransactionButtons();
            LoadReportsButton();
            LoadOtherOperationsButton();
            LoadBackButton();

        }
        private void LoadStyles()
        {
            this.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.FondoFormulario);
        }
        private void CenterPanel()
        {

            MainPanel.Location = new Point()
            {
                X = this.Width / 2 - MainPanel.Width / 2,
                Y = this.Height / 2 - MainPanel.Height / 2
            };

        }
        private void LoadTransactionButtons()
        {
            this.MainPanel.Controls.Clear();
            foreach (var item in _transactions)
            {

                if (SecurityController.IsOperationEnabled(((long)item.FuncionId)))
                {
                    CustomButton newButton = ControlBuilder.BuildStandardButton(
                        "TransactionButton" + item.Id.ToString(),
                        MultilanguangeController.GetText(item.Nombre), MainPanel.Width);

                    newButton.Click += new System.EventHandler(TransactionButton_Click);

                    newButton.Tag = item;

                    this.MainPanel.Controls.Add(newButton);
                }
            }

        }
        private void TransactionButton_Click(object sender, EventArgs e)
        {
            DatabaseController.CurrentOperation = (Permaquim.Depositario.Entities.Relations.Operacion.TipoTransaccion)((CustomButton)sender).Tag;

            switch ((int)DatabaseController.CurrentOperation.Id)
            {

                case (int)OperationTypeEnum.BillDeposit:

                    if (_device != null && !_device.CounterConnected)
                    {
                        OperationBlockingForm operationBlockingForm = new OperationBlockingForm();
                        operationBlockingForm.OperationBlockingReason = OperationblockingReasonEnum.CounterCommunicationError;
                        operationBlockingForm.ShowDialog();
                        DatabaseController.SetBlockingEvent(Enum.GetName(EventTypeEnum.Error_De_Comunicacion),
                            (int)EventTypeEnum.Estado_Fuera_De_Servicio, string.Empty);
                        return;
                    }
                    else
                    {
                        DatabaseController.SetBlockingEvent(Enum.GetName(EventTypeEnum.Normal),
                        (int)EventTypeEnum.Normal, string.Empty);
                    }

                    if (DatabaseController.GetBagPercentaje() >= ParameterController.BagMaxPercentage)
                    {
                        OperationBlockingForm operationBlockingForm = new OperationBlockingForm();
                        operationBlockingForm.OperationBlockingReason = OperationblockingReasonEnum.ContainerMaxVolumeReached;
                        operationBlockingForm.ShowDialog();
                        return;
                        DatabaseController.SetBlockingEvent(Enum.GetName(OperationblockingReasonEnum.ContainerMaxVolumeReached),
                       (int)EventTypeEnum.Estado_Fuera_De_Servicio, string.Empty);
                    }
                    else
                    {
                        DatabaseController.SetBlockingEvent(Enum.GetName(EventTypeEnum.Normal),
                        (int)EventTypeEnum.Normal, string.Empty);
                    }

                    if (DatabaseController.CurrentContainer.FechaCierre != null)
                    {
                        OperationBlockingForm operationBlockingForm = new OperationBlockingForm();
                        operationBlockingForm.OperationBlockingReason = OperationblockingReasonEnum.CurrentContainerIsClosed;
                        operationBlockingForm.ShowDialog();
                        DatabaseController.SetBlockingEvent(Enum.GetName(OperationblockingReasonEnum.CurrentContainerIsClosed),
                     (int)EventTypeEnum.Estado_Fuera_De_Servicio, string.Empty);
                        return;
                    }
                    else
                    {
                        DatabaseController.SetBlockingEvent(Enum.GetName(EventTypeEnum.Normal),
                        (int)EventTypeEnum.Normal, string.Empty);
                    }

                    if (DatabaseController.CurrentTurn != null)
                    {
                        if (DatabaseController.GetCurrencies().Count == 1)
                        {
                            DatabaseController.CurrentCurrency = DatabaseController.GetCurrencies()[0];
                            FormsController.OpenChildForm(this, new BillDepositForm(),
                                        (Permaquim.Depositary.UI.Desktop.Components.CounterDevice)this.Tag);
                        }
                        else
                        {
                            FormsController.OpenChildForm(this, new CurrencySelectorForm(),
                            (Permaquim.Depositary.UI.Desktop.Components.CounterDevice)this.Tag);
                        }
                    }
                    else
                    {
                        if (DatabaseController.GetAvailableTurns() > 0)
                        {
                            if (DatabaseController.GetCurrencies().Count == 1)
                            {
                                DatabaseController.CurrentCurrency = DatabaseController.GetCurrencies()[0];
                                FormsController.OpenChildForm(this, new BillDepositForm(),
                                            (Permaquim.Depositary.UI.Desktop.Components.CounterDevice)this.Tag);
                            }
                            else
                            {
                                FormsController.OpenChildForm(this, new CurrencySelectorForm(),
                                (Permaquim.Depositary.UI.Desktop.Components.CounterDevice)this.Tag);
                            }
                        }
                        else
                        {
                            FormsController.SetInformationMessage(InformationTypeEnum.Error,
                            MultilanguangeController.GetText(MultiLanguageEnum.SIN_TURNO));
                        }
                    }

                    break;

                case (int)OperationTypeEnum.EnvelopeDeposit:

                    if (_device != null && !_device.CounterConnected)
                    {
                        OperationBlockingForm operationBlockingForm = new OperationBlockingForm();
                        operationBlockingForm.OperationBlockingReason = OperationblockingReasonEnum.CounterCommunicationError;
                        operationBlockingForm.ShowDialog();
                        DatabaseController.SetBlockingEvent(Enum.GetName(EventTypeEnum.Error_De_Comunicacion),
                            (int)EventTypeEnum.Estado_Fuera_De_Servicio, string.Empty);
                        return;
                    }
                    else
                    {
                        DatabaseController.SetBlockingEvent(Enum.GetName(EventTypeEnum.Normal),
                        (int)EventTypeEnum.Normal, string.Empty);
                    }

                    if (DatabaseController.GetBagPercentaje() >= ParameterController.BagMaxPercentage)
                    {
                        OperationBlockingForm operationBlockingForm = new OperationBlockingForm();
                        operationBlockingForm.OperationBlockingReason = OperationblockingReasonEnum.ContainerMaxVolumeReached;
                        operationBlockingForm.ShowDialog();
                        return;
                        DatabaseController.SetBlockingEvent(Enum.GetName(OperationblockingReasonEnum.ContainerMaxVolumeReached),
                       (int)EventTypeEnum.Estado_Fuera_De_Servicio, string.Empty);
                    }
                    else
                    {
                        DatabaseController.SetBlockingEvent(Enum.GetName(EventTypeEnum.Normal),
                        (int)EventTypeEnum.Normal, string.Empty);
                    }

                    if (DatabaseController.CurrentContainer.FechaCierre != null)
                    {
                        OperationBlockingForm operationBlockingForm = new OperationBlockingForm();
                        operationBlockingForm.OperationBlockingReason = OperationblockingReasonEnum.CurrentContainerIsClosed;
                        operationBlockingForm.ShowDialog();
                        DatabaseController.SetBlockingEvent(Enum.GetName(OperationblockingReasonEnum.CurrentContainerIsClosed),
                     (int)EventTypeEnum.Estado_Fuera_De_Servicio, string.Empty);
                        return;
                    }
                    else
                    {
                        DatabaseController.SetBlockingEvent(Enum.GetName(EventTypeEnum.Normal),
                        (int)EventTypeEnum.Normal, string.Empty);
                    }

                    if (DatabaseController.CurrentTurn != null)
                    {
                        FormsController.OpenChildForm(this, new CurrencySelectorForm(),
                        (Permaquim.Depositary.UI.Desktop.Components.CounterDevice)this.Tag);
                        //}
                    }
                    else
                    {
                        if (DatabaseController.GetAvailableTurns() > 0)
                        {
                            if (DatabaseController.CurrentCurrency != null)
                            {
                                if (DatabaseController.GetCurrencyValueRelations().Count == 1)
                                {
                                    DatabaseController.CurrentCurrency = DatabaseController.GetCurrencies()[0];
                                    FormsController.OpenChildForm(this, new EnvelopeDepositForm(),
                                    (Permaquim.Depositary.UI.Desktop.Components.CounterDevice)this.Tag);
                                }
                            }
                            else
                            {
                                if (DatabaseController.GetCurrencyValueRelations().Count == 1)
                                {
                                    DatabaseController.CurrentCurrency = DatabaseController.GetCurrencies()[0];
                                    FormsController.OpenChildForm(this, new EnvelopeDepositForm(),
                                    (Permaquim.Depositary.UI.Desktop.Components.CounterDevice)this.Tag);
                                }
                                else
                                {
                                    FormsController.OpenChildForm(this, new CurrencySelectorForm(),
                                    (Permaquim.Depositary.UI.Desktop.Components.CounterDevice)this.Tag);
                                }
                            }
                        }
                        else
                        {
                            FormsController.SetInformationMessage(InformationTypeEnum.Error, MultilanguangeController.GetText(MultiLanguageEnum.SIN_TURNO));
                        }
                    }

                    break;

                case (int)OperationTypeEnum.ValueExtraction:
                    FormsController.OpenChildForm(this, new BagExtractionForm(),
                        (Permaquim.Depositary.UI.Desktop.Components.CounterDevice)this.Tag);
                    break;

                default:
                    break;
            }
        }
        private void LoadBackButton()
        {
            _backButton = ControlBuilder.BuildExitButton(
                "BackButton", MultilanguangeController.GetText(MultiLanguageEnum.BOTON_SALIR), MainPanel.Width);

            this.MainPanel.Controls.Add(_backButton);
            _backButton.Click += new System.EventHandler(BackButton_Click);
        }

        #region Reports

        private void LoadReportsButton()
        {
            if (SecurityController.IsFunctionEnabled(FunctionEnum.HistoricoTransacciones)
                || SecurityController.IsFunctionEnabled(FunctionEnum.HistoricoDeCierreDiario)
                || SecurityController.IsFunctionEnabled(FunctionEnum.HistoricoDeBolsas)
                )
            {
                CustomButton reportsButton = ControlBuilder.BuildStandardButton(
                    "ReportsButton", MultilanguangeController.GetText(MultiLanguageEnum.REPORTES), MainPanel.Width);

                this.MainPanel.Controls.Add(reportsButton);
                reportsButton.Click += new System.EventHandler(ReportsButton_Click);
            }
        }

        private void ReportsButton_Click(object sender, EventArgs e)
        {
            FormsController.OpenChildForm(this, new ReportsForm(),
              (Permaquim.Depositary.UI.Desktop.Components.CounterDevice)this.Tag);
        }
        #endregion

        #region Other Operations
        private void LoadOtherOperationsButton()
        {
            if (
                SecurityController.IsFunctionEnabled(FunctionEnum.CambioDeTurno)
                || SecurityController.IsFunctionEnabled(FunctionEnum.CierreDiario)
                || SecurityController.IsFunctionEnabled(FunctionEnum.Soporte)
             )
            {
                CustomButton otherOperationsButton = ControlBuilder.BuildAlternateButton(
                    "OtherOperationsButton",
                    MultilanguangeController.GetText(MultiLanguageEnum.OTRAS_OPERACIONES), MainPanel.Width);

                this.MainPanel.Controls.Add(otherOperationsButton);
                otherOperationsButton.Click += new System.EventHandler(OtherOperationButton_Click);
            }
        }

        private void OtherOperationButton_Click(object sender, EventArgs e)
        {
            FormsController.OpenChildForm(this, new OtherOperationsForm(),
              (Permaquim.Depositary.UI.Desktop.Components.CounterDevice)this.Tag);
        }
        # endregion

        private void BackButton_Click(object sender, EventArgs e)
        {
            DatabaseController.LogOff(false);
            MultilanguangeController.ResetLanguage();
            FormsController.HideInstance(this);
            FormsController.LogOff();
        }
        private void SetDeviceToNeutralMode()
        {
            // si por algun motivo el equipo se recupera de una transacción fallida,
            // se cancela la operación.
            if (_device.StateResultProperty.ModeStateInformation.ModeState
                == ModeStateInformation.Mode.DepositMode
                || _device.StateResultProperty.ModeStateInformation.ModeState
                == ModeStateInformation.Mode.ManualMode)
            {
                _device.RemoteCancel();
            }
        }

        private void OperationForm_MouseClick(object sender, MouseEventArgs e)
        {
            TimeOutController.Reset();
        }

        private void OperationForm_VisibleChanged(object sender, EventArgs e)
        {
            MainPanel.Enabled = false;
            _backButton.Enabled = true;
            _pollingTimer.Enabled = this.Visible;
            if (!this.Visible)
                InitializeLocals();
            else
            {
                _transactions = DatabaseController.GetTransactionTypes();
                LoadTransactionButtons();
                LoadOtherOperationsButton();
                LoadReportsButton();
                LoadBackButton();
                if (!ConfigurationController.IsDevelopment())
                    _device.RemoteCancel();

                if (DatabaseController.CurrentTurn != null)
                {
                    if (DatabaseController.CurrentTurn.Fecha < DateTime.Now.Date)
                    {
                        FormsController.SetInformationMessage(InformationTypeEnum.Error,
                        MultilanguangeController.GetText(MultiLanguageEnum.EXISTEN_TURNOS_PREVIOS_A_LA_FECHA));
                    }
                }
            }
        }
        private void InitializeLocals()
        {
            _transactions = new();
        }
    }
}
