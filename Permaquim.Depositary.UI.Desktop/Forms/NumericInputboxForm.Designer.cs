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
            this.TitleLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // NumericInputBoxControl
            // 
            this.NumericInputBoxControl.Location = new System.Drawing.Point(8, 56);
            this.NumericInputBoxControl.Name = "NumericInputBoxControl";
            this.NumericInputBoxControl.NumericInputBoxPlaceholder = "*";
            this.NumericInputBoxControl.Size = new System.Drawing.Size(225, 419);
            this.NumericInputBoxControl.TabIndex = 0;
            this.NumericInputBoxControl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NumericInputBoxControl_MouseClick);
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TitleLabel.ForeColor = System.Drawing.Color.SteelBlue;
            this.TitleLabel.Location = new System.Drawing.Point(16, 16);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(163, 25);
            this.TitleLabel.TabIndex = 5;
            this.TitleLabel.Text = "Ingrese Cantidad";
            // 
            // InputboxForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 489);
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