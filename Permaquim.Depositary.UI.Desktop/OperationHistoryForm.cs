using Permaquim.Depositary.UI.Desktop.Components;
using Permaquim.Depositary.UI.Desktop.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Permaquim.Depositary.UI.Desktop
{
    public partial class OperationHistoryForm : Form
    {
        public OperationHistoryForm()
        {
            InitializeComponent();
            CenterPanel();
            LoadStyles();
            LoadOperationsHeader();
            LoadBackButton();
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
            this.BackColor = StyleController.GetColor(StyleController.ColorNameEnum.Contenido);
            OperationsHeaderGridView.Columns["Id"].HeaderText = MultilanguangeController.GetText("ID");
            OperationsHeaderGridView.Columns["TotalValidado"].HeaderText = MultilanguangeController.GetText("TOTAL_VALIDADO");
            OperationsHeaderGridView.Columns["TotalAValidar"].HeaderText = MultilanguangeController.GetText("TOTAL_A_VALIDAR");
            //OperationsHeaderGridView.Columns["Amount"].HeaderText = MultilanguangeController.GetText("IMPORTE");

            //OperationsDetailGridview.Columns["Image"].HeaderText = MultilanguangeController.GetText("IMAGEN");
            //OperationsDetailGridview.Columns["Denomination"].HeaderText = MultilanguangeController.GetText("DENOMINACION");
            //OperationsDetailGridview.Columns["Quantity"].HeaderText = MultilanguangeController.GetText("CANTIDAD");
            //OperationsDetailGridview.Columns["Amount"].HeaderText = MultilanguangeController.GetText("IMPORTE");
        }
        #region Back button
        private void LoadBackButton()
        {
            CustomButton backButton = ControlBuilder.BuildExitButton(
                "BackButton", MultilanguangeController.GetText("Salir"), MainPanel.Width);

            this.MainPanel.Controls.Add(backButton);
             
            backButton.Click += new System.EventHandler(BackButton_Click);
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            AppController.OpenChildForm(new OperationForm(),
              (Permaquim.Depositary.UI.Desktop.Components.Device)this.Tag);
        }
        #endregion
        private void OperationHistoryForm_Load(object sender, EventArgs e)
        {

        }


        private void LoadOperationsHeader()
        {

            var operations = DatabaseController.GetOperationsHeaders();
            OperationsHeaderGridView.DataSource = operations;

        }

        private void OperationsHeaderGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var operationId = (long)OperationsHeaderGridView.Rows[e.RowIndex].Cells["Id"].Value;

            var operationDetails = DatabaseController.GetOperationsDetails(operationId);
            OperationsDetailGridview.DataSource = operationDetails;
        }
    }
}
