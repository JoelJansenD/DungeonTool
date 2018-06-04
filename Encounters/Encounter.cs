using DungeonTool.Characters;
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
            encounter.Monsters.Add(firstMonster);

            while (encounter.GetEffectiveExperience() < experience)
            {
                Monster newMonster = firstMonster.GetRandomAppropriateMonster();
                newMonster.SetRandomPersonality();
                newMonster.SetRandomRelationShip();
                encounter.Monsters.Add(newMonster);
                Console.WriteLine(newMonster.ToString());
            }

            encounter.Monsters.RemoveAt(encounter.Monsters.Count - 1);

            Console.WriteLine($"Player experience: {experience}\nEffective experience: {encounter.GetEffectiveExperience()}");

            return encounter;
        }

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
