﻿using Permaquim.Depositary.UI.Desktop.Builders;
using Permaquim.Depositary.UI.Desktop.Components;
using Permaquim.Depositary.UI.Desktop.Controllers;
using Permaquim.Depositary.UI.Desktop.Entities;
using Permaquim.Depositary.UI.Desktop.Global;
using static Permaquim.Depositary.UI.Desktop.Global.Enumerations;

namespace Permaquim.Depositary.UI.Desktop
{
    public partial class BagContentForm : Form
    {
        public Device _device { get; set; }

        private System.Windows.Forms.Timer _pollingTimer = new System.Windows.Forms.Timer();

        private List<BagContentItem> _bagContentItems = new();
        public BagContentForm()
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
        private void PollingTimer_Tick(object? sender, EventArgs e)
        {
            if (TimeOutController.IsTimeOut())
            {
                _pollingTimer.Enabled = false;
                DatabaseController.LogOff(true);
                FormsController.LogOff();
            }
        }
        private void BagContentForm_Load(object sender, EventArgs e)
        {
            _device = (Permaquim.Depositary.UI.Desktop.Components.Device)this.Tag;

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

            BagContentTabControl.TabPages[0].ForeColor = StyleController.GetColor(Enumerations.ColorNameEnum.FuentePrincipal);
            BagContentTabControl.TabPages[1].ForeColor = StyleController.GetColor(Enumerations.ColorNameEnum.FuentePrincipal);

        }


        private void LoadMultilanguageItems()
        {
            InformationLabel.Text = MultilanguangeController.GetText(MultiLanguageEnum.CONFIRMA_CIERRE_DIARIO);
            InformationLabel.ForeColor = StyleController.GetColor(Enumerations.ColorNameEnum.TextoInformacion);
            BagContentTabControl.TabPages[0].Text = MultilanguangeController.GetText(MultiLanguageEnum.BILLETES);
            BagContentTabControl.TabPages[1].Text = MultilanguangeController.GetText(MultiLanguageEnum.SOBRES);
        }
        #region BackButton
        private void LoadBackButton()
        {
            CustomButton backButton = ControlBuilder.BuildExitButton(
                "BackButton", MultilanguangeController.GetText(MultiLanguageEnum.CANCEL_BUTTON), MainPanel.Width);

            this.MainPanel.Controls.Add(backButton);

            backButton.Click += new System.EventHandler(BackButton_Click);
        }
        private void BackButton_Click(object sender, EventArgs e)
        {
            FormsController.OpenChildForm(this, new OtherOperationsForm(), _device);
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
                    _bagContentItems = DatabaseController.GetBillBagContentItems();
                    break;
                case OperationTypeEnum.CoinDeposit:
                    break;
                case OperationTypeEnum.EnvelopeDeposit:
                    referenceDataGridview = EnvelopeDepositGridView;
                    _bagContentItems = DatabaseController.GetEnvelopeBagContentItems();
                    break;
                case OperationTypeEnum.ValueExtraction:
                    break;
                default:
                    break;
            }

            

            _bagContentItems.Add(new BagContentItem()
            {
                Moneda = MultilanguangeController.GetText(MultiLanguageEnum.TOTAL),
                Cantidad = _bagContentItems.Sum(x => x.Cantidad)
            });

            referenceDataGridview.DataSource = _bagContentItems;

                if (referenceDataGridview.Rows.Count > 0)
                {
                    referenceDataGridview.Rows[referenceDataGridview.Rows.Count - 1].DefaultCellStyle.BackColor =
                        StyleController.GetColor(Enumerations.ColorNameEnum.PieGrilla);
                    referenceDataGridview.Rows[referenceDataGridview.Rows.Count - 1].DefaultCellStyle.ForeColor =
                        StyleController.GetColor(Enumerations.ColorNameEnum.FuenteContraste);
                    referenceDataGridview.Rows[referenceDataGridview.Rows.Count - 1].DefaultCellStyle.Font = new Font("Verdana", 16);


                for (int i = 0; i < referenceDataGridview.Columns.Count; i++)
                {
                    referenceDataGridview.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    referenceDataGridview.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }
            }

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
                DataPropertyName = "Moneda",
                HeaderText =  (operationType == OperationTypeEnum.BillDeposit 
                        ?  MultilanguangeController.GetText(MultiLanguageEnum.MONEDA)
                        : MultilanguangeController.GetText(MultiLanguageEnum.SOBRE)),
                Name = "Moneda",
                Visible = true,
                Width = 240,
                CellTemplate = new DataGridViewTextBoxCell()

            });

            if (operationType == OperationTypeEnum.BillDeposit)
            {
                referenceDataGridview.Columns.Add(new()
                {
                    DataPropertyName = "Denominacion",
                    HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.DENOMINACION),
                    Name = "Denominacion",
                    Visible = true,
                    Width = 150,
                    CellTemplate = new DataGridViewTextBoxCell()

                });
            }

            referenceDataGridview.Columns.Add(new()
            {
                DataPropertyName = "Cantidad",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.CANTIDAD),
                Name = "Cantidad",
                Visible = true,
                Width = 100,
                CellTemplate = new DataGridViewTextBoxCell()

            });

            referenceDataGridview.Columns.Add(new()
            {
                DataPropertyName = "Total",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.TOTAL),
                Name = "Total",
                
                Visible = true,
                Width = 180,
                CellTemplate = new DataGridViewTextBoxCell()

            });

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
        }

        private void EnvelopeDepositGridView_SelectionChanged(object sender, EventArgs e)
        {
            EnvelopeDepositGridView.ClearSelection();
        }
    }
}

