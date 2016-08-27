using System;
using System.Collections.Generic;
using MockingData.Generators.Extensions.Interfaces;
using System.Net;
using MockingData.Generators.Random.Interfaces;

namespace MockingData.Generators.Extensions
{
    public class ItGenerator : IItGenerator
    {
        private readonly IRandomGenerator _generator;
        private readonly IExtensionService _service;
        public ItGenerator(IRandomGenerator generator, IExtensionService extensionService)
        {
            _generator = generator;
            _service = extensionService;
        }

        #region IItGenerator
        #region Random IP v4 Addresses
        private List<string> _generatedIPv4Addresses;
        public List<string> GeneratedIPv4Addresses
        {
            get { return _generatedIPv4Addresses ?? (_generatedIPv4Addresses = new List<string>()); }
            set
            {
                _generatedIPv4Addresses = value;
            }
        }
        public bool OnlyUniqueIPv4Addresses { get; set; } = true;
        public string RandomIPv4Address()
        {
            var suggestedIp = SuggestedIPv4Address();
            if (OnlyUniqueIPv4Addresses)
            {
                while (GeneratedIPv4Addresses.BinarySearch(suggestedIp) >= 0)
                {
                    suggestedIp = SuggestedIPv4Address();
                }
            }
            GeneratedIPv4Addresses.Add(suggestedIp);
            return suggestedIp;
        }

        private string SuggestedIPv4Address()
        {
            return string.Format($"{_generator.Next(1, 254)}.{_generator.Next(0, 254)}.{_generator.Next(0, 254)}.{_generator.Next(1, 254)}");
        }
        #endregion


        #region Random IP v6 Addresses
        private List<string> _generatedIPv6Addresses;
        public List<string> GeneratedIPv6Addresses
        {
            get { return _generatedIPv6Addresses ?? (_generatedIPv6Addresses = new List<string>()); }
            set
            {
                _generatedIPv6Addresses = value;
            }
        }
        public bool OnlyUniqueIPv6Addresses { get; set; } = true;
        public string RandomIPv6Address()
        {
            var suggestedIp = SuggestedIPv6Address();
            if (OnlyUniqueIPv6Addresses)
            {
                while (GeneratedIPv6Addresses.BinarySearch(suggestedIp) >= 0)
                {
                    suggestedIp = SuggestedIPv6Address();
                }
            }
            GeneratedIPv6Addresses.Add(suggestedIp);
            return suggestedIp;
        }
        private string SuggestedIPv6Address()
        {
            byte[] bytes = new byte[16];
            new System.Random().NextBytes(bytes);
            IPAddress ipv6Address = new IPAddress(bytes);
            return ipv6Address.ToString();
        }
        #endregion


        #region Random MAC Addresses
        private List<string> _generatedMacAddresses;
        public List<string> GeneratedMacAddresses
        {
            get
            {
                if (_generatedMacAddresses == null)
                {
                    _generatedMacAddresses = new List<string>();
                }
                return _generatedMacAddresses;
            }
            set
            {
                _generatedMacAddresses = value;
            }
        }
        public bool OnlyUniqueMacAddresses { get; set; } = true;
        public string RandomMacAddress(char separator = ':')
        {
            // Similar to 00:0a:95:9d:68:16
            return $"{_generator.NextHexNumber(2)}{separator}{_generator.NextHexNumber(2)}{separator}{_generator.NextHexNumber(2)}{separator}{_generator.NextHexNumber(2)}{separator}{_generator.NextHexNumber(2)}{separator}{_generator.NextHexNumber(2)}";
        }
        #endregion


        #region Random functions with non-unique data
        public Guid RandomGuid()
        {
            return System.Guid.NewGuid();
        }

        public string RandomHexColorCode()
        {
            return _generator.NextHexNumber(6);
        }

        public GeneratorExtensionTypes GetExtensionType()
        {
            return GeneratorExtensionTypes.ItExtension;
        }


        #endregion
        #endregion

    }
}
