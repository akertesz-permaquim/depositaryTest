namespace Permaquim.Depositary.UI.Desktop.Forms
{
    partial class PermissionUnlockForm
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
            this.LoginPictureBox = new System.Windows.Forms.PictureBox();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.MainKeyboard = new Permaquim.Depositary.UI.Desktop.Controls.CustomKeyboard();
            this.MainPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.LoginPictureBox)).BeginInit();
            this.MainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // LoginPictureBox
            // 
            this.LoginPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.LoginPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LoginPictureBox.Location = new System.Drawing.Point(15, 18);
            this.LoginPictureBox.Name = "LoginPictureBox";
            this.LoginPictureBox.Size = new System.Drawing.Size(130, 130);
            this.LoginPictureBox.TabIndex = 5;
            this.LoginPictureBox.TabStop = false;
            // 
            // TitleLabel
            // 
            this.TitleLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TitleLabel.ForeColor = System.Drawing.Color.SteelBlue;
            this.TitleLabel.Location = new System.Drawing.Point(152, 6);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(544, 37);
            this.TitleLabel.TabIndex = 4;
            this.TitleLabel.Text = "Ingreso de Usuario";
            this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainKeyboard
            // 
            this.MainKeyboard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainKeyboard.AutoSize = true;
            this.MainKeyboard.BackColor = System.Drawing.Color.Transparent;
            this.MainKeyboard.Location = new System.Drawing.Point(4, 46);
            this.MainKeyboard.Name = "MainKeyboard";
            this.MainKeyboard.PasswordTextBoxPlaceholder = "Clave";
            this.MainKeyboard.Size = new System.Drawing.Size(1502, 942);
            this.MainKeyboard.TabIndex = 6;
            this.MainKeyboard.UserTextboxPlaceholder = "Usuario";
            this.MainKeyboard.Visible = false;
            // 
            // MainPanel
            // 
            this.MainPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.MainPanel.BackColor = System.Drawing.Color.Transparent;
            this.MainPanel.Controls.Add(this.LoginPictureBox);
            this.MainPanel.Controls.Add(this.TitleLabel);
            this.MainPanel.Controls.Add(this.MainKeyboard);
            this.MainPanel.Location = new System.Drawing.Point(117, 10);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(856, 552);
            this.MainPanel.TabIndex = 1;
            // 
            // PermissionUnlockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1091, 572);
            this.Controls.Add(this.MainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PermissionUnlockForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PermissionUnlockForm";
            ((System.ComponentModel.ISupportInitialize)(this.LoginPictureBox)).EndInit();
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox LoginPictureBox;
        private Label TitleLabel;
        private Controls.CustomKeyboard MainKeyboard;
        private Panel MainPanel;
    }
}