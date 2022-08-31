using Permaquim.Depositary.Launcher.Controllers;
using Permaquim.Depositary.Launcher.Security;
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
    
        }

        private async void Mainform_Load(object sender, EventArgs e)
        {


            if (DatabaseController.CurrentDepositary == null)
            {
                try
                {
                    await InitializationController.InitializeDepositary();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            // TODO: Verificar actualización * 
            // Llamar a la aplicación desktop

            if (System.IO.File.Exists(Directory.GetCurrentDirectory() + APPLICATION))
                Process.Start(Directory.GetCurrentDirectory() + APPLICATION);
            else
                MessageBox.Show("El archivo " + Directory.GetCurrentDirectory() + APPLICATION + " no existe.",
                    "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);

            Application.Exit();

        }
    }
}