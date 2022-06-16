namespace Permaquim.Depositary.UI.Desktop
{
    partial class BagExtractionForm
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
            this.ExitPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.MainPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.MonitorGroupBox = new System.Windows.Forms.GroupBox();
            this.LockStateLabel = new System.Windows.Forms.Label();
            this.BagAproveStatelabel = new System.Windows.Forms.Label();
            this.ShutterStatusLabel = new System.Windows.Forms.Label();
            this.BagStatusLabel = new System.Windows.Forms.Label();
            this.GatelStatusLabel = new System.Windows.Forms.Label();
            this.ContainerTextBox = new CustomTextBox();
            this.MonitorGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // ExitPanel
            // 
            this.ExitPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ExitPanel.BackColor = System.Drawing.Color.Transparent;
            this.ExitPanel.Location = new System.Drawing.Point(298, 493);
            this.ExitPanel.Name = "ExitPanel";
            this.ExitPanel.Size = new System.Drawing.Size(300, 103);
            this.ExitPanel.TabIndex = 3;
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.Color.Transparent;
            this.MainPanel.Location = new System.Drawing.Point(300, 80);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(300, 224);
            this.MainPanel.TabIndex = 2;
            // 
            // MonitorGroupBox
            // 
            this.MonitorGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.MonitorGroupBox.Controls.Add(this.LockStateLabel);
            this.MonitorGroupBox.Controls.Add(this.BagAproveStatelabel);
            this.MonitorGroupBox.Controls.Add(this.ShutterStatusLabel);
            this.MonitorGroupBox.Controls.Add(this.BagStatusLabel);
            this.MonitorGroupBox.Controls.Add(this.GatelStatusLabel);
            this.MonitorGroupBox.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MonitorGroupBox.Location = new System.Drawing.Point(616, 80);
            this.MonitorGroupBox.Name = "MonitorGroupBox";
            this.MonitorGroupBox.Size = new System.Drawing.Size(248, 168);
            this.MonitorGroupBox.TabIndex = 100;
            this.MonitorGroupBox.TabStop = false;
            this.MonitorGroupBox.Text = "Monitor";
            // 
            // LockStateLabel
            // 
            this.LockStateLabel.AutoSize = true;
            this.LockStateLabel.BackColor = System.Drawing.Color.Transparent;
            this.LockStateLabel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LockStateLabel.ForeColor = System.Drawing.Color.SteelBlue;
            this.LockStateLabel.Location = new System.Drawing.Point(16, 112);
            this.LockStateLabel.Name = "LockStateLabel";
            this.LockStateLabel.Size = new System.Drawing.Size(73, 13);
            this.LockStateLabel.TabIndex = 29;
            this.LockStateLabel.Text = "Lock Status";
            // 
            // BagAproveStatelabel
            // 
            this.BagAproveStatelabel.AutoSize = true;
            this.BagAproveStatelabel.BackColor = System.Drawing.Color.Transparent;
            this.BagAproveStatelabel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BagAproveStatelabel.ForeColor = System.Drawing.Color.SteelBlue;
            this.BagAproveStatelabel.Location = new System.Drawing.Point(16, 88);
            this.BagAproveStatelabel.Name = "BagAproveStatelabel";
            this.BagAproveStatelabel.Size = new System.Drawing.Size(114, 13);
            this.BagAproveStatelabel.TabIndex = 28;
            this.BagAproveStatelabel.Text = "Bag Aprove Status";
            // 
            // ShutterStatusLabel
            // 
            this.ShutterStatusLabel.AutoSize = true;
            this.ShutterStatusLabel.BackColor = System.Drawing.Color.Transparent;
            this.ShutterStatusLabel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ShutterStatusLabel.ForeColor = System.Drawing.Color.SteelBlue;
            this.ShutterStatusLabel.Location = new System.Drawing.Point(15, 64);
            this.ShutterStatusLabel.Name = "ShutterStatusLabel";
            this.ShutterStatusLabel.Size = new System.Drawing.Size(89, 13);
            this.ShutterStatusLabel.TabIndex = 27;
            this.ShutterStatusLabel.Text = "Shutter Status";
            // 
            // BagStatusLabel
            // 
            this.BagStatusLabel.AutoSize = true;
            this.BagStatusLabel.BackColor = System.Drawing.Color.Transparent;
            this.BagStatusLabel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BagStatusLabel.ForeColor = System.Drawing.Color.SteelBlue;
            this.BagStatusLabel.Location = new System.Drawing.Point(16, 40);
            this.BagStatusLabel.Name = "BagStatusLabel";
            this.BagStatusLabel.Size = new System.Drawing.Size(69, 13);
            this.BagStatusLabel.TabIndex = 26;
            this.BagStatusLabel.Text = "Bag Status";
            // 
            // GatelStatusLabel
            // 
            this.GatelStatusLabel.AutoSize = true;
            this.GatelStatusLabel.BackColor = System.Drawing.Color.Transparent;
            this.GatelStatusLabel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.GatelStatusLabel.ForeColor = System.Drawing.Color.SteelBlue;
            this.GatelStatusLabel.Location = new System.Drawing.Point(16, 136);
            this.GatelStatusLabel.Name = "GatelStatusLabel";
            this.GatelStatusLabel.Size = new System.Drawing.Size(74, 13);
            this.GatelStatusLabel.TabIndex = 25;
            this.GatelStatusLabel.Text = "Gate Status";
            // 
            // ContainerTextBox
            // 
            this.ContainerTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.ContainerTextBox.BorderColor = System.Drawing.Color.SteelBlue;
            this.ContainerTextBox.BorderFocusColor = System.Drawing.Color.MediumSlateBlue;
            this.ContainerTextBox.BorderRadius = 4;
            this.ContainerTextBox.BorderSize = 2;
            this.ContainerTextBox.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ContainerTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ContainerTextBox.Location = new System.Drawing.Point(296, 336);
            this.ContainerTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.ContainerTextBox.Multiline = false;
            this.ContainerTextBox.Name = "ContainerTextBox";
            this.ContainerTextBox.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.ContainerTextBox.PasswordChar = false;
            this.ContainerTextBox.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.ContainerTextBox.PlaceholderText = "Identificador de bolsa";
            this.ContainerTextBox.Size = new System.Drawing.Size(300, 45);
            this.ContainerTextBox.TabIndex = 139;
            this.ContainerTextBox.Texts = "";
            this.ContainerTextBox.UnderlinedStyle = false;
            this.ContainerTextBox.Visible = false;
            // 
            // BagExtractionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 593);
            this.ControlBox = false;
            this.Controls.Add(this.ContainerTextBox);
            this.Controls.Add(this.MonitorGroupBox);
            this.Controls.Add(this.ExitPanel);
            this.Controls.Add(this.MainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BagExtractionForm";
            this.Load += new System.EventHandler(this.BagExtractionForm_Load);
            this.MonitorGroupBox.ResumeLayout(false);
            this.MonitorGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private FlowLayoutPanel ExitPanel;
        private FlowLayoutPanel MainPanel;
        private GroupBox MonitorGroupBox;
        private Label GatelStatusLabel;
        private Label BagStatusLabel;
        private Label ShutterStatusLabel;
        private Label BagAproveStatelabel;
        private Label LockStateLabel;
        private CustomTextBox ContainerTextBox;
    }
}