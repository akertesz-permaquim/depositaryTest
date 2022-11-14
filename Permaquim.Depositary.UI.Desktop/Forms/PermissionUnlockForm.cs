using Permaquim.Depositary.UI.Desktop.Controllers;
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
    }
}
