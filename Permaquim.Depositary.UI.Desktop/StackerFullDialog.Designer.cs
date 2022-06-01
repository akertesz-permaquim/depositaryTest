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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.MessageLabel = new System.Windows.Forms.Label();
            this.ContinueDepositButton = new Permaquim.Depositary.UI.Desktop.CustomButton();
            this.ConfirmDepositButton = new Permaquim.Depositary.UI.Desktop.CustomButton();
            this.CancelDepositButton = new Permaquim.Depositary.UI.Desktop.CustomButton();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.SteelBlue;
            this.label3.Location = new System.Drawing.Point(24, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(172, 19);
            this.label3.TabIndex = 112;
            this.label3.Text = "Continuar depositando ?";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(24, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 19);
            this.label2.TabIndex = 111;
            this.label2.Text = "Cancelar el depósito ?";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.SeaGreen;
            this.label1.Location = new System.Drawing.Point(24, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 19);
            this.label1.TabIndex = 110;
            this.label1.Text = "Desea finalizar el depósito ?";
            // 
            // MessageLabel
            // 
            this.MessageLabel.AutoSize = true;
            this.MessageLabel.BackColor = System.Drawing.Color.Transparent;
            this.MessageLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.MessageLabel.ForeColor = System.Drawing.Color.SteelBlue;
            this.MessageLabel.Location = new System.Drawing.Point(24, 8);
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.Size = new System.Drawing.Size(422, 19);
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
            this.ContinueDepositButton.Location = new System.Drawing.Point(296, 120);
            this.ContinueDepositButton.Name = "ContinueDepositButton";
            this.ContinueDepositButton.Size = new System.Drawing.Size(232, 55);
            this.ContinueDepositButton.TabIndex = 108;
            this.ContinueDepositButton.Tag = "";
            this.ContinueDepositButton.Text = "Continuar";
            this.ContinueDepositButton.TextColor = System.Drawing.Color.White;
            this.ContinueDepositButton.UseVisualStyleBackColor = false;
            this.ContinueDepositButton.Click += new System.EventHandler(this.ContinueDepositButton_Click);
            // 
            // ConfirmDepositButton
            // 
            this.ConfirmDepositButton.BackColor = System.Drawing.Color.SeaGreen;
            this.ConfirmDepositButton.BackgroundColor = System.Drawing.Color.SeaGreen;
            this.ConfirmDepositButton.BorderColor = System.Drawing.Color.MediumSeaGreen;
            this.ConfirmDepositButton.BorderRadius = 4;
            this.ConfirmDepositButton.BorderSize = 0;
            this.ConfirmDepositButton.FlatAppearance.BorderSize = 0;
            this.ConfirmDepositButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConfirmDepositButton.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ConfirmDepositButton.ForeColor = System.Drawing.Color.White;
            this.ConfirmDepositButton.Location = new System.Drawing.Point(8, 120);
            this.ConfirmDepositButton.Name = "ConfirmDepositButton";
            this.ConfirmDepositButton.Size = new System.Drawing.Size(152, 55);
            this.ConfirmDepositButton.TabIndex = 107;
            this.ConfirmDepositButton.Tag = "";
            this.ConfirmDepositButton.Text = "Terminar";
            this.ConfirmDepositButton.TextColor = System.Drawing.Color.White;
            this.ConfirmDepositButton.UseVisualStyleBackColor = false;
            this.ConfirmDepositButton.Click += new System.EventHandler(this.ConfirmDepositButton_Click);
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
            this.CancelDepositButton.Location = new System.Drawing.Point(168, 120);
            this.CancelDepositButton.Name = "CancelDepositButton";
            this.CancelDepositButton.Size = new System.Drawing.Size(121, 55);
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
            this.ClientSize = new System.Drawing.Size(535, 188);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MessageLabel);
            this.Controls.Add(this.ContinueDepositButton);
            this.Controls.Add(this.ConfirmDepositButton);
            this.Controls.Add(this.CancelDepositButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "StackerFullDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label3;
        private Label label2;
        private Label label1;
        private Label MessageLabel;
        private CustomButton ContinueDepositButton;
        private CustomButton ConfirmDepositButton;
        private CustomButton CancelDepositButton;
    }
}