using System.Collections.Generic;

namespace MockingData.Model.Interfaces
{
    public interface ICountry
    {
        /// <summary>
        /// Internal country id passed in through the constructor
        /// </summary>
        int CountryId { get; set; }

        /// <summary>
        /// English version of the country name
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Longer version of CountryName, or the same if no longer version exists
        /// </summary>
        string NameLong { get; set; }

        /// <summary>
        /// Localized version of the country name
        /// </summary>
        string NameLocalized { get; set; }

        /// <summary>
        /// 3 num ISO Numeric Code UN M49. It's a string because some codes starts with 0s.
        /// http://www.nationsonline.org/oneworld/country_code_list.htm
        /// </summary>
        string CodeIsoNumeric { get; set; }

        /// <summary>
        /// 2 character country code according to the ISO 3166 standard
        /// http://www.nationsonline.org/oneworld/country_code_list.htm
        /// </summary>
        string CodeIsoAlpha2 { get; set; }

        /// <summary>
        /// 3 character country code according to ISO Alpha 3. This code is often used in events.
        /// http://www.nationsonline.org/oneworld/country_code_list.htm
        /// </summary>
        string CodeIsoAlpha3 { get; set; }

        /// <summary>
        /// 3 character currency code according to the ISO 4217 standard (based upon the ISO 3166 standard)
        /// https://en.wikipedia.org/wiki/ISO_4217
        /// </summary>
        string Currency { get; set; }

        /// <summary>
        /// Official name of currency (in English)
        /// https://en.wikipedia.org/wiki/ISO_4217
        /// </summary>
        string CurrencyName { get; set; }

        /// <summary>
        /// International Calling Code for the country
        /// http://www.nationsonline.org/oneworld/international-calling-codes.htm
        /// </summary>
        string PhoneCountryCode { get; set; }

        /// <summary>
        /// Population in the country
        /// </summary>
        int Population { get; set; }

        /// <summary>
        /// Area in Square Kilometres
        /// 1 sq km = 0.386102 sq mile
        /// </summary>
        int AreaSquareKilometers { get; set; }

        /// <summary>
        /// If this country has complete data or it it's still a "work in progress"
        /// </summary>
        bool HasCompleteData { get; set; }

        /// <summary>
        /// If this country is divided into states or not. If it's not, it will still have a single state
        /// entry.
        /// </summary>
        bool HasStates { get; set; }

        /// <summary>
        /// Geographical coordinates to a given point in the country
        /// </summary>
        GeoCoordinate GeoCoordinate { get; set; }

        /// <summary>
        /// List of popular male titles in the given country
        /// </summary>
        IList<string> TitlesLocalizedMale { get; set; }

        /// <summary>
        /// List of popular female titles in the given country
        /// </summary>
        IList<string> TitlesLocalizedFemale { get; set; }

        /// <summary>
        /// List of popular male first names in the given country
        /// </summary>
        IList<string> FirstNamesMale { get; set; }

        /// <summary>
        /// List of popular female first names in the given country
        /// </summary>
        IList<string> FirstNamesFemale { get; set; }

        /// <summary>
        /// List of popular last names in the given country
        /// </summary>
        IList<string> LastNames { get; set; }

        /// <summary>
        /// All the states/counties in a country. If country is too small to justify specification by
        /// state then add a single one and set HasStates to false.
        /// </summary>
        IList<State> States { get; set; }
    }
}
