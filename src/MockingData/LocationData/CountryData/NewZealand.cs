using System.Collections.Generic;
using MockingData.Model;

namespace MockingData.LocationData.CountryData
{
    public class NewZealand : Country
    {
        public NewZealand(int countryId) : base(countryId)
        {
            CountryName = "New Zealand";
            CountryCodeIsoAlpha2 = "NZ";
            Currency = "";
            GeoCoordinate = new GeoCoordinate(-40.900557, 174.885971);
            HasCompleteData = false;
            TitlesLocalizedMale = new List<string> { };
            TitlesLocalizedFemale = new List<string> { };
            FirstNamesMale = new List<string> { };
            FirstNamesFemale = new List<string> { };
            LastNames = new List<string> { };
            States = new List<State>
            {
                new State
                {
                    Code = "",
                    Name = "",
                    AreaSquareKilometers = 0,
                    Population = 0,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City {Name = "", Population = 102000, IsStateCapital = true}
                    }
                }
            };
        }
    }
}
