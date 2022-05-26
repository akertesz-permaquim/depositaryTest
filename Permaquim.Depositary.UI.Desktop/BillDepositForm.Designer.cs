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
            this.BillResumeListview = new Permaquim.Depositary.UI.Desktop.Controls.CustomListview();
            this.Denominacion = new System.Windows.Forms.ColumnHeader();
            this.Cantidad = new System.Windows.Forms.ColumnHeader();
            this.CancelDepositButton = new Permaquim.Depositary.UI.Desktop.CustomButton();
            this.BackButton = new Permaquim.Depositary.UI.Desktop.CustomButton();
            this.ConfirmAndExitDepositButton = new Permaquim.Depositary.UI.Desktop.CustomButton();
            this.MonitorGroupBox = new System.Windows.Forms.GroupBox();
            this.DenominationsLabel = new System.Windows.Forms.Label();
            this.DepositFinishedCheckbox = new System.Windows.Forms.CheckBox();
            this.HopperBillPresentCheckBox = new System.Windows.Forms.CheckBox();
            this.EscrowBillPresentCheckBox = new System.Windows.Forms.CheckBox();
            this.DischargingFailureCheckBox = new System.Windows.Forms.CheckBox();
            this.RejectedBillPresentCheckBox = new System.Windows.Forms.CheckBox();
            this.RejectFullCheckBox = new System.Windows.Forms.CheckBox();
            this.StackerFullCheckBox = new System.Windows.Forms.CheckBox();
            this.DeviceModeLabel = new System.Windows.Forms.Label();
            this.GeneralStatusLabel = new System.Windows.Forms.Label();
            this.TotalLabel = new System.Windows.Forms.Label();
            this.MonitorGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // BillResumeListview
            // 
            this.BillResumeListview.BackColor = System.Drawing.Color.White;
            this.BillResumeListview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BillResumeListview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Denominacion,
            this.Cantidad});
            this.BillResumeListview.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BillResumeListview.ForeColor = System.Drawing.Color.SteelBlue;
            this.BillResumeListview.Location = new System.Drawing.Point(16, 24);
            this.BillResumeListview.Name = "BillResumeListview";
            this.BillResumeListview.Size = new System.Drawing.Size(560, 272);
            this.BillResumeListview.TabIndex = 0;
            this.BillResumeListview.UseCompatibleStateImageBehavior = false;
            this.BillResumeListview.View = System.Windows.Forms.View.Details;
            // 
            // Denominacion
            // 
            this.Denominacion.Text = "Denominación";
            this.Denominacion.Width = 250;
            // 
            // Cantidad
            // 
            this.Cantidad.Text = "Cantidad";
            this.Cantidad.Width = 200;
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
            this.CancelDepositButton.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CancelDepositButton.ForeColor = System.Drawing.Color.White;
            this.CancelDepositButton.Location = new System.Drawing.Point(240, 312);
            this.CancelDepositButton.Name = "CancelDepositButton";
            this.CancelDepositButton.Size = new System.Drawing.Size(152, 55);
            this.CancelDepositButton.TabIndex = 93;
            this.CancelDepositButton.Tag = "";
            this.CancelDepositButton.Text = "Cancelar";
            this.CancelDepositButton.TextColor = System.Drawing.Color.White;
            this.CancelDepositButton.UseVisualStyleBackColor = false;
            this.CancelDepositButton.Click += new System.EventHandler(this.CancelDepositButton_Click);
            // 
            // BackButton
            // 
            this.BackButton.BackColor = System.Drawing.Color.SteelBlue;
            this.BackButton.BackgroundColor = System.Drawing.Color.SteelBlue;
            this.BackButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BackButton.BorderRadius = 4;
            this.BackButton.BorderSize = 0;
            this.BackButton.FlatAppearance.BorderSize = 0;
            this.BackButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackButton.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BackButton.ForeColor = System.Drawing.Color.White;
            this.BackButton.Location = new System.Drawing.Point(592, 312);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(193, 55);
            this.BackButton.TabIndex = 95;
            this.BackButton.Tag = "";
            this.BackButton.Text = "Volver";
            this.BackButton.TextColor = System.Drawing.Color.White;
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
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
            this.ConfirmAndExitDepositButton.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ConfirmAndExitDepositButton.ForeColor = System.Drawing.Color.White;
            this.ConfirmAndExitDepositButton.Location = new System.Drawing.Point(408, 312);
            this.ConfirmAndExitDepositButton.Name = "ConfirmAndExitDepositButton";
            this.ConfirmAndExitDepositButton.Size = new System.Drawing.Size(152, 55);
            this.ConfirmAndExitDepositButton.TabIndex = 98;
            this.ConfirmAndExitDepositButton.Tag = "";
            this.ConfirmAndExitDepositButton.Text = "Confirmar ";
            this.ConfirmAndExitDepositButton.TextColor = System.Drawing.Color.White;
            this.ConfirmAndExitDepositButton.UseVisualStyleBackColor = false;
            this.ConfirmAndExitDepositButton.Click += new System.EventHandler(this.ConfirmAndExitDepositButton_Click);
            // 
            // MonitorGroupBox
            // 
            this.MonitorGroupBox.BackColor = System.Drawing.Color.White;
            this.MonitorGroupBox.Controls.Add(this.DenominationsLabel);
            this.MonitorGroupBox.Controls.Add(this.DepositFinishedCheckbox);
            this.MonitorGroupBox.Controls.Add(this.HopperBillPresentCheckBox);
            this.MonitorGroupBox.Controls.Add(this.EscrowBillPresentCheckBox);
            this.MonitorGroupBox.Controls.Add(this.DischargingFailureCheckBox);
            this.MonitorGroupBox.Controls.Add(this.RejectedBillPresentCheckBox);
            this.MonitorGroupBox.Controls.Add(this.RejectFullCheckBox);
            this.MonitorGroupBox.Controls.Add(this.StackerFullCheckBox);
            this.MonitorGroupBox.Controls.Add(this.DeviceModeLabel);
            this.MonitorGroupBox.Controls.Add(this.GeneralStatusLabel);
            this.MonitorGroupBox.Location = new System.Drawing.Point(592, 24);
            this.MonitorGroupBox.Name = "MonitorGroupBox";
            this.MonitorGroupBox.Size = new System.Drawing.Size(200, 288);
            this.MonitorGroupBox.TabIndex = 99;
            this.MonitorGroupBox.TabStop = false;
            this.MonitorGroupBox.Text = "Monitor";
            // 
            // DenominationsLabel
            // 
            this.DenominationsLabel.AutoSize = true;
            this.DenominationsLabel.BackColor = System.Drawing.Color.White;
            this.DenominationsLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.DenominationsLabel.ForeColor = System.Drawing.Color.SteelBlue;
            this.DenominationsLabel.Location = new System.Drawing.Point(32, 256);
            this.DenominationsLabel.Name = "DenominationsLabel";
            this.DenominationsLabel.Size = new System.Drawing.Size(94, 15);
            this.DenominationsLabel.TabIndex = 34;
            this.DenominationsLabel.Text = "Denominations:";
            // 
            // DepositFinishedCheckbox
            // 
            this.DepositFinishedCheckbox.AutoSize = true;
            this.DepositFinishedCheckbox.BackColor = System.Drawing.Color.White;
            this.DepositFinishedCheckbox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.DepositFinishedCheckbox.ForeColor = System.Drawing.Color.SteelBlue;
            this.DepositFinishedCheckbox.Location = new System.Drawing.Point(30, 232);
            this.DepositFinishedCheckbox.Name = "DepositFinishedCheckbox";
            this.DepositFinishedCheckbox.Size = new System.Drawing.Size(116, 19);
            this.DepositFinishedCheckbox.TabIndex = 33;
            this.DepositFinishedCheckbox.Text = "Deposit finished";
            this.DepositFinishedCheckbox.UseVisualStyleBackColor = false;
            // 
            // HopperBillPresentCheckBox
            // 
            this.HopperBillPresentCheckBox.AutoSize = true;
            this.HopperBillPresentCheckBox.BackColor = System.Drawing.Color.White;
            this.HopperBillPresentCheckBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.HopperBillPresentCheckBox.ForeColor = System.Drawing.Color.SteelBlue;
            this.HopperBillPresentCheckBox.Location = new System.Drawing.Point(29, 207);
            this.HopperBillPresentCheckBox.Name = "HopperBillPresentCheckBox";
            this.HopperBillPresentCheckBox.Size = new System.Drawing.Size(134, 19);
            this.HopperBillPresentCheckBox.TabIndex = 32;
            this.HopperBillPresentCheckBox.Text = "Hopper Bill Present";
            this.HopperBillPresentCheckBox.UseVisualStyleBackColor = false;
            // 
            // EscrowBillPresentCheckBox
            // 
            this.EscrowBillPresentCheckBox.AutoSize = true;
            this.EscrowBillPresentCheckBox.BackColor = System.Drawing.Color.White;
            this.EscrowBillPresentCheckBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.EscrowBillPresentCheckBox.ForeColor = System.Drawing.Color.SteelBlue;
            this.EscrowBillPresentCheckBox.Location = new System.Drawing.Point(29, 183);
            this.EscrowBillPresentCheckBox.Name = "EscrowBillPresentCheckBox";
            this.EscrowBillPresentCheckBox.Size = new System.Drawing.Size(131, 19);
            this.EscrowBillPresentCheckBox.TabIndex = 31;
            this.EscrowBillPresentCheckBox.Text = "Escrow Bill Present";
            this.EscrowBillPresentCheckBox.UseVisualStyleBackColor = false;
            // 
            // DischargingFailureCheckBox
            // 
            this.DischargingFailureCheckBox.AutoSize = true;
            this.DischargingFailureCheckBox.BackColor = System.Drawing.Color.White;
            this.DischargingFailureCheckBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.DischargingFailureCheckBox.ForeColor = System.Drawing.Color.SteelBlue;
            this.DischargingFailureCheckBox.Location = new System.Drawing.Point(29, 159);
            this.DischargingFailureCheckBox.Name = "DischargingFailureCheckBox";
            this.DischargingFailureCheckBox.Size = new System.Drawing.Size(131, 19);
            this.DischargingFailureCheckBox.TabIndex = 30;
            this.DischargingFailureCheckBox.Text = "Discharging Failure";
            this.DischargingFailureCheckBox.UseVisualStyleBackColor = false;
            // 
            // RejectedBillPresentCheckBox
            // 
            this.RejectedBillPresentCheckBox.AutoSize = true;
            this.RejectedBillPresentCheckBox.BackColor = System.Drawing.Color.White;
            this.RejectedBillPresentCheckBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.RejectedBillPresentCheckBox.ForeColor = System.Drawing.Color.SteelBlue;
            this.RejectedBillPresentCheckBox.Location = new System.Drawing.Point(29, 135);
            this.RejectedBillPresentCheckBox.Name = "RejectedBillPresentCheckBox";
            this.RejectedBillPresentCheckBox.Size = new System.Drawing.Size(142, 19);
            this.RejectedBillPresentCheckBox.TabIndex = 29;
            this.RejectedBillPresentCheckBox.Text = "Rejected Bill Present";
            this.RejectedBillPresentCheckBox.UseVisualStyleBackColor = false;
            // 
            // RejectFullCheckBox
            // 
            this.RejectFullCheckBox.AutoSize = true;
            this.RejectFullCheckBox.BackColor = System.Drawing.Color.White;
            this.RejectFullCheckBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.RejectFullCheckBox.ForeColor = System.Drawing.Color.SteelBlue;
            this.RejectFullCheckBox.Location = new System.Drawing.Point(29, 111);
            this.RejectFullCheckBox.Name = "RejectFullCheckBox";
            this.RejectFullCheckBox.Size = new System.Drawing.Size(84, 19);
            this.RejectFullCheckBox.TabIndex = 28;
            this.RejectFullCheckBox.Text = "Reject Full";
            this.RejectFullCheckBox.UseVisualStyleBackColor = false;
            // 
            // StackerFullCheckBox
            // 
            this.StackerFullCheckBox.AutoSize = true;
            this.StackerFullCheckBox.BackColor = System.Drawing.Color.White;
            this.StackerFullCheckBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.StackerFullCheckBox.ForeColor = System.Drawing.Color.SteelBlue;
            this.StackerFullCheckBox.Location = new System.Drawing.Point(29, 87);
            this.StackerFullCheckBox.Name = "StackerFullCheckBox";
            this.StackerFullCheckBox.Size = new System.Drawing.Size(91, 19);
            this.StackerFullCheckBox.TabIndex = 27;
            this.StackerFullCheckBox.Text = "Stacker Full";
            this.StackerFullCheckBox.UseVisualStyleBackColor = false;
            // 
            // DeviceModeLabel
            // 
            this.DeviceModeLabel.AutoSize = true;
            this.DeviceModeLabel.BackColor = System.Drawing.Color.White;
            this.DeviceModeLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.DeviceModeLabel.ForeColor = System.Drawing.Color.SteelBlue;
            this.DeviceModeLabel.Location = new System.Drawing.Point(29, 63);
            this.DeviceModeLabel.Name = "DeviceModeLabel";
            this.DeviceModeLabel.Size = new System.Drawing.Size(78, 15);
            this.DeviceModeLabel.TabIndex = 26;
            this.DeviceModeLabel.Text = "DeviceMode";
            // 
            // GeneralStatusLabel
            // 
            this.GeneralStatusLabel.AutoSize = true;
            this.GeneralStatusLabel.BackColor = System.Drawing.Color.White;
            this.GeneralStatusLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.GeneralStatusLabel.ForeColor = System.Drawing.Color.SteelBlue;
            this.GeneralStatusLabel.Location = new System.Drawing.Point(29, 39);
            this.GeneralStatusLabel.Name = "GeneralStatusLabel";
            this.GeneralStatusLabel.Size = new System.Drawing.Size(86, 15);
            this.GeneralStatusLabel.TabIndex = 25;
            this.GeneralStatusLabel.Text = "GeneralStatus";
            // 
            // TotalLabel
            // 
            this.TotalLabel.AutoSize = true;
            this.TotalLabel.BackColor = System.Drawing.Color.SteelBlue;
            this.TotalLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TotalLabel.ForeColor = System.Drawing.Color.White;
            this.TotalLabel.Location = new System.Drawing.Point(640, 392);
            this.TotalLabel.Name = "TotalLabel";
            this.TotalLabel.Size = new System.Drawing.Size(65, 25);
            this.TotalLabel.TabIndex = 100;
            this.TotalLabel.Text = "Total :";
            // 
            // BillDepositForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 485);
            this.ControlBox = false;
            this.Controls.Add(this.TotalLabel);
            this.Controls.Add(this.MonitorGroupBox);
            this.Controls.Add(this.ConfirmAndExitDepositButton);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.CancelDepositButton);
            this.Controls.Add(this.BillResumeListview);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "BillDepositForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.BillDepositForm_Load);
            this.MonitorGroupBox.ResumeLayout(false);
            this.MonitorGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ColumnHeader Denominacion;
        private ColumnHeader Cantidad;
        private CustomButton CancelDepositButton;
        private CustomButton BackButton;
        private Controls.CustomListview BillResumeListview;
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
        private Label TotalLabel;
        private Label DenominationsLabel;
    }
}