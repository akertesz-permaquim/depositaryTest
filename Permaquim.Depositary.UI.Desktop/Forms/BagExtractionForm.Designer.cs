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
            this.MainPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.MonitorGroupBox = new System.Windows.Forms.GroupBox();
            this.ProcessStatusLabel = new System.Windows.Forms.Label();
            this.LockStateLabel = new System.Windows.Forms.Label();
            this.BagAproveStatelabel = new System.Windows.Forms.Label();
            this.ShutterStatusLabel = new System.Windows.Forms.Label();
            this.BagStatusLabel = new System.Windows.Forms.Label();
            this.GatelStatusLabel = new System.Windows.Forms.Label();
            this.InformationLabel = new System.Windows.Forms.Label();
            this.EventCheckbox = new System.Windows.Forms.CheckBox();
            this.MonitorGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.Color.Transparent;
            this.MainPanel.Location = new System.Drawing.Point(176, 168);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(456, 300);
            this.MainPanel.TabIndex = 2;
            // 
            // MonitorGroupBox
            // 
            this.MonitorGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MonitorGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.MonitorGroupBox.Controls.Add(this.ProcessStatusLabel);
            this.MonitorGroupBox.Controls.Add(this.LockStateLabel);
            this.MonitorGroupBox.Controls.Add(this.BagAproveStatelabel);
            this.MonitorGroupBox.Controls.Add(this.ShutterStatusLabel);
            this.MonitorGroupBox.Controls.Add(this.BagStatusLabel);
            this.MonitorGroupBox.Controls.Add(this.GatelStatusLabel);
            this.MonitorGroupBox.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MonitorGroupBox.Location = new System.Drawing.Point(640, 184);
            this.MonitorGroupBox.Name = "MonitorGroupBox";
            this.MonitorGroupBox.Size = new System.Drawing.Size(232, 208);
            this.MonitorGroupBox.TabIndex = 100;
            this.MonitorGroupBox.TabStop = false;
            this.MonitorGroupBox.Text = "Monitor";
            this.MonitorGroupBox.Visible = false;
            // 
            // ProcessStatusLabel
            // 
            this.ProcessStatusLabel.AutoSize = true;
            this.ProcessStatusLabel.BackColor = System.Drawing.Color.Transparent;
            this.ProcessStatusLabel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ProcessStatusLabel.ForeColor = System.Drawing.Color.SteelBlue;
            this.ProcessStatusLabel.Location = new System.Drawing.Point(16, 176);
            this.ProcessStatusLabel.Name = "ProcessStatusLabel";
            this.ProcessStatusLabel.Size = new System.Drawing.Size(91, 13);
            this.ProcessStatusLabel.TabIndex = 146;
            this.ProcessStatusLabel.Text = "Process Status";
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
            // InformationLabel
            // 
            this.InformationLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.InformationLabel.BackColor = System.Drawing.Color.Transparent;
            this.InformationLabel.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.InformationLabel.ForeColor = System.Drawing.Color.Red;
            this.InformationLabel.Location = new System.Drawing.Point(80, 8);
            this.InformationLabel.Name = "InformationLabel";
            this.InformationLabel.Size = new System.Drawing.Size(704, 72);
            this.InformationLabel.TabIndex = 143;
            this.InformationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EventCheckbox
            // 
            this.EventCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EventCheckbox.AutoSize = true;
            this.EventCheckbox.BackColor = System.Drawing.Color.Transparent;
            this.EventCheckbox.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.EventCheckbox.ForeColor = System.Drawing.Color.SteelBlue;
            this.EventCheckbox.Location = new System.Drawing.Point(656, 432);
            this.EventCheckbox.Name = "EventCheckbox";
            this.EventCheckbox.Size = new System.Drawing.Size(71, 17);
            this.EventCheckbox.TabIndex = 144;
            this.EventCheckbox.Text = "Eventos";
            this.EventCheckbox.UseVisualStyleBackColor = false;
            this.EventCheckbox.Visible = false;
            this.EventCheckbox.CheckedChanged += new System.EventHandler(this.EventCheckbox_CheckedChanged);
            // 
            // BagExtractionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 593);
            this.ControlBox = false;
            this.Controls.Add(this.EventCheckbox);
            this.Controls.Add(this.InformationLabel);
            this.Controls.Add(this.MonitorGroupBox);
            this.Controls.Add(this.MainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BagExtractionForm";
            this.Load += new System.EventHandler(this.BagExtractionForm_Load);
            this.VisibleChanged += new System.EventHandler(this.BagExtractionForm_VisibleChanged);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BagExtractionForm_MouseClick);
            this.MonitorGroupBox.ResumeLayout(false);
            this.MonitorGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private FlowLayoutPanel MainPanel;
        private GroupBox MonitorGroupBox;
        private Label GatelStatusLabel;
        private Label BagStatusLabel;
        private Label ShutterStatusLabel;
        private Label BagAproveStatelabel;
        private Label LockStateLabel;
        private Label InformationLabel;
        private CheckBox EventCheckbox;
        private Label ProcessStatusLabel;
    }
}