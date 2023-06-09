﻿using Permaquim.Depositary.UI.Desktop.Controllers;
using Permaquim.Depositary.UI.Desktop.Controls;
using Permaquim.Depositary.UI.Desktop.Global;
using System.Configuration;
using static Permaquim.Depositary.UI.Desktop.Global.Enumerations;

namespace Permaquim.Depositary.UI.Desktop.Forms
{
    public partial class PermissionUnlockForm : Form
    {
        private System.Windows.Forms.Timer _pollingTimer = new System.Windows.Forms.Timer();
        private const string ENTER = "{ENTER}";
        private const string RETIRO_DE_VALORES = "Retiro de Valores";
        private TextBox _activeTextbox;
        public PermissionUnlockForm()
        {
            this.SuspendLayout();
            InitializeComponent();
            MainKeyboard.Visible = false;
            LoadStyles();
            Loadlogo();

            TitleLabel.Text = MultilanguangeController.GetText(MultiLanguageEnum.INGRESE_CRDENCIALES_AUTORIZACION);
            MainKeyboard.UserTextboxPlaceholder = MultilanguangeController.GetText(MultiLanguageEnum.PLACEHOLDER_TEXTO_USUARIO);
            MainKeyboard.PasswordTextBoxPlaceholder = MultilanguangeController.GetText(MultiLanguageEnum.PLACEHOLDER_TEXTO_PASSWORD);

            MainKeyboard.SetButtonsColor(StyleController.GetColor(Enumerations.ColorNameEnum.FuentePrincipal));

            MainKeyboard.KeyboardEvent += MainKeyboard_KeyboardEvent;

            TimeOutController.Reset();
            _pollingTimer = new System.Windows.Forms.Timer()
            {
                Interval = DeviceController.GetPollingInterval()
            };
            _pollingTimer.Tick += PollingTimer_Tick;

            MainKeyboard.Visible = true;
            this.ResumeLayout();
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
        public void LoadStyles()
        {
            this.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.FondoFormulario);
            MainKeyboard.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.FondoFormulario);

        }
        private void CenterPanel()
        {

            MainKeyboard.Location = new Point()
            {
                X = this.Width / 2 - MainKeyboard.Width / 2,
                Y = this.Height / 2 - MainKeyboard.Height / 2
            };
        }

        private void Loadlogo()
        {
            LoginPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            LoginPictureBox.Image = StyleController.GetLogin();

        }

        private void KeyboardInputForm_Load(object sender, EventArgs e)
        {
            CenterPanel();
        }

        private void MainKeyboard_MouseClick(object sender, MouseEventArgs e)
        {
            TimeOutController.Reset();
        }

        private void KeyboardInputForm_VisibleChanged(object sender, EventArgs e)
        {
            _pollingTimer.Enabled = this.Visible;
            FormsController.SetInformationMessage(InformationTypeEnum.None, string.Empty);
        }
        private void KeysHandler(object sender, EventArgs e)
        {
            _activeTextbox.Focus();


            if (((System.Windows.Forms.Button)sender).Tag.ToString().Equals("{BACKSPACE}"))
            {
                if (_activeTextbox.Text.Length > 0)
                {
                    _activeTextbox.Text = _activeTextbox.Text.Substring(0, _activeTextbox.Text.Length - 1);
                    _activeTextbox.SelectionStart = _activeTextbox.Text.Length;
                }
            }
            else
            {

                int pos = _activeTextbox.SelectionStart;
                _activeTextbox.Text = _activeTextbox.Text.Insert(pos, ((System.Windows.Forms.Button)sender).Tag.ToString());
                _activeTextbox.SelectionStart = pos + 1;

                _activeTextbox.SelectionLength = 0;

            }
        }

        private void MainKeyboard_KeyboardEvent(object sender, KeyboardEventArgs args)
        {
            TimeOutController.Reset();

            if (args.KeyPressed.Equals(ENTER))
            {
                if (args.UserText.Trim().Equals(string.Empty) ||
                    args.PasswordText.Trim().Equals(string.Empty))
                {
                    MainKeyboard.SetLoginError(MultilanguangeController.GetText(MultiLanguageEnum.ERROR_FALTA_DATO));
                }
                else
                {
                    var currentUser = DatabaseController.Login(args.UserText.Trim(), args.PasswordText.Trim());

                    if (currentUser.Id != 0)
                    {
                        if (DatabaseController.UserAllowedInSector())
                        {

                            if (currentUser.DebeCambiarPassword)
                            {
                                MainKeyboard.SetLoginError(MultilanguangeController.GetText(MultiLanguageEnum.DEBECAMBIARPASSWORD));
                                return;
                            }

                            if (DatabaseController.UserExpirationDateReached())
                            {
                                MainKeyboard.SetLoginError(MultilanguangeController.GetText(MultiLanguageEnum.CUENTA_USUARIO_EXPIRADA));
                                return;
                            }

                            MultilanguangeController.ResetLanguage();

                            var operations = DatabaseController.GetTransactionTypes();
                            var operation = operations.Where(x => x.Nombre.Equals(RETIRO_DE_VALORES)).FirstOrDefault();

                            if (SecurityController.IsOperationEnabled((long)operation.FuncionId))
                            {
                                this.DialogResult = DialogResult.OK;
                            }
                            else
                                MainKeyboard.SetLoginError(MultilanguangeController.GetText(MultiLanguageEnum.NO_POSEE_PERMISOS));

                            if (((Permaquim.Depositary.UI.Desktop.Controls.KeyboardEventArgs)args).KeyPressed.Equals(ENTER))
                            {
                                MainKeyboard.ClearCredentials();
                            }
                        }
                        else
                        {
                            MainKeyboard.SetLoginError(MultilanguangeController.GetText(MultiLanguageEnum.USUARIO_NO_HABILITADO_EN_SECTOR));
                        }

                    }
                    else
                    {
                        MainKeyboard.SetLoginError(MultilanguangeController.GetText(MultiLanguageEnum.USUARIO_NO_REGISTRADO));
                    }
                }
            }
        }

    }
}
