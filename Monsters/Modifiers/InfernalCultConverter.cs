using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DungeonTool.Monsters.Modifiers
{
    public class InfernalCultConverter : Converter<InfernalCult>
    {
        protected override InfernalCult Create(Type objectType, JObject jObject)
        {
            InfernalCult cult = new InfernalCult();

            // Cult abilities
            if (FieldExists("abilities", jObject))
            {
                JArray abilityArray = jObject.GetValue("abilities").Value<JArray>();
                foreach (JToken abilityToken in abilityArray.Children())
                {
                    Ability ability = JsonConvert.DeserializeObject<Ability>(abilityToken.ToString(), new AbilityConverter());
                    cult.Abilities.Add(ability);
                }
            }

            // Cult cultists
            if (FieldExists("cultists", jObject))
            {
                string cultists = jObject.GetValue("cultists").Value<string>();
                cult.Cultists = cultists;
            }
            else
            {
                cult.Cultists = "Those who roll";
            }

            // Cult devil
            if (FieldExists("devil", jObject))
            {
                string devil = jObject.GetValue("devil").Value<string>();
                cult.Devil = devil;
            }
            else
            {
                cult.Cultists = "Rick Astley";
            }

            // Cult goals
            if(FieldExists("goals", jObject))
            {
                string goals = jObject.GetValue("goals").Value<string>();
                cult.Goals = goals;
            }
            else
            {
                cult.Goals = "What do you think they want?";
            }

            // Cult ID
            if (FieldExists("id", jObject))
            {
                string id = jObject.GetValue("id").Value<string>();
                cult.ID = id;
            }
            else
            {
                cult.ID = Guid.NewGuid().ToString();
            }

            if(FieldExists("spells", jObject))
            {
                JArray spellArray = jObject.GetValue("spells").Value<JArray>();
                foreach (JToken spellToken in spellArray.Children())
                {
                    Spell spell = JsonConvert.DeserializeObject<Spell>(spellToken.ToString(), new SpellConverter());
                    cult.Spells.Add(spell);
                }
            }

            return cult;
        }
    }
}
