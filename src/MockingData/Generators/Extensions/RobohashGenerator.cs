using System;
using MockingData.Generators.Extensions.Interfaces;
using MockingData.Model.Interfaces;

namespace MockingData.Generators.Extensions
{
    public class RobohashGenerator : IRobohashGenerator
    {
        private int Width { get; set; }
        private int Height { get; set; }
        private Func<IPerson, string> CreateMethod { get; set; }
        private string BaseUrl { get; set; }
        public RobohashGenerator(int width, int height, Func<IPerson, string> createMethod, string baseUrl)
        {
            Width = width;
            Height = height;
            BaseUrl = baseUrl;
            CreateMethod = createMethod;
        }

        #region IRobohashGenerator
        /// <summary>
        /// Todo: Rewrite this function
        /// </summary>
        /// <returns></returns>
        private Uri CreateUri(string key)
        {
            var uri = $"{BaseUrl}/{key.ToLower()}";
            if (Width > 0 && Height > 0)
            {
                uri += $"?size={Width}x{Height}";
            }
            return new Uri(uri);
        }

        /// <summary>
        /// Returns URI for a completely random robohash image
        /// </summary>
        /// <returns></returns>
        public Uri Generate()
        {
            return CreateUri(Guid.NewGuid().ToString());
        }

        /// <summary>
        /// Returns URI for given text
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public Uri Generate(string text)
        {
            string Key;
            if (!string.IsNullOrEmpty(text))
            {
                Key = text;
            }
            else
            {
                Key = Guid.NewGuid().ToString();
            }
            return CreateUri(Key);
        }

        /// <summary>
        /// Returns URI for given person
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public Uri Generate(IPerson person)
        {
            string Key;
            if (person != null)
            {
                Key = CreateMethod(person).ToLower();
            }
            else
            {
                Key = Guid.NewGuid().ToString().ToLower();
            }
            return CreateUri(Key);
        }

        /// <summary>
        /// Get type of extension
        /// </summary>
        /// <returns></returns>
        public GeneratorExtensionTypes GetExtensionType()
        {
            return GeneratorExtensionTypes.RobohashExtension;
        }
        #endregion

    }
}
