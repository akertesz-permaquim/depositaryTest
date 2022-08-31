namespace Permaquim.Depositary.UI.Desktop
{
    partial class TurnChangeForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.OperationsHeaderGridView = new System.Windows.Forms.DataGridView();
            this.TurnLabel = new System.Windows.Forms.Label();
            this.MainPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.DetailsPanel = new System.Windows.Forms.Panel();
            this.AcceptButton = new Permaquim.Depositary.UI.Desktop.CustomButton();
            this.OperationsDetailGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.OperationsHeaderGridView)).BeginInit();
            this.DetailsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OperationsDetailGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // OperationsHeaderGridView
            // 
            this.OperationsHeaderGridView.AllowUserToAddRows = false;
            this.OperationsHeaderGridView.AllowUserToDeleteRows = false;
            this.OperationsHeaderGridView.AllowUserToResizeColumns = false;
            this.OperationsHeaderGridView.AllowUserToResizeRows = false;
            this.OperationsHeaderGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.OperationsHeaderGridView.BackgroundColor = System.Drawing.Color.White;
            this.OperationsHeaderGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.OperationsHeaderGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.OperationsHeaderGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.OperationsHeaderGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.OperationsHeaderGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.OperationsHeaderGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.OperationsHeaderGridView.EnableHeadersVisualStyles = false;
            this.OperationsHeaderGridView.GridColor = System.Drawing.Color.White;
            this.OperationsHeaderGridView.Location = new System.Drawing.Point(13, 64);
            this.OperationsHeaderGridView.Name = "OperationsHeaderGridView";
            this.OperationsHeaderGridView.RowHeadersVisible = false;
            this.OperationsHeaderGridView.RowTemplate.DividerHeight = 1;
            this.OperationsHeaderGridView.RowTemplate.Height = 30;
            this.OperationsHeaderGridView.RowTemplate.ReadOnly = true;
            this.OperationsHeaderGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.OperationsHeaderGridView.Size = new System.Drawing.Size(760, 360);
            this.OperationsHeaderGridView.TabIndex = 188;
            this.OperationsHeaderGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OperationsHeaderGridView_CellClick);
            this.OperationsHeaderGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OperationsHeaderGridView_DataError);
            // 
            // TurnLabel
            // 
            this.TurnLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TurnLabel.BackColor = System.Drawing.Color.SteelBlue;
            this.TurnLabel.Font = new System.Drawing.Font("Verdana", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TurnLabel.ForeColor = System.Drawing.Color.White;
            this.TurnLabel.Location = new System.Drawing.Point(13, 32);
            this.TurnLabel.Name = "TurnLabel";
            this.TurnLabel.Size = new System.Drawing.Size(760, 27);
            this.TurnLabel.TabIndex = 190;
            this.TurnLabel.Text = "*";
            // 
            // MainPanel
            // 
            this.MainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.MainPanel.BackColor = System.Drawing.Color.Transparent;
            this.MainPanel.Location = new System.Drawing.Point(168, 448);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(448, 88);
            this.MainPanel.TabIndex = 191;
            // 
            // DetailsPanel
            // 
            this.DetailsPanel.Controls.Add(this.AcceptButton);
            this.DetailsPanel.Controls.Add(this.OperationsDetailGridView);
            this.DetailsPanel.Location = new System.Drawing.Point(16, 64);
            this.DetailsPanel.Name = "DetailsPanel";
            this.DetailsPanel.Size = new System.Drawing.Size(752, 360);
            this.DetailsPanel.TabIndex = 192;
            this.DetailsPanel.Visible = false;
            // 
            // AcceptButton
            // 
            this.AcceptButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AcceptButton.BackColor = System.Drawing.Color.SteelBlue;
            this.AcceptButton.BackgroundColor = System.Drawing.Color.SteelBlue;
            this.AcceptButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.AcceptButton.BorderRadius = 5;
            this.AcceptButton.BorderSize = 0;
            this.AcceptButton.FlatAppearance.BorderSize = 0;
            this.AcceptButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AcceptButton.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.AcceptButton.ForeColor = System.Drawing.Color.White;
            this.AcceptButton.Location = new System.Drawing.Point(316, 288);
            this.AcceptButton.Name = "AcceptButton";
            this.AcceptButton.Size = new System.Drawing.Size(160, 55);
            this.AcceptButton.TabIndex = 191;
            this.AcceptButton.Text = "Salir";
            this.AcceptButton.TextColor = System.Drawing.Color.White;
            this.AcceptButton.UseVisualStyleBackColor = false;
            this.AcceptButton.Click += new System.EventHandler(this.AcceptButton_Click);
            // 
            // OperationsDetailGridView
            // 
            this.OperationsDetailGridView.AllowUserToAddRows = false;
            this.OperationsDetailGridView.AllowUserToDeleteRows = false;
            this.OperationsDetailGridView.AllowUserToResizeColumns = false;
            this.OperationsDetailGridView.AllowUserToResizeRows = false;
            this.OperationsDetailGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.OperationsDetailGridView.BackgroundColor = System.Drawing.Color.White;
            this.OperationsDetailGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.OperationsDetailGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.OperationsDetailGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.OperationsDetailGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.OperationsDetailGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.OperationsDetailGridView.DefaultCellStyle = dataGridViewCellStyle4;
            this.OperationsDetailGridView.EnableHeadersVisualStyles = false;
            this.OperationsDetailGridView.GridColor = System.Drawing.Color.White;
            this.OperationsDetailGridView.Location = new System.Drawing.Point(8, 8);
            this.OperationsDetailGridView.Name = "OperationsDetailGridView";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.OperationsDetailGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.OperationsDetailGridView.RowHeadersVisible = false;
            this.OperationsDetailGridView.RowTemplate.DividerHeight = 1;
            this.OperationsDetailGridView.RowTemplate.Height = 30;
            this.OperationsDetailGridView.RowTemplate.ReadOnly = true;
            this.OperationsDetailGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.OperationsDetailGridView.Size = new System.Drawing.Size(736, 264);
            this.OperationsDetailGridView.TabIndex = 190;
            // 
            // TurnChangeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 600);
            this.Controls.Add(this.DetailsPanel);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.TurnLabel);
            this.Controls.Add(this.OperationsHeaderGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TurnChangeForm";
            this.Text = "TurnChangeForm";
            this.Load += new System.EventHandler(this.TurnChangeForm_Load);
            this.VisibleChanged += new System.EventHandler(this.TurnChangeForm_VisibleChanged);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TurnChangeForm_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.OperationsHeaderGridView)).EndInit();
            this.DetailsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OperationsDetailGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DataGridView OperationsHeaderGridView;
        private Label TurnLabel;
        private FlowLayoutPanel MainPanel;
        private Panel DetailsPanel;
        private DataGridView OperationsDetailGridView;
        private CustomButton AcceptButton;
    }
}