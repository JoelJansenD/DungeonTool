using DungeonTool.Monsters;
using DungeonTool.Encounters;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using DungeonTool.Monsters.Modifiers;

namespace DungeonTool
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Directory.GetCurrentDirectory().Split("DungeonTool")[0] + "DungeonTool/";
            StoredData.PlayerCount = 5;
            StoredData.PlayerLevel = 2;

            #region Personalities
            string personalityJson = File.ReadAllText(path + @"Data/personalities.json");
            JArray personalityArray = JArray.Parse(personalityJson);
            foreach (JToken personalityToken in personalityArray.Children())
            {
                Personality personality = JsonConvert.DeserializeObject<Personality>(personalityToken.ToString(), new PersonalityConverter());
                StoredData.Personalities.Add(personality);
            }
            #endregion

            #region Personality groups
            string personalityGroupJson = File.ReadAllText(path + @"Data/personality_groups.json");
            JArray personalityGroupArray = JArray.Parse(personalityGroupJson);
            foreach (JToken personalityGroupToken in personalityGroupArray.Children())
            {
                PersonalityGroup personalityGroup = JsonConvert.DeserializeObject<PersonalityGroup>(personalityGroupToken.ToString(), new PersonalityGroupConverter());
                StoredData.PersonalityGroups.Add(personalityGroup);
            }
            #endregion

            #region Relationships
            string relationshipJson = File.ReadAllText(path + @"Data/relationships.json");
            JArray relationshipArray = JArray.Parse(relationshipJson);
            foreach (JToken relationshipToken in relationshipArray.Children())
            {
                Relationship relationship = JsonConvert.DeserializeObject<Relationship>(relationshipToken.ToString(), new RelationshipConverter());
                StoredData.Relationships.Add(relationship);
            }
            #endregion

            #region Relationship groups
            string relationshipGroupJson = File.ReadAllText(path + @"Data/relationship_groups.json");
            JArray relationshipGroupArray = JArray.Parse(relationshipGroupJson);
            foreach (JToken relationshipGroupToken in relationshipGroupArray.Children())
            {
                RelationshipGroup relationshipGroup = JsonConvert.DeserializeObject<RelationshipGroup>(relationshipGroupToken.ToString(), new RelationshipGroupConverter());
                StoredData.RelationshipGroups.Add(relationshipGroup);
            }
            #endregion

            #region Infernal cults
            string cultJson = File.ReadAllText(path + @"Data/infernal_cults.json");
            JArray cultArray = JArray.Parse(cultJson);
            foreach (JToken cultToken in cultArray.Children())
            {
                InfernalCult cult = JsonConvert.DeserializeObject<InfernalCult>(cultToken.ToString(), new InfernalCultConverter());
                StoredData.InfernalCults.Add(cult);
            }
            #endregion

            #region Infernal cult groups
            string cultGroupJson = File.ReadAllText(path + @"Data/infernal_cult_groups.json");
            JArray cultGroupArray = JArray.Parse(cultGroupJson);
            foreach (JToken cultGroupToken in cultGroupArray.Children())
            {
                InfernalCultGroup cultGroup = JsonConvert.DeserializeObject<InfernalCultGroup>(cultGroupToken.ToString(), new InfernalCultGroupConverter());
                StoredData.InfernalCultGroups.Add(cultGroup);
            }
            #endregion

            #region Appropriate monsters
            string monsterJson = File.ReadAllText(path + @"Data/monsters.json");
            JArray monsterArray = JArray.Parse(monsterJson);
            foreach(JToken monsterToken in monsterArray.Children())
            {
                Monster monster = JsonConvert.DeserializeObject<Monster>(monsterToken.ToString(), new MonsterConverter());
                StoredData.Monsters.Add(monster);
            }
            #endregion

            Encounter encounter = Encounter.CreateEncounter(EncounterDifficulty.Deadly);
        }
    }
}
