using DungeonLib;
using DungeonTool;
using DungeonTool.Monsters;
using DungeonTool.Monsters.Modifiers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonTool.Encounters
{
    public class Encounter
    {
        public List<Monster> Monsters;
        public InfernalCult InfernalCult;

        private Encounter() {
            Monsters = new List<Monster>();
        }

        /// <summary>
        /// Generates a random encounter
        /// </summary>
        /// <param name="difficulty">The desired encounter difficulty</param>
        /// <returns>A created encounter or null if no encounter could be created with given parameters</returns>
        public static Encounter CreateEncounter(EncounterDifficulty difficulty)
        {
            double experience = StoredData.PlayerExperience[StoredData.PlayerLevel - 1, (int)difficulty] * StoredData.PlayerCount;

            if(difficulty == EncounterDifficulty.Deadly)
            {
                experience *= 1.05; // Increase the cap on deadly encounters by 5%
            }

            Encounter encounter = new Encounter();

            // Get a random monster to base the rest of the encounter on
            Monster firstMonster = Monster.GetRandomMonster();
            firstMonster.SetRandomPersonality();
            firstMonster.SetRandomRelationShip();

            int count = 0;
            while(firstMonster.GetExperience() > experience)
            {
                if(count++ == 20)
                {
                    return null;
                }

                firstMonster = Monster.GetRandomMonster();
                firstMonster.SetRandomPersonality();
                firstMonster.SetRandomRelationShip();
            }

            encounter.Monsters.Add(firstMonster);

            // Add random monsters appropriate to the first monster until the encounter is sufficiently difficult
            while (encounter.GetEffectiveExperience() < experience)
            {
                if(encounter.Monsters.Count > 20)
                {
                    return null;
                }

                Monster newMonster = firstMonster.GetRandomAppropriateMonster();
                newMonster.SetRandomPersonality();
                newMonster.SetRandomRelationShip();

                encounter.Monsters.Add(newMonster);
            }

            encounter.Monsters.RemoveAt(encounter.Monsters.Count - 1); // Remove the last one because the while statement added one monster above the maximum allowed difficulty

            // 5% chance that the encounter is tied to a random infernal cult
            // Add the cult to a given monster and randomly to additional monsters that have access to the same cult
            if (Utility.Random.Next(100) > 94)
            {
                int monsterIndex = encounter.Monsters.FindIndex(monster => monster.InfernalCults.Count > 0);

                if(monsterIndex > -1)
                {
                    encounter.InfernalCult = GetRandomInfernalCult(encounter.Monsters[monsterIndex].InfernalCults);
                    encounter.Monsters[monsterIndex].InfernalCult = encounter.InfernalCult;

                    for (int i = 0; i < encounter.Monsters.Count; i++)
                    {
                        if (i != monsterIndex && encounter.Monsters[i].InfernalCults.Where(cult => cult.ID == encounter.InfernalCult.ID).ToArray().Length > 0 && Utility.Random.Next(100) > 94)
                        {
                            encounter.Monsters[i].InfernalCult = encounter.InfernalCult;
                        }
                    }
                }
            }

            return encounter;
        }

        /// <summary>
        /// Calculates the amount of effective experience for this encounter, which is used to calculate the difficulty
        /// </summary>
        /// <returns>The effective experience for the encounter</returns>
        public double GetEffectiveExperience()
        {
            int sum = GetExperience();
            
            if(Monsters.Count == 1)
            {
                return sum;
            }
            else if(Monsters.Count == 2)
            {
                return sum * 1.5;
            }
            else if(Monsters.Count < 7)
            {
                return sum * 2;
            }
            else if(Monsters.Count < 11)
            {
                return sum * 2.5;
            }
            else if(Monsters.Count < 15)
            {
                return sum * 3;
            }

            return sum * 4;
        }

        /// <summary>
        /// Calculates the amount of experience the encounter is worth
        /// </summary>
        /// <returns>The amount of experience the players get for completing the encounter</returns>
        public int GetExperience()
        {
            return Monsters.Sum(monster => monster.GetExperience());
        }

        private static InfernalCult GetRandomInfernalCult(List<InfernalCult> infernalCults)
        {
            if (infernalCults.Count > 0)
            {
                return infernalCults[Utility.Random.Next(infernalCults.Count)];
            }

            return null;
        }

        public override string ToString()
        {
            string result = "";

            foreach(Monster monster in Monsters)
            {
                result += $"{monster.ToString()}\n\n";
            }

            result += $"Player experience: {GetExperience()}\nEffective experience: {GetEffectiveExperience()}";

            return result;
        }
    }

    public enum EncounterDifficulty
    {
        Easy,
        Medium,
        Hard,
        Deadly
    }
}
