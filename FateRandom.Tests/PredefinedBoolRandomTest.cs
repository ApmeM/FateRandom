using FateRandom.BoolRandomGenerator;
using FateRandom.RandomGenerator;
using NUnit.Framework;
using System;

namespace FateRandom.Tests
{
    [TestFixture]
    public class PredefinedBoolRandomTest
    {
        [Test]
        public void Chance_SimpleConfig_ShouldGenerateProperChance()
        {
            const float targetChance = 0.72f;
            var target = new PredefinedBoolRandom(new DefaultRandomGenerator(), targetChance);

            var successCount = 0;
            const int loopCount = 100000;
            for (var i = 0; i < loopCount; i++)
            {
                if (target.Chance())
                {
                    successCount++;
                }
            }

            Assert.AreEqual(targetChance, (float)successCount / loopCount, 0.01f);
        }

        [Test]
        public void Chance_ComplexConfig_ShouldGenerateProperChance()
        {
            var target = new PredefinedBoolRandom(new DefaultRandomGenerator(), 0.5f, 0.5f, 1f);

            var successCount = 0;
            const int loopCount = 100000;
            for (var i = 0; i < loopCount; i++)
            {
                if (target.Chance())
                {
                    successCount++;
                }
            }

            Assert.AreEqual(0.66f, (float)successCount / loopCount, 0.01f);
        }
    }
}
