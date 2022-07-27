namespace Permaquim.Depositary.UI.Desktop
{
    partial class PreferencesForm
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
            this.MainPropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.ConfirmAndContinueDepositButton = new Permaquim.Depositary.UI.Desktop.CustomButton();
            this.CancelDepositButton = new Permaquim.Depositary.UI.Desktop.CustomButton();
            this.SuspendLayout();
            // 
            // MainPropertyGrid
            // 
            this.MainPropertyGrid.Location = new System.Drawing.Point(0, 0);
            this.MainPropertyGrid.Name = "MainPropertyGrid";
            this.MainPropertyGrid.Size = new System.Drawing.Size(800, 424);
            this.MainPropertyGrid.TabIndex = 2;
            // 
            // ConfirmAndContinueDepositButton
            // 
            this.ConfirmAndContinueDepositButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConfirmAndContinueDepositButton.BackColor = System.Drawing.Color.SeaGreen;
            this.ConfirmAndContinueDepositButton.BackgroundColor = System.Drawing.Color.SeaGreen;
            this.ConfirmAndContinueDepositButton.BorderColor = System.Drawing.Color.MediumSeaGreen;
            this.ConfirmAndContinueDepositButton.BorderRadius = 4;
            this.ConfirmAndContinueDepositButton.BorderSize = 0;
            this.ConfirmAndContinueDepositButton.FlatAppearance.BorderSize = 0;
            this.ConfirmAndContinueDepositButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConfirmAndContinueDepositButton.Font = new System.Drawing.Font("Verdana", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ConfirmAndContinueDepositButton.ForeColor = System.Drawing.Color.White;
            this.ConfirmAndContinueDepositButton.Location = new System.Drawing.Point(176, 440);
            this.ConfirmAndContinueDepositButton.Name = "ConfirmAndContinueDepositButton";
            this.ConfirmAndContinueDepositButton.Size = new System.Drawing.Size(228, 55);
            this.ConfirmAndContinueDepositButton.TabIndex = 152;
            this.ConfirmAndContinueDepositButton.Tag = "";
            this.ConfirmAndContinueDepositButton.Text = ">";
            this.ConfirmAndContinueDepositButton.TextColor = System.Drawing.Color.White;
            this.ConfirmAndContinueDepositButton.UseVisualStyleBackColor = false;
            this.ConfirmAndContinueDepositButton.Click += new System.EventHandler(this.ConfirmAndContinueDepositButton_Click);
            // 
            // CancelDepositButton
            // 
            this.CancelDepositButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.CancelDepositButton.BackColor = System.Drawing.Color.Red;
            this.CancelDepositButton.BackgroundColor = System.Drawing.Color.Red;
            this.CancelDepositButton.BorderColor = System.Drawing.Color.DarkOrange;
            this.CancelDepositButton.BorderRadius = 4;
            this.CancelDepositButton.BorderSize = 0;
            this.CancelDepositButton.FlatAppearance.BorderSize = 0;
            this.CancelDepositButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelDepositButton.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CancelDepositButton.ForeColor = System.Drawing.Color.White;
            this.CancelDepositButton.Location = new System.Drawing.Point(408, 440);
            this.CancelDepositButton.Name = "CancelDepositButton";
            this.CancelDepositButton.Size = new System.Drawing.Size(230, 55);
            this.CancelDepositButton.TabIndex = 151;
            this.CancelDepositButton.Tag = "";
            this.CancelDepositButton.Text = "X";
            this.CancelDepositButton.TextColor = System.Drawing.Color.White;
            this.CancelDepositButton.UseVisualStyleBackColor = false;
            this.CancelDepositButton.Click += new System.EventHandler(this.CancelDepositButton_Click);
            // 
            // PreferencesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 508);
            this.Controls.Add(this.ConfirmAndContinueDepositButton);
            this.Controls.Add(this.CancelDepositButton);
            this.Controls.Add(this.MainPropertyGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PreferencesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PreferencesForm";
            this.ResumeLayout(false);

        }

        #endregion

        private Panel MainPanel;
        private PropertyGrid MainPropertyGrid;
        private CustomButton ConfirmAndContinueDepositButton;
        private CustomButton CancelDepositButton;
    }
}