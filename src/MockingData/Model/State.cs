using System.Collections.Generic;
using MockingData.Model.Interfaces;

namespace MockingData.Model
{
    public class State
    {
        /// <summary>
        /// Name of the state. 
        /// 
        /// This value is guaranteed.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Short code of the state. 
        /// 
        /// This value is NOT guaranteed since not all states in the world have a code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// International code for the state (https://en.wikipedia.org/wiki/ISO_3166)
        /// 
        /// This value is NOT enabled for all states, but is available is someone has the energy to fill it out
        /// </summary>
        public string Iso3166Code { get; set; }

        /// <summary>
        /// The country this state belongs to.
        /// 
        /// This value is guaranteed.
        /// </summary>
        public ICountry Country { get; set; }

        private IList<City> _cities = new List<City>();

        /// <summary>
        /// Selection of cities in the state.
        /// 
        /// This value is guaranteed to have at least one city and exactly one of the cities is marked as state capital.
        /// </summary>
        public IList<City> Cities {
            get {
                return _cities;
            }
            set {
                _cities = value;
                foreach (var city in _cities) {
                    city.State = this;
                }
            }
        }

        /// <summary>
        /// Population size of the state. 
        /// 
        /// This value is guaranteed.
        /// </summary>
        public int Population { get; set; }

        /// <summary>
        /// Size of the state in Square Kilometers. 
        /// 
        /// This value is guaranteed.
        /// </summary>
        public long AreaSquareKilometers { get; set; }

        /// <summary>
        /// Size of the state in Square Miles. 
        /// 
        /// This value is guaranteed.
        /// </summary>
        public long AreaSquareMiles => (long) ((double)AreaSquareKilometers * 0.38610);
    }
}
