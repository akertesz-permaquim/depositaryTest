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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.BackButton = new Permaquim.Depositary.UI.Desktop.CustomButton();
            this.label4 = new System.Windows.Forms.Label();
            this.SubtotalLabel = new System.Windows.Forms.Label();
            this.CurrencyLabel = new System.Windows.Forms.Label();
            this.ConfirmAndExitDepositButton = new Permaquim.Depositary.UI.Desktop.CustomButton();
            this.CancelDepositButton = new Permaquim.Depositary.UI.Desktop.CustomButton();
            this.DenominationsGridView = new System.Windows.Forms.DataGridView();
            this.InformationLabel = new System.Windows.Forms.Label();
            this.EventCheckbox = new System.Windows.Forms.CheckBox();
            this.MonitorGroupBox = new System.Windows.Forms.GroupBox();
            this.CountingErrorCheckBox = new System.Windows.Forms.CheckBox();
            this.JammingCheckBox = new System.Windows.Forms.CheckBox();
            this.DepositFinishedCheckbox = new System.Windows.Forms.CheckBox();
            this.HopperBillPresentCheckBox = new System.Windows.Forms.CheckBox();
            this.EscrowBillPresentCheckBox = new System.Windows.Forms.CheckBox();
            this.DischargingFailureCheckBox = new System.Windows.Forms.CheckBox();
            this.RejectedBillPresentCheckBox = new System.Windows.Forms.CheckBox();
            this.RejectFullCheckBox = new System.Windows.Forms.CheckBox();
            this.StackerFullCheckBox = new System.Windows.Forms.CheckBox();
            this.DeviceModeLabel = new System.Windows.Forms.Label();
            this.GeneralStatusLabel = new System.Windows.Forms.Label();
            this.denominationItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.EnvelopeTextBox = new CustomTextBox();
            this.Button_3 = new Permaquim.Depositary.UI.Desktop.CustomButton();
            this.Button_2 = new Permaquim.Depositary.UI.Desktop.CustomButton();
            this.Button_1 = new Permaquim.Depositary.UI.Desktop.CustomButton();
            this.Button_6 = new Permaquim.Depositary.UI.Desktop.CustomButton();
            this.Button_5 = new Permaquim.Depositary.UI.Desktop.CustomButton();
            this.Button_4 = new Permaquim.Depositary.UI.Desktop.CustomButton();
            this.Button_Dot = new Permaquim.Depositary.UI.Desktop.CustomButton();
            this.Button_BackSpace = new Permaquim.Depositary.UI.Desktop.CustomButton();
            this.Button_0 = new Permaquim.Depositary.UI.Desktop.CustomButton();
            this.Button_9 = new Permaquim.Depositary.UI.Desktop.CustomButton();
            this.Button_8 = new Permaquim.Depositary.UI.Desktop.CustomButton();
            this.Button_7 = new Permaquim.Depositary.UI.Desktop.CustomButton();
            this.Imagen = new System.Windows.Forms.DataGridViewImageColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Denomination = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DenominationsGridView)).BeginInit();
            this.MonitorGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.denominationItemBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // BackButton
            // 
            this.BackButton.BackColor = System.Drawing.Color.SteelBlue;
            this.BackButton.BackgroundColor = System.Drawing.Color.SteelBlue;
            this.BackButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BackButton.BorderRadius = 5;
            this.BackButton.BorderSize = 0;
            this.BackButton.FlatAppearance.BorderSize = 0;
            this.BackButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackButton.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BackButton.ForeColor = System.Drawing.Color.White;
            this.BackButton.Location = new System.Drawing.Point(404, 462);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(160, 55);
            this.BackButton.TabIndex = 124;
            this.BackButton.Text = "Salir";
            this.BackButton.TextColor = System.Drawing.Color.White;
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.SteelBlue;
            this.label4.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(496, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(234, 23);
            this.label4.TabIndex = 123;
            this.label4.Text = "Tiempo restante: ";
            // 
            // SubtotalLabel
            // 
            this.SubtotalLabel.BackColor = System.Drawing.Color.SteelBlue;
            this.SubtotalLabel.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SubtotalLabel.ForeColor = System.Drawing.Color.White;
            this.SubtotalLabel.Location = new System.Drawing.Point(248, 14);
            this.SubtotalLabel.Name = "SubtotalLabel";
            this.SubtotalLabel.Size = new System.Drawing.Size(248, 23);
            this.SubtotalLabel.TabIndex = 122;
            this.SubtotalLabel.Text = "Sub total: $ 0";
            // 
            // CurrencyLabel
            // 
            this.CurrencyLabel.BackColor = System.Drawing.Color.SteelBlue;
            this.CurrencyLabel.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CurrencyLabel.ForeColor = System.Drawing.Color.White;
            this.CurrencyLabel.Location = new System.Drawing.Point(47, 14);
            this.CurrencyLabel.Name = "CurrencyLabel";
            this.CurrencyLabel.Size = new System.Drawing.Size(201, 23);
            this.CurrencyLabel.TabIndex = 121;
            this.CurrencyLabel.Text = "Divisa: Pesos";
            // 
            // ConfirmAndExitDepositButton
            // 
            this.ConfirmAndExitDepositButton.BackColor = System.Drawing.Color.SeaGreen;
            this.ConfirmAndExitDepositButton.BackgroundColor = System.Drawing.Color.SeaGreen;
            this.ConfirmAndExitDepositButton.BorderColor = System.Drawing.Color.MediumSeaGreen;
            this.ConfirmAndExitDepositButton.BorderRadius = 4;
            this.ConfirmAndExitDepositButton.BorderSize = 0;
            this.ConfirmAndExitDepositButton.FlatAppearance.BorderSize = 0;
            this.ConfirmAndExitDepositButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConfirmAndExitDepositButton.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ConfirmAndExitDepositButton.ForeColor = System.Drawing.Color.White;
            this.ConfirmAndExitDepositButton.Location = new System.Drawing.Point(548, 462);
            this.ConfirmAndExitDepositButton.Name = "ConfirmAndExitDepositButton";
            this.ConfirmAndExitDepositButton.Size = new System.Drawing.Size(300, 55);
            this.ConfirmAndExitDepositButton.TabIndex = 120;
            this.ConfirmAndExitDepositButton.Tag = "";
            this.ConfirmAndExitDepositButton.Text = "Confirmar ";
            this.ConfirmAndExitDepositButton.TextColor = System.Drawing.Color.White;
            this.ConfirmAndExitDepositButton.UseVisualStyleBackColor = false;
            this.ConfirmAndExitDepositButton.Visible = false;
            this.ConfirmAndExitDepositButton.Click += new System.EventHandler(this.ConfirmAndExitDepositButton_Click);
            // 
            // CancelDepositButton
            // 
            this.CancelDepositButton.BackColor = System.Drawing.Color.Red;
            this.CancelDepositButton.BackgroundColor = System.Drawing.Color.Red;
            this.CancelDepositButton.BorderColor = System.Drawing.Color.DarkOrange;
            this.CancelDepositButton.BorderRadius = 4;
            this.CancelDepositButton.BorderSize = 0;
            this.CancelDepositButton.FlatAppearance.BorderSize = 0;
            this.CancelDepositButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelDepositButton.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CancelDepositButton.ForeColor = System.Drawing.Color.White;
            this.CancelDepositButton.Location = new System.Drawing.Point(156, 462);
            this.CancelDepositButton.Name = "CancelDepositButton";
            this.CancelDepositButton.Size = new System.Drawing.Size(300, 55);
            this.CancelDepositButton.TabIndex = 119;
            this.CancelDepositButton.Tag = "";
            this.CancelDepositButton.Text = "Cancelar";
            this.CancelDepositButton.TextColor = System.Drawing.Color.White;
            this.CancelDepositButton.UseVisualStyleBackColor = false;
            this.CancelDepositButton.Visible = false;
            // 
            // DenominationsGridView
            // 
            this.DenominationsGridView.AllowUserToAddRows = false;
            this.DenominationsGridView.AllowUserToDeleteRows = false;
            this.DenominationsGridView.AllowUserToResizeColumns = false;
            this.DenominationsGridView.AllowUserToResizeRows = false;
            this.DenominationsGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DenominationsGridView.BackgroundColor = System.Drawing.Color.White;
            this.DenominationsGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DenominationsGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.DenominationsGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DenominationsGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DenominationsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DenominationsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Imagen,
            this.Id,
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
            this.DenominationsGridView.EnableHeadersVisualStyles = false;
            this.DenominationsGridView.Location = new System.Drawing.Point(48, 40);
            this.DenominationsGridView.Name = "DenominationsGridView";
            this.DenominationsGridView.RowHeadersVisible = false;
            this.DenominationsGridView.RowTemplate.DividerHeight = 1;
            this.DenominationsGridView.RowTemplate.Height = 50;
            this.DenominationsGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DenominationsGridView.Size = new System.Drawing.Size(680, 360);
            this.DenominationsGridView.TabIndex = 133;
            this.DenominationsGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CellClicked);
            this.DenominationsGridView.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.DenominationsGridView_CellPainting);
            this.DenominationsGridView.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DenominationsGridView_EditingControlShowing);
            // 
            // InformationLabel
            // 
            this.InformationLabel.BackColor = System.Drawing.Color.Transparent;
            this.InformationLabel.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.InformationLabel.ForeColor = System.Drawing.Color.Red;
            this.InformationLabel.Location = new System.Drawing.Point(150, 528);
            this.InformationLabel.Name = "InformationLabel";
            this.InformationLabel.Size = new System.Drawing.Size(704, 72);
            this.InformationLabel.TabIndex = 134;
            this.InformationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EventCheckbox
            // 
            this.EventCheckbox.AutoSize = true;
            this.EventCheckbox.BackColor = System.Drawing.Color.Transparent;
            this.EventCheckbox.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.EventCheckbox.ForeColor = System.Drawing.Color.SteelBlue;
            this.EventCheckbox.Location = new System.Drawing.Point(880, 488);
            this.EventCheckbox.Name = "EventCheckbox";
            this.EventCheckbox.Size = new System.Drawing.Size(71, 17);
            this.EventCheckbox.TabIndex = 136;
            this.EventCheckbox.Text = "Eventos";
            this.EventCheckbox.UseVisualStyleBackColor = false;
            this.EventCheckbox.CheckedChanged += new System.EventHandler(this.EventCheckbox_CheckedChanged);
            // 
            // MonitorGroupBox
            // 
            this.MonitorGroupBox.BackColor = System.Drawing.Color.White;
            this.MonitorGroupBox.Controls.Add(this.CountingErrorCheckBox);
            this.MonitorGroupBox.Controls.Add(this.JammingCheckBox);
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
            this.MonitorGroupBox.Location = new System.Drawing.Point(752, 144);
            this.MonitorGroupBox.Name = "MonitorGroupBox";
            this.MonitorGroupBox.Size = new System.Drawing.Size(152, 256);
            this.MonitorGroupBox.TabIndex = 135;
            this.MonitorGroupBox.TabStop = false;
            this.MonitorGroupBox.Text = "Monitor";
            this.MonitorGroupBox.Visible = false;
            // 
            // CountingErrorCheckBox
            // 
            this.CountingErrorCheckBox.AutoSize = true;
            this.CountingErrorCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.CountingErrorCheckBox.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CountingErrorCheckBox.ForeColor = System.Drawing.Color.SteelBlue;
            this.CountingErrorCheckBox.Location = new System.Drawing.Point(9, 233);
            this.CountingErrorCheckBox.Name = "CountingErrorCheckBox";
            this.CountingErrorCheckBox.Size = new System.Drawing.Size(110, 17);
            this.CountingErrorCheckBox.TabIndex = 34;
            this.CountingErrorCheckBox.Text = "Counting Error";
            this.CountingErrorCheckBox.UseVisualStyleBackColor = false;
            // 
            // JammingCheckBox
            // 
            this.JammingCheckBox.AutoSize = true;
            this.JammingCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.JammingCheckBox.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.JammingCheckBox.ForeColor = System.Drawing.Color.SteelBlue;
            this.JammingCheckBox.Location = new System.Drawing.Point(9, 257);
            this.JammingCheckBox.Name = "JammingCheckBox";
            this.JammingCheckBox.Size = new System.Drawing.Size(77, 17);
            this.JammingCheckBox.TabIndex = 35;
            this.JammingCheckBox.Text = "Jamming";
            this.JammingCheckBox.UseVisualStyleBackColor = false;
            // 
            // DepositFinishedCheckbox
            // 
            this.DepositFinishedCheckbox.AutoSize = true;
            this.DepositFinishedCheckbox.BackColor = System.Drawing.Color.Transparent;
            this.DepositFinishedCheckbox.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DepositFinishedCheckbox.ForeColor = System.Drawing.Color.SteelBlue;
            this.DepositFinishedCheckbox.Location = new System.Drawing.Point(9, 209);
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
            this.HopperBillPresentCheckBox.Location = new System.Drawing.Point(8, 184);
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
            this.EscrowBillPresentCheckBox.Location = new System.Drawing.Point(8, 160);
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
            this.DischargingFailureCheckBox.Location = new System.Drawing.Point(8, 136);
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
            this.RejectedBillPresentCheckBox.Location = new System.Drawing.Point(8, 112);
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
            this.RejectFullCheckBox.Location = new System.Drawing.Point(8, 88);
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
            this.StackerFullCheckBox.Location = new System.Drawing.Point(8, 64);
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
            this.DeviceModeLabel.Location = new System.Drawing.Point(8, 40);
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
            this.GeneralStatusLabel.Location = new System.Drawing.Point(8, 16);
            this.GeneralStatusLabel.Name = "GeneralStatusLabel";
            this.GeneralStatusLabel.Size = new System.Drawing.Size(88, 13);
            this.GeneralStatusLabel.TabIndex = 25;
            this.GeneralStatusLabel.Text = "GeneralStatus";
            // 
            // denominationItemBindingSource
            // 
            this.denominationItemBindingSource.DataSource = typeof(Permaquim.Depositary.UI.Desktop.DenominationItem);
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
            this.EnvelopeTextBox.Location = new System.Drawing.Point(232, 408);
            this.EnvelopeTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.EnvelopeTextBox.Multiline = false;
            this.EnvelopeTextBox.Name = "EnvelopeTextBox";
            this.EnvelopeTextBox.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.EnvelopeTextBox.PasswordChar = false;
            this.EnvelopeTextBox.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.EnvelopeTextBox.PlaceholderText = "Identificador de sobre";
            this.EnvelopeTextBox.Size = new System.Drawing.Size(352, 45);
            this.EnvelopeTextBox.TabIndex = 138;
            this.EnvelopeTextBox.Texts = "";
            this.EnvelopeTextBox.UnderlinedStyle = false;
            // 
            // Button_3
            // 
            this.Button_3.BackColor = System.Drawing.Color.SteelBlue;
            this.Button_3.BackgroundColor = System.Drawing.Color.SteelBlue;
            this.Button_3.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.Button_3.BorderRadius = 4;
            this.Button_3.BorderSize = 0;
            this.Button_3.FlatAppearance.BorderSize = 0;
            this.Button_3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_3.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Button_3.ForeColor = System.Drawing.Color.White;
            this.Button_3.Location = new System.Drawing.Point(856, 152);
            this.Button_3.Name = "Button_3";
            this.Button_3.Size = new System.Drawing.Size(55, 55);
            this.Button_3.TabIndex = 141;
            this.Button_3.Tag = "3";
            this.Button_3.Text = "3";
            this.Button_3.TextColor = System.Drawing.Color.White;
            this.Button_3.UseVisualStyleBackColor = false;
            this.Button_3.Click += new System.EventHandler(this.Keys);
            // 
            // Button_2
            // 
            this.Button_2.BackColor = System.Drawing.Color.SteelBlue;
            this.Button_2.BackgroundColor = System.Drawing.Color.SteelBlue;
            this.Button_2.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.Button_2.BorderRadius = 4;
            this.Button_2.BorderSize = 0;
            this.Button_2.FlatAppearance.BorderSize = 0;
            this.Button_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Button_2.ForeColor = System.Drawing.Color.White;
            this.Button_2.Location = new System.Drawing.Point(797, 152);
            this.Button_2.Name = "Button_2";
            this.Button_2.Size = new System.Drawing.Size(55, 55);
            this.Button_2.TabIndex = 140;
            this.Button_2.Tag = "2";
            this.Button_2.Text = "2";
            this.Button_2.TextColor = System.Drawing.Color.White;
            this.Button_2.UseVisualStyleBackColor = false;
            this.Button_2.Click += new System.EventHandler(this.Keys);
            // 
            // Button_1
            // 
            this.Button_1.BackColor = System.Drawing.Color.SteelBlue;
            this.Button_1.BackgroundColor = System.Drawing.Color.SteelBlue;
            this.Button_1.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.Button_1.BorderRadius = 4;
            this.Button_1.BorderSize = 0;
            this.Button_1.FlatAppearance.BorderSize = 0;
            this.Button_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Button_1.ForeColor = System.Drawing.Color.White;
            this.Button_1.Location = new System.Drawing.Point(738, 152);
            this.Button_1.Name = "Button_1";
            this.Button_1.Size = new System.Drawing.Size(55, 55);
            this.Button_1.TabIndex = 139;
            this.Button_1.Tag = "1";
            this.Button_1.Text = "1";
            this.Button_1.TextColor = System.Drawing.Color.White;
            this.Button_1.UseVisualStyleBackColor = false;
            this.Button_1.Click += new System.EventHandler(this.Keys);
            // 
            // Button_6
            // 
            this.Button_6.BackColor = System.Drawing.Color.SteelBlue;
            this.Button_6.BackgroundColor = System.Drawing.Color.SteelBlue;
            this.Button_6.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.Button_6.BorderRadius = 4;
            this.Button_6.BorderSize = 0;
            this.Button_6.FlatAppearance.BorderSize = 0;
            this.Button_6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_6.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Button_6.ForeColor = System.Drawing.Color.White;
            this.Button_6.Location = new System.Drawing.Point(856, 94);
            this.Button_6.Name = "Button_6";
            this.Button_6.Size = new System.Drawing.Size(55, 55);
            this.Button_6.TabIndex = 144;
            this.Button_6.Tag = "6";
            this.Button_6.Text = "6";
            this.Button_6.TextColor = System.Drawing.Color.White;
            this.Button_6.UseVisualStyleBackColor = false;
            this.Button_6.Click += new System.EventHandler(this.Keys);
            // 
            // Button_5
            // 
            this.Button_5.BackColor = System.Drawing.Color.SteelBlue;
            this.Button_5.BackgroundColor = System.Drawing.Color.SteelBlue;
            this.Button_5.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.Button_5.BorderRadius = 4;
            this.Button_5.BorderSize = 0;
            this.Button_5.FlatAppearance.BorderSize = 0;
            this.Button_5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_5.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Button_5.ForeColor = System.Drawing.Color.White;
            this.Button_5.Location = new System.Drawing.Point(797, 94);
            this.Button_5.Name = "Button_5";
            this.Button_5.Size = new System.Drawing.Size(55, 55);
            this.Button_5.TabIndex = 143;
            this.Button_5.Tag = "5";
            this.Button_5.Text = "5";
            this.Button_5.TextColor = System.Drawing.Color.White;
            this.Button_5.UseVisualStyleBackColor = false;
            this.Button_5.Click += new System.EventHandler(this.Keys);
            // 
            // Button_4
            // 
            this.Button_4.BackColor = System.Drawing.Color.SteelBlue;
            this.Button_4.BackgroundColor = System.Drawing.Color.SteelBlue;
            this.Button_4.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.Button_4.BorderRadius = 4;
            this.Button_4.BorderSize = 0;
            this.Button_4.FlatAppearance.BorderSize = 0;
            this.Button_4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_4.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Button_4.ForeColor = System.Drawing.Color.White;
            this.Button_4.Location = new System.Drawing.Point(738, 94);
            this.Button_4.Name = "Button_4";
            this.Button_4.Size = new System.Drawing.Size(55, 55);
            this.Button_4.TabIndex = 142;
            this.Button_4.Tag = "4";
            this.Button_4.Text = "4";
            this.Button_4.TextColor = System.Drawing.Color.White;
            this.Button_4.UseVisualStyleBackColor = false;
            this.Button_4.Click += new System.EventHandler(this.Keys);
            // 
            // Button_Dot
            // 
            this.Button_Dot.BackColor = System.Drawing.Color.SteelBlue;
            this.Button_Dot.BackgroundColor = System.Drawing.Color.SteelBlue;
            this.Button_Dot.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.Button_Dot.BorderRadius = 4;
            this.Button_Dot.BorderSize = 0;
            this.Button_Dot.FlatAppearance.BorderSize = 0;
            this.Button_Dot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Dot.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Button_Dot.ForeColor = System.Drawing.Color.White;
            this.Button_Dot.Location = new System.Drawing.Point(797, 209);
            this.Button_Dot.Name = "Button_Dot";
            this.Button_Dot.Size = new System.Drawing.Size(55, 55);
            this.Button_Dot.TabIndex = 147;
            this.Button_Dot.Tag = ".";
            this.Button_Dot.Text = ".";
            this.Button_Dot.TextColor = System.Drawing.Color.White;
            this.Button_Dot.UseVisualStyleBackColor = false;
            this.Button_Dot.Click += new System.EventHandler(this.Keys);
            // 
            // Button_BackSpace
            // 
            this.Button_BackSpace.BackColor = System.Drawing.Color.SteelBlue;
            this.Button_BackSpace.BackgroundColor = System.Drawing.Color.SteelBlue;
            this.Button_BackSpace.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.Button_BackSpace.BorderRadius = 4;
            this.Button_BackSpace.BorderSize = 0;
            this.Button_BackSpace.FlatAppearance.BorderSize = 0;
            this.Button_BackSpace.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_BackSpace.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Button_BackSpace.ForeColor = System.Drawing.Color.White;
            this.Button_BackSpace.Location = new System.Drawing.Point(856, 208);
            this.Button_BackSpace.Name = "Button_BackSpace";
            this.Button_BackSpace.Size = new System.Drawing.Size(54, 55);
            this.Button_BackSpace.TabIndex = 146;
            this.Button_BackSpace.Tag = "{BACKSPACE}";
            this.Button_BackSpace.Text = "←";
            this.Button_BackSpace.TextColor = System.Drawing.Color.White;
            this.Button_BackSpace.UseVisualStyleBackColor = false;
            this.Button_BackSpace.Click += new System.EventHandler(this.Keys);
            // 
            // Button_0
            // 
            this.Button_0.BackColor = System.Drawing.Color.SteelBlue;
            this.Button_0.BackgroundColor = System.Drawing.Color.SteelBlue;
            this.Button_0.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.Button_0.BorderRadius = 4;
            this.Button_0.BorderSize = 0;
            this.Button_0.FlatAppearance.BorderSize = 0;
            this.Button_0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_0.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Button_0.ForeColor = System.Drawing.Color.White;
            this.Button_0.Location = new System.Drawing.Point(738, 209);
            this.Button_0.Name = "Button_0";
            this.Button_0.Size = new System.Drawing.Size(55, 55);
            this.Button_0.TabIndex = 145;
            this.Button_0.Tag = "0";
            this.Button_0.Text = "0";
            this.Button_0.TextColor = System.Drawing.Color.White;
            this.Button_0.UseVisualStyleBackColor = false;
            this.Button_0.Click += new System.EventHandler(this.Keys);
            // 
            // Button_9
            // 
            this.Button_9.BackColor = System.Drawing.Color.SteelBlue;
            this.Button_9.BackgroundColor = System.Drawing.Color.SteelBlue;
            this.Button_9.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.Button_9.BorderRadius = 4;
            this.Button_9.BorderSize = 0;
            this.Button_9.FlatAppearance.BorderSize = 0;
            this.Button_9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_9.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Button_9.ForeColor = System.Drawing.Color.White;
            this.Button_9.Location = new System.Drawing.Point(855, 36);
            this.Button_9.Name = "Button_9";
            this.Button_9.Size = new System.Drawing.Size(55, 55);
            this.Button_9.TabIndex = 150;
            this.Button_9.Tag = "9";
            this.Button_9.Text = "9";
            this.Button_9.TextColor = System.Drawing.Color.White;
            this.Button_9.UseVisualStyleBackColor = false;
            this.Button_9.Click += new System.EventHandler(this.Keys);
            // 
            // Button_8
            // 
            this.Button_8.BackColor = System.Drawing.Color.SteelBlue;
            this.Button_8.BackgroundColor = System.Drawing.Color.SteelBlue;
            this.Button_8.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.Button_8.BorderRadius = 4;
            this.Button_8.BorderSize = 0;
            this.Button_8.FlatAppearance.BorderSize = 0;
            this.Button_8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_8.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Button_8.ForeColor = System.Drawing.Color.White;
            this.Button_8.Location = new System.Drawing.Point(797, 36);
            this.Button_8.Name = "Button_8";
            this.Button_8.Size = new System.Drawing.Size(55, 55);
            this.Button_8.TabIndex = 149;
            this.Button_8.Tag = "8";
            this.Button_8.Text = "8";
            this.Button_8.TextColor = System.Drawing.Color.White;
            this.Button_8.UseVisualStyleBackColor = false;
            this.Button_8.Click += new System.EventHandler(this.Keys);
            // 
            // Button_7
            // 
            this.Button_7.BackColor = System.Drawing.Color.SteelBlue;
            this.Button_7.BackgroundColor = System.Drawing.Color.SteelBlue;
            this.Button_7.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.Button_7.BorderRadius = 4;
            this.Button_7.BorderSize = 0;
            this.Button_7.FlatAppearance.BorderSize = 0;
            this.Button_7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_7.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Button_7.ForeColor = System.Drawing.Color.White;
            this.Button_7.Location = new System.Drawing.Point(739, 36);
            this.Button_7.Name = "Button_7";
            this.Button_7.Size = new System.Drawing.Size(55, 55);
            this.Button_7.TabIndex = 148;
            this.Button_7.Tag = "7";
            this.Button_7.Text = "7";
            this.Button_7.TextColor = System.Drawing.Color.White;
            this.Button_7.UseVisualStyleBackColor = false;
            this.Button_7.Click += new System.EventHandler(this.Keys);
            // 
            // Imagen
            // 
            this.Imagen.DataPropertyName = "Image";
            this.Imagen.Frozen = true;
            this.Imagen.HeaderText = "";
            this.Imagen.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.Imagen.Name = "Imagen";
            this.Imagen.ReadOnly = true;
            this.Imagen.Width = 50;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.Frozen = true;
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            this.Id.Width = 5;
            // 
            // Denomination
            // 
            this.Denomination.DataPropertyName = "Denomination";
            this.Denomination.Frozen = true;
            this.Denomination.HeaderText = "Denominacion";
            this.Denomination.Name = "Denomination";
            this.Denomination.ReadOnly = true;
            this.Denomination.Width = 280;
            // 
            // Quantity
            // 
            this.Quantity.DataPropertyName = "Quantity";
            this.Quantity.Frozen = true;
            this.Quantity.HeaderText = "Cantidad";
            this.Quantity.Name = "Quantity";
            this.Quantity.Width = 90;
            // 
            // Amount
            // 
            this.Amount.DataPropertyName = "Amount";
            this.Amount.Frozen = true;
            this.Amount.HeaderText = "Importe";
            this.Amount.Name = "Amount";
            this.Amount.Width = 240;
            // 
            // EnvelopeDepositForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 614);
            this.ControlBox = false;
            this.Controls.Add(this.Button_3);
            this.Controls.Add(this.Button_9);
            this.Controls.Add(this.Button_8);
            this.Controls.Add(this.Button_7);
            this.Controls.Add(this.Button_Dot);
            this.Controls.Add(this.Button_BackSpace);
            this.Controls.Add(this.Button_0);
            this.Controls.Add(this.Button_6);
            this.Controls.Add(this.Button_5);
            this.Controls.Add(this.Button_4);
            this.Controls.Add(this.Button_2);
            this.Controls.Add(this.Button_1);
            this.Controls.Add(this.EnvelopeTextBox);
            this.Controls.Add(this.EventCheckbox);
            this.Controls.Add(this.InformationLabel);
            this.Controls.Add(this.DenominationsGridView);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.SubtotalLabel);
            this.Controls.Add(this.CurrencyLabel);
            this.Controls.Add(this.ConfirmAndExitDepositButton);
            this.Controls.Add(this.CancelDepositButton);
            this.Controls.Add(this.MonitorGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EnvelopeDepositForm";
            this.Load += new System.EventHandler(this.EnvelopeDepositForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DenominationsGridView)).EndInit();
            this.MonitorGroupBox.ResumeLayout(false);
            this.MonitorGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.denominationItemBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private CustomButton BackButton;
        private Label label4;
        private Label SubtotalLabel;
        private Label CurrencyLabel;
        private CustomButton ConfirmAndExitDepositButton;
        private CustomButton CancelDepositButton;
        private DataGridView DenominationsGridView;
        private Label InformationLabel;
        private CheckBox EventCheckbox;
        private GroupBox MonitorGroupBox;
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
        private BindingSource denominationItemBindingSource;
        private DataGridViewCheckBoxColumn Checkcolumn;
        private CustomTextBox EnvelopeTextBox;
        private DataGridViewTextBoxColumn Aount;
        private DataGridViewTextBoxColumn Cantidad;
        private CustomButton Button_3;
        private CustomButton Button_2;
        private CustomButton Button_1;
        private CustomButton Button_6;
        private CustomButton Button_5;
        private CustomButton Button_4;
        private CustomButton Button_Dot;
        private CustomButton Button_BackSpace;
        private CustomButton Button_0;
        private CustomButton Button_9;
        private CustomButton Button_8;
        private CustomButton Button_7;
        private DataGridViewImageColumn Imagen;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn Denomination;
        private DataGridViewTextBoxColumn Quantity;
        private DataGridViewTextBoxColumn Amount;
    }
}