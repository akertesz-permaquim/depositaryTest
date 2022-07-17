using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Permaquim.Depositary.UI.Desktop.Controls
{
    public partial class CustomInputboxKeyboard : UserControl
    {
        private Color _mainColor;

        private bool _shift = false;
        public delegate void KeyboardDataReceived(object sender, InputBoxKeyboardEventArgs args);

        public event KeyboardDataReceived KeyboardEvent;

        private Color _buttonsBackgroundColor;
        private CustomTextBox _activeTextbox ;
        public CustomInputboxKeyboard()
        {
            InitializeComponent();
            _activeTextbox.Focus();
            if(this.ParentForm !=null)
                this.ParentForm.AcceptButton = this.Button_Enter;
        }
        public void ClearText()
        {
              InputTexbox.Texts = String.Empty;
        }
        public void SetLoginError(string message)
        {
            InformationLabel.Text = message;
            InformationLabel.ForeColor = Color.Red;
            InputTexbox.BorderColor = Color.Red;
        }


        public string InputTexboxPlaceholder
        {
            get { return InputTexbox.PlaceholderText; }
            set { InputTexbox.PlaceholderText = value; }
        }

        public void SetButtonsColor(Color color)
        {
            _mainColor = color;
            foreach (var item in this.Controls)
            {
               if(item.GetType().Name.Equals("CustomButton"))
                {
                    ((CustomButton)item).BackColor = _mainColor;
                }
            }

            InputTexbox.ForeColor = _mainColor;
        }

        private void KeysHandler(object sender, EventArgs e)
        {
            _activeTextbox.Focus();

            if (((CustomButton)sender).Tag.ToString().Equals("{ENTER}"))
            {
                //Raises event for counter
                if (KeyboardEvent != null)
                {

                    InputBoxKeyboardEventArgs args = new()
                    {
                        KeyPressed = "{ENTER}",
                        InputboxText = InputTexbox.Texts
                    };

                    // Raise the event.
                    KeyboardEvent(this, args);
                }
            }
            else
            {
                //SendKeys.SendWait(((CustomButton)sender).Tag.ToString());
                _activeTextbox.Texts += ((CustomButton)sender).Tag.ToString();
                _activeTextbox.SelectionStart = _activeTextbox.Texts.Length;
                _activeTextbox.SelectionLength = 0;

                //Raises event for counter
                if (KeyboardEvent != null)
                {

                    InputBoxKeyboardEventArgs args = new()
                    {
                        KeyPressed = ((CustomButton)sender).Tag.ToString(),
                        InputboxText = InputTexbox.Texts
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

                    InputBoxKeyboardEventArgs args = new()
                    {
                        KeyPressed = "{ENTER}",
                        InputboxText = InputTexbox.Texts
                    };

                    // Raise the event.
                    KeyboardEvent(this, args);
                }
            }
            else
            {
                KeyboardEvent(this, new InputBoxKeyboardEventArgs());
            }
        }

        private void UsernameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                InputTexbox.Focus();
            }
            KeyboardEvent(this, new InputBoxKeyboardEventArgs());
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
                if (item.GetType() == typeof(CustomButton))
                {
                    if (!((CustomButton)item).Tag.ToString().StartsWith("{"))
                    {

                        if (_shift)
                        {
                            ((CustomButton)item).Tag = ((CustomButton)item).Tag.ToString().ToUpper();
                            ((CustomButton)item).Text = ((CustomButton)item).Text.ToString().ToUpper();
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
                            ((CustomButton)item).Tag = ((CustomButton)item).Tag.ToString().ToLower();
                            ((CustomButton)item).Text = ((CustomButton)item).Text.ToString().ToLower();
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
    }
    public class InputBoxKeyboardEventArgs : EventArgs
    {
        // The Key pressed
        public string KeyPressed = string.Empty;

        // The PasswordText
        public string InputboxText = string.Empty;
    }
}
