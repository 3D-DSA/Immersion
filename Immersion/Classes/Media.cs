using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Immersion.Classes
{
    internal class Media
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public List<string> Tags { get; set; }  

        public Media() { }
        public Media(string name, string path, List<string> tags) 
        { 
            Name = name; 
            Path = path;
            Tags = new List<string>();
            Tags = tags;
        }
    }
}
