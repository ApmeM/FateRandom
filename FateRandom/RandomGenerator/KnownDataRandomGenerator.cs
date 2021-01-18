namespace FateRandom.RandomGenerator
{
    public class KnownDataRandomGenerator : IRandomGenerator
    {
        public int Seed { get; set; }
        private readonly double[] data;
        private int currentData;

        public KnownDataRandomGenerator(params double[] data)
        {
            this.data = data;
        }

        public double NextDouble()
        {
            currentData = (currentData + 1) % data.Length;
            return data[currentData];
        }
    }
}
