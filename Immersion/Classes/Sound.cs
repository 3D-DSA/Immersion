using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Immersion.Classes
{
    internal class Sound : Media
    {
        public Sound(string? name, string? path, List<string> list)
        {
            this.Name = name;
            this.Path = path;
            Tags = new List<string>();
            this.Tags = list;
        }
    }
}
