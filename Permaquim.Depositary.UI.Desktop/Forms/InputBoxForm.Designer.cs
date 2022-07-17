namespace Permaquim.Depositary.UI.Desktop.Forms
{
    partial class InputBoxForm
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
            this.CustomInputBoxKeyboard = new Permaquim.Depositary.UI.Desktop.Controls.CustomInputBoxKeyboar();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CustomInputBoxKeyboard
            // 
            this.CustomInputBoxKeyboard.InputTexboxPlaceholder = "Ingrese texto";
            this.CustomInputBoxKeyboard.Location = new System.Drawing.Point(8, 48);
            this.CustomInputBoxKeyboard.Name = "CustomInputBoxKeyboard";
            this.CustomInputBoxKeyboard.Size = new System.Drawing.Size(841, 418);
            this.CustomInputBoxKeyboard.TabIndex = 0;
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TitleLabel.ForeColor = System.Drawing.Color.SteelBlue;
            this.TitleLabel.Location = new System.Drawing.Point(304, 8);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(163, 25);
            this.TitleLabel.TabIndex = 6;
            this.TitleLabel.Text = "Ingrese Cantidad";
            // 
            // InputBoxForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 481);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.CustomInputBoxKeyboard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "InputBoxForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InputBoxForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.CustomInputBoxKeyboar CustomInputBoxKeyboard;
        private Label TitleLabel;
    }
}