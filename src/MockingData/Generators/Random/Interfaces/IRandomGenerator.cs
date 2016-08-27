using System;
using System.Collections;
using System.Collections.Generic;
using NodaTime;

namespace MockingData.Generators.Random.Interfaces
{
    public interface IRandomGenerator 
    {
        int Next();
        int Next(int min, int max);
        long NextLong();
        long NextLong(long min, long max);
        double NextDouble();
        double NextDouble(double min, double max);
        bool NextBoolean();
        string NextHexNumber(int digits);
        double NextNormallyDistributedNumber(double meanValue = 0, double standardDeviation = 1);

        LocalDate NextDate(LocalDate minDate, LocalDate maxDate);
        LocalDate NextDate(LocalDate averageDate, double standardDeviation = 10);
        string RandomString(int length, char[] availableCharacters);
        IEnumerable<T> CreateListRandomLength<T>(Func<T> inner, int minCount = 1, int maxCount = 10);

        IList<int> UniqueNumbers(int maxNumber, int numbersToReturn);
        T RandomFromMap<T>(IDictionary<T, int> map);
        T RandomFromMap<T>(IDictionary<T, long> map);
        T RandomFromMap<T>(IDictionary<T, double> map);
        T RandomFromList<T>(IList<T> list);
        T RandomFromListUsingValueDistribution<T>(IList<T> list, Func<T, int> expressionForDistribution);
        T RandomFromListUsingValueDistribution<T>(IList<T> list, Func<T, long> expressionForDistribution);
        T RandomFromListUsingValueDistribution<T>(IList<T> list, Func<T, double> expressionForDistribution);
        void ShuffleList(IList list);
    }
}
