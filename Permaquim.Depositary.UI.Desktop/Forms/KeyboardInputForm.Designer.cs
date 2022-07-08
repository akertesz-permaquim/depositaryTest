namespace Permaquim.Depositary.UI.Desktop
{
    partial class KeyboardInputForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MainPanel = new System.Windows.Forms.Panel();
            this.LoginPictureBox = new System.Windows.Forms.PictureBox();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.MainKeyboard = new Permaquim.Depositary.UI.Desktop.Controls.CustomKeyboard();
            this.MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LoginPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.MainPanel.BackColor = System.Drawing.Color.Transparent;
            this.MainPanel.Controls.Add(this.LoginPictureBox);
            this.MainPanel.Controls.Add(this.TitleLabel);
            this.MainPanel.Controls.Add(this.MainKeyboard);
            this.MainPanel.Location = new System.Drawing.Point(3, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(725, 552);
            this.MainPanel.TabIndex = 0;
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
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TitleLabel.ForeColor = System.Drawing.Color.SteelBlue;
            this.TitleLabel.Location = new System.Drawing.Point(204, 6);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(259, 37);
            this.TitleLabel.TabIndex = 4;
            this.TitleLabel.Text = "Ingreso de Usuario";
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
            this.MainKeyboard.Size = new System.Drawing.Size(715, 548);
            this.MainKeyboard.TabIndex = 6;
            this.MainKeyboard.UserTextboxPlaceholder = "Usuario";
            this.MainKeyboard.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MainKeyboard_MouseClick);
            // 
            // KeyboardInputForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(734, 572);
            this.ControlBox = false;
            this.Controls.Add(this.MainPanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "KeyboardInputForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.KeyboardInputForm_Load);
            this.VisibleChanged += new System.EventHandler(this.KeyboardInputForm_VisibleChanged);
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LoginPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel MainPanel;
        private PictureBox LoginPictureBox;
        private Label TitleLabel;
        private Controls.CustomKeyboard MainKeyboard;
    }
}