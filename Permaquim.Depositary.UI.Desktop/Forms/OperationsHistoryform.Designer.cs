﻿namespace Permaquim.Depositary.UI.Desktop
{
    partial class OperationsHistoryForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.BackButton = new Permaquim.Depositary.UI.Desktop.CustomButton();
            this.OperationsHeaderGridView = new System.Windows.Forms.DataGridView();
            this.FilterPanel = new System.Windows.Forms.Panel();
            this.UserLabel = new System.Windows.Forms.Label();
            this.TurnLabel = new System.Windows.Forms.Label();
            this.ToDateTimeLabel = new System.Windows.Forms.Label();
            this.FromDateTimeLabel = new System.Windows.Forms.Label();
            this.ExecuteButton = new Permaquim.Depositary.UI.Desktop.CustomButton();
            this.UserComboBox = new System.Windows.Forms.ComboBox();
            this.TurnComboBox = new System.Windows.Forms.ComboBox();
            this.ToDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.FromDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.DetailPanel = new System.Windows.Forms.Panel();
            this.PrintButton = new Permaquim.Depositary.UI.Desktop.CustomButton();
            this.AcceptButton = new Permaquim.Depositary.UI.Desktop.CustomButton();
            this.OperationsDetailGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.OperationsHeaderGridView)).BeginInit();
            this.FilterPanel.SuspendLayout();
            this.DetailPanel.SuspendLayout();
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
            this.BackButton.Location = new System.Drawing.Point(392, 592);
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
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.OperationsHeaderGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.OperationsHeaderGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.OperationsHeaderGridView.DefaultCellStyle = dataGridViewCellStyle12;
            this.OperationsHeaderGridView.EnableHeadersVisualStyles = false;
            this.OperationsHeaderGridView.GridColor = System.Drawing.Color.White;
            this.OperationsHeaderGridView.Location = new System.Drawing.Point(16, 152);
            this.OperationsHeaderGridView.Name = "OperationsHeaderGridView";
            this.OperationsHeaderGridView.RowHeadersVisible = false;
            this.OperationsHeaderGridView.RowTemplate.DividerHeight = 1;
            this.OperationsHeaderGridView.RowTemplate.Height = 30;
            this.OperationsHeaderGridView.RowTemplate.ReadOnly = true;
            this.OperationsHeaderGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.OperationsHeaderGridView.Size = new System.Drawing.Size(925, 392);
            this.OperationsHeaderGridView.TabIndex = 181;
            this.OperationsHeaderGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OperationsHeaderGridView_CellClick);
            this.OperationsHeaderGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OperationsHeaderGridView_DataError);
            // 
            // FilterPanel
            // 
            this.FilterPanel.Controls.Add(this.UserLabel);
            this.FilterPanel.Controls.Add(this.TurnLabel);
            this.FilterPanel.Controls.Add(this.ToDateTimeLabel);
            this.FilterPanel.Controls.Add(this.FromDateTimeLabel);
            this.FilterPanel.Controls.Add(this.ExecuteButton);
            this.FilterPanel.Controls.Add(this.UserComboBox);
            this.FilterPanel.Controls.Add(this.TurnComboBox);
            this.FilterPanel.Controls.Add(this.ToDateTimePicker);
            this.FilterPanel.Controls.Add(this.FromDateTimePicker);
            this.FilterPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.FilterPanel.Location = new System.Drawing.Point(0, 0);
            this.FilterPanel.Name = "FilterPanel";
            this.FilterPanel.Size = new System.Drawing.Size(953, 88);
            this.FilterPanel.TabIndex = 183;
            // 
            // UserLabel
            // 
            this.UserLabel.BackColor = System.Drawing.Color.SteelBlue;
            this.UserLabel.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.UserLabel.ForeColor = System.Drawing.Color.White;
            this.UserLabel.Location = new System.Drawing.Point(616, 13);
            this.UserLabel.Name = "UserLabel";
            this.UserLabel.Size = new System.Drawing.Size(176, 27);
            this.UserLabel.TabIndex = 201;
            this.UserLabel.Text = "*";
            // 
            // TurnLabel
            // 
            this.TurnLabel.BackColor = System.Drawing.Color.SteelBlue;
            this.TurnLabel.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TurnLabel.ForeColor = System.Drawing.Color.White;
            this.TurnLabel.Location = new System.Drawing.Point(432, 13);
            this.TurnLabel.Name = "TurnLabel";
            this.TurnLabel.Size = new System.Drawing.Size(176, 27);
            this.TurnLabel.TabIndex = 200;
            this.TurnLabel.Text = "*";
            // 
            // ToDateTimeLabel
            // 
            this.ToDateTimeLabel.BackColor = System.Drawing.Color.SteelBlue;
            this.ToDateTimeLabel.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ToDateTimeLabel.ForeColor = System.Drawing.Color.White;
            this.ToDateTimeLabel.Location = new System.Drawing.Point(224, 13);
            this.ToDateTimeLabel.Name = "ToDateTimeLabel";
            this.ToDateTimeLabel.Size = new System.Drawing.Size(200, 27);
            this.ToDateTimeLabel.TabIndex = 199;
            this.ToDateTimeLabel.Text = "*";
            // 
            // FromDateTimeLabel
            // 
            this.FromDateTimeLabel.BackColor = System.Drawing.Color.SteelBlue;
            this.FromDateTimeLabel.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FromDateTimeLabel.ForeColor = System.Drawing.Color.White;
            this.FromDateTimeLabel.Location = new System.Drawing.Point(16, 13);
            this.FromDateTimeLabel.Name = "FromDateTimeLabel";
            this.FromDateTimeLabel.Size = new System.Drawing.Size(200, 27);
            this.FromDateTimeLabel.TabIndex = 198;
            this.FromDateTimeLabel.Text = "*";
            // 
            // ExecuteButton
            // 
            this.ExecuteButton.BackColor = System.Drawing.Color.SteelBlue;
            this.ExecuteButton.BackgroundColor = System.Drawing.Color.SteelBlue;
            this.ExecuteButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.ExecuteButton.BorderRadius = 5;
            this.ExecuteButton.BorderSize = 0;
            this.ExecuteButton.FlatAppearance.BorderSize = 0;
            this.ExecuteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExecuteButton.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ExecuteButton.ForeColor = System.Drawing.Color.White;
            this.ExecuteButton.Location = new System.Drawing.Point(808, 8);
            this.ExecuteButton.Name = "ExecuteButton";
            this.ExecuteButton.Size = new System.Drawing.Size(128, 64);
            this.ExecuteButton.TabIndex = 197;
            this.ExecuteButton.Text = "***";
            this.ExecuteButton.TextColor = System.Drawing.Color.White;
            this.ExecuteButton.UseVisualStyleBackColor = false;
            this.ExecuteButton.Click += new System.EventHandler(this.ExecuteButton_Click);
            // 
            // UserComboBox
            // 
            this.UserComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.UserComboBox.FormattingEnabled = true;
            this.UserComboBox.Location = new System.Drawing.Point(616, 45);
            this.UserComboBox.Name = "UserComboBox";
            this.UserComboBox.Size = new System.Drawing.Size(175, 23);
            this.UserComboBox.TabIndex = 196;
            // 
            // TurnComboBox
            // 
            this.TurnComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            // DetailPanel
            // 
            this.DetailPanel.Controls.Add(this.PrintButton);
            this.DetailPanel.Controls.Add(this.AcceptButton);
            this.DetailPanel.Controls.Add(this.OperationsDetailGridView);
            this.DetailPanel.Location = new System.Drawing.Point(16, 152);
            this.DetailPanel.Name = "DetailPanel";
            this.DetailPanel.Size = new System.Drawing.Size(920, 392);
            this.DetailPanel.TabIndex = 184;
            this.DetailPanel.Visible = false;
            // 
            // PrintButton
            // 
            this.PrintButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PrintButton.BackColor = System.Drawing.Color.SteelBlue;
            this.PrintButton.BackgroundColor = System.Drawing.Color.SteelBlue;
            this.PrintButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.PrintButton.BorderRadius = 5;
            this.PrintButton.BorderSize = 0;
            this.PrintButton.FlatAppearance.BorderSize = 0;
            this.PrintButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PrintButton.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.PrintButton.ForeColor = System.Drawing.Color.White;
            this.PrintButton.Location = new System.Drawing.Point(752, 328);
            this.PrintButton.Name = "PrintButton";
            this.PrintButton.Size = new System.Drawing.Size(160, 55);
            this.PrintButton.TabIndex = 185;
            this.PrintButton.Text = "Imprimir";
            this.PrintButton.TextColor = System.Drawing.Color.White;
            this.PrintButton.UseVisualStyleBackColor = false;
            this.PrintButton.Click += new System.EventHandler(this.PrintButton_Click);
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
            this.AcceptButton.Location = new System.Drawing.Point(496, 328);
            this.AcceptButton.Name = "AcceptButton";
            this.AcceptButton.Size = new System.Drawing.Size(160, 55);
            this.AcceptButton.TabIndex = 184;
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
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.OperationsDetailGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.OperationsDetailGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.OperationsDetailGridView.DefaultCellStyle = dataGridViewCellStyle14;
            this.OperationsDetailGridView.EnableHeadersVisualStyles = false;
            this.OperationsDetailGridView.GridColor = System.Drawing.Color.White;
            this.OperationsDetailGridView.Location = new System.Drawing.Point(8, 8);
            this.OperationsDetailGridView.Name = "OperationsDetailGridView";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.OperationsDetailGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.OperationsDetailGridView.RowHeadersVisible = false;
            this.OperationsDetailGridView.RowTemplate.DividerHeight = 1;
            this.OperationsDetailGridView.RowTemplate.Height = 30;
            this.OperationsDetailGridView.RowTemplate.ReadOnly = true;
            this.OperationsDetailGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.OperationsDetailGridView.Size = new System.Drawing.Size(904, 292);
            this.OperationsDetailGridView.TabIndex = 183;
            // 
            // OperationsHistoryform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 711);
            this.Controls.Add(this.DetailPanel);
            this.Controls.Add(this.FilterPanel);
            this.Controls.Add(this.OperationsHeaderGridView);
            this.Controls.Add(this.BackButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OperationsHistoryform";
            this.Text = "OperationsHistoryform";
            this.VisibleChanged += new System.EventHandler(this.OperationsHistoryform_VisibleChanged);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OperationsHistoryform_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.OperationsHeaderGridView)).EndInit();
            this.FilterPanel.ResumeLayout(false);
            this.DetailPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OperationsDetailGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private CustomButton BackButton;
        private DataGridView OperationsHeaderGridView;
        private Panel FilterPanel;
        private Label UserLabel;
        private Label TurnLabel;
        private Label ToDateTimeLabel;
        private Label FromDateTimeLabel;
        private ComboBox UserComboBox;
        private ComboBox TurnComboBox;
        private DateTimePicker ToDateTimePicker;
        private DateTimePicker FromDateTimePicker;
        private CustomButton ExecuteButton;
        private Panel DetailPanel;
        private CustomButton AcceptButton;
        private DataGridView OperationsDetailGridView;
        private CustomButton PrintButton;
    }
}