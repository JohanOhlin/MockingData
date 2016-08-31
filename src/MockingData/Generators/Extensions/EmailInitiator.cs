﻿using System;
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

        private List<string> _generatedEmails;
        private bool _onlyUniqueEmails;
        private Func<IPerson, string> _namePattern;
        private IList<string> _domainNames;

        public IEmailInitiator WithPreExistingEmails(IList<string> existingEmails)
        {
            _generatedEmails = existingEmails.ToList();
            return this;
        }

        public IEmailInitiator WithOnlyUniqueEmails(bool isTrue)
        {
            _onlyUniqueEmails = isTrue;
            return this;
        }

        public IEmailInitiator WithEmailNamePattern(Func<IPerson, string> namePattern)
        {
            _namePattern = namePattern;
            return this;
        }

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
            return new EmailGenerator(_onlyUniqueEmails, _generatedEmails, _namePattern, _domainNames);
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