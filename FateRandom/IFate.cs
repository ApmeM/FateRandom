using System.Collections.Generic;

namespace FateRandom
{
    public interface IFate
    {
        double NextDouble();
        double NextDouble(double max);
        float NextFloat();
        float NextFloat(float max);
        int NextInt(int max);
        float NextAngle();
        int Range(int min, int max);
        float Range(float min, float max);
        double Range(double min, double max);
        bool Chance(float percent);
        bool Chance(int value);
        T Choose<T>(T first, T second);
        T Choose<T>(T first, T second, T third);
        T Choose<T>(T first, T second, T third, T fourth);
        T Choose<T>(params T[] list);
        T Choose<T>(IList<T> list);
        string GenerateString(int size = 38);
        void Shuffle<T>(IList<T> list);
        void RandomItems<T>(IList<T> source, List<T> destination, int itemCount);
    }
}
