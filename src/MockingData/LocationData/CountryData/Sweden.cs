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
            Name = "Sweden";
            NameLong = "Sweden";
            NameLocalized = "Sverige";

            CodeIsoNumeric = "752";
            CodeIsoAlpha2 = "SE";
            CodeIsoAlpha3 = "SWE";

            Currency = "SEK";
            CurrencyName = "Swedish krona";
            PhoneCountryCode = "46";

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
                        new City { Name = "Karlskrona",PhoneAreaCode  = "455", PostalCode = "371 [00]", Population = 35212, IsStateCapital = true, Streets = InitiateStreets("Parkgatan","Ronnebygatan","Stenbergsgränd") },
                        new City { Name = "Karlshamn", PhoneAreaCode  = "454", PostalCode = "374 35", Population = 19075, Streets = InitiateStreets("Banvallsleden","Kyrkogatan","Vinkelgatan") },
                        new City { Name = "Ronneby", PhoneAreaCode  = "457", PostalCode = "372 39", Population = 12029, Streets = InitiateStreets("Karlskronagatan","Drottninggatan","Kungsgatan") },
                        new City { Name = "Sölvesborg", PhoneAreaCode  = "456", PostalCode = "294 93", Population = 8401, Streets = InitiateStreets("Brunnsgatan","Västra Storgatan","Danagatan") },
                        new City { Name = "Olofström", PhoneAreaCode  = "454", PostalCode = "293 40", Population = 7327, Streets = InitiateStreets("Olsgatan","Kvarngatan","Motalagatan") }
                    }
                },
                new State { Code = "W", Name = "Dalarnas län", AreaSquareKilometers = 28030, Population = 281359, Country = this,
                    Cities = new List<City>{
                        new City { Name = "Falun", PhoneAreaCode  = "23", PostalCode = "791 [00]", Population = 37291, IsStateCapital = true, Streets = InitiateStreets("Svärdsjögatan","Sturegatan","Mormorsgatan")  },
                        new City { Name = "Borlänge", PhoneAreaCode  = "243", PostalCode = "781 [00]", Population = 41734, Streets = InitiateStreets("Wallingatan","Vattugatan","Bygatan") },
                        new City { Name = "Avesta", PhoneAreaCode  = "226", PostalCode = "774 92", Population = 14506, Streets = InitiateStreets("Myntgatan","Vasagatan","Klippstigen") },
                        new City { Name = "Ludvika", PhoneAreaCode  = "240", PostalCode = "771 90", Population = 14498, Streets = InitiateStreets("Prästgårdsgatan","Hammarfallsgatan","Eriksgatan") },
                        new City { Name = "Mora", PhoneAreaCode  = "250", PostalCode = "792 80", Population = 10896, Streets = InitiateStreets("Köpmannagatan","Kyrkogatan","Moragatan")},
                        new City { Name = "Rättvik", PhoneAreaCode  = "248", PostalCode = "795 32", Population = 4686, Streets = InitiateStreets("Vasagatan","Hjort Anders väg","Werkmästergatan") }
                    }
                },
                new State { Code = "I", Name = "Gotlands län", AreaSquareKilometers = 3134, Population = 57405, Country = this,
                    Cities = new List<City>{
                        new City { Name = "Visby", PhoneAreaCode  = "498", PostalCode = "621 [00]", Population = 22593, IsStateCapital = true, Streets = InitiateStreets("Berggränd","Blockgränd","Artillerigatan")  },
                        new City { Name = "Hemse", PhoneAreaCode  = "498", PostalCode = "623 46", Population = 1715, Streets = InitiateStreets("Järnvägsgatan","Nygatan","Toffelgränd") }
                    }
                },
                new State { Code = "X", Name = "Gävleborgs län", AreaSquareKilometers = 18119, Population = 282270, Country = this,
                    Cities = new List<City>{
                        new City { Name = "Gävle", PhoneAreaCode  = "26", PostalCode = "80[0] [00]", Population = 71033, IsStateCapital = true, Streets = InitiateStreets("Hantverkargatan","Kyrkogatan","Norra Rådmansgatan")  }
                    }
                },
                new State { Code = "N", Name = "Hallands län", AreaSquareKilometers = 5427, Population = 315427, Country = this,
                    Cities = new List<City>{
                        new City { Name = "Halmstad", PhoneAreaCode  = "35", PostalCode = "301 [00]", Population = 58577, IsStateCapital = true, Streets = InitiateStreets("Stenvinkelsgatan","Backhausgatan","Hvitfeldtsgatan")},
                        new City { Name = "Falkenberg", PhoneAreaCode = "346", PostalCode = "311 12", Population = 20035, Streets = InitiateStreets("Ringvägen","Rörbecksgatan","Jonsavägen")},
                        new City { Name = "Kungsbacka", PhoneAreaCode = "300", PostalCode = "434 12", Population = 19057, Streets = InitiateStreets("Södra Torggatan","Nygatan","Svangatan") },
                        new City { Name = "Varberg", PhoneAreaCode = "340", PostalCode = "432 12", Population = 27602, Streets = InitiateStreets("Norrgatan","Bäckgatan","Torggatan")},
                        new City { Name = "Laholm", PhoneAreaCode = "430", PostalCode = "312 12", Population = 6150, Streets = InitiateStreets("Tulpanvägen","Liljevägen","Violvägen")},
                        new City { Name = "Hyltebruk", PhoneAreaCode = "345", PostalCode = "314 32", Population = 3716, Streets = InitiateStreets("Skolgatan","Jehandergatan","Kapellgatan")}
                    }
                },
                new State { Code = "F", Name = "Jönköpings län", AreaSquareKilometers = 10495, Population = 337013, Country = this,
                    Cities = new List<City>{
                        new City { Name = "Jönköping", PhoneAreaCode  = "36", PostalCode = "551 [00]", Population = 89396, IsStateCapital = true, Streets = InitiateStreets("Myntgatan","Oxtorgsgatan","Gjuterigatan")  }
                    }
                },
                new State { Code = "Z", Name = "Jämtlands län", AreaSquareKilometers = 48945, Population = 127654, Country = this,
                    Cities = new List<City>{
                        new City { Name = "Östersund", PhoneAreaCode  = "63", PostalCode = "831 [00]", Population = 44327, IsStateCapital = true, Streets = InitiateStreets("Postgränd","Biblioteksgatan","Tullgatan")  }
                    }
                },
                new State { Code = "H", Name = "Kalmar län", AreaSquareKilometers = 11166, Population = 238105, Country = this,
                    Cities = new List<City>{
                        new City { Name = "Kalmar", PhoneAreaCode  = "480", PostalCode = "39[0] [00]", Population = 36392, IsStateCapital = true, Streets = InitiateStreets("Unionsgatan","Nygatan","Trädgårdsgatan")  },
                        new City { Name = "Västervik", PhoneAreaCode  = "490", PostalCode = "593 80", Population = 21140, Streets = InitiateStreets("Storgatan","Bredgatan","Brunnsgatan", "Smugglaregränd")  }
                    }
                },
                new State { Code = "G", Name = "Kronobergs län", AreaSquareKilometers = 8425, Population = 191935, Country = this,
                    Cities = new List<City>{
                        new City { Name = "Växjö", PhoneAreaCode  = "470", PostalCode = "35[0] [00]", Population = 60887, IsStateCapital = true, Streets = InitiateStreets("Norrgatan","Kungsgatan","Klostergatan")  }
                    }
                },
                new State { Code = "BD", Name = "Norrbottens län", AreaSquareKilometers = 97257, Population = 249800, Country = this,
                    Cities = new List<City>{
                        new City { Name = "Luleå", PhoneAreaCode  = "920", PostalCode = "971 [00]", Population = 75966, IsStateCapital = true, Streets = InitiateStreets("Köpmangatan","Stationsgatan","Sandviksgatan")  }
                    }
                },
                new State { Code = "M", Name = "Skåne län", AreaSquareKilometers = 10969, Population = 1306951, Country = this,
                    Cities = new List<City>{
                        new City { Name = "Malmö", PhoneAreaCode  = "40", PostalCode = "21[0] [00]", Population = 280415, IsStateCapital = true, Streets = InitiateStreets("Baltzarsgatan","Stadt Hamburgsgatan","Adelgatan")  },
                        new City { Name = "Lund", PhoneAreaCode  = "46", PostalCode = "222 [00]", Population = 82800, Streets = InitiateStreets("Klostergatan","Winstrupsgatan","Sankt Petri kyrkogata") },
                        new City { Name = "Helsingborg", PhoneAreaCode  = "42", PostalCode = "25[0] [00]", Population = 97122, Streets = InitiateStreets("Möllegränden","Karlsgatan","Prästgatan") }
                    }
                },
                new State { Code = "AB", Name = "Stockholms län", AreaSquareKilometers = 6526, Population = 2239217, Country = this,
                    Cities = new List<City>{
                        new City { Name = "Stockholm", PhoneAreaCode  = "8", PostalCode = "1[00] [00]", Population = 1372565, IsStateCapital = true, IsCountryCapital = true, Streets = InitiateStreets("Skräddargränd","Brännkyrkagatan","Högbergsgatan","Mäster Samuelsgatan","Apelbergsgatan","Kammakargatan","Luntmakargatan","Holländargatan","Regeringsgatan","Lästmakargatan","Östermalmsgatan","Floragatan","Brahegatan","Grev Turegatan","Armfeltsgatan","Sandelsgatan","Olaus Petrigatan","Kampementsgatan","Dalagatan")}
                    }
                },
                new State { Code = "D", Name = "Södemanlands län", AreaSquareKilometers = 6076, Population = 284470, Country = this,
                    Cities = new List<City>{
                        new City { Name = "Nyköping", PhoneAreaCode  = "155", PostalCode = "611 [00]", Population = 29891, IsStateCapital = true, Streets = InitiateStreets("Östra Storgatan","Folkungavägen","Västra Kvarngatan")  }
                    }
                },
                new State { Code = "C", Name = "Uppsala län", AreaSquareKilometers = 8192, Population = 355466, Country = this,
                    Cities = new List<City>{
                        new City { Name = "Uppsala", PhoneAreaCode  = "18", PostalCode = "75[0] [00]", Population = 140454, IsStateCapital = true, Streets = InitiateStreets("Krusbärsgatan","Bruno Liljeforsgatan","Bangårdsgatan")  }
                    }
                },
                new State { Code = "S", Name = "Värmlands län", AreaSquareKilometers = 17517, Population = 276280, Country = this,
                    Cities = new List<City>{
                        new City { Name = "Karlstad", PhoneAreaCode  = "54", PostalCode = "65[0] [00]", Population = 61685, IsStateCapital = true, Streets = InitiateStreets("Färjestadsvägen","Skyttegatan","Granegatan")  }
                    }
                },
                new State { Code = "AC", Name = "Västerbottens län", AreaSquareKilometers = 54672, Population = 263876, Country = this,
                    Cities = new List<City>{
                        new City { Name = "Umeå", PhoneAreaCode  = "90", PostalCode = "900 [00]", Population = 79594, IsStateCapital = true, Streets = InitiateStreets("Skolgatan","Magasinsgatan","Sveagatan")  }
                    }
                },
                new State { Code = "Y", Name = "Västernorrlands län", AreaSquareKilometers = 21552, Population = 244034, Country = this,
                    Cities = new List<City>{
                        new City { Name = "Härnösand", PhoneAreaCode  = "611", PostalCode = "871 [00]", Population = 17556, IsStateCapital = true, Streets = InitiateStreets("Skeppsbron","Norra Kyrkogatan","Hovsgatan")  }
                    }
                },
                new State { Code = "U", Name = "Västmanlands län", AreaSquareKilometers = 5118, Population = 264796, Country = this,
                    Cities = new List<City>{
                        new City { Name = "Västerås", PhoneAreaCode  = "21", PostalCode = "721 [00]", Population = 110877, IsStateCapital = true, Streets = InitiateStreets("Brahegatan","Vallingatan","Kassörgatan")  }
                    }
                },
                new State { Code = "O", Name = "Västra Götalands län", AreaSquareKilometers = 23797, Population = 1652641, Country = this,
                    Cities = new List<City>{
                        new City { Name = "Göteborg", PhoneAreaCode  = "31", PostalCode = "40[0] [00]", Population = 549839, IsStateCapital = true, Streets = InitiateStreets("Vallgatan","Södra Larmgatan","Basargatan","Karl Gustavsgatan","Erik Dahlbergsgatan","Götabergsgatan","Haga Östergata","Frigångsgatan","Fjärde Långgatan","Drottninggatan")  }
                    }
                },
                new State { Code = "T", Name = "Örebro län", AreaSquareKilometers = 8504, Population = 291617, Country = this,
                    Cities = new List<City>{
                        new City { Name = "Örebro", PhoneAreaCode  = "19", PostalCode = "701 [00]", Population = 107038, IsStateCapital = true, Streets = InitiateStreets("Olaigatan","Manillagatan","Engelbrektsgatan")  }
                    }
                },
                new State { Code = "E", Name = "Östergötlands län", AreaSquareKilometers = 10545, Population = 446663, Country = this,
                    Cities = new List<City>{
                        new City { Name = "Linköping", PhoneAreaCode  = "13", PostalCode = "58[0] [00]", Population = 104232, IsStateCapital = true, Streets = InitiateStreets("Kungsgatan","Badhusgatan","Sankt Larsgatan")  },
                        new City { Name = "Norrköping", PhoneAreaCode  = "11", PostalCode = "60[0] [00]", Population = 87247, Streets = InitiateStreets("Repslagaregatan","Hospitalsgatan","Sundeliusgatan") }
                    }
                }

            };

            PostInitiation();

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
