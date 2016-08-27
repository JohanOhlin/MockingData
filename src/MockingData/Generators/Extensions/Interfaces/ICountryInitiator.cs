using System.Collections.Generic;
using MockingData.Model.Interfaces;

namespace MockingData.Generators.Extensions.Interfaces
{
    public interface ICountryInitiator : IExtensionInitiator
    {
        IList<ICountry> Countries();
        ICountryInitiator WithCountryBaseList(IList<ICountry> countryList);
        ICountryInitiator WithCountryBaseList(params ICountry[] countryList);
        ICountryInitiator WithCountries(IList<int> countryIds);
        ICountryInitiator WithCountries(params int[] countryIds);
        ICountryInitiator WithoutCountries(IList<int> countryIds);
        ICountryInitiator WithoutCountries(params int[] countryIds);
        ICountryInitiator UsingCountryPopulationDistribution();
        ICountryInitiator UsingCountryAreaDistribution();
        ICountryInitiator UsingCountryEqualDistribution();
        ICountryInitiator UsingCustomDistribution(IDictionary<int, int> customDistribution);
        ICountryGenerator Create();
    }
}
