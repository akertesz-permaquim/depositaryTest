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
}
