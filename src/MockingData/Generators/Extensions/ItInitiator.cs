using System.Collections;
using System.Collections.Generic;
using MockingData.Generators.Extensions.Interfaces;
using MockingData.Generators.Random.Interfaces;

namespace MockingData.Generators.Extensions
{
    public class ItInitiator : ExtensionInitiatorBase, IItInitiator
    {

        public ItInitiator(IRandomGenerator generator, IExtensionService extensionService) : base (generator, extensionService)
        {
        }


        #region IPv4
        private bool _onlyUniqueIpV4Addresses = true;
        private List<string> _existingIpV4Addresses = new List<string>();

        /// <summary>
        /// Set if only unique IPv4 addresses should be added. If you're creating a huge amount of data then
        /// setting this value to false will increase performance.
        /// </summary>
        /// <param name="isTrue"></param>
        /// <returns></returns>
        public IItInitiator UsingOnlyUniqueIPv4Addresses(bool isTrue)
        {
            _onlyUniqueIpV4Addresses = isTrue;
            return this;
        }

        /// <summary>
        /// Pre-existing IPv4 addresses. Use this setting in combination with UsingOnlyUniqueIPv4Addresses to 
        /// block certain addresses from being used.
        /// </summary>
        /// <param name="existingIpV4Addresses"></param>
        /// <returns></returns>
        public IItInitiator WithExistingIpV4Addresses(List<string> existingIpV4Addresses)
        {
            _existingIpV4Addresses = existingIpV4Addresses;
            return this;
        }
        #endregion

        #region IPv6
        private bool _onlyUniqueIpV6Addresses = true;
        private List<string> _existingIpV6Addresses = new List<string>();

        /// <summary>
        /// Set if only unique IPv6 addresses should be added. If you're creating a huge amount of data then
        /// setting this value to false will increase performance.
        /// </summary>
        /// <param name="isTrue"></param>
        /// <returns></returns>
        public IItInitiator UsingOnlyUniqueIPv6Addresses(bool isTrue)
        {
            _onlyUniqueIpV6Addresses = isTrue;
            return this;
        }

        /// <summary>
        /// Pre-existing IPv6 addresses. Use this setting in combination with UsingOnlyUniqueIPv6Addresses to 
        /// block certain addresses from being used.
        /// </summary>
        /// <param name="existingIpV6Addresses"></param>
        /// <returns></returns>
        public IItInitiator WithExistingIpV6Addresses(List<string> existingIpV6Addresses)
        {
            _existingIpV6Addresses = existingIpV6Addresses;
            return this;
        }
        #endregion

        #region MAC
        private bool _onlyUniqueMacAddresses = true;
        private List<string> _existingMacAddresses = new List<string>();
        private char _macSeparator = ':';

        /// <summary>
        /// Set if only unique MAC addresses should be added. If you're creating a huge amount of data then
        /// setting this value to false will increase performance.
        /// </summary>
        /// <param name="isTrue"></param>
        /// <returns></returns>
        public IItInitiator UsingOnlyUniqueMacAddresses(bool isTrue)
        {
            _onlyUniqueIpV6Addresses = isTrue;
            return this;
        }

        /// <summary>
        /// Set the separator to use when creating MAC addresses. Default is ':'
        /// </summary>
        /// <param name="separator"></param>
        /// <returns></returns>
        public IItInitiator UsingMacSeparator(char separator)
        {
            _macSeparator = separator;
            return this;
        }

        /// <summary>
        /// Pre-existing MAC addresses. Use this setting in combination with UsingOnlyUniqueMacAddresses to 
        /// block certain addresses from being used.
        /// </summary>
        /// <param name="existingMacAddresses"></param>
        /// <returns></returns>
        public IItInitiator WithExistingMacAddresses(List<string> existingMacAddresses)
        {
            _existingMacAddresses = existingMacAddresses;
            return this;
        }
        #endregion

        /// <summary>
        /// Creates the generator instance for generating data
        /// </summary>
        /// <returns></returns>
        public IItGenerator Create()
        {
            return new ItGenerator(Generator, ExtensionService, _existingIpV4Addresses, _onlyUniqueIpV4Addresses,
                _existingIpV6Addresses, _onlyUniqueIpV6Addresses, _existingMacAddresses, _onlyUniqueMacAddresses,
                _macSeparator);
        }

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
            return GeneratorExtensionTypes.ItExtension;
        }
        #endregion
    }
}
