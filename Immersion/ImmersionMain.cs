using Immersion.Classes;
namespace Immersion
{
    internal static class ImmersionMain
    {
        public static List<Scene> sceneList = new List<Scene>();
        public static List<Screen> screenList = new List<Screen>();
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            

            // fetch screens
            screenList = Infrastructure.GetScreenList();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());

        }
    }
}