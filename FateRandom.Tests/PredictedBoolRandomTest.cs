using FateRandom.BoolRandomGenerator;
using FateRandom.RandomGenerator;
using NUnit.Framework;
using System;

namespace FateRandom.Tests
{
    [TestFixture]
    public class PredictedBoolRandomTest
    {
        [Test]
        public void Chance_RandomResult_ShouldGenerateProperChanceAndFailsInARow()
        {
            const float targetChance = 0.72f;
            const int limitMaxFailsInARow = 2;
            var target = new PredictedBoolRandom(new DefaultRandomGenerator(), limitMaxFailsInARow, targetChance);

            var successCount = 0;
            var maxFailsInARow = 0;
            var currentFailsInARow = 0;
            const int loopCount = 100000;
            for (var i = 0; i < loopCount; i++)
            {
                if (target.Chance())
                {
                    successCount++;
                    maxFailsInARow = Math.Max(currentFailsInARow, maxFailsInARow);
                    currentFailsInARow = 0;
                }
                else
                {
                    currentFailsInARow++;
                }
            }

            Assert.LessOrEqual(maxFailsInARow, limitMaxFailsInARow);
            Assert.AreEqual(targetChance, (float)successCount / loopCount, 0.01f);
        }

        [Test]
        public void Chance_NotPossibleConditions_ShouldFail()
        {
            const float targetChance = 0.01f;
            const int limitMaxFailsInARow = 2;
            Assert.Throws<ArgumentException>(() => new PredictedBoolRandom(new DefaultRandomGenerator(), limitMaxFailsInARow, targetChance));
        }

        //[Test]
        //public void Chance_LargeNumbers_ShouldSuccess()
        //{
        //    const float targetChance = 0.40f;
        //    const int limitMaxFailsInARow = 9;
        //    var target = new PredictedBoolRandom(new DefaultRandomGenerator(), limitMaxFailsInARow, targetChance);

        //    var successCount = 0;
        //    var maxFailsInARow = 0;
        //    var currentFailsInARow = 0;
        //    const int loopCount = 100000;
        //    for (var i = 0; i < loopCount; i++)
        //    {
        //        if (target.Chance())
        //        {
        //            successCount++;
        //            maxFailsInARow = Math.Max(currentFailsInARow, maxFailsInARow);
        //            currentFailsInARow = 0;
        //        }
        //        else
        //        {
        //            currentFailsInARow++;
        //        }
        //    }

        //    Assert.LessOrEqual(maxFailsInARow, limitMaxFailsInARow);
        //    Assert.AreEqual(targetChance, (float)successCount / loopCount, 0.01f);
        //}
    }
}
