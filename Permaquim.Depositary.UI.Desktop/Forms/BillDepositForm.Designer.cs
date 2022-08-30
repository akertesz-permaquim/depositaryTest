namespace Permaquim.Depositary.UI.Desktop
{
    partial class BillDepositForm
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
            this.MainPanel = new System.Windows.Forms.Panel();
            this.ButtonsPanel = new System.Windows.Forms.Panel();
            this.ConfirmAndContinueDepositButton = new Permaquim.Depositary.UI.Desktop.CustomButton();
            this.BackButton = new Permaquim.Depositary.UI.Desktop.CustomButton();
            this.ConfirmAndExitDepositButton = new Permaquim.Depositary.UI.Desktop.CustomButton();
            this.CancelDepositButton = new Permaquim.Depositary.UI.Desktop.CustomButton();
            this.DenominationsGridView = new System.Windows.Forms.DataGridView();
            this.Image = new System.Windows.Forms.DataGridViewImageColumn();
            this.Denomination = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EventCheckbox = new System.Windows.Forms.CheckBox();
            this.RemainingTimeLabel = new System.Windows.Forms.Label();
            this.SubtotalLabel = new System.Windows.Forms.Label();
            this.CurrencyLabel = new System.Windows.Forms.Label();
            this.MonitorGroupBox = new System.Windows.Forms.GroupBox();
            this.CollectEndCheckBox = new System.Windows.Forms.CheckBox();
            this.StoreEndCheckBox = new System.Windows.Forms.CheckBox();
            this.CountEndCheckBox = new System.Windows.Forms.CheckBox();
            this.BatchEndCheckBox = new System.Windows.Forms.CheckBox();
            this.CurrencyStatusLabel = new System.Windows.Forms.Label();
            this.JammingCheckBox = new System.Windows.Forms.CheckBox();
            this.CountingErrorCheckBox = new System.Windows.Forms.CheckBox();
            this.DepositFinishedCheckbox = new System.Windows.Forms.CheckBox();
            this.HopperBillPresentCheckBox = new System.Windows.Forms.CheckBox();
            this.EscrowBillPresentCheckBox = new System.Windows.Forms.CheckBox();
            this.DischargingFailureCheckBox = new System.Windows.Forms.CheckBox();
            this.RejectedBillPresentCheckBox = new System.Windows.Forms.CheckBox();
            this.RejectFullCheckBox = new System.Windows.Forms.CheckBox();
            this.StackerFullCheckBox = new System.Windows.Forms.CheckBox();
            this.DeviceModeLabel = new System.Windows.Forms.Label();
            this.GeneralStatusLabel = new System.Windows.Forms.Label();
            this.MonitorGroupcheckbox = new System.Windows.Forms.CheckBox();
            this.MainPanel.SuspendLayout();
            this.ButtonsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DenominationsGridView)).BeginInit();
            this.MonitorGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.MainPanel.Controls.Add(this.ButtonsPanel);
            this.MainPanel.Controls.Add(this.DenominationsGridView);
            this.MainPanel.Controls.Add(this.EventCheckbox);
            this.MainPanel.Controls.Add(this.RemainingTimeLabel);
            this.MainPanel.Controls.Add(this.SubtotalLabel);
            this.MainPanel.Controls.Add(this.CurrencyLabel);
            this.MainPanel.Location = new System.Drawing.Point(1, 8);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(704, 644);
            this.MainPanel.TabIndex = 0;
            // 
            // ButtonsPanel
            // 
            this.ButtonsPanel.Controls.Add(this.ConfirmAndContinueDepositButton);
            this.ButtonsPanel.Controls.Add(this.BackButton);
            this.ButtonsPanel.Controls.Add(this.ConfirmAndExitDepositButton);
            this.ButtonsPanel.Controls.Add(this.CancelDepositButton);
            this.ButtonsPanel.Location = new System.Drawing.Point(3, 508);
            this.ButtonsPanel.Name = "ButtonsPanel";
            this.ButtonsPanel.Size = new System.Drawing.Size(705, 56);
            this.ButtonsPanel.TabIndex = 146;
            // 
            // ConfirmAndContinueDepositButton
            // 
            this.ConfirmAndContinueDepositButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConfirmAndContinueDepositButton.BackColor = System.Drawing.Color.SeaGreen;
            this.ConfirmAndContinueDepositButton.BackgroundColor = System.Drawing.Color.SeaGreen;
            this.ConfirmAndContinueDepositButton.BorderColor = System.Drawing.Color.MediumSeaGreen;
            this.ConfirmAndContinueDepositButton.BorderRadius = 4;
            this.ConfirmAndContinueDepositButton.BorderSize = 0;
            this.ConfirmAndContinueDepositButton.FlatAppearance.BorderSize = 0;
            this.ConfirmAndContinueDepositButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConfirmAndContinueDepositButton.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ConfirmAndContinueDepositButton.ForeColor = System.Drawing.Color.White;
            this.ConfirmAndContinueDepositButton.Location = new System.Drawing.Point(237, 0);
            this.ConfirmAndContinueDepositButton.Name = "ConfirmAndContinueDepositButton";
            this.ConfirmAndContinueDepositButton.Size = new System.Drawing.Size(228, 55);
            this.ConfirmAndContinueDepositButton.TabIndex = 150;
            this.ConfirmAndContinueDepositButton.Tag = "";
            this.ConfirmAndContinueDepositButton.Text = "*";
            this.ConfirmAndContinueDepositButton.TextColor = System.Drawing.Color.White;
            this.ConfirmAndContinueDepositButton.UseVisualStyleBackColor = false;
            this.ConfirmAndContinueDepositButton.Visible = false;
            this.ConfirmAndContinueDepositButton.Click += new System.EventHandler(this.ConfirmAndContinueDepositButton_Click);
            // 
            // BackButton
            // 
            this.BackButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BackButton.BackColor = System.Drawing.Color.SteelBlue;
            this.BackButton.BackgroundColor = System.Drawing.Color.SteelBlue;
            this.BackButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BackButton.BorderRadius = 5;
            this.BackButton.BorderSize = 0;
            this.BackButton.FlatAppearance.BorderSize = 0;
            this.BackButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackButton.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BackButton.ForeColor = System.Drawing.Color.White;
            this.BackButton.Location = new System.Drawing.Point(238, 1);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(228, 55);
            this.BackButton.TabIndex = 149;
            this.BackButton.Text = "*";
            this.BackButton.TextColor = System.Drawing.Color.White;
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // ConfirmAndExitDepositButton
            // 
            this.ConfirmAndExitDepositButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConfirmAndExitDepositButton.BackColor = System.Drawing.Color.SeaGreen;
            this.ConfirmAndExitDepositButton.BackgroundColor = System.Drawing.Color.SeaGreen;
            this.ConfirmAndExitDepositButton.BorderColor = System.Drawing.Color.MediumSeaGreen;
            this.ConfirmAndExitDepositButton.BorderRadius = 4;
            this.ConfirmAndExitDepositButton.BorderSize = 0;
            this.ConfirmAndExitDepositButton.FlatAppearance.BorderSize = 0;
            this.ConfirmAndExitDepositButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConfirmAndExitDepositButton.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ConfirmAndExitDepositButton.ForeColor = System.Drawing.Color.White;
            this.ConfirmAndExitDepositButton.Location = new System.Drawing.Point(0, 0);
            this.ConfirmAndExitDepositButton.Name = "ConfirmAndExitDepositButton";
            this.ConfirmAndExitDepositButton.Size = new System.Drawing.Size(230, 55);
            this.ConfirmAndExitDepositButton.TabIndex = 148;
            this.ConfirmAndExitDepositButton.Tag = "";
            this.ConfirmAndExitDepositButton.Text = "*";
            this.ConfirmAndExitDepositButton.TextColor = System.Drawing.Color.White;
            this.ConfirmAndExitDepositButton.UseVisualStyleBackColor = false;
            this.ConfirmAndExitDepositButton.Visible = false;
            this.ConfirmAndExitDepositButton.Click += new System.EventHandler(this.ConfirmAndExitDepositButton_Click);
            // 
            // CancelDepositButton
            // 
            this.CancelDepositButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.CancelDepositButton.BackColor = System.Drawing.Color.Red;
            this.CancelDepositButton.BackgroundColor = System.Drawing.Color.Red;
            this.CancelDepositButton.BorderColor = System.Drawing.Color.DarkOrange;
            this.CancelDepositButton.BorderRadius = 4;
            this.CancelDepositButton.BorderSize = 0;
            this.CancelDepositButton.FlatAppearance.BorderSize = 0;
            this.CancelDepositButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelDepositButton.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CancelDepositButton.ForeColor = System.Drawing.Color.White;
            this.CancelDepositButton.Location = new System.Drawing.Point(469, 0);
            this.CancelDepositButton.Name = "CancelDepositButton";
            this.CancelDepositButton.Size = new System.Drawing.Size(230, 55);
            this.CancelDepositButton.TabIndex = 147;
            this.CancelDepositButton.Tag = "";
            this.CancelDepositButton.Text = "*";
            this.CancelDepositButton.TextColor = System.Drawing.Color.White;
            this.CancelDepositButton.UseVisualStyleBackColor = false;
            this.CancelDepositButton.Visible = false;
            this.CancelDepositButton.Click += new System.EventHandler(this.CancelDepositButton_Click);
            // 
            // DenominationsGridView
            // 
            this.DenominationsGridView.AllowUserToAddRows = false;
            this.DenominationsGridView.AllowUserToDeleteRows = false;
            this.DenominationsGridView.AllowUserToResizeColumns = false;
            this.DenominationsGridView.AllowUserToResizeRows = false;
            this.DenominationsGridView.BackgroundColor = System.Drawing.Color.White;
            this.DenominationsGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DenominationsGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.DenominationsGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DenominationsGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DenominationsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DenominationsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Image,
            this.Denomination,
            this.Quantity,
            this.Amount});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DenominationsGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.DenominationsGridView.Enabled = false;
            this.DenominationsGridView.EnableHeadersVisualStyles = false;
            this.DenominationsGridView.GridColor = System.Drawing.Color.White;
            this.DenominationsGridView.Location = new System.Drawing.Point(4, 61);
            this.DenominationsGridView.Name = "DenominationsGridView";
            this.DenominationsGridView.RowHeadersVisible = false;
            this.DenominationsGridView.RowTemplate.DividerHeight = 1;
            this.DenominationsGridView.RowTemplate.Height = 50;
            this.DenominationsGridView.RowTemplate.ReadOnly = true;
            this.DenominationsGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DenominationsGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DenominationsGridView.Size = new System.Drawing.Size(697, 440);
            this.DenominationsGridView.TabIndex = 145;
            this.DenominationsGridView.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.DenominationsGridView_CellPainting);
            // 
            // Image
            // 
            this.Image.DataPropertyName = "Image";
            this.Image.Frozen = true;
            this.Image.HeaderText = "*";
            this.Image.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.Image.Name = "Image";
            this.Image.ReadOnly = true;
            this.Image.Width = 105;
            // 
            // Denomination
            // 
            this.Denomination.DataPropertyName = "Denomination";
            this.Denomination.HeaderText = "*";
            this.Denomination.Name = "Denomination";
            this.Denomination.ReadOnly = true;
            this.Denomination.Width = 260;
            // 
            // Quantity
            // 
            this.Quantity.DataPropertyName = "Quantity";
            this.Quantity.HeaderText = "*";
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            this.Quantity.Width = 110;
            // 
            // Amount
            // 
            this.Amount.DataPropertyName = "Amount";
            this.Amount.HeaderText = "*";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            this.Amount.Width = 221;
            // 
            // EventCheckbox
            // 
            this.EventCheckbox.AutoSize = true;
            this.EventCheckbox.BackColor = System.Drawing.Color.Transparent;
            this.EventCheckbox.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.EventCheckbox.ForeColor = System.Drawing.Color.SteelBlue;
            this.EventCheckbox.Location = new System.Drawing.Point(883, 518);
            this.EventCheckbox.Name = "EventCheckbox";
            this.EventCheckbox.Size = new System.Drawing.Size(71, 17);
            this.EventCheckbox.TabIndex = 143;
            this.EventCheckbox.Text = "Eventos";
            this.EventCheckbox.UseVisualStyleBackColor = false;
            this.EventCheckbox.Click += new System.EventHandler(this.EventCheckbox_CheckedChanged);
            // 
            // RemainingTimeLabel
            // 
            this.RemainingTimeLabel.BackColor = System.Drawing.Color.SteelBlue;
            this.RemainingTimeLabel.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RemainingTimeLabel.ForeColor = System.Drawing.Color.White;
            this.RemainingTimeLabel.Location = new System.Drawing.Point(451, 32);
            this.RemainingTimeLabel.Name = "RemainingTimeLabel";
            this.RemainingTimeLabel.Size = new System.Drawing.Size(250, 27);
            this.RemainingTimeLabel.TabIndex = 141;
            this.RemainingTimeLabel.Text = "*";
            this.RemainingTimeLabel.Click += new System.EventHandler(this.RemainingTimeLabel_Click);
            // 
            // SubtotalLabel
            // 
            this.SubtotalLabel.BackColor = System.Drawing.Color.SteelBlue;
            this.SubtotalLabel.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SubtotalLabel.ForeColor = System.Drawing.Color.White;
            this.SubtotalLabel.Location = new System.Drawing.Point(203, 32);
            this.SubtotalLabel.Name = "SubtotalLabel";
            this.SubtotalLabel.Size = new System.Drawing.Size(248, 27);
            this.SubtotalLabel.TabIndex = 140;
            this.SubtotalLabel.Text = "*";
            // 
            // CurrencyLabel
            // 
            this.CurrencyLabel.BackColor = System.Drawing.Color.SteelBlue;
            this.CurrencyLabel.Font = new System.Drawing.Font("Verdana", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CurrencyLabel.ForeColor = System.Drawing.Color.White;
            this.CurrencyLabel.Location = new System.Drawing.Point(1, 32);
            this.CurrencyLabel.Name = "CurrencyLabel";
            this.CurrencyLabel.Size = new System.Drawing.Size(201, 27);
            this.CurrencyLabel.TabIndex = 139;
            this.CurrencyLabel.Text = "*";
            // 
            // MonitorGroupBox
            // 
            this.MonitorGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MonitorGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.MonitorGroupBox.Controls.Add(this.CollectEndCheckBox);
            this.MonitorGroupBox.Controls.Add(this.StoreEndCheckBox);
            this.MonitorGroupBox.Controls.Add(this.CountEndCheckBox);
            this.MonitorGroupBox.Controls.Add(this.BatchEndCheckBox);
            this.MonitorGroupBox.Controls.Add(this.CurrencyStatusLabel);
            this.MonitorGroupBox.Controls.Add(this.JammingCheckBox);
            this.MonitorGroupBox.Controls.Add(this.CountingErrorCheckBox);
            this.MonitorGroupBox.Controls.Add(this.DepositFinishedCheckbox);
            this.MonitorGroupBox.Controls.Add(this.HopperBillPresentCheckBox);
            this.MonitorGroupBox.Controls.Add(this.EscrowBillPresentCheckBox);
            this.MonitorGroupBox.Controls.Add(this.DischargingFailureCheckBox);
            this.MonitorGroupBox.Controls.Add(this.RejectedBillPresentCheckBox);
            this.MonitorGroupBox.Controls.Add(this.RejectFullCheckBox);
            this.MonitorGroupBox.Controls.Add(this.StackerFullCheckBox);
            this.MonitorGroupBox.Controls.Add(this.DeviceModeLabel);
            this.MonitorGroupBox.Controls.Add(this.GeneralStatusLabel);
            this.MonitorGroupBox.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MonitorGroupBox.Location = new System.Drawing.Point(744, 120);
            this.MonitorGroupBox.Name = "MonitorGroupBox";
            this.MonitorGroupBox.Size = new System.Drawing.Size(152, 448);
            this.MonitorGroupBox.TabIndex = 140;
            this.MonitorGroupBox.TabStop = false;
            this.MonitorGroupBox.Text = "Monitor";
            this.MonitorGroupBox.Visible = false;
            // 
            // CollectEndCheckBox
            // 
            this.CollectEndCheckBox.AutoSize = true;
            this.CollectEndCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.CollectEndCheckBox.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CollectEndCheckBox.ForeColor = System.Drawing.Color.SteelBlue;
            this.CollectEndCheckBox.Location = new System.Drawing.Point(8, 406);
            this.CollectEndCheckBox.Name = "CollectEndCheckBox";
            this.CollectEndCheckBox.Size = new System.Drawing.Size(86, 17);
            this.CollectEndCheckBox.TabIndex = 40;
            this.CollectEndCheckBox.Text = "CollectEnd";
            this.CollectEndCheckBox.UseVisualStyleBackColor = false;
            // 
            // StoreEndCheckBox
            // 
            this.StoreEndCheckBox.AutoSize = true;
            this.StoreEndCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.StoreEndCheckBox.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.StoreEndCheckBox.ForeColor = System.Drawing.Color.SteelBlue;
            this.StoreEndCheckBox.Location = new System.Drawing.Point(8, 380);
            this.StoreEndCheckBox.Name = "StoreEndCheckBox";
            this.StoreEndCheckBox.Size = new System.Drawing.Size(78, 17);
            this.StoreEndCheckBox.TabIndex = 39;
            this.StoreEndCheckBox.Text = "StoreEnd";
            this.StoreEndCheckBox.UseVisualStyleBackColor = false;
            // 
            // CountEndCheckBox
            // 
            this.CountEndCheckBox.AutoSize = true;
            this.CountEndCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.CountEndCheckBox.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CountEndCheckBox.ForeColor = System.Drawing.Color.SteelBlue;
            this.CountEndCheckBox.Location = new System.Drawing.Point(8, 354);
            this.CountEndCheckBox.Name = "CountEndCheckBox";
            this.CountEndCheckBox.Size = new System.Drawing.Size(81, 17);
            this.CountEndCheckBox.TabIndex = 38;
            this.CountEndCheckBox.Text = "CountEnd";
            this.CountEndCheckBox.UseVisualStyleBackColor = false;
            // 
            // BatchEndCheckBox
            // 
            this.BatchEndCheckBox.AutoSize = true;
            this.BatchEndCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.BatchEndCheckBox.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BatchEndCheckBox.ForeColor = System.Drawing.Color.SteelBlue;
            this.BatchEndCheckBox.Location = new System.Drawing.Point(8, 328);
            this.BatchEndCheckBox.Name = "BatchEndCheckBox";
            this.BatchEndCheckBox.Size = new System.Drawing.Size(79, 17);
            this.BatchEndCheckBox.TabIndex = 37;
            this.BatchEndCheckBox.Text = "BatchEnd";
            this.BatchEndCheckBox.UseVisualStyleBackColor = false;
            // 
            // CurrencyStatusLabel
            // 
            this.CurrencyStatusLabel.AutoSize = true;
            this.CurrencyStatusLabel.BackColor = System.Drawing.Color.Transparent;
            this.CurrencyStatusLabel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CurrencyStatusLabel.ForeColor = System.Drawing.Color.SteelBlue;
            this.CurrencyStatusLabel.Location = new System.Drawing.Point(6, 64);
            this.CurrencyStatusLabel.Name = "CurrencyStatusLabel";
            this.CurrencyStatusLabel.Size = new System.Drawing.Size(96, 13);
            this.CurrencyStatusLabel.TabIndex = 36;
            this.CurrencyStatusLabel.Text = "CurrencyStatus";
            // 
            // JammingCheckBox
            // 
            this.JammingCheckBox.AutoSize = true;
            this.JammingCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.JammingCheckBox.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.JammingCheckBox.ForeColor = System.Drawing.Color.SteelBlue;
            this.JammingCheckBox.Location = new System.Drawing.Point(9, 280);
            this.JammingCheckBox.Name = "JammingCheckBox";
            this.JammingCheckBox.Size = new System.Drawing.Size(77, 17);
            this.JammingCheckBox.TabIndex = 35;
            this.JammingCheckBox.Text = "Jamming";
            this.JammingCheckBox.UseVisualStyleBackColor = false;
            // 
            // CountingErrorCheckBox
            // 
            this.CountingErrorCheckBox.AutoSize = true;
            this.CountingErrorCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.CountingErrorCheckBox.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CountingErrorCheckBox.ForeColor = System.Drawing.Color.SteelBlue;
            this.CountingErrorCheckBox.Location = new System.Drawing.Point(9, 256);
            this.CountingErrorCheckBox.Name = "CountingErrorCheckBox";
            this.CountingErrorCheckBox.Size = new System.Drawing.Size(110, 17);
            this.CountingErrorCheckBox.TabIndex = 34;
            this.CountingErrorCheckBox.Text = "Counting Error";
            this.CountingErrorCheckBox.UseVisualStyleBackColor = false;
            // 
            // DepositFinishedCheckbox
            // 
            this.DepositFinishedCheckbox.AutoSize = true;
            this.DepositFinishedCheckbox.BackColor = System.Drawing.Color.Transparent;
            this.DepositFinishedCheckbox.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DepositFinishedCheckbox.ForeColor = System.Drawing.Color.SteelBlue;
            this.DepositFinishedCheckbox.Location = new System.Drawing.Point(9, 232);
            this.DepositFinishedCheckbox.Name = "DepositFinishedCheckbox";
            this.DepositFinishedCheckbox.Size = new System.Drawing.Size(117, 17);
            this.DepositFinishedCheckbox.TabIndex = 33;
            this.DepositFinishedCheckbox.Text = "Deposit finished";
            this.DepositFinishedCheckbox.UseVisualStyleBackColor = false;
            // 
            // HopperBillPresentCheckBox
            // 
            this.HopperBillPresentCheckBox.AutoSize = true;
            this.HopperBillPresentCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.HopperBillPresentCheckBox.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.HopperBillPresentCheckBox.ForeColor = System.Drawing.Color.SteelBlue;
            this.HopperBillPresentCheckBox.Location = new System.Drawing.Point(8, 207);
            this.HopperBillPresentCheckBox.Name = "HopperBillPresentCheckBox";
            this.HopperBillPresentCheckBox.Size = new System.Drawing.Size(135, 17);
            this.HopperBillPresentCheckBox.TabIndex = 32;
            this.HopperBillPresentCheckBox.Text = "Hopper Bill Present";
            this.HopperBillPresentCheckBox.UseVisualStyleBackColor = false;
            // 
            // EscrowBillPresentCheckBox
            // 
            this.EscrowBillPresentCheckBox.AutoSize = true;
            this.EscrowBillPresentCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.EscrowBillPresentCheckBox.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.EscrowBillPresentCheckBox.ForeColor = System.Drawing.Color.SteelBlue;
            this.EscrowBillPresentCheckBox.Location = new System.Drawing.Point(8, 183);
            this.EscrowBillPresentCheckBox.Name = "EscrowBillPresentCheckBox";
            this.EscrowBillPresentCheckBox.Size = new System.Drawing.Size(134, 17);
            this.EscrowBillPresentCheckBox.TabIndex = 31;
            this.EscrowBillPresentCheckBox.Text = "Escrow Bill Present";
            this.EscrowBillPresentCheckBox.UseVisualStyleBackColor = false;
            // 
            // DischargingFailureCheckBox
            // 
            this.DischargingFailureCheckBox.AutoSize = true;
            this.DischargingFailureCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.DischargingFailureCheckBox.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DischargingFailureCheckBox.ForeColor = System.Drawing.Color.SteelBlue;
            this.DischargingFailureCheckBox.Location = new System.Drawing.Point(8, 159);
            this.DischargingFailureCheckBox.Name = "DischargingFailureCheckBox";
            this.DischargingFailureCheckBox.Size = new System.Drawing.Size(134, 17);
            this.DischargingFailureCheckBox.TabIndex = 30;
            this.DischargingFailureCheckBox.Text = "Discharging Failure";
            this.DischargingFailureCheckBox.UseVisualStyleBackColor = false;
            // 
            // RejectedBillPresentCheckBox
            // 
            this.RejectedBillPresentCheckBox.AutoSize = true;
            this.RejectedBillPresentCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.RejectedBillPresentCheckBox.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RejectedBillPresentCheckBox.ForeColor = System.Drawing.Color.SteelBlue;
            this.RejectedBillPresentCheckBox.Location = new System.Drawing.Point(8, 135);
            this.RejectedBillPresentCheckBox.Name = "RejectedBillPresentCheckBox";
            this.RejectedBillPresentCheckBox.Size = new System.Drawing.Size(144, 17);
            this.RejectedBillPresentCheckBox.TabIndex = 29;
            this.RejectedBillPresentCheckBox.Text = "Rejected Bill Present";
            this.RejectedBillPresentCheckBox.UseVisualStyleBackColor = false;
            // 
            // RejectFullCheckBox
            // 
            this.RejectFullCheckBox.AutoSize = true;
            this.RejectFullCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.RejectFullCheckBox.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RejectFullCheckBox.ForeColor = System.Drawing.Color.SteelBlue;
            this.RejectFullCheckBox.Location = new System.Drawing.Point(8, 111);
            this.RejectFullCheckBox.Name = "RejectFullCheckBox";
            this.RejectFullCheckBox.Size = new System.Drawing.Size(85, 17);
            this.RejectFullCheckBox.TabIndex = 28;
            this.RejectFullCheckBox.Text = "Reject Full";
            this.RejectFullCheckBox.UseVisualStyleBackColor = false;
            // 
            // StackerFullCheckBox
            // 
            this.StackerFullCheckBox.AutoSize = true;
            this.StackerFullCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.StackerFullCheckBox.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.StackerFullCheckBox.ForeColor = System.Drawing.Color.SteelBlue;
            this.StackerFullCheckBox.Location = new System.Drawing.Point(8, 87);
            this.StackerFullCheckBox.Name = "StackerFullCheckBox";
            this.StackerFullCheckBox.Size = new System.Drawing.Size(93, 17);
            this.StackerFullCheckBox.TabIndex = 27;
            this.StackerFullCheckBox.Text = "Stacker Full";
            this.StackerFullCheckBox.UseVisualStyleBackColor = false;
            // 
            // DeviceModeLabel
            // 
            this.DeviceModeLabel.AutoSize = true;
            this.DeviceModeLabel.BackColor = System.Drawing.Color.Transparent;
            this.DeviceModeLabel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DeviceModeLabel.ForeColor = System.Drawing.Color.SteelBlue;
            this.DeviceModeLabel.Location = new System.Drawing.Point(6, 40);
            this.DeviceModeLabel.Name = "DeviceModeLabel";
            this.DeviceModeLabel.Size = new System.Drawing.Size(76, 13);
            this.DeviceModeLabel.TabIndex = 26;
            this.DeviceModeLabel.Text = "DeviceMode";
            // 
            // GeneralStatusLabel
            // 
            this.GeneralStatusLabel.AutoSize = true;
            this.GeneralStatusLabel.BackColor = System.Drawing.Color.Transparent;
            this.GeneralStatusLabel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.GeneralStatusLabel.ForeColor = System.Drawing.Color.SteelBlue;
            this.GeneralStatusLabel.Location = new System.Drawing.Point(6, 16);
            this.GeneralStatusLabel.Name = "GeneralStatusLabel";
            this.GeneralStatusLabel.Size = new System.Drawing.Size(88, 13);
            this.GeneralStatusLabel.TabIndex = 25;
            this.GeneralStatusLabel.Text = "GeneralStatus";
            // 
            // MonitorGroupcheckbox
            // 
            this.MonitorGroupcheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MonitorGroupcheckbox.AutoSize = true;
            this.MonitorGroupcheckbox.BackColor = System.Drawing.Color.Transparent;
            this.MonitorGroupcheckbox.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MonitorGroupcheckbox.ForeColor = System.Drawing.Color.SteelBlue;
            this.MonitorGroupcheckbox.Location = new System.Drawing.Point(760, 80);
            this.MonitorGroupcheckbox.Name = "MonitorGroupcheckbox";
            this.MonitorGroupcheckbox.Size = new System.Drawing.Size(71, 17);
            this.MonitorGroupcheckbox.TabIndex = 141;
            this.MonitorGroupcheckbox.Text = "Eventos";
            this.MonitorGroupcheckbox.UseVisualStyleBackColor = false;
            this.MonitorGroupcheckbox.Visible = false;
            this.MonitorGroupcheckbox.CheckStateChanged += new System.EventHandler(this.MonitorGroupcheckbox_CheckStateChanged);
            // 
            // BillDepositForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(917, 650);
            this.ControlBox = false;
            this.Controls.Add(this.MonitorGroupcheckbox);
            this.Controls.Add(this.MonitorGroupBox);
            this.Controls.Add(this.MainPanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "BillDepositForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.BillDepositForm_Load);
            this.VisibleChanged += new System.EventHandler(this.BillDepositForm_VisibleChanged);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BillDepositForm_MouseClick);
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            this.ButtonsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DenominationsGridView)).EndInit();
            this.MonitorGroupBox.ResumeLayout(false);
            this.MonitorGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DataGridViewTextBoxColumn Denominacion;
        private DataGridViewTextBoxColumn Cantidad;
        private DataGridViewTextBoxColumn Importe;
        private Panel MainPanel;
        private DataGridView DenominationsGridView;
        private CheckBox EventCheckbox;
        private Label RemainingTimeLabel;
        private Label SubtotalLabel;
        private Label CurrencyLabel;
        private GroupBox MonitorGroupBox;
        private Label CurrencyStatusLabel;
        private CheckBox JammingCheckBox;
        private CheckBox CountingErrorCheckBox;
        private CheckBox DepositFinishedCheckbox;
        private CheckBox HopperBillPresentCheckBox;
        private CheckBox EscrowBillPresentCheckBox;
        private CheckBox DischargingFailureCheckBox;
        private CheckBox RejectedBillPresentCheckBox;
        private CheckBox RejectFullCheckBox;
        private CheckBox StackerFullCheckBox;
        private Label DeviceModeLabel;
        private Label GeneralStatusLabel;
        private CheckBox MonitorGroupcheckbox;
        private DataGridViewImageColumn Image;
        private DataGridViewTextBoxColumn Denomination;
        private DataGridViewTextBoxColumn Quantity;
        private DataGridViewTextBoxColumn Amount;
        private Panel ButtonsPanel;
        private CustomButton ConfirmAndContinueDepositButton;
        private CustomButton BackButton;
        private CustomButton ConfirmAndExitDepositButton;
        private CustomButton CancelDepositButton;
        private CheckBox BatchEndCheckBox;
        private CheckBox CountEndCheckBox;
        private CheckBox StoreEndCheckBox;
        private CheckBox CollectEndCheckBox;
    }
}