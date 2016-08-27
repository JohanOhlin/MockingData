using MockingData.Generators.Extensions.Interfaces;
using MockingData.Generators.Random.Interfaces;

namespace MockingData.Generators.Extensions
{
    public class RobohashInitiator : IRobohashInitiator
    {
        private IRandomGenerator _generator;
        private IExtensionService _service;
        public RobohashInitiator(IRandomGenerator generator, IExtensionService extensionService)
        {
            _generator = generator;
            _service = extensionService;
        }

        #region IRobohashInitiator
        private int Width { get; set; } = 300;
        private int Height { get; set; } = 300;

        public IRobohashInitiator WithSize(int width, int height)
        {
            Width = width;
            Height = height;
            return this;
        }

        /// <summary>
        /// Creates the generator instance for generating data
        /// </summary>
        /// <returns></returns>
        public IRobohashGenerator Create()
        {
            return new RobohashGenerator(_generator, _service, Width, Height);
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
