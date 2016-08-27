using System.Collections.Generic;
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
            CountryName = "UK";
            CountryNameLong = "United Kingdom";
            CountryNameLocalized = "United Kingdom";

            CountryCodeIsoNum = "826";
            CountryCodeIsoAlpha2 = "GB";
            CountryCodeIsoAlpha3 = "GBR";

            Currency = "GBP";
            CurrencyName = "Pound Sterling";
            CountryCallingCode = "44";

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
                        new City {Name = "Bedord", Population = 102000, IsStateCapital = true},
                        new City {Name = "Luton", Population = 236000}
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
                        new City {Name = "Cambridge", Population = 128515, IsStateCapital = true}
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
                        new City {Name = "Truro", Population = 18766, IsStateCapital = true}
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
                        new City {Name = "Exeter", Population = 124328, IsStateCapital = true}
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
                        new City {Name = "Dorchester", Population = 19060, IsStateCapital = true}
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
                        new City {Name = "Chelmsford", Population = 168310, IsStateCapital = true}
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
                        new City {Name = "Winchester", Population = 45184, IsStateCapital = true}
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
                        new City {Name = "London", Population = 8174000, IsStateCapital = true, IsCountryCapital = true}
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
                        new City {Name = "Norwich", Population = 213166, IsStateCapital = true}
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
                        new City {Name = "Northampton", Population = 219500, IsStateCapital = true},
                        new City {Name = "Kettering", Population = 67635}
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
                        new City {Name = "Taunton", Population = 64621, IsStateCapital = true}
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
                        new City {Name = "Ipswich", Population = 133384, IsStateCapital = true}
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
                        new City {Name = "Guildford", Population = 137200, IsStateCapital = true}
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
                        new City {Name = "Warwick", Population = 59679, IsStateCapital = true},
                        new City {Name = "Nuneaton", Population = 81877},
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
                        new City {Name = "Worcester", Population = 100000, IsStateCapital = true}
                    }
                }
            };
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