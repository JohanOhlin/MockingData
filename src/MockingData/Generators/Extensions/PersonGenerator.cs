using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using MockingData.Generators.Extensions.Interfaces;
using MockingData.Generators.Random.Extensions;
using MockingData.Generators.Random.Interfaces;
using MockingData.Model;
using MockingData.Model.Interfaces;

namespace MockingData.Generators.Extensions
{
    public class PersonGenerator : IPersonGenerator
    {
        private readonly IRandomGenerator _generator;
        private readonly IExtensionService _extensionService;

        public PersonGenerator(IRandomGenerator generator, IExtensionService extensionService)
        {
            _generator = generator;
            _extensionService = extensionService;
        }

        #region IPersonGenerator
        public Gender RandomGender => (Gender)_generator.Next(1, 2);

        /// <summary>
        /// Generates a stream of generated person objects
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        public IEnumerable<IPerson> RandomPersons()
        {
            while (true)
            {
                yield return new Person(_generator, _extensionService);
            }
        }

        /// <summary>
        /// Generates a random title localized from the specified country and gender
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        public string RandomTitle(ICountry country, Gender gender)
        {
            try
            {
                var newTitle = gender == Gender.Male
                    ? country.TitlesLocalizedMale.RandomFromList(_generator)
                    : country.TitlesLocalizedFemale.RandomFromList(_generator);
                return newTitle;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return "n/a";
        }

        /// <summary>
        /// Generates a random first name localized from the specified country and gender
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        public string RandomFirstName(ICountry country, Gender gender)
        {
            return gender == Gender.Male ? country.FirstNamesMale.RandomFromList(_generator) :
                country.FirstNamesFemale.RandomFromList(_generator);
        }

        /// <summary>
        /// Generates a random last name localized from the specified country
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        public string RandomLastName(ICountry country)
        {
            return country.LastNames.RandomFromList(_generator);
        }

        /// <summary>
        /// The type of extension
        /// </summary>
        /// <returns></returns>
        public GeneratorExtensionTypes GetExtensionType()
        {
            return GeneratorExtensionTypes.PersonExtension;
        }
        #endregion
    }
}
