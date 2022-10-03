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
            LoadMultilanguageItems();
            LoadBackButton();

            FromFechaAperturaDateTimePicker.Value = DateTime.Now.Date;
            ToFechaAperturaDateTimePicker.Value = DateTime.Now.Date;
            FromFechaCierreDateTimePicker.Checked = false;
            FromFechaCierreDateTimePicker.CustomFormat = " ";
            ToFechaCierreDateTimePicker.Checked = false;
            ToFechaCierreDateTimePicker.CustomFormat = " ";

            TimeOutController.Reset();

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

        private void LoadMultilanguageItems()
        {
            FromFechaAperturaDateTimeLabel.Text = MultilanguangeController.GetText(MultiLanguageEnum.FECHA_APERTURA_DESDE);
            ToFechaAperturaDateTimeLabel.Text = MultilanguangeController.GetText(MultiLanguageEnum.FECHA_APERTURA_HASTA);
            FromFechaCierreDateTimeLabel.Text = MultilanguangeController.GetText(MultiLanguageEnum.FECHA_CIERRE_DESDE);
            ToFechaCierreDateTimeLabel.Text = MultilanguangeController.GetText(MultiLanguageEnum.FECHA_CIERRE_HASTA);
            IdentificadorLabel.Text = MultilanguangeController.GetText(MultiLanguageEnum.IDENTIFICADOR);
            ExecuteBagHistorySearch.Text = MultilanguangeController.GetText(MultiLanguageEnum.EJECUTAR);
        }
        #region BackButton
        private void LoadBackButton()
        {
            CustomButton backButton = ControlBuilder.BuildExitButton(
                "BackButton", MultilanguangeController.GetText(MultiLanguageEnum.VOLVER), MainPanel.Width - 3);

            this.MainPanel.Controls.Add(backButton);

            backButton.Click += new System.EventHandler(BackButton_Click);
        }
        private void BackButton_Click(object sender, EventArgs e)
        {
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
                CellTemplate = new DataGridViewTextBoxCell()

            });

            MainGridView.Columns.Add(new()
            {
                DataPropertyName = "FechaCierre",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.FECHA_CIERRE),
                Name = "FechaCierre",
                Visible = true,
                Width = 150,
                CellTemplate = new DataGridViewTextBoxCell()

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
        #region Data    
        private void LoadBagHistoryItems()
        {

            DateTime FechaAperturaDesde = FromFechaAperturaDateTimePicker.Value;
            DateTime FechaAperturaHasta = ToFechaAperturaDateTimePicker.Value;
            DateTime? FechaCierreDesde = FromFechaCierreDateTimePicker.Checked ? FromFechaCierreDateTimePicker.Value : null;
            DateTime? FechaCierreHasta = ToFechaCierreDateTimePicker.Checked ? ToFechaCierreDateTimePicker.Value : null;

            FechaAperturaHasta = FechaAperturaHasta.AddHours(23);
            FechaAperturaHasta = FechaAperturaHasta.AddMinutes(59);
            FechaAperturaHasta = FechaAperturaHasta.AddSeconds(59);

            if (FechaCierreHasta.HasValue)
            {
                FechaCierreHasta = FechaCierreHasta.Value.AddHours(23);
                FechaCierreHasta = FechaCierreHasta.Value.AddMinutes(59);
                FechaCierreHasta = FechaCierreHasta.Value.AddSeconds(59);
            }

            _bagHistoryItems = DatabaseController.GetBaghistoryItems(FechaAperturaDesde,
                                                                    FechaAperturaHasta,
                                                                    FechaCierreDesde,
                                                                    FechaCierreHasta,
                                                                    IdentificadorTextbox.Text);
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
                FromFechaCierreDateTimePicker.CustomFormat = "dd/MM/yyyy";
                ToFechaCierreDateTimePicker.MinDate = FromFechaCierreDateTimePicker.Value;
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
                ToFechaCierreDateTimePicker.CustomFormat = "dd/MM/yyyy";
                FromFechaCierreDateTimePicker.MaxDate = ToFechaCierreDateTimePicker.Value;
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
    }
}
