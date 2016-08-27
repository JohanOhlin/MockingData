using System.Collections.Generic;
using FluentAssertions;
using MockingData;
using MockingData.Generators.Extensions;
using MockingData.Generators.Extensions.Interfaces;
using Moq;
using Xunit;

namespace MockingDataTests.GeneratorTests.Extensions.Email
{
    [Trait("Extensions","Email Generator")]
    public class When_Generating_Emails
    {
        [Fact]
        public void Two_Persons_With_Same_Name_Should_Not_Get_The_Same_Email_When_OnlyUniqueEmails_Is_True()
        {
            // Arrange
            var md = new MockingDataGenerator();
            var emailGenerator = md.ExtensionService.EmailExtensionInitiator()
                .WithOnlyUniqueEmails(true)
                .WithDomainNames(new List<string> { "test.com" })     // Force usage of single domain
                .Create();
            md.ExtensionService.RegisterGenerator(emailGenerator);

            var country = new MockingData.Model.Country(1)
            {
                FirstNamesMale = new List<string> {"FirstName"},
                FirstNamesFemale = new List<string> {"FirstName"},
                LastNames = new List<string> {"LastName"}
            };

            var countryGenerator = new Mock<ICountryGenerator>();
            countryGenerator.Setup(x => x.RandomCountry()).Returns(country);
            countryGenerator.Setup(x => x.GetExtensionType()).Returns(GeneratorExtensionTypes.CountryExtension);
            md.ExtensionService.RegisterGenerator(countryGenerator.Object);

            var person1 = new MockingData.Model.Person(md.RandomGenerator, md.ExtensionService);
            var person2 = new MockingData.Model.Person(md.RandomGenerator, md.ExtensionService);

            // Act
            var email1 = emailGenerator.RandomEmail(person1);
            var email2 = emailGenerator.RandomEmail(person2);

            // Assert
            email1.Should().NotBe(email2);
        }

        [Fact]
        public void Two_Persons_With_Same_Name_Should_Get_The_Same_Email_When_OnlyUniqueEmails_Is_False()
        {
            // Arrange
            var md = new MockingDataGenerator();
            var emailGenerator = md.ExtensionService.EmailExtensionInitiator()
                .WithOnlyUniqueEmails(false)
                .WithDomainNames(new List<string> {"test.com"})     // Force usage of single domain
                .Create();
            md.ExtensionService.RegisterGenerator(emailGenerator);

            var country = new MockingData.Model.Country(1)
            {
                FirstNamesMale = new List<string> { "FirstName" },
                FirstNamesFemale = new List<string> { "FirstName" },
                LastNames = new List<string> { "LastName" }
            };

            var countryGenerator = new Mock<ICountryGenerator>();
            countryGenerator.Setup(x => x.RandomCountry()).Returns(country);
            countryGenerator.Setup(x => x.GetExtensionType()).Returns(GeneratorExtensionTypes.CountryExtension);
            md.ExtensionService.RegisterGenerator(countryGenerator.Object);

            var person1 = new MockingData.Model.Person(md.RandomGenerator, md.ExtensionService);
            var person2 = new MockingData.Model.Person(md.RandomGenerator, md.ExtensionService);

            // Act
            var email1 = emailGenerator.RandomEmail(person1);
            var email2 = emailGenerator.RandomEmail(person2);

            // Assert
            email1.Should().Be(email2);
        }
    }
}
