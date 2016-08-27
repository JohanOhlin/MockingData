using System.Collections.Generic;
using MockingData.Model;
using NodaTime;

namespace MockingData.LocationData.CountryData
{
    /// <summary>
    /// Geographical data for Sweden
    /// 
    /// Completed:
    /// - All counties are in place
    /// - State codes are completed
    /// 
    /// Things left to do:
    /// - More cities should be added
    /// </summary>
    public class Sweden : Country
    {
        public Sweden(int countryId) : base(countryId) 
        {
            CountryName = "Sweden";
            CountryNameLong = "Sweden";
            CountryNameLocalized = "Sverige";

            CountryCodeIsoNum = "752";
            CountryCodeIsoAlpha2 = "SE";
            CountryCodeIsoAlpha3 = "SWE";

            Currency = "SEK";
            CurrencyName = "Swedish krona";
            CountryCallingCode = "46";

            GeoCoordinate = new GeoCoordinate(60.128161, 18.643501);
            HasCompleteData = true;
            HasStates = true;
            Population = 9000000;
            AreaSquareKilometers = 450295;
            TitlesLocalizedMale = new[] { "Herr" };
            TitlesLocalizedFemale = new[] { "Fru", "Fröken" };
            FirstNamesMale = new[] { "Adam", "Adrian", "Albin ", "Alex ", "Alexander", "Alfred ", "Algot", "Ali", "Alvin", "Anton", "Aron", "Arvid ", "August", "Axel ", "Benjamin", "Carl", "Casper ", "Charlie ", "Colin", "Daniel", "David ", "Ebbe", "Eddie", "Edvin ", "Edward", "Elias ", "Elis ", "Elliot", "Elton", "Elvin", "Emil", "Erik ", "Felix", "Filip", "Folke", "Frank", "Gabriel", "Gustav ", "Harry", "Henry", "Hjalmar", "Hugo ", "Isak ", "Ivar", "Jack", "Jacob", "Joel", "John", "Jonathan", "Josef ", "Julian", "Kevin", "Kian", "Leo", "Leon ", "Levi", "Liam ", "Linus ", "Loke ", "Loui", "Love ", "Lucas", "Ludvig ", "Malte", "Matteo", "Max", "Maximilian ", "Melker ", "Melvin", "Milo", "Milton ", "Mohamed", "Nils ", "Noah", "Noel ", "Oliver ", "Olle ", "Oscar", "Otto", "Rasmus", "Sam", "Samuel", "Sebastian ", "Sigge", "Simon", "Sixten ", "Tage", "Theo ", "Theodor", "Ture", "Valter", "Vidar", "Viggo ", "Viktor", "Vilgot", "Ville", "Vincent", "Wilhelm", "William ", "Wilmer" };
            FirstNamesFemale = new[] { "Agnes", "Alice", "Alicia ", "Alma", "Alva ", "Amanda ", "Amelia ", "Anna", "Astrid ", "Bianca ", "Celine", "Cornelia ", "Ebba ", "Edith", "Elin", "Elina ", "Elise", "Ella ", "Ellen ", "Ellie", "Ellinor", "Elsa", "Elvira", "Emelie ", "Emilia ", "Emma", "Emmy ", "Ester", "Felicia", "Filippa ", "Freja", "Greta", "Hanna ", "Hedvig ", "Hilda ", "Hilma ", "Ida", "Ines", "Ingrid", "Iris ", "Isabella", "Isabelle ", "Jasmine", "Joline", "Julia", "Julie", "Juni ", "Klara ", "Leah", "Leia", "Lilly", "Linn ", "Linnea", "Liv", "Livia ", "Lo", "Lova ", "Lovis", "Lovisa", "Luna", "Lykke", "Maja", "Majken ", "Maria", "Mariam", "Märta ", "Matilda ", "Meja", "Melissa", "Mira ", "Moa ", "Molly ", "My ", "Nathalie", "Nellie", "Nora", "Nova ", "Novalie", "Olivia", "Ronja ", "Rut", "Saga", "Sally", "Sara", "Selma ", "Signe ", "Sigrid ", "Siri", "Sofia", "Stella ", "Stina ", "Svea ", "Thea ", "Tilda ", "Tilde ", "Tindra ", "Tuva ", "Tyra ", "Vera ", "Wilma" };
            LastNames = new[] { "Andersson", "Johansson", "Karlsson", "Nilsson", "Eriksson", "Larsson", "Olsson", "Persson", "Svensson", "Gustafsson", "Pettersson", "Jonsson", "Jansson", "Hansson", "Bengtsson", "Jönsson", "Lindberg", "Jakobsson", "Magnusson", "Olofsson", "Lindström", "Lindqvist", "Lindgren", "Axelsson", "Berg", "Bergström", "Lundberg", "Lundgren", "Lind", "Lundqvist", "Mattsson", "Berglund", "Fredriksson", "Sandberg", "Henriksson", "Forsberg", "Sjöberg", "Wallin", "Engström", "Danielsson", "Eklund", "Håkansson", "Lundin", "Gunnarsson", "Bergman", "Björk", "Holm", "Samuelsson", "Fransson", "Wikström", "Isaksson", "Bergqvist", "Arvidsson", "Nyström", "Holmberg", "Löfgren", "Söderberg", "Nyberg", "Blomqvist", "Claesson", "Mårtensson", "Nordström", "Lundström", "Ali", "Mohamed", "Eliasson", "Pålsson", "Viklund", "Björklund", "Berggren", "Sandström", "Lund", "Nordin", "Ström", "Åberg", "Hermansson", "Ekström", "Holmgren", "Hedlund", "Sundberg", "Dahlberg", "Falk", "Hellström", "Sjögren", "Abrahamsson", "Martinsson", "Ek", "Blom", "Öberg", "Andreasson", "Månsson", "Strömberg", "Åkesson", "Jonasson", "Hansen", "Norberg", "Åström", "Sundström", "Lindholm", "Holmqvist" };
            States = new List<State>
            {
                new State { Code = "K", Name = "Blekinge län", AreaSquareKilometers = 2931, Population = 156590, Country = this,
                    Cities = new List<City>{
                        new City { Name = "Karlskrona", Population = 35212, IsStateCapital = true },
                        new City { Name = "Karlshamn", Population = 19075 },
                        new City { Name = "Ronneby", Population = 12029 },
                        new City { Name = "Sölvesborg", Population = 8401 },
                        new City { Name = "Olofström", Population = 7327 }
                    }
                },
                new State { Code = "W", Name = "Dalarnas län", AreaSquareKilometers = 28030, Population = 281359, Country = this,
                    Cities = new List<City>{
                        new City { Name = "Falun", Population = 37291, IsStateCapital = true  },
                        new City { Name = "Borlänge", Population = 41734 },
                        new City { Name = "Avesta", Population = 14506 },
                        new City { Name = "Ludvika", Population = 14498 },
                        new City { Name = "Mora", Population = 10896 },
                        new City { Name = "Rättvik", Population = 4686 }
                    }
                },
                new State { Code = "I", Name = "Gotlands län", AreaSquareKilometers = 3134, Population = 57405, Country = this,
                    Cities = new List<City>{
                        new City { Name = "Visby", Population = 22593, IsStateCapital = true  },
                        new City { Name = "Hemse", Population = 1715 }
                    }
                },
                new State { Code = "X", Name = "Gävleborgs län", AreaSquareKilometers = 18119, Population = 282270, Country = this,
                    Cities = new List<City>{
                        new City { Name = "Gävle", Population = 71033, IsStateCapital = true  }
                    }
                },
                new State { Code = "N", Name = "Hallands län", AreaSquareKilometers = 5427, Population = 315427, Country = this,
                    Cities = new List<City>{
                        new City { Name = "Halmstad", Population = 58577, IsStateCapital = true, PhoneAreaCode  = "035", PostalCode = "301 23"},
                        new City { Name = "Falkenberg", Population = 20035, PhoneAreaCode = "0346", PostalCode = "311 12"},
                        new City { Name = "Kungsbacka", Population = 19057, PhoneAreaCode = "0300", PostalCode = "434 12" },
                        new City { Name = "Varberg", Population = 27602, PhoneAreaCode = "0340", PostalCode = "432 12"},
                        new City { Name = "Laholm", Population = 6150, PhoneAreaCode = "0430", PostalCode = "312 12"},
                        new City { Name = "Hyltebruk", Population = 3716, PhoneAreaCode = "0345", PostalCode = "314 32"}
                    }
                },
                new State { Code = "F", Name = "Jönköpings län", AreaSquareKilometers = 10495, Population = 337013, Country = this,
                    Cities = new List<City>{
                        new City { Name = "Jönköping", Population = 89396, IsStateCapital = true  }
                    }
                },
                new State { Code = "Z", Name = "Jämtlands län", AreaSquareKilometers = 48945, Population = 127654, Country = this,
                    Cities = new List<City>{
                        new City { Name = "Östersund", Population = 44327, IsStateCapital = true  }
                    }
                },
                new State { Code = "H", Name = "Kalmar län", AreaSquareKilometers = 11166, Population = 238105, Country = this,
                    Cities = new List<City>{
                        new City { Name = "Kalmar", Population = 36392, IsStateCapital = true  }
                    }
                },
                new State { Code = "G", Name = "Kronobergs län", AreaSquareKilometers = 8425, Population = 191935, Country = this,
                    Cities = new List<City>{
                        new City { Name = "Växjö", Population = 60887, IsStateCapital = true  }
                    }
                },
                new State { Code = "BD", Name = "Norrbottens län", AreaSquareKilometers = 97257, Population = 249800, Country = this,
                    Cities = new List<City>{
                        new City { Name = "Luleå", Population = 75966, IsStateCapital = true  }
                    }
                },
                new State { Code = "M", Name = "Skåne län", AreaSquareKilometers = 10969, Population = 1306951, Country = this,
                    Cities = new List<City>{
                        new City { Name = "Malmö", Population = 280415, IsStateCapital = true  },
                        new City { Name = "Lund", Population = 82800 },
                        new City { Name = "Helsingborg", Population = 97122 }
                    }
                },
                new State { Code = "AB", Name = "Stockholms län", AreaSquareKilometers = 6526, Population = 2239217, Country = this,
                    Cities = new List<City>{
                        new City { Name = "Stockholm", Population = 1372565, IsStateCapital = true, IsCountryCapital = true},
                        new City { Name = "Huddinge", Population = 105566 },
                        new City { Name = "Täby", Population = 61272 },
                        new City { Name = "Södertälje", Population = 64619 }
                    }
                },
                new State { Code = "D", Name = "Södemanlands län", AreaSquareKilometers = 6076, Population = 284470, Country = this,
                    Cities = new List<City>{
                        new City { Name = "Nyköping", Population = 29891, IsStateCapital = true  }
                    }
                },
                new State { Code = "C", Name = "Uppsala län", AreaSquareKilometers = 8192, Population = 355466, Country = this,
                    Cities = new List<City>{
                        new City { Name = "Uppsala", Population = 140454, IsStateCapital = true  }
                    }
                },
                new State { Code = "S", Name = "Värmlands län", AreaSquareKilometers = 17517, Population = 276280, Country = this,
                    Cities = new List<City>{
                        new City { Name = "Karlstad", Population = 61685, IsStateCapital = true  }
                    }
                },
                new State { Code = "AC", Name = "Västerbottens län", AreaSquareKilometers = 54672, Population = 263876, Country = this,
                    Cities = new List<City>{
                        new City { Name = "Umeå", Population = 79594, IsStateCapital = true  }
                    }
                },
                new State { Code = "Y", Name = "Västernorrlands län", AreaSquareKilometers = 21552, Population = 244034, Country = this,
                    Cities = new List<City>{
                        new City { Name = "Härnösand", Population = 17556, IsStateCapital = true  }
                    }
                },
                new State { Code = "U", Name = "Västmanlands län", AreaSquareKilometers = 5118, Population = 264796, Country = this,
                    Cities = new List<City>{
                        new City { Name = "Västerås", Population = 110877, IsStateCapital = true  }
                    }
                },
                new State { Code = "O", Name = "Västra Götalands län", AreaSquareKilometers = 23797, Population = 1652641, Country = this,
                    Cities = new List<City>{
                        new City { Name = "Göteborg", Population = 549839, IsStateCapital = true  }
                    }
                },
                new State { Code = "T", Name = "Örebro län", AreaSquareKilometers = 8504, Population = 291617, Country = this,
                    Cities = new List<City>{
                        new City { Name = "Örebro", Population = 107038, IsStateCapital = true  }
                    }
                },
                new State { Code = "E", Name = "Östergötlands län", AreaSquareKilometers = 10545, Population = 446663, Country = this,
                    Cities = new List<City>{
                        new City { Name = "Linköping", Population = 104232, IsStateCapital = true  },
                        new City { Name = "Norrköping", Population = 87247 }
                    }
                }

            };

            // Update all cities with Stockholm timezone
            var timezone = DateTimeZoneProviders.Tzdb["Europe/Stockholm"];
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
