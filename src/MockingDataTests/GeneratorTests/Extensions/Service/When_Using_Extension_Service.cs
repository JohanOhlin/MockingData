using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using MockingData;
using MockingData.Generators.Extensions;
using MockingData.Generators.Extensions.Interfaces;
using Xunit;

namespace MockingDataTests.GeneratorTests.Extensions.Service
{
    [Trait("Extensions", "Extension Service")]
    public class When_Using_Extension_Service
    {
        [Fact]
        public void Two_Calls_To_GetGenerator_Should_Return_The_Same_Instance()
        {
            // Arrange
            var md = new MockingDataGenerator();
            var es = md.ExtensionService;

            // Act
            var x = es.GetGenerator(GeneratorExtensionTypes.EmailExtension);
            var x2 = es.GetGenerator<IEmailGenerator>();

            // Assert
            x.Should().BeSameAs(x2);
        }

        [Fact]
        public void Two_Calls_To_GetGenerator_With_RegisterGenerator_Inbetween_Should_Not_Return_The_Same_Instance()
        {
            // Arrange
            var md = new MockingDataGenerator();
            var es = md.ExtensionService;           
            var builder = es.EmailExtensionInitiator().Create();

            // Act
            var x = md.ExtensionService.GetGenerator(GeneratorExtensionTypes.EmailExtension);
            es.RegisterGenerator(builder);
            var x2 = es.GetGenerator<IEmailGenerator>();

            // Assert
            x.Should().NotBeSameAs(x2);
        }

        [Fact]
        public void Object_Being_Registered_Should_Be_Same_As_Returned_Object()
        {
            // Arrange
            var md = new MockingDataGenerator();
            var es = md.ExtensionService;
            var createdGenerator = es.EmailExtensionInitiator().Create();

            // Act
            es.RegisterGenerator(createdGenerator);
            var retrievedGenerator = es.GetGenerator(GeneratorExtensionTypes.EmailExtension);

            // Assert
            retrievedGenerator.Should().BeSameAs(createdGenerator);
        }
    }
}
