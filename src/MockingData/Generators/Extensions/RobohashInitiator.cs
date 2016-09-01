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

        /// <summary>
        /// The size to use for the images. 
        /// 
        /// Default is 300x300px.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public IRobohashInitiator WithSize(int width, int height)
        {
            Width = width;
            Height = height;
            return this;
        }

        /// <summary>
        /// How a person object should be transformed into the identifier in the URL
        /// 
        /// Default is "FirstnameLastnameCity"
        /// </summary>
        /// <param name="method"></param>
        /// <returns></returns>
        public IRobohashInitiator WithCreateMethod(Func<IPerson, string> method)
        {
            CreateMethod = method;
            return this;
        }

        /// <summary>
        /// The base url to use when generating the image links. 
        /// 
        /// Default value is https://robohash.org
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
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
