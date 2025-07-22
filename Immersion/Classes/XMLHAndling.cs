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
        internal static List<Scene> LoadScenesFromXML(string xmlFilePath)
        {   
            var scenes = new List<Scene>();
            if (xmlFilePath == null || String.IsNullOrWhiteSpace( xmlFilePath)) 
                return scenes;

            XmlSerializer serializer = new XmlSerializer(typeof(List<Scene>));
            using (FileStream fs = new FileStream(xmlFilePath, FileMode.Open))
            {
                scenes = (List<Scene>)serializer.Deserialize(fs);
            }
            if(scenes == null)
                return new List<Scene>();

            return scenes;
        }

        internal static void SaveScenesToXML(string fileName, List<Scene> sceneList)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Scene>));
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                serializer.Serialize(fs, sceneList);
            }
        }
    }
}
