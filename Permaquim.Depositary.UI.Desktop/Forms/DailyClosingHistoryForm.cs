using Permaquim.Depositary.UI.Desktop.Controllers;
using Permaquim.Depositary.UI.Desktop.Entities;
using Permaquim.Depositary.UI.Desktop.Global;
using static Permaquim.Depositary.UI.Desktop.Global.Enumerations;

namespace Permaquim.Depositary.UI.Desktop
{
    public partial class DailyClosingHistoryForm : Form
    {
        private const string NICKNAME = "NickName";
        private const string NOMBRE = "Nombre";
        private const string ID = "Id";
        private const string TODOS = "Todos";
        private System.Windows.Forms.Timer _pollingTimer = new System.Windows.Forms.Timer();

        private bool _alreadyPrinted;

        private long _operationId;
        private long _operationTypeId;

        public DailyClosingHistoryForm()
        {
            InitializeComponent();
            CenterPanel();
            LoadStyles();
            LoadMultilanguageItems();
            LoadFilterControls();
            InitializeDailyClosingHeaderGridView();

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
            FormsController.OpenChildForm(this,new ReportsForm(),
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
                Nombre  = TODOS,
                Id = -1
            });

            TurnComboBox.DataSource = turnList;

            TurnComboBox.DisplayMember = NOMBRE;
            TurnComboBox.ValueMember = ID;
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

            DailyClosingHeaderGridView.Columns.Add(new()
            {
                DataPropertyName = "TotalValidado",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.TOTAL_VALIDADO),
                Name = "TotalValidado",
                Visible = true,
                Width = 100,
                CellTemplate = new DataGridViewTextBoxCell()

            });

            DailyClosingHeaderGridView.Columns.Add(new()
            {
                DataPropertyName = "TotalAValidar",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.TOTAL_A_VALIDAR),
                Name = "TotalAValidar",
                Visible = true,
                Width = 100,
                CellTemplate = new DataGridViewTextBoxCell()

            });


            DailyClosingHeaderGridView.Columns.Add(new()
            {
                DataPropertyName = "Fecha",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.FECHA),
                Name = "Fecha",
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
                DataPropertyName = "Contenedor",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.CONTENEDOR),
                Name = "Contenedor",
                Visible = true,
                Width = 150,
                CellTemplate = new DataGridViewTextBoxCell()

            });

            DailyClosingHeaderGridView.Columns.Add(new()
            {
                DataPropertyName = "Tipo",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.TIPO),
                Name = "Tipo",
                Visible = true,
                Width = 150,
                CellTemplate = new DataGridViewTextBoxCell()

            });

            DailyClosingHeaderGridView.Columns.Add(new()
            {
                DataPropertyName = "Moneda",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.MONEDA),
                Name = "Moneda",
                Visible = true,
                Width = 150,
                CellTemplate = new DataGridViewTextBoxCell()

            });

            DailyClosingHeaderGridView.Columns.Add(new()
            {
                DataPropertyName = "TipoId",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.TIPOID),
                Name = "TipoId",
                Visible = false,
                Width = 1,
                CellTemplate = new DataGridViewTextBoxCell()

            });


            DailyClosingHeaderGridView.Columns.Add(new()
            {
                DataPropertyName = "UsuarioCuenta",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.USUARIOCUENTA),
                Name = "UsuarioCuenta",
                Visible = true,
                Width = 150,
                CellTemplate = new DataGridViewTextBoxCell()

            });

            DailyClosingHeaderGridView.Columns.Add(new()
            {
                DataPropertyName = "Turno",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.TURNO),
                Name = "Turno",
                Visible = true,
                Width = 150,
                CellTemplate = new DataGridViewTextBoxCell()

            });

            DailyClosingHeaderGridView.Columns.Add(new()
            {
                DataPropertyName = "CierreDiario",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.CIERREDIARIO),
                Name = "CierreDiario",
                Visible = true,
                Width = 150,
                CellTemplate = new DataGridViewTextBoxCell()

            });

            DailyClosingHeaderGridView.Columns.Add(new()
            {
                DataPropertyName = "Finalizada",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.FINALIZADA),
                Name = "Finalizada",
                Visible = true,
                Width = 100,
                CellTemplate = new DataGridViewCheckBoxCell()

            });
        }

        private void InitializeDailyClosingDetailGridView(OperationTypeEnum operationType)
        {
            DailyClosingHeaderGridView.AutoGenerateColumns = false;
            DailyClosingDetailGridView.Columns.Clear();

            if (operationType == OperationTypeEnum.BillDeposit)
            {
                DailyClosingDetailGridView.Columns.Add(new()
                {
                    DataPropertyName = ID,
                    HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.ID),
                    Name = ID,
                    Visible = false,
                    Width = 100,
                    CellTemplate = new DataGridViewTextBoxCell()

                });

                DailyClosingDetailGridView.Columns.Add(new()
                {
                    DataPropertyName = "Denominacion",
                    HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.DENOMINACION),
                    Name = "Denominacion",
                    Visible = true,
                    Width = 100,
                    CellTemplate = new DataGridViewTextBoxCell()

                });

                DailyClosingDetailGridView.Columns.Add(new()
                {
                    DataPropertyName = "CantidadUnidades",
                    HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.CANTIDADUNIDADES),
                    Name = "CantidadUnidades",
                    Visible = true,
                    Width = 100,
                    CellTemplate = new DataGridViewTextBoxCell()

                });
            }
            if(operationType == OperationTypeEnum.EnvelopeDeposit)
            {
                DailyClosingDetailGridView.Columns.Add(new()
                {
                    DataPropertyName = "Sobre",
                    HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.SOBRE),
                    Name = "Sobre",
                    Visible = true,
                    Width = 100,
                    CellTemplate = new DataGridViewTextBoxCell()

                });

                DailyClosingDetailGridView.Columns.Add(new()
                {
                    DataPropertyName = "TipoValor",
                    HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.TIPOVALOR),
                    Name = "TipoValor",
                    Visible = true,
                    Width = 100,
                    CellTemplate = new DataGridViewTextBoxCell()

                });

                DailyClosingDetailGridView.Columns.Add(new()
                {
                    DataPropertyName = "CantidadDeclarada",
                    HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.CANTIDADDECLARADA),
                    Name = "CantidadDeclarada",
                    Visible = true,
                    Width = 100,
                    CellTemplate = new DataGridViewTextBoxCell()

                });
            }

            DailyClosingDetailGridView.Columns.Add(new()
            {
                DataPropertyName = "Fecha",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.FECHA),
                Name = "Fecha",
                Visible = true,
                Width = 150,
                CellTemplate = new DataGridViewTextBoxCell()

            });
        }

        private void LoadDailyClosingHeader()
        {

            DailyClosingHeaderGridView.DataSource = null;
            DailyClosingDetailGridView.DataSource = null;
            InitializeDailyClosingHeaderGridView();

            var DailyClosing = DatabaseController.GetDailyClosingHeaders(
                FromDateTimePicker.Value,
                ToDateTimePicker.Value,
                (long)UserComboBox.SelectedValue
                );

            _dailyclosingItems.Clear();

            foreach (var item in DailyClosing)
            {
                _dailyclosingItems.Add(new DailyClosingItem()
                {
                    CantidadOperaciones = (long)DatabaseController.GetDailyClosingDetail(item.Id).Count,
                    Total = (double)DatabaseController.GetDailyClosingDetail(item.Id).Sum(x => x.CantidadUnidades * x.DenominacionId.Unidades),
                    Moneda = DatabaseController.GetDailyClosingDetail(item.Id).FirstOrDefault().DenominacionId.MonedaId.Nombre,
                    TotalAValidar = DatabaseController.GetDailyClosingDetail(item.Id).FirstOrDefault().TransaccionId.TotalAValidar,
                    TotalValidado = DatabaseController.GetDailyClosingDetail(item.Id).FirstOrDefault().TransaccionId.TotalValidado

                }); 
            }

            DailyClosingHeaderGridView.DataSource = _dailyclosingItems;


        }
        private void DailyClosingHeaderGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TimeOutController.Reset();

            DetailPanel.Visible = true;

            DailyClosingDetailGridView.DataSource  = null;
            if (e.RowIndex > -1)
            {

                _operationId = (long)DailyClosingHeaderGridView.Rows[e.RowIndex].Cells[ID].Value;
                _operationTypeId = (long)DailyClosingHeaderGridView.Rows[e.RowIndex].Cells["TipoId"].Value;

                InitializeDailyClosingDetailGridView((OperationTypeEnum)_operationTypeId);

       
    
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

            if (ParameterController.PrintsDailyClosing)
            {
                if (!_alreadyPrinted)
                {
                    for (int i = 0; i < ParameterController.PrintDailyClosingQuantity; i++)
                    {
                        ReportController.PrintDepositReport(ReportTypeEnum.DailyClosing,
                            _dailyclosingItems,null);
                        _alreadyPrinted = true;
                    }
                }
            }
        }

      }
}
