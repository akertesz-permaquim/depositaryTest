﻿namespace Permaquim.Depositary.UI.Desktop
{
    partial class CurrencySelectorForm
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
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.MainPanel.BackColor = System.Drawing.Color.Transparent;
            this.MainPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.MainPanel.Location = new System.Drawing.Point(250, 8);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(300, 584);
            this.MainPanel.TabIndex = 1;
            // 
            // CurrencySelectorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.ControlBox = false;
            this.Controls.Add(this.MainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CurrencySelectorForm";
            this.Load += new System.EventHandler(this.CurrencySelectorForm_Load);
            this.VisibleChanged += new System.EventHandler(this.CurrencySelectorForm_VisibleChanged);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CurrencySelectorForm_MouseClick);
            this.ResumeLayout(false);

        }

        #endregion

        private FlowLayoutPanel MainPanel;
    }
}