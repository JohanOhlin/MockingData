using System.Collections.Generic;
using MockingData.Model;
using MockingData.Model.Interfaces;
using NodaTime;

namespace MockingData.Generators.Extensions.Interfaces
{
    public interface ICountryGenerator : IExtensionGenerator
    {
        ICountry RandomCountry();
        IEnumerable<ICountry> RandomCountries();
        City RandomCity(State state);
        State RandomState(ICountry country);
        DateTimeZone TimeZone(ICountry country);
        ZonedDateTime ZonedDateTime(ICountry country, ZonedDateTime fromDateTime);
        ZonedDateTime ZonedDateTime(ICountry country);
    }
}
