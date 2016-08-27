using System.Collections.Generic;
using MockingData.Model;

namespace MockingData.LocationData.CountryData
{
    public class Australia : Country
    {
        public Australia(int countryId) : base(countryId)
        {
            CountryName = "Australia";
            CountryCodeIsoAlpha2 = "AU";
            Currency = "";
            GeoCoordinate = new GeoCoordinate(-25.274398, 133.775136);
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
