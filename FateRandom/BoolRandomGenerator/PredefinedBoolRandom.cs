namespace FateRandom.BoolRandomGenerator
{
    public class PredefinedBoolRandom : IBoolRandom
    {
        private readonly IRandomGenerator random;
        private readonly float[] probabilities;
        private int currentFailLength = 0;

        public PredefinedBoolRandom(IRandomGenerator random, params float[] probabilities)
        {
            this.random = random;
            this.probabilities = probabilities;
        }

        public bool Chance()
        {
            var result = random.NextDouble() <= probabilities[currentFailLength];
            currentFailLength = (currentFailLength+1) % probabilities.Length;
            return result;
        }
    }
}