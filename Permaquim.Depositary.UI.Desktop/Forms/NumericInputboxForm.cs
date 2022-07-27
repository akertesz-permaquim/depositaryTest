using Permaquim.Depositary.UI.Desktop.Controllers;
using Permaquim.Depositary.UI.Desktop.Controls;
using Permaquim.Depositary.UI.Desktop.Global;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Permaquim.Depositary.UI.Desktop.Global.Enumerations;

namespace Permaquim.Depositary.UI.Desktop.Forms
{
    public partial class CustomNumericInputboxKeyboard : Form
    {
        private const string ENTER = "{ENTER}";
        private const string ACCEPT = "{ACCEPT}";
        private const string CANCEL = "{CANCEL}";
        public CustomNumericInputboxKeyboard()
        {
            InitializeComponent();
            NumericInputBoxControl.NumericInputBoxPlaceholder = MultilanguangeController.GetText(MultiLanguageEnum.NUMERIC_TEXTBOX_PLACEHOLDER);


            NumericInputBoxControl.SetButtonsColor(StyleController.GetColor(Enumerations.ColorNameEnum.FuentePrincipal));

            NumericInputBoxControl.KeyboardEvent += NumericInputBoxControl_KeyboardEvent;
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams CP = base.CreateParams;
                CP.ExStyle = CP.ExStyle | 0x02000000; // WS_EX_COMPOSITED
                return CP;
            }
        }
        private void NumericInputBoxControl_MouseClick(object sender, MouseEventArgs e)
        {

        }

        public string NumericInputBoxPlaceholder
        {
            get { return NumericInputBoxControl.NumericInputBoxPlaceholder; }
            set { NumericInputBoxControl.NumericInputBoxPlaceholder = value; }
        }
        public string ReturnValue
        {
            get { return NumericInputBoxControl.ReturnValue; }
        }
        private void NumericInputBoxControl_KeyboardEvent(object sender, NumericInputBoxKeyboardEventArgs args)
        {
            TimeOutController.Reset();

            if (args.KeyPressed.Equals(ENTER) || args.KeyPressed.Equals(ACCEPT))
            {
                if (args.NumericInputboxText.Trim().Equals(string.Empty) )
                {
                    NumericInputBoxControl.SetLoginError(MultilanguangeController.GetText(MultiLanguageEnum.FALTA_USUARIO_PASSWORD));
                }
                else
                {
                    this.DialogResult = DialogResult.OK;
                }
            }
            if (args.KeyPressed.Equals(CANCEL))
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }
    }
}
