using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;

namespace DungeonTool.Monsters
{
    public class RelationshipConverter : Converter<Relationship>
    {
        protected override Relationship Create(Type objectType, JObject jObject)
        {
            Relationship relationship = new Relationship();

            // Relationship description
            if (FieldExists("description", jObject))
            {
                relationship.Description = jObject.GetValue("description").Value<string>();
            }
            else
            {
                relationship.Description = "They had a rough childhood.";
            }

            // Relationship ID
            if(FieldExists("id", jObject))
            {
                relationship.ID = jObject.GetValue("id").Value<String>();
            }
            else
            {
                relationship.ID = Guid.NewGuid().ToString();
            }

            return relationship;
        }
    }
}
