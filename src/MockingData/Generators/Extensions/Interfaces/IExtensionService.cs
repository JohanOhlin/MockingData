namespace MockingData.Generators.Extensions.Interfaces
{
    public interface IExtensionService
    {
        IExtensionGenerator GetGenerator(GeneratorExtensionTypes type);
        T GetGenerator<T>() where T : IExtensionGenerator;
        void RegisterGenerator(IExtensionGenerator generator);

        //IExtensionInitiator GetInitiator(GeneratorExtensionTypes type);
        //T GetInitiator<T>() where T : IExtensionGenerator;

        ICountryInitiator CountryExtensionInitiator();
        IEmailInitiator EmailExtensionInitiator();
        IRobohashInitiator RobohashExtensionInitiator();
    }
}
