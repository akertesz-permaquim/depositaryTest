namespace Permaquim.Depositary.UI.Desktop
{
    partial class OperationHistoryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.MainPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.OperationsHeaderGridView = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalValidado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalAValidar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrintButtonColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.OperationsDetailGridview = new System.Windows.Forms.DataGridView();
            this.TransaccionId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DenominacionId_Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadUnidades = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OperationsHeaderGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OperationsDetailGridview)).BeginInit();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.OperationsHeaderGridView);
            this.MainPanel.Controls.Add(this.OperationsDetailGridview);
            this.MainPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.MainPanel.Location = new System.Drawing.Point(8, 8);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(720, 576);
            this.MainPanel.TabIndex = 0;
            // 
            // OperationsHeaderGridView
            // 
            this.OperationsHeaderGridView.AllowUserToAddRows = false;
            this.OperationsHeaderGridView.AllowUserToDeleteRows = false;
            this.OperationsHeaderGridView.AllowUserToResizeColumns = false;
            this.OperationsHeaderGridView.AllowUserToResizeRows = false;
            this.OperationsHeaderGridView.BackgroundColor = System.Drawing.Color.White;
            this.OperationsHeaderGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.OperationsHeaderGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.OperationsHeaderGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.OperationsHeaderGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.OperationsHeaderGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.OperationsHeaderGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.TotalValidado,
            this.TotalAValidar,
            this.PrintButtonColumn});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.OperationsHeaderGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.OperationsHeaderGridView.EnableHeadersVisualStyles = false;
            this.OperationsHeaderGridView.GridColor = System.Drawing.Color.White;
            this.OperationsHeaderGridView.Location = new System.Drawing.Point(3, 3);
            this.OperationsHeaderGridView.Name = "OperationsHeaderGridView";
            this.OperationsHeaderGridView.RowHeadersVisible = false;
            this.OperationsHeaderGridView.RowTemplate.DividerHeight = 1;
            this.OperationsHeaderGridView.RowTemplate.Height = 50;
            this.OperationsHeaderGridView.RowTemplate.ReadOnly = true;
            this.OperationsHeaderGridView.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.OperationsHeaderGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.OperationsHeaderGridView.Size = new System.Drawing.Size(696, 232);
            this.OperationsHeaderGridView.TabIndex = 148;
            this.OperationsHeaderGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OperationsHeaderGridView_CellClick);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "*";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Width = 260;
            // 
            // TotalValidado
            // 
            this.TotalValidado.DataPropertyName = "TotalValidado";
            this.TotalValidado.HeaderText = "*";
            this.TotalValidado.Name = "TotalValidado";
            this.TotalValidado.ReadOnly = true;
            this.TotalValidado.Width = 110;
            // 
            // TotalAValidar
            // 
            this.TotalAValidar.DataPropertyName = "TotalAValidar";
            this.TotalAValidar.HeaderText = "*";
            this.TotalAValidar.Name = "TotalAValidar";
            this.TotalAValidar.ReadOnly = true;
            this.TotalAValidar.Width = 220;
            // 
            // PrintButtonColumn
            // 
            this.PrintButtonColumn.HeaderText = "*";
            this.PrintButtonColumn.Name = "PrintButtonColumn";
            // 
            // OperationsDetailGridview
            // 
            this.OperationsDetailGridview.AllowUserToAddRows = false;
            this.OperationsDetailGridview.AllowUserToDeleteRows = false;
            this.OperationsDetailGridview.AllowUserToResizeColumns = false;
            this.OperationsDetailGridview.AllowUserToResizeRows = false;
            this.OperationsDetailGridview.BackgroundColor = System.Drawing.Color.White;
            this.OperationsDetailGridview.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.OperationsDetailGridview.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.OperationsDetailGridview.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.OperationsDetailGridview.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.OperationsDetailGridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.OperationsDetailGridview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TransaccionId,
            this.DenominacionId_Nombre,
            this.CantidadUnidades});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.OperationsDetailGridview.DefaultCellStyle = dataGridViewCellStyle4;
            this.OperationsDetailGridview.EnableHeadersVisualStyles = false;
            this.OperationsDetailGridview.GridColor = System.Drawing.Color.White;
            this.OperationsDetailGridview.Location = new System.Drawing.Point(3, 241);
            this.OperationsDetailGridview.Name = "OperationsDetailGridview";
            this.OperationsDetailGridview.RowHeadersVisible = false;
            this.OperationsDetailGridview.RowTemplate.DividerHeight = 1;
            this.OperationsDetailGridview.RowTemplate.Height = 50;
            this.OperationsDetailGridview.RowTemplate.ReadOnly = true;
            this.OperationsDetailGridview.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.OperationsDetailGridview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.OperationsDetailGridview.Size = new System.Drawing.Size(696, 232);
            this.OperationsDetailGridview.TabIndex = 149;
            // 
            // TransaccionId
            // 
            this.TransaccionId.DataPropertyName = "TransaccionId";
            this.TransaccionId.HeaderText = "*";
            this.TransaccionId.Name = "TransaccionId";
            this.TransaccionId.ReadOnly = true;
            this.TransaccionId.Width = 260;
            // 
            // DenominacionId_Nombre
            // 
            this.DenominacionId_Nombre.DataPropertyName = "DenominacionId.Nombre";
            this.DenominacionId_Nombre.HeaderText = "*";
            this.DenominacionId_Nombre.Name = "DenominacionId_Nombre";
            this.DenominacionId_Nombre.ReadOnly = true;
            this.DenominacionId_Nombre.Width = 110;
            // 
            // CantidadUnidades
            // 
            this.CantidadUnidades.DataPropertyName = "CantidadUnidades";
            this.CantidadUnidades.HeaderText = "*";
            this.CantidadUnidades.Name = "CantidadUnidades";
            this.CantidadUnidades.ReadOnly = true;
            this.CantidadUnidades.Width = 220;
            // 
            // OperationHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 616);
            this.Controls.Add(this.MainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OperationHistoryForm";
            this.Text = "OperationHistoryForm";
            this.Load += new System.EventHandler(this.OperationHistoryForm_Load);
            this.MainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OperationsHeaderGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OperationsDetailGridview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FlowLayoutPanel MainPanel;
        private DataGridView OperationsHeaderGridView;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn TotalValidado;
        private DataGridViewTextBoxColumn TotalAValidar;
        private DataGridViewButtonColumn PrintButtonColumn;
        private DataGridView OperationsDetailGridview;
        private DataGridViewTextBoxColumn TransaccionId;
        private DataGridViewTextBoxColumn DenominacionId_Nombre;
        private DataGridViewTextBoxColumn CantidadUnidades;
    }
}