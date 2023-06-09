﻿namespace Permaquim.Depositary.UI.Desktop
{
    partial class EnvelopeDepositForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.ButtonsPanel = new System.Windows.Forms.Panel();
            this.ConfirmAndExitDepositButton = new System.Windows.Forms.Button();
            this.CancelDepositButton = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            this.DenominationsGridView = new System.Windows.Forms.DataGridView();
            this.Image = new System.Windows.Forms.DataGridViewImageColumn();
            this.Denomination = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EnvelopeTextBox = new CustomTextBox();
            this.RemainingTimeLabel = new System.Windows.Forms.Label();
            this.SubtotalLabel = new System.Windows.Forms.Label();
            this.CurrencyLabel = new System.Windows.Forms.Label();
            this.MonitorGroupcheckbox = new System.Windows.Forms.CheckBox();
            this.MonitorGroupBox = new System.Windows.Forms.GroupBox();
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
            this.MainPanel.Controls.Add(this.BackButton);
            this.MainPanel.Controls.Add(this.DenominationsGridView);
            this.MainPanel.Controls.Add(this.EnvelopeTextBox);
            this.MainPanel.Controls.Add(this.RemainingTimeLabel);
            this.MainPanel.Controls.Add(this.SubtotalLabel);
            this.MainPanel.Controls.Add(this.CurrencyLabel);
            this.MainPanel.Location = new System.Drawing.Point(8, 22);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(726, 632);
            this.MainPanel.TabIndex = 137;
            // 
            // ButtonsPanel
            // 
            this.ButtonsPanel.Controls.Add(this.ConfirmAndExitDepositButton);
            this.ButtonsPanel.Controls.Add(this.CancelDepositButton);
            this.ButtonsPanel.Location = new System.Drawing.Point(7, 487);
            this.ButtonsPanel.Name = "ButtonsPanel";
            this.ButtonsPanel.Size = new System.Drawing.Size(704, 62);
            this.ButtonsPanel.TabIndex = 179;
            this.ButtonsPanel.Visible = false;
            // 
            // ConfirmAndExitDepositButton
            // 
            this.ConfirmAndExitDepositButton.BackColor = System.Drawing.Color.SeaGreen;
            this.ConfirmAndExitDepositButton.FlatAppearance.BorderSize = 0;
            this.ConfirmAndExitDepositButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConfirmAndExitDepositButton.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ConfirmAndExitDepositButton.ForeColor = System.Drawing.Color.White;
            this.ConfirmAndExitDepositButton.Location = new System.Drawing.Point(1, 4);
            this.ConfirmAndExitDepositButton.Name = "ConfirmAndExitDepositButton";
            this.ConfirmAndExitDepositButton.Size = new System.Drawing.Size(230, 55);
            this.ConfirmAndExitDepositButton.TabIndex = 180;
            this.ConfirmAndExitDepositButton.Tag = "";
            this.ConfirmAndExitDepositButton.Text = "*";
            this.ConfirmAndExitDepositButton.UseVisualStyleBackColor = false;
            this.ConfirmAndExitDepositButton.Visible = false;
            this.ConfirmAndExitDepositButton.Click += new System.EventHandler(this.ConfirmAndExitDepositButton_Click);
            // 
            // CancelDepositButton
            // 
            this.CancelDepositButton.BackColor = System.Drawing.Color.Red;
            this.CancelDepositButton.FlatAppearance.BorderSize = 0;
            this.CancelDepositButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelDepositButton.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CancelDepositButton.ForeColor = System.Drawing.Color.White;
            this.CancelDepositButton.Location = new System.Drawing.Point(469, 4);
            this.CancelDepositButton.Name = "CancelDepositButton";
            this.CancelDepositButton.Size = new System.Drawing.Size(230, 55);
            this.CancelDepositButton.TabIndex = 179;
            this.CancelDepositButton.Tag = "";
            this.CancelDepositButton.Text = "*";
            this.CancelDepositButton.UseVisualStyleBackColor = false;
            this.CancelDepositButton.Visible = false;
            this.CancelDepositButton.Click += new System.EventHandler(this.CancelDepositButton_Click);
            // 
            // BackButton
            // 
            this.BackButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BackButton.BackColor = System.Drawing.Color.SteelBlue;
            this.BackButton.FlatAppearance.BorderSize = 0;
            this.BackButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackButton.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BackButton.ForeColor = System.Drawing.Color.White;
            this.BackButton.Location = new System.Drawing.Point(240, 552);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(228, 55);
            this.BackButton.TabIndex = 182;
            this.BackButton.Text = "*";
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
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
            this.Amount,
            this.Id});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DenominationsGridView.DefaultCellStyle = dataGridViewCellStyle4;
            this.DenominationsGridView.EnableHeadersVisualStyles = false;
            this.DenominationsGridView.GridColor = System.Drawing.Color.White;
            this.DenominationsGridView.Location = new System.Drawing.Point(12, 34);
            this.DenominationsGridView.Name = "DenominationsGridView";
            this.DenominationsGridView.RowHeadersVisible = false;
            this.DenominationsGridView.RowTemplate.DividerHeight = 1;
            this.DenominationsGridView.RowTemplate.Height = 50;
            this.DenominationsGridView.RowTemplate.ReadOnly = true;
            this.DenominationsGridView.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.DenominationsGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DenominationsGridView.Size = new System.Drawing.Size(697, 390);
            this.DenominationsGridView.TabIndex = 175;
            this.DenominationsGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DenominationsGridView_CellClick);
            this.DenominationsGridView.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.DenominationsGridView_CellPainting);
            this.DenominationsGridView.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DenominationsGridView_EditingControlShowing);
            this.DenominationsGridView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DenominationsGridView_KeyPress);
            // 
            // Image
            // 
            this.Image.DataPropertyName = "Image";
            this.Image.Frozen = true;
            this.Image.HeaderText = "*";
            this.Image.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.Image.Name = "Image";
            this.Image.ReadOnly = true;
            this.Image.Width = 90;
            // 
            // Denomination
            // 
            this.Denomination.DataPropertyName = "Denomination";
            this.Denomination.HeaderText = "*";
            this.Denomination.Name = "Denomination";
            this.Denomination.ReadOnly = true;
            this.Denomination.Width = 396;
            // 
            // Quantity
            // 
            this.Quantity.DataPropertyName = "Quantity";
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.Quantity.DefaultCellStyle = dataGridViewCellStyle2;
            this.Quantity.HeaderText = "*";
            this.Quantity.Name = "Quantity";
            this.Quantity.Width = 210;
            // 
            // Amount
            // 
            this.Amount.DataPropertyName = "Amount";
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.Amount.DefaultCellStyle = dataGridViewCellStyle3;
            this.Amount.HeaderText = "*";
            this.Amount.Name = "Amount";
            this.Amount.Visible = false;
            this.Amount.Width = 600;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // EnvelopeTextBox
            // 
            this.EnvelopeTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.EnvelopeTextBox.BorderColor = System.Drawing.Color.SteelBlue;
            this.EnvelopeTextBox.BorderFocusColor = System.Drawing.Color.MediumSlateBlue;
            this.EnvelopeTextBox.BorderRadius = 4;
            this.EnvelopeTextBox.BorderSize = 2;
            this.EnvelopeTextBox.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.EnvelopeTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.EnvelopeTextBox.Location = new System.Drawing.Point(8, 432);
            this.EnvelopeTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.EnvelopeTextBox.MaxLength = 100;
            this.EnvelopeTextBox.Multiline = false;
            this.EnvelopeTextBox.Name = "EnvelopeTextBox";
            this.EnvelopeTextBox.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.EnvelopeTextBox.PasswordChar = false;
            this.EnvelopeTextBox.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.EnvelopeTextBox.PlaceholderText = "*";
            this.EnvelopeTextBox.SelectionLength = 0;
            this.EnvelopeTextBox.SelectionStart = 0;
            this.EnvelopeTextBox.Size = new System.Drawing.Size(702, 45);
            this.EnvelopeTextBox.TabIndex = 159;
            this.EnvelopeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.EnvelopeTextBox.Texts = "";
            this.EnvelopeTextBox.UnderlinedStyle = false;
            this.EnvelopeTextBox.Visible = false;
            this.EnvelopeTextBox.Click += new System.EventHandler(this.EnvelopeTextBox_Click);
            // 
            // RemainingTimeLabel
            // 
            this.RemainingTimeLabel.BackColor = System.Drawing.Color.SteelBlue;
            this.RemainingTimeLabel.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.RemainingTimeLabel.ForeColor = System.Drawing.Color.White;
            this.RemainingTimeLabel.Location = new System.Drawing.Point(461, 8);
            this.RemainingTimeLabel.Name = "RemainingTimeLabel";
            this.RemainingTimeLabel.Size = new System.Drawing.Size(249, 25);
            this.RemainingTimeLabel.TabIndex = 155;
            this.RemainingTimeLabel.Text = "*";
            this.RemainingTimeLabel.Click += new System.EventHandler(this.RemainingTimeLabel_Click);
            // 
            // SubtotalLabel
            // 
            this.SubtotalLabel.BackColor = System.Drawing.Color.SteelBlue;
            this.SubtotalLabel.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SubtotalLabel.ForeColor = System.Drawing.Color.White;
            this.SubtotalLabel.Location = new System.Drawing.Point(213, 8);
            this.SubtotalLabel.Name = "SubtotalLabel";
            this.SubtotalLabel.Size = new System.Drawing.Size(248, 25);
            this.SubtotalLabel.TabIndex = 154;
            this.SubtotalLabel.Text = "*";
            // 
            // CurrencyLabel
            // 
            this.CurrencyLabel.BackColor = System.Drawing.Color.SteelBlue;
            this.CurrencyLabel.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CurrencyLabel.ForeColor = System.Drawing.Color.White;
            this.CurrencyLabel.Location = new System.Drawing.Point(12, 8);
            this.CurrencyLabel.Name = "CurrencyLabel";
            this.CurrencyLabel.Size = new System.Drawing.Size(201, 25);
            this.CurrencyLabel.TabIndex = 153;
            this.CurrencyLabel.Text = "*";
            // 
            // MonitorGroupcheckbox
            // 
            this.MonitorGroupcheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MonitorGroupcheckbox.AutoSize = true;
            this.MonitorGroupcheckbox.BackColor = System.Drawing.Color.Transparent;
            this.MonitorGroupcheckbox.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MonitorGroupcheckbox.ForeColor = System.Drawing.Color.SteelBlue;
            this.MonitorGroupcheckbox.Location = new System.Drawing.Point(760, 40);
            this.MonitorGroupcheckbox.Name = "MonitorGroupcheckbox";
            this.MonitorGroupcheckbox.Size = new System.Drawing.Size(71, 17);
            this.MonitorGroupcheckbox.TabIndex = 143;
            this.MonitorGroupcheckbox.Text = "Eventos";
            this.MonitorGroupcheckbox.UseVisualStyleBackColor = false;
            this.MonitorGroupcheckbox.Visible = false;
            this.MonitorGroupcheckbox.CheckedChanged += new System.EventHandler(this.MonitorGroupcheckbox_CheckStateChanged);
            this.MonitorGroupcheckbox.CheckStateChanged += new System.EventHandler(this.MonitorGroupcheckbox_CheckStateChanged);
            // 
            // MonitorGroupBox
            // 
            this.MonitorGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MonitorGroupBox.BackColor = System.Drawing.Color.Transparent;
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
            this.MonitorGroupBox.Location = new System.Drawing.Point(752, 112);
            this.MonitorGroupBox.Name = "MonitorGroupBox";
            this.MonitorGroupBox.Size = new System.Drawing.Size(152, 308);
            this.MonitorGroupBox.TabIndex = 142;
            this.MonitorGroupBox.TabStop = false;
            this.MonitorGroupBox.Text = "Monitor";
            this.MonitorGroupBox.Visible = false;
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
            // EnvelopeDepositForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 671);
            this.ControlBox = false;
            this.Controls.Add(this.MonitorGroupcheckbox);
            this.Controls.Add(this.MonitorGroupBox);
            this.Controls.Add(this.MainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EnvelopeDepositForm";
            this.Load += new System.EventHandler(this.EnvelopeDepositForm_Load);
            this.EnabledChanged += new System.EventHandler(this.EnvelopeDepositForm_EnabledChanged);
            this.VisibleChanged += new System.EventHandler(this.EnvelopeDepositForm_VisibleChanged);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.EnvelopeDepositForm_MouseClick);
            this.MainPanel.ResumeLayout(false);
            this.ButtonsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DenominationsGridView)).EndInit();
            this.MonitorGroupBox.ResumeLayout(false);
            this.MonitorGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DataGridViewCheckBoxColumn Checkcolumn;
        private DataGridViewTextBoxColumn Aount;
        private DataGridViewTextBoxColumn Cantidad;
        private Panel MainPanel;
        private CustomTextBox EnvelopeTextBox;
        private Label InformationLabel;
        private Label RemainingTimeLabel;
        private Label SubtotalLabel;
        private Label CurrencyLabel;
        private DataGridView DenominationsGridView;
        private CheckBox MonitorGroupcheckbox;
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
        private Panel ButtonsPanel;
        private Button ConfirmAndExitDepositButton;
        private Button CancelDepositButton;
        private Button BackButton;
        private DataGridViewImageColumn Image;
        private DataGridViewTextBoxColumn Denomination;
        private DataGridViewTextBoxColumn Quantity;
        private DataGridViewTextBoxColumn Amount;
        private DataGridViewTextBoxColumn Id;
    }
}