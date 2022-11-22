using Permaquim.Depositary.UI.Desktop.Controllers;
using Permaquim.Depositary.UI.Desktop.Controls;
using Permaquim.Depositary.UI.Desktop.Global;
using static Permaquim.Depositary.UI.Desktop.Global.Enumerations;

namespace Permaquim.Depositary.UI.Desktop.Forms
{
    public partial class InputBoxForm : Form
    {
        private const string ENTER = "{ENTER}";
        private const string ACCEPT = "{ACCEPT}";
        private const string CANCEL = "{CANCEL}";
        public InputBoxForm()
        {
            InitializeComponent();
            CustomInputBoxKeyboard.InputTexboxPlaceholder = MultilanguangeController.GetText(MultiLanguageEnum.PLACEHOLDER_TEXTBOX_ALFANUMERICO);
            CustomInputBoxKeyboard.SetButtonsColor(StyleController.GetColor(Enumerations.ColorNameEnum.FuentePrincipal));
            CustomInputBoxKeyboard.SetMaxLenght(50);
            CustomInputBoxKeyboard.KeyboardEvent += CustomInputBoxKeyboard_KeyboardEvent;
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
        public string ReturnTextValue
        {
            get { return CustomInputBoxKeyboard.ReturnTextValue; }
            set { CustomInputBoxKeyboard.ReturnTextValue = value; }
        }
        public string InputTexboxPlaceholder
        {
            get { return CustomInputBoxKeyboard.InputTexboxPlaceholder; }
            set { CustomInputBoxKeyboard.InputTexboxPlaceholder = value; }
        }
        private void CustomInputBoxKeyboard_KeyboardEvent(object sender, InputboxKeyboardEventArgs args)
        {
            TimeOutController.Reset();

            if (args.KeyPressed.Equals(ENTER) || args.KeyPressed.Equals(ACCEPT))
            {
                if (args.InputTex.Trim().Equals(string.Empty))
                {
                    CustomInputBoxKeyboard.SetLoginError(MultilanguangeController.
                        GetText(MultiLanguageEnum.ERROR_FALTA_DATO));
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
