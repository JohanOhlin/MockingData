using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using MockingData;
using MockingData.Generators.Extensions;
using MockingData.Generators.Extensions.Interfaces;
using Moq;
using Xunit;

namespace MockingDataTests.GeneratorTests.Extensions.Robohash
{
    [Trait("Extensions", "Robohash Generator")]
    public class When_Generating_Robohash_Links
    {
        [Fact]
        public void Custom_Base_Url_Should_Be_In_Output()
        {
            // Arrange
            var host = "www.testurl.com";
            var url = $"http://{host}";
            var md = new MockingDataGenerator();
            var robohashGenerator = md.ExtensionService.RobohashExtensionInitiator()
                .WithBaseUrl(url)
                .Create();

            // Act
            var robohashLink = robohashGenerator.Generate();

            // Assert
            robohashLink.Host.ShouldBeEquivalentTo(host);
        }

        [Fact]
        public void Custom_Method_Should_Be_Used()
        {
            // Arrange
            var md = new MockingDataGenerator();
            var robohashGenerator = md.ExtensionService.RobohashExtensionInitiator()
                .WithCreateMethod((person) => $"{person.FirstName}")
                .Create();
            var firstName = "UniqueFirstNameText";

            var country = new MockingData.Model.Country(1)
            {
                FirstNamesMale = new List<string> { firstName },
                FirstNamesFemale = new List<string> { firstName }
            };

            var countryGenerator = new Mock<ICountryGenerator>();
            countryGenerator.Setup(x => x.RandomCountry()).Returns(country);
            countryGenerator.Setup(x => x.GetExtensionType()).Returns(GeneratorExtensionTypes.CountryExtension);
            md.ExtensionService.RegisterGenerator(countryGenerator.Object);

            var randomPerson = new MockingData.Model.Person(md.RandomGenerator, md.ExtensionService);

            // Act
            var robohashLink = robohashGenerator.Generate(randomPerson);

            // Assert
            robohashLink.ToString().Should().Contain(firstName.ToLower());
        }
    }
}
