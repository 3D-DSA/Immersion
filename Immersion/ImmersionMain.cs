using Immersion.Classes;
using System.Collections.ObjectModel;

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

        internal static void AddImagesToList(List<string> imagePathList)
        {
            if (currentScene == null) InitializeCurrentScene();

            foreach (string imagePath in imagePathList)
            {
                Picture newPic = new Picture(currentScene.PictureCount() + 1,
                    imagePath, null);
                currentScene.AddPicture(newPic);
            }
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
                scenes[currentScene.GetId()] = currentScene;
            else
                scenes.Add(currentScene.GetId(), currentScene);
            currentScene = scene;
        }

        internal static void InitializeCurrentScene(bool forceOverride = false)
        {
            if(currentScene != null && !forceOverride) return;
            currentScene = new Scene(
                "Neue Szene",
                scenes.Count() + 1,
                "",
                new ObservableCollection<Picture>(),
                new ObservableCollection<Video>(),
                new ObservableCollection<Sound>());

        }
    }
}