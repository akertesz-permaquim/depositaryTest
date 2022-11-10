using Permaquim.Depositary.UI.Desktop.Controllers;
using Permaquim.Depositary.UI.Desktop.Entities;
using Permaquim.Depositary.UI.Desktop.Global;
using System.ComponentModel;
using static Permaquim.Depositary.UI.Desktop.Global.Enumerations;
using static System.Net.Mime.MediaTypeNames;

namespace Permaquim.Depositary.UI.Desktop
{
    public partial class DailyClosingHistoryForm : Form
    {
        private const string NOMBREAPELLIDO = "NombreApellido";
        private const string NOMBRE = "Nombre";
        private const string ID = "Id";
        private const string TODOS = "Todos";
        private const string TEXT = "Text";
        private const string VALUE = "Value";
        private System.Windows.Forms.Timer _pollingTimer = new System.Windows.Forms.Timer();

        private long _dailyClosingId;

        private BindingList<DailyClosingHeader> _dailyClosingHeaders = new();


        public DailyClosingHistoryForm()
        {
            InitializeComponent();
            CenterPanel();
            LoadStyles();
            LoadMultilanguageItems();
            LoadFilterControls();
            InitializeDailyClosingHeaderGridView();

            FromDateTimePicker.Value = DateTime.Today.Date;

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

        private void CenterPanel()
        {

            DailyClosingHeaderGridView.Location = new Point()
            {
                X = DailyClosingHeaderGridView.Location.X,
                Y = DailyClosingHeaderGridView.Location.Y
            };

            DailyClosingDetailGridView.Location = new Point()
            {
                X = DailyClosingDetailGridView.Location.X,
                Y = DailyClosingDetailGridView.Location.Y
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

            ExecuteButton.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.BotonAceptar);
            ExecuteButton.BackgroundColor = StyleController.GetColor(Enumerations.ColorNameEnum.BotonAceptar);
            ExecuteButton.ForeColor = StyleController.GetColor(Enumerations.ColorNameEnum.FuenteContraste);
            ExecuteButton.TextColor = StyleController.GetColor(Enumerations.ColorNameEnum.FuenteContraste);

            BackButton.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.BotonSalir);
            AcceptButton.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.BotonAceptar);
            PrintButton.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.BotonAlternativo);

            StyleController.SetControlStyle(DailyClosingHeaderGridView);
            StyleController.SetControlStyle(DailyClosingDetailGridView);
        }

        private void LoadMultilanguageItems()
        {
            FromDateTimeLabel.Text = MultilanguangeController.GetText(MultiLanguageEnum.FECHA_DESDE);
            ToDateTimeLabel.Text = MultilanguangeController.GetText(MultiLanguageEnum.FECHA_HASTA);
            TurnLabel.Text = MultilanguangeController.GetText(MultiLanguageEnum.TURNO);
            UserLabel.Text = MultilanguangeController.GetText(MultiLanguageEnum.USUARIO);
            ExecuteButton.Text = MultilanguangeController.GetText(MultiLanguageEnum.EJECUTAR);
            BackButton.Text = MultilanguangeController.GetText(MultiLanguageEnum.VOLVER);
            AcceptButton.Text = MultilanguangeController.GetText(MultiLanguageEnum.BOTON_ACEPTAR_OPERACION);
            PrintButton.Text = MultilanguangeController.GetText(MultiLanguageEnum.IMPRIMIR);
        }
        private void BackButton_Click(object sender, EventArgs e)
        {
            ResetReport();
            FormsController.OpenChildForm(this, new ReportsForm(),
              (Permaquim.Depositary.UI.Desktop.Components.CounterDevice)this.Tag);
        }

        private void ResetReport()
        {
            FromDateTimePicker.Value = DateTime.Now.Date;
            ToDateTimePicker.Value = DateTime.Now.Date;
            FromDateTimePicker.Format = DateTimePickerFormat.Custom;
            FromDateTimePicker.CustomFormat = MultilanguangeController.GetText(MultiLanguageEnum.FORMATO_FECHA);

            ToDateTimePicker.Format = DateTimePickerFormat.Custom;
            ToDateTimePicker.CustomFormat = MultilanguangeController.GetText(MultiLanguageEnum.FORMATO_FECHA);

            UserComboBox.SelectedIndex = 0;
            TurnComboBox.SelectedIndex = 0;

            LoadDailyClosingHeader();
        }

        public void LoadFilterControls()
        {
            var userList = DatabaseController.GetUserList();

            userList.Insert(0, new Depositario.Entities.Tables.Seguridad.Usuario()
            {
                NombreApellido = TODOS,
                Id = -1
            });

            UserComboBox.DataSource = userList;

            UserComboBox.DisplayMember = NOMBREAPELLIDO;
            UserComboBox.ValueMember = ID;

            var turnList = DatabaseController.GetTurnList();

            List<TurnItemElement> turnItemList = new();

            turnItemList.Add(new TurnItemElement() { Value = -1, Text = "Todos" });

            foreach (var item in turnList)
            {
                turnItemList.Add(new TurnItemElement()
                { Value = item.TurnoEsquemaDetalleId, Text = item.Nombre });
            }

            TurnComboBox.DisplayMember = TEXT;
            TurnComboBox.ValueMember = VALUE;
            TurnComboBox.DataSource = turnItemList;
        }

        private void OperationHistoryForm_Load(object sender, EventArgs e)
        {

        }

        private void InitializeDailyClosingHeaderGridView()
        {
            DailyClosingHeaderGridView.AutoGenerateColumns = false;
            DailyClosingHeaderGridView.Columns.Clear();


            DailyClosingHeaderGridView.Columns.Add(new()
            {
                DataPropertyName = ID,
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.ID),
                Name = ID,
                Visible = false,
                Width = 100,
                CellTemplate = new DataGridViewTextBoxCell()

            });

            var col = DailyClosingHeaderGridView.Columns.Add(new()
            {
                DataPropertyName = "Fecha",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.FECHA),
                Name = "Fecha",
                Visible = true,
                Width = 150,
                CellTemplate = new DataGridViewTextBoxCell(),
                DefaultCellStyle = StyleController.GetDateColumnStyle()

            });

  
            DailyClosingHeaderGridView.Columns.Add(new()
            {
                DataPropertyName = "CodigoCierre",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.CIERREDIARIO),
                Name = "CodigoCierre",
                Visible = true,
                Width = 150,
                CellTemplate = new DataGridViewTextBoxCell()

            });


            DailyClosingHeaderGridView.Columns.Add(new()
            {
                DataPropertyName = "Usuario",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.USUARIO),
                Name = "Usuario",
                Visible = true,
                Width = 200,
                CellTemplate = new DataGridViewTextBoxCell()

            });

            DailyClosingHeaderGridView.Columns.Add(new()
            {
                DataPropertyName = "Moneda",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.MONEDA),
                Name = "Moneda",
                Visible = true,
                Width = 200,
                CellTemplate = new DataGridViewTextBoxCell()

            });

            DailyClosingHeaderGridView.Columns.Add(new()
            {
                DataPropertyName = "TotalValidado",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.TOTAL_VALIDADO),
                Name = "TotalValidado",
                Visible = true,
                Width = 200,
                CellTemplate = new DataGridViewTextBoxCell()

            });

            DailyClosingHeaderGridView.Columns.Add(new()
            {
                DataPropertyName = "TotalAValidar",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.TOTAL_A_VALIDAR),
                Name = "TotalAValidar",
                Visible = true,
                Width = 200,
                CellTemplate = new DataGridViewTextBoxCell()

            });

        }

        private void InitializeDailyClosingDetailGridView(OperationTypeEnum operationType)
        {
            DailyClosingHeaderGridView.AutoGenerateColumns = false;
            DailyClosingDetailGridView.Columns.Clear();

            DailyClosingDetailGridView.Columns.Add(new()
            {
                DataPropertyName = "Id",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.ID),
                Name = "Id",
                Visible = false,
                Width = 100,
                CellTemplate = new DataGridViewTextBoxCell()

            });

            DailyClosingDetailGridView.Columns.Add(new()
            {
                DataPropertyName = "Tipo",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.TIPO),
                Name = "Tipo",
                Visible = true,
                Width = 150,
                CellTemplate = new DataGridViewTextBoxCell()

            });

            DailyClosingDetailGridView.Columns.Add(new()
            {
                DataPropertyName = "Moneda",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.MONEDA),
                Name = "Moneda",
                Visible = true,
                Width = 150,
                CellTemplate = new DataGridViewTextBoxCell()

            });

            DailyClosingDetailGridView.Columns.Add(new()
            {
                DataPropertyName = "TotalValidado",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.TOTAL_VALIDADO),
                Name = "TotalValidado",
                Visible = true,
                Width = 100,
                CellTemplate = new DataGridViewTextBoxCell()

            });

            DailyClosingDetailGridView.Columns.Add(new()
            {
                DataPropertyName = "TotalAValidar",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.TOTAL_A_VALIDAR),
                Name = "TotalAValidar",
                Visible = true,
                Width = 100,
                CellTemplate = new DataGridViewTextBoxCell()

            });


            DailyClosingDetailGridView.Columns.Add(new()
            {
                DataPropertyName = "Fecha",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.FECHA),
                Name = "Fecha",
                Visible = true,
                Width = 150,
                CellTemplate = new DataGridViewTextBoxCell(),
                DefaultCellStyle = StyleController.GetDateColumnStyle()

            });


            DailyClosingDetailGridView.Columns.Add(new()
            {
                DataPropertyName = "Usuario",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.USUARIO),
                Name = "Usuario",
                Visible = true,
                Width = 200,
                CellTemplate = new DataGridViewTextBoxCell()

            });

            DailyClosingDetailGridView.Columns.Add(new()
            {
                DataPropertyName = "Contenedor",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.CONTENEDOR),
                Name = "Contenedor",
                Visible = true,
                Width = 150,
                CellTemplate = new DataGridViewTextBoxCell()

            });

            DailyClosingDetailGridView.Columns.Add(new()
            {
                DataPropertyName = "TipoId",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.TIPOID),
                Name = "TipoId",
                Visible = false,
                Width = 1,
                CellTemplate = new DataGridViewTextBoxCell()

            });

            DailyClosingDetailGridView.Columns.Add(new()
            {
                DataPropertyName = "UsuarioCuenta",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.USUARIOCUENTA),
                Name = "UsuarioCuenta",
                Visible = ParameterController.UsesBankAccount,
                Width = 150,
                CellTemplate = new DataGridViewTextBoxCell()

            });

            DailyClosingDetailGridView.Columns.Add(new()
            {
                DataPropertyName = "Turno",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.TURNO),
                Name = "Turno",
                Visible = true,
                Width = 150,
                CellTemplate = new DataGridViewTextBoxCell()

            });

            DailyClosingDetailGridView.Columns.Add(new()
            {
                DataPropertyName = "CierreDiario",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.CIERREDIARIO),
                Name = "CierreDiario",
                Visible = true,
                Width = 150,
                CellTemplate = new DataGridViewTextBoxCell()

            });

            DailyClosingDetailGridView.Columns.Add(new()
            {
                DataPropertyName = "Finalizada",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.FINALIZADA),
                Name = "Finalizada",
                Visible = true,
                Width = 100,
                CellTemplate = new DataGridViewCheckBoxCell()

            });
        }

        private void LoadDailyClosingHeader()
        {

            DailyClosingHeaderGridView.DataSource = null;
            DailyClosingDetailGridView.DataSource = null;

            InitializeDailyClosingHeaderGridView();

            DateTime FechaHasta = ToDateTimePicker.Value.Date;

            FechaHasta = FechaHasta.AddHours(23);
            FechaHasta = FechaHasta.AddMinutes(59);
            FechaHasta = FechaHasta.AddSeconds(59);

            var DailyClosing = DatabaseController.GetDailyClosingHeaders(
                FromDateTimePicker.Value,
                FechaHasta,
                (long)UserComboBox.SelectedValue
                );

            _dailyClosingHeaders.Clear();

            Permaquim.Depositario.Entities.Relations.Valor.Moneda DefaultCurrency = DatabaseController.DefaultCurrency();

            foreach (var item in DailyClosing)
            {
                _dailyClosingHeaders.Add(new DailyClosingHeader()
                {
                    Id = item.Id,
                    CodigoCierre = item.CodigoCierre + "-" + item.Id,
                    Fecha = item.Fecha,
                    Usuario = item.UsuarioCreacion.NombreApellido,
                    TotalValidado = item.ListOf_Transaccion_CierreDiarioId.Where(x => x._MonedaId == DefaultCurrency.Id).Sum(x => x.TotalValidado),
                    TotalAValidar = item.ListOf_Transaccion_CierreDiarioId.Where(x => x._MonedaId == DefaultCurrency.Id).Sum(x => x.TotalAValidar),
                    Moneda = DefaultCurrency.Nombre
                });
            }

            DailyClosingHeaderGridView.DataSource = _dailyClosingHeaders;

        }

        private void DailyClosingHeaderGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TimeOutController.Reset();
            DetailPanel.Location = new Point(
            this.ClientSize.Width / 2 - DetailPanel.Size.Width / 2,
            this.ClientSize.Height / 2 - DetailPanel.Size.Height / 2);
            DetailPanel.Anchor = AnchorStyles.None;

            DetailPanel.Visible = true;

            DailyClosingDetailGridView.DataSource = null;

            if (e.RowIndex > -1)
            {
                //InitializeDailyClosingDetailGridView();

                _dailyClosingId = (long)DailyClosingHeaderGridView.Rows[e.RowIndex].Cells["Id"].Value;

                var dailyClosingDetails = DatabaseController.GetDailyClosingDetails(_dailyClosingId);

                List<TransactionHeaderItem> operationDailyClosingDetails = new();

                foreach (var item in dailyClosingDetails)
                {
                    var esquemaDetalleTurno = item.TurnoId.TurnoDepositarioId.EsquemaDetalleTurnoId;
                    operationDailyClosingDetails.Add(new TransactionHeaderItem()
                    {
                        Cierrediario = item.CierreDiarioId != null ?
                            item.CierreDiarioId.Fecha.HasValue ? item.CierreDiarioId.Fecha.Value.ToString(MultilanguangeController.GetText(MultiLanguageEnum.FORMATO_FECHA)) : "" : String.Empty,
                        Contenedor = item.ContenedorId.Nombre +
                            (item.ContenedorId.Identificador.Length == 0 ? "" : " (" + item.ContenedorId.Identificador + " )"),
                        Fecha = item.Fecha,
                        Finalizada = item.Finalizada,
                        Id = item.Id,
                        Moneda = item.MonedaId.Nombre,
                        Tipo = item.TipoId.Nombre,
                        TipoId = item.TipoId.Id,
                        TotalAValidar = item.TotalAValidar,
                        TotalValidado = item.TotalValidado,
                        Turno = esquemaDetalleTurno.EsquemaTurnoId.Nombre + " - " + esquemaDetalleTurno.Nombre,
                        Usuario = item.UsuarioId.NombreApellido,
                        UsuarioCuenta = item.CuentaId == null ? null : item.CuentaId.Numero
                    }); ;
                }

                DailyClosingDetailGridView.DataSource = operationDailyClosingDetails;

            }
        }


        private List<DailyClosingItem> _dailyclosingItems = new();


        private void DailyClosingHeaderGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            System.Diagnostics.Debug.Print("");
        }

        private void DailyClosingHistoryform_VisibleChanged(object sender, EventArgs e)
        {
            _pollingTimer.Enabled = this.Visible;
            if (this.Visible)
            {
                LoadDailyClosingHeader();
            }
            else
            {
                InitializeLocals();
            }

            FormsController.SetInformationMessage(InformationTypeEnum.None, string.Empty);
        }
        private void InitializeLocals()
        {
            // inicializar variables locales
            DailyClosingHeaderGridView.DataSource = null;
            DailyClosingDetailGridView.DataSource = null;
        }
        private void DailyClosingDetailGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TimeOutController.Reset();
        }

        private void DailyClosingHistoryform_MouseClick(object sender, MouseEventArgs e)
        {
            TimeOutController.Reset();
        }

        private void ExecuteButton_Click(object sender, EventArgs e)
        {
            LoadDailyClosingHeader();
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            DetailPanel.Visible = false;
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {

            PrintTicket();
        }

        private void PrintTicket()
        {

            Depositario.Business.Relations.Operacion.CierreDiario cierreDiario = new();
            cierreDiario.Where.Add(Depositario.Business.Relations.Operacion.CierreDiario.ColumnEnum.Id, Depositario.sqlEnum.OperandEnum.Equal, _dailyClosingId);
            cierreDiario.Items();

            if (cierreDiario.Result.Count > 0)
            {
                ReportController.DailyClosingToPrint = cierreDiario.Result.FirstOrDefault();

                ReportController.PrintReport(ReportTypeEnum.DailyClosing,
                DatabaseController.GetDailyClosingEnvelopeBagContentItems(_dailyClosingId),
                DatabaseController.GetDailyClosingTransactions(_dailyClosingId), 1);
            }
        }

    }
}
