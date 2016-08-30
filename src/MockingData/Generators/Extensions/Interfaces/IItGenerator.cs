using System;
using System.Collections.Generic;

namespace MockingData.Generators.Extensions.Interfaces
{
    public interface IItGenerator : IExtensionGenerator
    {
        #region Random IP v4 Addresses
        List<string> GeneratedIPv4Addresses();
        string RandomIPv4Address();
        #endregion
        
        #region Random IP v6 Addresses
        List<string> GeneratedIPv6Addresses();
        string RandomIPv6Address();
        #endregion

        #region Random MAC Addresses
        List<string> GeneratedMacAddresses();
        string RandomMacAddress();
        #endregion
        
        #region Random functions with non-unique data
        Guid RandomGuid();
        string RandomHexColorCode();
        #endregion
    }

}
