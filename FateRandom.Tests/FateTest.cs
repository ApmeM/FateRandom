using FateRandom.BoolRandomGenerator;
using FateRandom.RandomGenerator;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace FateRandom.Tests
{
    [TestFixture]
    public class FateTest
    {
        [Test]
        public void Shuffle_KnownRandom_ReorderedList()
        {
            Fate.Random = new KnownDataRandomGenerator(0.5);
            var list = new List<int> { 1, 2, 3, 4, 5 };
            Fate.Shuffle(list);

            Assert.AreEqual(1, list[0]);
            Assert.AreEqual(4, list[1]);
            Assert.AreEqual(2, list[2]);
            Assert.AreEqual(5, list[3]);
            Assert.AreEqual(3, list[4]);
        }

        [Test]
        public void RandomItems_KnownRandom_RandomPart()
        {
            Fate.Random = new KnownDataRandomGenerator(0.5, 0, 0.9);
            var list = new List<int> { 1, 2, 3, 4, 5 };
            var result = new List<int> { 6, 7, 8 };
            Fate.RandomItems(list, result, 3);

            Assert.AreEqual(6, result[0]);
            Assert.AreEqual(7, result[1]);
            Assert.AreEqual(8, result[2]);
            Assert.AreEqual(3, result[3]);
            Assert.AreEqual(1, result[4]);
            Assert.AreEqual(5, result[5]);
        }

        [Test]
        public void GenerateString_KnownRandom_RandomPart()
        {
            Fate.Random = new KnownDataRandomGenerator(0, 0.5, 0.99);
            var result = Fate.GenerateString(7);

            Assert.AreEqual("ANZANZA", result);
        }
    }
}
