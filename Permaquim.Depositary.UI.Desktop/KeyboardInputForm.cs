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
        }
        private void Loadlogo()
        {
            LoginPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            var appPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            LoginPictureBox.Load(appPath + LOGIN_IMAGE_FILE);

        }
    }
}