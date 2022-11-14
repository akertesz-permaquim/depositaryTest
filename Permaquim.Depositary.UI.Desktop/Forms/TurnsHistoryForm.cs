using Microsoft.Extensions.Primitives;
using Permaquim.Depositary.UI.Desktop.Controllers;
using Permaquim.Depositary.UI.Desktop.Entities;
using Permaquim.Depositary.UI.Desktop.Global;
using System.ComponentModel;
using static Permaquim.Depositary.UI.Desktop.Global.Enumerations;
using static System.Net.Mime.MediaTypeNames;

namespace Permaquim.Depositary.UI.Desktop
{
    public partial class TurnsHistoryForm : Form
    {
        private const string NOMBREAPELLIDO = "NombreApellido";
        private const string NOMBRE = "Nombre";
        private const string ID = "Id";
        private const string TODOS = "Todos";
        private const string TEXT = "Text";
        private const string VALUE = "Value";

        private System.Windows.Forms.Timer _pollingTimer = new System.Windows.Forms.Timer();

        private long _turnId;

        private BindingList<TurnItem> _turnItems = new();

        public TurnsHistoryForm()
        {
            InitializeComponent();
            CenterPanel();
            LoadStyles();
            LoadMultilanguageItems();
            LoadFilterControls();
            InitializeTurnsHeaderGridView();

            FromDateTimePicker.Value = DateTime.Today.Date;

            ResetReport();

            TimeOutController.Reset();
            _pollingTimer = new System.Windows.Forms.Timer()
            {
                Interval = DeviceController.GetPollingInterval()
            };
            _pollingTimer.Tick += PollingTimer_Tick;

            LoadTurnsHeader();
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

            TurnsHeaderGridView.Location = new Point()
            {
                X = TurnsHeaderGridView.Location.X,
                Y = TurnsHeaderGridView.Location.Y
            };

            TurnsDetailGridView.Location = new Point()
            {
                X = TurnsDetailGridView.Location.X,
                Y = TurnsDetailGridView.Location.Y
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
            ExecuteButton.ForeColor = StyleController.GetColor(Enumerations.ColorNameEnum.FuenteContraste);

            BackButton.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.BotonSalir);
            AcceptButton.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.BotonAceptar);
            PrintButton.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.BotonAlternativo);

            StyleController.SetControlStyle(TurnsHeaderGridView);
            StyleController.SetControlStyle(TurnsDetailGridView);
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

        private void InitializeTurnsHeaderGridView()
        {
            TurnsHeaderGridView.AutoGenerateColumns = false;
            TurnsHeaderGridView.Columns.Clear();

            TurnsHeaderGridView.Columns.Add(new()
            {
                DataPropertyName = "Id",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.ID),
                Name = "Id",
                Visible = false,
                Width = 100,
                CellTemplate = new DataGridViewTextBoxCell()

            });

            TurnsHeaderGridView.Columns.Add(new()
            {
                DataPropertyName = "Fecha",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.FECHA),
                Name = "Fecha",
                Visible = true,
                Width = 120,
                CellTemplate = new DataGridViewTextBoxCell(),
                DefaultCellStyle = StyleController.GetShortDateColumnStyle()

            });

            TurnsHeaderGridView.Columns.Add(new()
            {
                DataPropertyName = "Turno",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.TURNO),
                Name = "Turno",
                Visible = true,
                Width = 150,
                CellTemplate = new DataGridViewTextBoxCell()

            });

            TurnsHeaderGridView.Columns.Add(new()
            {
                DataPropertyName = "Secuencia",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.SECUENCIA),
                Name = "Secuencia",
                Visible = true,
                Width = 100,
                CellTemplate = new DataGridViewTextBoxCell()

            });

            TurnsHeaderGridView.Columns.Add(new()
            {
                DataPropertyName = "FechaApertura",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.FECHA_APERTURA),
                Name = "FechaApertura",
                Visible = true,
                Width = 150,
                CellTemplate = new DataGridViewTextBoxCell(),
                DefaultCellStyle = StyleController.GetFullDateColumnStyle()

            });


            TurnsHeaderGridView.Columns.Add(new()
            {
                DataPropertyName = "FechaCierre",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.FECHA_CIERRE),
                Name = "FechaCierre",
                Visible = true,
                Width = 150,
                CellTemplate = new DataGridViewTextBoxCell(),
                DefaultCellStyle = StyleController.GetFullDateColumnStyle()

            });

            TurnsHeaderGridView.Columns.Add(new()
            {
                DataPropertyName = "Usuario",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.USUARIO),
                Name = "Usuario",
                Visible = true,
                Width = 150,
                CellTemplate = new DataGridViewTextBoxCell()

            });

            TurnsHeaderGridView.Columns.Add(new()
            {
                DataPropertyName = "CantidadTransacciones",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.CANTIDADTRANSACCIONES),
                Name = "CantidadTransacciones",
                Visible = true,
                Width = 130,
                CellTemplate = new DataGridViewTextBoxCell()

            });

            TurnsHeaderGridView.Columns.Add(new()
            {
                DataPropertyName = "TotalValidado",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.TOTAL_VALIDADO),
                Name = "TotalValidado",
                Visible = true,
                Width = 130,
                CellTemplate = new DataGridViewTextBoxCell()

            });


            TurnsHeaderGridView.Columns.Add(new()
            {
                DataPropertyName = "TotalAValidar",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.TOTAL_A_VALIDAR),
                Name = "TotalAValidar",
                Visible = true,
                Width = 130,
                CellTemplate = new DataGridViewTextBoxCell()

            });

            TurnsHeaderGridView.Columns.Add(new()
            {
                DataPropertyName = "CierreDiario",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.CIERREDIARIO),
                Name = "CierreDiario",
                Visible = true,
                Width = 130,
                CellTemplate = new DataGridViewTextBoxCell()

            });
        }

        private void InitializeTurnsDetailGridView()
        {
            TurnsDetailGridView.AutoGenerateColumns = false;
            TurnsDetailGridView.Columns.Clear();

            TurnsDetailGridView.Columns.Add(new()
            {
                DataPropertyName = "Id",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.ID),
                Name = "Id",
                Visible = false,
                Width = 100,
                CellTemplate = new DataGridViewTextBoxCell()

            });

            TurnsDetailGridView.Columns.Add(new()
            {
                DataPropertyName = "Tipo",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.TIPO),
                Name = "Tipo",
                Visible = true,
                Width = 150,
                CellTemplate = new DataGridViewTextBoxCell()

            });

            TurnsDetailGridView.Columns.Add(new()
            {
                DataPropertyName = "Moneda",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.MONEDA),
                Name = "Moneda",
                Visible = true,
                Width = 150,
                CellTemplate = new DataGridViewTextBoxCell()

            });

            TurnsDetailGridView.Columns.Add(new()
            {
                DataPropertyName = "TotalValidado",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.TOTAL_VALIDADO),
                Name = "TotalValidado",
                Visible = true,
                Width = 100,
                CellTemplate = new DataGridViewTextBoxCell()

            });

            TurnsDetailGridView.Columns.Add(new()
            {
                DataPropertyName = "TotalAValidar",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.TOTAL_A_VALIDAR),
                Name = "TotalAValidar",
                Visible = true,
                Width = 100,
                CellTemplate = new DataGridViewTextBoxCell()

            });


            TurnsDetailGridView.Columns.Add(new()
            {
                DataPropertyName = "Fecha",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.FECHA),
                Name = "Fecha",
                Visible = true,
                Width = 150,
                CellTemplate = new DataGridViewTextBoxCell(),
                DefaultCellStyle = StyleController.GetFullDateColumnStyle()

            });


            TurnsDetailGridView.Columns.Add(new()
            {
                DataPropertyName = "Usuario",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.USUARIO),
                Name = "Usuario",
                Visible = true,
                Width = 200,
                CellTemplate = new DataGridViewTextBoxCell()

            });

            TurnsDetailGridView.Columns.Add(new()
            {
                DataPropertyName = "Contenedor",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.CONTENEDOR),
                Name = "Contenedor",
                Visible = true,
                Width = 150,
                CellTemplate = new DataGridViewTextBoxCell()

            });

            TurnsDetailGridView.Columns.Add(new()
            {
                DataPropertyName = "TipoId",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.TIPOID),
                Name = "TipoId",
                Visible = false,
                Width = 1,
                CellTemplate = new DataGridViewTextBoxCell()

            });
            if (ParameterController.UsesBankAccount)
            {
                TurnsDetailGridView.Columns.Add(new()
                {
                    DataPropertyName = "UsuarioCuenta",
                    HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.USUARIOCUENTA),
                    Name = "UsuarioCuenta",
                    Visible = ParameterController.UsesBankAccount,
                    Width = 150,
                    CellTemplate = new DataGridViewTextBoxCell()

                });
            }

            TurnsDetailGridView.Columns.Add(new()
            {
                DataPropertyName = "Turno",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.TURNO),
                Name = "Turno",
                Visible = true,
                Width = 150,
                CellTemplate = new DataGridViewTextBoxCell()

            });

            TurnsDetailGridView.Columns.Add(new()
            {
                DataPropertyName = "CierreDiario",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.CIERREDIARIO),
                Name = "CierreDiario",
                Visible = true,
                Width = 150,
                CellTemplate = new DataGridViewTextBoxCell()

            });

            TurnsDetailGridView.Columns.Add(new()
            {
                DataPropertyName = "Finalizada",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.FINALIZADA),
                Name = "Finalizada",
                Visible = true,
                Width = 100,
                CellTemplate = new DataGridViewCheckBoxCell()

            });

        }

        private void LoadTurnsHeader()
        {
            TurnsHeaderGridView.DataSource = null;
            TurnsDetailGridView.DataSource = null;
            InitializeTurnsHeaderGridView();

            DateTime FechaHasta = ToDateTimePicker.Value.Date;

            FechaHasta = FechaHasta.AddHours(23);
            FechaHasta = FechaHasta.AddMinutes(59);
            FechaHasta = FechaHasta.AddSeconds(59);

            var Turns = DatabaseController.GetTurnChangeHeaders(
                FromDateTimePicker.Value,
                FechaHasta,
                (long)UserComboBox.SelectedValue,
                (long)TurnComboBox.SelectedValue
                );

            _turnItems.Clear();

            Int64 DefaultCurrency = DatabaseController.DefaultCurrency().Id;

            foreach (var item in Turns)
            {
                var esquemaDetalleTurno = item.TurnoDepositarioId.EsquemaDetalleTurnoId;
                var transacciones = item.ListOf_Transaccion_TurnoId;
                _turnItems.Add(new TurnItem()
                {
                    Id = item.Id,
                    Fecha = item.Fecha,
                    FechaApertura = item.FechaApertura,
                    Usuario = item.UsuarioCreacion.NombreApellido,
                    Turno = esquemaDetalleTurno.EsquemaTurnoId.Nombre + " - " + esquemaDetalleTurno.Nombre,
                    TotalAValidar = transacciones.Where(x => x._MonedaId == DefaultCurrency).Sum(x => x.TotalAValidar),
                    TotalValidado = transacciones.Where(x => x._MonedaId == DefaultCurrency).Sum(x => x.TotalValidado),
                    CierreDiario = item.CierreDiarioId == null? string.Empty : item.CierreDiarioId.CodigoCierre + "-" + item._CierreDiarioId,
                    FechaCierre = item.FechaCierre,
                    CantidadTransacciones = transacciones.Count(),
                    Secuencia = item.Secuencia,
                });
            }

            TurnsHeaderGridView.DataSource = _turnItems;


        }
        private void TurnsHeaderGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TimeOutController.Reset();

            DetailPanel.Visible = true;

            TurnsDetailGridView.DataSource = null;

            if (e.RowIndex > -1)
            {

                if (e.RowIndex > -1)
                {
                    DetailPanel.Location = new Point(
                    this.ClientSize.Width / 2 - DetailPanel.Size.Width / 2,
                    this.ClientSize.Height / 2 - DetailPanel.Size.Height / 2);
                    DetailPanel.Anchor = AnchorStyles.None;

                    DetailPanel.Visible = true;

                    InitializeTurnsDetailGridView();

                    _turnId = (long)TurnsHeaderGridView.Rows[e.RowIndex].Cells["Id"].Value;

                    var turnDetails = DatabaseController.GetTurnsDetails(_turnId);

                    List<TransactionHeaderItem> operationTurnDetails = new();

                    foreach (var item in turnDetails)
                    {
                        var esquemaDetalleTurno = item.TurnoId.TurnoDepositarioId.EsquemaDetalleTurnoId;
                        operationTurnDetails.Add(new TransactionHeaderItem()
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

                    TurnsDetailGridView.DataSource = operationTurnDetails;

                }

            }
        }

        private void TurnsHeaderGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            System.Diagnostics.Debug.Print("");
        }

        private void TurnsHistoryform_VisibleChanged(object sender, EventArgs e)
        {
            _pollingTimer.Enabled = this.Visible;
            if (this.Visible)
            {
                FormsController.SetInformationMessage(InformationTypeEnum.None, String.Empty);
                LoadTurnsHeader();
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
            TurnsHeaderGridView.DataSource = null;
            TurnsDetailGridView.DataSource = null;
        }
        private void TurnsDetailGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TimeOutController.Reset();
        }

        private void TurnsHistoryform_MouseClick(object sender, MouseEventArgs e)
        {
            TimeOutController.Reset();
        }

        private void ExecuteButton_Click(object sender, EventArgs e)
        {
            LoadTurnsHeader();
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
            if (ParameterController.PrintsTurnChange)
            {
                Depositario.Business.Relations.Operacion.Turno turno = new();
                turno.Where.Add(Depositario.Business.Relations.Operacion.Turno.ColumnEnum.Id, Depositario.sqlEnum.OperandEnum.Equal, _turnId);
                turno.Items();

                if (turno.Result.Count > 0)
                {
                    ReportController.TurnToPrint = turno.Result.FirstOrDefault();

                    ReportController.PrintReport(ReportTypeEnum.TurnChange,
                        DatabaseController.GetTurnEnvelopeBagContentItems(_turnId), DatabaseController.GetTurnTransactions(_turnId), 1);
                }
            }
        }

        private void FromDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            ToDateTimePicker.MinDate = FromDateTimePicker.Value;
            TimeOutController.Reset();
        }

        private void ToDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            FromDateTimePicker.MaxDate = ToDateTimePicker.Value;
            TimeOutController.Reset();
        }

        private void FilterPanel_Click(object sender, EventArgs e)
        {
            TimeOutController.Reset();
        }

        private void TurnsHistoryForm_Click(object sender, EventArgs e)
        {
            TimeOutController.Reset();
        }

        private void FromDateTimePicker_MouseDown(object sender, MouseEventArgs e)
        {
            TimeOutController.Reset();
        }

        private void ToDateTimePicker_MouseDown(object sender, MouseEventArgs e)
        {
            TimeOutController.Reset();
        }

        private void TurnComboBox_Click(object sender, EventArgs e)
        {
            TimeOutController.Reset();
        }

        private void UserComboBox_Click(object sender, EventArgs e)
        {
            TimeOutController.Reset();
        }
    }
}
