using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permaquim.Depositary.UI.Desktop.Controllers
{
    internal static class AppController
    {
        private static List<Form> _formList = new List<Form>();
        public static MainForm MainFormInstance { get; set; }

        private static Form _activeForm = null;


        public static void OpenChildForm(Form childForm,
            Permaquim.Depositary.UI.Desktop.Components.Device device)
        {
            if (_activeForm != null) _activeForm.Close();
            _activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.None;
            MainFormInstance.MainPanel.Controls.Add(childForm);
            MainFormInstance.MainPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.StartPosition = FormStartPosition.Manual;

            childForm.Tag = device;

            childForm.Show();

            _formList.Add(childForm);   

            childForm.Location = new Point()
            {
                X = MainFormInstance.MainPanel.Width / 2 - childForm.Width / 2,
                Y = MainFormInstance.MainPanel.Height / 2 - childForm.Height / 2
            };
        }

        public static void Back(Form form)
        {
 
            _activeForm = _formList[_formList.IndexOf(form) -1];

            _activeForm.TopLevel = false;
            _activeForm.FormBorderStyle = FormBorderStyle.None;
            _activeForm.Dock = DockStyle.None;
            MainFormInstance.MainPanel.Controls.Add(_activeForm);
            MainFormInstance.MainPanel.Tag = _activeForm;
            _activeForm.BringToFront();
            _activeForm.StartPosition = FormStartPosition.Manual;
            _activeForm.Show();

            _formList.Remove(form);
            _formList.LastOrDefault().Show();
       

        }
    }
}
