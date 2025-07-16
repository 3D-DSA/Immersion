using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Immersion.Classes
{
    internal class Scene
    {
        private List<Picture> pictureList;
        private List<Video> videoList;
        private List<Sound> soundList;
        public Scene() {
            pictureList = new List<Picture>();
            videoList = new List<Video>();
            soundList = new List<Sound>();
        }

        public void AddPicture(Picture picture)
        {
            pictureList.Add(picture);
        }
    }
}
