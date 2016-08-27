using MockingData.Generators.Extensions;
using MockingData.Generators.Extensions.Interfaces;
using MockingData.Generators.Random;
using MockingData.Generators.Random.Interfaces;

namespace MockingData
{
    public class MockingDataGenerator
    {
        public IRandomGenerator RandomGenerator { get; } 
        public IExtensionService ExtensionService { get; }

        public MockingDataGenerator(IRandomGenerator randomGenerator = null, IExtensionService extensionService = null)
        {
            RandomGenerator = randomGenerator ?? new RandomGenerator();
            ExtensionService = extensionService ?? new ExtensionService(RandomGenerator);
        }

        // Shortcuts for all other generators 
        public ICountryGenerator CountryGenerator => ExtensionService.GetGenerator<ICountryGenerator>();
        public IEmailGenerator EmailGenerator => ExtensionService.GetGenerator<IEmailGenerator>();
        public IItGenerator ItGenerator => ExtensionService.GetGenerator<IItGenerator>();
        public IPersonGenerator PersonGenerator => ExtensionService.GetGenerator<IPersonGenerator>();
        public IRobohashGenerator RobohashGenerator => ExtensionService.GetGenerator<IRobohashGenerator>();
    }
}
