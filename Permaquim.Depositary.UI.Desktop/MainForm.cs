using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Permaquim.Depositary.UI.Desktop
{
    public partial class MainForm : System.Windows.Forms.Form
    {
        private const string LOGO_IMAGE_FILE = @"\Resources\Images\Logo.png";
        private System.Windows.Forms.Timer _timer = new System.Windows.Forms.Timer();
        public MainForm()
        {
            InitializeComponent();
            // StartPosition was set to FormStartPosition.Manual in the properties window.
            Rectangle screen = Screen.PrimaryScreen.WorkingArea;
            this.Location = new Point(0,0);
            this.Size = new Size(screen.Width, screen.Height);
            _timer = new System.Windows.Forms.Timer()
            {
                Interval = 1000,
                Enabled = true
            };
            _timer.Tick += _timer_Tick;

            LoadLogo();
            OpenChildForm(new KeyboardInputForm());
            SetOwnerData();
        }

        private void _timer_Tick(object? sender, EventArgs e)
        {
            DateTimeLabel.Text = DateTime.Now.ToString("dd MM yyyy - HH mm ss");
        }

        private void SetOwnerData()
        {
            OwnerDataLabel.Text = "Permaquim :.: Depositario. Versión 0.1";
        }
        private void MainPanel_MouseClick(object sender, MouseEventArgs e)
        {
            //OpenChildForm(new KeyboardInputForm());
            //OpenChildForm(new OperationForm());

        }


        private Form _activeForm = null;
        private void OpenChildForm(Form childForm)
        {
            if (_activeForm != null) _activeForm.Close();
            _activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.None;
            MainPanel.Controls.Add(childForm);
            MainPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.StartPosition= FormStartPosition.Manual;
            childForm.Show();

            childForm.Location = new Point()
            {
                X = MainPanel.Width / 2 - childForm.Width / 2,
                Y = MainPanel.Height / 2 - childForm.Height /2
            };

       }

        private void LoadLogo()
        {
            LogoPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            var appPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            LogoPictureBox.Load(appPath + LOGO_IMAGE_FILE);
        }
    }
}
