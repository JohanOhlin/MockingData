using System;
using System.Collections.Generic;
using MockingData.Generators.Structured.Interfaces;
using NodaTime;

namespace MockingData.Generators.Structured
{
    public class SerieGenerator : ISerieGenerator
    {
        public IEnumerable<double> RangeOfDouble(double startValue, double step = 1.0)
        {
            yield return startValue;
            while (true)
            {
                yield return startValue += step;
            }
        }

        public IEnumerable<DateTime> RangeOfDate(DateTime start, DateTime end)
        {
            yield return start;
            var diff = start.Date.Subtract(end.Date).Days;
            for (var i = 0; i < diff; i++)
            {
                yield return start.AddDays(i);
            }
        }

        public IEnumerable<LocalDate> RangeOfDate(LocalDate start, LocalDate end)
        {
            yield return start;
            var diff = Period.Between(start, end);
            for (var i = 0; i < diff.Days; i++) {
                yield return start.PlusDays(i);
            }
        }
    }
}
