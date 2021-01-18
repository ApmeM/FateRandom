namespace FateRandom.BoolRandomGenerator
{
    public class DefaultBoolRandom : IBoolRandom
    {
        private readonly IRandomGenerator random;
        private readonly float probability;

        public DefaultBoolRandom(IRandomGenerator random, float probability)
        {
            this.random = random;
            this.probability = probability;
        }

        public bool Chance()
        {
            return random.NextDouble() < probability;
        }
    }
}