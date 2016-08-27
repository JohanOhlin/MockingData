using System;
using MockingData.Generators.Extensions.Interfaces;
using MockingData.Generators.Random.Interfaces;
using MockingData.Model.Interfaces;

namespace MockingData.Generators.Extensions
{
    public class RobohashGenerator : IRobohashGenerator
    {
        private IRandomGenerator _generator;
        private IExtensionService _service;
        private int Width { get; set; } = 300;
        private int Height { get; set; } = 300;
        public RobohashGenerator(IRandomGenerator generator, IExtensionService extensionService, int width, int height)
        {
            _generator = generator;
            _service = extensionService;
            Width = width;
            Height = height;
        }

        #region IRobohashGenerator
        private string Key { get; set; } = Guid.NewGuid().ToString();

        private Uri CreateUri()
        {
            var uri = $"https://robohash.org/{Key}";
            if (Width > 0 && Height > 0)
            {
                uri += $"?size={Width}x{Height}";
            }
            return new Uri(uri);
        }

        public Uri Generate()
        {
            Key = Guid.NewGuid().ToString();
            return CreateUri();
        }

        public Uri Generate(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                Key = text;
            }
            else
            {
                Key = Guid.NewGuid().ToString();
            }
            return CreateUri();
        }

        public Uri Generate(IPerson person)
        {
            if (person != null)
            {
                Key = $"{person.FirstName}{person.LastName}{person.City.Name}".ToLower();
            }
            else
            {
                Key = Guid.NewGuid().ToString().ToLower();
            }
            return CreateUri();
        }

        public GeneratorExtensionTypes GetExtensionType()
        {
            return GeneratorExtensionTypes.RobohashExtension;
        }
        #endregion

    }
}
