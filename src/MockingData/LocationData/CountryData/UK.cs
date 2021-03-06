﻿using System.Collections.Generic;
using MockingData.Model;
using NodaTime;

namespace MockingData.LocationData.CountryData
{
    /// <summary>
    /// Geographical data for United Kingdom
    /// 
    /// Things left to do:
    /// - Many counties are missing
    /// - More cities should be added
    /// - State codes should be added
    /// - Postal codes for cities
    /// - Phone Area codes for cities and states/counties
    /// </summary>
    public class Uk : Country
    {
        public Uk(int countryId) : base(countryId)
        {
            Name = "UK";
            NameLong = "United Kingdom";
            NameLocalized = "United Kingdom";

            CodeIsoNumeric = "826";
            CodeIsoAlpha2 = "GB";
            CodeIsoAlpha3 = "GBR";

            Currency = "GBP";
            CurrencyName = "Pound Sterling";
            PhoneCountryCode = "44";

            GeoCoordinate = new GeoCoordinate(55.378051, -3.435973);
            HasCompleteData = true;
            HasStates = true;
            Population = 60000000;
            AreaSquareKilometers = 243610;

            TitlesLocalizedMale = new List<string> {"Mr", "Lord", "Sir"};
            TitlesLocalizedFemale = new List<string> {"Ms", "Mrs", "Lady"};
            FirstNamesMale = new[]
            {
                "Adam", "Alex", "Alexander", "Alfie", "Archie", "Arthur", "Benjamin", "Blake", "Bobby", "Charles",
                "Charlie", "Daniel", "David", "Dexter", "Dylan", "Edward", "Elijah", "Elliott", "Ethan", "Finley",
                "Frankie", "Freddie", "George", "Harley", "Harrison", "Harry", "Harvey", "Henry", "Hugo", "Isaac",
                "Jack", "Jacob", "Jake", "James", "Jayden", "Jenson", "Joseph", "Joshua", "Jude", "Kian", "Leo", "Lewis",
                "Liam", "Logan", "Louie", "Louis", "Luca", "Lucas", "Luke", "Max", "Mason", "Matthew", "Michael",
                "Mohammed", "Muhammad", "Nathan", "Noah", "Oliver", "Ollie", "Oscar", "Reuben", "Riley", "Ryan",
                "Samuel", "Sebastian", "Stanley", "Teddy", "Theo", "Theodore", "Thomas", "Toby", "Tommy", "Tyler",
                "William", "Zachary"
            };
            FirstNamesFemale = new[]
            {
                "Abigail", "Aisha", "Alice", "Amber", "Amelia", "Amelie", "Anna", "Annabelle", "Ava", "Bella", "Brooke",
                "Charlotte", "Chloe", "Daisy", "Eleanor", "Eliza", "Elizabeth", "Ella", "Ellie", "Elsie", "Emilia",
                "Emily", "Emma", "Erin", "Esme", "Eva", "Evelyn", "Evie", "Florence", "Freya", "Georgia", "Grace",
                "Gracie", "Hannah", "Harriet", "Holly", "Imogen", "Isabella", "Isabelle", "Isla", "Ivy", "Jasmine",
                "Jessica", "Katie", "Lacey", "Layla", "Lexi", "Lilly", "Lily", "Lola", "Lucy", "Maisie", "Maria",
                "Martha", "Maryam", "Matilda", "Maya", "Megan", "Mia", "Millie", "Molly", "Olivia", "Phoebe", "Poppy",
                "Rose", "Rosie", "Ruby", "Scarlet", "Sienna", "Sophia", "Sophie", "Summer", "Violet", "Willow", "Zara"
            };
            LastNames = new[]
            {
                "Smith", "Jones", "Taylor", "Williams", "Brown", "Davies", "Evans", "Wilson", "Thomas", "Roberts",
                "Jonson", "Lewis", "Walker", "Robinson", "Wood", "Thompson", "White", "Watson", "Jackson", "Wright",
                "Green", "Harris", "Cooper", "King", "Lee", "Martin", "Clarke", "James", "Morgan", "Hughes", "Edwards",
                "Hill", "Moore", "Clark", "Harrison", "Scott", "Young", "Morris", "Hall", "Ward", "Turner", "Carter",
                "Philips", "Mitchell", "Patel", "Adams", "Campbell", "Anderson", "Allen", "Cook", "Bailey", "Parker",
                "Miller", "Davis", "Murphy", "Price", "Bell", "Baker", "Griffiths", "Kelly", "Simpson", "Marshall",
                "Collins", "Bennett", "Cox", "Richardson", "Fox", "Gray", "Rose", "Chapman", "Hunt"
            };
            States = new List<State>
            {
                new State
                {
                    Code = "",
                    Name = "Bedfordshire",
                    AreaSquareKilometers = 1235,
                    Population = 617000,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City {Name = "Bedford", PhoneAreaCode = "1234", PostalCode = "MK40 [0AA]", Streets = InitiateStreets("Lurke St","Ram Yard","Rothsay Pl"), Population = 102000, IsStateCapital = true},
                        new City {Name = "Luton", PhoneAreaCode = "1582", PostalCode = "LU[0] [0AA]", Streets = InitiateStreets("Clarendon Rd","Ridgway Rd","Wardown Cres"), Population = 236000}
                    }
                },
                new State
                {
                    Code = "",
                    Name = "Cambridgeshire",
                    AreaSquareKilometers = 3389,
                    Population = 806700,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City {Name = "Cambridge", PhoneAreaCode = "1223", PostalCode = "CB1 [0AA]", Streets = InitiateStreets("Pembroke St","Russell St","Bateman St"), Population = 128515, IsStateCapital = true}
                    }
                },
                new State
                {
                    Code = "",
                    Name = "Cornwall",
                    AreaSquareKilometers = 3563,
                    Population = 536000,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City {Name = "Truro", PhoneAreaCode = "1872", PostalCode = "TR1 [0AA]", Streets = InitiateStreets("Prospect Pl","Rosewin Row","Fairmantle St"), Population = 18766, IsStateCapital = true}
                    }
                },
                new State
                {
                    Code = "",
                    Name = "Devon",
                    AreaSquareKilometers = 6707,
                    Population = 1135700,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City {Name = "Exeter", PhoneAreaCode = "1392", PostalCode = "EX1 [0AA]", Streets = InitiateStreets("Market St","Smythen St","Mary Arches St"), Population = 124328, IsStateCapital = true}
                    }
                },
                new State
                {
                    Code = "",
                    Name = "Dorset",
                    AreaSquareKilometers = 2653,
                    Population = 745400,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City {Name = "Dorchester", PhoneAreaCode = "1305", PostalCode = "DT1 [0AA]", Streets = InitiateStreets("Poets Way","Edward Rd","Alexandra Rd"), Population = 19060, IsStateCapital = true}
                    }
                },
                new State
                {
                    Code = "",
                    Name = "Essex",
                    AreaSquareKilometers = 3670,
                    Population = 1729200,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City {Name = "Chelmsford", PhoneAreaCode = "1245", PostalCode = "CM1 [0AA]", Streets = InitiateStreets("Viaduct Rd","Marconi Plaza","Duke St"), Population = 168310, IsStateCapital = true}
                    }
                },
                new State
                {
                    Code = "",
                    Name = "Hampshire",
                    AreaSquareKilometers = 3769,
                    Population = 1322300,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City {Name = "Winchester", PhoneAreaCode = "1962", PostalCode = "SO22 [0AA]", Streets = InitiateStreets("Lower Brook St","Union St","St Thomas St"), Population = 45184, IsStateCapital = true}
                    }
                },
                new State
                {
                    Code = "",
                    Name = "Greater London",
                    AreaSquareKilometers = 1569,
                    Population = 8174000,
                    Country = this,
                    Cities = new List<City>
                    {
                        // City of London only has 7000 residents and might be the correct one here, but would
                        // give an unexpected outcome since people in general see London as a million capital
                        new City {Name = "London", PhoneAreaCode = "20", PostalCode = "NW[0] [0AA]", Streets = InitiateStreets("Chapter Rd","Leigh Gardens","Dundonald Rd","Mill Ln","Exeter Rd","Dartmouth Rd","Fordwych Rd","Garlinge Rd","Maygrove Rd","Iverson Rd","Brassey Rd","Ravenshaw St","Dyne Rd","Plympton Rd","Callcott Rd","Torbay Rd","Winchester Ave","Kimberley Rd","Iverson Rd","Kingdon Rd","Holmdale Rd","Solent Rd","Sumatra Rd","Canfield Gardens","Cleve Rd","Crediton Hill","Fawley Rd","Lymington Rd","Wakemand Rd","Rainham Rd","Greyhound Rd","Earlsmead Rd","Hiley Rd","Ashburnham Rd","Drayton Rd","Chadwick Rd","Fry Rd","Ambleside Rd","Mortimer Rd"), Population = 8174000, IsStateCapital = true, IsCountryCapital = true}
                    }
                },
                new State
                {
                    Code = "",
                    Name = "Norfolk",
                    AreaSquareKilometers = 5372,
                    Population = 859400,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City {Name = "Norwich", PhoneAreaCode = "1603", PostalCode = "NR1 [0AA]", Streets = InitiateStreets("Wensum St","Fye Bridge St","Fishergate"), Population = 213166, IsStateCapital = true}  // Bedford Street
                    }
                },
                new State
                {
                    Code = "",
                    Name = "Northamptonshire",
                    AreaSquareKilometers = 2364,
                    Population = 693900,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City () { Name = "Northampton", PhoneAreaCode = "1604", PostalCode = "NN1 [0AA]", Streets = InitiateStreets("Abington St","Gold St","Herbert St"), Population = 219500, IsStateCapital = true }, 
                        new City { Name = "Kettering", PhoneAreaCode = "1536", PostalCode = "NN16 [0AA]", Streets = InitiateStreets("Lahnstein Court","Sheep St","Queensberry Rd"), Population = 67635 }
                    }
                },
                new State
                {
                    Code = "",
                    Name = "Somerset",
                    AreaSquareKilometers = 4171,
                    Population = 910200,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City { Name = "Taunton", PhoneAreaCode = "1823", PostalCode = "TA1 [0AA]", Streets = InitiateStreets("Part St", "Upper High St", "Tower St"), Population = 64621, IsStateCapital = true }
                    }
                },
                new State
                {
                    Code = "",
                    Name = "Suffolk",
                    AreaSquareKilometers = 3798,
                    Population = 730100,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City {Name = "Ipswich", PhoneAreaCode = "1473", PostalCode = "IP4 [0AA]", Streets = InitiateStreets("Museum St","Orwell Pl","College St"), Population = 133384, IsStateCapital = true}
                    }
                },
                new State
                {
                    Code = "",
                    Name = "Surrey",
                    AreaSquareKilometers = 1663,
                    Population = 1135500,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City {Name = "Guildford", PhoneAreaCode = "1483", PostalCode = "GU1 [0AA]", Streets = InitiateStreets("Haydon Pl","The Bars","Martyr Rd"), Population = 137200, IsStateCapital = true}
                    }
                },
                new State
                {
                    Code = "",
                    Name = "Warwickshire",
                    AreaSquareKilometers = 1975,
                    Population = 546500,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City {Name = "Warwick", PhoneAreaCode = "1926", PostalCode = "CV34 [0AA]", Streets = InitiateStreets("Priory Rd","Castle Ln","Church St"), Population = 59679, IsStateCapital = true},
                        new City {Name = "Nuneaton", PhoneAreaCode = "24", PostalCode = "CV10 [0AA]", Streets = InitiateStreets("Queens Rd","Corporation St","Abbey St"), Population = 81877},
                    }
                },
                new State
                {
                    Code = "",
                    Name = "Worcestershire",
                    AreaSquareKilometers = 1741,
                    Population = 566000,
                    Country = this,
                    Cities = new List<City>
                    {
                        new City {Name = "Worcester", PhoneAreaCode = "1905", PostalCode = "WR1 [0AA]", Streets = InitiateStreets("Moor St","Quay St","Middle St"), Population = 100000, IsStateCapital = true}
                    }
                }
            };

            PostInitiation();
            
            // Update all cities with London timezone
            var timezone = DateTimeZoneProviders.Tzdb["Europe/London"];
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