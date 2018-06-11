using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonTool.Monsters.Modifiers
{
    public class DemonicBeing
    {
        public List<string> Bonds;
        public List<string> Features;
        public List<string> Flaws;
        public List<string> Ideals;
        public List<string> Traits;

        public DemonicBeing()
        {
            Bonds = new List<string>();
            Features = new List<string>();
            Flaws = new List<string>();
            Ideals = new List<string>();
            Traits = new List<string>();
        }
    }
}
