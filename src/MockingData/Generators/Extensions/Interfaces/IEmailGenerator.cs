using MockingData.Model.Interfaces;

namespace MockingData.Generators.Extensions.Interfaces
{
    public interface IEmailGenerator : IExtensionGenerator
    {
        //List<string> GeneratedEmails();
        string RandomEmail(IPerson person);
    }

}
