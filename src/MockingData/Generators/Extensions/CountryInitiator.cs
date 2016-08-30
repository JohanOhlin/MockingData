using System.Collections.Generic;
using System.Linq;
using MockingData.Generators.Extensions.Interfaces;
using MockingData.Generators.Random;
using MockingData.Generators.Random.Interfaces;
using MockingData.Model.Interfaces;

namespace MockingData.Generators.Extensions
{
    public class CountryInitator : ExtensionInitiatorBase, ICountryInitiator
    {
        public CountryInitator(IRandomGenerator generator, IExtensionService extensionService)
            : base(generator, extensionService)
        {
        }


        #region ICountryBuilder

        #region List functions

        private Dictionary<int, ICountry> _countryList;

        /// <summary>
        /// Don't use this variable, use FilteredCountryList instead since it's making null checks
        /// </summary>
        private IList<ICountry> _filteredCountryList;

        private IList<ICountry> FilteredCountryList
        {
            get
            {
                if (_filteredCountryList != null) return _filteredCountryList;

                UpdateFilteredCountries();
                return _filteredCountryList;
            }
        }

        /// <summary>
        /// The complete list of countries, including countries that might have invalid data (HasCompleteData == false).
        /// </summary>
        private Dictionary<int, ICountry> CountryList
        {
            get { return _countryList ?? (_countryList = LocationData.Countries.GetValidRegisteredCountriesWithId()); }
            set
            {
                _countryList = value;
                UpdateFilteredCountries();
            }
        }

        /// <summary>
        /// Returns a filtered list of valid countries.
        /// </summary>
        /// <returns></returns>
        public IList<ICountry> Countries()
        {
            return FilteredCountryList.Where(x => x.HasCompleteData).ToList();
        }

        /// <summary>
        /// This internal function should be called every time the country list or any of the filter functions
        /// have been called, to recalculate the list of filtered countries.
        /// 
        /// You don't need to call this function when a distribution function has been called since these calls
        /// only prepare for the random functions.
        /// </summary>
        private void UpdateFilteredCountries()
        {
            var filteredCountryIds =
                (_filterWithCountryIds.Any() ? _filterWithCountryIds : CountryList.Keys.ToList()).Except(
                    _filterWithoutCountryIds);
            _filteredCountryList =
                CountryList.Where(x => filteredCountryIds.Contains(x.Key)).Select(x => x.Value).ToList();
        }

        /// <summary>
        /// The initial country list. If none is set then the result from 
        /// 
        ///   LocationData.Countries.GetRegisteredCountries()
        /// 
        /// will be used instead.
        /// </summary>
        /// <param name="countryList"></param>
        /// <returns></returns>
        public ICountryInitiator WithCountryBaseList(IList<ICountry> countryList)
        {
            if (countryList == null || !countryList.Any()) return this;

            _countryList = countryList.ToDictionary(x => x.CountryId, y => y);
            UpdateFilteredCountries();
            return this;
        }

        /// <summary>
        /// The initial country list. If none is set then the result from 
        /// 
        ///   LocationData.Countries.GetRegisteredCountries()
        /// 
        /// will be used instead.
        /// </summary>
        /// <param name="countryList"></param>
        /// <returns></returns>
        public ICountryInitiator WithCountryBaseList(params ICountry[] countryList)
        {
            return WithCountryBaseList(countryList.ToList());
        }

        #endregion

        #region Country id filters

        private IList<int> _filterWithCountryIds = new List<int>();

        /// <summary>
        /// Set a defined list of countries that should be included. The ids in the list have to 
        /// be present in the country list
        /// </summary>
        /// <param name="countryIds"></param>
        /// <returns></returns>
        public ICountryInitiator WithCountries(IList<int> countryIds)
        {
            _filterWithCountryIds = countryIds;
            UpdateFilteredCountries();
            return this;
        }

        /// <summary>
        /// Set a defined list of countries that should be included. The ids in the list have to 
        /// be present in the country list
        /// </summary>
        /// <param name="countryIds"></param>
        /// <returns></returns>
        public ICountryInitiator WithCountries(params int[] countryIds)
        {
            return WithCountries(countryIds.ToList());
        }

        private IList<int> _filterWithoutCountryIds = new List<int>();

        /// <summary>
        /// Set a defined list of countries that should be excluded.
        /// </summary>
        /// <param name="countryIds"></param>
        /// <returns></returns>
        public ICountryInitiator WithoutCountries(IList<int> countryIds)
        {
            _filterWithoutCountryIds = countryIds;
            UpdateFilteredCountries();
            return this;
        }

        /// <summary>
        /// Set a defined list of countries that should be excluded.
        /// </summary>
        /// <param name="countryIds"></param>
        /// <returns></returns>
        public ICountryInitiator WithoutCountries(params int[] countryIds)
        {
            return WithoutCountries(countryIds.ToList());
        }

        #endregion

        #region Distribution selection

        private CountryDistribution _countryDistribution = CountryDistribution.Equal;

        /// <summary>
        /// The probability of a country to be selected is based upon the population of the country
        /// </summary>
        /// <returns></returns>
        public ICountryInitiator UsingCountryPopulationDistribution()
        {
            _countryDistribution = CountryDistribution.Population;
            return this;
        }

        /// <summary>
        /// The probability of a country to be selected is based upon the size/area of the country
        /// </summary>
        /// <returns></returns>
        public ICountryInitiator UsingCountryAreaDistribution()
        {
            _countryDistribution = CountryDistribution.Area;
            return this;
        }

        /// <summary>
        /// All countries have equal probability of being selected, no matter the size of area and
        /// population
        /// </summary>
        /// <returns></returns>
        public ICountryInitiator UsingCountryEqualDistribution()
        {
            _countryDistribution = CountryDistribution.Equal;
            return this;
        }

        private IDictionary<int, int> _customDistribution;

        /// <summary>
        /// The weight when selecting a random country is set based upon the values in the dictinary.
        /// 
        /// The first value in the dictionary is the country id.
        /// The second value is the weight. A weight of 10 has 10 times higher probability to be randomly 
        /// chosen than a country with the weight 1. The weight can't be less than 1. If it is less than 1
        /// then it'll be set to 1. There's no upper limit on weight
        /// 
        /// This list might be filtered further by the id filter functions. If a non-valid country id
        /// is given, it'll be ignored. If a 
        /// </summary>
        /// <param name="customDistribution"></param>
        /// <returns></returns>
        public ICountryInitiator UsingCustomDistribution(IDictionary<int, int> customDistribution)
        {
            // Country id will be checked in the random function since the final list of selected countries
            // won't be known until then. But we need to check that all countries provided have a valid
            // weight value.
            var invalidPairs = customDistribution.Where(x => x.Value < 1);
            foreach (var pair in invalidPairs)
            {
                customDistribution.Remove(pair);
                customDistribution.Add(new KeyValuePair<int, int>(pair.Key, 1));
            }

            _countryDistribution = CountryDistribution.Custom;
            _customDistribution = customDistribution;
            return this;
        }

        #endregion

        /// <summary>
        /// When builder calls are completed, call this function to return the generator that will generate the random 
        /// countries based upon builder specifications
        /// </summary>
        /// <returns></returns>
        public ICountryGenerator Create()
        {
            return new CountryGenerator(Generator, Countries(), _countryDistribution, _customDistribution);
        }
        #endregion

        #region Abstract class ExtensionInitiatorBase 
        /// <summary>
        /// Used by the ExtensionService class for automation. Use the normal Create method instead.
        /// </summary>
        /// <returns></returns>
        public override IExtensionGenerator CreateGenericGenerator()
        {
            return Create();
        }

        /// <summary>
        /// Identifies this extension
        /// </summary>
        /// <returns></returns>
        public override GeneratorExtensionTypes GetExtensionType()
        {
            return GeneratorExtensionTypes.CountryExtension;
        }
        #endregion
    }

}
