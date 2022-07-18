namespace Permaquim.Depositary.UI.Desktop.Forms
{
    partial class CustomNumericInputboxKeyboard
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
            this.NumericInputBoxControl = new Permaquim.Depositary.UI.Desktop.Controls.CustomNumericInputboxKeyboard();
            this.SuspendLayout();
            // 
            // NumericInputBoxControl
            // 
            this.NumericInputBoxControl.Location = new System.Drawing.Point(8, 8);
            this.NumericInputBoxControl.Name = "NumericInputBoxControl";
            this.NumericInputBoxControl.NumericInputBoxPlaceholder = "*";
            this.NumericInputBoxControl.Size = new System.Drawing.Size(225, 400);
            this.NumericInputBoxControl.TabIndex = 0;
            this.NumericInputBoxControl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NumericInputBoxControl_MouseClick);
            // 
            // InputboxForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 400);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.NumericInputBoxControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "InputboxForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InputboxForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.CustomNumericInputboxKeyboard NumericInputBoxControl;
        private Label TitleLabel;
    }
}