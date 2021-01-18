namespace FateRandom
{
    public interface IRandomGenerator
    {
        int Seed { get; set; }
        double NextDouble();
    }
}
