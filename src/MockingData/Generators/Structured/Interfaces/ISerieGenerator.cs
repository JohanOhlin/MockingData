using System;
using System.Collections.Generic;
using NodaTime;

namespace MockingData.Generators.Structured.Interfaces
{
    public interface ISerieGenerator
    {
        IEnumerable<double> RangeOfDouble(double startValue, double step = 1.0);
        IEnumerable<DateTime> RangeOfDate(DateTime start, DateTime end);
        IEnumerable<LocalDate> RangeOfDate(LocalDate start, LocalDate end);
    }
}
