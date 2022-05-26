namespace Permaquim.Depositary.UI.Desktop
{
    partial class MainForm
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
            this.TopPanel = new System.Windows.Forms.Panel();
            this.OwnerDataLabel = new System.Windows.Forms.Label();
            this.HeadPanel = new System.Windows.Forms.Panel();
            this.LogoPictureBox = new System.Windows.Forms.PictureBox();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.labelContadora = new System.Windows.Forms.Label();
            this.labelIoboard = new System.Windows.Forms.Label();
            this.DateTimeLabel = new System.Windows.Forms.Label();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.InformationPanel = new System.Windows.Forms.Panel();
            this.InformationLabel = new System.Windows.Forms.Label();
            this.TopPanel.SuspendLayout();
            this.HeadPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).BeginInit();
            this.BottomPanel.SuspendLayout();
            this.MainPanel.SuspendLayout();
            this.InformationPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TopPanel
            // 
            this.TopPanel.BackColor = System.Drawing.Color.SteelBlue;
            this.TopPanel.Controls.Add(this.OwnerDataLabel);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(868, 42);
            this.TopPanel.TabIndex = 0;
            // 
            // OwnerDataLabel
            // 
            this.OwnerDataLabel.AutoSize = true;
            this.OwnerDataLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.OwnerDataLabel.ForeColor = System.Drawing.Color.White;
            this.OwnerDataLabel.Location = new System.Drawing.Point(21, 14);
            this.OwnerDataLabel.Name = "OwnerDataLabel";
            this.OwnerDataLabel.Size = new System.Drawing.Size(77, 15);
            this.OwnerDataLabel.TabIndex = 0;
            this.OwnerDataLabel.Text = "**************";
            // 
            // HeadPanel
            // 
            this.HeadPanel.BackColor = System.Drawing.Color.Snow;
            this.HeadPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.HeadPanel.Controls.Add(this.LogoPictureBox);
            this.HeadPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.HeadPanel.Location = new System.Drawing.Point(0, 42);
            this.HeadPanel.Name = "HeadPanel";
            this.HeadPanel.Size = new System.Drawing.Size(868, 54);
            this.HeadPanel.TabIndex = 1;
            // 
            // LogoPictureBox
            // 
            this.LogoPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LogoPictureBox.Location = new System.Drawing.Point(0, 3);
            this.LogoPictureBox.Name = "LogoPictureBox";
            this.LogoPictureBox.Size = new System.Drawing.Size(288, 50);
            this.LogoPictureBox.TabIndex = 0;
            this.LogoPictureBox.TabStop = false;
            // 
            // BottomPanel
            // 
            this.BottomPanel.BackColor = System.Drawing.Color.SteelBlue;
            this.BottomPanel.Controls.Add(this.labelContadora);
            this.BottomPanel.Controls.Add(this.labelIoboard);
            this.BottomPanel.Controls.Add(this.DateTimeLabel);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPanel.Location = new System.Drawing.Point(0, 445);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(868, 47);
            this.BottomPanel.TabIndex = 2;
            // 
            // labelContadora
            // 
            this.labelContadora.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelContadora.AutoSize = true;
            this.labelContadora.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelContadora.ForeColor = System.Drawing.Color.Red;
            this.labelContadora.Location = new System.Drawing.Point(8, 16);
            this.labelContadora.Name = "labelContadora";
            this.labelContadora.Size = new System.Drawing.Size(106, 15);
            this.labelContadora.TabIndex = 17;
            this.labelContadora.Text = "Contadora Offline";
            // 
            // labelIoboard
            // 
            this.labelIoboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelIoboard.AutoSize = true;
            this.labelIoboard.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelIoboard.ForeColor = System.Drawing.Color.Red;
            this.labelIoboard.Location = new System.Drawing.Point(144, 16);
            this.labelIoboard.Name = "labelIoboard";
            this.labelIoboard.Size = new System.Drawing.Size(98, 15);
            this.labelIoboard.TabIndex = 18;
            this.labelIoboard.Text = "IO Board Offline";
            // 
            // DateTimeLabel
            // 
            this.DateTimeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DateTimeLabel.AutoSize = true;
            this.DateTimeLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.DateTimeLabel.ForeColor = System.Drawing.Color.White;
            this.DateTimeLabel.Location = new System.Drawing.Point(672, 14);
            this.DateTimeLabel.Name = "DateTimeLabel";
            this.DateTimeLabel.Size = new System.Drawing.Size(57, 15);
            this.DateTimeLabel.TabIndex = 1;
            this.DateTimeLabel.Text = "**********";
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.Color.White;
            this.MainPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.MainPanel.Controls.Add(this.InformationPanel);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 96);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(868, 349);
            this.MainPanel.TabIndex = 3;
            this.MainPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MainPanel_MouseClick);
            // 
            // InformationPanel
            // 
            this.InformationPanel.Controls.Add(this.InformationLabel);
            this.InformationPanel.Location = new System.Drawing.Point(0, 328);
            this.InformationPanel.Name = "InformationPanel";
            this.InformationPanel.Size = new System.Drawing.Size(864, 17);
            this.InformationPanel.TabIndex = 0;
            this.InformationPanel.Visible = false;
            // 
            // InformationLabel
            // 
            this.InformationLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InformationLabel.AutoSize = true;
            this.InformationLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.InformationLabel.ForeColor = System.Drawing.Color.Red;
            this.InformationLabel.Location = new System.Drawing.Point(248, 136);
            this.InformationLabel.Name = "InformationLabel";
            this.InformationLabel.Size = new System.Drawing.Size(373, 32);
            this.InformationLabel.TabIndex = 0;
            this.InformationLabel.Text = "El dispositivo no está operativo";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 492);
            this.ControlBox = false;
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.BottomPanel);
            this.Controls.Add(this.HeadPanel);
            this.Controls.Add(this.TopPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            this.HeadPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).EndInit();
            this.BottomPanel.ResumeLayout(false);
            this.BottomPanel.PerformLayout();
            this.MainPanel.ResumeLayout(false);
            this.InformationPanel.ResumeLayout(false);
            this.InformationPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel TopPanel;
        private Panel HeadPanel;
        private Panel BottomPanel;
        private PictureBox LogoPictureBox;
        public Panel MainPanel;
        private Label OwnerDataLabel;
        private Label DateTimeLabel;
        private Label labelContadora;
        private Label labelIoboard;
        private Panel InformationPanel;
        private Label InformationLabel;
    }
}