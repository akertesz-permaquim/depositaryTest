namespace Permaquim.Depositary.Launcher
{
    partial class Mainform
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mainform));
            this.MainPicturebox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.MainPicturebox)).BeginInit();
            this.SuspendLayout();
            // 
            // MainPicturebox
            // 
            this.MainPicturebox.BackColor = System.Drawing.Color.Transparent;
            this.MainPicturebox.Image = ((System.Drawing.Image)(resources.GetObject("MainPicturebox.Image")));
            this.MainPicturebox.Location = new System.Drawing.Point(8, 20);
            this.MainPicturebox.Name = "MainPicturebox";
            this.MainPicturebox.Size = new System.Drawing.Size(368, 66);
            this.MainPicturebox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.MainPicturebox.TabIndex = 0;
            this.MainPicturebox.TabStop = false;
            // 
            // Mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(387, 103);
            this.Controls.Add(this.MainPicturebox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Mainform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Permaquim";
            this.Load += new System.EventHandler(this.Mainform_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MainPicturebox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox MainPicturebox;
    }
}