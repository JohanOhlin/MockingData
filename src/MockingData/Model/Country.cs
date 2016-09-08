using System;
using System.Collections.Generic;
using System.Linq;
using MockingData.Generators.Random.Interfaces;
using MockingData.Model.Interfaces;

namespace MockingData.Model
{
    public class Country : ICountry
    {

        public Country(int countryId)
        {
            CountryId = countryId;
        }

        /// <summary>
        /// Size of the country in Square Kilometers. 
        /// 
        /// This value is guaranteed.
        /// </summary>
        public int AreaSquareKilometers { get; set; }

        /// <summary>
        /// Size of the country in Square Miles. 
        /// 
        /// This value is guaranteed.
        /// </summary>
        public long AreaSquareMiles => (long)((double)AreaSquareKilometers * 0.38610);

        public string PhoneCountryCode { get; set; }

        public string CodeIsoAlpha2 { get; set; }

        public string CodeIsoAlpha3 { get; set; }

        public string CodeIsoNumeric { get; set; }

        public int CountryId { get; set; }

        public string Name { get; set; }

        public string NameLocalized { get; set; }

        public string NameLong { get; set; }

        public string Currency { get; set; }

        public string CurrencyName { get; set; }

        public int Population { get; set; }

        public GeoCoordinate GeoCoordinate { get; set; }

        public bool HasCompleteData { get; set; }

        public bool HasStates { get; set; }

        public IList<string> FirstNamesFemale { get; set; }

        public IList<string> FirstNamesMale { get; set; }

        public IList<string> LastNames { get; set; }

        public IList<State> States { get; set; }

        public IList<string> TitlesLocalizedFemale { get; set; }

        public IList<string> TitlesLocalizedMale { get; set; }

        protected static IList<Street> InitiateStreets(params string[] streetName)
        {
            return streetName.Select(street => new Street(street)).ToList();
        }
    }
}
