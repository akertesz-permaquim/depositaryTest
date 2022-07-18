﻿using Permaquim.Depositary.UI.Desktop.Controllers;
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
    public partial class InputBoxForm : Form
    {
        private const string ENTER = "{ENTER}";
        private const string ACCEPT = "{ACCEPT}";
        private const string CANCEL = "{CANCEL}";
        public InputBoxForm()
        {
            InitializeComponent();
            CustomInputBoxKeyboard.InputTexboxPlaceholder = MultilanguangeController.GetText(MultiLanguageEnum.ALPHANUMERIC_TEXTBOX_PLACEHOLDER);
            CustomInputBoxKeyboard.SetButtonsColor(StyleController.GetColor(Enumerations.ColorNameEnum.FuentePrincipal));

            CustomInputBoxKeyboard.KeyboardEvent += CustomInputBoxKeyboard_KeyboardEvent;
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
                        GetText(MultiLanguageEnum.FALTA_USUARIO_PASSWORD));
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
