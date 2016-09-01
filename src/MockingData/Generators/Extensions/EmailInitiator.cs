using System;
using System.Collections.Generic;
using System.Linq;
using MockingData.Generators.Extensions.Interfaces;
using MockingData.Generators.Random.Interfaces;
using MockingData.Model.Interfaces;

namespace MockingData.Generators.Extensions
{
    public class EmailInitiator : ExtensionInitiatorBase, IEmailInitiator
    {
        public EmailInitiator(IRandomGenerator generator, IExtensionService extensionService) : base (generator, extensionService)
        {
            _onlyUniqueEmails = true;
            _generatedEmails = new List<string>();
            _namePattern = person => $"{person.FirstName}_{person.LastName}".ToLower();
            _domainNames = new List<string> { "gmail.com", "outlook.com", "hotmail.com" };
        }

        private IList<string> _generatedEmails;
        private bool _onlyUniqueEmails;
        private Func<IPerson, string> _namePattern;
        private IList<string> _domainNames;

        /// <summary>
        /// Returns the currently existing domain names being used when generating email addresses
        /// </summary>
        /// <returns></returns>
        public IList<string> ExistingDomainNames()
        {
            return _domainNames;
        }

        /// <summary>
        /// Returns any preregistered emails. By default this list is empty.
        /// </summary>
        /// <returns></returns>
        public IList<string> GeneratedEmails()
        {
            return _generatedEmails;
        }

        /// <summary>
        /// Returns if only unique emails should be created.
        /// </summary>
        /// <returns></returns>
        public bool OnlyUniqueEmails()
        {
            return _onlyUniqueEmails;
        }

        /// <summary>
        /// Set pre-existing emails that should be possible to generate, if OnlyUniqueEmails is true
        /// </summary>
        /// <param name="existingEmails"></param>
        /// <returns></returns>
        public IEmailInitiator WithPreExistingEmails(IList<string> existingEmails)
        {
            _generatedEmails = existingEmails.ToList();
            return this;
        }

        /// <summary>
        /// If all email addresses generated should be unique. 
        /// 
        /// Default value is "true"
        /// </summary>
        /// <param name="isTrue"></param>
        /// <returns></returns>
        public IEmailInitiator WithOnlyUniqueEmails(bool isTrue)
        {
            _onlyUniqueEmails = isTrue;
            return this;
        }

        /// <summary>
        /// The pattern to use when generating the user name part of the email address.
        /// 
        /// Default value is "firstname_lastname"
        /// </summary>
        /// <param name="namePattern"></param>
        /// <returns></returns>
        public IEmailInitiator WithEmailNamePattern(Func<IPerson, string> namePattern)
        {
            _namePattern = namePattern;
            return this;
        }

        /// <summary>
        /// Domain names to use after the @ in the email addresses. You can add your own list here. Don't 
        /// include the @ sign in the domain names.
        /// </summary>
        /// <param name="domainNames"></param>
        /// <returns></returns>
        public IEmailInitiator WithDomainNames(IList<string> domainNames)
        {
            _domainNames = domainNames;
            return this;
        }

        /// <summary>
        /// Creates the generator instance for generating data
        /// </summary>
        /// <returns></returns>
        public IEmailGenerator Create()
        {
            return new EmailGenerator(_onlyUniqueEmails, _generatedEmails.ToList(), _namePattern, _domainNames);
        }

        #region Abstract class ExtensionInitiatorBase 
        /// <summary>
        /// Used by the ExtensionService class for automation. Use the normal Create method instead.
        /// </summary>
        /// <returns></returns>
        public override IExtensionGenerator CreateGenericGenerator()
        {
            return Create();
        }

        /// <summary>
        /// Identifies this extension
        /// </summary>
        /// <returns></returns>
        public override GeneratorExtensionTypes GetExtensionType()
        {
            return GeneratorExtensionTypes.EmailExtension;
        }
        #endregion
    }
}
