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
            FromFechaAperturaDateTimePicker.Value = DateTime.Now.Date;
            ToFechaAperturaDateTimePicker.Value = DateTime.Now.Date;
            FromFechaCierreDateTimePicker.Checked = false;
            FromFechaCierreDateTimePicker.CustomFormat = " ";
            ToFechaCierreDateTimePicker.Checked = false;
            ToFechaCierreDateTimePicker.CustomFormat = " ";
            IdentificadorTextbox.Text = "";

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

            DateTime FechaAperturaDesde = FromFechaAperturaDateTimePicker.Value.Date;
            DateTime FechaAperturaHasta = ToFechaAperturaDateTimePicker.Value.Date;
            DateTime? FechaCierreDesde = FromFechaCierreDateTimePicker.Checked ?
                                        new DateTime(FromFechaCierreDateTimePicker.Value.Year, FromFechaCierreDateTimePicker.Value.Month, FromFechaCierreDateTimePicker.Value.Day, 0, 0, 0) : null;
            DateTime? FechaCierreHasta = ToFechaCierreDateTimePicker.Checked ?
                                        new DateTime(ToFechaCierreDateTimePicker.Value.Year, ToFechaCierreDateTimePicker.Value.Month, ToFechaCierreDateTimePicker.Value.Day, 23, 59, 59) : null;

            FechaAperturaHasta = FechaAperturaHasta.AddHours(23);
            FechaAperturaHasta = FechaAperturaHasta.AddMinutes(59);
            FechaAperturaHasta = FechaAperturaHasta.AddSeconds(59);

            _bagHistoryItems = DatabaseController.GetBaghistoryItems(FechaAperturaDesde,
                                                                    FechaAperturaHasta,
                                                                    FechaCierreDesde,
                                                                    FechaCierreHasta,
                                                                    IdentificadorTextbox.Text);
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
                FromFechaCierreDateTimePicker.CustomFormat = "dd/MM/yyyy";
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
                ToFechaCierreDateTimePicker.CustomFormat = "dd/MM/yyyy";
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

        private void MainGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TimeOutController.Reset();
        }
    }
}
