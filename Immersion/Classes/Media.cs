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
        public string PathToFile { get; set; }
        public List<string> Tags { get; set; }  
        public int Id { get; set; }

        public Media(int id, string path, List<string> tags, string name = "") 
        {
            if (String.IsNullOrWhiteSpace(path) || !Path.Exists(path))
                throw new FileNotFoundException(path);

            Id = id;
            Name = String.IsNullOrWhiteSpace(name) ?
                Path.GetFileNameWithoutExtension(path) :
                name;
            PathToFile = path;
            Tags = new List<string>();
            if (tags != null)
                Tags = tags;
        }
    }
}
