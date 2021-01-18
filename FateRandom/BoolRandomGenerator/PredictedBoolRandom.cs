using System;

namespace FateRandom.BoolRandomGenerator
{
    public class PredictedBoolRandom : IBoolRandom
    {
        private readonly IRandomGenerator random;
        private readonly float[] probabilities;
        private int currentFailLength = 0;
        private static long[] factorials = new long[] { 1, 1, 2, 6, 24, 120, 720, 5040, 40320, 362880, 3628800 };
        private static long[,] pows = new long[,] { 
            { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024 },
            { 1, 3, 9, 27, 81, 243, 729, 2187, 6561, 19683, 59049 },
            { 1, 4, 16, 64, 256, 1024, 4096, 16384, 65536, 262144, 1048576 },
            { 1, 5, 25, 125, 625, 3125, 15625, 78125, 390625, 1953125, 9765625 },
            { 1, 6, 36, 216, 1296, 7776, 46656, 279936, 1679616, 10077696, 60466176 },
            { 1, 7, 49, 343, 2401, 16807, 117649, 823543, 5764801, 40353607, 282475249 },
            { 1, 8, 64, 512, 4096, 32768, 262144, 2097152, 16777216, 134217728, 1073741824 },
            { 1, 9, 81, 729, 6561, 59049, 531441, 4782969, 43046721, 387420489, 3486784401 },
            { 1, 10, 100, 1000, 10000, 100000, 1000000, 10000000, 100000000, 1000000000, 10000000000 }
        };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="random"></param>
        /// <param name="maxFailLength">must be between 1 and 10</param>
        /// <param name="expectedProbability">must be between 0 and 1</param>
        public PredictedBoolRandom(IRandomGenerator random, int maxFailLength, float expectedProbability)
        {
            this.random = random;
            this.probabilities = new float[maxFailLength + 2];
            var pz = 1 - expectedProbability;
            var l = maxFailLength;
            var koefs = new float[l + 1];

            koefs[0] = -pz / ((1 - pz) * factorials[l]);
            for (var i = 1; i <= l; i++)
            {
                koefs[i] = 1f / (factorials[l - i] * pows[l, i]);
            }

            var p = 1 - CalculateProbability(koefs);

            for (var i = 0; i < maxFailLength + 2; i++)
            {
                this.probabilities[i] = p + i * (1 - p) / maxFailLength;
            }
        }

        private float CalculateProbability(float[] koefs)
        {
            var left = 0f;
            var right = 1f;
            if (Math.Sign(Calculate(koefs, 0)) == Math.Sign(Calculate(koefs, 1))){
                throw new ArgumentException("Cant find solution for specified arguments.");
            }

            while (left <= right)
            {
                var mid = (left + right) / 2f;
                var midValue = Calculate(koefs, mid);
                if (Math.Abs(midValue) < 0.0001)
                {
                    return mid;
                }

                else if (midValue < 0)
                {
                    left = mid;
                }
                else
                {
                    right = mid;
                }
            }

            throw new ArgumentException("Cant find solution for specified arguments.");
        }

        private float Calculate(float[] koefs, float p)
        {
            var result = 0f;
            for (var i = 0; i < koefs.Length; i++)
            {
                result += (float)(koefs[i] * Math.Pow(p, i));
            }

            return result;
        }

        public bool Chance()
        {
            var result = random.NextDouble() <= probabilities[currentFailLength];
            currentFailLength++;
            if (result)
            {
                currentFailLength = 0;
            }

            return result;
        }
    }
}