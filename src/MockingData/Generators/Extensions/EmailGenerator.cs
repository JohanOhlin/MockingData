using System;
using System.Collections.Generic;
using MockingData.Generators.Extensions.Interfaces;
using MockingData.Generators.Random.Extensions;
using MockingData.Model.Interfaces;

namespace MockingData.Generators.Extensions
{
    public class EmailGenerator : IEmailGenerator
    {
        private readonly List<string> _generatedEmails;
        private readonly bool _onlyUniqueEmails;
        private readonly Func<IPerson, string> _namePattern;
        private readonly IList<string> _domainNames;

        public EmailGenerator(bool onlyUniqueEmails, List<string> generatedEmails, Func<IPerson, string> namePattern, IList<string> domainNames)
        {
            _onlyUniqueEmails = onlyUniqueEmails;
            _generatedEmails = generatedEmails;
            _namePattern = namePattern;
            _domainNames = domainNames;
        }
        
        #region IEmailGenerator functions
        public string RandomEmail(IPerson person)
        {
            // Check if person already has an assigned email address
            var emailPerson = person as IPersonInternal;
            if (emailPerson != null && emailPerson.HasEmailAddress())
            {
                return emailPerson.GetEmailAddress();
            }

            // Person has no email so we generate a new one
            var nameSection = _namePattern(person).ToLower();
            var domain = _domainNames.RandomFromList().ToLower();
            var suggestedEmail = $"{nameSection}@{domain}";

            if (_onlyUniqueEmails)
            {
                var numerator = 1;
                while (_generatedEmails.BinarySearch(suggestedEmail) >= 0)
                {
                    suggestedEmail = $"{nameSection}_{numerator++}@{domain}";
                }
            }
            _generatedEmails.Add(suggestedEmail);

            emailPerson?.SetEmailAddress(suggestedEmail);

            return suggestedEmail;
        }
        #endregion

        #region interface IExtensionGenerator
        /// <summary>
        /// Returns the type of this extension
        /// </summary>
        /// <returns></returns>
        public GeneratorExtensionTypes GetExtensionType()
        {
            return GeneratorExtensionTypes.EmailExtension;
        }
        #endregion
    }
}
