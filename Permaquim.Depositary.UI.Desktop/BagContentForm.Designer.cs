namespace Permaquim.Depositary.UI.Desktop
{
    partial class BagContentForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.MainPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.BagContentTabControl = new System.Windows.Forms.TabControl();
            this.Billetes = new System.Windows.Forms.TabPage();
            this.BillDepositGridView = new System.Windows.Forms.DataGridView();
            this.EnvelopeDepositTabPage = new System.Windows.Forms.TabPage();
            this.EnvelopeDepositGridView = new System.Windows.Forms.DataGridView();
            this.BagContentTabControl.SuspendLayout();
            this.Billetes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BillDepositGridView)).BeginInit();
            this.EnvelopeDepositTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EnvelopeDepositGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.MainPanel.BackColor = System.Drawing.Color.Transparent;
            this.MainPanel.Location = new System.Drawing.Point(256, 496);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(264, 86);
            this.MainPanel.TabIndex = 188;
            // 
            // BagContentTabControl
            // 
            this.BagContentTabControl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BagContentTabControl.Controls.Add(this.Billetes);
            this.BagContentTabControl.Controls.Add(this.EnvelopeDepositTabPage);
            this.BagContentTabControl.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BagContentTabControl.Location = new System.Drawing.Point(8, 8);
            this.BagContentTabControl.Name = "BagContentTabControl";
            this.BagContentTabControl.SelectedIndex = 0;
            this.BagContentTabControl.Size = new System.Drawing.Size(776, 408);
            this.BagContentTabControl.TabIndex = 189;
            // 
            // Billetes
            // 
            this.Billetes.BackColor = System.Drawing.Color.Transparent;
            this.Billetes.Controls.Add(this.BillDepositGridView);
            this.Billetes.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Billetes.Location = new System.Drawing.Point(4, 39);
            this.Billetes.Name = "Billetes";
            this.Billetes.Padding = new System.Windows.Forms.Padding(3);
            this.Billetes.Size = new System.Drawing.Size(768, 365);
            this.Billetes.TabIndex = 0;
            this.Billetes.Text = "Billetes";
            // 
            // BillDepositGridView
            // 
            this.BillDepositGridView.AllowUserToAddRows = false;
            this.BillDepositGridView.AllowUserToDeleteRows = false;
            this.BillDepositGridView.AllowUserToResizeColumns = false;
            this.BillDepositGridView.AllowUserToResizeRows = false;
            this.BillDepositGridView.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BillDepositGridView.BackgroundColor = System.Drawing.Color.White;
            this.BillDepositGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.BillDepositGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.BillDepositGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.BillDepositGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.BillDepositGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.BillDepositGridView.DefaultCellStyle = dataGridViewCellStyle6;
            this.BillDepositGridView.EnableHeadersVisualStyles = false;
            this.BillDepositGridView.GridColor = System.Drawing.Color.White;
            this.BillDepositGridView.Location = new System.Drawing.Point(8, 10);
            this.BillDepositGridView.Name = "BillDepositGridView";
            this.BillDepositGridView.RowHeadersVisible = false;
            this.BillDepositGridView.RowTemplate.DividerHeight = 1;
            this.BillDepositGridView.RowTemplate.Height = 50;
            this.BillDepositGridView.RowTemplate.ReadOnly = true;
            this.BillDepositGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.BillDepositGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.BillDepositGridView.Size = new System.Drawing.Size(752, 344);
            this.BillDepositGridView.TabIndex = 186;
            this.BillDepositGridView.SelectionChanged += new System.EventHandler(this.BillDepositGridView_SelectionChanged);
            // 
            // EnvelopeDepositTabPage
            // 
            this.EnvelopeDepositTabPage.Controls.Add(this.EnvelopeDepositGridView);
            this.EnvelopeDepositTabPage.Location = new System.Drawing.Point(4, 39);
            this.EnvelopeDepositTabPage.Name = "EnvelopeDepositTabPage";
            this.EnvelopeDepositTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.EnvelopeDepositTabPage.Size = new System.Drawing.Size(768, 365);
            this.EnvelopeDepositTabPage.TabIndex = 1;
            this.EnvelopeDepositTabPage.Text = "Sobres";
            // 
            // EnvelopeDepositGridView
            // 
            this.EnvelopeDepositGridView.AllowUserToAddRows = false;
            this.EnvelopeDepositGridView.AllowUserToDeleteRows = false;
            this.EnvelopeDepositGridView.AllowUserToResizeColumns = false;
            this.EnvelopeDepositGridView.AllowUserToResizeRows = false;
            this.EnvelopeDepositGridView.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.EnvelopeDepositGridView.BackgroundColor = System.Drawing.Color.White;
            this.EnvelopeDepositGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.EnvelopeDepositGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.EnvelopeDepositGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.EnvelopeDepositGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.EnvelopeDepositGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.EnvelopeDepositGridView.DefaultCellStyle = dataGridViewCellStyle8;
            this.EnvelopeDepositGridView.EnableHeadersVisualStyles = false;
            this.EnvelopeDepositGridView.GridColor = System.Drawing.Color.White;
            this.EnvelopeDepositGridView.Location = new System.Drawing.Point(8, 10);
            this.EnvelopeDepositGridView.Name = "EnvelopeDepositGridView";
            this.EnvelopeDepositGridView.RowHeadersVisible = false;
            this.EnvelopeDepositGridView.RowTemplate.DividerHeight = 1;
            this.EnvelopeDepositGridView.RowTemplate.Height = 50;
            this.EnvelopeDepositGridView.RowTemplate.ReadOnly = true;
            this.EnvelopeDepositGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.EnvelopeDepositGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.EnvelopeDepositGridView.Size = new System.Drawing.Size(752, 344);
            this.EnvelopeDepositGridView.TabIndex = 187;
            this.EnvelopeDepositGridView.SelectionChanged += new System.EventHandler(this.EnvelopeDepositGridView_SelectionChanged);
            // 
            // BagContentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.BagContentTabControl);
            this.Controls.Add(this.MainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BagContentForm";
            this.Text = "BagContentForm";
            this.Load += new System.EventHandler(this.BagContentForm_Load);
            this.VisibleChanged += new System.EventHandler(this.BagContentForm_VisibleChanged);
            this.BagContentTabControl.ResumeLayout(false);
            this.Billetes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BillDepositGridView)).EndInit();
            this.EnvelopeDepositTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EnvelopeDepositGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Label InformationLabel;
        private DataGridViewTextBoxColumn Currency;
        private DataGridViewTextBoxColumn Type;
        private DataGridViewTextBoxColumn Validated;
        private FlowLayoutPanel MainPanel;
        private TabControl BagContentTabControl;
        private TabPage Billetes;
        private DataGridView BillDepositGridView;
        private TabPage EnvelopeDepositTabPage;
        private DataGridView EnvelopeDepositGridView;
    }
}