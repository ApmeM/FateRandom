using System;

namespace FateRandom
{
    public class KnownDataRandomGenerator : IRandomGenerator
    {
        private double[] data;
        public int CurrentData;

        public KnownDataRandomGenerator(params double[] data)
        {
            this.Init(data);
        }

        protected void Init(double[] data){
            this.data = data;
            foreach (var d in data)
            {
                if (d >= 1 || d < 0)
                {
                    throw new ArgumentOutOfRangeException("data", d, "RandomGenerator should have values that is greater than or equal to 0.0, and less than 1.0.");
                }
            }
        }

        public double NextDouble()
        {
            var result = data[CurrentData];
            CurrentData = (CurrentData + 1) % data.Length;
            return result;
        }
    }
}
