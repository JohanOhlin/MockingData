using System.Collections.Generic;
using MockingData.Model;

namespace MockingData.LocationData.CountryData
{
    public class Ireland : Country
    {
        public Ireland(int countryId) : base(countryId)
        {
            CountryName = "Ireland";
            CountryCodeIsoAlpha2 = "IE";
            Currency = "EUR";
            GeoCoordinate = new GeoCoordinate(53.41291, -8.24389);
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
