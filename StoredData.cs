using DungeonTool.Monsters;
using DungeonTool.Monsters.Modifiers;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonTool
{
    public class StoredData
    {
        private static List<InfernalCult> _infernalCults;
        private static List<InfernalCultGroup> _infernalCultGroups;
        private static List<Monster> _monsters;
        private static List<Personality> _personalities;
        private static List<PersonalityGroup> _personalityGroups;
        private static List<Relationship> _relationships;
        private static List<RelationshipGroup> _relationshipGroups;

        public static List<InfernalCult> InfernalCults
        {
            get
            {
                if (_infernalCults == null)
                {
                    _infernalCults = new List<InfernalCult>();
                }
                return _infernalCults;
            }
        }
        public static List<InfernalCultGroup> InfernalCultGroups
        {
            get
            {
                if (_infernalCultGroups == null)
                {
                    _infernalCultGroups = new List<InfernalCultGroup>();
                }
                return _infernalCultGroups;
            }
        }
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
            private set {
                _monsters = value;
            }
        }
        public static List<Personality> Personalities
        {
            get
            {
                if (_personalities == null)
                {
                    _personalities = new List<Personality>();
                }
                return _personalities;
            }
        }
        public static List<PersonalityGroup> PersonalityGroups {
            get
            {
                if (_personalityGroups == null)
                {
                    _personalityGroups = new List<PersonalityGroup>();
                }
                return _personalityGroups;
            }
        }
        public static List<Relationship> Relationships
        {
            get
            {
                if (_relationships == null)
                {
                    _relationships = new List<Relationship>();
                }
                return _relationships;
            }
        }
        public static List<RelationshipGroup> RelationshipGroups {
            get{
                if(_relationshipGroups == null)
                {
                    _relationshipGroups = new List<RelationshipGroup>();
                }
                return _relationshipGroups;
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
