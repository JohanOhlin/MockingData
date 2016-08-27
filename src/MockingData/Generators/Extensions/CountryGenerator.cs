using System.Collections.Generic;
using System.Linq;
using MockingData.Generators.Extensions.Interfaces;
using MockingData.Generators.Random.Extensions;
using MockingData.Generators.Random.Interfaces;
using MockingData.Model;
using MockingData.Model.Interfaces;
using NodaTime;
using NodaTime.Extensions;
using NodaTime.TimeZones;

namespace MockingData.Generators.Extensions
{
    public class CountryGenerator : ICountryGenerator
    {
        public IList<ICountry> CountryList { get; private set; }
        public CountryDistribution Distribution { get; private set; }
        private IRandomGenerator _generator { get; set; }
        public IDictionary<int, int> CustomDistribution { get; private set; }

        public CountryGenerator(IRandomGenerator randomGenerator, IList<ICountry> countryList, CountryDistribution distribution, IDictionary<int, int> customDistribution)
        {
            CountryList = countryList;
            _generator = randomGenerator;
            Distribution = distribution;
            CustomDistribution = customDistribution;
        }

        #region ICountryGenerator
        /// <summary>
        /// Returns a random country
        /// </summary>
        /// <returns></returns>
        public ICountry RandomCountry()
        {
            var countryIdList = CountryList.Select(x => x.CountryId).ToList();

            var countryId = 0;
            switch (Distribution)
            {
                case CountryDistribution.Population:
                    return _generator.RandomFromListUsingValueDistribution(CountryList, x => x.Population);
                case CountryDistribution.Area:
                    return _generator.RandomFromListUsingValueDistribution(CountryList, x => x.AreaSquareKilometers);
                case CountryDistribution.Equal:
                    countryId = _generator.RandomFromList(countryIdList);
                    return CountryList.FirstOrDefault(x => x.CountryId == countryId);
                case CountryDistribution.Custom:
                    // Only include values from _customDistribution that are included in the countryIdList
                    var filteredDistribution = CustomDistribution.Where(x => countryIdList.Contains(x.Key)).ToDictionary(x => x.Key, y => y.Value);
                    countryId = _generator.RandomFromMap(filteredDistribution);
                    return CountryList.FirstOrDefault(x => x.CountryId == countryId);
                default:
                    // This is same as equal distribution
                    countryId = _generator.RandomFromList(countryIdList);
                    return CountryList.FirstOrDefault(x => x.CountryId == countryId);
            }
        }

        /// <summary>
        /// Returns a stream of random countries
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ICountry> RandomCountries()
        {
            while (true)
            {
                yield return RandomCountry();
            }
        }

        public GeneratorExtensionTypes GetExtensionType()
        {
            return GeneratorExtensionTypes.CountryExtension;
        }

        public City RandomCity(State state)
        {
            return state.Cities.RandomFromList(_generator);
        }

        public State RandomState(ICountry country)
        {
            return country.States.RandomFromList(_generator);
        }

        /// <summary>
        /// Returns the TimeZone (NodaTime) for the given country. If country is invalid and is missing
        /// time zone data then UTC is returned.
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        public DateTimeZone TimeZone(ICountry country)
        {
            IClock clock = SystemClock.Instance;

            var location = TzdbDateTimeZoneSource.Default.ZoneLocations
                             .FirstOrDefault(loc => loc.CountryCode == country.CountryCodeIsoAlpha2);

            return location == null ? DateTimeZone.Utc : DateTimeZoneProviders.Tzdb[location.ZoneId];
        }

        /// <summary>
        /// Gets the zoned local time for this country given a zoned local time to start from. 
        /// 
        /// I.e. If this country is Argentina and 8pm Europe/London is given as fromDateTime then 
        /// 1pm America/BuenosAires might be returned.
        /// </summary>
        /// <param name="fromDateTime"></param>
        /// <returns></returns>
        public ZonedDateTime ZonedDateTime(ICountry country, ZonedDateTime fromDateTime)
        {
            var timeZone = TimeZone(country);
            if (timeZone == null) return fromDateTime;

            return fromDateTime
                .WithZone(timeZone);
        }


        public ZonedDateTime ZonedDateTime(ICountry country)
        {
            var timeZone = TimeZone(country);
            return timeZone == null ?
                SystemClock.Instance.InUtc().GetCurrentZonedDateTime() :
                SystemClock.Instance.InZone(timeZone).GetCurrentZonedDateTime();
        }


        #endregion
    }

    public enum CountryDistribution
    {
        Equal = 1,
        Population = 2,
        Area = 3,
        Custom = 4
    }
}
