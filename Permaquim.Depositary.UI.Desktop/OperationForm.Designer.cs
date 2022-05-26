namespace Permaquim.Depositary.UI.Desktop
{
    partial class OperationForm
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
            this.MainPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.BillDepositButton = new Permaquim.Depositary.UI.Desktop.CustomButton();
            this.CoinDepositButton = new Permaquim.Depositary.UI.Desktop.CustomButton();
            this.EnvelopeDepositButton = new Permaquim.Depositary.UI.Desktop.CustomButton();
            this.BackButton = new Permaquim.Depositary.UI.Desktop.CustomButton();
            this.MainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.Color.Transparent;
            this.MainPanel.Controls.Add(this.BillDepositButton);
            this.MainPanel.Controls.Add(this.CoinDepositButton);
            this.MainPanel.Controls.Add(this.EnvelopeDepositButton);
            this.MainPanel.Controls.Add(this.BackButton);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(300, 450);
            this.MainPanel.TabIndex = 0;
            this.MainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.MainPanel_Paint);
            // 
            // BillDepositButton
            // 
            this.BillDepositButton.BackColor = System.Drawing.Color.SeaGreen;
            this.BillDepositButton.BackgroundColor = System.Drawing.Color.SeaGreen;
            this.BillDepositButton.BorderColor = System.Drawing.Color.LightGreen;
            this.BillDepositButton.BorderRadius = 5;
            this.BillDepositButton.BorderSize = 0;
            this.BillDepositButton.FlatAppearance.BorderSize = 0;
            this.BillDepositButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BillDepositButton.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BillDepositButton.ForeColor = System.Drawing.Color.White;
            this.BillDepositButton.Location = new System.Drawing.Point(3, 3);
            this.BillDepositButton.Name = "BillDepositButton";
            this.BillDepositButton.Size = new System.Drawing.Size(293, 77);
            this.BillDepositButton.TabIndex = 0;
            this.BillDepositButton.Text = "Depositar Billetes";
            this.BillDepositButton.TextColor = System.Drawing.Color.White;
            this.BillDepositButton.UseVisualStyleBackColor = false;
            this.BillDepositButton.Click += new System.EventHandler(this.BillDepositButton_Click);
            // 
            // CoinDepositButton
            // 
            this.CoinDepositButton.BackColor = System.Drawing.Color.SeaGreen;
            this.CoinDepositButton.BackgroundColor = System.Drawing.Color.SeaGreen;
            this.CoinDepositButton.BorderColor = System.Drawing.Color.LightGreen;
            this.CoinDepositButton.BorderRadius = 5;
            this.CoinDepositButton.BorderSize = 0;
            this.CoinDepositButton.FlatAppearance.BorderSize = 0;
            this.CoinDepositButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CoinDepositButton.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CoinDepositButton.ForeColor = System.Drawing.Color.White;
            this.CoinDepositButton.Location = new System.Drawing.Point(3, 86);
            this.CoinDepositButton.Name = "CoinDepositButton";
            this.CoinDepositButton.Size = new System.Drawing.Size(293, 77);
            this.CoinDepositButton.TabIndex = 1;
            this.CoinDepositButton.Text = "Depositar Monedas";
            this.CoinDepositButton.TextColor = System.Drawing.Color.White;
            this.CoinDepositButton.UseVisualStyleBackColor = false;
            // 
            // EnvelopeDepositButton
            // 
            this.EnvelopeDepositButton.BackColor = System.Drawing.Color.SeaGreen;
            this.EnvelopeDepositButton.BackgroundColor = System.Drawing.Color.SeaGreen;
            this.EnvelopeDepositButton.BorderColor = System.Drawing.Color.LightGreen;
            this.EnvelopeDepositButton.BorderRadius = 5;
            this.EnvelopeDepositButton.BorderSize = 0;
            this.EnvelopeDepositButton.FlatAppearance.BorderSize = 0;
            this.EnvelopeDepositButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EnvelopeDepositButton.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.EnvelopeDepositButton.ForeColor = System.Drawing.Color.White;
            this.EnvelopeDepositButton.Location = new System.Drawing.Point(3, 169);
            this.EnvelopeDepositButton.Name = "EnvelopeDepositButton";
            this.EnvelopeDepositButton.Size = new System.Drawing.Size(293, 77);
            this.EnvelopeDepositButton.TabIndex = 2;
            this.EnvelopeDepositButton.Text = "Depositar Sobres";
            this.EnvelopeDepositButton.TextColor = System.Drawing.Color.White;
            this.EnvelopeDepositButton.UseVisualStyleBackColor = false;
            // 
            // BackButton
            // 
            this.BackButton.BackColor = System.Drawing.Color.SteelBlue;
            this.BackButton.BackgroundColor = System.Drawing.Color.SteelBlue;
            this.BackButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BackButton.BorderRadius = 5;
            this.BackButton.BorderSize = 0;
            this.BackButton.FlatAppearance.BorderSize = 0;
            this.BackButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackButton.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BackButton.ForeColor = System.Drawing.Color.White;
            this.BackButton.Location = new System.Drawing.Point(3, 252);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(293, 77);
            this.BackButton.TabIndex = 3;
            this.BackButton.Text = "Salir";
            this.BackButton.TextColor = System.Drawing.Color.White;
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // OperationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(300, 450);
            this.ControlBox = false;
            this.Controls.Add(this.MainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "OperationForm";
            this.Load += new System.EventHandler(this.OperationForm_Load);
            this.MainPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private FlowLayoutPanel MainPanel;
        private CustomButton BillDepositButton;
        private CustomButton CoinDepositButton;
        private CustomButton EnvelopeDepositButton;
        private CustomButton BackButton;
    }
}