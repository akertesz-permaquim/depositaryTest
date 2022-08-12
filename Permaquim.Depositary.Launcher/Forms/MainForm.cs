using Permaquim.Depositary.Launcher.Controllers;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Permaquim.Depositary.Launcher
{
    public partial class Mainform : Form
    {
        private const string APPLICATION = @"\APP.0.STOL.exe";

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
       (
           int nLeftRect,     // x-coordinate of upper-left corner
           int nTopRect,      // y-coordinate of upper-left corner
           int nRightRect,    // x-coordinate of lower-right corner
           int nBottomRect,   // y-coordinate of lower-right corner
           int nWidthEllipse, // width of ellipse
           int nHeightEllipse // height of ellipse
       );
        public Mainform()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            if (DatabaseController.CurrentDepositary == null)
            {
                try
                {
                    InitializationController.InitializeDepositary();
                    Application.Exit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                //TODO: Verificar actualización
                // Llamar a la aplicación desktop
                //Process.Start(Directory.GetCurrentDirectory() + APPLICATION);
            }
        }
    }
}