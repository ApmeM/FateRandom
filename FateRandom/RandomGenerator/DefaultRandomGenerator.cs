using System;

namespace FateRandom.RandomGenerator
{
    public class DefaultRandomGenerator : IRandomGenerator
    {
        private Random r;
        private int seed;
        public int Seed { get => seed; set { seed = value; r = new Random(seed); } }
        public DefaultRandomGenerator(int? seed = null)
        {
            this.Seed = seed ?? Environment.TickCount;
        }

        public double NextDouble()
        {
            return r.NextDouble();
        }
    }
}
