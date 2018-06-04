using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonTool.Characters
{
    public class Monster
    {
        private List<Monster> _monsters;

        public Species Species;
        public Subspecies Subspecies;

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
        public Personality Personality;
        public Relationship Relationship;

        public List<string> MonsterIDs;
        public string ID;
        public string Name;
        public string CR;

        public Monster()
        {
            MonsterIDs = new List<string>();
            Personalities = new List<Personality>();
            Relationships = new List<Relationship>();
        }

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

        public Monster GetRandomAppropriateMonster()
        {
            return Monsters[Utility.Random.Next(Monsters.Count)];
        }

        public static Monster GetRandomMonster()
        {
            return StoredData.Monsters[Utility.Random.Next(StoredData.Monsters.Count)];
        }

        public void SetRandomPersonality()
        {
            if(Personalities.Count > 0)
            {
                Personality = Personalities[Utility.Random.Next(Personalities.Count)];
            }
        }

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
