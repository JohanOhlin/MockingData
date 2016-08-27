using System;
using System.Collections;
using System.Collections.Generic;
using MockingData.Generators.Random.Interfaces;

namespace MockingData.Generators.Random.Extensions
{
    public static class RandomListExtensions
    {
        public static T RandomFromMap<T>(this IDictionary<T, int> map, IRandomGenerator generator = null)
        {
            if (generator == null) {
                generator = new RandomGenerator();
            }
            return generator.RandomFromMap(map);
        }

        public static T RandomFromMap<T>(this IDictionary<T, long> map, IRandomGenerator generator = null)
        {
            if (generator == null)
            {
                generator = new RandomGenerator();
            }
            return generator.RandomFromMap(map);
        }

        public static T RandomFromMap<T>(this IDictionary<T, double> map, IRandomGenerator generator = null)
        {
            if (generator == null)
            {
                generator = new RandomGenerator();
            }
            return generator.RandomFromMap(map);
        }

        public static T RandomFromList<T>(this IList<T> list, IRandomGenerator generator = null)
        {
            if (generator == null)
            {
                generator = new RandomGenerator();
            }
            return generator.RandomFromList(list);
        }

        public static T RandomFromListUsingValueDistribution<T>(this IList<T> list, Func<T, int> expressionForDistribution, IRandomGenerator generator = null)
        {
            if (generator == null)
            {
                generator = new RandomGenerator();
            }
            return generator.RandomFromListUsingValueDistribution(list, expressionForDistribution);
        }

        public static T RandomFromListUsingValueDistribution<T>(this IList<T> list, Func<T, long> expressionForDistribution, IRandomGenerator generator = null)
        {
            if (generator == null)
            {
                generator = new RandomGenerator();
            }
            return generator.RandomFromListUsingValueDistribution(list, expressionForDistribution);
        }

        public static T RandomFromListUsingValueDistribution<T>(this IList<T> list, Func<T, double> expressionForDistribution, IRandomGenerator generator = null)
        {
            if (generator == null)
            {
                generator = new RandomGenerator();
            }
            return generator.RandomFromListUsingValueDistribution(list, expressionForDistribution);
        }

        public static void ShuffleList(this IList list, IRandomGenerator generator = null)
        {
            if (generator == null)
            {
                generator = new RandomGenerator();
            }
            generator.ShuffleList(list);
        }
    }
}
