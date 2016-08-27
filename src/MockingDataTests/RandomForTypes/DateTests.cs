using System.Collections.Generic;
using System.Linq;
using NodaTime;
using Xunit;
using MockingData.Generators;
using MockingData.Generators.Random;

namespace MockingDataTests.RandomForTypes
{
    public class DateTests
    {
        [Fact]
        public void RandomGenerator_NextRandomDate_With_Interval_Should_Stay_In_Interval()
        {
            // Arrange
            var generator = new RandomGenerator();
            var minDate = new LocalDate(2000, 1, 1);
            var maxDate = new LocalDate(2000, 1, 31);
            var loops = 1000;

            // Act 
            var dateResult = new SortedDictionary<LocalDate, int>();

            for (var i = 0; i < loops; i++)
            {
                var date = generator.NextDate(minDate, maxDate);
                if (dateResult.ContainsKey(date))
                {
                    dateResult[date] += 1;
                }
                else
                {
                    dateResult.Add(date, 1);
                }
            }

            // Assert
            Assert.True(dateResult.Keys.Min() == minDate);
            Assert.True(dateResult.Keys.Max() == maxDate);
        }

        [Fact]
        public void RandomGenerator_NextRandomDate_With_Normal_Distribution_Should_Have_Majority_Within_One_StdDev()
        {
            // Arrange
            var generator = new RandomGenerator();
            var middleDate = new LocalDate(2000,1,15);
            var sampleDateCount = 1000;
            var stdDev = 1;
            var daySpread = 10;

            // The correct value for 1 std dev is 68.27%. But since we want this test to succeed,
            // we calculate that 60% should be within.
            var sampleAcceptancePercent = 0.6;
            var sampleDateAcceptanceCount = sampleDateCount * sampleAcceptancePercent;

            var minDate = middleDate.PlusDays(-stdDev * daySpread);
            var maxDate = middleDate.PlusDays(stdDev * daySpread);

            // Act 
            var dateResult = new SortedDictionary<LocalDate, int>();

            for (var i = 0; i < sampleDateCount; i++)
            {
                var date = generator.NextDate(middleDate, stdDev * daySpread);
                if (dateResult.ContainsKey(date))
                {
                    dateResult[date] += 1;
                }
                else
                {
                    dateResult.Add(date, 1);
                }
            }
            var daysInInterval = dateResult.Where(x => x.Key >= minDate && x.Key <= maxDate).Sum(x => x.Value);

            // Assert
            Assert.True(daysInInterval >= sampleDateAcceptanceCount);
        }
    }
}


