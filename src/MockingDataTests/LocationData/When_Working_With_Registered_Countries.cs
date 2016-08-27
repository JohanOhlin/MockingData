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
    [Trait("Location data", "Countries")]
    public class When_Working_With_Registered_Countries
    {
        [Fact]
        public void All_Valid_Countries_Should_Have_A_Country_Capital()
        {
            // Arrange
            var countries = Countries.GetValidRegisteredCountries();

            // Act
            var citiesWithoutPopulation = countries
                .SelectMany(x => x.States, (country, state) => new { country, state })
                .SelectMany(s => s.state.Cities, (csgroup, city) => new { country = csgroup.country, city })
                .GroupBy(x => x.country)
                .Where(x => x.Count(w => w.city.IsCountryCapital) == 0)
                .Select(x => x.Key.CountryName)
                .ToList();

            // Assert
            citiesWithoutPopulation.Should().HaveCount(0, $" all countries should have a COUNTRY CAPITAL (these are missing: {string.Join(",", citiesWithoutPopulation)})");

        }

        [Fact]
        public void All_Valid_Countries_Should_Have_Id()
        {
            // Arrange
            var countries = Countries.GetValidRegisteredCountries();

            // Act
            var countriesWithoutId = countries
                .Where(x => x.CountryId <= 0)
                .Select(x => x.CountryName)
                .ToList();

            // Assert
            countriesWithoutId.Should().HaveCount(0, $" all countries should have an ID (these are missing: {string.Join(",", countriesWithoutId)})");
        }


        [Fact]
        public void All_Valid_Countries_Should_Have_Name()
        {
            // Arrange
            var countries = Countries.GetValidRegisteredCountries();

            // Act
            var countriesWithoutName = countries
                .Where(x => string.IsNullOrEmpty(x.CountryName))
                .Select(x => x.CountryName)
                .ToList();

            // Assert
            countriesWithoutName.Should().HaveCount(0, $" all countries should have a NAME (these are missing: {string.Join(",", countriesWithoutName)})");
        }

        [Fact]
        public void All_Valid_Countries_Should_Have_Long_Name()
        {
            // Arrange
            var countries = Countries.GetValidRegisteredCountries();

            // Act
            var countriesWithoutNameLong = countries
                .Where(x => string.IsNullOrEmpty(x.CountryNameLong))
                .Select(x => x.CountryName)
                .ToList();

            // Assert
            countriesWithoutNameLong.Should().HaveCount(0, $" all countries should have a LONG NAME (these are missing: {string.Join(",", countriesWithoutNameLong)})");
        }

        [Fact]
        public void All_Valid_Countries_Should_Have_Localized_Name()
        {
            // Arrange
            var countries = Countries.GetValidRegisteredCountries();

            // Act
            var countriesWithoutNameLocalized = countries
                .Where(x => string.IsNullOrEmpty(x.CountryNameLocalized))
                .Select(x => x.CountryName)
                .ToList();

            // Assert
            countriesWithoutNameLocalized.Should().HaveCount(0, $" all countries should have a LOCALIZED NAME (these are missing: {string.Join(",", countriesWithoutNameLocalized)})");
        }


        [Fact]
        public void All_Valid_Countries_Should_Have_Numeric_ISO_Code()
        {
            // Arrange
            var countries = Countries.GetValidRegisteredCountries();

            // Act
            var countriesWithoutIsoNum = countries
                .Where(x => string.IsNullOrEmpty(x.CountryCodeIsoNum))
                .Select(x => x.CountryName)
                .ToList();

            // Assert
            countriesWithoutIsoNum.Should().HaveCount(0, $" all countries should have a NUMERIC ISO CODE (these are missing: {string.Join(",", countriesWithoutIsoNum)})");
        }

        [Fact]
        public void All_Valid_Countries_Should_Have_2_Letter_ISO_Code()
        {
            // Arrange
            var countries = Countries.GetValidRegisteredCountries();

            // Act
            var countriesWithoutIsoAlpha2 = countries
                .Where(x => string.IsNullOrEmpty(x.CountryCodeIsoAlpha2))
                .Select(x => x.CountryName)
                .ToList();

            // Assert
            countriesWithoutIsoAlpha2.Should().HaveCount(0, $" all countries should have a 2 LETTER ISO CODE (these are missing: {string.Join(",", countriesWithoutIsoAlpha2)})");
        }

        [Fact]
        public void All_Valid_Countries_Should_Have_3_Letter_ISO_Code()
        {
            // Arrange
            var countries = Countries.GetValidRegisteredCountries();

            // Act
            var countriesWithoutIsoAlpha3 = countries
                .Where(x => string.IsNullOrEmpty(x.CountryCodeIsoAlpha3))
                .Select(x => x.CountryName)
                .ToList();

            // Assert
            countriesWithoutIsoAlpha3.Should().HaveCount(0, $" all countries should have a 3 LETTER ISO CODE (these are missing: {string.Join(",", countriesWithoutIsoAlpha3)})");
        }



        [Fact]
        public void All_Valid_Countries_Should_Have_Currency()
        {
            // Arrange
            var countries = Countries.GetValidRegisteredCountries();

            // Act
            var countriesWithoutCurrency = countries
                .Where(x => string.IsNullOrEmpty(x.Currency))
                .Select(x => x.CountryName)
                .ToList();

            // Assert
            countriesWithoutCurrency.Should().HaveCount(0, $" all countries should have a CURRENCY (these are missing: {string.Join(",", countriesWithoutCurrency)})");
        }

        [Fact]
        public void All_Valid_Countries_Should_Have_Currency_Name()
        {
            // Arrange
            var countries = Countries.GetValidRegisteredCountries();

            // Act
            var countriesWithoutCurrencyName = countries
                .Where(x => string.IsNullOrEmpty(x.CurrencyName))
                .Select(x => x.CountryName)
                .ToList();

            // Assert
            countriesWithoutCurrencyName.Should().HaveCount(0, $" all countries should have a CURRENCY NAME (these are missing: {string.Join(",", countriesWithoutCurrencyName)})");
        }


        [Fact]
        public void All_Valid_Countries_Should_Have_Phone_Info()
        {
            // Arrange
            var countries = Countries.GetValidRegisteredCountries();

            // Act
            var countriesWithoutCallingCode = countries
                .Where(x => string.IsNullOrEmpty(x.CountryCallingCode))
                .Select(x => x.CountryName)
                .ToList();

            // Assert
            countriesWithoutCallingCode.Should().HaveCount(0, $" all countries should have CALLING CODE (these are missing: {string.Join(",", countriesWithoutCallingCode)})");
        }

        [Fact]
        public void All_Valid_Countries_Should_Have_Population_Greater_Than_0()
        {
            // Arrange
            var countries = Countries.GetValidRegisteredCountries();

            // Act
            var countriesWithoutPopulation = countries
                .Where(x => x.Population <= 0)
                .Select(x => x.CountryName)
                .ToList();

            // Assert
            countriesWithoutPopulation.Should().HaveCount(0, $" all countries should have a POPULATION (these are missing: {string.Join(",", countriesWithoutPopulation)})");
        }

        [Fact]
        public void All_Valid_Countries_Should_Have_Area_Greater_Than_0()
        {
            // Arrange
            var countries = Countries.GetValidRegisteredCountries();

            // Act
            var countriesWithoutArea = countries
                .Where(x => x.AreaSquareKilometers <= 0)
                .Select(x => x.CountryName)
                .ToList();

            // Assert
            countriesWithoutArea.Should().HaveCount(0, $" all countries should have area (these are missing: {string.Join(",", countriesWithoutArea)})");
        }

        [Fact]
        public void All_Valid_Countries_Should_Have_GeoCoordinates()
        {
            // Arrange
            var countries = Countries.GetValidRegisteredCountries();
            const double TOLERANCE = 0;

            // Act
            var countriesWithoutGeoCoordinates = countries
                .Where(x => Math.Abs(x.GeoCoordinate.Latitude - default(double)) < TOLERANCE || Math.Abs(x.GeoCoordinate.Longitude - default(double)) < TOLERANCE)
                .Select(x => x.CountryName)
                .ToList();

            // Assert
            countriesWithoutGeoCoordinates.Should().HaveCount(0, $" all countries should have GEO-COORDINATES (these are missing: {string.Join(",", countriesWithoutGeoCoordinates)})");
        }

        [Fact]
        public void All_Valid_Countries_Should_Have_Male_Titles()
        {
            // Arrange
            var countries = Countries.GetValidRegisteredCountries();

            // Act
            var countriesWithoutMaleTitles = countries
                .Where(x => !x.TitlesLocalizedMale.Any())
                .Select(x => x.CountryName)
                .ToList();

            // Assert
            countriesWithoutMaleTitles.Should().HaveCount(0, $" all countries should have MALE TITLES (these are missing: {string.Join(",", countriesWithoutMaleTitles)})");
        }

        [Fact]
        public void All_Valid_Countries_Should_Have_Female_Titles()
        {
            // Arrange
            var countries = Countries.GetValidRegisteredCountries();

            // Act
            var countriesWithoutFemaleTitles = countries
                .Where(x => !x.TitlesLocalizedFemale.Any())
                .Select(x => x.CountryName)
                .ToList();

            // Assert
            countriesWithoutFemaleTitles.Should().HaveCount(0, $" all countries should have FEMALE TITLES (these are missing: {string.Join(",", countriesWithoutFemaleTitles)})");
        }

        [Fact]
        public void All_Valid_Countries_Should_Have_Male_Firstnames()
        {
            // Arrange
            var countries = Countries.GetValidRegisteredCountries();

            // Act
            var countriesWithoutFirstnamesMale = countries
                .Where(x => !x.FirstNamesMale.Any())
                .Select(x => x.CountryName)
                .ToList();

            // Assert
            countriesWithoutFirstnamesMale.Should().HaveCount(0, $" all countries should have MALE FIRSTNAMES (these are missing: {string.Join(",", countriesWithoutFirstnamesMale)})");
        }

        [Fact]
        public void All_Valid_Countries_Should_Have_Female_Firstnames()
        {
            // Arrange
            var countries = Countries.GetValidRegisteredCountries();

            // Act
            var countriesWithoutFirstnamesFemale = countries
                .Where(x => !x.FirstNamesFemale.Any())
                .Select(x => x.CountryName)
                .ToList();

            // Assert
            countriesWithoutFirstnamesFemale.Should().HaveCount(0, $" all countries should have FEMALE FIRSTNAMES (these are missing: {string.Join(",", countriesWithoutFirstnamesFemale)})");
        }

        [Fact]
        public void All_Valid_Countries_Should_Have_Lastnames()
        {
            // Arrange
            var countries = Countries.GetValidRegisteredCountries();

            // Act
            var countriesWithoutLastnames = countries
                .Where(x => !x.LastNames.Any())
                .Select(x => x.CountryName)
                .ToList();

            // Assert
            countriesWithoutLastnames.Should().HaveCount(0, $" all countries should have LASTNAMES (these are missing: {string.Join(",", countriesWithoutLastnames)})");
        }

        [Fact]
        public void All_Valid_Countries_If_HasStates_Then_Should_Have_More_Than_One_State()
        {
            // Arrange
            var countries = Countries.GetValidRegisteredCountries();

            // Act
            var countriesWithoutStates = countries
                .Where(x => x.HasStates && x.States.Count() <= 1)
                .Select(x => x.CountryName)
                .ToList();

            // Assert
            countriesWithoutStates.Should().HaveCount(0, $" all countries, if HasStates, should have MORE THAN ONE STATE (these are missing: {string.Join(",", countriesWithoutStates)})");
        }

        [Fact]
        public void All_Valid_Countries_Should_Have_A_Valid_Iso2Alpha_Code()
        {
            // Arrange
            var generator = new RandomGenerator();
            var countries = Countries.GetValidRegisteredCountries();

            // Act
            foreach (var country in countries)
            {
                var location = TzdbDateTimeZoneSource.Default.ZoneLocations
                                 .FirstOrDefault(loc => loc.CountryCode == country.CountryCodeIsoAlpha2);

                // Assert
                location.Should().NotBeNull();
            }
        }
    }
}
