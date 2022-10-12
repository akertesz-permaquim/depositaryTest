using Permaquim.Depositary.UI.Desktop.Builders;
using Permaquim.Depositary.UI.Desktop.Components;
using Permaquim.Depositary.UI.Desktop.Controllers;
using Permaquim.Depositary.UI.Desktop.Entities;
using Permaquim.Depositary.UI.Desktop.Global;
using static Permaquim.Depositary.UI.Desktop.Global.Enumerations;

namespace Permaquim.Depositary.UI.Desktop
{
    public partial class DailyClosingForm : Form
    {
        public CounterDevice _device { get; set; }
        private System.Windows.Forms.Timer _pollingTimer = new System.Windows.Forms.Timer();

        private List<DailyClosingItem> _dailyClosingItems = new();
        private Depositario.Entities.Tables.Operacion.CierreDiario _currentDailyclosing = new();

        public DailyClosingForm()
        {
            InitializeComponent();
            CenterPanel();
            LoadStyles();
            LoadDailyClosingButton();
            LoadBackButton();
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
            if (TimeOutController.IsTimeOut())
            {
                _pollingTimer.Enabled = false;
                DatabaseController.LogOff(true);
                FormsController.LogOff();
            }
        }
        private void DailyClosingForm_Load(object sender, EventArgs e)
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

            DenominationsGridView.Location = new Point()
            {
                X = this.Width / 2 - DenominationsGridView.Width / 2,
                Y = DenominationsGridView.Location.Y
            };

        }
        private void LoadStyles()
        {
            this.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.FondoFormulario);
            FormsController.SetInformationMessage(InformationTypeEnum.Information,
                MultilanguangeController.GetText(MultiLanguageEnum.CONFIRMA_CIERRE_DIARIO));

            StyleController.SetControlStyle(DenominationsGridView);
        }


        #region DailyClosingButton
        private void LoadDailyClosingButton()
        {
            CustomButton backButton = ControlBuilder.BuildStandardButton(
                "DailyClosingButton", MultilanguangeController.GetText(MultiLanguageEnum.BOTON_ACEPTAR_OPERACION), MainPanel.Width / 2 - 5, 55);

            this.MainPanel.Controls.Add(backButton);

            backButton.Click += new System.EventHandler(DailyClosingButton_Click);
        }
        private void DailyClosingButton_Click(object sender, EventArgs e)
        {
            _currentDailyclosing = DatabaseController.ClosePendingDays();
            PrintTicket();
            FormsController.OpenChildForm(this, new OtherOperationsForm(), _device);
        }
        #endregion

        #region BackButton
        private void LoadBackButton()
        {
            CustomButton backButton = ControlBuilder.BuildCancelButton(
                "BackButton", MultilanguangeController.GetText(MultiLanguageEnum.BOTON_CANCELAR_OPERACION), MainPanel.Width / 2 - 5, 55);

            this.MainPanel.Controls.Add(backButton);

            backButton.Click += new System.EventHandler(BackButton_Click);
        }
        private void BackButton_Click(object sender, EventArgs e)
        {
            FormsController.OpenChildForm(this, new OtherOperationsForm(), _device);
        }
        #endregion
        #region Data    
        private void LoadDailyClosingItems()
        {
            _dailyClosingItems = DatabaseController.GetDailyClosingItems();
            DenominationsGridView.DataSource = _dailyClosingItems;
            StyleController.SetControlHeight(DenominationsGridView);
        }
        #endregion

        #region Datagrid        
        private void InitializeDenominationsGridViewDetailGridView()
        {
            DenominationsGridView.AutoGenerateColumns = false;

            DenominationsGridView.Columns.Clear();

            DenominationsGridView.Columns.Add(new()
            {
                Visible = false,
                Width = 1,
                CellTemplate = new DataGridViewTextBoxCell()

            });

            DenominationsGridView.Columns.Add(new()
            {
                DataPropertyName = "Moneda",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.MONEDA),
                Name = "Moneda",
                Visible = true,
                Width = 260,
                CellTemplate = new DataGridViewTextBoxCell()

            });
            
 
            DenominationsGridView.Columns.Add(new()
            {
                DataPropertyName = "CantidadOperaciones",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.CANTIDADOPERACIONES),
                Name = "CantidadOperaciones",
                Visible = true,
                Width = 100,
                CellTemplate = new DataGridViewTextBoxCell()

            });

            DenominationsGridView.Columns.Add(new()
            {
                DataPropertyName = "TotalValidado",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.TOTAL_VALIDADO),
                Name = "TotalValidado",
                Visible = true,
                Width = 100,
                CellTemplate = new DataGridViewTextBoxCell()

            });

            DenominationsGridView.Columns.Add(new()
            {
                DataPropertyName = "TotalAValidar",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.TOTAL_A_VALIDAR),
                Name = "TotalAValidar",
                Visible = true,
                Width = 100,
                CellTemplate = new DataGridViewTextBoxCell()

            });
            DenominationsGridView.Columns.Add(new()
            {
                DataPropertyName = "Total",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.TOTAL),
                Name = "Total",
                Visible = true,
                Width = 100,
                CellTemplate = new DataGridViewTextBoxCell()

            }); 

        }
        #endregion

        private void DailyClosingForm_VisibleChanged(object sender, EventArgs e)
        {
            _pollingTimer.Enabled = this.Visible;
            if (this.Visible)
            {
                InitializeDenominationsGridViewDetailGridView();
                LoadDailyClosingItems();
            }
            else
                InitializeLocals();

            FormsController.SetInformationMessage(InformationTypeEnum.None, string.Empty);
        }
        private void InitializeLocals()
        {
            // inicializar las variables locales
            DenominationsGridView.DataSource = null;
        }

        private void DenominationsGridView_SelectionChanged(object sender, EventArgs e)
        {
            DenominationsGridView.ClearSelection();
        }

        private void DailyClosingForm_MouseClick(object sender, MouseEventArgs e)
        {
            TimeOutController.Reset();
        }
        private void PrintTicket()
        {

            if (ParameterController.PrintsDailyClosing)
            {
                for (int i = 0; i < ParameterController.PrintDailyClosingQuantity; i++)
                {
                    ReportController.PrintReport(ReportTypeEnum.DailyClosing, 
                        DatabaseController.LastDailyClosing, 
                        DatabaseController.GetDailyClosingDetail(DatabaseController.LastDailyClosing.Id), i);

                }
            }
        }
    }
}

