using FateRandom.BoolRandomGenerator;
using FateRandom.RandomGenerator;
using NUnit.Framework;
using System;

namespace FateRandom.Tests
{
    [TestFixture]
    public class DefaultBoolRandomTest
    {
        [Test]
        public void Chance_RandomResult_ShouldGenerateProperChance()
        {
            const float targetChance = 0.72f;
            var target = new DefaultBoolRandom(new DefaultRandomGenerator(), targetChance);

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
    }
}
