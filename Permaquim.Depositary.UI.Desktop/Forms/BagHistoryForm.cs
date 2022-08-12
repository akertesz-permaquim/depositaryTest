using Permaquim.Depositary.UI.Desktop.Builders;
using Permaquim.Depositary.UI.Desktop.Components;
using Permaquim.Depositary.UI.Desktop.Controllers;
using Permaquim.Depositary.UI.Desktop.Entities;
using Permaquim.Depositary.UI.Desktop.Global;
using static Permaquim.Depositary.UI.Desktop.Global.Enumerations;

namespace Permaquim.Depositary.UI.Desktop
{
    public partial class BagHistoryForm : Form
    {
        public CounterDevice _device { get; set; }
        private System.Windows.Forms.Timer _pollingTimer = new System.Windows.Forms.Timer();

        private List<Depositario.Entities.Views.Reporte.Contenedores> _bagHistoryItems = new();
        public BagHistoryForm()
        {
            InitializeComponent();
            CenterPanel();
            LoadStyles();
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

        private void BagHistoryForm_Load(object sender, EventArgs e)
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

            MainGridView.Location = new Point()
            {
                X = this.Width / 2 - MainGridView.Width / 2,
                Y = MainGridView.Location.Y
            };

        }
        private void LoadStyles()
        {
            this.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.FondoFormulario);

            StyleController.SetControlStyle(MainGridView);
        }
        #region BackButton
        private void LoadBackButton()
        {
            CustomButton backButton = ControlBuilder.BuildCancelButton(
                "BackButton", MultilanguangeController.GetText(MultiLanguageEnum.CANCEL_BUTTON), MainPanel.Width / 2 - 5, 55);

            this.MainPanel.Controls.Add(backButton);

            backButton.Click += new System.EventHandler(BackButton_Click);
        }
        private void BackButton_Click(object sender, EventArgs e)
        {
            FormsController.OpenChildForm(this, new OtherOperationsForm(), _device);
        }
        #endregion
        #region Datagrid        
        private void InitializeMainGridView()
        {
            MainGridView.AutoGenerateColumns = false;

            MainGridView.Columns.Clear();



            MainGridView.Columns.Add(new()
            {
                DataPropertyName = "Identificador",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.CODIGO),
                Name = "Identificador",
                Visible = true,
                Width = 260,
                CellTemplate = new DataGridViewTextBoxCell()

            });

            MainGridView.Columns.Add(new()
            {
                DataPropertyName = "FechaApertura",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.FECHA),
                Name = "FechaApertura",
                Visible = true,
                Width = 260,
                CellTemplate = new DataGridViewTextBoxCell()

            });

            MainGridView.Columns.Add(new()
            {
                DataPropertyName = "FechaCierre",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.FECHA),
                Name = "FechaCierre",
                Visible = true,
                Width = 260,
                CellTemplate = new DataGridViewTextBoxCell()

            });

            MainGridView.Columns.Add(new()
            {
                DataPropertyName = "Depositario",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.DEPOSITARIO),
                Name = "Depositario",
                Visible = true,
                Width = 260,
                CellTemplate = new DataGridViewTextBoxCell()

            });

            MainGridView.Columns.Add(new()
            {
                DataPropertyName = "CantidadTransacciones",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.CANTIDADOPERACIONES),
                Name = "CantidadTransacciones",
                Visible = true,
                Width = 260,
                CellTemplate = new DataGridViewTextBoxCell()

            });

            MainGridView.Columns.Add(new()
            {
                DataPropertyName = "CantidadBilletes",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.BILLETES),
                Name = "CantidadBilletes",
                Visible = true,
                Width = 260,
                CellTemplate = new DataGridViewTextBoxCell()

            });
            MainGridView.Columns.Add(new()
            {
                DataPropertyName = "CantidadSobres",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.SOBRES),
                Name = "CantidadSobres",
                Visible = true,
                Width = 260,
                CellTemplate = new DataGridViewTextBoxCell()

            });
            MainGridView.Columns.Add(new()
            {
                DataPropertyName = "CantidadTotalDineroMonedaDefault",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.CANTIDAD),
                Name = "CantidadTotalDineroMonedaDefault",
                Visible = true,
                Width = 260,
                CellTemplate = new DataGridViewTextBoxCell()

            });
        }

        #endregion
        #region Data    
        private void LoadBagHistoryItems()
        {
            _bagHistoryItems = DatabaseController.GetBaghistoryItems();
            MainGridView.DataSource = _bagHistoryItems;
            StyleController.SetControlHeight(MainGridView);
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
    }
}
