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
        private const string FORM = "System.Windows.Forms.Form";
        private static List<Form> _formList = new();
        public static MainForm MainFormInstance { get; set; }

        public static Form ActiveForm { get; set; }

        /// <summary>
        /// Hides 'instance', shows 'childForm' and appends breadCrumbText
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="childForm"></param>
        /// <param name="device"></param>
        public static void OpenChildForm(Form instance, Form childForm,
        Permaquim.Depositary.UI.Desktop.Components.CounterDevice device,string breadCrumbText)
        {
            HideInstance(instance);
            OpenChildForm(childForm, device);
            MainFormInstance.BreadCrumbText =
                 MultilanguangeController.GetText(childForm.Name) + breadCrumbText;
            MainFormInstance.SetInformationMessage(InformationTypeEnum.None, string.Empty);
        }


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
        /// <summary>
        /// Loads child form
        /// </summary>
        /// <param name="childForm"></param>
        /// <param name="device"></param>
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

            childForm.Location = new Point()
            {
                X = MainFormInstance.MainPanel.Width / 2 - childForm.Width / 2,
                Y = MainFormInstance.MainPanel.Height / 2 - childForm.Height / 2
            };

            childForm.Show();
            ActiveForm = childForm;
            MainFormInstance.SetInformationMessage(InformationTypeEnum.None, string.Empty);
        }

        public static void AppendtoBreadcrumbText(string textToAppend)
        {
            MainFormInstance.BreadCrumbText += textToAppend;
        }
        public static int ActiveFormscount
        {
            get
            {
                return _formList.Count;
            }
        }
        public static void HideInstance(Form instance)
        {
            instance.Hide();
        }
        public static void LogOff()
        {
            foreach (var item in _formList)
            {
                if (item.GetType().BaseType.FullName.Equals(FORM))
                {
                    item.Close();
                }
            }
            _formList.Clear();
            MainFormInstance.BreadCrumbText =
                 MultilanguangeController.GetText(MainFormInstance.Name);
            MultilanguangeController.ResetLanguage();

            MainFormInstance.SetInformationMessage(InformationTypeEnum.None,string.Empty);

            MainFormInstance.LoadPresentation();


        }

        public static void SetInformationMessage(InformationTypeEnum type, string message)
        {
            MainFormInstance.SetInformationMessage(type, message);
        }
    }
}
