using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using MockingData.LocationData;
using Xunit;

namespace MockingDataTests.LocationData
{
    [Trait("Location data", "States")]
    public class When_Working_Wtih_Registered_States
    {
        [Fact]
        public void All_States_In_Valid_Countries_Should_Have_A_State_Capital()
        {
            // Arrange
            var countries = Countries.GetValidRegisteredCountries();

            // Act
            var statesWithoutStateCapital = countries
                .SelectMany(x => x.States, (country, state) => new { country, state })
                .SelectMany(s => s.state.Cities, (csgroup, city) => new { state = csgroup.state, city })
                .GroupBy(x => x.state)
                .Where(x => x.Count(w => w.city.IsStateCapital) == 0)
                .Select(x => x.Key.Name)
                .ToList();

            // Assert
            statesWithoutStateCapital.Should().HaveCount(0, $" all states should have a STATE CAPITAL (these are missing: {string.Join(",", statesWithoutStateCapital)})");
        }

        [Fact]
        public void All_States_In_Valid_Countries_Should_Have_A_Name()
        {
            // Arrange
            var countries = Countries.GetValidRegisteredCountries();

            // Act
            var statesWithoutAName = countries
                .SelectMany(x => x.States, (country, state) => new {country, state})
                .Where(x => string.IsNullOrEmpty(x.state.Name))
                .Select(x => x.country.CountryName)
                .ToList();

            // Assert
            statesWithoutAName.Should().HaveCount(0, $" all states should have a NAME (these countries have a state with missing name: {string.Join(",", statesWithoutAName)})");
        }

        [Fact]
        public void All_States_In_Valid_Countries_Should_Have_A_Population()
        {
            // Arrange
            var countries = Countries.GetValidRegisteredCountries();

            // Act
            var statesWithoutPopulation = countries
                .SelectMany(x => x.States, (country, state) => new { country, state })
                .Where(x => x.state.Population <= 0)
                .Select(x => x.state.Name)
                .ToList();

            // Assert
            statesWithoutPopulation.Should().HaveCount(0, $" all states should have a POPULATION (these are missing: {string.Join(",", statesWithoutPopulation)})");
        }

        [Fact]
        public void All_States_In_Valid_Countries_Should_Have_An_Area()
        {
            // Arrange
            var countries = Countries.GetValidRegisteredCountries();

            // Act
            var statesWithoutPopulation = countries
                .SelectMany(x => x.States, (country, state) => new { country, state })
                .Where(x => x.state.AreaSquareKilometers <= 0)
                .Select(x => x.state.Name)
                .ToList();

            // Assert
            statesWithoutPopulation.Should().HaveCount(0, $" all states should have an AREA SQM (these are missing: {string.Join(",", statesWithoutPopulation)})");
        }
    }
}
