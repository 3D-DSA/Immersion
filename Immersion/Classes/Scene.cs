using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Immersion.Classes
{
    public class Scene
    {
        public ObservableCollection<Picture> PictureList;
        public ObservableCollection<Video> VideoList;
        public ObservableCollection<Sound> SoundList;

        public string Name;
        public int Id;
        public string BgImagePath;
        public Picture Background;

        public Scene()
        { }
        public Scene(string name, int id, string bgImage, ObservableCollection<Picture> pictures, ObservableCollection<Video> videos, ObservableCollection<Sound> sounds)
        {
            PictureList = new ObservableCollection<Picture>();
            VideoList = new ObservableCollection<Video>();
            SoundList = new ObservableCollection<Sound>();
            
            Name = String.IsNullOrWhiteSpace(name) ? "Neue Szene" : name;
            Id = id;
            PictureList = pictures;
            VideoList = videos;
            SoundList = sounds;

            BgImagePath = bgImage;
        }

        public void AddPicture(Picture picture) 
        {
            PictureList.Add(picture); 
        }
        public void RemovePicture(Picture picture) { PictureList.Remove(picture); }
        public void AddVideo(Video video) {VideoList.Add(video); }
        public void RemoveVideo(Video video) { VideoList.Remove(video); }
        public void AddSound(Sound sound) { SoundList.Add(sound); }
        public void RemoveSound(Sound sound) {SoundList.Remove(sound); }

        internal ScenePanel CreateScenePanel()
        {
            return new ScenePanel(Id, Name)
            {
                Height = 80,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(3),
            };
        }

        internal void SetName(string name)
        {
            Name = name;
        }

        public int GetId() { return Id;}
        public string GetName() { return Name;}
        internal int PictureCount() { return PictureList.Count; }
        internal int VideoCount() { return VideoList.Count; }
        internal int SoundCount() { return SoundList.Count; }
    }
}
