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
            const string pattern = "abc[A01a]def";
            const string regexPattern = "abc[A-Z][0-9][1-9][a-z]def";

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
            const string pattern = "abcdef";
            const string regexPattern = "abcdef";

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
            const string pattern = "ab[]cdef";
            const string regexPattern = "abcdef";

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
            const string pattern = "ab[]cd[]ef";
            const string regexPattern = "abcdef";

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
            const string pattern = "[]abcdef";
            const string regexPattern = "abcdef";

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
            const string pattern = "abcdef[]";
            const string regexPattern = "abcdef";

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
            const string pattern = "abcdef[aA01]";
            const string regexPattern = "abcdef[a-z][A-Z][0-9][1-9]";

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
            const string pattern = "[aA01]abcdef";
            const string regexPattern = "[a-z][A-Z][0-9][1-9]abcdef";

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
            const string pattern = "a[aA]bcde[01]f";
            const string regexPattern = "a[a-z][A-Z]bcde[0-9][1-9]f";

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
            const string pattern = "a[a][A]bcdef";
            const string regexPattern = "a[a-z][A-Z]bcdef";

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
            const string pattern = "a[x]bcdef";

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
            const string pattern = "abcde[a0";

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
            const string pattern = "abcde[a[0]]";

            // Act
            var exception = Assert.Throws<InvalidPatternException>(() => pm.RandomAlphaNumFromPattern(pattern));

            // Assert
            exception.Should().NotBeNull();
        }

        [Fact]
        public void Pattern_With_Nested_Inner_Range_Pattern_Should_Throw_Exception()
        {
            // Arrange
            var md = new MockingDataGenerator();
            var pm = new PatternMatching(md.RandomGenerator);
            const string pattern = "abcde[a{0-10}]";

            // Act
            var exception = Assert.Throws<InvalidPatternException>(() => pm.RandomAlphaNumFromPattern(pattern));

            // Assert
            exception.Should().NotBeNull();
        }

        [Fact]
        public void Range_Pattern_Without_Closing_Tag_Should_Throw_Exception()
        {
            // Arrange
            var md = new MockingDataGenerator();
            var pm = new PatternMatching(md.RandomGenerator);
            const string pattern = "abcde{0-10";

            // Act
            var exception = Assert.Throws<InvalidPatternException>(() => pm.RandomAlphaNumFromPattern(pattern));

            // Assert
            exception.Should().NotBeNull();
        }

        [Fact]
        public void Range_Pattern_Without_Starting_Tag_Should_Throw_Exception()
        {
            // Arrange
            var md = new MockingDataGenerator();
            var pm = new PatternMatching(md.RandomGenerator);
            const string pattern = "abcde0-10}";

            // Act
            var exception = Assert.Throws<InvalidPatternException>(() => pm.RandomAlphaNumFromPattern(pattern));

            // Assert
            exception.Should().NotBeNull();
        }

        [Fact]
        public void Range_Pattern_With_Nested_Inner_Range_Pattern_Should_Throw_Exception()
        {
            // Arrange
            var md = new MockingDataGenerator();
            var pm = new PatternMatching(md.RandomGenerator);
            const string pattern = "abcde{a{0-10}}";

            // Act
            var exception = Assert.Throws<InvalidPatternException>(() => pm.RandomAlphaNumFromPattern(pattern));

            // Assert
            exception.Should().NotBeNull();
        }

        [Fact]
        public void Range_Pattern_Should_Return_Value_Within_Range()
        {
            // Arrange
            var md = new MockingDataGenerator();
            var pm = new PatternMatching(md.RandomGenerator);
            const string pattern = "{0-10}";

            // Act
            var result = int.Parse(pm.RandomAlphaNumFromPattern(pattern));

            // Assert
            result.Should().BeGreaterOrEqualTo(0).And.BeLessOrEqualTo(10);
        }

        [Fact]
        public void Double_Range_Pattern_Next_To_Each_Other_Should_Generate_Correct_Return_Value()
        {
            // Arrange
            var md = new MockingDataGenerator();
            var pm = new PatternMatching(md.RandomGenerator);
            const string pattern = "a{10-20}{0-2}bcdef";
            const string regexPattern = @"a\d{3}bcdef";

            // Act
            var patternTranslated = pm.RandomAlphaNumFromPattern(pattern);

            // Assert
            Regex.IsMatch(patternTranslated, regexPattern).Should().BeTrue();
        }

        [Fact]
        public void Invalid_Range_Pattern_Should_Throw_Exception()
        {
            // Arrange
            var md = new MockingDataGenerator();
            var pm = new PatternMatching(md.RandomGenerator);
            const string pattern = "abcde{10}"; // Missing range, should be 1-10 or similar

            // Act
            var exception = Assert.Throws<InvalidPatternException>(() => pm.RandomAlphaNumFromPattern(pattern));

            // Assert
            exception.Should().NotBeNull();
        }
    }
}
