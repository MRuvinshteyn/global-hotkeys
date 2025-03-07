using GlobalTextExpansion;

namespace CentralTrayApplication
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            TextExpander expander = new TextExpander();
            expander.Start();

            using (TrayApplication app = new TrayApplication())
            {
                Application.Run();
            }

            expander.Stop();
        }
    }
}