using System.Collections.Generic;
using MockingData.Model;
using NodaTime;

namespace MockingData.LocationData.CountryData
{
    /// <summary>
    /// Geographical data for Spain
    /// 
    /// Completed:
    /// - All counties are in place
    /// - State codes are completed
    /// 
    /// Things left to do:
    /// - More cities should be added
    /// - Postal codes for cities
    /// - Phone Area codes for cities and states/counties
    /// </summary>
    public class Spain : Country
    {
        public Spain(int countryId) : base(countryId)
        {
            GeoCoordinate = new GeoCoordinate(40.463667, -3.74922);

            Name = "Spain";
            NameLong = "Spain";
            NameLocalized = "Espana";

            CodeIsoNumeric = "724";
            CodeIsoAlpha2 = "ES";
            CodeIsoAlpha3 = "ESP";

            Currency = "EUR";
            CurrencyName = "EURO";
            PhoneCountryCode = "344";

            HasCompleteData = true;
            HasStates = true;

            Population = 46423064;
            AreaSquareKilometers = 505990;
            TitlesLocalizedMale = new List<string> { "Señor" };
            TitlesLocalizedFemale = new List<string> { "Señorita", "Señora" };
            FirstNamesMale = new[] { "Antonio", "Manuel", "Juan", "Pedro", "Miguel", "Luis", "Angel" };
            FirstNamesFemale = new[] { "Maria", "Carmen", "Dolores", "Francisca", "Antonia", "Isabel", "Pilar" };
            LastNames = new[] { "Garcia", "Fernandez", "Lopez", "Martinez", "Gonzalez", "Rodriguez", "Sanchez", "Perez", "Martin", "Gomez", "Ruiz", "Diaz", "Hernandez", "Alvarez" };

            States = new List<State>
            {
                new State
                {
                    Code = "AN",
                    Name = "Andalucia",
                    AreaSquareKilometers = 87268,
                    Population = 8402305,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City {Name = "Seville", Population = 703021, IsStateCapital = true}
                    }
                },
                new State
                {
                    Code = "AR",
                    Name = "Aragon",
                    AreaSquareKilometers = 47719,
                    Population = 1317847,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City {Name = "Zaragoza", Population = 666058, IsStateCapital = true}
                    }
                },
                new State
                {
                    Code = "O",
                    Name = "Asturias",
                    AreaSquareKilometers = 10604,
                    Population = 1061756,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City {Name = "Gijón", Population = 276473, IsStateCapital = true}
                    }
                },
                new State
                {
                    Code = "IB",
                    Name = "Balearic Islands",
                    AreaSquareKilometers = 4992,
                    Population = 1106049,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City {Name = "Palma de Mallorca", Population = 401270, IsStateCapital = true}
                    }
                },
                new State
                {
                    Code = "ES-PV",
                    Name = "Basque Country",
                    AreaSquareKilometers = 7234,
                    Population = 2166184,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City {Name = "Bilbao", Population = 345141},
                        new City {Name = "Vitoria-Gasteiz", Population = 243918, IsStateCapital = true }
                    }
                },
                new State
                {
                    Code = "-",
                    Name = "Canary Islands",
                    AreaSquareKilometers = 7493,
                    Population = 2117519,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City {Name = "Santa Cruz de Tenerife", Population = 206593, IsStateCapital = true},
                        new City {Name = "Las Palmas de Gran Canaria", Population = 383308, IsStateCapital = true}
                    }
                },
                new State
                {
                    Code = "CB",
                    Name = "Cantabria",
                    AreaSquareKilometers = 5321,
                    Population = 593121,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City {Name = "Santander", Population = 178465, IsStateCapital = true}
                    }
                },
                new State
                {
                    Code = "CM",
                    Name = "Castilla La Mancha",
                    AreaSquareKilometers = 79463,
                    Population = 2121888,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City {Name = "Toledo", Population = 84019, IsStateCapital = true},
                        new City {Name = "Albacete", Population = 172693 }
                    }
                },
                new State
                {
                    Code = "CL",
                    Name = "Castilla y León",
                    AreaSquareKilometers = 94222,
                    Population = 2558463,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City {Name = "Valladolid", Population = 309714, IsStateCapital = true}
                    }
                },
                new State
                {
                    Code = "ES-CT",
                    Name = "Catalonia",
                    AreaSquareKilometers = 32108,
                    Population = 7565603,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City {Name = "Barcelona", Population = 1604555, IsStateCapital = true}
                    }
                },
                new State
                {
                    Code = "ES-EX",
                    Name = "Extremadura",
                    AreaSquareKilometers = 41634,
                    Population = 1097744,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City {Name = "Mérida", Population = 58164, IsStateCapital = true}
                    }
                },
                new State
                {
                    Code = "ES-GA",
                    Name = "Galicia",
                    AreaSquareKilometers = 29574,
                    Population = 2765940,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City {Name = "Santiago de Compostela", Population = 95671, IsStateCapital = true}
                    }
                },
                new State
                {
                    Code = "LO",
                    Name = "La Rioja",
                    AreaSquareKilometers = 5045,
                    Population = 308968,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City {Name = "Logroño", Population = 153736, IsStateCapital = true}
                    }
                },
                new State
                {
                    Code = "M",
                    Name = "Madrid",
                    AreaSquareKilometers = 8030,
                    Population = 6489680,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City {Name = "Madrid", Population = 3141991, IsStateCapital = true, IsCountryCapital = true}
                    }
                },
                new State
                {
                    Code = "MU",
                    Name = "Murcia",
                    AreaSquareKilometers = 11313,
                    Population = 1470069,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City {Name = "Murcia", Population = 442573, IsStateCapital = true}
                    }
                },
                new State
                {
                    Code = "NA",
                    Name = "Navarra",
                    AreaSquareKilometers = 10391,
                    Population = 640790,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City {Name = "Pamplona", Population = 195853, IsStateCapital = true}
                    }
                },
                new State
                {
                    Code = "VC",
                    Name = "Valencia",
                    AreaSquareKilometers = 23255,
                    Population = 4980689,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City {Name = "Valencia", Population = 809267, IsStateCapital = true}
                    }
                }
            };

            // Update all cities with Spain/Madrid timezone
            var timezone = DateTimeZoneProviders.Tzdb["Europe/Madrid"];
            foreach (var state in States)
            {
                foreach (var city in state.Cities)
                {
                    city.TimeZone = timezone;
                }
            }
        }
    }
}
