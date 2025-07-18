using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Immersion.Classes
{
    internal class XMLHAndling
    {
        internal static List<Scene> LoadScenesFromXML(string xmlFilePath)
        {
            var doc = XDocument.Parse(File.ReadAllText(xmlFilePath));
            var scenes = new List<Scene>();

            foreach (var sceneElem in doc.Descendants("Scene"))
            {
                string name = (string)sceneElem.Attribute("name");
                int id = (int)sceneElem.Attribute("id");
                string bgImage = (string)sceneElem.Attribute("bgimage") ?? "";

                // Bilder sammeln
                var pictures = sceneElem
                    .Element("Images")?
                    .Elements("Image")
                    .Select(img => new Picture(
                        (string)img.Attribute("name"),
                        (string)img.Attribute("path"),
                        new List<string>() // aktuell keine Tags im XML
                    ))
                    .ToList() ?? new List<Picture>();

                // Videos sammeln
                var videos = sceneElem
                    .Element("Videos")?
                    .Elements("Video")
                    .Select(vid => new Video(
                        (string)vid.Attribute("name"),
                        (string)vid.Attribute("path"),
                        new List<string>()
                    ))
                    .ToList() ?? new List<Video>();

                // Sounds sammeln
                var sounds = sceneElem
                    .Element("Sounds")?
                    .Elements("Sound")
                    .Select(snd => new Sound(
                        (string)snd.Attribute("name"),
                        (string)snd.Attribute("path"),
                        new List<string>()
                    ))
                    .ToList() ?? new List<Sound>();

                scenes.Add(new Scene(name, id, bgImage, pictures, videos, sounds));
            }
            return scenes;
        }
    }
}
