using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;

namespace DungeonTool.Monsters
{
    class PersonalityGroupConverter : Converter<PersonalityGroup>
    {
        protected override PersonalityGroup Create(Type objectType, JObject jObject)
        {
            PersonalityGroup personalityGroup = new PersonalityGroup();

            // PersonalityGroup name
            if (FieldExists("type", jObject))
            {
                personalityGroup.Type = jObject.GetValue("type").Value<string>();
            }
            else
            {
                personalityGroup.Type = "Very generic";
            }

            // Personality group personalities
            if (FieldExists("personalities", jObject))
            {
                JArray personalityGroupArray = jObject.GetValue("personalities").Value<JArray>();
                foreach (JToken personalityGroupToken in personalityGroupArray.Children())
                {
                    personalityGroup.Personalities.Add(StoredData.Personalities.Find(personality => personality.ID == personalityGroupToken.ToString()));
                }
            }

            return personalityGroup;
        }
    }
}
