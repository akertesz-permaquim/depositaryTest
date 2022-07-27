using Permaquim.Depositary.UI.Desktop.Builders;
using Permaquim.Depositary.UI.Desktop.Components;
using Permaquim.Depositary.UI.Desktop.Controllers;
using Permaquim.Depositary.UI.Desktop.Entities;
using Permaquim.Depositary.UI.Desktop.Global;
using static Permaquim.Depositary.UI.Desktop.Global.Enumerations;

namespace Permaquim.Depositary.UI.Desktop
{
    public partial class TurnChangeForm : Form
    {
        CounterDevice _device = null;
        private System.Windows.Forms.Timer _pollingTimer = new System.Windows.Forms.Timer();

        public TurnChangeForm()
        {
            InitializeComponent();
            CenterPanel();
            LoadStyles();
            LoadMultiLanguageItems();
            LoadTurnChangeButton();
            LoadBackButton();
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
                FormsController.LogOff();
            }
        }
        private void TurnChangeForm_Load(object sender, EventArgs e)
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
        }
        private void LoadStyles()
        {
            this.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.FondoFormulario);

            StyleController.SetControlStyle(OperationsHeaderGridView);
            StyleController.SetControlStyle(OperationsDetailGridView);

        }
        private void LoadMultiLanguageItems()
        {
            string message = MultilanguangeController.GetText(MultiLanguageEnum.CONFIRMA_CIERRE_TURNO)
             + Environment.NewLine + "Turno actual: "
                + DatabaseController.CurrentTurn.TurnoDepositarioId.Nombre;
            FormsController.SetInformationMessage(InformationTypeEnum.Information, message);
 
            TurnLabel.Text = MultilanguangeController.GetText(MultiLanguageEnum.TRANSACCIONES_TURNO);
        }


        #region TurnchangeButton
        private void LoadTurnChangeButton()
        {
            CustomButton backButton = ControlBuilder.BuildExitButton(
                "TurnchangeButton", MultilanguangeController.GetText(MultiLanguageEnum.ACCEPT_BUTTON), MainPanel.Width /2 -5,55);

            this.MainPanel.Controls.Add(backButton);

            backButton.Click += new System.EventHandler(TurnchangeButton_Click);
        }
        private void TurnchangeButton_Click(object sender, EventArgs e)
        {
            DatabaseController.CloseCurrentTurn();

            FormsController.OpenChildForm(this,new OtherOperationsForm(), _device);
        }
        #endregion

        #region BackButton
        private void LoadBackButton()
        {
            CustomButton backButton = ControlBuilder.BuildCancelButton(
                "BackButton", MultilanguangeController.GetText(MultiLanguageEnum.VOLVER), MainPanel.Width / 2 - 5,55);

            this.MainPanel.Controls.Add(backButton);

            backButton.Click += new System.EventHandler(BackButton_Click);
        }
        private void BackButton_Click(object sender, EventArgs e)
        {
            FormsController.OpenChildForm(this,new OtherOperationsForm(), _device);
        }
        #endregion

        private void TurnChangeForm_VisibleChanged(object sender, EventArgs e)
        {
            _pollingTimer.Enabled = this.Visible;
            if (this.Visible)
            {
                LoadOperationsHeader();
            }
            else
            {
                InitializeLocals();
            }

            FormsController.SetInformationMessage(InformationTypeEnum.None, string.Empty);
        }

        #region Datagrid        

        private void LoadOperationsHeader()
        {

            var operations = DatabaseController.GetCurrentTurnOperationsHeaders();

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

        private void InitializeOperationsHeaderGridView()
        {
            OperationsHeaderGridView.AutoGenerateColumns = false;
            OperationsHeaderGridView.Columns.Clear();

            OperationsHeaderGridView.Columns.Add(new()
            {
                DataPropertyName = "Id",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.ID),
                Name = "Id",
                Visible = false,
                Width = 100,
                CellTemplate = new DataGridViewTextBoxCell()

            });

            OperationsHeaderGridView.Columns.Add(new()
            {
                DataPropertyName = "TotalValidado",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.TOTAL_VALIDADO),
                Name = "TotalValidado",
                Visible = true,
                Width = 100,
                CellTemplate = new DataGridViewTextBoxCell()

            });

            OperationsHeaderGridView.Columns.Add(new()
            {
                DataPropertyName = "TotalAValidar",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.TOTAL_A_VALIDAR),
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
                DataPropertyName = "Usuario",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.USUARIO),
                Name = "Usuario",
                Visible = true,
                Width = 200,
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
                DataPropertyName = "UsuarioCuenta",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.USUARIOCUENTA),
                Name = "UsuarioCuenta",
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
                DataPropertyName = "Finalizada",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.FINALIZADA),
                Name = "Finalizada",
                Visible = true,
                Width = 100,
                CellTemplate = new DataGridViewCheckBoxCell()

            });


        }
        private void OperationsHeaderGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TimeOutController.Reset();
            if (e.RowIndex > -1)
            {
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
                            TipoValor = item.RelacionMonedaTipoValorId.TipoValorId.Nombre

                        });
                    }
                    OperationsDetailGridView.DataSource = _transactionEnvelopeDetailItems;
                }

             
            }
        }


        private List<TransactionHeaderItem> _transactionHeaderItems = new();
        private List<TransactionDetailItem> _transactionDetailItems = new();
        private List<TransactionEnvelopDetailItem> _transactionEnvelopeDetailItems = new();



        private void OperationsHeaderGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            System.Diagnostics.Debug.Print("");
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
            if (operationType == OperationTypeEnum.EnvelopeDeposit)
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

        #endregion
        private void InitializeLocals()
        {
            // inicializar variables locales.
            OperationsHeaderGridView.DataSource = null;
            OperationsDetailGridView.DataSource = null;
        }

        private void TurnChangeForm_MouseClick(object sender, MouseEventArgs e)
        {
            TimeOutController.Reset();
        }
    }
}
