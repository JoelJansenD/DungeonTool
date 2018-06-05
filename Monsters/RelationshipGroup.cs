using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonTool.Monsters
{
    public class RelationshipGroup
    {
        public string Type;
        public List<Relationship> Relationships;

        public RelationshipGroup()
        {
            Relationships = new List<Relationship>();
        }
    }
}
