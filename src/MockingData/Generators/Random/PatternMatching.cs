using System;
using System.Collections.Generic;
using MockingData.Generators.Random.Interfaces;

namespace MockingData.Generators.Random
{
    public class PatternMatching : IPatternMatching
    {
        private readonly IRandomGenerator _generator;

        public PatternMatching(IRandomGenerator generator)
        {
            _generator = generator;
        }

        /// <summary>
        /// Transforms a string with internal pattern to a string with random sections.
        /// 
        /// Pattern is enclosed by [ and ]. No nested patterns are allowed. Each character inside the pattern
        /// will be replaced by a random character or number. Valid options are:
        /// 0 - number from 0-9
        /// 1 - number from 1-9
        /// a - any letter from a to z (only lower case)
        /// A - any letter from A to Z (only upper case)
        /// 
        /// EXAMPLE STRINGS
        /// abc[a]def
        /// a[0]bc[1A]def
        /// [0101010101]
        /// d[aaaaaaaaa]d
        /// </summary>
        /// <param name="pattern">String containing pattern</param>
        /// <returns></returns>
        public string RandomAlphaNumFromPattern(string pattern)
        {
            return new string(RandomAlphaNumFromPattern(pattern.ToCharArray()));
        }


        private char[] RandomAlphaNumFromPattern(char[] pattern)
        {
            var newWord = new List<char>();
            var isInPattern = false;
            var innerPatternIsFound = false;
            var innerPattern = new List<char>();

            foreach (var c in pattern)
            {
                // Search for pattern opening character
                if (c == '[')
                {
                    // Make sure we're not already inside another pattern
                    if (isInPattern)
                    {
                        throw new InvalidPatternException($"Can't nest pattern inside pattern for string {new string(pattern)}");
                    }

                    isInPattern = true;
                    innerPatternIsFound = true;
                }
                if (c == ']')
                {
                    isInPattern = false;
                }


                if (isInPattern)
                {
                    // We're inside a pattern and add all characters beside [ and ] to the innerPattern variable
                    if (c != '[' && c != ']')
                    {
                        innerPattern.Add(c);
                    }
                }
                else
                {
                    // We're not inside a pattern

                    // Check if we've just exited a pattern
                    if (innerPatternIsFound)
                    {
                        var inner = GetRandomFromInnerPattern(innerPattern.ToArray());
                        newWord.AddRange(inner);

                        // inner pattern is processed and we reset the list
                        innerPatternIsFound = false;                        
                        innerPattern = new List<char>();
                    }
                    else
                    {
                        // We're outside a pattern and we haven't got an unprocessed pattern
                        newWord.Add(c);
                    }
                }
            }

            // Have we started a pattern but not finished it?
            if (isInPattern)
            {
                throw new InvalidPatternException($"Invalid pattern. No closing character ']' found in pattern {new string(pattern)}");
            }

            return newWord.ToArray();
        }

        private char[] GetRandomFromInnerPattern(char[] pattern)
        {
            var newWord = new List<char>();
            foreach (var c in pattern)
            {
                if (c == 'a') {
                    newWord.AddRange(_generator.RandomString(1, "abcdefghijklmnopqrstuvxyz".ToCharArray()));
                } else if (c == 'A') {
                    newWord.AddRange(_generator.RandomString(1, "ABCDEFGHIJKLMNOPQRSTUVXYZ".ToCharArray()));
                } else if (c == '0') {
                    var newInt = _generator.Next(0, 9).ToString();
                    newWord.Add(Convert.ToChar(newInt));
                } else if (c == '1') {
                    var newInt = _generator.Next(1, 9).ToString();
                    newWord.Add(Convert.ToChar(newInt));
                } else { throw new InvalidPatternException($"Invalid character {c} in pattern"); }
            }
            return newWord.ToArray();
        }
    }

    public class InvalidPatternException : Exception
    {
        public InvalidPatternException(string message) : base(message) {}
    }
}
