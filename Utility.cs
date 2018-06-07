using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonTool
{
    class Utility
    {
        private static Random _random;
        public static Random Random {
            get
            {
                if(_random == null)
                {
                    _random = new Random();
                }

                return _random;
            }
            private set
            {
                _random = value;
            }
        }

        /// <summary>
        /// Replace the first occurance of a string inside another
        /// </summary>
        /// <param name="input">The string to be altered</param>
        /// <param name="search">The string that test against the main string</param>
        /// <param name="replace">The string to replace the first occurance by</param>
        /// <returns></returns>
        public static string ReplaceFirstString(string input, string search, string replace)
        {
            int position = input.IndexOf(search);
            if (position < 0)
            {
                return input;
            }

            return input.Substring(0, position) + replace + input.Substring(position + search.Length);
        }

        /// <summary>
        /// Rolls dice along the XdY format
        /// </summary>
        /// <param name="input">A string following the XdY format</param>
        /// <returns></returns>
        public static int RollDice(string input)
        {
            string[] rollParams = input.Split('d');

            int dieCount = Convert.ToInt32(rollParams[0]);
            int dieSize = Convert.ToInt32(rollParams[1]);

            int total = 0;
            for (int i = 0; i < dieCount; i++)
            {
                total += Random.Next(1, dieSize + 1);
            }

            return total;
        }

    }
}
