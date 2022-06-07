using Permaquim.Depositary.UI.Desktop.Controllers;
using Permaquim.Depositary.UI.Desktop.Controls;
using System.Configuration;

namespace Permaquim.Depositary.UI.Desktop
{
    public partial class KeyboardInputForm : System.Windows.Forms.Form
    {
 
        public KeyboardInputForm()
        {
            InitializeComponent();
            Loadlogo();

            TitleLabel.Text = MultilanguangeController.GetText("LOGIN_TITLE");
            MainKeyboard.UserTextboxPlaceholder = MultilanguangeController.GetText("USERTEXTBOXPLACEHOLDER");
            MainKeyboard.PasswordTextBoxPlaceholder = MultilanguangeController.GetText("PASSWORDTEXTBOXPLACEHOLDER");

            MainKeyboard.KeyboardEvent += MainKeyboard_KeyboardEvent;

        }

        private void MainKeyboard_KeyboardEvent(object sender, KeyboardEventArgs args)
        {

            if (args.UserText.Trim().Equals(string.IsNullOrEmpty) ||
                args.PasswordText.Trim().Equals(string.IsNullOrEmpty))
            {

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
            }
        }

        private void Loadlogo()
        {
            LoginPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            LoginPictureBox.Image = StyleController.GetLogin();

        }

        private void MainKeyboard_Click(object sender, EventArgs e)
        {
           

            AppController.OpenChildForm(new OperationForm(),(Permaquim.Depositary.UI.Desktop.Components.Device)this.Tag);
        }
    }
}