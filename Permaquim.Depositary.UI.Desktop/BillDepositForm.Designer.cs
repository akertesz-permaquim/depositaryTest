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
            this.CancelDepositButton = new Permaquim.Depositary.UI.Desktop.CustomButton();
            this.ConfirmAndExitDepositButton = new Permaquim.Depositary.UI.Desktop.CustomButton();
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
            this.SubtotalLabel = new System.Windows.Forms.Label();
            this.CurrencyLabel = new System.Windows.Forms.Label();
            this.RemainingTimeLabel = new System.Windows.Forms.Label();
            this.InformationLabel = new System.Windows.Forms.Label();
            this.EventCheckbox = new System.Windows.Forms.CheckBox();
            this.BackButton = new Permaquim.Depositary.UI.Desktop.CustomButton();
            this.DenominationsGridView = new System.Windows.Forms.DataGridView();
            this.Image = new System.Windows.Forms.DataGridViewImageColumn();
            this.Denomination = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ConfirmAndContinueDepositButton = new Permaquim.Depositary.UI.Desktop.CustomButton();
            this.MonitorGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DenominationsGridView)).BeginInit();
            this.SuspendLayout();
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
            this.CancelDepositButton.Location = new System.Drawing.Point(162, 492);
            this.CancelDepositButton.Name = "CancelDepositButton";
            this.CancelDepositButton.Size = new System.Drawing.Size(230, 55);
            this.CancelDepositButton.TabIndex = 93;
            this.CancelDepositButton.Tag = "";
            this.CancelDepositButton.Text = "Cancelar";
            this.CancelDepositButton.TextColor = System.Drawing.Color.White;
            this.CancelDepositButton.UseVisualStyleBackColor = false;
            this.CancelDepositButton.Visible = false;
            this.CancelDepositButton.Click += new System.EventHandler(this.CancelDepositButton_Click);
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
            this.ConfirmAndExitDepositButton.Location = new System.Drawing.Point(632, 493);
            this.ConfirmAndExitDepositButton.Name = "ConfirmAndExitDepositButton";
            this.ConfirmAndExitDepositButton.Size = new System.Drawing.Size(234, 55);
            this.ConfirmAndExitDepositButton.TabIndex = 98;
            this.ConfirmAndExitDepositButton.Tag = "";
            this.ConfirmAndExitDepositButton.Text = "Confirmar ";
            this.ConfirmAndExitDepositButton.TextColor = System.Drawing.Color.White;
            this.ConfirmAndExitDepositButton.UseVisualStyleBackColor = false;
            this.ConfirmAndExitDepositButton.Visible = false;
            this.ConfirmAndExitDepositButton.Click += new System.EventHandler(this.ConfirmAndExitDepositButton_Click);
            // 
            // MonitorGroupBox
            // 
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
            this.MonitorGroupBox.Location = new System.Drawing.Point(872, 60);
            this.MonitorGroupBox.Name = "MonitorGroupBox";
            this.MonitorGroupBox.Size = new System.Drawing.Size(152, 308);
            this.MonitorGroupBox.TabIndex = 99;
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
            // SubtotalLabel
            // 
            this.SubtotalLabel.BackColor = System.Drawing.Color.SteelBlue;
            this.SubtotalLabel.Font = new System.Drawing.Font("Verdana", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SubtotalLabel.ForeColor = System.Drawing.Color.White;
            this.SubtotalLabel.Location = new System.Drawing.Point(368, 20);
            this.SubtotalLabel.Name = "SubtotalLabel";
            this.SubtotalLabel.Size = new System.Drawing.Size(248, 27);
            this.SubtotalLabel.TabIndex = 103;
            this.SubtotalLabel.Text = "Sub total: $ 0";
            // 
            // CurrencyLabel
            // 
            this.CurrencyLabel.BackColor = System.Drawing.Color.SteelBlue;
            this.CurrencyLabel.Font = new System.Drawing.Font("Verdana", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CurrencyLabel.ForeColor = System.Drawing.Color.White;
            this.CurrencyLabel.Location = new System.Drawing.Point(167, 20);
            this.CurrencyLabel.Name = "CurrencyLabel";
            this.CurrencyLabel.Size = new System.Drawing.Size(201, 27);
            this.CurrencyLabel.TabIndex = 102;
            this.CurrencyLabel.Text = "Divisa: Pesos";
            // 
            // RemainingTimeLabel
            // 
            this.RemainingTimeLabel.BackColor = System.Drawing.Color.SteelBlue;
            this.RemainingTimeLabel.Font = new System.Drawing.Font("Verdana", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RemainingTimeLabel.ForeColor = System.Drawing.Color.White;
            this.RemainingTimeLabel.Location = new System.Drawing.Point(616, 20);
            this.RemainingTimeLabel.Name = "RemainingTimeLabel";
            this.RemainingTimeLabel.Size = new System.Drawing.Size(248, 27);
            this.RemainingTimeLabel.TabIndex = 105;
            this.RemainingTimeLabel.Text = "Tiempo restante: ";
            // 
            // InformationLabel
            // 
            this.InformationLabel.BackColor = System.Drawing.Color.Transparent;
            this.InformationLabel.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.InformationLabel.ForeColor = System.Drawing.Color.Red;
            this.InformationLabel.Location = new System.Drawing.Point(160, 552);
            this.InformationLabel.Name = "InformationLabel";
            this.InformationLabel.Size = new System.Drawing.Size(704, 72);
            this.InformationLabel.TabIndex = 107;
            this.InformationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EventCheckbox
            // 
            this.EventCheckbox.AutoSize = true;
            this.EventCheckbox.BackColor = System.Drawing.Color.Transparent;
            this.EventCheckbox.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.EventCheckbox.ForeColor = System.Drawing.Color.SteelBlue;
            this.EventCheckbox.Location = new System.Drawing.Point(888, 520);
            this.EventCheckbox.Name = "EventCheckbox";
            this.EventCheckbox.Size = new System.Drawing.Size(71, 17);
            this.EventCheckbox.TabIndex = 108;
            this.EventCheckbox.Text = "Eventos";
            this.EventCheckbox.UseVisualStyleBackColor = false;
            this.EventCheckbox.CheckedChanged += new System.EventHandler(this.EventCheckbox_CheckedChanged);
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
            this.BackButton.Location = new System.Drawing.Point(404, 493);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(216, 55);
            this.BackButton.TabIndex = 109;
            this.BackButton.Text = "Salir";
            this.BackButton.TextColor = System.Drawing.Color.White;
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
            this.DenominationsGridView.GridColor = System.Drawing.Color.White;
            this.DenominationsGridView.Location = new System.Drawing.Point(168, 48);
            this.DenominationsGridView.Name = "DenominationsGridView";
            this.DenominationsGridView.RowHeadersVisible = false;
            this.DenominationsGridView.RowTemplate.DividerHeight = 1;
            this.DenominationsGridView.RowTemplate.Height = 50;
            this.DenominationsGridView.RowTemplate.ReadOnly = true;
            this.DenominationsGridView.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.DenominationsGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DenominationsGridView.Size = new System.Drawing.Size(696, 440);
            this.DenominationsGridView.TabIndex = 134;
            this.DenominationsGridView.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.DenominationsGridView_CellPainting);
            // 
            // Image
            // 
            this.Image.DataPropertyName = "Image";
            this.Image.Frozen = true;
            this.Image.HeaderText = "Imágen";
            this.Image.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.Image.Name = "Image";
            this.Image.ReadOnly = true;
            this.Image.Width = 105;
            // 
            // Denomination
            // 
            this.Denomination.DataPropertyName = "Denomination";
            this.Denomination.HeaderText = "Denominación";
            this.Denomination.Name = "Denomination";
            this.Denomination.ReadOnly = true;
            this.Denomination.Width = 260;
            // 
            // Quantity
            // 
            this.Quantity.DataPropertyName = "Quantity";
            this.Quantity.HeaderText = "Cantidad";
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            this.Quantity.Width = 110;
            // 
            // Amount
            // 
            this.Amount.DataPropertyName = "Amount";
            this.Amount.HeaderText = "Importe";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            this.Amount.Width = 220;
            // 
            // ConfirmAndContinueDepositButton
            // 
            this.ConfirmAndContinueDepositButton.BackColor = System.Drawing.Color.SeaGreen;
            this.ConfirmAndContinueDepositButton.BackgroundColor = System.Drawing.Color.SeaGreen;
            this.ConfirmAndContinueDepositButton.BorderColor = System.Drawing.Color.MediumSeaGreen;
            this.ConfirmAndContinueDepositButton.BorderRadius = 4;
            this.ConfirmAndContinueDepositButton.BorderSize = 0;
            this.ConfirmAndContinueDepositButton.FlatAppearance.BorderSize = 0;
            this.ConfirmAndContinueDepositButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConfirmAndContinueDepositButton.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ConfirmAndContinueDepositButton.ForeColor = System.Drawing.Color.White;
            this.ConfirmAndContinueDepositButton.Location = new System.Drawing.Point(405, 493);
            this.ConfirmAndContinueDepositButton.Name = "ConfirmAndContinueDepositButton";
            this.ConfirmAndContinueDepositButton.Size = new System.Drawing.Size(214, 55);
            this.ConfirmAndContinueDepositButton.TabIndex = 135;
            this.ConfirmAndContinueDepositButton.Tag = "";
            this.ConfirmAndContinueDepositButton.Text = "Continuar";
            this.ConfirmAndContinueDepositButton.TextColor = System.Drawing.Color.White;
            this.ConfirmAndContinueDepositButton.UseVisualStyleBackColor = false;
            this.ConfirmAndContinueDepositButton.Visible = false;
            this.ConfirmAndContinueDepositButton.Click += new System.EventHandler(this.ConfirmAndContinueDepositButton_Click);
            // 
            // BillDepositForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1026, 641);
            this.ControlBox = false;
            this.Controls.Add(this.ConfirmAndContinueDepositButton);
            this.Controls.Add(this.DenominationsGridView);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.EventCheckbox);
            this.Controls.Add(this.InformationLabel);
            this.Controls.Add(this.RemainingTimeLabel);
            this.Controls.Add(this.SubtotalLabel);
            this.Controls.Add(this.CurrencyLabel);
            this.Controls.Add(this.MonitorGroupBox);
            this.Controls.Add(this.ConfirmAndExitDepositButton);
            this.Controls.Add(this.CancelDepositButton);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "BillDepositForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.BillDepositForm_Load);
            this.MonitorGroupBox.ResumeLayout(false);
            this.MonitorGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DenominationsGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private CustomButton CancelDepositButton;
        private CustomButton ConfirmAndExitDepositButton;
        private GroupBox MonitorGroupBox;
        private CheckBox HopperBillPresentCheckBox;
        private CheckBox EscrowBillPresentCheckBox;
        private CheckBox DischargingFailureCheckBox;
        private CheckBox RejectedBillPresentCheckBox;
        private CheckBox RejectFullCheckBox;
        private CheckBox StackerFullCheckBox;
        private Label DeviceModeLabel;
        private Label GeneralStatusLabel;
        private CheckBox DepositFinishedCheckbox;
        private CheckBox CountingErrorCheckBox;
        private CheckBox JammingCheckBox;
        private Label SubtotalLabel;
        private Label CurrencyLabel;
        private Label RemainingTimeLabel;
        private Label InformationLabel;
        private CheckBox EventCheckbox;
        private CustomButton BackButton;
        private DataGridView DenominationsGridView;
        private DataGridViewImageColumn Image;
        private DataGridViewTextBoxColumn Denominacion;
        private DataGridViewTextBoxColumn Cantidad;
        private DataGridViewTextBoxColumn Importe;
        private Label CurrencyStatusLabel;
        private CustomButton ConfirmAndContinueDepositButton;
        private DataGridViewTextBoxColumn Denomination;
        private DataGridViewTextBoxColumn Quantity;
        private DataGridViewTextBoxColumn Amount;
    }
}