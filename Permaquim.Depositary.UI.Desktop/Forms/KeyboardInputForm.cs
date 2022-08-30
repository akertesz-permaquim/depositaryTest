using Permaquim.Depositary.UI.Desktop.Controllers;
using Permaquim.Depositary.UI.Desktop.Controls;
using Permaquim.Depositary.UI.Desktop.Global;
using System.Configuration;
using static Permaquim.Depositary.UI.Desktop.Global.Enumerations;

namespace Permaquim.Depositary.UI.Desktop
{
    public partial class KeyboardInputForm : System.Windows.Forms.Form
    {
        private System.Windows.Forms.Timer _pollingTimer = new System.Windows.Forms.Timer();
        private const string ENTER = "{ENTER}";
        public KeyboardInputForm()
        {
            this.SuspendLayout();
            InitializeComponent();
            MainKeyboard.Visible = false;
            LoadStyles();
            Loadlogo();
           
            TitleLabel.Text = MultilanguangeController.GetText(MultiLanguageEnum.TITULO_LOGIN);
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
        private void LoadStyles()
        {
            this.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.FondoFormulario);
            MainKeyboard.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.FondoFormulario);

        }
        private void CenterPanel()
        {

            MainPanel.Location = new Point()
            {
                X = this.Width / 2 - MainPanel.Width / 2,
                Y = this.Height / 2 - MainPanel.Height / 2
            };
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

                        if (currentUser.DebeCambiarPassword || DatabaseController.UserExpirationDateReached())
                        {
                            MultilanguangeController.ResetLanguage();

                            DatabaseController.GetTurnSchedule();

                            if (((Permaquim.Depositary.UI.Desktop.Controls.KeyboardEventArgs)args).KeyPressed.Equals(ENTER))
                            {
                                MainKeyboard.ClearCredentials();
                                FormsController.OpenChildForm(this, new OperationForm(),
                                    (Permaquim.Depositary.UI.Desktop.Components.CounterDevice)this.Tag);
                            }
                        }

                        MainKeyboard.SetLoginError(MultilanguangeController.GetText(MultiLanguageEnum.DEBECAMBIARPASSWORD));
                    }
                    else
                    {
                        MainKeyboard.SetLoginError(MultilanguangeController.GetText(MultiLanguageEnum.USUARIO_NO_REGISTRADO));
                    }
                }
            }
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
    }
}