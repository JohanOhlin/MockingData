using System.Collections.Generic;
using System.Linq;
using MockingData.LocationData.CountryData;
using MockingData.Model.Interfaces;

namespace MockingData.LocationData
{
    public static class Countries 
    {
        public static Dictionary<int, ICountry> GetAllRegisteredCountriesWithId()
        {
            // Register all countries
            var counter = 0;
            
            var countries = new Dictionary<int, ICountry>
            {
                [++counter] = new Sweden(counter),
                [++counter] = new Uk(counter),
                [++counter] = new Spain(counter)
            };
            return countries;
        }

        public static Dictionary<int, ICountry> GetValidRegisteredCountriesWithId()
        {
            return GetAllRegisteredCountriesWithId().Where(x => x.Value.HasCompleteData).ToDictionary(x => x.Key, y => y.Value);
        }

        public static IEnumerable<ICountry> GetValidRegisteredCountries()
        {
            return GetAllRegisteredCountriesWithId().Values.Where(x => x.HasCompleteData);
        }
    }
}
