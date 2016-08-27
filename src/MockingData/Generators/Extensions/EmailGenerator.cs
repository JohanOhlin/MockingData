using System;
using System.Collections.Generic;
using MockingData.Generators.Extensions.Interfaces;
using MockingData.Generators.Random.Extensions;
using MockingData.Model.Interfaces;

namespace MockingData.Generators.Extensions
{
    public class EmailGenerator : IEmailGenerator
    {
        public EmailGenerator(bool onlyUniqueEmails, List<string> generatedEmails, Func<IPerson, string> namePattern, IList<string> domainNames)
        {
            OnlyUniqueEmails = onlyUniqueEmails;
            GeneratedEmails = generatedEmails;
            NamePattern = namePattern;
            DomainNames = domainNames;
        }

        public List<string> GeneratedEmails { get; private set; }
        public bool OnlyUniqueEmails { get; private set; }
        public Func<IPerson, string> NamePattern { get; private set; }
        public IList<string> DomainNames { get; private set; }
    
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
            var nameSection = NamePattern(person).ToLower();
            var domain = DomainNames.RandomFromList().ToLower();
            var suggestedEmail = $"{nameSection}@{domain}";

            if (OnlyUniqueEmails)
            {
                var numerator = 1;
                while (GeneratedEmails.BinarySearch(suggestedEmail) >= 0)
                {
                    suggestedEmail = $"{nameSection}_{numerator++}@{domain}";
                }
            }
            GeneratedEmails.Add(suggestedEmail);

            emailPerson?.SetEmailAddress(suggestedEmail);

            return suggestedEmail;
        }
        #endregion

        public GeneratorExtensionTypes GetExtensionType()
        {
            return GeneratorExtensionTypes.EmailExtension;
        }
    }
}
