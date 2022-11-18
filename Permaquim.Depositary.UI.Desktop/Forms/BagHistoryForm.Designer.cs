namespace Permaquim.Depositary.UI.Desktop
{
    partial class BagHistoryForm
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
            this.MainGridView = new System.Windows.Forms.DataGridView();
            this.FilterPanel = new System.Windows.Forms.Panel();
            this.ToFechaCierreDateTimeLabel = new System.Windows.Forms.Label();
            this.ToFechaCierreDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.FromFechaCierreDateTimeLabel = new System.Windows.Forms.Label();
            this.FromFechaCierreDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.ExecuteBagHistorySearch = new System.Windows.Forms.Button();
            this.IdentificadorTextbox = new System.Windows.Forms.TextBox();
            this.IdentificadorLabel = new System.Windows.Forms.Label();
            this.FromFechaAperturaDateTimeLabel = new System.Windows.Forms.Label();
            this.ToFechaAperturaDateTimeLabel = new System.Windows.Forms.Label();
            this.ToFechaAperturaDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.FromFechaAperturaDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.ExecuteButton = new System.Windows.Forms.Button();
            this.DetailPanel = new System.Windows.Forms.Panel();
            this.BagContentTabControl = new System.Windows.Forms.TabControl();
            this.Billetes = new System.Windows.Forms.TabPage();
            this.BillDepositGridView = new System.Windows.Forms.DataGridView();
            this.EnvelopeDepositTabPage = new System.Windows.Forms.TabPage();
            this.EnvelopeDepositGridView = new System.Windows.Forms.DataGridView();
            this.PrintButton = new System.Windows.Forms.Button();
            this.AcceptButton = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MainGridView)).BeginInit();
            this.FilterPanel.SuspendLayout();
            this.DetailPanel.SuspendLayout();
            this.BagContentTabControl.SuspendLayout();
            this.Billetes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BillDepositGridView)).BeginInit();
            this.EnvelopeDepositTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EnvelopeDepositGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // MainGridView
            // 
            this.MainGridView.AllowUserToAddRows = false;
            this.MainGridView.AllowUserToDeleteRows = false;
            this.MainGridView.AllowUserToResizeColumns = false;
            this.MainGridView.AllowUserToResizeRows = false;
            this.MainGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.MainGridView.BackgroundColor = System.Drawing.Color.White;
            this.MainGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MainGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.MainGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.MainGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.MainGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.MainGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.MainGridView.EnableHeadersVisualStyles = false;
            this.MainGridView.GridColor = System.Drawing.Color.White;
            this.MainGridView.Location = new System.Drawing.Point(12, 107);
            this.MainGridView.Name = "MainGridView";
            this.MainGridView.RowHeadersVisible = false;
            this.MainGridView.RowTemplate.DividerHeight = 1;
            this.MainGridView.RowTemplate.Height = 30;
            this.MainGridView.RowTemplate.ReadOnly = true;
            this.MainGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.MainGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.MainGridView.Size = new System.Drawing.Size(1022, 368);
            this.MainGridView.TabIndex = 192;
            this.MainGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MainGridView_CellClick);
            this.MainGridView.Click += new System.EventHandler(this.MainGridView_Click);
            // 
            // FilterPanel
            // 
            this.FilterPanel.Controls.Add(this.ToFechaCierreDateTimeLabel);
            this.FilterPanel.Controls.Add(this.ToFechaCierreDateTimePicker);
            this.FilterPanel.Controls.Add(this.FromFechaCierreDateTimeLabel);
            this.FilterPanel.Controls.Add(this.FromFechaCierreDateTimePicker);
            this.FilterPanel.Controls.Add(this.ExecuteBagHistorySearch);
            this.FilterPanel.Controls.Add(this.IdentificadorTextbox);
            this.FilterPanel.Controls.Add(this.IdentificadorLabel);
            this.FilterPanel.Controls.Add(this.FromFechaAperturaDateTimeLabel);
            this.FilterPanel.Controls.Add(this.ToFechaAperturaDateTimeLabel);
            this.FilterPanel.Controls.Add(this.ToFechaAperturaDateTimePicker);
            this.FilterPanel.Controls.Add(this.FromFechaAperturaDateTimePicker);
            this.FilterPanel.Controls.Add(this.ExecuteButton);
            this.FilterPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.FilterPanel.Location = new System.Drawing.Point(0, 0);
            this.FilterPanel.Name = "FilterPanel";
            this.FilterPanel.Size = new System.Drawing.Size(1048, 88);
            this.FilterPanel.TabIndex = 193;
            // 
            // ToFechaCierreDateTimeLabel
            // 
            this.ToFechaCierreDateTimeLabel.BackColor = System.Drawing.Color.SteelBlue;
            this.ToFechaCierreDateTimeLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ToFechaCierreDateTimeLabel.ForeColor = System.Drawing.Color.White;
            this.ToFechaCierreDateTimeLabel.Location = new System.Drawing.Point(540, 12);
            this.ToFechaCierreDateTimeLabel.Name = "ToFechaCierreDateTimeLabel";
            this.ToFechaCierreDateTimeLabel.Size = new System.Drawing.Size(170, 27);
            this.ToFechaCierreDateTimeLabel.TabIndex = 210;
            this.ToFechaCierreDateTimeLabel.Text = "*";
            // 
            // ToFechaCierreDateTimePicker
            // 
            this.ToFechaCierreDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ToFechaCierreDateTimePicker.Location = new System.Drawing.Point(540, 44);
            this.ToFechaCierreDateTimePicker.Name = "ToFechaCierreDateTimePicker";
            this.ToFechaCierreDateTimePicker.ShowCheckBox = true;
            this.ToFechaCierreDateTimePicker.Size = new System.Drawing.Size(170, 23);
            this.ToFechaCierreDateTimePicker.TabIndex = 209;
            this.ToFechaCierreDateTimePicker.ValueChanged += new System.EventHandler(this.ToFechaCierreDateTimePicker_ValueChanged);
            // 
            // FromFechaCierreDateTimeLabel
            // 
            this.FromFechaCierreDateTimeLabel.BackColor = System.Drawing.Color.SteelBlue;
            this.FromFechaCierreDateTimeLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FromFechaCierreDateTimeLabel.ForeColor = System.Drawing.Color.White;
            this.FromFechaCierreDateTimeLabel.Location = new System.Drawing.Point(364, 12);
            this.FromFechaCierreDateTimeLabel.Name = "FromFechaCierreDateTimeLabel";
            this.FromFechaCierreDateTimeLabel.Size = new System.Drawing.Size(170, 27);
            this.FromFechaCierreDateTimeLabel.TabIndex = 208;
            this.FromFechaCierreDateTimeLabel.Text = "*";
            // 
            // FromFechaCierreDateTimePicker
            // 
            this.FromFechaCierreDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.FromFechaCierreDateTimePicker.Location = new System.Drawing.Point(364, 44);
            this.FromFechaCierreDateTimePicker.Name = "FromFechaCierreDateTimePicker";
            this.FromFechaCierreDateTimePicker.ShowCheckBox = true;
            this.FromFechaCierreDateTimePicker.Size = new System.Drawing.Size(170, 23);
            this.FromFechaCierreDateTimePicker.TabIndex = 207;
            this.FromFechaCierreDateTimePicker.ValueChanged += new System.EventHandler(this.FromFechaCierreDateTimePicker_ValueChanged);
            // 
            // ExecuteBagHistorySearch
            // 
            this.ExecuteBagHistorySearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ExecuteBagHistorySearch.BackColor = System.Drawing.Color.SteelBlue;
            this.ExecuteBagHistorySearch.FlatAppearance.BorderSize = 0;
            this.ExecuteBagHistorySearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExecuteBagHistorySearch.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ExecuteBagHistorySearch.ForeColor = System.Drawing.Color.White;
            this.ExecuteBagHistorySearch.Location = new System.Drawing.Point(888, 8);
            this.ExecuteBagHistorySearch.Name = "ExecuteBagHistorySearch";
            this.ExecuteBagHistorySearch.Size = new System.Drawing.Size(128, 64);
            this.ExecuteBagHistorySearch.TabIndex = 213;
            this.ExecuteBagHistorySearch.Text = "***";
            this.ExecuteBagHistorySearch.UseVisualStyleBackColor = false;
            this.ExecuteBagHistorySearch.Click += new System.EventHandler(this.ExecuteBagHistorySearch_Click);
            // 
            // IdentificadorTextbox
            // 
            this.IdentificadorTextbox.Location = new System.Drawing.Point(716, 44);
            this.IdentificadorTextbox.Name = "IdentificadorTextbox";
            this.IdentificadorTextbox.Size = new System.Drawing.Size(134, 23);
            this.IdentificadorTextbox.TabIndex = 212;
            this.IdentificadorTextbox.TextChanged += new System.EventHandler(this.IdentificadorTextbox_TextChanged);
            // 
            // IdentificadorLabel
            // 
            this.IdentificadorLabel.BackColor = System.Drawing.Color.SteelBlue;
            this.IdentificadorLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.IdentificadorLabel.ForeColor = System.Drawing.Color.White;
            this.IdentificadorLabel.Location = new System.Drawing.Point(716, 12);
            this.IdentificadorLabel.Name = "IdentificadorLabel";
            this.IdentificadorLabel.Size = new System.Drawing.Size(134, 27);
            this.IdentificadorLabel.TabIndex = 211;
            this.IdentificadorLabel.Text = "*";
            // 
            // FromFechaAperturaDateTimeLabel
            // 
            this.FromFechaAperturaDateTimeLabel.BackColor = System.Drawing.Color.SteelBlue;
            this.FromFechaAperturaDateTimeLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FromFechaAperturaDateTimeLabel.ForeColor = System.Drawing.Color.White;
            this.FromFechaAperturaDateTimeLabel.Location = new System.Drawing.Point(12, 12);
            this.FromFechaAperturaDateTimeLabel.Name = "FromFechaAperturaDateTimeLabel";
            this.FromFechaAperturaDateTimeLabel.Size = new System.Drawing.Size(170, 27);
            this.FromFechaAperturaDateTimeLabel.TabIndex = 204;
            this.FromFechaAperturaDateTimeLabel.Text = "*";
            // 
            // ToFechaAperturaDateTimeLabel
            // 
            this.ToFechaAperturaDateTimeLabel.BackColor = System.Drawing.Color.SteelBlue;
            this.ToFechaAperturaDateTimeLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ToFechaAperturaDateTimeLabel.ForeColor = System.Drawing.Color.White;
            this.ToFechaAperturaDateTimeLabel.Location = new System.Drawing.Point(188, 12);
            this.ToFechaAperturaDateTimeLabel.Name = "ToFechaAperturaDateTimeLabel";
            this.ToFechaAperturaDateTimeLabel.Size = new System.Drawing.Size(170, 27);
            this.ToFechaAperturaDateTimeLabel.TabIndex = 206;
            this.ToFechaAperturaDateTimeLabel.Text = "*";
            // 
            // ToFechaAperturaDateTimePicker
            // 
            this.ToFechaAperturaDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ToFechaAperturaDateTimePicker.Location = new System.Drawing.Point(188, 44);
            this.ToFechaAperturaDateTimePicker.Name = "ToFechaAperturaDateTimePicker";
            this.ToFechaAperturaDateTimePicker.Size = new System.Drawing.Size(170, 23);
            this.ToFechaAperturaDateTimePicker.TabIndex = 205;
            this.ToFechaAperturaDateTimePicker.ValueChanged += new System.EventHandler(this.ToFechaAperturaDateTimePicker_ValueChanged);
            // 
            // FromFechaAperturaDateTimePicker
            // 
            this.FromFechaAperturaDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FromFechaAperturaDateTimePicker.Location = new System.Drawing.Point(12, 44);
            this.FromFechaAperturaDateTimePicker.Name = "FromFechaAperturaDateTimePicker";
            this.FromFechaAperturaDateTimePicker.Size = new System.Drawing.Size(170, 23);
            this.FromFechaAperturaDateTimePicker.TabIndex = 203;
            this.FromFechaAperturaDateTimePicker.ValueChanged += new System.EventHandler(this.FromFechaAperturaDateTimePicker_ValueChanged);
            // 
            // ExecuteButton
            // 
            this.ExecuteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ExecuteButton.BackColor = System.Drawing.Color.SteelBlue;
            this.ExecuteButton.FlatAppearance.BorderSize = 0;
            this.ExecuteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExecuteButton.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ExecuteButton.ForeColor = System.Drawing.Color.White;
            this.ExecuteButton.Location = new System.Drawing.Point(1446, 8);
            this.ExecuteButton.Name = "ExecuteButton";
            this.ExecuteButton.Size = new System.Drawing.Size(128, 64);
            this.ExecuteButton.TabIndex = 197;
            this.ExecuteButton.Text = "***";
            this.ExecuteButton.UseVisualStyleBackColor = false;
            // 
            // DetailPanel
            // 
            this.DetailPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DetailPanel.Controls.Add(this.BagContentTabControl);
            this.DetailPanel.Controls.Add(this.PrintButton);
            this.DetailPanel.Controls.Add(this.AcceptButton);
            this.DetailPanel.Location = new System.Drawing.Point(56, 104);
            this.DetailPanel.Name = "DetailPanel";
            this.DetailPanel.Size = new System.Drawing.Size(784, 488);
            this.DetailPanel.TabIndex = 194;
            this.DetailPanel.Visible = false;
            this.DetailPanel.Click += new System.EventHandler(this.DetailPanel_Click);
            // 
            // BagContentTabControl
            // 
            this.BagContentTabControl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BagContentTabControl.Controls.Add(this.Billetes);
            this.BagContentTabControl.Controls.Add(this.EnvelopeDepositTabPage);
            this.BagContentTabControl.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BagContentTabControl.Location = new System.Drawing.Point(3, 8);
            this.BagContentTabControl.Name = "BagContentTabControl";
            this.BagContentTabControl.SelectedIndex = 0;
            this.BagContentTabControl.Size = new System.Drawing.Size(776, 384);
            this.BagContentTabControl.TabIndex = 190;
            this.BagContentTabControl.Click += new System.EventHandler(this.BagContentTabControl_Click);
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.BillDepositGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.BillDepositGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.BillDepositGridView.DefaultCellStyle = dataGridViewCellStyle4;
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
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.EnvelopeDepositGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.EnvelopeDepositGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.EnvelopeDepositGridView.DefaultCellStyle = dataGridViewCellStyle6;
            this.EnvelopeDepositGridView.EnableHeadersVisualStyles = false;
            this.EnvelopeDepositGridView.GridColor = System.Drawing.Color.White;
            this.EnvelopeDepositGridView.Location = new System.Drawing.Point(8, 8);
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
            // 
            // PrintButton
            // 
            this.PrintButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PrintButton.BackColor = System.Drawing.Color.SteelBlue;
            this.PrintButton.FlatAppearance.BorderSize = 0;
            this.PrintButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PrintButton.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.PrintButton.ForeColor = System.Drawing.Color.White;
            this.PrintButton.Location = new System.Drawing.Point(424, 408);
            this.PrintButton.Name = "PrintButton";
            this.PrintButton.Size = new System.Drawing.Size(160, 55);
            this.PrintButton.TabIndex = 185;
            this.PrintButton.Text = "Imprimir";
            this.PrintButton.UseVisualStyleBackColor = false;
            this.PrintButton.Click += new System.EventHandler(this.PrintButton_Click);
            // 
            // AcceptButton
            // 
            this.AcceptButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AcceptButton.BackColor = System.Drawing.Color.SteelBlue;
            this.AcceptButton.FlatAppearance.BorderSize = 0;
            this.AcceptButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AcceptButton.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.AcceptButton.ForeColor = System.Drawing.Color.White;
            this.AcceptButton.Location = new System.Drawing.Point(176, 408);
            this.AcceptButton.Name = "AcceptButton";
            this.AcceptButton.Size = new System.Drawing.Size(160, 55);
            this.AcceptButton.TabIndex = 184;
            this.AcceptButton.Text = "Salir";
            this.AcceptButton.UseVisualStyleBackColor = false;
            this.AcceptButton.Click += new System.EventHandler(this.AcceptButton_Click);
            // 
            // BackButton
            // 
            this.BackButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BackButton.BackColor = System.Drawing.Color.SteelBlue;
            this.BackButton.FlatAppearance.BorderSize = 0;
            this.BackButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackButton.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BackButton.ForeColor = System.Drawing.Color.White;
            this.BackButton.Location = new System.Drawing.Point(377, 512);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(240, 55);
            this.BackButton.TabIndex = 195;
            this.BackButton.Text = "Salir";
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // BagHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 600);
            this.Controls.Add(this.DetailPanel);
            this.Controls.Add(this.FilterPanel);
            this.Controls.Add(this.MainGridView);
            this.Controls.Add(this.BackButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BagHistoryForm";
            this.Text = "BagHistoryForm";
            this.Load += new System.EventHandler(this.BagHistoryForm_Load);
            this.VisibleChanged += new System.EventHandler(this.BagHistoryForm_VisibleChanged);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BagHistoryForm_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.MainGridView)).EndInit();
            this.FilterPanel.ResumeLayout(false);
            this.FilterPanel.PerformLayout();
            this.DetailPanel.ResumeLayout(false);
            this.BagContentTabControl.ResumeLayout(false);
            this.Billetes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BillDepositGridView)).EndInit();
            this.EnvelopeDepositTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EnvelopeDepositGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FlowLayoutPanel MainPanel;
        private DataGridView MainGridView;
        private Panel FilterPanel;
        private System.Windows.Forms.Button ExecuteButton;
        private Label IdentificadorLabel;
        private Label ToFechaCierreDateTimeLabel;
        private DateTimePicker ToFechaCierreDateTimePicker;
        private Label FromFechaCierreDateTimeLabel;
        private DateTimePicker FromFechaCierreDateTimePicker;
        private Label ToFechaAperturaDateTimeLabel;
        private DateTimePicker ToFechaAperturaDateTimePicker;
        private Label FromFechaAperturaDateTimeLabel;
        private DateTimePicker FromFechaAperturaDateTimePicker;
        private TextBox IdentificadorTextbox;
        private System.Windows.Forms.Button ExecuteBagHistorySearch;
        private Panel DetailPanel;
        private System.Windows.Forms.Button PrintButton;
        private System.Windows.Forms.Button AcceptButton;
        private TabControl BagContentTabControl;
        private TabPage Billetes;
        private DataGridView BillDepositGridView;
        private TabPage EnvelopeDepositTabPage;
        private DataGridView EnvelopeDepositGridView;
        private System.Windows.Forms.Button BackButton;
    }
}