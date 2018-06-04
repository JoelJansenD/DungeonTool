using DungeonTool.Characters;
using DungeonTool.Encounters;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;

namespace DungeonTool
{
    class Program
    {
        static void Main(string[] args)
        {
            StoredData.PlayerCount = 5;
            StoredData.PlayerLevel = 2;

            string personalityJson = File.ReadAllText(@"Data/personalities.json");
            JArray personalityArray = JArray.Parse(personalityJson);
            foreach(JToken personalityToken in personalityArray.Children())
            {
                Personality personality = JsonConvert.DeserializeObject<Personality>(personalityToken.ToString(), new PersonalityConverter());
                StoredData.Personalities.Add(personality);
            }

            string relationshipJson = File.ReadAllText(@"Data/relationships.json");
            JArray relationshipArray = JArray.Parse(relationshipJson);
            foreach(JToken relationshipToken in relationshipArray.Children())
            {
                Relationship relationship = JsonConvert.DeserializeObject<Relationship>(relationshipToken.ToString(), new RelationshipConverter());
                StoredData.Relationships.Add(relationship);
            }

            string monsterJson = File.ReadAllText(@"Data/monsters.json");
            JArray monsterArray = JArray.Parse(monsterJson);
            foreach(JToken monsterToken in monsterArray.Children())
            {
                Monster monster = JsonConvert.DeserializeObject<Monster>(monsterToken.ToString(), new MonsterConverter());
                StoredData.Monsters.Add(monster);
            }

            Encounter encounter = Encounter.CreateEncounter(EncounterDifficulty.Deadly);
        }
    }
}
