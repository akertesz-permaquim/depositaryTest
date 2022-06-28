using Permaquim.Depositary.UI.Desktop.Controllers;
using Permaquim.Depositary.UI.Desktop.Controls;
using Permaquim.Depositary.UI.Desktop.Global;
using System.Configuration;

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

            LoadStyles();
            Loadlogo();
           
            TitleLabel.Text = MultilanguangeController.GetText(MultilanguageConstants.LOGIN_TITLE);
            MainKeyboard.UserTextboxPlaceholder = MultilanguangeController.GetText(MultilanguageConstants.USERTEXTBOXPLACEHOLDER);
            MainKeyboard.PasswordTextBoxPlaceholder = MultilanguangeController.GetText(MultilanguageConstants.PASSWORDTEXTBOXPLACEHOLDER);

            MainKeyboard.SetButtonsColor(StyleController.GetColor(Enumerations.ColorNameEnum.FuentePrincipal));

            MainKeyboard.KeyboardEvent += MainKeyboard_KeyboardEvent;
            this.ResumeLayout();

            TimeOutController.Reset();
            _pollingTimer = new System.Windows.Forms.Timer()
            {
                Interval = DeviceController.GetPollingInterval(),
                Enabled = true
            };
            _pollingTimer.Tick += PollingTimer_Tick;

        }
        private void PollingTimer_Tick(object? sender, EventArgs e)
        {
            if (TimeOutController.IsTimeOut())
            {
                _pollingTimer.Enabled = false;
                DatabaseController.LogOff(true);
                AppController.HideInstance(this);
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
                    MainKeyboard.SetLoginError(MultilanguangeController.GetText(MultilanguageConstants.FALTA_USUARIO_PASSWORD));
                }
                else
                {
                    Permaquim.Depositario.Entities.Relations.Seguridad.Usuario currentUser =
                        DatabaseController.Login(args.UserText.Trim(), args.PasswordText.Trim());

                    if (currentUser.Id != 0)
                    {

                        Permaquim.Depositario.Business.Tables.Operacion.Sesion sesion = new();
                        sesion.Add(DatabaseController.CurrentUser.Id, DateTime.Now, null, null);

                        DatabaseController.GetTurnSchedule();

                        if (((Permaquim.Depositary.UI.Desktop.Controls.KeyboardEventArgs)args).KeyPressed.Equals(ENTER))
                        {
                            MainKeyboard.ClearCredentials();
                            AppController.OpenChildForm(this,new OperationForm(), 
                                (Permaquim.Depositary.UI.Desktop.Components.Device)this.Tag);
                        }
                    }
                    else
                    {
                        MainKeyboard.SetLoginError(MultilanguangeController.GetText(MultilanguageConstants.USUARIO_NO_REGISTRADO));
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
    }
}