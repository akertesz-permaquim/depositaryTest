using Permaquim.Depositary.UI.Desktop.Controllers;
using Permaquim.Depositary.UI.Desktop.Entities;
using Permaquim.Depositary.UI.Desktop.Global;
using static Permaquim.Depositary.UI.Desktop.Global.Enumerations;

namespace Permaquim.Depositary.UI.Desktop
{
    public partial class TurnsHistoryForm : Form
    {
        private const string NICKNAME = "NickName";
        private const string NOMBRE = "Nombre";
        private const string ID = "Id";
        private const string TODOS = "Todos";
        private System.Windows.Forms.Timer _pollingTimer = new System.Windows.Forms.Timer();

        private bool _alreadyPrinted;

        private long _operationId;
        private long _operationTypeId;

        public TurnsHistoryForm()
        {
            InitializeComponent();
            CenterPanel();
            LoadStyles();
            LoadMultilanguageItems();
            LoadFilterControls();
            InitializeTurnsHeaderGridView();

            FromDateTimePicker.Value = DateTime.Now.AddDays(-30);

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
            ExecuteButton.BackgroundColor = StyleController.GetColor(Enumerations.ColorNameEnum.BotonAceptar);
            ExecuteButton.ForeColor = StyleController.GetColor(Enumerations.ColorNameEnum.FuenteContraste);
            ExecuteButton.TextColor = StyleController.GetColor(Enumerations.ColorNameEnum.FuenteContraste);

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
            FormsController.OpenChildForm(this, new ReportsForm(),
              (Permaquim.Depositary.UI.Desktop.Components.CounterDevice)this.Tag);
        }

        public void LoadFilterControls()
        {
            var userList = DatabaseController.GetUserList();

            userList.Insert(0, new Depositario.Entities.Tables.Seguridad.Usuario()
            {
                NickName = TODOS,
                Id = -1
            });

            UserComboBox.DataSource = userList;

            UserComboBox.DisplayMember = NICKNAME;
            UserComboBox.ValueMember = ID;

            var turnList = DatabaseController.GetTurnList();

            turnList.Insert(0, new Depositario.Entities.Tables.Turno.AgendaTurno()
            {
                Nombre = TODOS,
                Id = -1
            });

            TurnComboBox.DataSource = turnList;

            TurnComboBox.DisplayMember = NOMBRE;
            TurnComboBox.ValueMember = ID;
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
                DataPropertyName = ID,
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.ID),
                Name = ID,
                Visible = false,
                Width = 100,
                CellTemplate = new DataGridViewTextBoxCell()

            });

            TurnsHeaderGridView.Columns.Add(new()
            {
                DataPropertyName = "TotalValidado",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.TOTAL_VALIDADO),
                Name = "TotalValidado",
                Visible = true,
                Width = 100,
                CellTemplate = new DataGridViewTextBoxCell()

            });

            TurnsHeaderGridView.Columns.Add(new()
            {
                DataPropertyName = "TotalAValidar",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.TOTAL_A_VALIDAR),
                Name = "TotalAValidar",
                Visible = true,
                Width = 100,
                CellTemplate = new DataGridViewTextBoxCell()

            });


            TurnsHeaderGridView.Columns.Add(new()
            {
                DataPropertyName = "Fecha",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.FECHA),
                Name = "Fecha",
                Visible = true,
                Width = 150,
                CellTemplate = new DataGridViewTextBoxCell()

            });


            TurnsHeaderGridView.Columns.Add(new()
            {
                DataPropertyName = "Usuario",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.USUARIO),
                Name = "Usuario",
                Visible = true,
                Width = 200,
                CellTemplate = new DataGridViewTextBoxCell()

            });

            TurnsHeaderGridView.Columns.Add(new()
            {
                DataPropertyName = "Contenedor",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.CONTENEDOR),
                Name = "Contenedor",
                Visible = true,
                Width = 150,
                CellTemplate = new DataGridViewTextBoxCell()

            });

            TurnsHeaderGridView.Columns.Add(new()
            {
                DataPropertyName = "Tipo",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.TIPO),
                Name = "Tipo",
                Visible = true,
                Width = 150,
                CellTemplate = new DataGridViewTextBoxCell()

            });

            TurnsHeaderGridView.Columns.Add(new()
            {
                DataPropertyName = "Moneda",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.MONEDA),
                Name = "Moneda",
                Visible = true,
                Width = 150,
                CellTemplate = new DataGridViewTextBoxCell()

            });

            TurnsHeaderGridView.Columns.Add(new()
            {
                DataPropertyName = "TipoId",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.TIPOID),
                Name = "TipoId",
                Visible = false,
                Width = 1,
                CellTemplate = new DataGridViewTextBoxCell()

            });


            TurnsHeaderGridView.Columns.Add(new()
            {
                DataPropertyName = "UsuarioCuenta",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.USUARIOCUENTA),
                Name = "UsuarioCuenta",
                Visible = true,
                Width = 150,
                CellTemplate = new DataGridViewTextBoxCell()

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
                DataPropertyName = "CierreDiario",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.CIERREDIARIO),
                Name = "CierreDiario",
                Visible = true,
                Width = 150,
                CellTemplate = new DataGridViewTextBoxCell()

            });

            TurnsHeaderGridView.Columns.Add(new()
            {
                DataPropertyName = "Finalizada",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.FINALIZADA),
                Name = "Finalizada",
                Visible = true,
                Width = 100,
                CellTemplate = new DataGridViewCheckBoxCell()

            });
        }

        private void InitializeTurnsDetailGridView(OperationTypeEnum operationType)
        {
            TurnsHeaderGridView.AutoGenerateColumns = false;
            TurnsDetailGridView.Columns.Clear();

            if (operationType == OperationTypeEnum.BillDeposit)
            {
                TurnsDetailGridView.Columns.Add(new()
                {
                    DataPropertyName = ID,
                    HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.ID),
                    Name = ID,
                    Visible = false,
                    Width = 100,
                    CellTemplate = new DataGridViewTextBoxCell()

                });

                TurnsDetailGridView.Columns.Add(new()
                {
                    DataPropertyName = "Denominacion",
                    HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.DENOMINACION),
                    Name = "Denominacion",
                    Visible = true,
                    Width = 100,
                    CellTemplate = new DataGridViewTextBoxCell()

                });

                TurnsDetailGridView.Columns.Add(new()
                {
                    DataPropertyName = "CantidadUnidades",
                    HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.CANTIDADUNIDADES),
                    Name = "CantidadUnidades",
                    Visible = true,
                    Width = 100,
                    CellTemplate = new DataGridViewTextBoxCell()

                });
            }
            if (operationType == OperationTypeEnum.EnvelopeDeposit)
            {
                TurnsDetailGridView.Columns.Add(new()
                {
                    DataPropertyName = "Sobre",
                    HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.SOBRE),
                    Name = "Sobre",
                    Visible = true,
                    Width = 100,
                    CellTemplate = new DataGridViewTextBoxCell()

                });

                TurnsDetailGridView.Columns.Add(new()
                {
                    DataPropertyName = "TipoValor",
                    HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.TIPOVALOR),
                    Name = "TipoValor",
                    Visible = true,
                    Width = 100,
                    CellTemplate = new DataGridViewTextBoxCell()

                });

                TurnsDetailGridView.Columns.Add(new()
                {
                    DataPropertyName = "CantidadDeclarada",
                    HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.CANTIDADDECLARADA),
                    Name = "CantidadDeclarada",
                    Visible = true,
                    Width = 100,
                    CellTemplate = new DataGridViewTextBoxCell()

                });
            }

            TurnsDetailGridView.Columns.Add(new()
            {
                DataPropertyName = "Fecha",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.FECHA),
                Name = "Fecha",
                Visible = true,
                Width = 150,
                CellTemplate = new DataGridViewTextBoxCell()

            });
        }

        private void LoadTurnsHeader()
        {

            TurnsHeaderGridView.DataSource = null;
            TurnsDetailGridView.DataSource = null;
            InitializeTurnsHeaderGridView();

            var Turns = DatabaseController.GetTurnChangeHeaders(
                FromDateTimePicker.Value,
                ToDateTimePicker.Value,
                (long)UserComboBox.SelectedValue
                );

            _transactionHeaderItems.Clear();

            foreach (var item in Turns)
            {
                _transactionHeaderItems.Add(new TurnItem()
                {



                    //Cierrediario = item.CierreDiarioId.Nombre,
                    //Contenedor = item.ContenedorId.Identificador,
                    //Fecha = item.Fecha,
                    //Finalizada = item.Finalizada,
                    //Id = item.Id,
                    //Moneda = item.MonedaId.Nombre,
                    //Tipo = item.TipoId.Nombre,
                    //TipoId = item.TipoId.Id,
                    //TotalAValidar = item.TotalAValidar,
                    //TotalValidado = item.TotalValidado,
                    //Turno = item.TurnoId.ToString(),
                    //Usuario = item.UsuarioId.ToString(),
                    //UsuarioCuenta = item.UsuarioCuentaId.CuentaId.Numero
                });
            }

            TurnsHeaderGridView.DataSource = _transactionHeaderItems;


        }
        private void TurnsHeaderGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TimeOutController.Reset();

            DetailPanel.Visible = true;

            TurnsDetailGridView.DataSource = null;
            if (e.RowIndex > -1)
            {

                _operationId = (long)TurnsHeaderGridView.Rows[e.RowIndex].Cells[ID].Value;
                _operationTypeId = (long)TurnsHeaderGridView.Rows[e.RowIndex].Cells["TipoId"].Value;

                InitializeTurnsDetailGridView((OperationTypeEnum)_operationTypeId);

                //if ((OperationTypeEnum)_operationTypeId == OperationTypeEnum.)
                //{
                //var operationDetails = DatabaseController.GetTurnsDetails(_operationId);

                //_transactionDetailItems.Clear();

                //foreach (var item in operationDetails)
                //{
                //    _transactionDetailItems.Add(new TransactionDetailItem()
                //    {
                //        CantidadUnidades = item.CantidadUnidades,
                //        Denominacion = item.DenominacionId.Nombre,
                //        Fecha = item.Fecha,
                //        Id = item.Id
                //    });
                //}

                //TurnsDetailGridView.DataSource = _transactionDetailItems;


                //}

            }
        }


        private List<TurnItem> _transactionHeaderItems = new();
        private List<TransactionDetailItem> _transactionDetailItems = new();
        private List<TransactionEnvelopDetailItem> _transactionEnvelopeDetailItems = new();



        private void TurnsHeaderGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            System.Diagnostics.Debug.Print("");
        }

        private void TurnsHistoryform_VisibleChanged(object sender, EventArgs e)
        {
            _pollingTimer.Enabled = this.Visible;
            if (this.Visible)
            {
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
                if (!_alreadyPrinted)
                {
                    for (int i = 0; i < ParameterController.PrintTurnChangeQuantity; i++)
                    {
                        ReportController.PrintReport(ReportTypeEnum.TurnChange,
                            null, null);
                        _alreadyPrinted = true;
                    }
                }
            }
        }

    }
}
