namespace FateRandom.RandomGenerator
{
    public class KnownDataRandomGenerator : IRandomGenerator
    {
        private readonly double[] data;
        private int currentData;

        public KnownDataRandomGenerator(params double[] data)
        {
            this.data = data;
        }

        public double NextDouble()
        {
            var result = data[currentData];
            currentData = (currentData + 1) % data.Length;
            return result;
        }
    }
}
