using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DungeonTool.Monsters.Modifiers
{
    public class DemonicBeingConverter : Converter<DemonicBeing>
    {
        protected override DemonicBeing Create(Type objectType, JObject jObject)
        {
            DemonicBeing demonicBeing = new DemonicBeing();

            // Cult traits
            if (FieldExists("traits", jObject))
            {
                JArray traitArray = jObject.GetValue("traits").Value<JArray>();
                foreach (JToken traitToken in traitArray.Children())
                {
                    string trait = JsonConvert.DeserializeObject<string>(traitToken.ToString());
                    demonicBeing.Traits.Add(trait);
                }
            }

            return demonicBeing;
        }
    }
}
