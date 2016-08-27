using System.Collections.Generic;
using MockingData.Model;

namespace MockingData.LocationData.CountryData
{
    public class Portugal : Country
    {
        public Portugal(int countryId) : base(countryId)
        {
            CountryName = "Portugal";
            CountryCodeIsoAlpha2 = "PT";
            Currency = "EUR";
            GeoCoordinate = new GeoCoordinate(39.399872, -8.224454);
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
