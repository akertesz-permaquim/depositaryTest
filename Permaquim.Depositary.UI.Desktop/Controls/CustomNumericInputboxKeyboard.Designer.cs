namespace Permaquim.Depositary.UI.Desktop.Controls
{
    partial class CustomNumericInputboxKeyboard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.InformationLabel = new System.Windows.Forms.Label();
            this.Button_Delete = new System.Windows.Forms.Button();
            this.NumericInputBoxTexbox = new CustomTextBox();
            this.Button_0 = new System.Windows.Forms.Button();
            this.Button_9 = new System.Windows.Forms.Button();
            this.Button_8 = new System.Windows.Forms.Button();
            this.Button_7 = new System.Windows.Forms.Button();
            this.Button_6 = new System.Windows.Forms.Button();
            this.Button_5 = new System.Windows.Forms.Button();
            this.Button_4 = new System.Windows.Forms.Button();
            this.Button_3 = new System.Windows.Forms.Button();
            this.Button_2 = new System.Windows.Forms.Button();
            this.Button_1 = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // InformationLabel
            // 
            this.InformationLabel.BackColor = System.Drawing.Color.Transparent;
            this.InformationLabel.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.InformationLabel.ForeColor = System.Drawing.Color.Red;
            this.InformationLabel.Location = new System.Drawing.Point(-3, 357);
            this.InformationLabel.Name = "InformationLabel";
            this.InformationLabel.Size = new System.Drawing.Size(216, 44);
            this.InformationLabel.TabIndex = 195;
            this.InformationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Button_Delete
            // 
            this.Button_Delete.BackColor = System.Drawing.Color.SteelBlue;
            this.Button_Delete.FlatAppearance.BorderSize = 0;
            this.Button_Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Delete.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Button_Delete.ForeColor = System.Drawing.Color.White;
            this.Button_Delete.Location = new System.Drawing.Point(78, 238);
            this.Button_Delete.Name = "Button_Delete";
            this.Button_Delete.Size = new System.Drawing.Size(136, 55);
            this.Button_Delete.TabIndex = 194;
            this.Button_Delete.Tag = "{CLEAR}";
            this.Button_Delete.Text = "Borrar";
            this.Button_Delete.UseVisualStyleBackColor = false;
            this.Button_Delete.Click += new System.EventHandler(this.Delete);
            // 
            // NumericInputBoxTexbox
            // 
            this.NumericInputBoxTexbox.BackColor = System.Drawing.SystemColors.Window;
            this.NumericInputBoxTexbox.BorderColor = System.Drawing.Color.SteelBlue;
            this.NumericInputBoxTexbox.BorderFocusColor = System.Drawing.Color.MediumSlateBlue;
            this.NumericInputBoxTexbox.BorderRadius = 4;
            this.NumericInputBoxTexbox.BorderSize = 2;
            this.NumericInputBoxTexbox.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.NumericInputBoxTexbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.NumericInputBoxTexbox.Location = new System.Drawing.Point(5, 5);
            this.NumericInputBoxTexbox.Margin = new System.Windows.Forms.Padding(4);
            this.NumericInputBoxTexbox.MaxLength = 4;
            this.NumericInputBoxTexbox.Multiline = false;
            this.NumericInputBoxTexbox.Name = "NumericInputBoxTexbox";
            this.NumericInputBoxTexbox.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.NumericInputBoxTexbox.PasswordChar = false;
            this.NumericInputBoxTexbox.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.NumericInputBoxTexbox.PlaceholderText = "Ingrese número";
            this.NumericInputBoxTexbox.SelectionLength = 0;
            this.NumericInputBoxTexbox.SelectionStart = 0;
            this.NumericInputBoxTexbox.Size = new System.Drawing.Size(208, 45);
            this.NumericInputBoxTexbox.TabIndex = 193;
            this.NumericInputBoxTexbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.NumericInputBoxTexbox.Texts = "";
            this.NumericInputBoxTexbox.UnderlinedStyle = false;
            this.NumericInputBoxTexbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumericInputBoxTexbox_KeyPress);
            // 
            // Button_0
            // 
            this.Button_0.BackColor = System.Drawing.Color.SteelBlue;
            this.Button_0.FlatAppearance.BorderSize = 0;
            this.Button_0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_0.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Button_0.ForeColor = System.Drawing.Color.White;
            this.Button_0.Location = new System.Drawing.Point(4, 238);
            this.Button_0.Name = "Button_0";
            this.Button_0.Size = new System.Drawing.Size(65, 55);
            this.Button_0.TabIndex = 192;
            this.Button_0.Tag = "0";
            this.Button_0.Text = "0";
            this.Button_0.UseVisualStyleBackColor = false;
            this.Button_0.Click += new System.EventHandler(this.KeysHandler);
            // 
            // Button_9
            // 
            this.Button_9.BackColor = System.Drawing.Color.SteelBlue;
            this.Button_9.FlatAppearance.BorderSize = 0;
            this.Button_9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_9.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Button_9.ForeColor = System.Drawing.Color.White;
            this.Button_9.Location = new System.Drawing.Point(150, 61);
            this.Button_9.Name = "Button_9";
            this.Button_9.Size = new System.Drawing.Size(64, 55);
            this.Button_9.TabIndex = 191;
            this.Button_9.Tag = "9";
            this.Button_9.Text = "9";
            this.Button_9.UseVisualStyleBackColor = false;
            this.Button_9.Click += new System.EventHandler(this.KeysHandler);
            // 
            // Button_8
            // 
            this.Button_8.BackColor = System.Drawing.Color.SteelBlue;
            this.Button_8.FlatAppearance.BorderSize = 0;
            this.Button_8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_8.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Button_8.ForeColor = System.Drawing.Color.White;
            this.Button_8.Location = new System.Drawing.Point(78, 61);
            this.Button_8.Name = "Button_8";
            this.Button_8.Size = new System.Drawing.Size(64, 55);
            this.Button_8.TabIndex = 190;
            this.Button_8.Tag = "8";
            this.Button_8.Text = "8";
            this.Button_8.UseVisualStyleBackColor = false;
            this.Button_8.Click += new System.EventHandler(this.KeysHandler);
            // 
            // Button_7
            // 
            this.Button_7.BackColor = System.Drawing.Color.SteelBlue;
            this.Button_7.FlatAppearance.BorderSize = 0;
            this.Button_7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_7.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Button_7.ForeColor = System.Drawing.Color.White;
            this.Button_7.Location = new System.Drawing.Point(4, 61);
            this.Button_7.Name = "Button_7";
            this.Button_7.Size = new System.Drawing.Size(65, 55);
            this.Button_7.TabIndex = 189;
            this.Button_7.Tag = "7";
            this.Button_7.Text = "7";
            this.Button_7.UseVisualStyleBackColor = false;
            this.Button_7.Click += new System.EventHandler(this.KeysHandler);
            // 
            // Button_6
            // 
            this.Button_6.BackColor = System.Drawing.Color.SteelBlue;
            this.Button_6.FlatAppearance.BorderSize = 0;
            this.Button_6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_6.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Button_6.ForeColor = System.Drawing.Color.White;
            this.Button_6.Location = new System.Drawing.Point(150, 121);
            this.Button_6.Name = "Button_6";
            this.Button_6.Size = new System.Drawing.Size(64, 55);
            this.Button_6.TabIndex = 188;
            this.Button_6.Tag = "6";
            this.Button_6.Text = "6";
            this.Button_6.UseMnemonic = false;
            this.Button_6.UseVisualStyleBackColor = false;
            this.Button_6.Click += new System.EventHandler(this.KeysHandler);
            // 
            // Button_5
            // 
            this.Button_5.BackColor = System.Drawing.Color.SteelBlue;
            this.Button_5.FlatAppearance.BorderSize = 0;
            this.Button_5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_5.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Button_5.ForeColor = System.Drawing.Color.White;
            this.Button_5.Location = new System.Drawing.Point(78, 121);
            this.Button_5.Name = "Button_5";
            this.Button_5.Size = new System.Drawing.Size(64, 55);
            this.Button_5.TabIndex = 187;
            this.Button_5.Tag = "5";
            this.Button_5.Text = "5";
            this.Button_5.UseVisualStyleBackColor = false;
            this.Button_5.Click += new System.EventHandler(this.KeysHandler);
            // 
            // Button_4
            // 
            this.Button_4.BackColor = System.Drawing.Color.SteelBlue;
            this.Button_4.FlatAppearance.BorderSize = 0;
            this.Button_4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_4.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Button_4.ForeColor = System.Drawing.Color.White;
            this.Button_4.Location = new System.Drawing.Point(4, 121);
            this.Button_4.Name = "Button_4";
            this.Button_4.Size = new System.Drawing.Size(65, 55);
            this.Button_4.TabIndex = 186;
            this.Button_4.Tag = "4";
            this.Button_4.Text = "4";
            this.Button_4.UseVisualStyleBackColor = false;
            this.Button_4.Click += new System.EventHandler(this.KeysHandler);
            // 
            // Button_3
            // 
            this.Button_3.BackColor = System.Drawing.Color.SteelBlue;
            this.Button_3.FlatAppearance.BorderSize = 0;
            this.Button_3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_3.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Button_3.ForeColor = System.Drawing.Color.White;
            this.Button_3.Location = new System.Drawing.Point(150, 179);
            this.Button_3.Name = "Button_3";
            this.Button_3.Size = new System.Drawing.Size(64, 55);
            this.Button_3.TabIndex = 185;
            this.Button_3.Tag = "3";
            this.Button_3.Text = "3";
            this.Button_3.UseVisualStyleBackColor = false;
            this.Button_3.Click += new System.EventHandler(this.KeysHandler);
            // 
            // Button_2
            // 
            this.Button_2.BackColor = System.Drawing.Color.SteelBlue;
            this.Button_2.FlatAppearance.BorderSize = 0;
            this.Button_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Button_2.ForeColor = System.Drawing.Color.White;
            this.Button_2.Location = new System.Drawing.Point(78, 179);
            this.Button_2.Name = "Button_2";
            this.Button_2.Size = new System.Drawing.Size(64, 55);
            this.Button_2.TabIndex = 184;
            this.Button_2.Tag = "2";
            this.Button_2.Text = "2";
            this.Button_2.UseVisualStyleBackColor = false;
            this.Button_2.Click += new System.EventHandler(this.KeysHandler);
            // 
            // Button_1
            // 
            this.Button_1.BackColor = System.Drawing.Color.SteelBlue;
            this.Button_1.FlatAppearance.BorderSize = 0;
            this.Button_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Button_1.ForeColor = System.Drawing.Color.White;
            this.Button_1.Location = new System.Drawing.Point(4, 179);
            this.Button_1.Name = "Button_1";
            this.Button_1.Size = new System.Drawing.Size(65, 55);
            this.Button_1.TabIndex = 183;
            this.Button_1.Tag = "1";
            this.Button_1.Text = "1";
            this.Button_1.UseVisualStyleBackColor = false;
            this.Button_1.Click += new System.EventHandler(this.KeysHandler);
            // 
            // CancelButton
            // 
            this.CancelButton.BackColor = System.Drawing.Color.Red;
            this.CancelButton.FlatAppearance.BorderSize = 0;
            this.CancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CancelButton.ForeColor = System.Drawing.Color.White;
            this.CancelButton.Location = new System.Drawing.Point(112, 296);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(102, 55);
            this.CancelButton.TabIndex = 197;
            this.CancelButton.Tag = "{CANCEL}";
            this.CancelButton.Text = "*";
            this.CancelButton.UseVisualStyleBackColor = false;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.BackColor = System.Drawing.Color.SeaGreen;
            this.ConfirmButton.FlatAppearance.BorderSize = 0;
            this.ConfirmButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConfirmButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ConfirmButton.ForeColor = System.Drawing.Color.White;
            this.ConfirmButton.Location = new System.Drawing.Point(4, 296);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(101, 55);
            this.ConfirmButton.TabIndex = 196;
            this.ConfirmButton.Tag = "{ACCEPT}";
            this.ConfirmButton.Text = "*";
            this.ConfirmButton.UseVisualStyleBackColor = false;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // CustomNumericInputboxKeyboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.ConfirmButton);
            this.Controls.Add(this.InformationLabel);
            this.Controls.Add(this.Button_Delete);
            this.Controls.Add(this.NumericInputBoxTexbox);
            this.Controls.Add(this.Button_0);
            this.Controls.Add(this.Button_9);
            this.Controls.Add(this.Button_8);
            this.Controls.Add(this.Button_7);
            this.Controls.Add(this.Button_6);
            this.Controls.Add(this.Button_5);
            this.Controls.Add(this.Button_4);
            this.Controls.Add(this.Button_3);
            this.Controls.Add(this.Button_2);
            this.Controls.Add(this.Button_1);
            this.Name = "CustomNumericInputboxKeyboard";
            this.Size = new System.Drawing.Size(225, 419);
            this.ResumeLayout(false);

        }

        #endregion
        private Label InformationLabel;
        private Button Button_Delete;
        private CustomTextBox NumericInputBoxTexbox;
        private Button Button_0;
        private Button Button_9;
        private Button Button_8;
        private Button Button_7;
        private Button Button_6;
        private Button Button_5;
        private Button Button_4;
        private Button Button_3;
        private Button Button_2;
        private Button Button_1;
        private Button CancelButton;
        private Button ConfirmButton;
    }
}
