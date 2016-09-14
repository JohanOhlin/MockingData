using System.Collections.Generic;
using MockingData.Model;

namespace MockingData.LocationData.CountryData
{
    public class USA : Country
    {
        public USA(int countryId) : base(countryId)
        {
            Name = "United States of America";
            CodeIsoAlpha2 = "US";
            Currency = "USD";
            GeoCoordinate = new GeoCoordinate(0.0, 0.0);
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
                    Code = "AL",
                    Name = "Alabama",
                    AreaSquareKilometers = 131170,
                    Population = 4858979,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City {Name = "Montgomery", Population = 0, IsStateCapital = true},
						new City {Name = "Birmingham", Population = 0}
                    }
                },
                new State
                {
                    Code = "Alaska",
                    Name = "AK",
                    AreaSquareKilometers = 1477950,
                    Population = 738432,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City {Name = "Juneau", Population = 0, IsStateCapital = true},
						new City {Name = "Anchorage", Population = 0}
                    }
                },
                new State
                {
                    Code = "AZ",
                    Name = "Arizona",
                    AreaSquareKilometers = 294207,
                    Population = 6828065,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City {Name = "Phoenix", Population = 0, IsStateCapital = true}
                    }
                },
                new State
                {
                    Code = "AR",
                    Name = "Arkansas",
                    AreaSquareKilometers = 134770,
                    Population = 2978204,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City {Name = "Little Rock", Population = 0, IsStateCapital = true}
                    }
                },
                new State
                {
                    Code = "CA",
                    Name = "California",
                    AreaSquareKilometers = 403466,
                    Population = 39144818,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City {Name = "Los Angeles", Population = 0},
						new City {Name = "Sacramento", Population = 0, IsStateCapital = true}
                    }
                },
                new State
                {
                    Code = "CO",
                    Name = "Colorado",
                    AreaSquareKilometers = 268432,
                    Population = 5456574,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City {Name = "Denver", Population = 0, IsStateCapital = true}
                    }
                },
                new State
                {
                    Code = "CT",
                    Name = "Connecticut",
                    AreaSquareKilometers = 12541,
                    Population = 3590886,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City {Name = "Hartford", Population = 0, IsStateCapital = true},
						new City {Name = "Bridgeport", Population = 0}
                    }
                },
                new State
                {
                    Code = "DE",
                    Name = "Delaware",
                    AreaSquareKilometers = 5048,
                    Population = 945934,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City {Name = "Dover", Population = 0, IsStateCapital = true},
						new City {Name = "Wilmington", Population = 0}
                    }
                },
                new State
                {
                    Code = "FL",
                    Name = "Florida",
                    AreaSquareKilometers = 138888,
                    Population = 20271272,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City {Name = "Tallahassee", Population = 0, IsStateCapital = true},
						new City {Name = "Jacksonville", Population = 0}
                    }
                },
                new State
                {
                    Code = "GA",
                    Name = "Georgia",
                    AreaSquareKilometers = 148958,
                    Population = 10214860,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City {Name = "Atlanta", Population = 0, IsStateCapital = true}
                    }
                },
                new State
                {
                    Code = "HI",
                    Name = "Hawaii",
                    AreaSquareKilometers = 16635,
                    Population = 1431603,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City {Name = "Honolulu", Population = 0, IsStateCapital = true}
                    }
                },
                new State
                {
                    Code = "ID",
                    Name = "Idaho",
                    AreaSquareKilometers = 214044,
                    Population = 1654930,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City {Name = "Boise", Population = 0, IsStateCapital = true}
                    }
                },
                new State
                {
                    Code = "IL",
                    Name = "Illinois",
                    AreaSquareKilometers = 143794,
                    Population = 12859995,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City {Name = "Springfield", Population = 0, IsStateCapital = true},
						new City {Name = "Chicago", Population = 0}
                    }
                },
                new State
                {
                    Code = "IN",
                    Name = "Indianapolis",
                    AreaSquareKilometers = 92789,
                    Population = 6619680,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City {Name = "Indianapolis", Population = 0, IsStateCapital = true}
                    }
                },
                new State
                {
                    Code = "IA",
                    Name = "Iowa",
                    AreaSquareKilometers = 144669,
                    Population = 3123899,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City {Name = "Des Moines", Population = 0, IsStateCapital = true}
                    }
                },
                new State
                {
                    Code = "KS",
                    Name = "Kansas",
                    AreaSquareKilometers = 211755,
                    Population = 2911641,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City {Name = "Topeka", Population = 0, IsStateCapital = true},
						new City {Name = "Wichita", Population = 0}
                    }
                },
                new State
                {
                    Code = "KY",
                    Name = "Kentucky",
                    AreaSquareKilometers = 102268,
                    Population = 4425092,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City {Name = "Frankfort", Population = 0, IsStateCapital = true},
						new City {Name = "Louisville", Population = 0}
                    }
                },
                new State
                {
                    Code = "LA",
                    Name = "Louisiana",
                    AreaSquareKilometers = 111898,
                    Population = 4670724,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City {Name = "Baton Rouge", Population = 0, IsStateCapital = true},
						new City {Name = "New Orleans", Population = 0}
                    }
                },
                new State
                {
                    Code = "ME",
                    Name = "Maine",
                    AreaSquareKilometers = 79883,
                    Population = 1329328,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City {Name = "Augusta", Population = 0, IsStateCapital = true},
						new City {Name = "Portland", Population = 0}
                    }
                },
                new State
                {
                    Code = "MD",
                    Name = "Maryland",
                    AreaSquareKilometers = 25141,
                    Population = 6006401,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City {Name = "Annapolis", Population = 0, IsStateCapital = true},
						new City {Name = "Baltimore", Population = 0}
                    }
                },
                new State
                {
                    Code = "MA",
                    Name = "Massachusetts",
                    AreaSquareKilometers = 20202,
                    Population = 6794422,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City {Name = "Boston", Population = 0, IsStateCapital = true}
                    }
                },
                new State
                {
                    Code = "MI",
                    Name = "Michigan",
                    AreaSquareKilometers = 146435,
                    Population = 9922576,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City {Name = "Lansing", Population = 0, IsStateCapital = true},
						new City {Name = "Detroit", Population = 0}
                    }
                },
                new State
                {
                    Code = "MN",
                    Name = "Minnesota",
                    AreaSquareKilometers = 206233,
                    Population = 5489594,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City {Name = "St. Paul", Population = 0, IsStateCapital = true},
						new City {Name = "Minneapolis", Population = 0}
                    }
                },
                new State
                {
                    Code = "MS",
                    Name = "Mississippi",
                    AreaSquareKilometers = 121530,
                    Population = 2992333,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City {Name = "Jackson", Population = 0, IsStateCapital = true}
                    }
                },
                new State
                {
                    Code = "MO",
                    Name = "Missouri",
                    AreaSquareKilometers = 178041,
                    Population = 6083672,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City {Name = "Jefferson City", Population = 0, IsStateCapital = true},
						new City {Name = "Kansas City", Population = 0}
						
                    }
                },
                new State
                {
                    Code = "MT",
                    Name = "Montana",
                    AreaSquareKilometers = 376962,
                    Population = 1032949,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City {Name = "Helena", Population = 0, IsStateCapital = true},
						new City {Name = "Billings", Population = 0}
                    }
                },
                new State
                {
                    Code = "NE",
                    Name = "Nebraska",
                    AreaSquareKilometers = 198973,
                    Population = 1896190,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City {Name = "Lincoln", Population = 0, IsStateCapital = true},
						new City {Name = "Omaha", Population = 0}
                    }
                },
                new State
                {
                    Code = "NV",
                    Name = "Nevada",
                    AreaSquareKilometers = 284331,
                    Population = 2890845,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City {Name = "Carson City", Population = 0, IsStateCapital = true},
						new City {Name = "Las Vegas", Population = 0}
                    }
                },
                new State
                {
                    Code = "NH",
                    Name = "New Hampshire",
                    AreaSquareKilometers = 23188,
                    Population = 1330608,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City {Name = "Concord", Population = 0, IsStateCapital = true},
						new City {Name = "Manchester", Population = 0}
                    }
                },
                new State
                {
                    Code = "NJ",
                    Name = "New Jersey",
                    AreaSquareKilometers = 19047,
                    Population = 8958013,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City {Name = "Trenton", Population = 0, IsStateCapital = true},
						new City {Name = "Newark", Population = 0}
                    }
                },
                new State
                {
                    Code = "NM",
                    Name = "New Mexico",
                    AreaSquareKilometers = 314160,
                    Population = 2085109,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City {Name = "Santa Fe", Population = 0, IsStateCapital = true},
						new City {Name = "Albuquerque", Population = 0}
                    }
                },
                new State
                {
                    Code = "NY",
                    Name = "New York",
                    AreaSquareKilometers = 122056,
                    Population = 19795791,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City {Name = "Albany", Population = 0, IsStateCapital = true},
						new City {Name = "New York", Population = 0}
                    }
                },
                new State
                {
                    Code = "NC",
                    Name = "North Carolina",
                    AreaSquareKilometers = 125920,
                    Population = 10042802,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City {Name = "Raleigh", Population = 0, IsStateCapital = true},
						new City {Name = "Charlotte", Population = 0}
                    }
                },
                new State
                {
                    Code = "ND",
                    Name = "North Dakota",
                    AreaSquareKilometers = 178712,
                    Population = 756927,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City {Name = "Bismarck", Population = 0, IsStateCapital = true},
						new City {Name = "Fargo", Population = 0}
                    }
                },
                new State
                {
                    Code = "OH",
                    Name = "Ohio",
                    AreaSquareKilometers = 105830,
                    Population = 11613423,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City {Name = "Columbus", Population = 0, IsStateCapital = true}
                    }
                },
                new State
                {
                    Code = "OK",
                    Name = "Oklahoma",
                    AreaSquareKilometers = 177660,
                    Population = 3911338,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City {Name = "Oklahoma City", Population = 0, IsStateCapital = true}
                    }
                },
                new State
                {
                    Code = "OR",
                    Name = "Oregon",
                    AreaSquareKilometers = 248608,
                    Population = 4028977,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City {Name = "Salem", Population = 0, IsStateCapital = true},
						new City {Name = "Portland", Population = 0}
                    }
                },
                new State
                {
                    Code = "PA",
                    Name = "Pennsylvania",
                    AreaSquareKilometers = 115884,
                    Population = 12802503,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City {Name = "Harrisburg", Population = 0, IsStateCapital = true},
						new City {Name = "Philadelphia", Population = 0}
                    }
                },
                new State
                {
                    Code = "RI",
                    Name = "Rhode Island",
                    AreaSquareKilometers = 2678,
                    Population = 1056298,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City {Name = "Providence", Population = 0, IsStateCapital = true}
                    }
                },
                new State
                {
                    Code = "SC",
                    Name = "South Carolina",
                    AreaSquareKilometers = 77858,
                    Population = 4896146,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City {Name = "Columbia", Population = 0, IsStateCapital = true}
                    }
                },
                new State
                {
                    Code = "SD",
                    Name = "South Dakota",
                    AreaSquareKilometers = 196350,
                    Population = 858469,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City {Name = "Pierre", Population = 0, IsStateCapital = true},
						new City {Name = "Sioux Falls", Population = 0}
                    }
                },
                new State
                {
                    Code = "TN",
                    Name = "Tennessee",
                    AreaSquareKilometers = 106798,
                    Population = 6600299,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City {Name = "Nashville", Population = 0, IsStateCapital = true},
						new City {Name = "Memphis", Population = 0}
                    }
                },
                new State
                {
                    Code = "TX",
                    Name = "Texas",
                    AreaSquareKilometers = 676588,
                    Population = 27469114,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City {Name = "Austin", Population = 0, IsStateCapital = true},
						new City {Name = "Houston", Population = 0}
                    }
                },
                new State
                {
                    Code = "UT",
                    Name = "Utah",
                    AreaSquareKilometers = 212819,
                    Population = 2995919,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City {Name = "Salt Lake City", Population = 0, IsStateCapital = true}
                    }
                },
                new State
                {
                    Code = "VT",
                    Name = "Vermont",
                    AreaSquareKilometers = 23872,
                    Population = 626042,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City {Name = "Montpelier", Population = 0, IsStateCapital = true},
						new City {Name = "Burlington", Population = 0}
                    }
                },
                new State
                {
                    Code = "VA",
                    Name = "Virginia",
                    AreaSquareKilometers = 102279,
                    Population = 8382993,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City {Name = "Richmond", Population = 0, IsStateCapital = true},
                        new City {Name = "Virginia Beach", Population = 0}
                    }
                },
                new State
                {
                    Code = "WA",
                    Name = "Washington",
                    AreaSquareKilometers = 172120,
                    Population = 7170351,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City {Name = "Olympia", Population = 0, IsStateCapital = true},
						new City {Name = "Seattle", Population = 0}
                    }
                },
                new State
                {
                    Code = "WV",
                    Name = "West Virginia",
                    AreaSquareKilometers = 62258,
                    Population = 1844128,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City {Name = "Charleston", Population = 0, IsStateCapital = true}
                    }
                },
                new State
                {
                    Code = "WI",
                    Name = "Wisconsin",
                    AreaSquareKilometers = 140269,
                    Population = 5771337,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City {Name = "Madison", Population = 0, IsStateCapital = true},
						new City {Name = "Milwaukee", Population = 0}
                    }
                },
                new State
                {
                    Code = "WY",
                    Name = "Wyoming",
                    AreaSquareKilometers = 251470,
                    Population = 586107,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City {Name = "Cheyenne", Population = 0, IsStateCapital = true}
                    }
                }
            };
        }
    }
}
