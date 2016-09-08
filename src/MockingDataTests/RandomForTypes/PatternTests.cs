using System.Text.RegularExpressions;
using FluentAssertions;
using MockingData;
using MockingData.Generators.Random;
using Xunit;

namespace MockingDataTests.RandomForTypes
{
    public class PatternTests
    {
        [Fact]
        public void Pattern_With_Aa01_Should_Generate_Correct_Return_Value()
        {
            // Arrange
            var md = new MockingDataGenerator();
            var pm = new PatternMatching(md.RandomGenerator);
            var pattern = "abc[A01a]def";
            var regexPattern = "abc[A-Z][0-9][1-9][a-z]def";

            // Act
            var patternTranslated = pm.RandomAlphaNumFromPattern(pattern);

            // Assert
            Regex.IsMatch(patternTranslated, regexPattern).Should().BeTrue();
        }

        [Fact]
        public void Pattern_Without_Inner_Pattern_Should_Return_Outer_Pattern_Only()
        {
            // Arrange
            var md = new MockingDataGenerator();
            var pm = new PatternMatching(md.RandomGenerator);
            var pattern = "abcdef";
            var regexPattern = "abcdef";

            // Act
            var patternTranslated = pm.RandomAlphaNumFromPattern(pattern);

            // Assert
            Regex.IsMatch(patternTranslated, regexPattern).Should().BeTrue();
        }

        [Fact]
        public void Pattern_With_Empty_Inner_Pattern_Should_Return_Outer_Pattern_Only()
        {
            // Arrange
            var md = new MockingDataGenerator();
            var pm = new PatternMatching(md.RandomGenerator);
            var pattern = "ab[]cdef";
            var regexPattern = "abcdef";

            // Act
            var patternTranslated = pm.RandomAlphaNumFromPattern(pattern);

            // Assert
            Regex.IsMatch(patternTranslated, regexPattern).Should().BeTrue();
        }

        [Fact]
        public void Pattern_With_Double_Empty_Inner_Pattern_Should_Return_Outer_Pattern_Only()
        {
            // Arrange
            var md = new MockingDataGenerator();
            var pm = new PatternMatching(md.RandomGenerator);
            var pattern = "ab[]cd[]ef";
            var regexPattern = "abcdef";

            // Act
            var patternTranslated = pm.RandomAlphaNumFromPattern(pattern);

            // Assert
            Regex.IsMatch(patternTranslated, regexPattern).Should().BeTrue();
        }

        [Fact]
        public void Pattern_With_Starting_Empty_Inner_Pattern_Should_Return_Outer_Pattern_Only()
        {
            // Arrange
            var md = new MockingDataGenerator();
            var pm = new PatternMatching(md.RandomGenerator);
            var pattern = "[]abcdef";
            var regexPattern = "abcdef";

            // Act
            var patternTranslated = pm.RandomAlphaNumFromPattern(pattern);

            // Assert
            Regex.IsMatch(patternTranslated, regexPattern).Should().BeTrue();
        }

        [Fact]
        public void Pattern_With_Ending_Empty_Inner_Pattern_Should_Return_Outer_Pattern_Only()
        {
            // Arrange
            var md = new MockingDataGenerator();
            var pm = new PatternMatching(md.RandomGenerator);
            var pattern = "abcdef[]";
            var regexPattern = "abcdef";

            // Act
            var patternTranslated = pm.RandomAlphaNumFromPattern(pattern);

            // Assert
            Regex.IsMatch(patternTranslated, regexPattern).Should().BeTrue();
        }

        [Fact]
        public void Pattern_With_Ending_Inner_Pattern_Should_Generate_Correct_Return_Value()
        {
            // Arrange
            var md = new MockingDataGenerator();
            var pm = new PatternMatching(md.RandomGenerator);
            var pattern = "abcdef[aA01]";
            var regexPattern = "abcdef[a-z][A-Z][0-9][1-9]";

            // Act
            var patternTranslated = pm.RandomAlphaNumFromPattern(pattern);

            // Assert
            Regex.IsMatch(patternTranslated, regexPattern).Should().BeTrue();
        }

        [Fact]
        public void Pattern_With_Starting_Inner_Pattern_Should_Generate_Correct_Return_Value()
        {
            // Arrange
            var md = new MockingDataGenerator();
            var pm = new PatternMatching(md.RandomGenerator);
            var pattern = "[aA01]abcdef";
            var regexPattern = "[a-z][A-Z][0-9][1-9]abcdef";

            // Act
            var patternTranslated = pm.RandomAlphaNumFromPattern(pattern);

            // Assert
            Regex.IsMatch(patternTranslated, regexPattern).Should().BeTrue();
        }

        [Fact]
        public void Pattern_With_Double_Inner_Pattern_Should_Generate_Correct_Return_Value()
        {
            // Arrange
            var md = new MockingDataGenerator();
            var pm = new PatternMatching(md.RandomGenerator);
            var pattern = "a[aA]bcde[01]f";
            var regexPattern = "a[a-z][A-Z]bcde[0-9][1-9]f";

            // Act
            var patternTranslated = pm.RandomAlphaNumFromPattern(pattern);

            // Assert
            Regex.IsMatch(patternTranslated, regexPattern).Should().BeTrue();
        }

        [Fact]
        public void Pattern_With_Double_Inner_Pattern_Next_To_Each_Other_Should_Generate_Correct_Return_Value()
        {
            // Arrange
            var md = new MockingDataGenerator();
            var pm = new PatternMatching(md.RandomGenerator);
            var pattern = "a[a][A]bcdef";
            var regexPattern = "a[a-z][A-Z]bcdef";

            // Act
            var patternTranslated = pm.RandomAlphaNumFromPattern(pattern);

            // Assert
            Regex.IsMatch(patternTranslated, regexPattern).Should().BeTrue();
        }

        [Fact]
        public void Pattern_With_Invalid_Inner_Pattern_Should_Throw_Exception()
        {
            // Arrange
            var md = new MockingDataGenerator();
            var pm = new PatternMatching(md.RandomGenerator);
            var pattern = "a[x]bcdef";

            // Act
            var exception = Assert.Throws<InvalidPatternException>(() => pm.RandomAlphaNumFromPattern(pattern));

            // Assert
            exception.Should().NotBeNull();
        }

        [Fact]
        public void Pattern_With_Not_Closed_Inner_Pattern_Should_Throw_Exception()
        {
            // Arrange
            var md = new MockingDataGenerator();
            var pm = new PatternMatching(md.RandomGenerator);
            var pattern = "abcde[a0";

            // Act
            var exception = Assert.Throws<InvalidPatternException>(() => pm.RandomAlphaNumFromPattern(pattern));

            // Assert
            exception.Should().NotBeNull();
        }

        [Fact]
        public void Pattern_With_Nested_Inner_Pattern_Should_Throw_Exception()
        {
            // Arrange
            var md = new MockingDataGenerator();
            var pm = new PatternMatching(md.RandomGenerator);
            var pattern = "abcde[a[0]]";

            // Act
            var exception = Assert.Throws<InvalidPatternException>(() => pm.RandomAlphaNumFromPattern(pattern));

            // Assert
            exception.Should().NotBeNull();
        }
    }
}
