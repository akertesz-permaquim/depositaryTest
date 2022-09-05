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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.MainPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.BagContentTabControl = new System.Windows.Forms.TabControl();
            this.Billetes = new System.Windows.Forms.TabPage();
            this.BillDepositGridView = new System.Windows.Forms.DataGridView();
            this.EnvelopeDepositTabPage = new System.Windows.Forms.TabPage();
            this.EnvelopeDepositGridView = new System.Windows.Forms.DataGridView();
            this.DetailGridView = new System.Windows.Forms.DataGridView();
            this.AcceptButton = new Permaquim.Depositary.UI.Desktop.CustomButton();
            this.DetailLabel = new System.Windows.Forms.Label();
            this.DetailPanel = new System.Windows.Forms.Panel();
            this.BagContentTabControl.SuspendLayout();
            this.Billetes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BillDepositGridView)).BeginInit();
            this.EnvelopeDepositTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EnvelopeDepositGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DetailGridView)).BeginInit();
            this.DetailPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.MainPanel.BackColor = System.Drawing.Color.Transparent;
            this.MainPanel.Location = new System.Drawing.Point(264, 384);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(300, 55);
            this.MainPanel.TabIndex = 188;
            // 
            // BagContentTabControl
            // 
            this.BagContentTabControl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BagContentTabControl.Controls.Add(this.Billetes);
            this.BagContentTabControl.Controls.Add(this.EnvelopeDepositTabPage);
            this.BagContentTabControl.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BagContentTabControl.Location = new System.Drawing.Point(8, 24);
            this.BagContentTabControl.Name = "BagContentTabControl";
            this.BagContentTabControl.SelectedIndex = 0;
            this.BagContentTabControl.Size = new System.Drawing.Size(776, 360);
            this.BagContentTabControl.TabIndex = 189;
            this.BagContentTabControl.TabIndexChanged += new System.EventHandler(this.BagContentTabControl_TabIndexChanged);
            // 
            // Billetes
            // 
            this.Billetes.BackColor = System.Drawing.Color.Transparent;
            this.Billetes.Controls.Add(this.BillDepositGridView);
            this.Billetes.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Billetes.Location = new System.Drawing.Point(4, 39);
            this.Billetes.Name = "Billetes";
            this.Billetes.Padding = new System.Windows.Forms.Padding(3);
            this.Billetes.Size = new System.Drawing.Size(768, 317);
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.BillDepositGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.BillDepositGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.BillDepositGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.BillDepositGridView.EnableHeadersVisualStyles = false;
            this.BillDepositGridView.GridColor = System.Drawing.Color.White;
            this.BillDepositGridView.Location = new System.Drawing.Point(8, 8);
            this.BillDepositGridView.Name = "BillDepositGridView";
            this.BillDepositGridView.RowHeadersVisible = false;
            this.BillDepositGridView.RowTemplate.DividerHeight = 1;
            this.BillDepositGridView.RowTemplate.Height = 50;
            this.BillDepositGridView.RowTemplate.ReadOnly = true;
            this.BillDepositGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.BillDepositGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.BillDepositGridView.Size = new System.Drawing.Size(752, 296);
            this.BillDepositGridView.TabIndex = 186;
            this.BillDepositGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.BillDepositGridView_CellClick);
            this.BillDepositGridView.SelectionChanged += new System.EventHandler(this.BillDepositGridView_SelectionChanged);
            // 
            // EnvelopeDepositTabPage
            // 
            this.EnvelopeDepositTabPage.Controls.Add(this.EnvelopeDepositGridView);
            this.EnvelopeDepositTabPage.Location = new System.Drawing.Point(4, 39);
            this.EnvelopeDepositTabPage.Name = "EnvelopeDepositTabPage";
            this.EnvelopeDepositTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.EnvelopeDepositTabPage.Size = new System.Drawing.Size(768, 317);
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.EnvelopeDepositGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.EnvelopeDepositGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.EnvelopeDepositGridView.DefaultCellStyle = dataGridViewCellStyle4;
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
            this.EnvelopeDepositGridView.Size = new System.Drawing.Size(752, 294);
            this.EnvelopeDepositGridView.TabIndex = 187;
            this.EnvelopeDepositGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.EnvelopeDepositGridView_CellClick);
            this.EnvelopeDepositGridView.SelectionChanged += new System.EventHandler(this.EnvelopeDepositGridView_SelectionChanged);
            // 
            // detailGridView
            // 
            this.DetailGridView.AllowUserToAddRows = false;
            this.DetailGridView.AllowUserToDeleteRows = false;
            this.DetailGridView.AllowUserToResizeColumns = false;
            this.DetailGridView.AllowUserToResizeRows = false;
            this.DetailGridView.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DetailGridView.BackgroundColor = System.Drawing.Color.White;
            this.DetailGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DetailGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.DetailGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DetailGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.DetailGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DetailGridView.DefaultCellStyle = dataGridViewCellStyle6;
            this.DetailGridView.EnableHeadersVisualStyles = false;
            this.DetailGridView.GridColor = System.Drawing.Color.White;
            this.DetailGridView.Location = new System.Drawing.Point(7, 40);
            this.DetailGridView.Name = "detailGridView";
            this.DetailGridView.RowHeadersVisible = false;
            this.DetailGridView.RowTemplate.DividerHeight = 1;
            this.DetailGridView.RowTemplate.Height = 50;
            this.DetailGridView.RowTemplate.ReadOnly = true;
            this.DetailGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DetailGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DetailGridView.Size = new System.Drawing.Size(544, 267);
            this.DetailGridView.TabIndex = 187;
            // 
            // AcceptButton
            // 
            this.AcceptButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AcceptButton.BackColor = System.Drawing.Color.SteelBlue;
            this.AcceptButton.BackgroundColor = System.Drawing.Color.SteelBlue;
            this.AcceptButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.AcceptButton.BorderRadius = 5;
            this.AcceptButton.BorderSize = 0;
            this.AcceptButton.FlatAppearance.BorderSize = 0;
            this.AcceptButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AcceptButton.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.AcceptButton.ForeColor = System.Drawing.Color.White;
            this.AcceptButton.Location = new System.Drawing.Point(192, 312);
            this.AcceptButton.Name = "AcceptButton";
            this.AcceptButton.Size = new System.Drawing.Size(160, 55);
            this.AcceptButton.TabIndex = 188;
            this.AcceptButton.Text = "Salir";
            this.AcceptButton.TextColor = System.Drawing.Color.White;
            this.AcceptButton.UseVisualStyleBackColor = false;
            this.AcceptButton.Click += new System.EventHandler(this.AcceptButton_Click);
            // 
            // DetailLabel
            // 
            this.DetailLabel.BackColor = System.Drawing.Color.SteelBlue;
            this.DetailLabel.Font = new System.Drawing.Font("Verdana", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DetailLabel.ForeColor = System.Drawing.Color.White;
            this.DetailLabel.Location = new System.Drawing.Point(8, 8);
            this.DetailLabel.Name = "DetailLabel";
            this.DetailLabel.Size = new System.Drawing.Size(544, 27);
            this.DetailLabel.TabIndex = 189;
            this.DetailLabel.Text = "*";
            // 
            // detailPanel
            // 
            this.DetailPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DetailPanel.Controls.Add(this.DetailLabel);
            this.DetailPanel.Controls.Add(this.AcceptButton);
            this.DetailPanel.Controls.Add(this.DetailGridView);
            this.DetailPanel.Location = new System.Drawing.Point(112, 56);
            this.DetailPanel.Name = "detailPanel";
            this.DetailPanel.Size = new System.Drawing.Size(560, 376);
            this.DetailPanel.TabIndex = 190;
            this.DetailPanel.Visible = false;
            // 
            // BagContentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 637);
            this.Controls.Add(this.DetailPanel);
            this.Controls.Add(this.BagContentTabControl);
            this.Controls.Add(this.MainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BagContentForm";
            this.Text = "BagContentForm";
            this.Load += new System.EventHandler(this.BagContentForm_Load);
            this.VisibleChanged += new System.EventHandler(this.BagContentForm_VisibleChanged);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BagContentForm_MouseClick);
            this.BagContentTabControl.ResumeLayout(false);
            this.Billetes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BillDepositGridView)).EndInit();
            this.EnvelopeDepositTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EnvelopeDepositGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DetailGridView)).EndInit();
            this.DetailPanel.ResumeLayout(false);
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
        private DataGridView DetailGridView;
        private CustomButton AcceptButton;
        private Label DetailLabel;
        private Panel DetailPanel;
    }
}