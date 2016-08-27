using System.Collections.Generic;
using MockingData.Model;

namespace MockingData.LocationData.CountryData
{
    public class Denmark : Country
    {
        public Denmark(int countryId) : base(countryId)
        {
            CountryName = "Denmark";
            CountryCodeIsoAlpha2 = "DK";
            Currency = "EUR";
            GeoCoordinate = new GeoCoordinate(56.26392, 9.501785);
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
