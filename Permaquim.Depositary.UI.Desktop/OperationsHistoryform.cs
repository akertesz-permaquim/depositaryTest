using Permaquim.Depositary.UI.Desktop.Controllers;
using Permaquim.Depositary.UI.Desktop.Global;
using static Permaquim.Depositary.UI.Desktop.Global.Enumerations;

namespace Permaquim.Depositary.UI.Desktop
{
    public partial class OperationsHistoryform : Form
    {
        private System.Windows.Forms.Timer _pollingTimer = new System.Windows.Forms.Timer();
        public OperationsHistoryform()
        {
            InitializeComponent();
            CenterPanel();
            LoadStyles();
            InitializeOperationsHeaderGridView();
  
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
                FormsController.HideInstance(this);
            }
        }
        private void CenterPanel()
        {

            OperationsHeaderGridView.Location = new Point()
            {
                X = this.Width / 2 - OperationsHeaderGridView.Width / 2,
                Y = OperationsHeaderGridView.Location.Y
            };

            OperationsDetailGridView.Location = new Point()
            {
                X = this.Width / 2 - OperationsDetailGridView.Width / 2,
                Y = OperationsDetailGridView.Location.Y
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
            OperationsHeaderGridView.ColumnHeadersDefaultCellStyle.BackColor =
                StyleController.GetColor(Enumerations.ColorNameEnum.CabeceraGrilla);
            OperationsDetailGridView.ColumnHeadersDefaultCellStyle.BackColor =
                StyleController.GetColor(Enumerations.ColorNameEnum.CabeceraGrilla);
        }


        private void BackButton_Click(object sender, EventArgs e)
        {
            FormsController.OpenChildForm(this,new OperationForm(),
              (Permaquim.Depositary.UI.Desktop.Components.Device)this.Tag);
        }

        private void OperationHistoryForm_Load(object sender, EventArgs e)
        {

        }

        private void InitializeOperationsHeaderGridView()
        {
            OperationsHeaderGridView.AutoGenerateColumns = false;
            OperationsHeaderGridView.Columns.Clear();

            OperationsHeaderGridView.Columns.Add(new()
            {
                DataPropertyName = "Id",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.ID),
                Name = "Id",
                Visible = true,
                Width = 100,
                CellTemplate = new DataGridViewTextBoxCell()

            });

            OperationsHeaderGridView.Columns.Add(new()
            {
                DataPropertyName = "Tipo",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.TIPO),
                Name = "Tipo",
                Visible = true,
                Width = 150,
                CellTemplate = new DataGridViewTextBoxCell()

            });

            OperationsHeaderGridView.Columns.Add(new()
            {
                DataPropertyName = "Moneda",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.MONEDA),
                Name = "Moneda",
                Visible = true,
                Width = 150,
                CellTemplate = new DataGridViewTextBoxCell()

            });

            OperationsHeaderGridView.Columns.Add(new()
            {
                DataPropertyName = "TipoId",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.TIPOID),
                Name = "TipoId",
                Visible = false,
                Width = 1,
                CellTemplate = new DataGridViewTextBoxCell()

            });

            OperationsHeaderGridView.Columns.Add(new()
            {
                DataPropertyName = "Usuario",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.USUARIO),
                Name = "Usuario",
                Visible = true,
                Width = 200,
                CellTemplate = new DataGridViewTextBoxCell()

            });

            OperationsHeaderGridView.Columns.Add(new()
            {
                DataPropertyName = "UsuarioCuenta",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.USUARIOCUENTA),
                Name = "UsuarioCuenta",
                Visible = true,
                Width = 150,
                CellTemplate = new DataGridViewTextBoxCell()

            });


            OperationsHeaderGridView.Columns.Add(new()
            {
                DataPropertyName = "Contenedor",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.CONTENEDOR),
                Name = "Contenedor",
                Visible = true,
                Width = 150,
                CellTemplate = new DataGridViewTextBoxCell()

            });

            OperationsHeaderGridView.Columns.Add(new()
            {
                DataPropertyName = "Turno",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.TURNO),
                Name = "Turno",
                Visible = true,
                Width = 150,
                CellTemplate = new DataGridViewTextBoxCell()

            });

            OperationsHeaderGridView.Columns.Add(new()
            {
                DataPropertyName = "CierreDiario",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.CIERREDIARIO),
                Name = "CierreDiario",
                Visible = true,
                Width = 150,
                CellTemplate = new DataGridViewTextBoxCell()

            });

            OperationsHeaderGridView.Columns.Add(new()
            {
                DataPropertyName = "TotalValidado",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.TOTALVALIDADO),
                Name = "TotalValidado",
                Visible = true,
                Width = 100,
                CellTemplate = new DataGridViewTextBoxCell()

            });

            OperationsHeaderGridView.Columns.Add(new()
            {
                DataPropertyName = "TotalAValidar",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.TOTALAVALIDAR),
                Name = "TotalAValidar",
                Visible = true,
                Width = 100,
                CellTemplate = new DataGridViewTextBoxCell()

            });

            OperationsHeaderGridView.Columns.Add(new()
            {
                DataPropertyName = "Fecha",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.FECHA),
                Name = "Fecha",
                Visible = true,
                Width = 150,
                CellTemplate = new DataGridViewTextBoxCell()

            });


            OperationsHeaderGridView.Columns.Add(new()
            {
                DataPropertyName = "Finalizada",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.FINALIZADA),
                Name = "Finalizada",
                Visible = true,
                Width = 100,
                CellTemplate = new DataGridViewCheckBoxCell()

            });


        }

        private void InitializeOperationsDetailGridView(OperationTypeEnum operationType)
        {
            OperationsHeaderGridView.AutoGenerateColumns = false;
            OperationsDetailGridView.Columns.Clear();

            if (operationType == OperationTypeEnum.BillDeposit)
            {
                OperationsDetailGridView.Columns.Add(new()
                {
                    DataPropertyName = "Id",
                    HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.ID),
                    Name = "Id",
                    Visible = true,
                    Width = 100,
                    CellTemplate = new DataGridViewTextBoxCell()

                });

                OperationsDetailGridView.Columns.Add(new()
                {
                    DataPropertyName = "Denominacion",
                    HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.DENOMINACION),
                    Name = "Denominacion",
                    Visible = true,
                    Width = 100,
                    CellTemplate = new DataGridViewTextBoxCell()

                });

                OperationsDetailGridView.Columns.Add(new()
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
                OperationsDetailGridView.Columns.Add(new()
                {
                    DataPropertyName = "Sobre",
                    HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.SOBRE),
                    Name = "Sobre",
                    Visible = true,
                    Width = 100,
                    CellTemplate = new DataGridViewTextBoxCell()

                });

                OperationsDetailGridView.Columns.Add(new()
                {
                    DataPropertyName = "TipoValor",
                    HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.TIPOVALOR),
                    Name = "TipoValor",
                    Visible = true,
                    Width = 100,
                    CellTemplate = new DataGridViewTextBoxCell()

                });

                OperationsDetailGridView.Columns.Add(new()
                {
                    DataPropertyName = "CantidadDeclarada",
                    HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.CANTIDADDECLARADA),
                    Name = "CantidadDeclarada",
                    Visible = true,
                    Width = 100,
                    CellTemplate = new DataGridViewTextBoxCell()

                });
            }

            OperationsDetailGridView.Columns.Add(new()
            {
                DataPropertyName = "Fecha",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.FECHA),
                Name = "Fecha",
                Visible = true,
                Width = 150,
                CellTemplate = new DataGridViewTextBoxCell()

            });
        }

        private void LoadOperationsHeader()
        {

            var operations = DatabaseController.GetOperationsHeaders();

            _transactionHeaderItems.Clear();

            foreach (var item in operations)
            {
                _transactionHeaderItems.Add(new TransactionHeaderItem()
                {
                    Cierrediario = item.CierreDiarioId.Nombre,
                    Contenedor = item.ContenedorId.Identificador,
                    Fecha = item.Fecha,
                    Finalizada = item.Finalizada,
                    Id = item.Id,
                    Moneda = item.MonedaId.Nombre,
                    Tipo = item.TipoId.Nombre,
                    TipoId = item.TipoId.Id,
                    TotalAValidar = item.TotalAValidar,
                    TotalValidado = item.TotalValidado,
                    Turno = item.TurnoId.ToString(),
                    Usuario = item.UsuarioId.ToString(),
                    UsuarioCuenta = item.UsuarioCuentaId.CuentaId.Numero
                });
            }

            OperationsHeaderGridView.DataSource = _transactionHeaderItems;

        }
        private void OperationsHeaderGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TimeOutController.Reset();

            var operationId = (long)OperationsHeaderGridView.Rows[e.RowIndex].Cells["Id"].Value;
            var operationTypeId = (long)OperationsHeaderGridView.Rows[e.RowIndex].Cells["TipoId"].Value;

            InitializeOperationsDetailGridView((OperationTypeEnum)operationTypeId);

            if ((OperationTypeEnum)operationTypeId == OperationTypeEnum.BillDeposit)
            {
                var operationDetails = DatabaseController.GetOperationsDetails(operationId);

                _transactionDetailItems.Clear();

                foreach (var item in operationDetails)
                {
                    _transactionDetailItems.Add(new TransactionDetailItem()
                    {
                        CantidadUnidades = item.CantidadUnidades,
                        Denominacion = item.DenominacionId.Nombre,
                        Fecha = item.Fecha,
                        Id = item.Id
                    });
                }
             

                OperationsDetailGridView.DataSource = _transactionDetailItems;
            }
            if ((OperationTypeEnum)operationTypeId == OperationTypeEnum.EnvelopeDeposit)
            {
                var operationEnvelopeDetails = DatabaseController.GetEnvelopeOperationsDetails(operationId);

                _transactionEnvelopeDetailItems.Clear();

                foreach (var item in operationEnvelopeDetails)
                {
                    _transactionEnvelopeDetailItems.Add(new TransactionEnvelopDetailItem()
                    {
                        CantidadDeclarada = item.CantidadDeclarada,
                        Sobre = item.SobreId.CodigoSobre,
                        Fecha = item.Fecha,
                        TipoValor     = item.RelacionMonedaTipoValorId.TipoValorId.Nombre

                    });
                }


                OperationsDetailGridView.DataSource = _transactionEnvelopeDetailItems;
            }

            OperationsDetailGridView.Visible = true;
        }


        private List<TransactionHeaderItem> _transactionHeaderItems = new();
        private List<TransactionDetailItem> _transactionDetailItems = new();
        private List<TransactionEnvelopDetailItem> _transactionEnvelopeDetailItems = new();

        private class TransactionHeaderItem
        {
            public long Id { get; set; }
            public string Tipo { get; set; }
            public long TipoId { get; set; }
            public string Moneda { get; set; }
            public string Usuario { get; set; }
            public string UsuarioCuenta { get; set; }
            public string Contenedor { get; set; }
            public string Turno { get; set; }
            public string Cierrediario { get; set; }
            public double TotalValidado { get; set; }
            public double TotalAValidar { get; set; }
            public DateTime Fecha { get; set; }
            public bool Finalizada { get; set; }
        }
        private class TransactionDetailItem
        {
            public long Id { get; set; }
            public string Denominacion { get; set; }
            public long CantidadUnidades { get; set; }

            public DateTime Fecha { get; set; }
        }

        private class TransactionEnvelopDetailItem
        {
            public string Sobre { get; set; }
            public string TipoValor { get; set; }
            public long CantidadDeclarada { get; set; }
            public DateTime Fecha { get; set; }
        }

        private void OperationsHeaderGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            System.Diagnostics.Debug.Print("");
        }

        private void OperationsHistoryform_VisibleChanged(object sender, EventArgs e)
        {
            _pollingTimer.Enabled = this.Visible;
            if (this.Visible)
            {
                LoadOperationsHeader();
            }
        }

        private void OperationsDetailGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TimeOutController.Reset();
        }
    }
}
