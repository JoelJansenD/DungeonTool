using System;
using System.Collections.Generic;
using System.Text;
using DungeonLib;
using Newtonsoft.Json.Linq;

namespace DungeonTool.Monsters.Modifiers
{
    public class InfernalCultGroupConverter : Converter<InfernalCultGroup>
    {
        protected override InfernalCultGroup Create(Type objectType, JObject jObject)
        {
            InfernalCultGroup infernalCultGroup = new InfernalCultGroup();

            // InfernalCultGroup name
            if (FieldExists("type", jObject))
            {
                infernalCultGroup.Type = jObject.GetValue("type").Value<string>();
            }
            else
            {
                infernalCultGroup.Type = "Very generic";
            }

            // InfernalCultGroup infernal cults
            if (FieldExists("cults", jObject))
            {
                JArray infernalCultGroupArray = jObject.GetValue("cults").Value<JArray>();
                foreach (JToken infernalCultGroupToken in infernalCultGroupArray.Children())
                {
                    infernalCultGroup.InfernalCults.Add(StoredData.InfernalCults.Find(infernalCult => infernalCult.ID == infernalCultGroupToken.ToString()));
                }
            }

            return infernalCultGroup;
        }
    }
}
