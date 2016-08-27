using FluentAssertions;
using MockingData.Generators;
using MockingData.Generators.Random;
using MockingData.LocationData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NodaTime;
using NodaTime.TimeZones;
using Xunit;

namespace MockingDataTests.LocationData
{
    [Trait("Location data", "Cities")]
    public class When_Working_With_Registered_Cities
    {
        [Fact]
        public void All_Citites_In_Valid_Countries_Should_Have_A_Time_Zone()
        {
            // Arrange
            var countries = Countries.GetValidRegisteredCountries();

            // Act
            var citiesWithoutTimeZone = countries
                .SelectMany(x => x.States)
                .SelectMany(s => s.Cities)
                .Where(c => c.TimeZone == null)
                .Select(x => x.Name)
                .ToList();

            // Assert
            citiesWithoutTimeZone.Should().HaveCount(0, $" all cities should have a TIME ZONE (these are missing: {string.Join(",", citiesWithoutTimeZone)})");

        }

        [Fact]
        public void All_Citites_In_Valid_Countries_Should_Have_A_Name()
        {
            // Arrange
            var countries = Countries.GetValidRegisteredCountries();

            // Act
            var citiesWithoutNames = countries
                .SelectMany(x => x.States)
                .SelectMany(s => s.Cities)
                .Where(c => string.IsNullOrEmpty(c.Name))
                .Select(c => c.State.Country.CountryName)
                .ToList();

            // Assert
            citiesWithoutNames.Should().HaveCount(0, $" all cities should have a NAME (these countries have cities without name: {string.Join(",", citiesWithoutNames)})");
        }

        [Fact]
        public void All_Citites_In_Valid_Countries_Should_Have_A_Population()
        {
            // Arrange
            var countries = Countries.GetValidRegisteredCountries();

            // Act
            var citiesWithoutPopulation = countries
                .SelectMany(x => x.States)
                .SelectMany(s => s.Cities)
                .Where(c => c.Population <= 0)
                .Select(x => x.Name)
                .ToList();

            // Assert
            citiesWithoutPopulation.Should().HaveCount(0, $" all cities should have a POPULATION (these are missing: {string.Join(",", citiesWithoutPopulation)})");
        }

        [Fact]
        public void All_Citites_In_Valid_Countries_Should_Have_A_State()
        {
            // Arrange
            var countries = Countries.GetValidRegisteredCountries();

            // Act
            var citiesWithoutPopulation = countries
                .SelectMany(x => x.States)
                .SelectMany(s => s.Cities)
                .Where(c => c.State == null)
                .Select(x => x.Name)
                .ToList();

            // Assert
            citiesWithoutPopulation.Should().HaveCount(0, $" all cities should have a STATE (these are missing: {string.Join(",", citiesWithoutPopulation)})");
        }

    }
}
