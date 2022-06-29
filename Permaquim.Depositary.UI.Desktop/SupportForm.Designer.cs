namespace Permaquim.Depositary.UI.Desktop
{
    partial class SupportForm
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
            this.MainPanel = new System.Windows.Forms.Panel();
            this.ModeCheckBox = new System.Windows.Forms.CheckBox();
            this.BackButton = new Permaquim.Depositary.UI.Desktop.CustomButton();
            this.IoBoardStatusGroup = new System.Windows.Forms.GroupBox();
            this.ExecuteIoBoardComandButton = new System.Windows.Forms.Button();
            this.IoboardCommandComboBox = new System.Windows.Forms.ComboBox();
            this.IoBoardResponseTextBox = new CustomTextBox();
            this.IoBoardStatusPropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.CounterStatudGroupBox = new System.Windows.Forms.GroupBox();
            this.CounterComboBox = new System.Windows.Forms.ComboBox();
            this.CounterResponseTextBox = new CustomTextBox();
            this.ExecuteCounterComandButton = new System.Windows.Forms.Button();
            this.CounterStatusPropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.CounterCommandComboBox = new System.Windows.Forms.ComboBox();
            this.MainPanel.SuspendLayout();
            this.IoBoardStatusGroup.SuspendLayout();
            this.CounterStatudGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.ModeCheckBox);
            this.MainPanel.Controls.Add(this.BackButton);
            this.MainPanel.Controls.Add(this.IoBoardStatusGroup);
            this.MainPanel.Controls.Add(this.CounterStatudGroupBox);
            this.MainPanel.Location = new System.Drawing.Point(0, 8);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1056, 648);
            this.MainPanel.TabIndex = 0;
            // 
            // ModeCheckBox
            // 
            this.ModeCheckBox.AutoSize = true;
            this.ModeCheckBox.Location = new System.Drawing.Point(32, 24);
            this.ModeCheckBox.Name = "ModeCheckBox";
            this.ModeCheckBox.Size = new System.Drawing.Size(68, 19);
            this.ModeCheckBox.TabIndex = 158;
            this.ModeCheckBox.Text = "Append";
            this.ModeCheckBox.UseVisualStyleBackColor = true;
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
            this.BackButton.Location = new System.Drawing.Point(416, 584);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(160, 55);
            this.BackButton.TabIndex = 157;
            this.BackButton.Text = "Salir";
            this.BackButton.TextColor = System.Drawing.Color.White;
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // IoBoardStatusGroup
            // 
            this.IoBoardStatusGroup.Controls.Add(this.ExecuteIoBoardComandButton);
            this.IoBoardStatusGroup.Controls.Add(this.IoboardCommandComboBox);
            this.IoBoardStatusGroup.Controls.Add(this.IoBoardResponseTextBox);
            this.IoBoardStatusGroup.Controls.Add(this.IoBoardStatusPropertyGrid);
            this.IoBoardStatusGroup.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.IoBoardStatusGroup.ForeColor = System.Drawing.Color.SteelBlue;
            this.IoBoardStatusGroup.Location = new System.Drawing.Point(496, 56);
            this.IoBoardStatusGroup.Name = "IoBoardStatusGroup";
            this.IoBoardStatusGroup.Size = new System.Drawing.Size(472, 512);
            this.IoBoardStatusGroup.TabIndex = 33;
            this.IoBoardStatusGroup.TabStop = false;
            this.IoBoardStatusGroup.Text = "Estado IO Board";
            // 
            // ExecuteIoBoardComandButton
            // 
            this.ExecuteIoBoardComandButton.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ExecuteIoBoardComandButton.Location = new System.Drawing.Point(248, 16);
            this.ExecuteIoBoardComandButton.Name = "ExecuteIoBoardComandButton";
            this.ExecuteIoBoardComandButton.Size = new System.Drawing.Size(216, 27);
            this.ExecuteIoBoardComandButton.TabIndex = 163;
            this.ExecuteIoBoardComandButton.Text = "Ejecutar";
            this.ExecuteIoBoardComandButton.UseVisualStyleBackColor = true;
            this.ExecuteIoBoardComandButton.Click += new System.EventHandler(this.ExecuteIoBoardComandButton_Click);
            // 
            // IoboardCommandComboBox
            // 
            this.IoboardCommandComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.IoboardCommandComboBox.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.IoboardCommandComboBox.FormattingEnabled = true;
            this.IoboardCommandComboBox.Items.AddRange(new object[] {
            "Open ",
            "Close",
            "UnLock ",
            "Status ",
            "Empty",
            "Approve"});
            this.IoboardCommandComboBox.Location = new System.Drawing.Point(8, 16);
            this.IoboardCommandComboBox.Name = "IoboardCommandComboBox";
            this.IoboardCommandComboBox.Size = new System.Drawing.Size(232, 28);
            this.IoboardCommandComboBox.TabIndex = 162;
            // 
            // IoBoardResponseTextBox
            // 
            this.IoBoardResponseTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.IoBoardResponseTextBox.BorderColor = System.Drawing.Color.SteelBlue;
            this.IoBoardResponseTextBox.BorderFocusColor = System.Drawing.Color.MediumSlateBlue;
            this.IoBoardResponseTextBox.BorderRadius = 4;
            this.IoBoardResponseTextBox.BorderSize = 2;
            this.IoBoardResponseTextBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.IoBoardResponseTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.IoBoardResponseTextBox.Location = new System.Drawing.Point(8, 48);
            this.IoBoardResponseTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.IoBoardResponseTextBox.Multiline = true;
            this.IoBoardResponseTextBox.Name = "IoBoardResponseTextBox";
            this.IoBoardResponseTextBox.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.IoBoardResponseTextBox.PasswordChar = false;
            this.IoBoardResponseTextBox.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.IoBoardResponseTextBox.PlaceholderText = "Respuestas de la IO Board";
            this.IoBoardResponseTextBox.Size = new System.Drawing.Size(232, 448);
            this.IoBoardResponseTextBox.TabIndex = 161;
            this.IoBoardResponseTextBox.Texts = "";
            this.IoBoardResponseTextBox.UnderlinedStyle = false;
            // 
            // IoBoardStatusPropertyGrid
            // 
            this.IoBoardStatusPropertyGrid.CategoryForeColor = System.Drawing.Color.SteelBlue;
            this.IoBoardStatusPropertyGrid.DisabledItemForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(70)))), ((int)(((byte)(130)))), ((int)(((byte)(180)))));
            this.IoBoardStatusPropertyGrid.HelpVisible = false;
            this.IoBoardStatusPropertyGrid.Location = new System.Drawing.Point(248, 51);
            this.IoBoardStatusPropertyGrid.Name = "IoBoardStatusPropertyGrid";
            this.IoBoardStatusPropertyGrid.Size = new System.Drawing.Size(216, 445);
            this.IoBoardStatusPropertyGrid.TabIndex = 0;
            this.IoBoardStatusPropertyGrid.ViewBorderColor = System.Drawing.Color.SteelBlue;
            this.IoBoardStatusPropertyGrid.ViewForeColor = System.Drawing.Color.SteelBlue;
            // 
            // CounterStatudGroupBox
            // 
            this.CounterStatudGroupBox.Controls.Add(this.CounterComboBox);
            this.CounterStatudGroupBox.Controls.Add(this.CounterResponseTextBox);
            this.CounterStatudGroupBox.Controls.Add(this.ExecuteCounterComandButton);
            this.CounterStatudGroupBox.Controls.Add(this.CounterStatusPropertyGrid);
            this.CounterStatudGroupBox.Controls.Add(this.CounterCommandComboBox);
            this.CounterStatudGroupBox.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CounterStatudGroupBox.ForeColor = System.Drawing.Color.SteelBlue;
            this.CounterStatudGroupBox.Location = new System.Drawing.Point(16, 56);
            this.CounterStatudGroupBox.Name = "CounterStatudGroupBox";
            this.CounterStatudGroupBox.Size = new System.Drawing.Size(472, 512);
            this.CounterStatudGroupBox.TabIndex = 0;
            this.CounterStatudGroupBox.TabStop = false;
            this.CounterStatudGroupBox.Text = "Estado Contadora";
            // 
            // CounterComboBox
            // 
            this.CounterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CounterComboBox.FormattingEnabled = true;
            this.CounterComboBox.Items.AddRange(new object[] {
            "StatusInformation",
            "EndInformation",
            "DeviceStateInformation",
            "ErrorStateInformation",
            "ModeStateInformation ",
            "DoorStateInformation "});
            this.CounterComboBox.Location = new System.Drawing.Point(248, 56);
            this.CounterComboBox.Name = "CounterComboBox";
            this.CounterComboBox.Size = new System.Drawing.Size(216, 22);
            this.CounterComboBox.TabIndex = 162;
            this.CounterComboBox.SelectedIndexChanged += new System.EventHandler(this.CounterComboBox_SelectedIndexChanged);
            // 
            // CounterResponseTextBox
            // 
            this.CounterResponseTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.CounterResponseTextBox.BorderColor = System.Drawing.Color.SteelBlue;
            this.CounterResponseTextBox.BorderFocusColor = System.Drawing.Color.MediumSlateBlue;
            this.CounterResponseTextBox.BorderRadius = 4;
            this.CounterResponseTextBox.BorderSize = 2;
            this.CounterResponseTextBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CounterResponseTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CounterResponseTextBox.Location = new System.Drawing.Point(8, 48);
            this.CounterResponseTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.CounterResponseTextBox.Multiline = true;
            this.CounterResponseTextBox.Name = "CounterResponseTextBox";
            this.CounterResponseTextBox.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.CounterResponseTextBox.PasswordChar = false;
            this.CounterResponseTextBox.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.CounterResponseTextBox.PlaceholderText = "Respuestas de la contadora";
            this.CounterResponseTextBox.Size = new System.Drawing.Size(232, 448);
            this.CounterResponseTextBox.TabIndex = 161;
            this.CounterResponseTextBox.Texts = "";
            this.CounterResponseTextBox.UnderlinedStyle = false;
            // 
            // ExecuteCounterComandButton
            // 
            this.ExecuteCounterComandButton.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ExecuteCounterComandButton.Location = new System.Drawing.Point(248, 22);
            this.ExecuteCounterComandButton.Name = "ExecuteCounterComandButton";
            this.ExecuteCounterComandButton.Size = new System.Drawing.Size(216, 27);
            this.ExecuteCounterComandButton.TabIndex = 31;
            this.ExecuteCounterComandButton.Text = "Ejecutar";
            this.ExecuteCounterComandButton.UseVisualStyleBackColor = true;
            this.ExecuteCounterComandButton.Click += new System.EventHandler(this.ExecuteCounterComandButton_Click);
            // 
            // CounterStatusPropertyGrid
            // 
            this.CounterStatusPropertyGrid.CategoryForeColor = System.Drawing.Color.SteelBlue;
            this.CounterStatusPropertyGrid.DisabledItemForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(70)))), ((int)(((byte)(130)))), ((int)(((byte)(180)))));
            this.CounterStatusPropertyGrid.HelpVisible = false;
            this.CounterStatusPropertyGrid.Location = new System.Drawing.Point(248, 88);
            this.CounterStatusPropertyGrid.Name = "CounterStatusPropertyGrid";
            this.CounterStatusPropertyGrid.Size = new System.Drawing.Size(216, 408);
            this.CounterStatusPropertyGrid.TabIndex = 0;
            this.CounterStatusPropertyGrid.ViewBorderColor = System.Drawing.Color.SteelBlue;
            this.CounterStatusPropertyGrid.ViewForeColor = System.Drawing.Color.SteelBlue;
            // 
            // CounterCommandComboBox
            // 
            this.CounterCommandComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CounterCommandComboBox.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CounterCommandComboBox.ForeColor = System.Drawing.Color.SteelBlue;
            this.CounterCommandComboBox.FormattingEnabled = true;
            this.CounterCommandComboBox.Items.AddRange(new object[] {
            "RemoteCancel",
            "OpenEscrow",
            "CloseEscrow",
            "CountingDataRequest",
            "StopCounting",
            "StoringStart",
            "BatchDataTransmission",
            "Sense",
            "CountingDataRequest",
            "DepositMode",
            "ManualDepositMode",
            "NormalErrorRecoveryMode ",
            "StoringErrorRecoveryMode",
            "CollectMode",
            "Reset",
            "SwitchtoARS",
            "SwitchtoUS",
            "SwitchToEUR",
            "SwitchToCL"});
            this.CounterCommandComboBox.Location = new System.Drawing.Point(8, 24);
            this.CounterCommandComboBox.Name = "CounterCommandComboBox";
            this.CounterCommandComboBox.Size = new System.Drawing.Size(232, 22);
            this.CounterCommandComboBox.TabIndex = 30;
            // 
            // SupportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 661);
            this.ControlBox = false;
            this.Controls.Add(this.MainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SupportForm";
            this.Text = "SupportForm";
            this.Load += new System.EventHandler(this.SupportForm_Load);
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            this.IoBoardStatusGroup.ResumeLayout(false);
            this.CounterStatudGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel MainPanel;
        private GroupBox CounterStatudGroupBox;
        private PropertyGrid CounterStatusPropertyGrid;
        private Button ExecuteCounterComandButton;
        private ComboBox CounterCommandComboBox;
        private CustomTextBox CounterResponseTextBox;
        private ComboBox CounterComboBox;
        private CheckBox ModeCheckBox;
        private CustomButton BackButton;
        private GroupBox IoBoardStatusGroup;
        private Button ExecuteIoBoardComandButton;
        private ComboBox IoboardCommandComboBox;
        private CustomTextBox IoBoardResponseTextBox;
        private PropertyGrid IoBoardStatusPropertyGrid;
    }
}