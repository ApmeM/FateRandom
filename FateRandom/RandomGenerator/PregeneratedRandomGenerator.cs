using System;

namespace FateRandom
{
    public class PregeneratedRandomGenerator : KnownDataRandomGenerator
    {
        public PregeneratedRandomGenerator(int pregeneratedCount, int? seed = null)
        {
            var r = new Random(seed ?? Environment.TickCount);

            var data = new double[pregeneratedCount];
            for (var i = 0; i < data.Length; i++)
            {
                data[i] = r.NextDouble();
            }

            this.Init(data);
        }
    }
}
