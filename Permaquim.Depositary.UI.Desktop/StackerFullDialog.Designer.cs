namespace Permaquim.Depositary.UI.Desktop
{
    partial class StackerFullDialog
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
            this.MessageLabel = new System.Windows.Forms.Label();
            this.ContinueDepositButton = new Permaquim.Depositary.UI.Desktop.CustomButton();
            this.CancelDepositButton = new Permaquim.Depositary.UI.Desktop.CustomButton();
            this.SuspendLayout();
            // 
            // MessageLabel
            // 
            this.MessageLabel.AutoSize = true;
            this.MessageLabel.BackColor = System.Drawing.Color.Transparent;
            this.MessageLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.MessageLabel.ForeColor = System.Drawing.Color.SteelBlue;
            this.MessageLabel.Location = new System.Drawing.Point(72, 8);
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.Size = new System.Drawing.Size(550, 25);
            this.MessageLabel.TabIndex = 109;
            this.MessageLabel.Text = "Se ha alcanzado el tamaño máximo de billetes en la bandeja. ";
            // 
            // ContinueDepositButton
            // 
            this.ContinueDepositButton.BackColor = System.Drawing.Color.SteelBlue;
            this.ContinueDepositButton.BackgroundColor = System.Drawing.Color.SteelBlue;
            this.ContinueDepositButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.ContinueDepositButton.BorderRadius = 4;
            this.ContinueDepositButton.BorderSize = 0;
            this.ContinueDepositButton.FlatAppearance.BorderSize = 0;
            this.ContinueDepositButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ContinueDepositButton.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ContinueDepositButton.ForeColor = System.Drawing.Color.White;
            this.ContinueDepositButton.Location = new System.Drawing.Point(362, 48);
            this.ContinueDepositButton.Name = "ContinueDepositButton";
            this.ContinueDepositButton.Size = new System.Drawing.Size(248, 55);
            this.ContinueDepositButton.TabIndex = 108;
            this.ContinueDepositButton.Tag = "";
            this.ContinueDepositButton.Text = "Continuar";
            this.ContinueDepositButton.TextColor = System.Drawing.Color.White;
            this.ContinueDepositButton.UseVisualStyleBackColor = false;
            this.ContinueDepositButton.Click += new System.EventHandler(this.ContinueDepositButton_Click);
            // 
            // CancelDepositButton
            // 
            this.CancelDepositButton.BackColor = System.Drawing.Color.Red;
            this.CancelDepositButton.BackgroundColor = System.Drawing.Color.Red;
            this.CancelDepositButton.BorderColor = System.Drawing.Color.DarkOrange;
            this.CancelDepositButton.BorderRadius = 4;
            this.CancelDepositButton.BorderSize = 0;
            this.CancelDepositButton.FlatAppearance.BorderSize = 0;
            this.CancelDepositButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelDepositButton.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CancelDepositButton.ForeColor = System.Drawing.Color.White;
            this.CancelDepositButton.Location = new System.Drawing.Point(74, 48);
            this.CancelDepositButton.Name = "CancelDepositButton";
            this.CancelDepositButton.Size = new System.Drawing.Size(272, 55);
            this.CancelDepositButton.TabIndex = 106;
            this.CancelDepositButton.Tag = "";
            this.CancelDepositButton.Text = "Cancelar";
            this.CancelDepositButton.TextColor = System.Drawing.Color.White;
            this.CancelDepositButton.UseVisualStyleBackColor = false;
            this.CancelDepositButton.Click += new System.EventHandler(this.CancelDepositButton_Click);
            // 
            // StackerFullDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 116);
            this.ControlBox = false;
            this.Controls.Add(this.MessageLabel);
            this.Controls.Add(this.ContinueDepositButton);
            this.Controls.Add(this.CancelDepositButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StackerFullDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label MessageLabel;
        private CustomButton ContinueDepositButton;
        private CustomButton CancelDepositButton;
    }
}