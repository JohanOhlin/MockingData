using MockingData.Generators.Extensions.Interfaces;
using MockingData.Generators.Random.Interfaces;

namespace MockingData.Generators.Extensions
{
    public class PersonInitiator : IPersonInitiator
    {
        private IRandomGenerator _generator;
        private IExtensionService _service;

        public PersonInitiator(IRandomGenerator generator, IExtensionService extensionService)
        {
            _generator = generator;
            _service = extensionService;
        }

        #region IPersonInitiator
        public GeneratorExtensionTypes GetExtensionType()
        {
            return GeneratorExtensionTypes.PersonExtension;
        }

        /// <summary>
        /// Creates the generator instance for generating data
        /// </summary>
        /// <returns></returns>
        public IPersonGenerator Create()
        {
            return new PersonGenerator(_generator, _service);
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
