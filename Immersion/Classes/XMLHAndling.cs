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
            var scenes = new Dictionary<int, Scene>();
            if (xmlFilePath == null || String.IsNullOrWhiteSpace( xmlFilePath)) 
                return scenes;

            XmlSerializer serializer = new XmlSerializer(typeof(Dictionary<int, Scene>));
            using (FileStream fs = new FileStream(xmlFilePath, FileMode.Open))
            {
                scenes = (Dictionary<int, Scene>)serializer.Deserialize(fs);
            }
            if(scenes == null)
                return new Dictionary<int, Scene>();

            return scenes;
        }

        internal static void SaveScenesToXML(string fileName, Dictionary<int, Scene> sceneList)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Dictionary<int, Scene>));
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                serializer.Serialize(fs, sceneList);
            }
        }
    }
}
