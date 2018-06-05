using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonTool.Monsters.Modifiers
{
    public class InfernalCult
    {
        public List<Ability> Abilities;
        public List<Spell> Spells;

        public string Cultists;
        public string Devil;
        public string Goals;
        public string ID;
        public string Name { get => "Cult of " + Devil; }
        
        public InfernalCult()
        {
            Abilities = new List<Ability>();
            Spells = new List<Spell>();
        }
    }
}
