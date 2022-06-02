﻿namespace Permaquim.Depositary.UI.Desktop
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
            this.AvatarPicturebox = new System.Windows.Forms.PictureBox();
            this.UserLabel = new System.Windows.Forms.Label();
            this.LogoPictureBox = new System.Windows.Forms.PictureBox();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.CounterLabel = new System.Windows.Forms.Label();
            this.IoBoardLabel = new System.Windows.Forms.Label();
            this.DateTimeLabel = new System.Windows.Forms.Label();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.InformationPanel = new System.Windows.Forms.Panel();
            this.InformationLabel = new System.Windows.Forms.Label();
            this.EnterpriseLabel = new System.Windows.Forms.Label();
            this.TopPanel.SuspendLayout();
            this.HeadPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AvatarPicturebox)).BeginInit();
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
            this.HeadPanel.Controls.Add(this.EnterpriseLabel);
            this.HeadPanel.Controls.Add(this.AvatarPicturebox);
            this.HeadPanel.Controls.Add(this.UserLabel);
            this.HeadPanel.Controls.Add(this.LogoPictureBox);
            this.HeadPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.HeadPanel.Location = new System.Drawing.Point(0, 42);
            this.HeadPanel.Name = "HeadPanel";
            this.HeadPanel.Size = new System.Drawing.Size(868, 54);
            this.HeadPanel.TabIndex = 1;
            // 
            // AvatarPicturebox
            // 
            this.AvatarPicturebox.BackColor = System.Drawing.Color.Transparent;
            this.AvatarPicturebox.Dock = System.Windows.Forms.DockStyle.Right;
            this.AvatarPicturebox.Location = new System.Drawing.Point(808, 0);
            this.AvatarPicturebox.Name = "AvatarPicturebox";
            this.AvatarPicturebox.Size = new System.Drawing.Size(60, 54);
            this.AvatarPicturebox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.AvatarPicturebox.TabIndex = 109;
            this.AvatarPicturebox.TabStop = false;
            // 
            // UserLabel
            // 
            this.UserLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UserLabel.AutoSize = true;
            this.UserLabel.BackColor = System.Drawing.Color.White;
            this.UserLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.UserLabel.ForeColor = System.Drawing.Color.SteelBlue;
            this.UserLabel.Location = new System.Drawing.Point(656, 8);
            this.UserLabel.Name = "UserLabel";
            this.UserLabel.Size = new System.Drawing.Size(37, 15);
            this.UserLabel.TabIndex = 101;
            this.UserLabel.Text = "------";
            this.UserLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
            this.BottomPanel.Controls.Add(this.CounterLabel);
            this.BottomPanel.Controls.Add(this.IoBoardLabel);
            this.BottomPanel.Controls.Add(this.DateTimeLabel);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPanel.Location = new System.Drawing.Point(0, 445);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(868, 47);
            this.BottomPanel.TabIndex = 2;
            // 
            // CounterLabel
            // 
            this.CounterLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CounterLabel.AutoSize = true;
            this.CounterLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CounterLabel.ForeColor = System.Drawing.Color.Red;
            this.CounterLabel.Location = new System.Drawing.Point(8, 16);
            this.CounterLabel.Name = "CounterLabel";
            this.CounterLabel.Size = new System.Drawing.Size(106, 15);
            this.CounterLabel.TabIndex = 17;
            this.CounterLabel.Text = "Contadora Offline";
            // 
            // IoBoardLabel
            // 
            this.IoBoardLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.IoBoardLabel.AutoSize = true;
            this.IoBoardLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.IoBoardLabel.ForeColor = System.Drawing.Color.Red;
            this.IoBoardLabel.Location = new System.Drawing.Point(144, 16);
            this.IoBoardLabel.Name = "IoBoardLabel";
            this.IoBoardLabel.Size = new System.Drawing.Size(98, 15);
            this.IoBoardLabel.TabIndex = 18;
            this.IoBoardLabel.Text = "IO Board Offline";
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
            // EnterpriseLabel
            // 
            this.EnterpriseLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EnterpriseLabel.AutoSize = true;
            this.EnterpriseLabel.BackColor = System.Drawing.Color.White;
            this.EnterpriseLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.EnterpriseLabel.ForeColor = System.Drawing.Color.SteelBlue;
            this.EnterpriseLabel.Location = new System.Drawing.Point(656, 32);
            this.EnterpriseLabel.Name = "EnterpriseLabel";
            this.EnterpriseLabel.Size = new System.Drawing.Size(37, 15);
            this.EnterpriseLabel.TabIndex = 110;
            this.EnterpriseLabel.Text = "------";
            this.EnterpriseLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
            this.HeadPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AvatarPicturebox)).EndInit();
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
        private Label CounterLabel;
        private Label IoBoardLabel;
        private Panel InformationPanel;
        private Label InformationLabel;
        private Label UserLabel;
        private PictureBox AvatarPicturebox;
        private Label EnterpriseLabel;
    }
}