using Permaquim.Depositary.UI.Desktop.Builders;
using Permaquim.Depositary.UI.Desktop.Components;
using Permaquim.Depositary.UI.Desktop.Controllers;
using Permaquim.Depositary.UI.Desktop.Entities;
using Permaquim.Depositary.UI.Desktop.Global;
using static Permaquim.Depositary.UI.Desktop.Global.Enumerations;

namespace Permaquim.Depositary.UI.Desktop
{
    public partial class BagContentForm : Form
    {
        public CounterDevice _device { get; set; }

        private const int BILLS = 0;
        private const int ENVELOPES = 1;
        private System.Windows.Forms.Timer _pollingTimer = new System.Windows.Forms.Timer();

        private List<BagBillContentResume> _bagContentItems = new();
        private List<BagBillContentResume> _bagContentResumeItems = new();
        public BagContentForm()
        {
            try
            {

                InitializeComponent();
                CenterPanel();
                LoadStyles();
                LoadMultilanguageItems();
                LoadBackButton();

                TimeOutController.Reset();
                _pollingTimer = new System.Windows.Forms.Timer()
                {
                    Interval = DeviceController.GetPollingInterval()
                };
                _pollingTimer.Tick += PollingTimer_Tick;
            }
            catch (Exception ex)
            {
                AuditController.Log(ex);
            }
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
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams CP = base.CreateParams;
                CP.ExStyle = CP.ExStyle | 0x02000000; // WS_EX_COMPOSITED
                return CP;
            }
        }
        private void BagContentForm_Load(object sender, EventArgs e)
        {
            _device = (Permaquim.Depositary.UI.Desktop.Components.CounterDevice)this.Tag;

        }
        private void CenterPanel()
        {

            MainPanel.Location = new Point()
            {
                X = this.Width / 2 - MainPanel.Width / 2,
                Y = MainPanel.Location.Y
            };

 
            BagContentTabControl.Location = new Point()
            {
                X = this.Width / 2 - BagContentTabControl.Width / 2,
                Y = BagContentTabControl.Location.Y
            };
        }
        private void LoadStyles()
        {
            this.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.FondoFormulario);

            StyleController.SetControlStyle(BillDepositGridView);
            StyleController.SetControlStyle(EnvelopeDepositGridView);
            StyleController.SetControlStyle(DetailGridView);

            BagContentTabControl.TabPages[BILLS].ForeColor = StyleController.GetColor(Enumerations.ColorNameEnum.FuentePrincipal);
            BagContentTabControl.TabPages[ENVELOPES].ForeColor = StyleController.GetColor(Enumerations.ColorNameEnum.FuentePrincipal);

            AcceptButton.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.BotonAceptar);

        }


        private void LoadMultilanguageItems()
        {
            BagContentTabControl.TabPages[BILLS].Text = MultilanguangeController.GetText(MultiLanguageEnum.BILLETES);
            BagContentTabControl.TabPages[ENVELOPES].Text = MultilanguangeController.GetText(MultiLanguageEnum.SOBRES);
            AcceptButton.Text = MultilanguangeController.GetText(MultiLanguageEnum.BOTON_ACEPTAR_OPERACION);
        }
        #region BackButton
        private void LoadBackButton()
        {
            CustomButton backButton = ControlBuilder.BuildExitButton(
                "BackButton", MultilanguangeController.GetText(MultiLanguageEnum.VOLVER), MainPanel.Width);

            this.MainPanel.Controls.Add(backButton);

            backButton.Click += new System.EventHandler(BackButton_Click);
        }
        private void BackButton_Click(object sender, EventArgs e)
        {
            FormsController.OpenChildForm(this, new ReportsForm(), _device);
        }
        #endregion
        #region Data    
        private void LoadBagContentItems(OperationTypeEnum operationType)
        {
            DataGridView referenceDataGridview = null;

            switch (operationType)
            {
                case OperationTypeEnum.None:
                    break;
                case OperationTypeEnum.BillDeposit:
                    referenceDataGridview = BillDepositGridView;
                    _bagContentResumeItems = DatabaseController.GetCurrentContainerResume(OperationTypeEnum.BillDeposit);
                    BillDepositGridView.DataSource = _bagContentResumeItems;
                    break;
                case OperationTypeEnum.CoinDeposit:
                    break;
                case OperationTypeEnum.EnvelopeDeposit:
                    referenceDataGridview = EnvelopeDepositGridView;
                    //_bagContentItems = DatabaseController.GetEnvelopeBagContentItems();
                    _bagContentItems = DatabaseController.GetCurrentContainerResume(OperationTypeEnum.EnvelopeDeposit);
                    EnvelopeDepositGridView.DataSource = _bagContentItems;
                    break;
                case OperationTypeEnum.ValueExtraction:
                    break;
                default:
                    break;
            }

            //_bagContentItems.Add(new BagContentItem()
            //{
            //    Moneda = MultilanguangeController.GetText(MultiLanguageEnum.TOTAL),
            //    Cantidad = _bagContentItems.Sum(x => x.Cantidad)
            //});

            //referenceDataGridview.DataSource = _bagContentResumeItems; //_bagContentItems;

            //if (referenceDataGridview.Rows.Count > 0)
            //{
            //    referenceDataGridview.Rows[referenceDataGridview.Rows.Count - 1].DefaultCellStyle.BackColor =
            //        StyleController.GetColor(Enumerations.ColorNameEnum.PieGrilla);
            //    referenceDataGridview.Rows[referenceDataGridview.Rows.Count - 1].DefaultCellStyle.ForeColor =
            //        StyleController.GetColor(Enumerations.ColorNameEnum.FuenteContraste);
            //    referenceDataGridview.Rows[referenceDataGridview.Rows.Count - 1].DefaultCellStyle.Font = new Font("Verdana", 16);
            //}

            //for (int i = 0; i < referenceDataGridview.Columns.Count; i++)
            //{
            //    referenceDataGridview.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //    referenceDataGridview.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //}

            referenceDataGridview.ClearSelection();
        }
        #endregion

        #region Datagrid        
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
                HeaderText =  (operationType == OperationTypeEnum.BillDeposit 
                        ?  MultilanguangeController.GetText(MultiLanguageEnum.MONEDA)
                        : MultilanguangeController.GetText(MultiLanguageEnum.SOBRE)),
                Name = "Moneda",
                Visible = true,
                Width = 240,
                CellTemplate = new DataGridViewTextBoxCell()
                

            });

            referenceDataGridview.Columns.Add(new()
            {
                DataPropertyName = "FormattedTotal",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.TOTAL),
                Name = "Total",
                   Visible = true,
                Width = 180,
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

        private void BagContentForm_VisibleChanged(object sender, EventArgs e)
        {
            _pollingTimer.Enabled = this.Visible;
            if (this.Visible)
            {
                InitializeGridView(OperationTypeEnum.BillDeposit);
                InitializeGridView(OperationTypeEnum.EnvelopeDeposit);

                LoadBagContentItems(OperationTypeEnum.BillDeposit);
                LoadBagContentItems(OperationTypeEnum.EnvelopeDeposit);
            }
            else
                InitializeLocals();

            SetcolumnsAlignment(BillDepositGridView);
            SetcolumnsAlignment(EnvelopeDepositGridView);
            SetcolumnsAlignment(DetailGridView);

            FormsController.SetInformationMessage(InformationTypeEnum.None, string.Empty);
        }
        private void InitializeLocals()
        {
            // inicializar las variables locales
            BillDepositGridView.DataSource = null;
            EnvelopeDepositGridView.DataSource = null;

        }

        private void BillDepositGridView_SelectionChanged(object sender, EventArgs e)
        {
            BillDepositGridView.ClearSelection();
            TimeOutController.Reset();
        }

        private void EnvelopeDepositGridView_SelectionChanged(object sender, EventArgs e)
        {
            EnvelopeDepositGridView.ClearSelection();
            TimeOutController.Reset();
        }

        private void BagContentForm_MouseClick(object sender, MouseEventArgs e)
        {
            TimeOutController.Reset();
        }

        private void BagContentTabControl_TabIndexChanged(object sender, EventArgs e)
        {
            TimeOutController.Reset();
        }

        private void BillDepositGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            InitializeDetailGridview(OperationTypeEnum.BillDeposit);

            if (e.RowIndex > -1)
            {
                DetailLabel.Text = BillDepositGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                var currencyId = BillDepositGridView.Rows[e.RowIndex].Cells[1].Value;
                DetailGridView.DataSource = DatabaseController.GetBillBagContentItems((long)currencyId);


                DetailPanel.Location = new Point(
                    this.ClientSize.Width / 2 - DetailPanel.Size.Width / 2,
                    this.ClientSize.Height / 2 - DetailPanel.Size.Height / 2);
                DetailPanel.Anchor = AnchorStyles.None;

                DetailPanel.Visible = true;
            }
        }

        private void InitializeDetailGridview(OperationTypeEnum operationType)
        {
            DetailGridView.AutoGenerateColumns = false;
            DetailGridView.Columns.Clear();

            if (operationType == OperationTypeEnum.BillDeposit)
            {
                DetailGridView.Columns.Add(new()
                {
                    DataPropertyName = "Denominacion",
                    HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.DENOMINACION),
                    Name = "Denominacion",
                    Visible = true,
                    Width = 240,
                    CellTemplate = new DataGridViewTextBoxCell()

                });

                DetailGridView.Columns.Add(new()
                {
                    DataPropertyName = "Cantidad",
                    HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.CANTIDAD),
                    Name = "Cantidad",
                    Visible = true,
                    Width = 150,
                    CellTemplate = new DataGridViewTextBoxCell()

                });

                DetailGridView.Columns.Add(new()
                {
                    DataPropertyName = "FormattedTotal",
                    HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.TOTAL),
                    Name = "Total",

                    Visible = true,
                    Width = 180,
                    CellTemplate = new DataGridViewTextBoxCell()
                });
            }
            if(operationType == OperationTypeEnum.EnvelopeDeposit)
            {
                DetailGridView.Columns.Add(new()
                {
                    DataPropertyName = "Moneda",
                    HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.SOBRE),
                    Name = "Denominacion",
                    Visible = true,
                    Width = 150,
                    CellTemplate = new DataGridViewTextBoxCell()

                });

                DetailGridView.Columns.Add(new()
                {
                    DataPropertyName = "Cantidad",
                    HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.CANTIDADDECLARADA),
                    Name = "Denominacion",
                    Visible = true,
                    Width = 150,
                    CellTemplate = new DataGridViewTextBoxCell()

                });

                DetailGridView.Columns.Add(new()
                {
                    DataPropertyName = "Denominacion",
                    HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.DENOMINACION),
                    Name = "Denominacion",
                    Visible = true,
                    Width = 240,
                    CellTemplate = new DataGridViewTextBoxCell()

                });
            }
                    
        }

        private void EnvelopeDepositGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            InitializeDetailGridview(OperationTypeEnum.EnvelopeDeposit);

            if (e.RowIndex > -1)
            {
                DetailLabel.Text = BillDepositGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                var currencyId = BillDepositGridView.Rows[e.RowIndex].Cells[1].Value;
                DetailGridView.DataSource = DatabaseController.GetEnvelopeBagContentItems();
                DetailPanel.Location = new Point(
       this.ClientSize.Width / 2 - DetailPanel.Size.Width / 2,
       this.ClientSize.Height / 2 - DetailPanel.Size.Height / 2);
                DetailPanel.Anchor = AnchorStyles.None;
                DetailPanel.Visible = true;
            }
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            DetailPanel.Visible = false;
        }

    }
}

