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
        private readonly IExtensionService _extensionService;

        public ItGenerator(IRandomGenerator generator, IExtensionService extensionService, 
            List<string> ipv4Adr, bool onlyUniqueIpv4, 
            List<string> ipv6Adr, bool onlyUniqueIpv6, 
            List<string> macAdr, bool onlyUniqueMac, char macSeparator)
        {
            _generator = generator;
            _extensionService = extensionService;
            _generatedIPv4Addresses = ipv4Adr;
            _onlyUniqueIPv4Addresses = onlyUniqueIpv4;
            _generatedIPv6Addresses = ipv6Adr;
            _onlyUniqueIPv6Addresses = onlyUniqueIpv6;
            _generatedMacAddresses = macAdr;
            _onlyUniqueMacAddresses = onlyUniqueMac;
            _macSeparator = macSeparator;
        }

        #region Random IP v6 Addresses
        private readonly List<string> _generatedIPv4Addresses;
        private readonly bool _onlyUniqueIPv4Addresses;

        /// <summary>
        /// Returns a list of all generated IPv4 addresses
        /// </summary>
        /// <returns></returns>
        public List<string> GeneratedIPv4Addresses()
        {
            return _generatedIPv4Addresses;
        }

        /// <summary>
        /// Creates a random IPv4 address. If OnlyUniqueIPv4 is set to true then this address is guaranteed to
        /// be unique.
        /// </summary>
        /// <returns></returns>
        public string RandomIPv4Address()
        {
            var suggestedIp = SuggestedIPv4Address();
            if (_onlyUniqueIPv4Addresses)
            {
                while (_generatedIPv4Addresses.BinarySearch(suggestedIp) >= 0)
                {
                    suggestedIp = SuggestedIPv4Address();
                }
            }
            _generatedIPv4Addresses.Add(suggestedIp);
            return suggestedIp;
        }

        /// <summary>
        /// Creates a suggested IPv4 address
        /// </summary>
        /// <returns></returns>
        private string SuggestedIPv4Address()
        {
            return string.Format($"{_generator.Next(1, 254)}." +
                                 $"{_generator.Next(0, 254)}." +
                                 $"{_generator.Next(0, 254)}." +
                                 $"{_generator.Next(1, 254)}");
        }
        #endregion


        #region Random IP v6 Addresses
        private readonly List<string> _generatedIPv6Addresses;
        private readonly bool _onlyUniqueIPv6Addresses = true;

        /// <summary>
        /// Returns a list of all generated IPv6 addresses
        /// </summary>
        /// <returns></returns>
        public List<string> GeneratedIPv6Addresses()
        {
            return _generatedIPv6Addresses;
        }

        /// <summary>
        /// Returns a random IPv6 address. If OnlyUniqueIPv6 is set to true then this address is guaranteed to
        /// be unique.
        /// </summary>
        /// <returns></returns>
        public string RandomIPv6Address()
        {
            var suggestedIp = SuggestedIPv6Address();
            if (_onlyUniqueIPv6Addresses)
            {
                while (_generatedIPv6Addresses.BinarySearch(suggestedIp) >= 0)
                {
                    suggestedIp = SuggestedIPv6Address();
                }
            }
            _generatedIPv6Addresses.Add(suggestedIp);
            return suggestedIp;
        }

        /// <summary>
        /// Returns a suggested new IPv6 address
        /// </summary>
        /// <returns></returns>
        private string SuggestedIPv6Address()
        {
            var bytes = new byte[16];
            new System.Random().NextBytes(bytes);
            var ipv6Address = new IPAddress(bytes);
            return ipv6Address.ToString();
        }
        #endregion

        #region Random MAC Addresses
        private readonly List<string> _generatedMacAddresses;
        private readonly char _macSeparator;
        private readonly bool _onlyUniqueMacAddresses;

        /// <summary>
        /// Returns a list of all generated MAC addresses
        /// </summary>
        /// <returns></returns>
        public List<string> GeneratedMacAddresses()
        {
            return _generatedIPv6Addresses;
        }

        /// <summary>
        /// Returns a random MAC address. If OnlyUniqueMAC is set to true then this address is guaranteed to
        /// be unique.
        /// </summary>
        /// <returns></returns>
        public string RandomMacAddress()
        {
            var suggestedMac = SuggestedMacAddress();
            if (_onlyUniqueMacAddresses)
            {
                while (_generatedMacAddresses.BinarySearch(suggestedMac) >= 0)
                {
                    suggestedMac = SuggestedMacAddress();
                }
            }
            _generatedMacAddresses.Add(suggestedMac);
            return suggestedMac;
        }

        /// <summary>
        /// Returns a suggested new MAC address
        /// </summary>
        /// <returns></returns>
        private string SuggestedMacAddress()
        {
            // Similar to 00:0a:95:9d:68:16
            return $"{_generator.NextHexNumber(2)}{_macSeparator}" +
                   $"{_generator.NextHexNumber(2)}{_macSeparator}" +
                   $"{_generator.NextHexNumber(2)}{_macSeparator}" +
                   $"{_generator.NextHexNumber(2)}{_macSeparator}" +
                   $"{_generator.NextHexNumber(2)}{_macSeparator}" +
                   $"{_generator.NextHexNumber(2)}";
        }
        #endregion

        #region Random functions with non-unique data
        /// <summary>
        /// Returns a random GUID
        /// </summary>
        /// <returns></returns>
        public Guid RandomGuid()
        {
            return System.Guid.NewGuid();
        }
        
        /// <summary>
        /// Returns a six number HEX code (without the leading # sometimes used)
        /// </summary>
        /// <returns></returns>
        public string RandomHexColorCode()
        {
            return _generator.NextHexNumber(6);
        }
        #endregion

        #region interface IExtensionGenerator
        /// <summary>
        /// Returns the type of this extension
        /// </summary>
        /// <returns></returns>
        public GeneratorExtensionTypes GetExtensionType()
        {
            return GeneratorExtensionTypes.ItExtension;
        }
        #endregion


    }
}
