using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonTool.Monsters.Modifiers
{
    public class InfernalCultGroup
    {
        public string Type;
        public List<InfernalCult> InfernalCults;

        public InfernalCultGroup()
        {
            InfernalCults = new List<InfernalCult>();
        }
    }
}
