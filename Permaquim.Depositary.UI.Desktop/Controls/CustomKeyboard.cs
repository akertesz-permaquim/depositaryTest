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

        public delegate void KeyboardDataReceived(object sender, KeyboardEventArgs args);

        public event KeyboardDataReceived KeyboardEvent;

        private Color _buttonsBackgroundColor;
        private CustomTextBox _activeTextbox;
        public CustomKeyboard()
        {
            InitializeComponent();
            _activeTextbox = UsernameTextBox;
            _activeTextbox.Focus();
        }
        private void Keys(object sender, EventArgs e)
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
        }

        private void PasswordTexbox_Enter(object sender, EventArgs e)
        {
            _activeTextbox = (CustomTextBox)sender;
        }

        private void UsernameTextBox_Enter(object sender, EventArgs e)
        {
            _activeTextbox = (CustomTextBox)sender;
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
