using MockingData.Generators;
using MockingData.LocationData;
using MockingData.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using MockingData.Generators.Random;

namespace MockingDataTests.GeneratorTests.Country
{
    public class When_Working_With_Country_List
    {
        public void Validating_Existing_Country_Id_Should_Return_True() {
            // Arrange
            var generator = new RandomGenerator();
            var countries = new Dictionary<int, ICountry> {
                
            };

            //var countryGenerator = new RandomCountryGenerator(generator, countries);

            // Act
            


            // Assert

        }

        public void Validating_Non_Existing_Country_Id_Should_Return_False() {

        }
    }
}
