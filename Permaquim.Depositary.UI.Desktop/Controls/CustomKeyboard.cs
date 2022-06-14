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
    public partial class CustomKeyboard : UserControl
    {
        private Color _mainColor;
        public delegate void KeyboardDataReceived(object sender, KeyboardEventArgs args);

        public event KeyboardDataReceived KeyboardEvent;

        private Color _buttonsBackgroundColor;
        private CustomTextBox _activeTextbox ;
        public CustomKeyboard()
        {
            InitializeComponent();
            _activeTextbox = UsernameTextBox;
            _activeTextbox.Focus();
            if(this.ParentForm !=null)
                this.ParentForm.AcceptButton = this.Button_Enter;
        }
        public void SetLoginError(string message)
        {
            InformationLabel.Text = message;
            InformationLabel.ForeColor = Color.Red;
            UsernameTextBox.BorderColor = Color.Red;
            PasswordTexbox.BorderColor = Color.Red;
        }

        public string UserTextboxPlaceholder
        {
            get { return UsernameTextBox.PlaceholderText; }
            set { UsernameTextBox.PlaceholderText = value; }
        }

        public string PasswordTextBoxPlaceholder
        {
            get { return PasswordTexbox.PlaceholderText; }
            set { PasswordTexbox.PlaceholderText = value; }
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
        }

        private void KeysHandler(object sender, EventArgs e)
        {
            _activeTextbox.Focus();
            
            SendKeys.Send(((CustomButton)sender).Tag.ToString());

            //Raises event for counter
            if (KeyboardEvent != null)
            {

                KeyboardEventArgs args = new()
                {
                    KeyPressed = ((CustomButton)sender).Tag.ToString(),
                    UserText = UsernameTextBox.Texts,
                    PasswordText = PasswordTexbox.Texts
                };

                // Raise the event.
                KeyboardEvent(this, args);
            }
        }
        private void Delete(object sender, EventArgs e)
        {
            UsernameTextBox.Texts = String.Empty;
            PasswordTexbox.Texts = String.Empty;
            UsernameTextBox.BorderColor = _mainColor;
            PasswordTexbox.BorderColor = _mainColor;
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

                    KeyboardEventArgs args = new()
                    {
                        KeyPressed = "{ENTER}",
                        UserText = UsernameTextBox.Texts,
                        PasswordText = PasswordTexbox.Texts
                    };

                    // Raise the event.
                    KeyboardEvent(this, args);
                }
            }
        }

        private void UsernameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                PasswordTexbox.Focus();
            }
        }
    }
    public class KeyboardEventArgs : EventArgs
    {
        // The Key pressed
        public string KeyPressed = string.Empty;

        // The UserText
        public string UserText = string.Empty;

        // The PasswordText
        public string PasswordText = string.Empty;
    }
}
