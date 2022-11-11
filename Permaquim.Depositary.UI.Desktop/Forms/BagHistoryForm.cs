using Permaquim.Depositary.UI.Desktop.Builders;
using Permaquim.Depositary.UI.Desktop.Components;
using Permaquim.Depositary.UI.Desktop.Controllers;
using Permaquim.Depositary.UI.Desktop.Entities;
using Permaquim.Depositary.UI.Desktop.Global;
using System.Windows.Forms;
using static Permaquim.Depositary.UI.Desktop.Global.Enumerations;

namespace Permaquim.Depositary.UI.Desktop
{
    public partial class BagHistoryForm : Form
    {
        public CounterDevice _device { get; set; }
        private System.Windows.Forms.Timer _pollingTimer = new System.Windows.Forms.Timer();

        private List<Depositario.Entities.Views.Reporte.Contenedores> _bagHistoryItems = new();

        private long _currentContainerId;

        private List<BagBillContentResume> _bagContentItems = new();
        private List<BagBillContentResume> _bagContentResumeItems = new();

        public BagHistoryForm()
        {
            InitializeComponent();
            CenterPanel();
            LoadStyles();
            LoadMultilanguageItems();

            ResetReport();

            TimeOutController.Reset();
            _pollingTimer = new System.Windows.Forms.Timer()
            {
                Interval = DeviceController.GetPollingInterval()
            };
            _pollingTimer.Tick += PollingTimer_Tick;

        }

        private void ResetReport()
        {
            ToFechaAperturaDateTimePicker.Value = DateTime.Now.Date;
            ToFechaCierreDateTimePicker.Value = DateTime.Now.Date;
            ToFechaCierreDateTimePicker.Checked = false;

            FromFechaCierreDateTimePicker.Value = DateTime.Now.Date;
            FromFechaAperturaDateTimePicker.Value = DateTime.Now.Date;
            FromFechaCierreDateTimePicker.Checked = false;

            IdentificadorTextbox.Text = "";

            FromFechaAperturaDateTimePicker.Format = DateTimePickerFormat.Custom;
            FromFechaAperturaDateTimePicker.CustomFormat = MultilanguangeController.GetText(MultiLanguageEnum.FORMATO_FECHA);
            ToFechaAperturaDateTimePicker.Format = DateTimePickerFormat.Custom;
            ToFechaAperturaDateTimePicker.CustomFormat = MultilanguangeController.GetText(MultiLanguageEnum.FORMATO_FECHA);


            FromFechaCierreDateTimePicker.Format = DateTimePickerFormat.Custom;
            FromFechaCierreDateTimePicker.CustomFormat = MultilanguangeController.GetText(MultiLanguageEnum.FORMATO_FECHA);
            ToFechaCierreDateTimePicker.Format = DateTimePickerFormat.Custom;
            ToFechaCierreDateTimePicker.CustomFormat = MultilanguangeController.GetText(MultiLanguageEnum.FORMATO_FECHA);


            LoadBagHistoryItems();
        }

        private void PollingTimer_Tick(object? sender, EventArgs e)
        {
            if (TimeOutController.IsTimeOut())
            {
                _pollingTimer.Enabled = false;
                DatabaseController.LogOff(true);
                FormsController.LogOff();
            }
        }

        private void BagHistoryForm_Load(object sender, EventArgs e)
        {
            _device = (Permaquim.Depositary.UI.Desktop.Components.CounterDevice)this.Tag;
        }
        private void CenterPanel()
        {

            MainGridView.Location = new Point()
            {
                X = this.Width / 2 - MainGridView.Width / 2,
                Y = MainGridView.Location.Y
            };

            BackButton.Location = new Point()
            {
                X = this.Width / 2 - BackButton.Width / 2,
                Y = BackButton.Location.Y
            };

        }
        private void LoadStyles()
        {
            this.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.FondoFormulario);
            AcceptButton.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.BotonAceptar);
            PrintButton.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.BotonAlternativo);
            BackButton.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.BotonSalir);
            ExecuteBagHistorySearch.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.BotonAceptar);
            ExecuteBagHistorySearch.BackgroundColor = StyleController.GetColor(Enumerations.ColorNameEnum.BotonAceptar);
            ExecuteBagHistorySearch.ForeColor = StyleController.GetColor(Enumerations.ColorNameEnum.FuenteContraste);
            ExecuteBagHistorySearch.TextColor = StyleController.GetColor(Enumerations.ColorNameEnum.FuenteContraste);

            StyleController.SetControlStyle(MainGridView);
            StyleController.SetControlStyle(BillDepositGridView);
            StyleController.SetControlStyle(EnvelopeDepositGridView);
        }

        private void LoadMultilanguageItems()
        {
            FromFechaAperturaDateTimeLabel.Text = MultilanguangeController.GetText(MultiLanguageEnum.FECHA_APERTURA_DESDE);
            ToFechaAperturaDateTimeLabel.Text = MultilanguangeController.GetText(MultiLanguageEnum.FECHA_APERTURA_HASTA);
            FromFechaCierreDateTimeLabel.Text = MultilanguangeController.GetText(MultiLanguageEnum.FECHA_CIERRE_DESDE);
            ToFechaCierreDateTimeLabel.Text = MultilanguangeController.GetText(MultiLanguageEnum.FECHA_CIERRE_HASTA);
            IdentificadorLabel.Text = MultilanguangeController.GetText(MultiLanguageEnum.IDENTIFICADOR);
            ExecuteBagHistorySearch.Text = MultilanguangeController.GetText(MultiLanguageEnum.EJECUTAR);
            AcceptButton.Text = MultilanguangeController.GetText(MultiLanguageEnum.BOTON_ACEPTAR_OPERACION);
            PrintButton.Text = MultilanguangeController.GetText(MultiLanguageEnum.IMPRIMIR);
            BackButton.Text = MultilanguangeController.GetText(MultiLanguageEnum.VOLVER);
        }
        #region BackButton
        private void BackButton_Click(object sender, EventArgs e)
        {
            ResetReport();
            TimeOutController.Reset();
            FormsController.OpenChildForm(this, new ReportsForm(), _device);
        }
        #endregion
        #region Datagrid        
        private void InitializeMainGridView()
        {
            MainGridView.AutoGenerateColumns = false;

            MainGridView.Columns.Clear();

            MainGridView.Columns.Add(new()
            {
                DataPropertyName = "ContenedorId",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.ID),
                Name = "Id",
                Visible = true,
                Width = 150,
                CellTemplate = new DataGridViewTextBoxCell()

            });

            MainGridView.Columns.Add(new()
            {
                DataPropertyName = "Identificador",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.CODIGO),
                Name = "Identificador",
                Visible = true,
                Width = 150,
                CellTemplate = new DataGridViewTextBoxCell()

            });

            MainGridView.Columns.Add(new()
            {
                DataPropertyName = "FechaApertura",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.FECHA_APERTURA),
                Name = "FechaApertura",
                Visible = true,
                Width = 150,
                CellTemplate = new DataGridViewTextBoxCell(),
                DefaultCellStyle = StyleController.GetDateColumnStyle()

            });

            MainGridView.Columns.Add(new()
            {
                DataPropertyName = "FechaCierre",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.FECHA_CIERRE),
                Name = "FechaCierre",
                Visible = true,
                Width = 150,
                CellTemplate = new DataGridViewTextBoxCell(),
                DefaultCellStyle = StyleController.GetDateColumnStyle()

            });

            MainGridView.Columns.Add(new()
            {
                DataPropertyName = "Depositario",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.DEPOSITARIO),
                Name = "Depositario",
                Visible = true,
                Width = 150,
                CellTemplate = new DataGridViewTextBoxCell()

            });

            MainGridView.Columns.Add(new()
            {
                DataPropertyName = "CantidadTransacciones",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.CANTIDADOPERACIONES),
                Name = "CantidadTransacciones",
                Visible = true,
                Width = 150,
                CellTemplate = new DataGridViewTextBoxCell()

            });

            MainGridView.Columns.Add(new()
            {
                DataPropertyName = "CantidadBilletes",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.BILLETES),
                Name = "CantidadBilletes",
                Visible = true,
                Width = 150,
                CellTemplate = new DataGridViewTextBoxCell()

            });
            MainGridView.Columns.Add(new()
            {
                DataPropertyName = "CantidadSobres",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.SOBRES),
                Name = "CantidadSobres",
                Visible = true,
                Width = 150,
                CellTemplate = new DataGridViewTextBoxCell()

            });
            MainGridView.Columns.Add(new()
            {
                DataPropertyName = "CantidadTotalDineroMonedaDefault",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.CANTIDAD),
                Name = "CantidadTotalDineroMonedaDefault",
                Visible = true,
                Width = 150,
                CellTemplate = new DataGridViewTextBoxCell()

            });
        }

        #endregion

        #region Datagrid Detalle
        private void InitializeGridView(OperationTypeEnum operationType)
        {

            DataGridView referenceDataGridview = null;


            switch (operationType)
            {
                case OperationTypeEnum.None:
                    break;
                case OperationTypeEnum.BillDeposit:
                    referenceDataGridview = BillDepositGridView;
                    break;
                case OperationTypeEnum.CoinDeposit:
                    break;
                case OperationTypeEnum.EnvelopeDeposit:
                    referenceDataGridview = EnvelopeDepositGridView;
                    break;
                case OperationTypeEnum.ValueExtraction:
                    break;
                default:
                    break;
            }



            referenceDataGridview.AutoGenerateColumns = false;

            referenceDataGridview.Columns.Clear();

            referenceDataGridview.Columns.Add(new()
            {
                Visible = false,
                Width = 1,
                CellTemplate = new DataGridViewTextBoxCell()

            });

            referenceDataGridview.Columns.Add(new()
            {
                DataPropertyName = "MonedaId",
                Name = "MonedaId",
                Visible = false,
                Width = 50,
                CellTemplate = new DataGridViewTextBoxCell()

            });

            referenceDataGridview.Columns.Add(new()
            {
                DataPropertyName = "Moneda",
                HeaderText = (operationType == OperationTypeEnum.BillDeposit
                        ? MultilanguangeController.GetText(MultiLanguageEnum.MONEDA)
                        : MultilanguangeController.GetText(MultiLanguageEnum.SOBRE)),
                Name = "Moneda",
                Visible = true,
                Width = 350,
                CellTemplate = new DataGridViewTextBoxCell()


            });

            if (operationType == OperationTypeEnum.BillDeposit)
            {
                referenceDataGridview.Columns.Add(new()
                {
                    DataPropertyName = "CantidadBilletes",
                    HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.BILLETES),
                    Name = "CantidadBilletes",
                    Visible = true,
                    Width = 100,
                    CellTemplate = new DataGridViewTextBoxCell()

                });
            }


            referenceDataGridview.Columns.Add(new()
            {
                DataPropertyName = "FormattedTotal",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.TOTAL),
                Name = "Total",
                Visible = true,
                Width = 250,
                CellTemplate = new DataGridViewTextBoxCell()
            });

        }
        private void SetcolumnsAlignment(DataGridView grid)
        {
            for (int i = 1; i < grid.Columns.Count; i++)
            {
                grid.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grid.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            }


        }


        #endregion

        #region Data    
        private void LoadBagHistoryItems()
        {

            DateTime FechaAperturaDesde = FromFechaAperturaDateTimePicker.Value.Date;
            DateTime FechaAperturaHasta = ToFechaAperturaDateTimePicker.Value.Date;
            DateTime? FechaCierreDesde = FromFechaCierreDateTimePicker.Checked ?
                                        new DateTime(FromFechaCierreDateTimePicker.Value.Year, FromFechaCierreDateTimePicker.Value.Month, FromFechaCierreDateTimePicker.Value.Day, 0, 0, 0) : null;
            DateTime? FechaCierreHasta = ToFechaCierreDateTimePicker.Checked ?
                                        new DateTime(ToFechaCierreDateTimePicker.Value.Year, ToFechaCierreDateTimePicker.Value.Month, ToFechaCierreDateTimePicker.Value.Day, 23, 59, 59) : null;

            FechaAperturaHasta = FechaAperturaHasta.AddHours(23);
            FechaAperturaHasta = FechaAperturaHasta.AddMinutes(59);
            FechaAperturaHasta = FechaAperturaHasta.AddSeconds(59);

            _bagHistoryItems = DatabaseController.GetBagHistoryItems(FechaAperturaDesde,
                                                                    FechaAperturaHasta,
                                                                    FechaCierreDesde,
                                                                    FechaCierreHasta,
                                                                    IdentificadorTextbox.Text, false);
            MainGridView.DataSource = _bagHistoryItems;

        }
        #endregion
        private void InitializeLocals()
        {
            // inicializar las variables locales
            MainGridView.DataSource = null;
        }
        #region Datagrid   
        private void BagHistoryForm_VisibleChanged(object sender, EventArgs e)
        {
            _pollingTimer.Enabled = this.Visible;
            if (this.Visible)
            {
                InitializeMainGridView();
                LoadBagHistoryItems();
            }
            else
                InitializeLocals();
            FormsController.SetInformationMessage(InformationTypeEnum.None, string.Empty);

        }
        #endregion
        private void BagHistoryForm_MouseClick(object sender, MouseEventArgs e)
        {
            TimeOutController.Reset();
        }

        private void MainGridView_Click(object sender, EventArgs e)
        {
            TimeOutController.Reset();
        }

        private void FromFechaCierreDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            TimeOutController.Reset();
            if (!FromFechaCierreDateTimePicker.Checked)
            {
                FromFechaCierreDateTimePicker.Format = DateTimePickerFormat.Custom;
                FromFechaCierreDateTimePicker.CustomFormat = " ";
            }
            else
            {
                FromFechaCierreDateTimePicker.Format = DateTimePickerFormat.Short;
                FromFechaCierreDateTimePicker.CustomFormat = MultilanguangeController.GetText(MultiLanguageEnum.FORMATO_FECHA);
                if (ToFechaCierreDateTimePicker.Checked)
                    ToFechaCierreDateTimePicker.MinDate = FromFechaCierreDateTimePicker.Value;
                else
                {
                    ToFechaCierreDateTimePicker.Format = DateTimePickerFormat.Custom;
                    ToFechaCierreDateTimePicker.CustomFormat = " ";
                }
            }
        }

        private void ToFechaCierreDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            TimeOutController.Reset();
            if (!ToFechaCierreDateTimePicker.Checked)
            {
                ToFechaCierreDateTimePicker.Format = DateTimePickerFormat.Custom;
                ToFechaCierreDateTimePicker.CustomFormat = " ";
            }
            else
            {
                ToFechaCierreDateTimePicker.Format = DateTimePickerFormat.Short;
                ToFechaCierreDateTimePicker.CustomFormat = MultilanguangeController.GetText(MultiLanguageEnum.FORMATO_FECHA);
                if(FromFechaCierreDateTimePicker.Checked)
                {
                    FromFechaCierreDateTimePicker.MaxDate = ToFechaCierreDateTimePicker.Value;
                }

            }
        }

        private void ExecuteBagHistorySearch_Click(object sender, EventArgs e)
        {
            TimeOutController.Reset();
            LoadBagHistoryItems();
        }

        private void FromFechaAperturaDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            ToFechaAperturaDateTimePicker.MinDate = FromFechaAperturaDateTimePicker.Value;
            TimeOutController.Reset();
        }

        private void ToFechaAperturaDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            FromFechaAperturaDateTimePicker.MaxDate = ToFechaAperturaDateTimePicker.Value;
            TimeOutController.Reset();
        }

        private void IdentificadorTextbox_TextChanged(object sender, EventArgs e)
        {
            TimeOutController.Reset();
        }

        private void InitializeContainerHistoryDetaillGridView()
        {

        }

        private void MainGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TimeOutController.Reset();

            if (e.RowIndex > -1)
            {
                DetailPanel.Location = new Point(
                  this.ClientSize.Width / 2 - DetailPanel.Size.Width / 2,
                  this.ClientSize.Height / 2 - DetailPanel.Size.Height / 2);
                DetailPanel.Anchor = AnchorStyles.None;

                DetailPanel.Visible = true;

                InitializeGridView(OperationTypeEnum.BillDeposit);
                InitializeGridView(OperationTypeEnum.EnvelopeDeposit);

                SetcolumnsAlignment(BillDepositGridView);
                SetcolumnsAlignment(EnvelopeDepositGridView);

                InitializeContainerHistoryDetaillGridView();

                _currentContainerId = (long)MainGridView.Rows[e.RowIndex].Cells["Id"].Value;
                LoadBagContentItems(OperationTypeEnum.BillDeposit);
                LoadBagContentItems(OperationTypeEnum.EnvelopeDeposit);

            }
        }

        private void LoadBagContentItems(OperationTypeEnum operationType)
        {
            DataGridView referenceDataGridview = null;

            switch (operationType)
            {
                case OperationTypeEnum.None:
                    break;
                case OperationTypeEnum.BillDeposit:
                    referenceDataGridview = BillDepositGridView;
                    _bagContentResumeItems = DatabaseController.GetContainerResume(_currentContainerId,OperationTypeEnum.BillDeposit);
                    BillDepositGridView.DataSource = _bagContentResumeItems;
                    break;
                case OperationTypeEnum.CoinDeposit:
                    break;
                case OperationTypeEnum.EnvelopeDeposit:
                    referenceDataGridview = EnvelopeDepositGridView;
                    _bagContentItems = DatabaseController.GetContainerResume(_currentContainerId,OperationTypeEnum.EnvelopeDeposit);
                    EnvelopeDepositGridView.DataSource = _bagContentItems;
                    break;
                case OperationTypeEnum.ValueExtraction:
                    break;
                default:
                    break;
            }

            referenceDataGridview.ClearSelection();

        }

        private void PrintButton_Click(object sender, EventArgs e)
        {


            ReportController.ContainerToPrint = DatabaseController.GetContainer(_currentContainerId);
            ReportController.PrintReport(ReportTypeEnum.ValueExtraction,
            DatabaseController.GetEnvelopeContainerContentItems(_currentContainerId),
            DatabaseController.GetBillContainerContentItems(_currentContainerId),1);
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            DetailPanel.Visible = false;
        }

        private void BillDepositGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TimeOutController.Reset();
        }

        private void EnvelopeDepositGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TimeOutController.Reset();
        }

        private void BagContentTabControl_Click(object sender, EventArgs e)
        {
            TimeOutController.Reset();
        }
    }
}
