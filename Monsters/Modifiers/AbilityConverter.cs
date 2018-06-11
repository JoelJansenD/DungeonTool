using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;

namespace DungeonTool.Monsters.Modifiers
{
    public class AbilityConverter : Converter<Ability>
    {
        protected override Ability Create(Type objectType, JObject jObject)
        {
            Ability ability = new Ability();

            // Ability description
            if(FieldExists("description", jObject))
            {
                string description = jObject.GetValue("description").Value<string>();
                ability.Description = description;
            }
            else
            {
                ability.Description = "Strangers to love, we are not.";
            }

            // Ability name
            if(FieldExists("name", jObject))
            {
                string abilityName = jObject.GetValue("name").Value<String>();
                ability.Name = abilityName;
            }
            else
            {
                ability.Name = "Big Shiny Balls";
            }

            return ability;
        }
    }
}
