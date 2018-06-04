using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonTool.Characters
{
    public class MonsterConverter : Converter<Monster>
    {
        protected override Monster Create(Type objectType, JObject jObject)
        {
            Monster monster = new Monster();

            // Monster CR
            if (FieldExists("cr", jObject))
            {
                monster.CR = jObject.GetValue("cr").Value<string>();
            }
            else
            {
                monster.CR = "0";
            }

            // Monster ID
            if (FieldExists("id", jObject))
            {
                monster.ID = jObject.GetValue("id").Value<string>();
            }
            else
            {
                monster.ID = Guid.NewGuid().ToString();
            }

            // Monster's friends
            if(FieldExists("monsters", jObject))
            {
                JArray monsterArray = jObject.GetValue("monsters").Value<JArray>();
                foreach(JToken monsterToken in monsterArray.Children())
                {
                    monster.MonsterIDs.Add(monsterToken.ToString());
                }
            }
            else
            {
                monster.MonsterIDs.Add(monster.ID);
            }

            // Monster name
            if (FieldExists("name", jObject))
            {
                monster.Name = jObject.GetValue("name").Value<string>();
            }
            else
            {
                monster.Name = "Random goonie";
            }

            // Monster personalities
            if (FieldExists("personalities", jObject))
            {
                JArray personalityArray = jObject.GetValue("personalities").Value<JArray>();

                foreach (JToken personalityToken in personalityArray.Children())
                {
                    monster.Personalities.Add(StoredData.Personalities.Find(personality => personality.ID == personalityToken.ToString()));
                }
            }

            // Monster relationships
            if(FieldExists("relationships", jObject))
            {
                JArray relationshipArray = jObject.GetValue("relationships").Value<JArray>();

                foreach(JToken relationshipToken in relationshipArray.Children())
                {
                    monster.Relationships.Add(StoredData.Relationships.Find(relationship => relationship.ID == relationshipToken.ToString()));
                }
            }

            // Monster species
            if (FieldExists("species", jObject))
            {
                JToken field = jObject.GetValue("species");
                if (field.Type == JTokenType.Integer)
                {
                    monster.Species = (Species)field.Value<int>();
                }
                else if (field.Type == JTokenType.String)
                {
                    monster.Species = (Species)Enum.Parse(typeof(Species), field.Value<string>().ToLower());
                }
            }
            else
            {
                monster.Species = Species.goonie;
            }

            // Monster subspecies
            if (FieldExists("subspecies", jObject))
            {
                JToken field = jObject.GetValue("subspecies");
                if (field.Type == JTokenType.Integer)
                {
                    monster.Subspecies = (Subspecies)field.Value<int>();
                }
                else if (field.Type == JTokenType.String)
                {
                    monster.Subspecies = (Subspecies)Enum.Parse(typeof(Subspecies), field.Value<string>().ToLower());
                }
            }
            else
            {
                monster.Subspecies = Subspecies.none;
            }

            return monster;
        }
    }
}
