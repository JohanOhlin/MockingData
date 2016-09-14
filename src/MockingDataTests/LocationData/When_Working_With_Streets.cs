using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using MockingData;
using MockingData.Generators.Random;
using MockingData.LocationData;
using Xunit;

namespace MockingDataTests.LocationData
{
    [Trait("Location data", "Streets")]
    public class When_Working_With_Streets
    {
        [Fact]
        public void All_Streets_Should_Have_A_Convertible_Postcode_Pattern()
        {
            // Each street should have a postal code pattern that can be converted without errors

            // Arrange
            var countries = Countries.GetValidRegisteredCountries();
            var md = new MockingDataGenerator();
            var pat = new PatternMatching(md.RandomGenerator);

            // Act
            var allCities = countries
                .SelectMany(x => x.States)
                .SelectMany(s => s.Cities);

            var citiesWithStreetsWithInvalidPostalCode = new List<string>();
            foreach (var city in allCities)
            {
                // We already have a check to verify that each city has streets so we don't need to do that here.
                if (city.Streets == null) continue;

                foreach (var street in city.Streets)
                {
                    try
                    {
                        pat.RandomAlphaNumFromPattern(street.PostalCode);
                    }
                    catch (InvalidPatternException)
                    {
                        citiesWithStreetsWithInvalidPostalCode.Add($"{city.Name} ({street.Name} - {street.PostalCode})");
                    }
                }
            }

            // Assert
            citiesWithStreetsWithInvalidPostalCode.Should().HaveCount(0, $" all streets should have a VALID POSTAL CODE PATTERN (these cities have streets with invalid patterns: {string.Join(",", citiesWithStreetsWithInvalidPostalCode)})");
        }

        [Fact]
        public void All_Streets_In_Citites_In_Valid_Countries_Should_Have_A_City()
        {
            // Arrange
            var countries = Countries.GetValidRegisteredCountries();

            // Act
            var streetsWithoutACity = countries
                .SelectMany(x => x.States)
                .SelectMany(s => s.Cities)
                .Where(c => c.Streets == null || c.Streets.Any(s => s.City == null))
                .Select(x => x.Name)
                .ToList();

            // Assert
            streetsWithoutACity.Should().HaveCount(0, $" all streets should have a CITY (these cities have streets with no city: {string.Join(",", streetsWithoutACity)})");
        }

        [Fact]
        public void All_Streets_In_Citites_In_Valid_Countries_Should_Have_A_Name()
        {
            // Arrange
            var countries = Countries.GetValidRegisteredCountries();

            // Act
            var citiesWithStreetsWithoutName = countries
                .SelectMany(x => x.States)
                .SelectMany(s => s.Cities)
                .Where(c => c.Streets == null || c.Streets.Any(s => string.IsNullOrEmpty(s.Name)))
                .Select(x => x.Name)
                .ToList();

            // Assert
            citiesWithStreetsWithoutName.Should().HaveCount(0, $" all streets should have a STREET NAME (these cities have streets without name: {string.Join(",", citiesWithStreetsWithoutName)})");
        }

    }
}
