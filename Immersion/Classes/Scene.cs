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
    internal class Scene
    {
        public ObservableCollection<Picture> PictureList;
        public ObservableCollection<Video> VideoList;
        public ObservableCollection<Sound> SoundList;

        private string Name;
        private int Id;
        private string BgImagePath;
        private Picture Background;

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
            var panel = new ScenePanel(Id, Name)
            {
                Height = 80,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(3),
            };

            var lbl = new Label()
            {
                Text = Name,
                AutoSize = true,
                Font = new Font(FontFamily.GenericSansSerif, 12.0f, FontStyle.Bold),
            };
            panel.Controls.Add(lbl);

            return panel;
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
