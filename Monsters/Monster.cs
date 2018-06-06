using DungeonTool.Monsters.Modifiers;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonTool.Monsters
{
    public class Monster
    {
        private List<Monster> _monsters;

        public Species Species;
        public Subspecies Subspecies;

        public List<InfernalCult> InfernalCults;
        public List<Monster> Monsters {
            get
            {
                if(_monsters == null)
                {
                    _monsters = new List<Monster>();
                    foreach(string id in MonsterIDs)
                    {
                        _monsters.Add(StoredData.Monsters.Find(monster => monster.ID == id));
                    }
                }
                return _monsters;
            }
        }
        public List<Personality> Personalities;
        public List<Relationship> Relationships;
        public InfernalCult InfernalCult;
        public Personality Personality;
        public Relationship Relationship;

        public List<string> MonsterIDs;
        public string ID;
        public string Name;
        public string CR;

        public Monster()
        {
            InfernalCults = new List<InfernalCult>();
            MonsterIDs = new List<string>();
            Personalities = new List<Personality>();
            Relationships = new List<Relationship>();
        }

        /// <summary>
        /// Returns the amount of experience a monster gives upon being defeated based on their challnge rating
        /// </summary>
        /// <returns>The amount of experience the monster is worth</returns>
        public int GetExperience()
        {
            switch (CR)
            {
                case "0":
                    return 10;
                case "1/8":
                    return 25;
                case "1/4":
                    return 50;
                default:
                    return 0;
            }
        }

        /// <summary>
        /// Returns a random monster appropriate to appear alongside this monster
        /// </summary>
        /// <returns>A random monster</returns>
        public Monster GetRandomAppropriateMonster()
        {
            return Monsters[Utility.Random.Next(Monsters.Count)];
        }

        /// <summary>
        /// Returns a random monster
        /// </summary>
        /// <returns>A random monster</returns>
        public static Monster GetRandomMonster()
        {
            return StoredData.Monsters[Utility.Random.Next(StoredData.Monsters.Count)];
        }

        public void SetRandomInfernalCult()
        {
            if(InfernalCults.Count > 0)
            {
                InfernalCult = InfernalCults[Utility.Random.Next(InfernalCults.Count)];
            }
        }

        /// <summary>
        /// Sets a random personality for the monster, provided that it has personalities available
        /// </summary>
        public void SetRandomPersonality()
        {
            if(Personalities.Count > 0)
            {
                Personality = Personalities[Utility.Random.Next(Personalities.Count)];
            }
        }

        /// <summary>
        /// Sets a random relation for the monster, provided that it has relationships available
        /// </summary>
        public void SetRandomRelationShip()
        {
            if(Relationships.Count > 0)
            {
                Relationship = Relationships[Utility.Random.Next(Relationships.Count)];
            }
        }

        public override string ToString()
        {
            string result = $"{Name}, {Species} ";
            
            if(Subspecies != Subspecies.none)
            {
                result += $"({Subspecies}) ";
            }

            result += $"- {CR} ";

            if(Personality != null)
            {
                result += $" - {Personality.ToString()}";
            }

            if(Relationship != null)
            {
                result += $" - {Relationship.Description}";
            }

            if(InfernalCult != null)
            {
                result += $" - {InfernalCult.Name}";
            }

            return result;
        }
    }

    public enum Species
    {
        aberration,
        beast,
        goonie,
        humanoid
    }

    public enum Subspecies
    {
        elf,
        goblinoid,
        human,
        none
    }
}
