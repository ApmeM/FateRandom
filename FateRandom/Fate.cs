namespace FateRandom
{
    using FateRandom.RandomGenerator;
    using System;

    public class Fate
    {
        public static IRandomGenerator Random { get; set; } = new DefaultRandomGenerator();

        public static float NextFloat()
        {
            return (float)Random.NextDouble();
        }

        public static float NextFloat(float max)
        {
            return (float)Random.NextDouble() * max;
        }

        public static int NextInt(int max)
        {
            return (int)(Random.NextDouble() * max);
        }

        public static float NextAngle()
        {
            return (float)(Random.NextDouble() * Math.PI * 2);
        }

        public static int Range(int min, int max)
        {
            return (int)(Random.NextDouble() * (max - min) + min);
        }

        public static float Range(float min, float max)
        {
            return (float)(Random.NextDouble() * (max - min) + min);
        }

        public static double Range(double min, double max)
        {
            return (double)(Random.NextDouble() * (max - min) + min);
        }

        public static bool Chance(float percent)
        {
            return NextFloat() < percent;
        }

        public static bool Chance(int value)
        {
            return NextInt(100) < value;
        }

        public static T Choose<T>(T first, T second)
        {
            if (NextInt(2) == 0)
                return first;
            return second;
        }

        public static T Choose<T>(T first, T second, T third)
        {
            switch (NextInt(3))
            {
                case 0:
                    return first;
                case 1:
                    return second;
                default:
                    return third;
            }
        }

        public static T Choose<T>(T first, T second, T third, T fourth)
        {
            switch (NextInt(4))
            {
                case 0:
                    return first;
                case 1:
                    return second;
                case 2:
                    return third;
                default:
                    return fourth;
            }
        }

        public static T Choose<T>(params T[] list)
        {
            return list[NextInt(list.Length)];
        }
    }
}