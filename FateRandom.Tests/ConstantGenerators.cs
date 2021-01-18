using NUnit.Framework;
using System;

namespace FateRandom.Tests
{
    [TestFixture]
    public class ConstantGenerators
    {
        [Test]
        public void Factorials()
        {
            var factorials = new long[11];
            factorials[0] = 1;
            for (var i = 1; i < factorials.Length; i++)
            {
                factorials[i] = factorials[i - 1] * i;
            }

            var str = string.Join(",", factorials);
            Assert.AreEqual("1,1,2,6,24,120,720,5040,40320,362880,3628800", str);
        }

        [Test]
        public void Pows()
        {
            var strings = new string[11];
            for (var i = 0; i < 11; i++)
            {
                var pows = new long[11];
                for (var j = 0; j < pows.Length; j++)
                {
                    pows[j] = (long)Math.Pow(i, j);
                }

                strings[i] = string.Join(",", pows);
            }

            var str = $"{{{string.Join("},{", strings)}}}";
            Assert.AreEqual("{1,0,0,0,0,0,0,0,0,0,0},{1,1,1,1,1,1,1,1,1,1,1},{1,2,4,8,16,32,64,128,256,512,1024},{1,3,9,27,81,243,729,2187,6561,19683,59049},{1,4,16,64,256,1024,4096,16384,65536,262144,1048576},{1,5,25,125,625,3125,15625,78125,390625,1953125,9765625},{1,6,36,216,1296,7776,46656,279936,1679616,10077696,60466176},{1,7,49,343,2401,16807,117649,823543,5764801,40353607,282475249},{1,8,64,512,4096,32768,262144,2097152,16777216,134217728,1073741824},{1,9,81,729,6561,59049,531441,4782969,43046721,387420489,3486784401},{1,10,100,1000,10000,100000,1000000,10000000,100000000,1000000000,10000000000}", str);
        }
    }
}
