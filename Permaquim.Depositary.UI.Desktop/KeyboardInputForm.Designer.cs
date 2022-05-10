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
            this.TitleLabel = new System.Windows.Forms.Label();
            this.LoginPictureBox = new System.Windows.Forms.PictureBox();
            this.customKeyboard1 = new Permaquim.Depositary.UI.Desktop.Controls.CustomKeyboard();
            ((System.ComponentModel.ISupportInitialize)(this.LoginPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TitleLabel.ForeColor = System.Drawing.Color.SteelBlue;
            this.TitleLabel.Location = new System.Drawing.Point(212, 4);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(259, 37);
            this.TitleLabel.TabIndex = 1;
            this.TitleLabel.Text = "Ingreso de Usuario";
            // 
            // LoginPictureBox
            // 
            this.LoginPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.LoginPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LoginPictureBox.Location = new System.Drawing.Point(23, 16);
            this.LoginPictureBox.Name = "LoginPictureBox";
            this.LoginPictureBox.Size = new System.Drawing.Size(130, 130);
            this.LoginPictureBox.TabIndex = 2;
            this.LoginPictureBox.TabStop = false;
            // 
            // customKeyboard1
            // 
            this.customKeyboard1.AutoSize = true;
            this.customKeyboard1.BackColor = System.Drawing.Color.Transparent;
            this.customKeyboard1.Location = new System.Drawing.Point(12, 44);
            this.customKeyboard1.Name = "customKeyboard1";
            this.customKeyboard1.Size = new System.Drawing.Size(713, 425);
            this.customKeyboard1.TabIndex = 3;
            // 
            // KeyboardInputForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(734, 493);
            this.ControlBox = false;
            this.Controls.Add(this.LoginPictureBox);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.customKeyboard1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "KeyboardInputForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            ((System.ComponentModel.ISupportInitialize)(this.LoginPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label TitleLabel;
        private PictureBox LoginPictureBox;
        private Controls.CustomKeyboard customKeyboard1;
    }
}