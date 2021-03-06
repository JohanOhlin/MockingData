﻿using System.Collections.Generic;
using MockingData.Model;

namespace MockingData.LocationData.CountryData
{
    public class Norway : Country
    {
        public Norway(int countryId) : base(countryId)
        {
            Name = "Norway";
            CodeIsoAlpha2 = "NO";
            Currency = "NOK";
            GeoCoordinate = new GeoCoordinate(60.472024, 8.468946);
            HasCompleteData = false;
            TitlesLocalizedMale = new List<string> {};
            TitlesLocalizedFemale = new List<string> {};
            FirstNamesMale = new List<string> {};
            FirstNamesFemale = new List<string> {};
            LastNames = new List<string> {};
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
