using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MockingData.Generators.Random.Interfaces;
using NodaTime;

namespace MockingData.Generators.Random
{
    public partial class RandomGenerator : IRandomGenerator
    {
        /* Some reading 
            http://blogs.msdn.com/b/pfxteam/archive/2009/02/19/9434171.aspx
        */
              
        private static readonly System.Security.Cryptography.RandomNumberGenerator RandomBytes = System.Security.Cryptography.RandomNumberGenerator.Create();
        private static readonly object LockRandomBytes = new object();

        private static System.Random _random;
        private static readonly object LockRandom = new object();

        /// <summary>
        /// Instantiate the random generator
        /// </summary>
        public RandomGenerator()
        {
            var buffer = new byte[4];
            lock (LockRandomBytes)
            {
                RandomBytes.GetBytes(buffer);
            }
            lock (LockRandom)
            {
                _random = new System.Random(BitConverter.ToInt32(buffer, 0));
            }
        }

        /// <summary>
        ///     Returns random int values
        /// </summary>
        /// <returns></returns>
        public int Next()
        {
            lock (LockRandom)
            {
                return _random.Next();
            }
        }

        /// <summary>
        ///     Returns random int values between (and including) min and max
        /// </summary>
        /// <param name="min">Lowest random value</param>
        /// <param name="max">Highest random value</param>
        /// <returns></returns>
        public int Next(int min, int max)
        {
            if (min > max)
                throw new ArgumentOutOfRangeException("Min can't be greater than max");
            if (min == max)
                return min;

            int nextValue = 0;
            lock (LockRandom)
            {
                // The normal random.Next doesn"t include max but can return max
                nextValue = _random.Next(min, max + 1);
            }

            // Next value has to be within bounds, or we get a new value
            while (nextValue == (max + 1))
            {
                nextValue = _random.Next(min, max + 1);
            }
            return nextValue;
        }

        /// <summary>
        ///     Returns a random long value
        /// </summary>
        /// <returns></returns>
        public long NextLong()
        {
            var buf = new byte[8];
            lock (LockRandom)
            {
                _random.NextBytes(buf);
            }
            
            return Convert.ToInt64(buf);
        }

        /// <summary>
        ///     Returns a random long value
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public long NextLong(long min, long max)
        {
            var buf = new byte[8];
            lock (LockRandom)
            {
                _random.NextBytes(buf);
            }
            
            var longRand = BitConverter.ToInt64(buf, 0);
            return (Math.Abs(longRand % (max - min)) + min);
        }

        /// <summary>
        ///     Returns a random double 
        /// </summary>
        /// <returns></returns>
        public double NextDouble()
        {
            lock (LockRandom)
            {
                return _random.NextDouble();
            }
        }

        /// <summary>
        ///     Returns a random double
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public double NextDouble(double min, double max)
        {
            lock (LockRandom)
            {
                return min + _random.NextDouble() * (max - min);
            }

        }

        /// <summary>
        ///     Returns a random true or false value
        /// </summary>
        /// <returns></returns>
        public bool NextBoolean()
        {
            return Next(0,1) > 0;
        }

        /// <summary>
        /// Returns a random Hex number of the given length
        /// </summary>
        /// <param name="digits">how many hex digits to return</param>
        /// <returns></returns>
        public string NextHexNumber(int digits)
        {
            var result = new StringBuilder();
            for (int i = 0; i < digits; i++)
            {
                var newNumber = Next(0, 15).ToString("X");
                result.Append(newNumber);
            }

            return result.ToString();
        }


        /// <summary>
        ///   Generates normally distributed numbers. 
        /// </summary>
        /// <param name="meanValue">Mean of the distribution</param>
        /// <param name="standardDeviation">Standard deviation</param>
        /// <returns>Normally distributed number</returns>
        public double NextNormallyDistributedNumber(double meanValue = 0, double standardDeviation = 1)
        {
            double d1 = 0.0;
            double d2 = 0.0;
            lock (LockRandom)
            {
                d1 = _random.NextDouble();
                d2 = _random.NextDouble();
            }
            
            var normalizedRandomStandardValue = Math.Sqrt(-2.0 * Math.Log(d1)) * Math.Sin(2.0 * Math.PI * d2);

            var randomStandardValue = meanValue + standardDeviation * normalizedRandomStandardValue;

            return randomStandardValue;
        }

        /// <summary>
        ///     Generates a random NodaTime date based upon a linear distribution where all values, between min
        ///     and max, have an equal chance of being selected.
        /// </summary>
        /// <param name="minDate"></param>
        /// <param name="maxDate"></param>
        /// <returns></returns>
        public LocalDate NextDate(LocalDate minDate, LocalDate maxDate)
        {
            var diff = Period.Between(minDate, maxDate);
            var randDateAdd = Next(0, diff.Days);
            return minDate.PlusDays(randDateAdd);
        }

        /// <summary>
        ///     Generates a random NodaTime date based upon an central average date and a standard deviation. 
        ///     With a standard deviation of 10:
        ///     * 68.27% of all dates will be within average date +- 10 days.
        ///     * 95.45% of all dates will be within average date +- 20 days.
        ///     * 99.73% of all dates will be within average date +- 30 days.
        /// </summary>
        /// <param name="averageDate">The average date used for calculation</param>
        /// <param name="standardDeviation">How spread the dates will be</param>
        /// <returns></returns>
        public LocalDate NextDate(LocalDate averageDate, double standardDeviation = 10)
        {
            var newDateDiff = (int)NextNormallyDistributedNumber(0, standardDeviation);
            return averageDate.PlusDays(newDateDiff);
        }

        /// <summary>
        /// Creates a random string of given length using the characters specified in argument
        /// </summary>
        /// <param name="length">How long the random string should be</param>
        /// <param name="availableCharacters">What characters to use in the random string</param>
        /// <returns></returns>
        public string RandomString(int length, char[] availableCharacters)
        {
            var identifier = new char[length];
            var randomData = new byte[length];

            lock (LockRandomBytes)
            {
                RandomBytes.GetBytes(randomData);
            }

            for (var idx = 0; idx < identifier.Length; idx++)
            {
                var pos = randomData[idx] % availableCharacters.Length;
                identifier[idx] = availableCharacters[pos];
            }

            return new string(identifier);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="inner"></param>
        /// <param name="minCount"></param>
        /// <param name="maxCount"></param>
        /// <returns></returns>
        public IEnumerable<T> CreateListRandomLength<T>(Func<T> inner, int minCount = 1, int maxCount = 10)
        {
            if (maxCount < 0) maxCount = 0;
            if (minCount < 0) minCount = 0;
            if (minCount > maxCount) minCount = maxCount;
            var objectCount = Next(minCount, maxCount);

            var objectList = new List<T>();
            for (var i = 0; i < objectCount; i++)
            {
                objectList.Add(inner());
            }

            return objectList;
        }


        /// <summary>
        /// Returns numbersToReturn unique random numbers from 1 to maxNumber (both inclusive). 
        /// </summary>
        /// <param name="maxNumber">Maximum number possible. Has to be 1 or greater.</param>
        /// <param name="numbersToReturn">How many numbers to return. Has to be 1 or greater.</param>
        /// <returns></returns>
        public IList<int> UniqueNumbers(int maxNumber, int numbersToReturn)
        {
            if (maxNumber < 1)
                throw new ArgumentException("MaxNumber has to be 1 or greater");
            if (numbersToReturn < 1)
                throw new ArgumentException("NumbersToReturn has to be 1 or greater");

            if (maxNumber < numbersToReturn)
                throw new ArgumentException($"MaxNumber ({maxNumber}) has to be greater than NumbersToReturn ({numbersToReturn})");

            var result = new List<int>();
            var sorted = new SortedSet<int>();

            for (var i = 0; i < numbersToReturn; i++)
            {
                int nextSuggestedNumber = 0;
                nextSuggestedNumber = Next(1, maxNumber - i);

                foreach (var q in sorted)
                    if (nextSuggestedNumber >= q) nextSuggestedNumber++;

                result.Add(nextSuggestedNumber);
                sorted.Add(nextSuggestedNumber);
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="map"></param>
        /// <returns></returns>
        public T RandomFromMap<T>(IDictionary<T, int> map)
        {
            if (map == null || !map.Any()) return default(T);

            var maxValue = Convert.ToInt64(map.Sum(x => x.Value));
            var selectedValue = NextLong(1, maxValue);
            long loopValue = 0;
            foreach (var item in map)
            {
                loopValue += item.Value;
                if (selectedValue <= loopValue)
                {
                    return item.Key;
                }
            }
            return map.Last().Key;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="map"></param>
        /// <returns></returns>
        public T RandomFromMap<T>(IDictionary<T, long> map)
        {
            if (map == null || !map.Any()) return default(T);

            var maxValue = map.Sum(x => x.Value);
            var selectedValue = NextLong(1, maxValue);
            long loopValue = 0;
            foreach (var item in map)
            {
                loopValue += item.Value;
                if (selectedValue <= loopValue)
                {
                    return item.Key;
                }
            }
            return map.Last().Key;
        }

        /// <summary>
        /// Returns a random key from the dictionary where the value is used to give weight in the 
        /// random selection
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="map"></param>
        /// <returns></returns>
        public T RandomFromMap<T>(IDictionary<T, double> map)
        {
            if (map == null || !map.Any()) return default(T);

            var maxValue = map.Sum(x => x.Value);
            if (maxValue <= double.MaxValue)
            {
                var selectedValue = NextDouble(1, maxValue);
                double loopValue = 0;
                foreach (var item in map)
                {
                    loopValue += item.Value;
                    if (selectedValue <= loopValue)
                    {
                        return item.Key;
                    }
                }
                return map.Last().Key;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        /// <summary>
        /// Returns a random item in the list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public T RandomFromList<T>(IList<T> list)
        {
            if (list == null || !list.Any()) return default(T);

            try
            {
                var nextIndex = Next(0, list.Count - 1);
                //Console.WriteLine($"|0<{nextIndex}<{list.Count}|");

                var item = list[nextIndex];
                return item;
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
            return list[0];
        }

        /// <summary>
        /// Returns a random item in the list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public T RandomFromList<T>(IEnumerable<T> list)
        {
            return RandomFromList(list.ToList());
        }

        /// <summary>
        /// Returns a random value from list. The int-property used as expression will give a weight to each item. The higher the 
        /// weight the higher chance the value will be randomly selected.
        /// 
        /// Todo: This is not an efficient way of doing it and should be rewritten
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="expressionForDistribution">Selection of int value to use as value</param>
        /// <returns></returns>
        public T RandomFromListUsingValueDistribution<T>(IList<T> list, Func<T, int> expressionForDistribution)
        {
            var map = list.ToDictionary(x => x, expressionForDistribution);
            return RandomFromMap(map);
        }

        /// <summary>
        /// Returns a random value from list. The int-property used as expression will give a weight to each item. The higher the 
        /// weight the higher chance the value will be randomly selected.
        /// 
        /// Todo: This is not an efficient way of doing it and should be rewritten
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="expressionForDistribution">Selection of int value to use as value</param>
        /// <returns></returns>
        public T RandomFromListUsingValueDistribution<T>(IEnumerable<T> list, Func<T, int> expressionForDistribution)
        {
            return RandomFromListUsingValueDistribution(list.ToList(), expressionForDistribution);
        }

        /// <summary>
        /// Returns a random value from list. The long-property used as expression will give a weight to each item. The higher the 
        /// weight the higher chance the value will be randomly selected.
        /// 
        /// Todo: This is not an efficient way of doing it and should be rewritten
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="expressionForDistribution">Selection of long value to use as value</param>
        /// <returns></returns>
        public T RandomFromListUsingValueDistribution<T>(IList<T> list, Func<T, long> expressionForDistribution)
        {
            var map = list.ToDictionary(x => x, expressionForDistribution);
            return RandomFromMap(map);
        }

        /// <summary>
        /// Returns a random value from list. The long-property used as expression will give a weight to each item. The higher the 
        /// weight the higher chance the value will be randomly selected.
        /// 
        /// Todo: This is not an efficient way of doing it and should be rewritten
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="expressionForDistribution">Selection of long value to use as value</param>
        /// <returns></returns>
        public T RandomFromListUsingValueDistribution<T>(IEnumerable<T> list, Func<T, long> expressionForDistribution)
        {
            return RandomFromListUsingValueDistribution(list.ToList(), expressionForDistribution);
        }

        /// <summary>
        /// Returns a random value from list. The double-property used as expression will give a weight to each item. The higher the 
        /// weight the higher chance the value will be randomly selected.
        /// 
        /// Todo: This is not an efficient way of doing it and should be rewritten
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="expressionForDistribution">Selection of double value to use as value</param>
        /// <returns></returns>
        public T RandomFromListUsingValueDistribution<T>(IList<T> list, Func<T, double> expressionForDistribution)
        {
            var map = list.ToDictionary(x => x, expressionForDistribution);
            return RandomFromMap(map);
        }

        /// <summary>
        /// Returns a random value from list. The double-property used as expression will give a weight to each item. The higher the 
        /// weight the higher chance the value will be randomly selected.
        /// 
        /// Todo: This is not an efficient way of doing it and should be rewritten
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="expressionForDistribution">Selection of double value to use as value</param>
        /// <returns></returns>
        public T RandomFromListUsingValueDistribution<T>(IEnumerable<T> list, Func<T, double> expressionForDistribution)
        {
            return RandomFromListUsingValueDistribution(list.ToList(), expressionForDistribution);
        }

        /// <summary>
        /// Shuffles the list given
        /// </summary>
        /// <param name = "list"></param>
        public void ShuffleList(IList list)
        {
            for (var i = 0; i < list.Count; i++)
            {
                var j = Next(0, i + 1);

                var tempItem = list[j];
                list[j] = list[i];
                list[i] = tempItem;
            }
        }
    }
}
