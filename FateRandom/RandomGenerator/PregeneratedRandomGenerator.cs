using System;

namespace FateRandom.RandomGenerator
{
    public class PregeneratedRandomGenerator : IRandomGenerator
    {
        private Random r;
        private int seed;
        private double[] data;
        private int currentData;
        public int Seed
        {
            get => seed; 
            set
            {
                seed = value;
                r = new Random(seed);
                Generate();
            }
        }

        public PregeneratedRandomGenerator(int pregeneratedCount, int? seed = null)
        {
            this.data = new double[pregeneratedCount];
            this.Seed = seed ?? Environment.TickCount;
        }

        private void Generate()
        {
            for (var i = 0; i < data.Length; i++)
            {
                data[i] = r.NextDouble();
            }
        }

        public double NextDouble()
        {
            var result = data[currentData];
            currentData = (currentData + 1) % data.Length;
            return result;
        }
    }
}
