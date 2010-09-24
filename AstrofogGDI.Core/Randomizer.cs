using System;
using System.Collections.Generic;
using System.Text;

namespace AstrofogGDI.Core
{
    public class Randomizer
    {
        private static Random rand = new Random();
        public static Randomizer GetInstance()
        {
            return new Randomizer();
        }

        /// <summary>
        /// private constructor
        /// </summary>
        private Randomizer()
        {
        }
        public int Next()
        {
            return rand.Next();
        }
        public int Next(int minValue, int maxValue)
        {
            return rand.Next(minValue, maxValue);
        }
        public int Next(int maxValue)
        {
            return rand.Next(maxValue);
        }
        public double NextDouble()
        {
            return rand.NextDouble();
        }
    }
}
