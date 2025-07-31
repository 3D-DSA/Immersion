using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Immersion.Classes
{
    internal class XMLHandling
    {
        internal static Dictionary<int, Scene> LoadScenesFromXML(string xmlFilePath)
        {   
            var sceneDictionary = new Dictionary<int, Scene>();
            var sceneList = new List<Scene>();

            if (xmlFilePath == null || String.IsNullOrWhiteSpace( xmlFilePath)) 
                return sceneDictionary;

            XmlSerializer serializer = new XmlSerializer(typeof(List<Scene>));
            using (FileStream fs = new FileStream(xmlFilePath, FileMode.Open))
            {
                sceneList = (List<Scene>)serializer.Deserialize(fs);
            }
            if(sceneList == null)
                return new Dictionary<int, Scene>();

            foreach (Scene scene in sceneList)
                sceneDictionary.Add(scene.GetId(), scene);

            return sceneDictionary;
        }

        public static void SaveScenesToXML(string fileName, Dictionary<int, Scene> sceneDictionary)
        {
            List<Scene> sceneList = new List<Scene>();
            foreach (Scene scene in sceneDictionary.Values) { sceneList.Add(scene); }

            XmlSerializer serializer = new XmlSerializer(typeof(List<Scene>));
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                serializer.Serialize(fs, sceneList);
            }
        }
    }
}
