namespace Permaquim.Depositary.UI.Desktop
{
    partial class OperationsHistoryform
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
            this.BackButton = new Permaquim.Depositary.UI.Desktop.CustomButton();
            this.OperationsHeaderGridView = new System.Windows.Forms.DataGridView();
            this.OperationsDetailGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.OperationsHeaderGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OperationsDetailGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // BackButton
            // 
            this.BackButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BackButton.BackColor = System.Drawing.Color.SteelBlue;
            this.BackButton.BackgroundColor = System.Drawing.Color.SteelBlue;
            this.BackButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BackButton.BorderRadius = 5;
            this.BackButton.BorderSize = 0;
            this.BackButton.FlatAppearance.BorderSize = 0;
            this.BackButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackButton.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BackButton.ForeColor = System.Drawing.Color.White;
            this.BackButton.Location = new System.Drawing.Point(368, 552);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(160, 55);
            this.BackButton.TabIndex = 179;
            this.BackButton.Text = "Salir";
            this.BackButton.TextColor = System.Drawing.Color.White;
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // OperationsHeaderGridView
            // 
            this.OperationsHeaderGridView.AllowUserToAddRows = false;
            this.OperationsHeaderGridView.AllowUserToDeleteRows = false;
            this.OperationsHeaderGridView.AllowUserToResizeColumns = false;
            this.OperationsHeaderGridView.AllowUserToResizeRows = false;
            this.OperationsHeaderGridView.Anchor = System.Windows.Forms.AnchorStyles.None;
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
            this.OperationsHeaderGridView.Location = new System.Drawing.Point(14, 8);
            this.OperationsHeaderGridView.Name = "OperationsHeaderGridView";
            this.OperationsHeaderGridView.RowHeadersVisible = false;
            this.OperationsHeaderGridView.RowTemplate.DividerHeight = 1;
            this.OperationsHeaderGridView.RowTemplate.Height = 30;
            this.OperationsHeaderGridView.RowTemplate.ReadOnly = true;
            this.OperationsHeaderGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.OperationsHeaderGridView.Size = new System.Drawing.Size(925, 256);
            this.OperationsHeaderGridView.TabIndex = 181;
            this.OperationsHeaderGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OperationsHeaderGridView_CellClick);
            this.OperationsHeaderGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OperationsHeaderGridView_DataError);
            // 
            // OperationsDetailGridView
            // 
            this.OperationsDetailGridView.AllowUserToAddRows = false;
            this.OperationsDetailGridView.AllowUserToDeleteRows = false;
            this.OperationsDetailGridView.AllowUserToResizeColumns = false;
            this.OperationsDetailGridView.AllowUserToResizeRows = false;
            this.OperationsDetailGridView.Anchor = System.Windows.Forms.AnchorStyles.None;
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
            this.OperationsDetailGridView.Location = new System.Drawing.Point(14, 270);
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
            this.OperationsDetailGridView.Size = new System.Drawing.Size(925, 256);
            this.OperationsDetailGridView.TabIndex = 182;
            this.OperationsDetailGridView.Visible = false;
            this.OperationsDetailGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OperationsDetailGridView_CellClick);
            this.OperationsDetailGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OperationsHeaderGridView_DataError);
            // 
            // OperationsHistoryform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 615);
            this.Controls.Add(this.OperationsHeaderGridView);
            this.Controls.Add(this.OperationsDetailGridView);
            this.Controls.Add(this.BackButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OperationsHistoryform";
            this.Text = "OperationsHistoryform";
            this.VisibleChanged += new System.EventHandler(this.OperationsHistoryform_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.OperationsHeaderGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OperationsDetailGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private CustomButton BackButton;
        private DataGridView OperationsHeaderGridView;
        private DataGridView OperationsDetailGridView;
    }
}