using Permaquim.Depositary.UI.Desktop.Controllers;
using Permaquim.Depositary.UI.Desktop.Controls;
using System.Configuration;

namespace Permaquim.Depositary.UI.Desktop
{
    public partial class KeyboardInputForm : System.Windows.Forms.Form
    {
 
        public KeyboardInputForm()
        {
            this.SuspendLayout();
            InitializeComponent();
            LoadStyles();
            Loadlogo();

            TitleLabel.Text = MultilanguangeController.GetText("LOGIN_TITLE");
            MainKeyboard.UserTextboxPlaceholder = MultilanguangeController.GetText("USERTEXTBOXPLACEHOLDER");
            MainKeyboard.PasswordTextBoxPlaceholder = MultilanguangeController.GetText("PASSWORDTEXTBOXPLACEHOLDER");

            MainKeyboard.SetButtonsColor(StyleController.GetColor(StyleController.ColorNameEnum.FuentePrincipal));

            MainKeyboard.KeyboardEvent += MainKeyboard_KeyboardEvent;
            this.ResumeLayout();

        }
        private void LoadStyles()
        {
            this.BackColor = StyleController.GetColor(StyleController.ColorNameEnum.Contenido);
            MainKeyboard.BackColor = StyleController.GetColor(StyleController.ColorNameEnum.Contenido);

        }

        private void MainKeyboard_KeyboardEvent(object sender, KeyboardEventArgs args)
        {

            if (args.KeyPressed.Equals("{ENTER}"))
            {
                if (args.UserText.Trim().Equals(string.Empty) ||
                    args.PasswordText.Trim().Equals(string.Empty))
                {
                    MainKeyboard.SetLoginError(MultilanguangeController.GetText("FALTA_USUARIO_PASSWORD"));
                }
                else
                {
                    Permaquim.Depositario.Entities.Relations.Seguridad.Usuario currentUser =
                        DatabaseController.Login(args.UserText.Trim(), args.PasswordText.Trim());

                    if (currentUser.Id != 0)
                    {

                        Permaquim.Depositario.Business.Tables.Operacion.Sesion sesion = new();
                        sesion.Add(DatabaseController.CurrentUser.Id, DateTime.Now, null, null);
                        if (((Permaquim.Depositary.UI.Desktop.Controls.KeyboardEventArgs)args).KeyPressed.Equals("{ENTER}"))
                            AppController.OpenChildForm(new OperationForm(), (Permaquim.Depositary.UI.Desktop.Components.Device)this.Tag);
                    }
                    else
                    {
                        MainKeyboard.SetLoginError(MultilanguangeController.GetText("USUARIO_NO_REGISTRADO"));
                    }
                }
            }
        }

        private void Loadlogo()
        {
            LoginPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            LoginPictureBox.Image = StyleController.GetLogin();

        }
    }
}