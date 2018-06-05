using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonTool.Monsters
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
