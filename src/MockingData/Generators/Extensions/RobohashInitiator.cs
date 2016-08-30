using System;
using MockingData.Generators.Extensions.Interfaces;
using MockingData.Generators.Random.Interfaces;
using MockingData.Model.Interfaces;

namespace MockingData.Generators.Extensions
{
    public class RobohashInitiator : ExtensionInitiatorBase, IRobohashInitiator
    {
        public RobohashInitiator(IRandomGenerator generator, IExtensionService extensionService) : base(generator, extensionService)
        {
            CreateMethod = (person) => $"{person.FirstName}{person.LastName}{person.City}";
        }

        #region IRobohashInitiator
        private int Width { get; set; } = 300;
        private int Height { get; set; } = 300;
        private string BaseUrl { get; set; } = "https://robohash.org";
        private Func<IPerson, string> CreateMethod { get; set; }

        public IRobohashInitiator WithSize(int width, int height)
        {
            Width = width;
            Height = height;
            return this;
        }

        public IRobohashInitiator WithCreateMethod(Func<IPerson, string> method)
        {
            CreateMethod = method;
            return this;
        }

        public IRobohashInitiator WithBaseUrl(string url)
        {
            BaseUrl = url;
            return this;
        }

        /// <summary>
        /// Creates the generator instance for generating data
        /// </summary>
        /// <returns></returns>
        public IRobohashGenerator Create()
        {
            return new RobohashGenerator(Width, Height, CreateMethod, BaseUrl);
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
            return GeneratorExtensionTypes.RobohashExtension;
        }
        #endregion

    }
}
