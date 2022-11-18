using Permaquim.Depositary.UI.Desktop.Controllers;
using Permaquim.Depositary.UI.Desktop.Global;
using static Permaquim.Depositary.UI.Desktop.Global.Enumerations;

namespace Permaquim.Depositary.UI.Desktop.Controls
{
    public partial class CustomInputBoxKeyboar : UserControl
    {
        private Color _mainColor;

        private bool _shift = false;
        public delegate void KeyboardDataReceived(object sender, InputboxKeyboardEventArgs args);

        public event KeyboardDataReceived KeyboardEvent;

        private Color _buttonsBackgroundColor;
        private CustomTextBox _activeTextbox;
        public CustomInputBoxKeyboar()
        {
            InitializeComponent();
            _activeTextbox = InputTexbox;
            _activeTextbox.Focus();
            if (this.ParentForm != null)
                this.ParentForm.AcceptButton = this.Button_Enter;
            LoadStyles();
        }
        private void LoadStyles()
        {
            ConfirmButton.Text = MultilanguangeController.GetText(MultiLanguageEnum.BOTON_ACEPTAR_OPERACION);
            ConfirmButton.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.BotonAceptar);
            ConfirmButton.ForeColor = StyleController.GetColor(Enumerations.ColorNameEnum.FuenteContraste);

            CancelButton.Text = MultilanguangeController.GetText(MultiLanguageEnum.BOTON_CANCELAR_OPERACION);
            CancelButton.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.BotonCancelar);
            CancelButton.ForeColor = StyleController.GetColor(Enumerations.ColorNameEnum.FuenteContraste);


        }
        public void ClearCredentials()
        {
            InputTexbox.Texts = String.Empty;
        }
        public void SetLoginError(string message)
        {
            InformationLabel.Text = message;
            InformationLabel.ForeColor = Color.Red;
            InputTexbox.BorderColor = Color.Red;
        }
        public string ReturnTextValue
        {
            get { return InputTexbox.Texts; }
            set { InputTexbox.Texts = value; }
        }
        public string InputTexboxPlaceholder
        {
            get { return InputTexbox.PlaceholderText; }
            set { InputTexbox.PlaceholderText = value; }
        }
        public void SetMaxLenght(int number)
        {
            InputTexbox.MaxLength = number;
        }

        public void SetButtonsColor(Color color)
        {
            _mainColor = color;
            foreach (var item in this.Controls)
            {
                if (item.GetType().Name.Equals("Button"))
                {
                    string buttonTag = ((Button)item).Tag.ToString();

                    if (!(buttonTag.Equals("{ACCEPT}") || buttonTag.Equals("{CANCEL}")))
                        ((Button)item).BackColor = _mainColor;
                }
            }

            InputTexbox.ForeColor = _mainColor;
        }

        private void KeysHandler(object sender, EventArgs e)
        {
            _activeTextbox.Focus();


            if (_activeTextbox.Texts.Length >= _activeTextbox.MaxLength)
                return;

            if (((Button)sender).Tag.ToString().Equals("{ENTER}"))
            {
                //Raises event for counter
                if (KeyboardEvent != null)
                {

                    InputboxKeyboardEventArgs args = new()
                    {
                        KeyPressed = "{ENTER}",
                        InputTex = InputTexbox.Texts
                    };

                    // Raise the event.
                    KeyboardEvent(this, args);
                }
                return;
            }
            if (((Button)sender).Tag.ToString().Equals("{BACKSPACE}"))
            {
                if (InputTexbox.Texts.Length > 0)
                {
                    InputTexbox.Texts = InputTexbox.Texts.Substring(0, InputTexbox.Texts.Length - 1);
                    InputTexbox.SelectionStart = InputTexbox.Texts.Length;
                }
            }
            else
            {
                //SendKeys.SendWait(((Button)sender).Tag.ToString());
                _activeTextbox.Texts += ((Button)sender).Tag.ToString();
                _activeTextbox.SelectionStart = _activeTextbox.Texts.Length;
                _activeTextbox.SelectionLength = 0;

                //Raises event for counter
                if (KeyboardEvent != null)
                {

                    InputboxKeyboardEventArgs args = new()
                    {
                        KeyPressed = ((Button)sender).Tag.ToString(),
                        InputTex = InputTexbox.Texts
                    };

                    // Raise the event.
                    KeyboardEvent(this, args);
                }
            }
        }
        private void Delete(object sender, EventArgs e)
        {
            InputTexbox.Texts = String.Empty;
            InputTexbox.BorderColor = _mainColor;
            InformationLabel.Text = String.Empty;
            InformationLabel.ForeColor = _mainColor;
        }

        private void PasswordTexbox_Enter(object sender, EventArgs e)
        {
            _activeTextbox = (CustomTextBox)sender;
        }

        private void UsernameTextBox_Enter(object sender, EventArgs e)
        {
            _activeTextbox = (CustomTextBox)sender;
        }

        private void PasswordTexbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                //Raises event for counter
                if (KeyboardEvent != null)
                {

                    InputboxKeyboardEventArgs args = new()
                    {
                        KeyPressed = "{ENTER}",
                        InputTex = InputTexbox.Texts,

                    };

                    // Raise the event.
                    KeyboardEvent(this, args);
                }
            }
            else
            {
                KeyboardEvent(this, new InputboxKeyboardEventArgs());
            }
        }

        private void Button_Shift_Click(object sender, EventArgs e)
        {
            _shift = !_shift;
            ShiftUnshift();
        }
        private void ShiftUnshift()
        {
            foreach (var item in this.Controls)
            {
                if (item.GetType() == typeof(Button))
                {
                    if (!((Button)item).Tag.ToString().StartsWith("{"))
                    {

                        if (_shift)
                        {
                            ((Button)item).Tag = ((Button)item).Tag.ToString().ToUpper();
                            ((Button)item).Text = ((Button)item).Text.ToString().ToUpper();
                            Button_0.Tag = "="; Button_0.Text = Button_0.Tag.ToString();
                            Button_1.Tag = "¬"; Button_1.Text = Button_1.Tag.ToString();
                            Button_2.Tag = System.Convert.ToChar(34); Button_2.Text = Button_2.Tag.ToString();
                            Button_3.Tag = "#"; Button_3.Text = Button_3.Tag.ToString();
                            Button_4.Tag = "$"; Button_4.Text = Button_4.Tag.ToString();
                            Button_5.Tag = "%"; Button_5.Text = Button_5.Tag.ToString();
                            Button_6.Tag = "&"; Button_6.Text = Button_6.Tag.ToString();
                            Button_7.Tag = "/"; Button_7.Text = Button_7.Tag.ToString();
                            Button_8.Tag = "("; Button_8.Text = Button_8.Tag.ToString();
                            Button_SpecialCharacter_1.Tag = "~"; Button_SpecialCharacter_1.Text = Button_SpecialCharacter_1.Tag.ToString();
                            Button_9.Tag = ")"; Button_9.Text = Button_9.Tag.ToString();
                            Button_SpecialCharacter_2.Tag = "!"; Button_SpecialCharacter_2.Text = Button_SpecialCharacter_2.Tag.ToString();
                            Button_SpecialCharacter_3.Tag = "|"; Button_SpecialCharacter_3.Text = Button_SpecialCharacter_3.Tag.ToString();
                            Button_SpecialCharacter_4.Tag = "?"; Button_SpecialCharacter_4.Text = Button_SpecialCharacter_4.Tag.ToString();
                            Button_SpecialCharacter_5.Tag = "["; Button_SpecialCharacter_5.Text = Button_SpecialCharacter_5.Tag.ToString();
                            Button_SpecialCharacter_6.Tag = "]"; Button_SpecialCharacter_6.Text = Button_SpecialCharacter_6.Tag.ToString();
                            Button_Dot.Tag = ":"; Button_Dot.Text = Button_Dot.Tag.ToString();
                            Button_Underscore.Tag = "-"; Button_Underscore.Text = Button_Underscore.Tag.ToString();
                            Button_Star.Tag = "*"; Button_Star.Text = Button_Star.Tag.ToString();
                        }
                        else
                        {
                            ((Button)item).Tag = ((Button)item).Tag.ToString().ToLower();
                            ((Button)item).Text = ((Button)item).Text.ToString().ToLower();
                            Button_0.Tag = "0"; Button_0.Text = Button_0.Tag.ToString();
                            Button_1.Tag = "1"; Button_1.Text = Button_1.Tag.ToString();
                            Button_2.Tag = "2"; Button_2.Text = Button_2.Tag.ToString();
                            Button_3.Tag = "3"; Button_3.Text = Button_3.Tag.ToString();
                            Button_4.Tag = "4"; Button_4.Text = Button_4.Tag.ToString();
                            Button_5.Tag = "5"; Button_5.Text = Button_5.Tag.ToString();
                            Button_6.Tag = "6"; Button_6.Text = Button_6.Tag.ToString();
                            Button_7.Tag = "7"; Button_7.Text = Button_7.Tag.ToString();
                            Button_8.Tag = "8"; Button_8.Text = Button_8.Tag.ToString();
                            Button_9.Tag = "9"; Button_9.Text = Button_9.Tag.ToString();
                            Button_SpecialCharacter_1.Tag = @"\"; Button_SpecialCharacter_1.Text = Button_SpecialCharacter_1.Tag.ToString();
                            Button_SpecialCharacter_2.Tag = "¡"; Button_SpecialCharacter_2.Text = Button_SpecialCharacter_2.Tag.ToString();
                            Button_SpecialCharacter_3.Tag = "@"; Button_SpecialCharacter_3.Text = Button_SpecialCharacter_3.Tag.ToString();
                            Button_SpecialCharacter_4.Tag = "¿"; Button_SpecialCharacter_4.Text = Button_SpecialCharacter_4.Tag.ToString();
                            Button_SpecialCharacter_5.Tag = "{"; Button_SpecialCharacter_5.Text = Button_SpecialCharacter_5.Tag.ToString();
                            Button_SpecialCharacter_6.Tag = "}"; Button_SpecialCharacter_6.Text = Button_SpecialCharacter_6.Tag.ToString();
                            Button_Dot.Tag = "."; Button_Dot.Text = Button_Dot.Tag.ToString();
                            Button_Underscore.Tag = "_"; Button_Underscore.Text = Button_Underscore.Tag.ToString();
                            Button_Star.Tag = "+"; Button_Star.Text = Button_Star.Tag.ToString();
                        }
                    }
                }
            }
        }
        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            //Raises event for counter
            if (KeyboardEvent != null)
            {

                InputboxKeyboardEventArgs args = new()
                {
                    KeyPressed = "{ACCEPT}",
                     InputTex = InputTexbox.Texts
                };

                // Raise the event.
                KeyboardEvent(this, args);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            //Raises event for counter
            if (KeyboardEvent != null)
            {

                InputboxKeyboardEventArgs args = new()
                {
                    KeyPressed = "{CANCEL}",
                     InputTex = InputTexbox.Texts
                };

                // Raise the event.
                KeyboardEvent(this, args);
            }
        }
    }
    public class InputboxKeyboardEventArgs : EventArgs
    {
        // The Key pressed
        public string KeyPressed = string.Empty;

        // The UserText
        public string InputTex = string.Empty;

    }
}
