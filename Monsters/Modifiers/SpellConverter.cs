using System;
using Newtonsoft.Json.Linq;

namespace DungeonTool.Monsters.Modifiers
{
    class SpellConverter : Converter<Spell>
    {
        protected override Spell Create(Type objectType, JObject jObject)
        {
            Spell spell = new Spell();

            // spell level
            if (FieldExists("level", jObject))
            {
                int level = jObject.GetValue("level").Value<int>();
                spell.Level = level;
            }
            else
            {
                spell.Level = 0;
            }

            // Spell name
            if (FieldExists("name", jObject))
            {
                string spellName = jObject.GetValue("name").Value<String>();
                spell.Name = spellName;
            }
            else
            {
                spell.Name = "Snilloc's Tiny Shiny Balls";
            }

            return spell;
        }
    }
}
