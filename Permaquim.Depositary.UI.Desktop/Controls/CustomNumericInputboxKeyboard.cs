﻿using Permaquim.Depositary.UI.Desktop.Controllers;
using Permaquim.Depositary.UI.Desktop.Global;
using static Permaquim.Depositary.UI.Desktop.Global.Enumerations;

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
            NumericInputBoxTexbox.MaxLength = 18;
            NumericInputBoxTexbox.TextAlign = HorizontalAlignment.Right;
            if (this.ParentForm != null)
                this.ParentForm.AcceptButton = this.ConfirmButton;
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
        public void SetMaxLenght(int number)
        {
            NumericInputBoxTexbox.MaxLength = number;
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
                if (item.GetType().Name.Equals("Button"))
                {
                    string buttonTag = ((Button)item).Tag.ToString();

                    if (!(buttonTag.Equals("{ACCEPT}") || buttonTag.Equals("{CANCEL}")))
                        ((Button)item).BackColor = _mainColor;
                }
            }
            NumericInputBoxTexbox.ForeColor = _mainColor;
        }

        private void KeysHandler(object sender, EventArgs e)
        {
            NumericInputBoxTexbox.Focus();

            if (NumericInputBoxTexbox.Texts.Length >= NumericInputBoxTexbox.MaxLength)
                return;

            if (((Button)sender).Tag.ToString().Equals("{ENTER}"))
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
                //SendKeys.SendWait(((Button)sender).Tag.ToString());
                NumericInputBoxTexbox.Texts += ((Button)sender).Tag.ToString();
                NumericInputBoxTexbox.SelectionStart = NumericInputBoxTexbox.Texts.Length;
                NumericInputBoxTexbox.SelectionLength = 0;

                //Raises event for counter
                if (KeyboardEvent != null)
                {

                    NumericInputBoxKeyboardEventArgs args = new()
                    {
                        KeyPressed = ((Button)sender).Tag.ToString(),
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
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                {
                    e.Handled = true;
                }

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
