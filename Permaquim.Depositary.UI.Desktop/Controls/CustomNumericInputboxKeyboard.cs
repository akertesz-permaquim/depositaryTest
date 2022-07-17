namespace Permaquim.Depositary.UI.Desktop.Controls
{
    public partial class CustomNumericInputboxKeyboard : UserControl
    {
        private Color _mainColor;

        public delegate void KeyboardDataReceived(object sender, NumericInputBoxKeyboardEventArgs args);

        public event KeyboardDataReceived KeyboardEvent;

        public CustomNumericInputboxKeyboard()
        {
            InitializeComponent();
            NumericInputBoxTexbox.Focus();
            if (this.ParentForm != null)
                this.ParentForm.AcceptButton = this.ConfirmButton;
        }
        public void ClearData()
        {
            NumericInputBoxTexbox.Texts = String.Empty;
        }
        public void SetLoginError(string message)
        {
            InformationLabel.Text = message;
            InformationLabel.ForeColor = Color.Red;
            NumericInputBoxTexbox.BorderColor = Color.Red;
        }

        public string NumericInputBoxPlaceholder
        {
            get { return NumericInputBoxTexbox.PlaceholderText; }
            set { NumericInputBoxTexbox.PlaceholderText = value; }
        }

        public string ReturnValue
        {
            get { return NumericInputBoxTexbox.Texts; }
        }

        public void SetButtonsColor(Color color)
        {
            _mainColor = color;
            foreach (var item in this.Controls)
            {
                if (item.GetType().Name.Equals("CustomButton"))
                {
                    string buttonTag = ((CustomButton)item).Tag.ToString();

                    if (!(buttonTag.Equals("{ACCEPT}") || buttonTag.Equals("{CANCEL}")))
                        ((CustomButton)item).BackColor = _mainColor;
                }
            }
            NumericInputBoxTexbox.ForeColor = _mainColor;
        }

        private void KeysHandler(object sender, EventArgs e)
        {
            NumericInputBoxTexbox.Focus();

            if (((CustomButton)sender).Tag.ToString().Equals("{ENTER}"))
            {
                //Raises event for counter
                if (KeyboardEvent != null)
                {

                    NumericInputBoxKeyboardEventArgs args = new()
                    {
                        KeyPressed = "{ENTER}",
                        NumericInputboxText = NumericInputBoxTexbox.Texts
                    };

                    // Raise the event.
                    KeyboardEvent(this, args);
                }
            }
            else
            {
                //SendKeys.SendWait(((CustomButton)sender).Tag.ToString());
                NumericInputBoxTexbox.Texts += ((CustomButton)sender).Tag.ToString();
                NumericInputBoxTexbox.SelectionStart = NumericInputBoxTexbox.Texts.Length;
                NumericInputBoxTexbox.SelectionLength = 0;

                //Raises event for counter
                if (KeyboardEvent != null)
                {

                    NumericInputBoxKeyboardEventArgs args = new()
                    {
                        KeyPressed = ((CustomButton)sender).Tag.ToString(),
                        NumericInputboxText = NumericInputBoxTexbox.Texts
                    };

                    // Raise the event.
                    KeyboardEvent(this, args);
                }
            }
        }
        private void Delete(object sender, EventArgs e)
        {
            NumericInputBoxTexbox.Texts = String.Empty;
            NumericInputBoxTexbox.BorderColor = _mainColor;
            InformationLabel.Text = String.Empty;
            InformationLabel.ForeColor = _mainColor;
        }

 
        private void NumericInputBoxTexbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                //Raises event for counter
                if (KeyboardEvent != null)
                {

                    NumericInputBoxKeyboardEventArgs args = new()
                    {
                        KeyPressed = "{ACCEPT}",
                        NumericInputboxText = NumericInputBoxTexbox.Texts
                    };

                    // Raise the event.
                    KeyboardEvent(this, args);
                }
            }
            else
            {
                KeyboardEvent(this, new NumericInputBoxKeyboardEventArgs());
            }
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            //Raises event for counter
            if (KeyboardEvent != null)
            {

                NumericInputBoxKeyboardEventArgs args = new()
                {
                    KeyPressed = ConfirmButton.Tag.ToString(),
                    NumericInputboxText = NumericInputBoxTexbox.Texts
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

                NumericInputBoxKeyboardEventArgs args = new()
                {
                    KeyPressed = CancelButton.Tag.ToString(),
                    NumericInputboxText = NumericInputBoxTexbox.Texts
                };

                // Raise the event.
                KeyboardEvent(this, args);
            }
        }
    }
    public class NumericInputBoxKeyboardEventArgs : EventArgs
    {
        // The Key pressed
        public string KeyPressed = string.Empty;

        // Numeric Inputbox Text
        public string NumericInputboxText = string.Empty;
    }
}
