using Permaquim.Depositary.UI.Desktop.Controllers;
using System.Configuration;

namespace Permaquim.Depositary.UI.Desktop
{
    public partial class KeyboardInputForm : System.Windows.Forms.Form
    {
        private const string LOGIN_IMAGE_FILE = @"\Resources\Images\Login.png";
        public KeyboardInputForm()
        {
            InitializeComponent();
            Loadlogo();
            MainKeyboard.KeyboardEvent += MainKeyboard_KeyboardEvent;

        }

        private void MainKeyboard_KeyboardEvent(object sender, EventArgs args)
        {
            PQDepositario.Business.Tables.Operacion.Sesion sesion = new();
            sesion.Add(0,DateTime.Now,null,null);
            if (((Permaquim.Depositary.UI.Desktop.Controls.KeyboardEventArgs)args).KeyPressed.Equals("{ENTER}"))
                AppController.OpenChildForm(new OperationForm(), (Permaquim.Depositary.UI.Desktop.Components.Device)this.Tag);
        }

        private void Loadlogo()
        {
            LoginPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            var appPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            LoginPictureBox.Load(appPath + LOGIN_IMAGE_FILE);

        }

        private void MainKeyboard_Click(object sender, EventArgs e)
        {

            AppController.OpenChildForm(new OperationForm(),(Permaquim.Depositary.UI.Desktop.Components.Device)this.Tag);
        }
    }
}