using System;
using System.Collections.Generic;

namespace MockingData.Generators.Extensions.Interfaces
{
    public interface IItGenerator : IExtensionGenerator
    {
        #region Random IP v4 Addresses
        List<string> GeneratedIPv4Addresses { get; set; }
        bool OnlyUniqueIPv4Addresses { get; set; }
        string RandomIPv4Address();
        #endregion
        
        #region Random IP v6 Addresses
        List<string> GeneratedIPv6Addresses { get; set; }
        bool OnlyUniqueIPv6Addresses { get; set; }
        string RandomIPv6Address();
        #endregion

        #region Random MAC Addresses
        List<string> GeneratedMacAddresses { get; set; }
        bool OnlyUniqueMacAddresses { get; set; }
        string RandomMacAddress(char separator = ':');
        #endregion
        
        #region Random functions with non-unique data
        Guid RandomGuid();
        string RandomHexColorCode();
        #endregion
    }

}
