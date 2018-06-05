using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;

namespace DungeonTool.Monsters
{
    class RelationshipGroupConverter : Converter<RelationshipGroup>
    {
        protected override RelationshipGroup Create(Type objectType, JObject jObject)
        {
            RelationshipGroup relationshipGroup = new RelationshipGroup();

            // PersonalityGroup name
            if (FieldExists("type", jObject))
            {
                relationshipGroup.Type = jObject.GetValue("type").Value<string>();
            }
            else
            {
                relationshipGroup.Type = "Lacks social skills";
            }

            // Personality group personalities
            if (FieldExists("relationships", jObject))
            {
                JArray relationshipGroupArray = jObject.GetValue("relationships").Value<JArray>();
                foreach (JToken relationshipGroupToken in relationshipGroupArray.Children())
                {
                    relationshipGroup.Relationships.Add(StoredData.Relationships.Find(relationship => relationship.ID == relationshipGroupToken.ToString()));
                }
            }

            return relationshipGroup;
        }
    }
}
