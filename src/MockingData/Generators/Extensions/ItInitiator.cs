using MockingData.Generators.Extensions.Interfaces;
using MockingData.Generators.Random.Interfaces;

namespace MockingData.Generators.Extensions
{
    public class ItInitiator : IItInitiator, IExtensionInitiator
    {
        private IRandomGenerator _generator;
        private IExtensionService _service;
        public ItInitiator(IRandomGenerator generator, IExtensionService extensionService)
        {
            _generator = generator;
            _service = extensionService;
        }

        #region IItInitiator
        /// <summary>
        /// Creates the generator instance for generating data
        /// </summary>
        /// <returns></returns>
        public IItGenerator Create()
        {
            return new ItGenerator(_generator, _service);
        }

        /// <summary>
        /// Used by the ExtensionService class for automation. Use the normal Create method instead.
        /// </summary>
        /// <returns></returns>
        public IExtensionGenerator CreateGenericGenerator()
        {
            return Create();
        }
        #endregion

    }
}
