using Permaquim.Depositary.UI.Desktop.Controllers;
using Permaquim.Depositary.UI.Desktop.Controls;
using Permaquim.Depositary.UI.Desktop.Global;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Permaquim.Depositary.UI.Desktop.Global.Enumerations;

namespace Permaquim.Depositary.UI.Desktop.Forms
{
    public partial class StandardLoginForm : Form
    {
        private Color _mainColor;

        private bool _shift = false;
        private System.Windows.Forms.Timer _pollingTimer = new System.Windows.Forms.Timer();
        private const string ENTER = "{ENTER}";

        private Color _buttonsBackgroundColor;
        private TextBox _activeTextbox;
        public StandardLoginForm()
        {
            this.SuspendLayout();
            this.DoubleBuffered = true;
            InitializeComponent();

            this.ResumeLayout();
            _activeTextbox = UsernameTextBox;
            _activeTextbox.Focus();
            if (this.ParentForm != null)
                this.ParentForm.AcceptButton = this.Button_Enter;


            this.SuspendLayout();
            InitializeComponent();
            LoadStyles();
            Loadlogo();

            TitleLabel.Text = MultilanguangeController.GetText(MultiLanguageEnum.TITULO_LOGIN);
            UsernameTextBox.PlaceholderText = MultilanguangeController.GetText(MultiLanguageEnum.PLACEHOLDER_TEXTO_USUARIO);
            PasswordTexBox.PlaceholderText = MultilanguangeController.GetText(MultiLanguageEnum.PLACEHOLDER_TEXTO_PASSWORD);

            SetButtonsColor(StyleController.GetColor(Enumerations.ColorNameEnum.FuentePrincipal));


            TimeOutController.Reset();
            _pollingTimer = new System.Windows.Forms.Timer()
            {
                Interval = DeviceController.GetPollingInterval()
            };
            _pollingTimer.Tick += PollingTimer_Tick;

            CenterPanel();
        }
        private void Loadlogo()
        {
            LoginPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            LoginPictureBox.Image = StyleController.GetLogin();

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
        private void PollingTimer_Tick(object? sender, EventArgs e)
        {
            if (TimeOutController.IsTimeOut())
            {
                _pollingTimer.Enabled = false;
                DatabaseController.LogOff(true);
                FormsController.LogOff();
            }

        }
        private void LoadStyles()
        {
            this.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.FondoFormulario);
 
        }
        private void CenterPanel()
        {

            MainPanel.Location = new Point()
            {
                X = this.Width / 2 - MainPanel.Width / 2,
                Y = this.Height / 2 - MainPanel.Height / 2
            };
        }

        public void ClearCredentials()
        {
            UsernameTextBox.Text = String.Empty;
            PasswordTexBox.Text = String.Empty;
        }
        public void SetLoginError(string message)
        {
            InformationLabel.Text = message;
            InformationLabel.ForeColor = Color.Red;

        }

        public void SetButtonsColor(Color color)
        {
            _mainColor = color;
            foreach (var item in this.Controls)
            {
                if (item.GetType().Name.Equals("Button"))
                {
                    ((System.Windows.Forms.Button)item).BackColor = _mainColor;
                }
            }

            UsernameTextBox.ForeColor = _mainColor;
            PasswordTexBox.ForeColor = _mainColor;
        }

        private void KeysHandler(object sender, EventArgs e)
        {
            Button button = (System.Windows.Forms.Button)sender;

            if (button.Tag.ToString().Equals("{ENTER}"))
            {
                if (UsernameTextBox.Text.Trim().Equals(string.Empty) ||
                     PasswordTexBox.Text.Trim().Equals(string.Empty))
                {
                    SetLoginError(MultilanguangeController.GetText(MultiLanguageEnum.ERROR_FALTA_DATO));
                }
                else
                {
                    var currentUser = DatabaseController.Login(UsernameTextBox.Text.Trim(), PasswordTexBox.Text.Trim());

                    if (currentUser.Id != 0)
                    {
                        if (DatabaseController.UserAllowedInSector())
                        {

                            if (currentUser.DebeCambiarPassword)
                            {
                                SetLoginError(MultilanguangeController.GetText(MultiLanguageEnum.DEBECAMBIARPASSWORD));
                                return;
                            }

                            if (DatabaseController.UserExpirationDateReached())
                            {
                                SetLoginError(MultilanguangeController.GetText(MultiLanguageEnum.CUENTA_USUARIO_EXPIRADA));
                                return;
                            }

                            MultilanguangeController.ResetLanguage();

                            DatabaseController.GetTurnSchedule();

                            //if (((Permaquim.Depositary.UI.Desktop.Controls.KeyboardEventArgs)args).KeyPressed.Equals(ENTER))
                            //{
                            //    ClearCredentials();
                            //    FormsController.OpenChildForm(this, new OperationForm(),
                            //        (Permaquim.Depositary.UI.Desktop.Components.CounterDevice)this.Tag);
                            //}
                        }
                        else
                        {
                            SetLoginError(MultilanguangeController.GetText(MultiLanguageEnum.USUARIO_NO_HABILITADO_EN_SECTOR));
                        }

                    }
                    else
                    {
                        SetLoginError(MultilanguangeController.GetText(MultiLanguageEnum.USUARIO_NO_REGISTRADO));
                    }
                }
            }
            if (button.Tag.ToString().Equals("{BACKSPACE}"))
            {
                if (_activeTextbox.Text.Length > 0)
                {
                    _activeTextbox.Text = _activeTextbox.Text.Substring(0, _activeTextbox.Text.Length - 1);
                    _activeTextbox.SelectionStart = _activeTextbox.Text.Length;
                }
            }
            else
            {    int pos = _activeTextbox.SelectionStart;
                _activeTextbox.Text = _activeTextbox.Text.Insert(pos, button.Tag.ToString());
                _activeTextbox.SelectionStart = pos + 1;
                _activeTextbox.SelectionLength = 0;
            }
        }

        private void Delete(object sender, EventArgs e)
        {
            UsernameTextBox.Text = String.Empty;
            PasswordTexBox.Text = String.Empty;
            InformationLabel.Text = String.Empty;
            InformationLabel.ForeColor = _mainColor;
        }

        private void PasswordTexbox_Enter(object sender, EventArgs e)
        {
            _activeTextbox = (TextBox)sender;
        }

        private void UsernameTextBox_Enter(object sender, EventArgs e)
        {
            _activeTextbox = (TextBox)sender;
        }

        private void PasswordTexbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Debug.Print("");

            }
        }

        private void UsernameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                PasswordTexBox.Focus();
            }

        }

        private void Button_Shift_Click(object sender, EventArgs e)
        {
            _shift = !_shift;
            ShiftUnshift();
        }
        private void ShiftUnshift()
        {
            foreach (var item in this.MainPanel.Controls)
            {
                if (item.GetType() == typeof(System.Windows.Forms.Button))
                {
                    if (!((System.Windows.Forms.Button)item).Tag.ToString().StartsWith("{"))
                    {

                        if (_shift)
                        {
                            ((System.Windows.Forms.Button)item).Tag = ((System.Windows.Forms.Button)item).Tag.ToString().ToUpper();
                            ((System.Windows.Forms.Button)item).Text = ((System.Windows.Forms.Button)item).Text.ToString().ToUpper();
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
                            ((System.Windows.Forms.Button)item).Tag = ((System.Windows.Forms.Button)item).Tag.ToString().ToLower();
                            ((System.Windows.Forms.Button)item).Text = ((System.Windows.Forms.Button)item).Text.ToString().ToLower();
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
  }

