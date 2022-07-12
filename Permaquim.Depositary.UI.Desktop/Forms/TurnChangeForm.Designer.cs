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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.InformationLabel = new System.Windows.Forms.Label();
            this.MainPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.OperationsHeaderGridView = new System.Windows.Forms.DataGridView();
            this.OperationsDetailGridView = new System.Windows.Forms.DataGridView();
            this.TurnLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.OperationsHeaderGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OperationsDetailGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // InformationLabel
            // 
            this.InformationLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InformationLabel.BackColor = System.Drawing.Color.Transparent;
            this.InformationLabel.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.InformationLabel.ForeColor = System.Drawing.Color.Red;
            this.InformationLabel.Location = new System.Drawing.Point(40, 464);
            this.InformationLabel.Name = "InformationLabel";
            this.InformationLabel.Size = new System.Drawing.Size(697, 32);
            this.InformationLabel.TabIndex = 146;
            this.InformationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainPanel
            // 
            this.MainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.MainPanel.BackColor = System.Drawing.Color.Transparent;
            this.MainPanel.Location = new System.Drawing.Point(168, 504);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(448, 55);
            this.MainPanel.TabIndex = 187;
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
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.OperationsHeaderGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.OperationsHeaderGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.OperationsHeaderGridView.DefaultCellStyle = dataGridViewCellStyle7;
            this.OperationsHeaderGridView.EnableHeadersVisualStyles = false;
            this.OperationsHeaderGridView.GridColor = System.Drawing.Color.White;
            this.OperationsHeaderGridView.Location = new System.Drawing.Point(13, 32);
            this.OperationsHeaderGridView.Name = "OperationsHeaderGridView";
            this.OperationsHeaderGridView.RowHeadersVisible = false;
            this.OperationsHeaderGridView.RowTemplate.DividerHeight = 1;
            this.OperationsHeaderGridView.RowTemplate.Height = 30;
            this.OperationsHeaderGridView.RowTemplate.ReadOnly = true;
            this.OperationsHeaderGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.OperationsHeaderGridView.Size = new System.Drawing.Size(776, 178);
            this.OperationsHeaderGridView.TabIndex = 188;
            this.OperationsHeaderGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OperationsHeaderGridView_CellClick);
            this.OperationsHeaderGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OperationsHeaderGridView_DataError);
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
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.OperationsDetailGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.OperationsDetailGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.OperationsDetailGridView.DefaultCellStyle = dataGridViewCellStyle9;
            this.OperationsDetailGridView.EnableHeadersVisualStyles = false;
            this.OperationsDetailGridView.GridColor = System.Drawing.Color.White;
            this.OperationsDetailGridView.Location = new System.Drawing.Point(13, 221);
            this.OperationsDetailGridView.Name = "OperationsDetailGridView";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.OperationsDetailGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.OperationsDetailGridView.RowHeadersVisible = false;
            this.OperationsDetailGridView.RowTemplate.DividerHeight = 1;
            this.OperationsDetailGridView.RowTemplate.Height = 30;
            this.OperationsDetailGridView.RowTemplate.ReadOnly = true;
            this.OperationsDetailGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.OperationsDetailGridView.Size = new System.Drawing.Size(776, 180);
            this.OperationsDetailGridView.TabIndex = 189;
            this.OperationsDetailGridView.Visible = false;
            this.OperationsDetailGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OperationsHeaderGridView_DataError);
            // 
            // TurnLabel
            // 
            this.TurnLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TurnLabel.BackColor = System.Drawing.Color.SteelBlue;
            this.TurnLabel.Font = new System.Drawing.Font("Verdana", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TurnLabel.ForeColor = System.Drawing.Color.White;
            this.TurnLabel.Location = new System.Drawing.Point(13, 0);
            this.TurnLabel.Name = "TurnLabel";
            this.TurnLabel.Size = new System.Drawing.Size(776, 27);
            this.TurnLabel.TabIndex = 190;
            this.TurnLabel.Text = "*";
            // 
            // TurnChangeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.TurnLabel);
            this.Controls.Add(this.InformationLabel);
            this.Controls.Add(this.OperationsHeaderGridView);
            this.Controls.Add(this.OperationsDetailGridView);
            this.Controls.Add(this.MainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TurnChangeForm";
            this.Text = "TurnChangeForm";
            this.Load += new System.EventHandler(this.TurnChangeForm_Load);
            this.VisibleChanged += new System.EventHandler(this.TurnChangeForm_VisibleChanged);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TurnChangeForm_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.OperationsHeaderGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OperationsDetailGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Label InformationLabel;
        private FlowLayoutPanel MainPanel;
        private DataGridView OperationsHeaderGridView;
        private DataGridView OperationsDetailGridView;
        private Label TurnLabel;
    }
}