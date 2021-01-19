using System;

namespace FateRandom.RandomGenerator
{
    public class PregeneratedRandomGenerator : IRandomGenerator
    {
        private double[] data;
        private int currentData;

        public PregeneratedRandomGenerator(int pregeneratedCount, int? seed = null)
        {
            var r = new Random(seed ?? Environment.TickCount);

            this.data = new double[pregeneratedCount];
            for (var i = 0; i < this.data.Length; i++)
            {
                this.data[i] = r.NextDouble();
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
