﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Immersion.Classes
{
    public class Sound : Media
    {
        public Sound(int id, string path, List<string> list, string name = "") : 
            base(id, path, list, name)
        {
            
        }

        public Sound() : base() { }
    }
}
