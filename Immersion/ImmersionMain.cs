using Immersion.Classes;

namespace Immersion
{
    internal static class ImmersionMain
    {
        //public static List<Scene> sceneList = new List<Scene>();
        public static Dictionary<int, Scene> scenes = new Dictionary<int, Scene>();
        public static Scene currentScene;
        public static List<ScreenPanel> screenList = new List<ScreenPanel>();
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());

        }
        /// <summary>
        /// Swaps a new scene with the currently used scene. The old scene is stored
        /// in the scenes dictionary
        /// </summary>
        /// <param name="scene">The scene that should become the new current scene</param>
        internal static void SwapCurrentScene(Scene scene)
        {
            if (scene == null) return;
            if (scenes.ContainsKey(currentScene.GetId()))
                scenes[scene.GetId()] = currentScene;
            else
                scenes.Add(currentScene.GetId(), currentScene);
            currentScene = scene;
        }
    }
}