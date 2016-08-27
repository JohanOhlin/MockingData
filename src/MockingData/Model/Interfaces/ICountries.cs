using System.Collections.Generic;

namespace MockingData.Model.Interfaces
{
    public interface ICountries
    {
        Dictionary<int, ICountry> CountryList { get; }
    }
}
