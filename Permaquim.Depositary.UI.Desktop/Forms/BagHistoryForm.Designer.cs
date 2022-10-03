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
            this.MainPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.MainGridView = new System.Windows.Forms.DataGridView();
            this.FilterPanel = new System.Windows.Forms.Panel();
            this.ExecuteBagHistorySearch = new Permaquim.Depositary.UI.Desktop.CustomButton();
            this.IdentificadorTextbox = new System.Windows.Forms.TextBox();
            this.IdentificadorLabel = new System.Windows.Forms.Label();
            this.FromFechaAperturaDateTimeLabel = new System.Windows.Forms.Label();
            this.FromFechaAperturaDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.ToFechaCierreDateTimeLabel = new System.Windows.Forms.Label();
            this.ToFechaCierreDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.FromFechaCierreDateTimeLabel = new System.Windows.Forms.Label();
            this.FromFechaCierreDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.ToFechaAperturaDateTimeLabel = new System.Windows.Forms.Label();
            this.ToFechaAperturaDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.ExecuteButton = new Permaquim.Depositary.UI.Desktop.CustomButton();
            ((System.ComponentModel.ISupportInitialize)(this.MainGridView)).BeginInit();
            this.FilterPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.MainPanel.BackColor = System.Drawing.Color.Transparent;
            this.MainPanel.Location = new System.Drawing.Point(319, 500);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(320, 88);
            this.MainPanel.TabIndex = 191;
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
            this.MainGridView.Size = new System.Drawing.Size(924, 368);
            this.MainGridView.TabIndex = 192;
            this.MainGridView.Click += new System.EventHandler(this.MainGridView_Click);
            // 
            // FilterPanel
            // 
            this.FilterPanel.Controls.Add(this.ExecuteBagHistorySearch);
            this.FilterPanel.Controls.Add(this.IdentificadorTextbox);
            this.FilterPanel.Controls.Add(this.IdentificadorLabel);
            this.FilterPanel.Controls.Add(this.FromFechaAperturaDateTimeLabel);
            this.FilterPanel.Controls.Add(this.FromFechaAperturaDateTimePicker);
            this.FilterPanel.Controls.Add(this.ToFechaCierreDateTimeLabel);
            this.FilterPanel.Controls.Add(this.ToFechaCierreDateTimePicker);
            this.FilterPanel.Controls.Add(this.FromFechaCierreDateTimeLabel);
            this.FilterPanel.Controls.Add(this.FromFechaCierreDateTimePicker);
            this.FilterPanel.Controls.Add(this.ToFechaAperturaDateTimeLabel);
            this.FilterPanel.Controls.Add(this.ToFechaAperturaDateTimePicker);
            this.FilterPanel.Controls.Add(this.ExecuteButton);
            this.FilterPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.FilterPanel.Location = new System.Drawing.Point(0, 0);
            this.FilterPanel.Name = "FilterPanel";
            this.FilterPanel.Size = new System.Drawing.Size(950, 88);
            this.FilterPanel.TabIndex = 193;
            // 
            // ExecuteBagHistorySearch
            // 
            this.ExecuteBagHistorySearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ExecuteBagHistorySearch.BackColor = System.Drawing.Color.SteelBlue;
            this.ExecuteBagHistorySearch.BackgroundColor = System.Drawing.Color.SteelBlue;
            this.ExecuteBagHistorySearch.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.ExecuteBagHistorySearch.BorderRadius = 5;
            this.ExecuteBagHistorySearch.BorderSize = 0;
            this.ExecuteBagHistorySearch.FlatAppearance.BorderSize = 0;
            this.ExecuteBagHistorySearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExecuteBagHistorySearch.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ExecuteBagHistorySearch.ForeColor = System.Drawing.Color.White;
            this.ExecuteBagHistorySearch.Location = new System.Drawing.Point(810, 12);
            this.ExecuteBagHistorySearch.Name = "ExecuteBagHistorySearch";
            this.ExecuteBagHistorySearch.Size = new System.Drawing.Size(128, 64);
            this.ExecuteBagHistorySearch.TabIndex = 213;
            this.ExecuteBagHistorySearch.Text = "***";
            this.ExecuteBagHistorySearch.TextColor = System.Drawing.Color.White;
            this.ExecuteBagHistorySearch.UseVisualStyleBackColor = false;
            // 
            // IdentificadorTextbox
            // 
            this.IdentificadorTextbox.Location = new System.Drawing.Point(604, 44);
            this.IdentificadorTextbox.Name = "IdentificadorTextbox";
            this.IdentificadorTextbox.Size = new System.Drawing.Size(145, 23);
            this.IdentificadorTextbox.TabIndex = 212;
            // 
            // IdentificadorLabel
            // 
            this.IdentificadorLabel.BackColor = System.Drawing.Color.SteelBlue;
            this.IdentificadorLabel.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.IdentificadorLabel.ForeColor = System.Drawing.Color.White;
            this.IdentificadorLabel.Location = new System.Drawing.Point(604, 12);
            this.IdentificadorLabel.Name = "IdentificadorLabel";
            this.IdentificadorLabel.Size = new System.Drawing.Size(145, 27);
            this.IdentificadorLabel.TabIndex = 211;
            this.IdentificadorLabel.Text = "*";
            // 
            // FromFechaAperturaDateTimeLabel
            // 
            this.FromFechaAperturaDateTimeLabel.BackColor = System.Drawing.Color.SteelBlue;
            this.FromFechaAperturaDateTimeLabel.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FromFechaAperturaDateTimeLabel.ForeColor = System.Drawing.Color.White;
            this.FromFechaAperturaDateTimeLabel.Location = new System.Drawing.Point(12, 12);
            this.FromFechaAperturaDateTimeLabel.Name = "FromFechaAperturaDateTimeLabel";
            this.FromFechaAperturaDateTimeLabel.Size = new System.Drawing.Size(142, 27);
            this.FromFechaAperturaDateTimeLabel.TabIndex = 204;
            this.FromFechaAperturaDateTimeLabel.Text = "*";
            // 
            // FromFechaAperturaDateTimePicker
            // 
            this.FromFechaAperturaDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FromFechaAperturaDateTimePicker.Location = new System.Drawing.Point(12, 44);
            this.FromFechaAperturaDateTimePicker.Name = "FromFechaAperturaDateTimePicker";
            this.FromFechaAperturaDateTimePicker.Size = new System.Drawing.Size(142, 23);
            this.FromFechaAperturaDateTimePicker.TabIndex = 203;
            // 
            // ToFechaCierreDateTimeLabel
            // 
            this.ToFechaCierreDateTimeLabel.BackColor = System.Drawing.Color.SteelBlue;
            this.ToFechaCierreDateTimeLabel.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ToFechaCierreDateTimeLabel.ForeColor = System.Drawing.Color.White;
            this.ToFechaCierreDateTimeLabel.Location = new System.Drawing.Point(456, 12);
            this.ToFechaCierreDateTimeLabel.Name = "ToFechaCierreDateTimeLabel";
            this.ToFechaCierreDateTimeLabel.Size = new System.Drawing.Size(142, 27);
            this.ToFechaCierreDateTimeLabel.TabIndex = 210;
            this.ToFechaCierreDateTimeLabel.Text = "*";
            // 
            // ToFechaCierreDateTimePicker
            // 
            this.ToFechaCierreDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ToFechaCierreDateTimePicker.Location = new System.Drawing.Point(456, 44);
            this.ToFechaCierreDateTimePicker.Name = "ToFechaCierreDateTimePicker";
            this.ToFechaCierreDateTimePicker.ShowCheckBox = true;
            this.ToFechaCierreDateTimePicker.Size = new System.Drawing.Size(142, 23);
            this.ToFechaCierreDateTimePicker.TabIndex = 209;
            this.ToFechaCierreDateTimePicker.ValueChanged += new System.EventHandler(this.ToFechaCierreDateTimePicker_ValueChanged);
            this.ToFechaCierreDateTimePicker.EnabledChanged += new System.EventHandler(this.ToFechaCierreDateTimePicker_EnabledChanged);
            // 
            // FromFechaCierreDateTimeLabel
            // 
            this.FromFechaCierreDateTimeLabel.BackColor = System.Drawing.Color.SteelBlue;
            this.FromFechaCierreDateTimeLabel.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FromFechaCierreDateTimeLabel.ForeColor = System.Drawing.Color.White;
            this.FromFechaCierreDateTimeLabel.Location = new System.Drawing.Point(308, 12);
            this.FromFechaCierreDateTimeLabel.Name = "FromFechaCierreDateTimeLabel";
            this.FromFechaCierreDateTimeLabel.Size = new System.Drawing.Size(142, 27);
            this.FromFechaCierreDateTimeLabel.TabIndex = 208;
            this.FromFechaCierreDateTimeLabel.Text = "*";
            // 
            // FromFechaCierreDateTimePicker
            // 
            this.FromFechaCierreDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.FromFechaCierreDateTimePicker.Location = new System.Drawing.Point(308, 44);
            this.FromFechaCierreDateTimePicker.Name = "FromFechaCierreDateTimePicker";
            this.FromFechaCierreDateTimePicker.ShowCheckBox = true;
            this.FromFechaCierreDateTimePicker.Size = new System.Drawing.Size(142, 23);
            this.FromFechaCierreDateTimePicker.TabIndex = 207;
            this.FromFechaCierreDateTimePicker.ValueChanged += new System.EventHandler(this.FromFechaCierreDateTimePicker_ValueChanged);
            this.FromFechaCierreDateTimePicker.EnabledChanged += new System.EventHandler(this.FromFechaCierreDateTimePicker_EnabledChanged);
            // 
            // ToFechaAperturaDateTimeLabel
            // 
            this.ToFechaAperturaDateTimeLabel.BackColor = System.Drawing.Color.SteelBlue;
            this.ToFechaAperturaDateTimeLabel.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ToFechaAperturaDateTimeLabel.ForeColor = System.Drawing.Color.White;
            this.ToFechaAperturaDateTimeLabel.Location = new System.Drawing.Point(160, 12);
            this.ToFechaAperturaDateTimeLabel.Name = "ToFechaAperturaDateTimeLabel";
            this.ToFechaAperturaDateTimeLabel.Size = new System.Drawing.Size(142, 27);
            this.ToFechaAperturaDateTimeLabel.TabIndex = 206;
            this.ToFechaAperturaDateTimeLabel.Text = "*";
            // 
            // ToFechaAperturaDateTimePicker
            // 
            this.ToFechaAperturaDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ToFechaAperturaDateTimePicker.Location = new System.Drawing.Point(160, 44);
            this.ToFechaAperturaDateTimePicker.Name = "ToFechaAperturaDateTimePicker";
            this.ToFechaAperturaDateTimePicker.Size = new System.Drawing.Size(142, 23);
            this.ToFechaAperturaDateTimePicker.TabIndex = 205;
            // 
            // ExecuteButton
            // 
            this.ExecuteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ExecuteButton.BackColor = System.Drawing.Color.SteelBlue;
            this.ExecuteButton.BackgroundColor = System.Drawing.Color.SteelBlue;
            this.ExecuteButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.ExecuteButton.BorderRadius = 5;
            this.ExecuteButton.BorderSize = 0;
            this.ExecuteButton.FlatAppearance.BorderSize = 0;
            this.ExecuteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExecuteButton.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ExecuteButton.ForeColor = System.Drawing.Color.White;
            this.ExecuteButton.Location = new System.Drawing.Point(1558, 8);
            this.ExecuteButton.Name = "ExecuteButton";
            this.ExecuteButton.Size = new System.Drawing.Size(128, 64);
            this.ExecuteButton.TabIndex = 197;
            this.ExecuteButton.Text = "***";
            this.ExecuteButton.TextColor = System.Drawing.Color.White;
            this.ExecuteButton.UseVisualStyleBackColor = false;
            // 
            // BagHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 600);
            this.Controls.Add(this.FilterPanel);
            this.Controls.Add(this.MainGridView);
            this.Controls.Add(this.MainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BagHistoryForm";
            this.Text = "BagHisoryForm";
            this.Load += new System.EventHandler(this.BagHistoryForm_Load);
            this.VisibleChanged += new System.EventHandler(this.BagHistoryForm_VisibleChanged);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BagHistoryForm_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.MainGridView)).EndInit();
            this.FilterPanel.ResumeLayout(false);
            this.FilterPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private FlowLayoutPanel MainPanel;
        private DataGridView MainGridView;
        private Panel FilterPanel;
        private CustomButton ExecuteButton;
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
        private CustomButton ExecuteBagHistorySearch;
    }
}