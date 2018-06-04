using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonTool.Characters
{
    public class Personality
    {
        public string ID;
        public string Name;
        public string Description;

        public override string ToString()
        {
            return $"{Name}. {Description}";
        }
    }
}
