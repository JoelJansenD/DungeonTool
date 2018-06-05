using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonTool.Monsters
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
            if (FieldExists("personalitygroup", jObject))
            {
                string groupName = jObject.GetValue("personalitygroup").Value<string>();
                List<PersonalityGroup> groups = StoredData.PersonalityGroups.Where(personality => personality.Type == groupName).ToList();

                if(groups.Count > 0)
                {
                    monster.Personalities = groups.First().Personalities;
                }
            }

            // Monster relationships
            if(FieldExists("relationshipgroup", jObject))
            {
                string groupName = jObject.GetValue("relationshipgroup").Value<string>();
                List<RelationshipGroup> groups = StoredData.RelationshipGroups.Where(relationship => relationship.Type == groupName).ToList();

                if(groups.Count > 0)
                {
                    monster.Relationships = groups.First().Relationships;
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
