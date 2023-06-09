﻿using Permaquim.Depositary.UI.Desktop.Controllers;
using Permaquim.Depositary.UI.Desktop.Entities;
using Permaquim.Depositary.UI.Desktop.Global;
using System.Buffers;
using static Permaquim.Depositary.UI.Desktop.Global.Enumerations;

namespace Permaquim.Depositary.UI.Desktop
{
    public partial class OperationsHistoryForm : Form
    {
        private const string NOMBREAPELLIDO = "NombreApellido";
        private const string TEXT = "Text";
        private const string VALUE = "Value";
        private const string ID = "Id";
        private const string TODOS = "Todos";
        private System.Windows.Forms.Timer _pollingTimer = new System.Windows.Forms.Timer();

        private long _operationId;
        private long _operationTypeId;

        public OperationsHistoryForm(bool singleUser = false)
        {
            InitializeComponent();
            CenterPanel();
            LoadStyles();
            LoadMultilanguageItems();
            LoadFilterControls(singleUser);
            InitializeOperationsHeaderGridView();

            TimeOutController.Reset();
            _pollingTimer = new System.Windows.Forms.Timer()
            {
                Interval = DeviceController.GetPollingInterval()
            };
            _pollingTimer.Tick += PollingTimer_Tick;
            ResetReport();
            LoadOperationsHeader();
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

        private void ResetReport()
        {
            ToDateTimePicker.Value = DateTime.Now.Date;
            FromDateTimePicker.Value = DateTime.Now.Date;
            FromDateTimePicker.Format = DateTimePickerFormat.Custom;
            FromDateTimePicker.CustomFormat = MultilanguangeController.GetText(MultiLanguageEnum.FORMATO_FECHA);

            ToDateTimePicker.Format = DateTimePickerFormat.Custom;
            ToDateTimePicker.CustomFormat = MultilanguangeController.GetText(MultiLanguageEnum.FORMATO_FECHA);

            UserComboBox.SelectedIndex = 0;
            TurnComboBox.SelectedIndex = 0;
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

            OperationsHeaderGridView.Location = new Point()
            {
                X = OperationsHeaderGridView.Location.X,
                Y = OperationsHeaderGridView.Location.Y
            };

            OperationsDetailGridView.Location = new Point()
            {
                X = OperationsDetailGridView.Location.X,
                Y = OperationsDetailGridView.Location.Y
            };

            DetailPanel.Location = new Point()
            {
                X = this.Width / 2 - this.Width / 2,
                Y = this.Height / 2 - this.Height / 2
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
            //ExecuteButton.BackgroundColor = StyleController.GetColor(Enumerations.ColorNameEnum.BotonAceptar);
            ExecuteButton.ForeColor = StyleController.GetColor(Enumerations.ColorNameEnum.FuenteContraste);
            //ExecuteButton.TextColor = StyleController.GetColor(Enumerations.ColorNameEnum.FuenteContraste);

            BackButton.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.BotonSalir);
            AcceptButton.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.BotonAceptar);
            PrintButton.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.BotonAlternativo);


            FromDateTimeLabel.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.CabeceraGrilla);
            ToDateTimeLabel.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.CabeceraGrilla);
            UserLabel.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.CabeceraGrilla);
            TurnLabel.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.CabeceraGrilla);
            UserLabel.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.CabeceraGrilla);
            TypeLabel.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.CabeceraGrilla);

            StyleController.SetControlStyle(OperationsHeaderGridView);
            StyleController.SetControlStyle(OperationsDetailGridView);
        }

        private void LoadMultilanguageItems()
        {
            FromDateTimeLabel.Text = MultilanguangeController.GetText(MultiLanguageEnum.FECHA_DESDE);
            ToDateTimeLabel.Text = MultilanguangeController.GetText(MultiLanguageEnum.FECHA_HASTA);
            TurnLabel.Text = MultilanguangeController.GetText(MultiLanguageEnum.TURNO);
            UserLabel.Text = MultilanguangeController.GetText(MultiLanguageEnum.USUARIO);
            TypeLabel.Text = MultilanguangeController.GetText(MultiLanguageEnum.TIPO);
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

        public void LoadFilterControls(bool singleUser)
        {
            var userList = DatabaseController.GetUserList(false);

            if (!singleUser)
            {
                userList.Insert(0, new Depositario.Entities.Tables.Seguridad.Usuario()
                {
                    NombreApellido = TODOS,
                    Id = -1
                });
            }

            if (singleUser)
                UserComboBox.DataSource = DatabaseController.GetUserList(true); 
            else
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

            List<OperationTypeItemElement> typeItemList = new();

            typeItemList.Add(new OperationTypeItemElement() { Value = -1, Text = "Todos" });

            var typeList = DatabaseController.GetTransactionTypes();

            foreach (var item in typeList)
            {
                typeItemList.Add(new OperationTypeItemElement()
                { Value = item.Id, Text = item.Nombre });
            }

            TypeComboBox.DisplayMember = TEXT;
            TypeComboBox.ValueMember = VALUE;
            TypeComboBox.DataSource = typeItemList;
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
                Visible = false,
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
                CellTemplate = new DataGridViewTextBoxCell(),
                DefaultCellStyle = StyleController.GetFullDateColumnStyle()

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
                Visible = ParameterController.UsesBankAccount,
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

            OperationsHeaderGridView.Columns.Add(new()
            {
                DataPropertyName = "EsDepositoAutomatico",
                HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.ES_DEPOSITO_AUTOMATICO),
                Name = "EsDepositoAutomatico",
                Visible = true,
                Width = 100,
                CellTemplate = new DataGridViewCheckBoxCell()

            });

        }

        private void InitializeOperationsDetailGridView(OperationTypeEnum operationType)
        {
            OperationsDetailGridView.AutoGenerateColumns = false;
            OperationsDetailGridView.Columns.Clear();

            if (operationType == OperationTypeEnum.BillDeposit)
            {
                OperationsDetailGridView.Columns.Add(new()
                {
                    DataPropertyName = "Id",
                    HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.ID),
                    Name = "Id",
                    Visible = false,
                    Width = 100,
                    CellTemplate = new DataGridViewTextBoxCell()
                });

                OperationsDetailGridView.Columns.Add(new()
                {
                    DataPropertyName = "Moneda",
                    HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.MONEDA),
                    Name = "Moneda",
                    Visible = true,
                    Width = 200,
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
                    Width = 130,
                    CellTemplate = new DataGridViewTextBoxCell()

                });

                OperationsDetailGridView.Columns.Add(new()
                {
                    DataPropertyName = "Unidades",
                    HeaderText = "",
                    Name = "Unidades",
                    Visible = false,
                    Width = 100,
                    CellTemplate = new DataGridViewTextBoxCell()

                });

                OperationsDetailGridView.Columns.Add(new()
                {
                    DataPropertyName = "DenominacionId",
                    HeaderText = "",
                    Name = "DenominacionId",
                    Visible = false,
                    Width = 100,
                    CellTemplate = new DataGridViewTextBoxCell()

                });
            }
            if (operationType == OperationTypeEnum.EnvelopeDeposit)
            {
                OperationsDetailGridView.Columns.Add(new()
                {
                    DataPropertyName = "Moneda",
                    HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.MONEDA),
                    Name = "Moneda",
                    Visible = true,
                    Width = 200,
                    CellTemplate = new DataGridViewTextBoxCell()

                });

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
                    Width = 130,
                    CellTemplate = new DataGridViewTextBoxCell()

                });
            }
            if (operationType == OperationTypeEnum.ValueExtraction)
            {
                OperationsDetailGridView.Columns.Add(new()
                {
                    DataPropertyName = "Id",
                    HeaderText = MultilanguangeController.GetText(MultiLanguageEnum.ID),
                    Name = "Id",
                    Visible = false,
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
                CellTemplate = new DataGridViewTextBoxCell(),
                DefaultCellStyle = StyleController.GetFullDateColumnStyle()

            });
        }

        private void LoadOperationsHeader()
        {

            OperationsHeaderGridView.DataSource = null;
            OperationsDetailGridView.DataSource = null;

            InitializeOperationsHeaderGridView();

            DateTime FechaHasta = ToDateTimePicker.Value;

            FechaHasta = FechaHasta.AddHours(23);
            FechaHasta = FechaHasta.AddMinutes(59);
            FechaHasta = FechaHasta.AddSeconds(59);

            var operations = DatabaseController.GetOperationsHeaders(
                FromDateTimePicker.Value,
                FechaHasta,
                (long)UserComboBox.SelectedValue,
                (long)TurnComboBox.SelectedValue,
                (long)TypeComboBox.SelectedValue
                );

            _transactionHeaderItems.Clear();

            foreach (var item in operations)
            {
                var esquemaDetalleTurno = item.TurnoId.TurnoDepositarioId.EsquemaDetalleTurnoId;
                _transactionHeaderItems.Add(new TransactionHeaderItem()
                {
                    Cierrediario =  item.CierreDiarioId != null?  
                        item.CierreDiarioId.CodigoCierre : String.Empty,
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
                    UsuarioCuenta = item.CuentaId == null ? null : item.CuentaId.Numero,
                    EsDepositoAutomatico= item.EsDepositoAutomatico,
                }); ;
            }

            OperationsHeaderGridView.DataSource = _transactionHeaderItems;


        }
        private void OperationsHeaderGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TimeOutController.Reset();


            if (e.RowIndex > -1)
            {
                OperationsDetailGridView.DataSource = null;
                DetailPanel.Location = new Point(
                this.ClientSize.Width / 2 - DetailPanel.Size.Width / 2,
                this.ClientSize.Height / 2 - DetailPanel.Size.Height / 2);
                DetailPanel.Anchor = AnchorStyles.None;

                DetailPanel.Visible = true;


                if (OperationsHeaderGridView.Rows[e.RowIndex].Cells["Id"] != null)
                {
                    _operationId = (long)OperationsHeaderGridView.Rows[e.RowIndex].Cells["Id"].Value;
                    _operationTypeId = (long)OperationsHeaderGridView.Rows[e.RowIndex].Cells["TipoId"].Value;
                    var moneda = OperationsHeaderGridView.Rows[e.RowIndex].Cells["Moneda"].Value.ToString();
                    InitializeOperationsDetailGridView((OperationTypeEnum)_operationTypeId);

                    if ((OperationTypeEnum)_operationTypeId == OperationTypeEnum.BillDeposit)
                    {
                        var operationDetails = DatabaseController.GetOperationsDetails(_operationId);

                        _transactionDetailItems.Clear();

                        foreach (var item in operationDetails)
                        {
                            var operationDetail = _transactionDetailItems.FirstOrDefault(x => x.DenominacionId == item._DenominacionId);

                            //Si ya existia en la lista un elemento con esa denominacion lo actualizo
                            if (operationDetail != null)
                            {
                                operationDetail.CantidadUnidades += item.CantidadUnidades;
                            }
                            else
                            {
                                _transactionDetailItems.Add(new TransactionDetailItem()
                                {
                                    CantidadUnidades = item.CantidadUnidades,
                                    Unidades = item.DenominacionId.Unidades,
                                    DenominacionId = item._DenominacionId,
                                    Denominacion = item.DenominacionId.Nombre,
                                    Fecha = item.Fecha,
                                    Moneda = moneda == null ? "" : moneda,
                                    Id = item.Id
                                });
                            }
                        }

                        OperationsDetailGridView.DataSource = _transactionDetailItems.OrderBy(x => x.Unidades).ToList();

                    }
                    if ((OperationTypeEnum)_operationTypeId == OperationTypeEnum.EnvelopeDeposit)
                    {
                        var operationEnvelopeDetails = DatabaseController.GetEnvelopeOperationsDetails(_operationId);

                        _transactionEnvelopeDetailItems.Clear();

                        foreach (var item in operationEnvelopeDetails)
                        {
                            _transactionEnvelopeDetailItems.Add(new TransactionEnvelopDetailItem()
                            {
                                CantidadDeclarada = item.CantidadDeclarada,
                                Sobre = item.SobreId.CodigoSobre,
                                Fecha = item.Fecha,
                                Moneda = moneda == null ? "" : moneda,
                                TipoValor = item.RelacionMonedaTipoValorId.TipoValorId.Nombre

                            });
                        }


                        OperationsDetailGridView.DataSource = _transactionEnvelopeDetailItems;
                    }
                }
            }
        }


        private System.ComponentModel.BindingList<TransactionHeaderItem> _transactionHeaderItems = new();
        private System.ComponentModel.BindingList<TransactionDetailItem> _transactionDetailItems = new();
        private System.ComponentModel.BindingList<TransactionEnvelopDetailItem> _transactionEnvelopeDetailItems = new();



        private void OperationsHeaderGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            System.Diagnostics.Debug.Print("");
        }

        private void OperationsHistoryform_VisibleChanged(object sender, EventArgs e)
        {
            _pollingTimer.Enabled = this.Visible;
            if (this.Visible)
            {
                FormsController.SetInformationMessage(InformationTypeEnum.None, String.Empty);
                LoadOperationsHeader();
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
            OperationsHeaderGridView.DataSource = null;
            OperationsDetailGridView.DataSource = null;
        }
        private void OperationsDetailGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TimeOutController.Reset();
        }

        private void OperationsHistoryform_MouseClick(object sender, MouseEventArgs e)
        {
            TimeOutController.Reset();
        }

        private void ExecuteButton_Click(object sender, EventArgs e)
        {
            TimeOutController.Reset();
            LoadOperationsHeader();
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            TimeOutController.Reset();
            DetailPanel.Visible = false;
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            TimeOutController.Reset();
            if ((OperationTypeEnum)_operationTypeId == OperationTypeEnum.BillDeposit)
                PrintBillDepositTicket();
            if ((OperationTypeEnum)_operationTypeId == OperationTypeEnum.EnvelopeDeposit)
                PrintEnvelopeTicket();
            if ((OperationTypeEnum)_operationTypeId == OperationTypeEnum.ValueExtraction)
                PrintValueExtractionTicket();
        }
        private void PrintValueExtractionTicket()
        {
            if (ParameterController.PrintsBagExtraction)
            {
                var _header = DatabaseController.GetTransactionHeader(_operationId);

                ReportController.ContainerToPrint = DatabaseController.GetContainer(_header.ContenedorId.Id);
                ReportController.PrintReport(ReportTypeEnum.ValueExtraction,
                DatabaseController.GetEnvelopeContainerContentItems(_header.ContenedorId.Id),
                DatabaseController.GetBillContainerContentItems(_header.ContenedorId.Id), 1);
            }
        }
        private void PrintBillDepositTicket()
        {
            if (ParameterController.PrintsBillDeposit)
            {
                var _header = DatabaseController.GetTransactionHeader(_operationId);
                var _details = DatabaseController.GetTransactionDetails(_operationId);

                //Consolidamos el detalle 
                List<Entities.BillDepositDetail> _consolidatedDetailsList = new List<Entities.BillDepositDetail>();
                foreach (var detailReportItem in _details)
                {
                    var detailExists = _consolidatedDetailsList.FirstOrDefault(x => x.DenominacionId == detailReportItem._DenominacionId);

                    if (detailExists != null)
                    {
                        detailExists.CantidadUnidades += detailReportItem.CantidadUnidades;
                    }
                    else
                    {
                        Entities.BillDepositDetail billDepositDetail = new();

                        billDepositDetail.CantidadUnidades = detailReportItem.CantidadUnidades;
                        billDepositDetail.Unidades = detailReportItem.DenominacionId.Unidades;
                        billDepositDetail.DenominacionId = detailReportItem._DenominacionId;
                        billDepositDetail.DenominacionNombre = detailReportItem.DenominacionId.Nombre;
                        billDepositDetail.MonedaCodigo = detailReportItem.DenominacionId.MonedaId.Codigo;

                        _consolidatedDetailsList.Add(billDepositDetail);
                    }
                }



                Thread thread = new Thread(() =>
                {

                    for (int i = 1; i <= ParameterController.PrintBillDepositQuantity; i++)
                    {
                        ReportController.PrintReport(ReportTypeEnum.BillDeposit,
                            _header, _consolidatedDetailsList, i);
                    }
                });
                thread.Start();
            }
        }

        private void PrintEnvelopeTicket()
        {
            if (ParameterController.PrintsEnvelopeDeposit)
            {
                var _header = DatabaseController.GetTransactionHeader(_operationId);
                var _details = DatabaseController.GetTransactionDetails(_operationId);

                for (int i = 1; i <= ParameterController.PrintBillDepositQuantity; i++)
                {
                    ReportController.PrintReport(ReportTypeEnum.EnvelopeDepositSecondReport, _header, _details, i);
                }
            }
        }

        private void ToDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            FromDateTimePicker.MaxDate = ToDateTimePicker.Value;
            TimeOutController.Reset();
        }

        private void FromDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            ToDateTimePicker.MinDate = FromDateTimePicker.Value;
            TimeOutController.Reset();
        }

        private void FilterPanel_Click(object sender, EventArgs e)
        {
            TimeOutController.Reset();
        }

        private void OperationsHistoryForm_Click(object sender, EventArgs e)
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

        private void FromDateTimePicker_MouseDown(object sender, MouseEventArgs e)
        {
            TimeOutController.Reset();
        }

        private void ToDateTimePicker_MouseDown(object sender, MouseEventArgs e)
        {
            TimeOutController.Reset();
        }

        private void DetailPanel_Click(object sender, EventArgs e)
        {
            TimeOutController.Reset();
        }

        private void OperationsDetailGridView_Click(object sender, EventArgs e)
        {
            TimeOutController.Reset();
        }

        private void DetailLabel_Click(object sender, EventArgs e)
        {
            TimeOutController.Reset();
        }
    }
}
