using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;

namespace DungeonTool.Monsters
{
    class PersonalityConverter : Converter<Personality>
    {
        protected override Personality Create(Type objectType, JObject jObject)
        {
            Personality personality = new Personality();

            // Personality description
            if(FieldExists("description", jObject))
            {
                personality.Description = jObject.GetValue("description").Value<string>();
            }
            else
            {
                personality.Description = "They have a heart of stone.";
            }

            // Personality ID
            if(FieldExists("id", jObject))
            {
                personality.ID = jObject.GetValue("id").Value<string>();
            }
            else
            {
                personality.ID = Guid.NewGuid().ToString();
            }

            // Personality name
            if(FieldExists("name", jObject))
            {
                personality.Name = jObject.GetValue("name").Value<string>();
            }
            else
            {
                personality.Name = "Emotionless bastard";
            }

            return personality;
        }
    }
}
