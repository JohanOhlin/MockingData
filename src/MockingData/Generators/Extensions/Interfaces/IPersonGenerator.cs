using System.Collections.Generic;
using MockingData.Model;
using MockingData.Model.Interfaces;

namespace MockingData.Generators.Extensions.Interfaces
{
    public interface IPersonGenerator : IExtensionGenerator
    {
        Gender RandomGender { get; }
        string RandomTitle(ICountry country, Gender gender);
        string RandomFirstName(ICountry country, Gender gender);
        string RandomLastName(ICountry country);
        IEnumerable<IPerson> RandomPersons();
    }
}
