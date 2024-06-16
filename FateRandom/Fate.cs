namespace FateRandom
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Fate : IFate
    {
        public static Fate GlobalFate = new Fate(new DefaultRandomGenerator());

        public Fate(IRandomGenerator random)
        {
            this.Random = random;
        }

        public IRandomGenerator Random;

        public double NextDouble()
        {
            return Random.NextDouble();
        }

        public double NextDouble(double max)
        {
            return Random.NextDouble() * max;
        }

        public float NextFloat()
        {
            return (float)Random.NextDouble();
        }

        public float NextFloat(float max)
        {
            return (float)Random.NextDouble() * max;
        }

        public int NextInt(int max)
        {
            return (int)(Random.NextDouble() * max);
        }

        public float NextAngle()
        {
            return (float)(Random.NextDouble() * Math.PI * 2);
        }

        public int Range(int min, int max)
        {
            return (int)(Random.NextDouble() * (max - min) + min);
        }

        public float Range(float min, float max)
        {
            return (float)(Random.NextDouble() * (max - min) + min);
        }

        public double Range(double min, double max)
        {
            return (double)(Random.NextDouble() * (max - min) + min);
        }

        public bool Chance(float percent)
        {
            return NextFloat() < percent;
        }

        public bool Chance(int value)
        {
            return NextInt(100) < value;
        }

        public T Choose<T>(T first, T second)
        {
            if (NextInt(2) == 0)
                return first;
            return second;
        }

        public T Choose<T>(T first, T second, T third)
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

        public T Choose<T>(T first, T second, T third, T fourth)
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

        public T Choose<T>(params T[] list)
        {
            return list[NextInt(list.Length)];
        }

        public T Choose<T>(IList<T> list)
        {
            return list[NextInt(list.Count)];
        }

        public string GenerateString(int size = 38)
        {
            var builder = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Range(65, 65 + 26));
                builder.Append(ch);
            }
            return builder.ToString();
        }

        public void Shuffle<T>(IList<T> list)
        {
            var n = list.Count;
            while (n > 1)
            {
                n--;
                int k = Range(0, n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public void RandomItems<T>(IList<T> source, List<T> destination, int itemCount)
        {
            if (itemCount >= source.Count)
            {
                destination.AddRange(source);
                return;
            }

            var set = new HashSet<T>();
            while (set.Count != itemCount)
            {
                var item = Choose(source);
                set.Add(item);
            }

            destination.AddRange(set);
        }
    }
}
