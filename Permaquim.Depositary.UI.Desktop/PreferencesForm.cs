using Permaquim.Depositary.UI.Desktop.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Permaquim.Depositary.UI.Desktop
{
    public partial class PreferencesForm : Form
    {
        private System.Windows.Forms.Timer _pollingTimer = new System.Windows.Forms.Timer();
        public PreferencesForm()
        {
            InitializeComponent();
            CenterPanel();
            LoadLanguages();
            TimeOutController.Reset();
            _pollingTimer = new System.Windows.Forms.Timer()
            {
                Interval = DeviceController.GetPollingInterval(),
                Enabled = true
            };
            _pollingTimer.Tick += PollingTimer_Tick;
        }
        private void PollingTimer_Tick(object? sender, EventArgs e)
        {
            if (TimeOutController.IsTimeOut())
            {
                _pollingTimer.Enabled = false;
                DatabaseController.LogOff(true);
                AppController.HideInstance(this);
            }
        }
        private void CenterPanel()
        {

            MainPanel.Location = new Point()
            {
                X = this.Width / 2 - MainPanel.Width / 2,
                Y = this.Height / 2 - MainPanel.Height / 2
            };
        }

        private void LoadLanguages()
        {
            LanguageComboBox.Items.Clear();
            LanguageComboBox.DisplayMember = "Nombre";
            LanguageComboBox.ValueMember = "Id";
            LanguageComboBox.DataSource = DatabaseController.GetLanguageList();

            LanguageComboBox.SelectedIndex = (int)DatabaseController.CurrentUser.LenguajeId.Id;


        }

        private void LanguageComboBox_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            DatabaseController.SetLanguageId(LanguageComboBox.SelectedIndex);
        }
    }
}
