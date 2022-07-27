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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.HeadPanel = new System.Windows.Forms.Panel();
            this.EnterpriseLabel = new System.Windows.Forms.Label();
            this.AvatarPicturebox = new System.Windows.Forms.PictureBox();
            this.UserLabel = new System.Windows.Forms.Label();
            this.LogoPictureBox = new System.Windows.Forms.PictureBox();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.DepositaryLabel = new System.Windows.Forms.Label();
            this.SucursalLabel = new System.Windows.Forms.Label();
            this.RemainingTimeLabel = new System.Windows.Forms.Label();
            this.IoBoardPictureBox = new System.Windows.Forms.PictureBox();
            this.CounterPictureBox = new System.Windows.Forms.PictureBox();
            this.DateTimeLabel = new System.Windows.Forms.Label();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.MainPictureBox = new System.Windows.Forms.PictureBox();
            this.BreadcrumbLabel = new System.Windows.Forms.Label();
            this.InformationLabel = new System.Windows.Forms.Label();
            this.HeadPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AvatarPicturebox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).BeginInit();
            this.BottomPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IoBoardPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CounterPictureBox)).BeginInit();
            this.MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // HeadPanel
            // 
            this.HeadPanel.BackColor = System.Drawing.Color.White;
            this.HeadPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.HeadPanel.Controls.Add(this.EnterpriseLabel);
            this.HeadPanel.Controls.Add(this.AvatarPicturebox);
            this.HeadPanel.Controls.Add(this.UserLabel);
            this.HeadPanel.Controls.Add(this.LogoPictureBox);
            this.HeadPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.HeadPanel.Location = new System.Drawing.Point(0, 0);
            this.HeadPanel.Name = "HeadPanel";
            this.HeadPanel.Size = new System.Drawing.Size(873, 54);
            this.HeadPanel.TabIndex = 1;
            // 
            // EnterpriseLabel
            // 
            this.EnterpriseLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EnterpriseLabel.AutoSize = true;
            this.EnterpriseLabel.BackColor = System.Drawing.Color.Transparent;
            this.EnterpriseLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.EnterpriseLabel.ForeColor = System.Drawing.Color.White;
            this.EnterpriseLabel.Location = new System.Drawing.Point(661, 32);
            this.EnterpriseLabel.Name = "EnterpriseLabel";
            this.EnterpriseLabel.Size = new System.Drawing.Size(37, 15);
            this.EnterpriseLabel.TabIndex = 110;
            this.EnterpriseLabel.Text = "------";
            this.EnterpriseLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // AvatarPicturebox
            // 
            this.AvatarPicturebox.BackColor = System.Drawing.Color.Transparent;
            this.AvatarPicturebox.Dock = System.Windows.Forms.DockStyle.Right;
            this.AvatarPicturebox.Location = new System.Drawing.Point(813, 0);
            this.AvatarPicturebox.Name = "AvatarPicturebox";
            this.AvatarPicturebox.Size = new System.Drawing.Size(60, 54);
            this.AvatarPicturebox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.AvatarPicturebox.TabIndex = 109;
            this.AvatarPicturebox.TabStop = false;
            this.AvatarPicturebox.Click += new System.EventHandler(this.AvatarPicturebox_Click);
            // 
            // UserLabel
            // 
            this.UserLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UserLabel.AutoSize = true;
            this.UserLabel.BackColor = System.Drawing.Color.Transparent;
            this.UserLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.UserLabel.ForeColor = System.Drawing.Color.White;
            this.UserLabel.Location = new System.Drawing.Point(661, 8);
            this.UserLabel.Name = "UserLabel";
            this.UserLabel.Size = new System.Drawing.Size(37, 15);
            this.UserLabel.TabIndex = 101;
            this.UserLabel.Text = "------";
            this.UserLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // LogoPictureBox
            // 
            this.LogoPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LogoPictureBox.Location = new System.Drawing.Point(0, 0);
            this.LogoPictureBox.Name = "LogoPictureBox";
            this.LogoPictureBox.Size = new System.Drawing.Size(288, 53);
            this.LogoPictureBox.TabIndex = 0;
            this.LogoPictureBox.TabStop = false;
            this.LogoPictureBox.Click += new System.EventHandler(this.LogoPictureBox_Click);
            // 
            // BottomPanel
            // 
            this.BottomPanel.BackColor = System.Drawing.Color.White;
            this.BottomPanel.Controls.Add(this.DepositaryLabel);
            this.BottomPanel.Controls.Add(this.SucursalLabel);
            this.BottomPanel.Controls.Add(this.RemainingTimeLabel);
            this.BottomPanel.Controls.Add(this.IoBoardPictureBox);
            this.BottomPanel.Controls.Add(this.CounterPictureBox);
            this.BottomPanel.Controls.Add(this.DateTimeLabel);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPanel.Location = new System.Drawing.Point(0, 445);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(873, 47);
            this.BottomPanel.TabIndex = 2;
            // 
            // DepositaryLabel
            // 
            this.DepositaryLabel.AutoSize = true;
            this.DepositaryLabel.BackColor = System.Drawing.Color.Transparent;
            this.DepositaryLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.DepositaryLabel.ForeColor = System.Drawing.Color.White;
            this.DepositaryLabel.Location = new System.Drawing.Point(288, 16);
            this.DepositaryLabel.Name = "DepositaryLabel";
            this.DepositaryLabel.Size = new System.Drawing.Size(37, 15);
            this.DepositaryLabel.TabIndex = 103;
            this.DepositaryLabel.Text = "------";
            this.DepositaryLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // SucursalLabel
            // 
            this.SucursalLabel.AutoSize = true;
            this.SucursalLabel.BackColor = System.Drawing.Color.Transparent;
            this.SucursalLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SucursalLabel.ForeColor = System.Drawing.Color.White;
            this.SucursalLabel.Location = new System.Drawing.Point(112, 16);
            this.SucursalLabel.Name = "SucursalLabel";
            this.SucursalLabel.Size = new System.Drawing.Size(37, 15);
            this.SucursalLabel.TabIndex = 102;
            this.SucursalLabel.Text = "------";
            this.SucursalLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // RemainingTimeLabel
            // 
            this.RemainingTimeLabel.BackColor = System.Drawing.Color.Transparent;
            this.RemainingTimeLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.RemainingTimeLabel.ForeColor = System.Drawing.Color.White;
            this.RemainingTimeLabel.Location = new System.Drawing.Point(408, 16);
            this.RemainingTimeLabel.Name = "RemainingTimeLabel";
            this.RemainingTimeLabel.Size = new System.Drawing.Size(376, 15);
            this.RemainingTimeLabel.TabIndex = 21;
            this.RemainingTimeLabel.Text = "**********";
            this.RemainingTimeLabel.Paint += new System.Windows.Forms.PaintEventHandler(this.RemainingTimeLabel_Paint);
            // 
            // IoBoardPictureBox
            // 
            this.IoBoardPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.IoBoardPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.IoBoardPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("IoBoardPictureBox.Image")));
            this.IoBoardPictureBox.Location = new System.Drawing.Point(64, 8);
            this.IoBoardPictureBox.Name = "IoBoardPictureBox";
            this.IoBoardPictureBox.Size = new System.Drawing.Size(24, 24);
            this.IoBoardPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.IoBoardPictureBox.TabIndex = 20;
            this.IoBoardPictureBox.TabStop = false;
            // 
            // CounterPictureBox
            // 
            this.CounterPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CounterPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.CounterPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("CounterPictureBox.Image")));
            this.CounterPictureBox.Location = new System.Drawing.Point(24, 8);
            this.CounterPictureBox.Name = "CounterPictureBox";
            this.CounterPictureBox.Size = new System.Drawing.Size(24, 24);
            this.CounterPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CounterPictureBox.TabIndex = 19;
            this.CounterPictureBox.TabStop = false;
            // 
            // DateTimeLabel
            // 
            this.DateTimeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DateTimeLabel.AutoSize = true;
            this.DateTimeLabel.BackColor = System.Drawing.Color.Transparent;
            this.DateTimeLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.DateTimeLabel.ForeColor = System.Drawing.Color.White;
            this.DateTimeLabel.Location = new System.Drawing.Point(677, 16);
            this.DateTimeLabel.Name = "DateTimeLabel";
            this.DateTimeLabel.Size = new System.Drawing.Size(57, 15);
            this.DateTimeLabel.TabIndex = 1;
            this.DateTimeLabel.Text = "**********";
            this.DateTimeLabel.Click += new System.EventHandler(this.DateTimeLabel_Click);
            // 
            // MainPanel
            // 
            this.MainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainPanel.BackColor = System.Drawing.Color.White;
            this.MainPanel.Controls.Add(this.MainPictureBox);
            this.MainPanel.Location = new System.Drawing.Point(0, 96);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(873, 306);
            this.MainPanel.TabIndex = 3;
            this.MainPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MainPanel_MouseClick);
            // 
            // MainPictureBox
            // 
            this.MainPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainPictureBox.ErrorImage = null;
            this.MainPictureBox.Location = new System.Drawing.Point(0, 0);
            this.MainPictureBox.Name = "MainPictureBox";
            this.MainPictureBox.Size = new System.Drawing.Size(873, 261);
            this.MainPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.MainPictureBox.TabIndex = 1;
            this.MainPictureBox.TabStop = false;
            this.MainPictureBox.VisibleChanged += new System.EventHandler(this.MainPictureBox_VisibleChanged);
            this.MainPictureBox.Click += new System.EventHandler(this.MainPictureBox_Click);
            // 
            // BreadcrumbLabel
            // 
            this.BreadcrumbLabel.BackColor = System.Drawing.Color.Transparent;
            this.BreadcrumbLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.BreadcrumbLabel.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BreadcrumbLabel.ForeColor = System.Drawing.Color.Silver;
            this.BreadcrumbLabel.Location = new System.Drawing.Point(0, 54);
            this.BreadcrumbLabel.Name = "BreadcrumbLabel";
            this.BreadcrumbLabel.Size = new System.Drawing.Size(873, 42);
            this.BreadcrumbLabel.TabIndex = 111;
            this.BreadcrumbLabel.Text = "Breadcrumb";
            this.BreadcrumbLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InformationLabel
            // 
            this.InformationLabel.BackColor = System.Drawing.Color.Transparent;
            this.InformationLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.InformationLabel.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.InformationLabel.ForeColor = System.Drawing.Color.Silver;
            this.InformationLabel.Location = new System.Drawing.Point(0, 403);
            this.InformationLabel.Name = "InformationLabel";
            this.InformationLabel.Size = new System.Drawing.Size(873, 42);
            this.InformationLabel.TabIndex = 113;
            this.InformationLabel.Text = "...";
            this.InformationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 492);
            this.ControlBox = false;
            this.Controls.Add(this.InformationLabel);
            this.Controls.Add(this.BreadcrumbLabel);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.BottomPanel);
            this.Controls.Add(this.HeadPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.HeadPanel.ResumeLayout(false);
            this.HeadPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AvatarPicturebox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).EndInit();
            this.BottomPanel.ResumeLayout(false);
            this.BottomPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IoBoardPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CounterPictureBox)).EndInit();
            this.MainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Panel HeadPanel;
        private Panel BottomPanel;
        private PictureBox LogoPictureBox;
        public Panel MainPanel;
        private Label DateTimeLabel;
        private Label UserLabel;
        private PictureBox AvatarPicturebox;
        private Label EnterpriseLabel;
        private PictureBox IoBoardPictureBox;
        private PictureBox CounterPictureBox;
        private Label RemainingTimeLabel;
        private Label SucursalLabel;
        private Label DepositaryLabel;
        private PictureBox MainPictureBox;
        private Label BreadcrumbLabel;
        private Label InformationLabel;
    }
}