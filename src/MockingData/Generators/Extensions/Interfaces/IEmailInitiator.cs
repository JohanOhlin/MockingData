using System;
using System.Collections.Generic;
using MockingData.Model.Interfaces;

namespace MockingData.Generators.Extensions.Interfaces
{
    public interface IEmailInitiator : IExtensionInitiator
    {
        bool OnlyUniqueEmails();
        IList<string> GeneratedEmails();
        IList<string> ExistingDomainNames();

        IEmailInitiator WithPreExistingEmails(IList<string> existingEmails);
        IEmailInitiator WithOnlyUniqueEmails(bool isTrue);
        IEmailInitiator WithEmailNamePattern(Func<IPerson, string> func);
        IEmailInitiator WithDomainNames(IList<string> domainNames);
        IEmailGenerator Create();
    }
}
