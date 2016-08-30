using System;
using MockingData.Generators.Extensions.Interfaces;
using MockingData.Generators.Random.Interfaces;

namespace MockingData.Generators.Extensions
{
    public class PersonInitiator : ExtensionInitiatorBase, IPersonInitiator
    {
        public PersonInitiator(IRandomGenerator generator, IExtensionService extensionService) : base(generator, extensionService) { }

        #region IPersonInitiator
        /// <summary>
        /// Creates the generator instance for generating data
        /// </summary>
        /// <returns></returns>
        public IPersonGenerator Create()
        {
            return new PersonGenerator(Generator, ExtensionService);
        }
        #endregion

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
            return GeneratorExtensionTypes.PersonExtension;
        }
        #endregion
    }
}
