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
            this.LanguageComboBox = new Permaquim.Depositary.UI.Desktop.CustomComboBox();
            this.Languagelabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LanguageComboBox
            // 
            this.LanguageComboBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.LanguageComboBox.BorderColor = System.Drawing.Color.SteelBlue;
            this.LanguageComboBox.BorderSize = 1;
            this.LanguageComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.LanguageComboBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LanguageComboBox.ForeColor = System.Drawing.Color.DimGray;
            this.LanguageComboBox.IconColor = System.Drawing.Color.RoyalBlue;
            this.LanguageComboBox.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(228)))), ((int)(((byte)(245)))));
            this.LanguageComboBox.ListTextColor = System.Drawing.Color.DimGray;
            this.LanguageComboBox.Location = new System.Drawing.Point(176, 32);
            this.LanguageComboBox.MinimumSize = new System.Drawing.Size(200, 30);
            this.LanguageComboBox.Name = "LanguageComboBox";
            this.LanguageComboBox.Padding = new System.Windows.Forms.Padding(1);
            this.LanguageComboBox.Size = new System.Drawing.Size(200, 30);
            this.LanguageComboBox.TabIndex = 0;
            this.LanguageComboBox.Texts = "";
            this.LanguageComboBox.OnSelectedIndexChanged += new System.EventHandler(this.LanguageComboBox_OnSelectedIndexChanged);
            // 
            // Languagelabel
            // 
            this.Languagelabel.AutoSize = true;
            this.Languagelabel.Location = new System.Drawing.Point(40, 40);
            this.Languagelabel.Name = "Languagelabel";
            this.Languagelabel.Size = new System.Drawing.Size(61, 15);
            this.Languagelabel.TabIndex = 1;
            this.Languagelabel.Text = "Lenguaje: ";
            // 
            // PreferencesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Languagelabel);
            this.Controls.Add(this.LanguageComboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PreferencesForm";
            this.Text = "PreferencesForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel MainPanel;
        private CustomComboBox LanguageComboBox;
        private Label Languagelabel;
    }
}