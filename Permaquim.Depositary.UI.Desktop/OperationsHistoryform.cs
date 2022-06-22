﻿using Permaquim.Depositary.UI.Desktop.Controllers;
using Permaquim.Depositary.UI.Desktop.Global;
using static Permaquim.Depositary.UI.Desktop.Global.Enumerations;

namespace Permaquim.Depositary.UI.Desktop
{
    public partial class OperationsHistoryform : Form
    {

        public OperationsHistoryform()
        {
            InitializeComponent();
            CenterPanel();
            LoadStyles();
            InitializeOperationsHeaderGridView();
            LoadOperationsHeader();
        }
        private void CenterPanel()
        {

            MainPanel.Location = new Point()
            {
                X = this.Width / 2 - MainPanel.Width / 2,
                Y = this.Height / 2 - MainPanel.Height / 2
            };
        }
        private void LoadStyles()
        {
            this.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.Contenido);
        }


        private void BackButton_Click(object sender, EventArgs e)
        {
            AppController.OpenChildForm(new OperationForm(),
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
                HeaderText = MultilanguangeController.GetText("ID"),
                Name = "Id",
                Visible = true,
                Width = 100,
                CellTemplate = new DataGridViewTextBoxCell()

            });

            OperationsHeaderGridView.Columns.Add(new()
            {
                DataPropertyName = "Tipo",
                HeaderText = MultilanguangeController.GetText("Tipo"),
                Name = "Tipo",
                Visible = true,
                Width = 150,
                CellTemplate = new DataGridViewTextBoxCell()

            });

            OperationsHeaderGridView.Columns.Add(new()
            {
                DataPropertyName = "TipoId",
                HeaderText = MultilanguangeController.GetText("TipoId"),
                Name = "TipoId",
                Visible = false,
                Width = 1,
                CellTemplate = new DataGridViewTextBoxCell()

            });

            OperationsHeaderGridView.Columns.Add(new()
            {
                DataPropertyName = "Usuario",
                HeaderText = MultilanguangeController.GetText("Usuario"),
                Name = "Usuario",
                Visible = true,
                Width = 200,
                CellTemplate = new DataGridViewTextBoxCell()

            });

            OperationsHeaderGridView.Columns.Add(new()
            {
                DataPropertyName = "UsuarioCuenta",
                HeaderText = MultilanguangeController.GetText("UsuarioCuenta"),
                Name = "UsuarioCuenta",
                Visible = true,
                Width = 150,
                CellTemplate = new DataGridViewTextBoxCell()

            });


            OperationsHeaderGridView.Columns.Add(new()
            {
                DataPropertyName = "Contenedor",
                HeaderText = MultilanguangeController.GetText("Contenedor"),
                Name = "Contenedor",
                Visible = true,
                Width = 150,
                CellTemplate = new DataGridViewTextBoxCell()

            });

            OperationsHeaderGridView.Columns.Add(new()
            {
                DataPropertyName = "Turno",
                HeaderText = MultilanguangeController.GetText("Turno"),
                Name = "Turno",
                Visible = true,
                Width = 150,
                CellTemplate = new DataGridViewTextBoxCell()

            });

            OperationsHeaderGridView.Columns.Add(new()
            {
                DataPropertyName = "CierreDiario",
                HeaderText = MultilanguangeController.GetText("CierreDiario"),
                Name = "CierreDiario",
                Visible = true,
                Width = 150,
                CellTemplate = new DataGridViewTextBoxCell()

            });

            OperationsHeaderGridView.Columns.Add(new()
            {
                DataPropertyName = "TotalValidado",
                HeaderText = MultilanguangeController.GetText("TotalValidado"),
                Name = "TotalValidado",
                Visible = true,
                Width = 100,
                CellTemplate = new DataGridViewTextBoxCell()

            });

            OperationsHeaderGridView.Columns.Add(new()
            {
                DataPropertyName = "TotalAValidar",
                HeaderText = MultilanguangeController.GetText("TotalAValidar"),
                Name = "TotalAValidar",
                Visible = true,
                Width = 100,
                CellTemplate = new DataGridViewTextBoxCell()

            });

            OperationsHeaderGridView.Columns.Add(new()
            {
                DataPropertyName = "Fecha",
                HeaderText = MultilanguangeController.GetText("Fecha"),
                Name = "Fecha",
                Visible = true,
                Width = 150,
                CellTemplate = new DataGridViewTextBoxCell()

            });


            OperationsHeaderGridView.Columns.Add(new()
            {
                DataPropertyName = "Finalizada",
                HeaderText = MultilanguangeController.GetText("Finalizada"),
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
                    HeaderText = MultilanguangeController.GetText("ID"),
                    Name = "Id",
                    Visible = true,
                    Width = 100,
                    CellTemplate = new DataGridViewTextBoxCell()

                });

                OperationsDetailGridView.Columns.Add(new()
                {
                    DataPropertyName = "Denominacion",
                    HeaderText = MultilanguangeController.GetText("Denominacion"),
                    Name = "Denominacion",
                    Visible = true,
                    Width = 100,
                    CellTemplate = new DataGridViewTextBoxCell()

                });

                OperationsDetailGridView.Columns.Add(new()
                {
                    DataPropertyName = "CantidadUnidades",
                    HeaderText = MultilanguangeController.GetText("CantidadUnidades"),
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
                    HeaderText = MultilanguangeController.GetText("Sobre"),
                    Name = "Sobre",
                    Visible = true,
                    Width = 100,
                    CellTemplate = new DataGridViewTextBoxCell()

                });

                OperationsDetailGridView.Columns.Add(new()
                {
                    DataPropertyName = "TipoValor",
                    HeaderText = MultilanguangeController.GetText("TipoValor"),
                    Name = "TipoValor",
                    Visible = true,
                    Width = 100,
                    CellTemplate = new DataGridViewTextBoxCell()

                });

                OperationsDetailGridView.Columns.Add(new()
                {
                    DataPropertyName = "CantidadDeclarada",
                    HeaderText = MultilanguangeController.GetText("CantidadDeclarada"),
                    Name = "CantidadDeclarada",
                    Visible = true,
                    Width = 100,
                    CellTemplate = new DataGridViewTextBoxCell()

                });
            }

            OperationsDetailGridView.Columns.Add(new()
            {
                DataPropertyName = "Fecha",
                HeaderText = MultilanguangeController.GetText("Fecha"),
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
                var operationEnvelopeDetails = DatabaseController.GetenvelopeOperationsDetails(operationId);

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
    }
}
