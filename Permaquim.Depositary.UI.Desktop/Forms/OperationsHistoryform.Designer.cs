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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.BackButton = new Permaquim.Depositary.UI.Desktop.CustomButton();
            this.OperationsHeaderGridView = new System.Windows.Forms.DataGridView();
            this.OperationsDetailGridView = new System.Windows.Forms.DataGridView();
            this.FilterPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.RemainingTimeLabel = new System.Windows.Forms.Label();
            this.ExecuteButton = new Permaquim.Depositary.UI.Desktop.CustomButton();
            this.UserComboBox = new System.Windows.Forms.ComboBox();
            this.TurnComboBox = new System.Windows.Forms.ComboBox();
            this.ToDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.FromDateTimePicker = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.OperationsHeaderGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OperationsDetailGridView)).BeginInit();
            this.FilterPanel.SuspendLayout();
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
            this.BackButton.Location = new System.Drawing.Point(392, 616);
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
            this.OperationsHeaderGridView.Location = new System.Drawing.Point(16, 88);
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
            this.OperationsDetailGridView.Location = new System.Drawing.Point(16, 352);
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
            this.OperationsDetailGridView.Size = new System.Drawing.Size(925, 256);
            this.OperationsDetailGridView.TabIndex = 182;
            this.OperationsDetailGridView.Visible = false;
            this.OperationsDetailGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OperationsDetailGridView_CellClick);
            this.OperationsDetailGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OperationsHeaderGridView_DataError);
            // 
            // FilterPanel
            // 
            this.FilterPanel.Controls.Add(this.label3);
            this.FilterPanel.Controls.Add(this.label2);
            this.FilterPanel.Controls.Add(this.label1);
            this.FilterPanel.Controls.Add(this.RemainingTimeLabel);
            this.FilterPanel.Controls.Add(this.ExecuteButton);
            this.FilterPanel.Controls.Add(this.UserComboBox);
            this.FilterPanel.Controls.Add(this.TurnComboBox);
            this.FilterPanel.Controls.Add(this.ToDateTimePicker);
            this.FilterPanel.Controls.Add(this.FromDateTimePicker);
            this.FilterPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.FilterPanel.Location = new System.Drawing.Point(0, 0);
            this.FilterPanel.Name = "FilterPanel";
            this.FilterPanel.Size = new System.Drawing.Size(953, 80);
            this.FilterPanel.TabIndex = 183;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.SteelBlue;
            this.label3.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(616, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 27);
            this.label3.TabIndex = 201;
            this.label3.Text = "*";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.SteelBlue;
            this.label2.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(432, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 27);
            this.label2.TabIndex = 200;
            this.label2.Text = "*";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(224, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 27);
            this.label1.TabIndex = 199;
            this.label1.Text = "*";
            // 
            // RemainingTimeLabel
            // 
            this.RemainingTimeLabel.BackColor = System.Drawing.Color.SteelBlue;
            this.RemainingTimeLabel.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RemainingTimeLabel.ForeColor = System.Drawing.Color.White;
            this.RemainingTimeLabel.Location = new System.Drawing.Point(16, 13);
            this.RemainingTimeLabel.Name = "RemainingTimeLabel";
            this.RemainingTimeLabel.Size = new System.Drawing.Size(200, 27);
            this.RemainingTimeLabel.TabIndex = 198;
            this.RemainingTimeLabel.Text = "*";
            // 
            // ExecuteButton
            // 
            this.ExecuteButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ExecuteButton.BackColor = System.Drawing.Color.SteelBlue;
            this.ExecuteButton.BackgroundColor = System.Drawing.Color.SteelBlue;
            this.ExecuteButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.ExecuteButton.BorderRadius = 5;
            this.ExecuteButton.BorderSize = 0;
            this.ExecuteButton.FlatAppearance.BorderSize = 0;
            this.ExecuteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExecuteButton.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ExecuteButton.ForeColor = System.Drawing.Color.White;
            this.ExecuteButton.Location = new System.Drawing.Point(816, 21);
            this.ExecuteButton.Name = "ExecuteButton";
            this.ExecuteButton.Size = new System.Drawing.Size(120, 32);
            this.ExecuteButton.TabIndex = 197;
            this.ExecuteButton.Text = "Ejecutar";
            this.ExecuteButton.TextColor = System.Drawing.Color.White;
            this.ExecuteButton.UseVisualStyleBackColor = false;
            this.ExecuteButton.Click += new System.EventHandler(this.ExecuteButton_Click);
            // 
            // UserComboBox
            // 
            this.UserComboBox.FormattingEnabled = true;
            this.UserComboBox.Location = new System.Drawing.Point(616, 45);
            this.UserComboBox.Name = "UserComboBox";
            this.UserComboBox.Size = new System.Drawing.Size(175, 23);
            this.UserComboBox.TabIndex = 196;
            // 
            // TurnComboBox
            // 
            this.TurnComboBox.FormattingEnabled = true;
            this.TurnComboBox.Location = new System.Drawing.Point(432, 45);
            this.TurnComboBox.Name = "TurnComboBox";
            this.TurnComboBox.Size = new System.Drawing.Size(175, 23);
            this.TurnComboBox.TabIndex = 195;
            // 
            // ToDateTimePicker
            // 
            this.ToDateTimePicker.Location = new System.Drawing.Point(224, 45);
            this.ToDateTimePicker.Name = "ToDateTimePicker";
            this.ToDateTimePicker.Size = new System.Drawing.Size(200, 23);
            this.ToDateTimePicker.TabIndex = 194;
            // 
            // FromDateTimePicker
            // 
            this.FromDateTimePicker.Location = new System.Drawing.Point(16, 45);
            this.FromDateTimePicker.Name = "FromDateTimePicker";
            this.FromDateTimePicker.Size = new System.Drawing.Size(200, 23);
            this.FromDateTimePicker.TabIndex = 193;
            // 
            // OperationsHistoryform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 711);
            this.Controls.Add(this.FilterPanel);
            this.Controls.Add(this.OperationsHeaderGridView);
            this.Controls.Add(this.OperationsDetailGridView);
            this.Controls.Add(this.BackButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OperationsHistoryform";
            this.Text = "OperationsHistoryform";
            this.VisibleChanged += new System.EventHandler(this.OperationsHistoryform_VisibleChanged);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OperationsHistoryform_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.OperationsHeaderGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OperationsDetailGridView)).EndInit();
            this.FilterPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private CustomButton BackButton;
        private DataGridView OperationsHeaderGridView;
        private DataGridView OperationsDetailGridView;
        private Panel FilterPanel;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label RemainingTimeLabel;
        private CustomButton ExecuteButton;
        private ComboBox UserComboBox;
        private ComboBox TurnComboBox;
        private DateTimePicker ToDateTimePicker;
        private DateTimePicker FromDateTimePicker;
    }
}