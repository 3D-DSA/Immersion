using Immersion.Classes;
namespace Immersion
{
    internal static class ImmersionMain
    {
        
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var sceneList = new List<Scene>();
            var screenList = new List<Screen>();
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());

            screenList = Classes.Infrastructure.GetScreenList();

        }
    }
}