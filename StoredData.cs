using DungeonTool.Characters;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonTool
{
    public class StoredData
    {
        private static List<Monster> _monsters;
        private static List<Personality> _personalities;
        private static List<Relationship> _relationships;

        public static List<Monster> Monsters
        {
            get
            {
                if (_monsters == null)
                {
                    _monsters = new List<Monster>();
                }
                return _monsters;
            }
        }
        public static List<Personality> Personalities
        {
            get
            {
                if(_personalities == null)
                {
                    _personalities = new List<Personality>();
                }
                return _personalities;
            }
        }
        public static List<Relationship> Relationships
        {
            get
            {
                if(_relationships == null)
                {
                    _relationships = new List<Relationship>();
                }
                return _relationships;
            }
        }

        public static readonly int[,] PlayerExperience = new int[,]
        {
            { 25, 50, 75, 100 },        // Level 1
            { 50, 100, 150, 200 },      // Level 2
            { 75, 150, 225, 300 },      // Level 3
            { 125, 250, 375, 500 }      // Level 4
        };

        public static int PlayerCount;
        public static int PlayerLevel;
    }
}
