using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Permaquim.Depositary.UI.Desktop.Global.Enumerations;

namespace Permaquim.Depositary.UI.Desktop.Controllers
{
    internal static class FormsController
    {
        private static List<Form> _formList = new();
        public static MainForm MainFormInstance { get; set; }

        private static Form _activeForm = null;

        /// <summary>
        /// Hides 'instance' and shows 'childForm'
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="childForm"></param>
        /// <param name="device"></param>
        public static void OpenChildForm(Form instance, Form childForm,
       Permaquim.Depositary.UI.Desktop.Components.CounterDevice device)
        {
            HideInstance(instance);
            OpenChildForm(childForm, device);
            MainFormInstance.BreadCrumbText =
                 MultilanguangeController.GetText(childForm.Name);
            MainFormInstance.SetInformationMessage(InformationTypeEnum.None, string.Empty);
        }
        public static void OpenChildForm(Form childForm,
        Permaquim.Depositary.UI.Desktop.Components.CounterDevice device)
        {

            var refForm = _formList.FirstOrDefault(s => s.Name.Equals(childForm.Name));

            if (refForm != null)
            {
                childForm = refForm;
            }
            else
            {
                _formList.Add(childForm);

                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Dock = DockStyle.None;
                childForm.Width = MainFormInstance.MainPanel.Width;
                childForm.Height = MainFormInstance.MainPanel.Height;
                childForm.Location = new Point(MainFormInstance.MainPanel.Left, MainFormInstance.MainPanel.Top);
                MainFormInstance.MainPanel.Controls.Add(childForm);
                MainFormInstance.MainPanel.Tag = childForm;
                childForm.BringToFront();
                childForm.StartPosition = FormStartPosition.Manual;

                childForm.Tag = device;
                MainFormInstance.BreadCrumbText =
                    MultilanguangeController.GetText(childForm.Name);
            }
            childForm.Show();

            MainFormInstance.SetInformationMessage(InformationTypeEnum.None,string.Empty);

            childForm.Location = new Point()
            {
                X = MainFormInstance.MainPanel.Width / 2 - childForm.Width / 2,
                Y = MainFormInstance.MainPanel.Height / 2 - childForm.Height / 2
            };
        }

        public static void HideInstance(Form instance)
        {
            MainFormInstance.SetInformationMessage(InformationTypeEnum.None,string.Empty);
            instance.Hide();
        }
        public static void LogOff()
        {
            foreach (var item in _formList)
            {
                if (item.GetType().BaseType.FullName.Equals("System.Windows.Forms.Form"))
                {
                    item.Close();
                }
            }
            _formList.Clear();
            MainFormInstance.BreadCrumbText =
                 MultilanguangeController.GetText(MainFormInstance.Name);
            MultilanguangeController.ResetLanguage();

            MainFormInstance.SetInformationMessage(InformationTypeEnum.None,string.Empty);
        }

        public static void SetInformationMessage(InformationTypeEnum type, string message)
        {
            MainFormInstance.SetInformationMessage(type, message);
        }
    }
}
