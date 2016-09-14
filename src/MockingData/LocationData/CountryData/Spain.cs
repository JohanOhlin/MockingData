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
                        new City {Name = "Seville", PhoneAreaCode = "954", PostalCode = "410{0-1}[0]",Streets = InitiateStreets("Calle Santiago","Calle Urquiza","Calle Arroyo", "Calle Socorro", "Calle Sol","Calle Castellar"), Population = 703021, IsStateCapital = true}
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
                        new City {Name = "Zaragoza", PhoneAreaCode = "876", PostalCode = "5000{1-9}",Streets = InitiateStreets("Calle Tarragona","Calle Santander","Calle Burgos","Calle de Bolivia","Calle Cosme Blasco","Calle Segovia"), Population = 666058, IsStateCapital = true}
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
                        new City {Name = "Gijón", PhoneAreaCode = "984", PostalCode = "33691",Streets = InitiateStreets("Calle Soria","Calle Baleares","Calle Valencia","Calle Ana Maria","Calle Zoila","Calle Julio"), Population = 276473, IsStateCapital = true}
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
                        new City {Name = "Palma de Mallorca", PhoneAreaCode = "871", PostalCode = "0700{1-9}",Streets = InitiateStreets("Carrer del Sindicat","Carrer dels Hostals","Carrer Esguerrat","Carrer Quartereta","Carrer dels Frares","Carrer del Deganat"), Population = 401270, IsStateCapital = true}
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
                        new City {Name = "Bilbao", PhoneAreaCode = "94", PostalCode = "4800{1-9}",Streets = InitiateStreets("Urkixo Zumarkalea","Bizkaia Plaza","Elcano Kalea","Labayru Kalea","Calixto Diez Kalea","Kontozezio Kalea"), Population = 345141},
                        new City {Name = "Vitoria-Gasteiz", PhoneAreaCode = "945", PostalCode = "0100{1-9}",Streets = InitiateStreets("Ori Kalea","Sierra de Andia Kalea","Gabriel Celaya Kalea","Txirpia Kalea","Elorrio Kalea","Azpeitia Kalea"), Population = 243918, IsStateCapital = true }
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
                        new City {Name = "Santa Cruz de Tenerife", PhoneAreaCode = "922", PostalCode = "3800{1-9}",Streets = InitiateStreets("Calle Padre Anchieta","Calle Cervantes","Calle de Leoncio Rodriguez","Av. de Buenos Aires","Rambla de Pulido","Calle Maria Cristina"), Population = 206593, IsStateCapital = true},
                        new City {Name = "Las Palmas de Gran Canaria", PhoneAreaCode = "928", PostalCode = "3500{1-9}",Streets = InitiateStreets("Calle Juan de Bethencourt","Calle Leopardi","Calle Lord Byron","Calle Puccini","Calle Quintana","Calle Alemania"), Population = 383308}
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
                        new City {Name = "Santander", PhoneAreaCode = "942", PostalCode = "3900{1-9}",Streets = InitiateStreets("Calle Tres de Noviembre","Calle Alta","Via Cornelia","Calle San Sebastian","Calle Laredo","Calle Isaac Peral"), Population = 178465, IsStateCapital = true}
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
                        new City {Name = "Toledo", PhoneAreaCode = "925", PostalCode = "4500{1-8}",Streets = InitiateStreets("Calle Sal","Calle Plata","Calle Alfileritos","Calle Nueva","Calle Silleria","Calle de Toledo de Ohio"), Population = 84019, IsStateCapital = true},
                        new City {Name = "Albacete", PhoneAreaCode = "967", PostalCode = "0200{1-7}",Streets = InitiateStreets("Calle Rios Rosas","Calle Pedro Coca","Calle Blasco de Garay","Calle Angel","Calle Tejares","Calle Cid"), Population = 172693 }
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
                        new City {Name = "Valladolid", PhoneAreaCode = "983", PostalCode = "4700{1-9}",Streets = InitiateStreets("Calle de Fray Luis de Léon","Calle Real","Calle Macias Picavea","Calle Sanz y Fores","Calle Huertas","Paseo Prado de la Magdalena"), Population = 309714, IsStateCapital = true}
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
                        new City {Name = "Barcelona", PhoneAreaCode = "930", PostalCode = "0800{1-6}",Streets = InitiateStreets("Carrer de Quevedo","Carrer de Ciudad Real","Carrer de Bruniquer","Carrer del Montseny","Carrer de Verdi","Carrer del Topazi"), Population = 1604555, IsStateCapital = true}
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
                        new City {Name = "Mérida", PhoneAreaCode = "924", PostalCode = "06800",Streets = InitiateStreets("Calle San José","Calle Louis Braille","Calle Delgado Valencia","Calle Cervantes","Calle Reyes Huertas","Calle Piedad"), Population = 58164, IsStateCapital = true}
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
                        new City {Name = "Santiago de Compostela", PhoneAreaCode = "981", PostalCode = "1570{1-7}",Streets = InitiateStreets("Costa do Vedor","Rúa de Londres","Rúa de Altiboia","Rúa de Moscova","Rúa de Dublin","Rúa de Raxeira"), Population = 95671, IsStateCapital = true}
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
                        new City {Name = "Logroño", PhoneAreaCode = "941", PostalCode = "2600{1-9}",Streets = InitiateStreets("Calle Somosierra","Calle Huesca","Calle Belchite","Calle Galicia","Calle Calvo Sotelo","Calle Ciriaco Garrido"), Population = 153736, IsStateCapital = true}
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
                        new City {Name = "Madrid", PhoneAreaCode = "910", PostalCode = "280{10-52}",Streets = InitiateStreets("Calle de Ayala","Calle de Goya","Calle de Jorge Juan","Calle de Lagasca","Calle de Padilla","Calle de Serrano"), Population = 3141991, IsStateCapital = true, IsCountryCapital = true}
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
                        new City {Name = "Murcia", PhoneAreaCode = "968", PostalCode = "3000{0-9}",Streets = InitiateStreets("Calle Lepanto","Plaza Preciosa","Calle Portillo San Antonio","Calle Maestro Alonso","Calle Enrique Villar","Calle Greco"), Population = 442573, IsStateCapital = true}
                    }
                },
                new State
                {
                    Code = "NA",
                    Name = "Navarre",
                    AreaSquareKilometers = 10391,
                    Population = 640790,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City {Name = "Pamplona", PhoneAreaCode = "948", PostalCode = "3100[0]",Streets = InitiateStreets("Calle Leyre","Calle de los Teobaldos","Calle San Fermin","Calle de Tafalla","Calle Estella","Calle Paulino Caballero"), Population = 195853, IsStateCapital = true}
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
                        new City {Name = "Valencia", PhoneAreaCode = "960", PostalCode = "460{10-25}",Streets = InitiateStreets("Carrer de Marti","Carrer de Pizarro","Carrer de Jorge Juan","Carrer de Ciscar","Carrer del Bany","Carrer de Lepant"), Population = 809267, IsStateCapital = true}
                    }
                }
            };

            PostInitiation();

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
