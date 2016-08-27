using MockingData.Generators;
using MockingData.Generators.Random;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MockingDataTests.Utils
{
    public class RandomHelpersTest
    {
        [Fact]
        public void RandomHelpers_RandomFromList_Returns_Random_Result()
        {
            // Assert
            var generator = new RandomGenerator();
            const int loops = 10000;
            var list = new List<TestClass>
            {
                new TestClass { Key = 1, ValueInt = 1 },
                new TestClass { Key = 2, ValueInt = 1 },
                new TestClass { Key = 3, ValueInt = 1 }
            };

            var resultList = list.Select(x => new { x.Key, Value = 0}).ToDictionary(x => x.Key, x => x.Value);
            var expectedAverage = loops/list.Count;
            var acceptedFailRange = expectedAverage*0.05;   // We expect the average to be within 90%, allowing 5% divergence on each side

            // Act
            for (var i = 0; i < loops; i++)
            {
                var randomVal = generator.RandomFromList(list);
                resultList[randomVal.Key]++;
            }

            // Assert
            foreach (var item in resultList)
            {
                Console.WriteLine($"Key {item.Key} has value {item.Value}");
                Assert.True(item.Value > expectedAverage - acceptedFailRange);
                Assert.True(item.Value < expectedAverage + acceptedFailRange);
            }
        }

        [Fact]
        public void RandomHelpers_RandomFromList_Returns_Random_Value_Distributed_Result()
        {
            // Assert
            var generator = new RandomGenerator();
            const int loops = 10000;
            var map = new Dictionary<string, int> { { "a", 1 }, { "b", 2 } };

            var dict = new Dictionary<int, int> {{1, 0}, {2, 0}, {3, 0}, {4, 0}, {5, 0}};

            for (var i = 0; i < loops; i++)
            {
                var next = generator.Next(1, 5);
                dict[next]++;
            }

            foreach (var item in dict)
            {
                Console.WriteLine($"Key {item.Key} has value {item.Value}");
            }


        }
    }

    public class TestClass
    {
        public int Key { get; set; }
        public int ValueInt { get; set; }
        public long ValueLong { get; set; }
        public double ValueDouble { get; set; }
    }
}
