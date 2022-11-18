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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.BagContentTabControl = new System.Windows.Forms.TabControl();
            this.Billetes = new System.Windows.Forms.TabPage();
            this.BillDepositGridView = new System.Windows.Forms.DataGridView();
            this.EnvelopeDepositTabPage = new System.Windows.Forms.TabPage();
            this.EnvelopeDepositGridView = new System.Windows.Forms.DataGridView();
            this.DetailGridView = new System.Windows.Forms.DataGridView();
            this.AcceptButton = new System.Windows.Forms.Button();
            this.DetailLabel = new System.Windows.Forms.Label();
            this.DetailPanel = new System.Windows.Forms.Panel();
            this.BackButton = new System.Windows.Forms.Button();
            this.InformationLabel = new System.Windows.Forms.Label();
            this.BagContentTabControl.SuspendLayout();
            this.Billetes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BillDepositGridView)).BeginInit();
            this.EnvelopeDepositTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EnvelopeDepositGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DetailGridView)).BeginInit();
            this.DetailPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // BagContentTabControl
            // 
            this.BagContentTabControl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BagContentTabControl.Controls.Add(this.Billetes);
            this.BagContentTabControl.Controls.Add(this.EnvelopeDepositTabPage);
            this.BagContentTabControl.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BagContentTabControl.Location = new System.Drawing.Point(83, 56);
            this.BagContentTabControl.Name = "BagContentTabControl";
            this.BagContentTabControl.SelectedIndex = 0;
            this.BagContentTabControl.Size = new System.Drawing.Size(776, 384);
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
            this.Billetes.Size = new System.Drawing.Size(768, 341);
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
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.BillDepositGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.BillDepositGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.BillDepositGridView.DefaultCellStyle = dataGridViewCellStyle8;
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
            this.BillDepositGridView.Size = new System.Drawing.Size(752, 328);
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
            this.EnvelopeDepositTabPage.Size = new System.Drawing.Size(768, 341);
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
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.EnvelopeDepositGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.EnvelopeDepositGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.EnvelopeDepositGridView.DefaultCellStyle = dataGridViewCellStyle10;
            this.EnvelopeDepositGridView.EnableHeadersVisualStyles = false;
            this.EnvelopeDepositGridView.GridColor = System.Drawing.Color.White;
            this.EnvelopeDepositGridView.Location = new System.Drawing.Point(8, 7);
            this.EnvelopeDepositGridView.Name = "EnvelopeDepositGridView";
            this.EnvelopeDepositGridView.RowHeadersVisible = false;
            this.EnvelopeDepositGridView.RowTemplate.DividerHeight = 1;
            this.EnvelopeDepositGridView.RowTemplate.Height = 50;
            this.EnvelopeDepositGridView.RowTemplate.ReadOnly = true;
            this.EnvelopeDepositGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.EnvelopeDepositGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.EnvelopeDepositGridView.Size = new System.Drawing.Size(752, 326);
            this.EnvelopeDepositGridView.TabIndex = 187;
            this.EnvelopeDepositGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.EnvelopeDepositGridView_CellClick);
            this.EnvelopeDepositGridView.SelectionChanged += new System.EventHandler(this.EnvelopeDepositGridView_SelectionChanged);
            // 
            // DetailGridView
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
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DetailGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.DetailGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DetailGridView.DefaultCellStyle = dataGridViewCellStyle12;
            this.DetailGridView.EnableHeadersVisualStyles = false;
            this.DetailGridView.GridColor = System.Drawing.Color.White;
            this.DetailGridView.Location = new System.Drawing.Point(8, 40);
            this.DetailGridView.Name = "DetailGridView";
            this.DetailGridView.RowHeadersVisible = false;
            this.DetailGridView.RowTemplate.DividerHeight = 1;
            this.DetailGridView.RowTemplate.Height = 50;
            this.DetailGridView.RowTemplate.ReadOnly = true;
            this.DetailGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DetailGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DetailGridView.Size = new System.Drawing.Size(631, 267);
            this.DetailGridView.TabIndex = 187;
            this.DetailGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DetailGridView_CellClick);
            // 
            // AcceptButton
            // 
            this.AcceptButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AcceptButton.BackColor = System.Drawing.Color.SteelBlue;
            this.AcceptButton.FlatAppearance.BorderSize = 0;
            this.AcceptButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AcceptButton.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.AcceptButton.ForeColor = System.Drawing.Color.White;
            this.AcceptButton.Location = new System.Drawing.Point(236, 312);
            this.AcceptButton.Name = "AcceptButton";
            this.AcceptButton.Size = new System.Drawing.Size(160, 55);
            this.AcceptButton.TabIndex = 188;
            this.AcceptButton.Text = "Salir";
            this.AcceptButton.UseVisualStyleBackColor = false;
            this.AcceptButton.Click += new System.EventHandler(this.AcceptButton_Click);
            // 
            // DetailLabel
            // 
            this.DetailLabel.BackColor = System.Drawing.Color.SteelBlue;
            this.DetailLabel.Font = new System.Drawing.Font("Verdana", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DetailLabel.ForeColor = System.Drawing.Color.White;
            this.DetailLabel.Location = new System.Drawing.Point(7, 8);
            this.DetailLabel.Name = "DetailLabel";
            this.DetailLabel.Size = new System.Drawing.Size(631, 27);
            this.DetailLabel.TabIndex = 189;
            this.DetailLabel.Text = "*";
            this.DetailLabel.Click += new System.EventHandler(this.DetailLabel_Click);
            // 
            // DetailPanel
            // 
            this.DetailPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DetailPanel.Controls.Add(this.AcceptButton);
            this.DetailPanel.Controls.Add(this.DetailLabel);
            this.DetailPanel.Controls.Add(this.DetailGridView);
            this.DetailPanel.Location = new System.Drawing.Point(264, 64);
            this.DetailPanel.Name = "DetailPanel";
            this.DetailPanel.Size = new System.Drawing.Size(648, 376);
            this.DetailPanel.TabIndex = 190;
            this.DetailPanel.Visible = false;
            // 
            // BackButton
            // 
            this.BackButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BackButton.BackColor = System.Drawing.Color.SteelBlue;
            this.BackButton.FlatAppearance.BorderSize = 0;
            this.BackButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackButton.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BackButton.ForeColor = System.Drawing.Color.White;
            this.BackButton.Location = new System.Drawing.Point(353, 472);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(240, 55);
            this.BackButton.TabIndex = 196;
            this.BackButton.Text = "Salir";
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // InformationLabel
            // 
            this.InformationLabel.BackColor = System.Drawing.Color.Transparent;
            this.InformationLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.InformationLabel.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.InformationLabel.ForeColor = System.Drawing.Color.Silver;
            this.InformationLabel.Location = new System.Drawing.Point(0, 0);
            this.InformationLabel.Name = "InformationLabel";
            this.InformationLabel.Size = new System.Drawing.Size(950, 42);
            this.InformationLabel.TabIndex = 197;
            this.InformationLabel.Text = "...";
            this.InformationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BagContentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 600);
            this.Controls.Add(this.InformationLabel);
            this.Controls.Add(this.DetailPanel);
            this.Controls.Add(this.BagContentTabControl);
            this.Controls.Add(this.BackButton);
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
        private TabControl BagContentTabControl;
        private TabPage Billetes;
        private DataGridView BillDepositGridView;
        private TabPage EnvelopeDepositTabPage;
        private DataGridView EnvelopeDepositGridView;
        private DataGridView DetailGridView;
        private System.Windows.Forms.Button AcceptButton;
        private Label DetailLabel;
        private Panel DetailPanel;
        private System.Windows.Forms.Button BackButton;
    }
}