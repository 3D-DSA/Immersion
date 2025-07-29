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
        public int Id { get; set; }

        public Media() { }
        public Media(int id, string name, string path, List<string> tags) 
        { 
            Id = id;
            Name = name; 
            Path = path;
            Tags = new List<string>();
            Tags = tags;
        }
    }
}
