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
        private readonly IList<ICountry> _countryList;
        private readonly CountryDistribution _distribution;
        private readonly IRandomGenerator _generator;
        private readonly IDictionary<int, int> _customDistribution;

        public CountryGenerator(IRandomGenerator randomGenerator, IList<ICountry> countryList, CountryDistribution distribution, IDictionary<int, int> customDistribution)
        {
            _countryList = countryList;
            _generator = randomGenerator;
            _distribution = distribution;
            _customDistribution = customDistribution;
        }

        #region ICountryGenerator

        /// <summary>
        /// Returns the list of countries that are being used
        /// </summary>
        /// <returns></returns>
        public IList<ICountry> CountryList()
        {
            return _countryList;
        }

        /// <summary>
        /// Returns the type of distribution being used
        /// </summary>
        /// <returns></returns>
        public CountryDistribution Distribution()
        {
            return _distribution;
        }

        /// <summary>
        /// Returns the specification for the custom distribution. This value is only used if Distribution is set to Custom.
        /// </summary>
        /// <returns></returns>
        public IDictionary<int, int> CustomDistribution()
        {
            return _customDistribution;
        }

        /// <summary>
        /// Returns a random country
        /// </summary>
        /// <returns></returns>
        public ICountry RandomCountry()
        {
            var countryIdList = _countryList.Select(x => x.CountryId).ToList();

            var countryId = 0;
            switch (_distribution)
            {
                case CountryDistribution.Population:
                    return _generator.RandomFromListUsingValueDistribution(_countryList, x => x.Population);
                case CountryDistribution.Area:
                    return _generator.RandomFromListUsingValueDistribution(_countryList, x => x.AreaSquareKilometers);
                case CountryDistribution.Equal:
                    countryId = _generator.RandomFromList(countryIdList);
                    return _countryList.FirstOrDefault(x => x.CountryId == countryId);
                case CountryDistribution.Custom:
                    // Only include values from _customDistribution that are included in the countryIdList
                    var filteredDistribution = _customDistribution.Where(x => countryIdList.Contains(x.Key)).ToDictionary(x => x.Key, y => y.Value);
                    countryId = _generator.RandomFromMap(filteredDistribution);
                    return _countryList.FirstOrDefault(x => x.CountryId == countryId);
                default:
                    // This is same as equal distribution
                    countryId = _generator.RandomFromList(countryIdList);
                    return _countryList.FirstOrDefault(x => x.CountryId == countryId);
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

        #region interface IExtensionGenerator
        /// <summary>
        /// Returns the type of this extension
        /// </summary>
        /// <returns></returns>
        public GeneratorExtensionTypes GetExtensionType()
        {
            return GeneratorExtensionTypes.CountryExtension;
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
