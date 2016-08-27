using FluentAssertions;
using MockingData.Generators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MockingData.Generators.Structured;
using Xunit;

namespace MockingDataTests.GeneratorTests.Serie
{
    public class When_Generating_A_Range_Of_Doubles
    {
        [Fact]
        public void Last_Value_Should_Be_Correct()
        {
            // Arrange
            var start = 1;
            var step = 0.2;
            var length = 50;
            var expectedLastValue = Math.Round((length - 1) * step + start, 1);
            var generator = new SerieGenerator();

            // Act
            var lastValue = Math.Round(generator.RangeOfDouble(start, step).Take(length).Last(), 1);

            // Assert
            lastValue.Should().Be(expectedLastValue);
        }

        [Fact]
        public void Last_Value_With_Negative_Step_Should_Be_Correct()
        {
            // Arrange
            var start = 1;
            var step = -0.3;
            var length = 10;
            var expectedLastValue = Math.Round((length - 1) * step + start,1);
            var generator = new SerieGenerator();

            // Act
            var lastValue = Math.Round(generator.RangeOfDouble(start, step).Take(length).Last(), 1);

            // Assert
            lastValue.Should().Be(expectedLastValue);
        }
    }
}
