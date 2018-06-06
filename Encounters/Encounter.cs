using DungeonTool.Monsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonTool.Encounters
{
    public class Encounter
    {
        public List<Monster> Monsters;

        private Encounter() {
            Monsters = new List<Monster>();
        }

        /// <summary>
        /// Generates a random encounter
        /// </summary>
        /// <param name="difficulty">The desired encounter difficulty</param>
        /// <returns>A created encounter or null if no encounter could be created</returns>
        public static Encounter CreateEncounter(EncounterDifficulty difficulty)
        {
            double experience = StoredData.PlayerExperience[StoredData.PlayerLevel - 1, (int)difficulty] * StoredData.PlayerCount;

            if(difficulty == EncounterDifficulty.Deadly)
            {
                experience *= 1.05; // Increase the cap on deadly encounters by 5%
            }

            Encounter encounter = new Encounter();

            Monster firstMonster = Monster.GetRandomMonster();
            while(firstMonster.GetExperience() > experience)
            {
                firstMonster = Monster.GetRandomMonster();
            }

            if (firstMonster.InfernalCults.Count > 0 && Utility.Random.Next(100) > 94)
            {
                firstMonster.SetRandomInfernalCult();
            }

            encounter.Monsters.Add(firstMonster);
            Console.WriteLine(firstMonster.ToString());

            while (encounter.GetEffectiveExperience() < experience)
            {
                if(encounter.Monsters.Count > 20)
                {
                    return null;
                }

                Monster newMonster = firstMonster.GetRandomAppropriateMonster();
                newMonster.SetRandomPersonality();
                newMonster.SetRandomRelationShip();

                // Every monster has a 5% chance of being an honoured cultists
                if (Utility.Random.Next(100) > 94 && newMonster.InfernalCults.Count > 0)
                {
                    newMonster.SetRandomInfernalCult();
                }

                encounter.Monsters.Add(newMonster);
                Console.WriteLine(newMonster.ToString());
            }

            encounter.Monsters.RemoveAt(encounter.Monsters.Count - 1);

            Console.WriteLine($"Player experience: {experience}\nEffective experience: {encounter.GetEffectiveExperience()}");

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
    }

    public enum EncounterDifficulty
    {
        Easy,
        Medium,
        Hard,
        Deadly
    }
}
