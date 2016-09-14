using System;
using System.Collections.Generic;
using System.Linq;
using MockingData.Generators.Random.Interfaces;
using MockingData.Model;

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
        /// There are two types of patterns you can use:
        /// NORMAL PATTERN
        /// This pattern is enclosed by [ and ]. No nested patterns are allowed. Each character inside the pattern
        /// will be replaced by a random character or number. Valid options are:
        /// 0 - number from 0-9
        /// 1 - number from 1-9
        /// a - any letter from a to z (only lower case)
        /// A - any letter from A to Z (only upper case)
        /// 
        /// RANGE PATTERN
        /// Use { and } to create an int range, similar to this {10-99} which would generate a random value between
        /// 10 and 99. You can't use a range pattern inside any other pattern.
        /// 
        /// EXAMPLE STRINGS
        /// abc[a]def
        /// a[0]bc[1A]def
        /// [0101010101]
        /// d[aaaaaaaaa]{10-20}d
        /// abc{1-3}de{0-9}f
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

            var isInRangePattern = false;
            var innerRangePatternIsFound = false;
            var innerRangePattern = new List<char>();
            var innerRangeData = new RangeBetween(0,0);

            foreach (var c in pattern)
            {
                // Search for pattern opening character
                if (c == '[')
                {
                    // Make sure we're not already inside another pattern
                    if (isInPattern)
                    {
                        throw new InvalidPatternException($"Can't nest normal pattern inside another pattern, for string {new string(pattern)}");
                    }
                    if (isInRangePattern)
                    {
                        throw new InvalidPatternException($"Can't start normal pattern inside a range pattern, for string {new string(pattern)}");
                    }

                    isInPattern = true;
                    innerPatternIsFound = true;
                }
                if (c == ']')
                {
                    if (isInRangePattern)
                    {
                        throw new InvalidPatternException($"Can't end normal pattern inside a range pattern, for string {new string(pattern)}");
                    }
                    if (!isInPattern)
                    {
                        throw new InvalidPatternException($"Can't end normal pattern without starting it, for string {new string(pattern)}");
                    }

                    isInPattern = false;
                }
                if (c == '{')
                {
                    // Make sure we're not already inside another pattern
                    if (isInPattern)
                    {
                        throw new InvalidPatternException($"Can't start range pattern inside a normal pattern, for string {new string(pattern)}");
                    }
                    if (isInRangePattern)
                    {
                        throw new InvalidPatternException($"Can't nest range pattern inside another pattern, for string {new string(pattern)}");
                    }

                    isInRangePattern = true;
                    innerRangePatternIsFound = true;
                }
                if (c == '}')
                {
                    if (isInPattern)
                    {
                        throw new InvalidPatternException($"Can't end range pattern inside a normal pattern, for string {new string(pattern)}");
                    }
                    if (!isInRangePattern)
                    {
                        throw new InvalidPatternException($"Can't end range pattern without starting it, for string {new string(pattern)}");
                    }

                    isInRangePattern = false;
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
                        if (isInRangePattern)
                        {
                            // We're inside a pattern and add all characters beside [ and ] to the innerPattern variable
                            if (c != '{' && c != '}')
                            {
                                innerRangePattern.Add(c);
                            }
                        }
                        else
                        {
                            if (innerRangePatternIsFound)
                            {
                                // Try to interpret inner range pattern. It should be looking like this 10-30 
                                var d = new string(innerRangePattern.ToArray());
                                var parts = d.Split('-');
                                if (parts.Length == 2)
                                {
                                    if (int.TryParse(parts[0], out innerRangeData.Min) && int.TryParse(parts[1], out innerRangeData.Max))
                                    {
                                        var rndNumber = _generator.Next(innerRangeData.Min, innerRangeData.Max);
                                        newWord.AddRange(rndNumber.ToString().ToCharArray());

                                        // Reset data because inner pattern is found and added to output data
                                        innerRangeData.Min = 0;
                                        innerRangeData.Max = 0;
                                        innerRangePattern = new List<char>();
                                        innerRangePatternIsFound = false;
                                    } else
                                    {
                                        throw new InvalidPatternException($"Pattern {new string(pattern.ToArray())} contains an invalid range section. A valid range would look like this {{10-30}}");
                                    }
                                }
                                else
                                {
                                    throw new InvalidPatternException($"Pattern {new string(pattern.ToArray())} contains an invalid range section. A valid range would look like this {{10-30}}");
                                }
                            }
                            else
                            {
                                // We're outside a pattern and we haven't got an unprocessed pattern
                                newWord.Add(c);
                            }
                        }
                    }
                }
            }

            // Have we started a pattern but not finished it?
            if (isInPattern)
            {
                throw new InvalidPatternException($"Invalid pattern. No closing character ']' found in pattern {new string(pattern)}");
            }
            if (isInRangePattern)
            {
                throw new InvalidPatternException($"Invalid range pattern. No closing character '}}' found in pattern {new string(pattern)}");
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
