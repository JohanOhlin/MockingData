﻿using System.Collections.Generic;
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

        public string CountryCallingCode { get; set; }

        public string CountryCodeIsoAlpha2 { get; set; }

        public string CountryCodeIsoAlpha3 { get; set; }

        public string CountryCodeIsoNum { get; set; }

        public int CountryId { get; set; }

        public string CountryName { get; set; }

        public string CountryNameLocalized { get; set; }

        public string CountryNameLong { get; set; }

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
    }
}