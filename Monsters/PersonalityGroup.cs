using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonTool.Monsters
{
    public class PersonalityGroup
    {
        public string Type;
        public List<Personality> Personalities;

        public PersonalityGroup()
        {
            Personalities = new List<Personality>();
        }
    }
}
