namespace Permaquim.Depositary.Launcher
{
    internal static class Program
    {
        static Mutex mutex = new Mutex(true, Application.ProductName);
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (mutex.WaitOne(TimeSpan.Zero, true))
            {
                // To customize application configuration such as set high DPI settings or default font,
                // see https://aka.ms/applicationconfiguration.
                ApplicationConfiguration.Initialize();
                Application.Run(new Mainform());
                // release mutex after the form is closed.
                mutex.ReleaseMutex();
                mutex.Dispose();
            }
        }
    }
}