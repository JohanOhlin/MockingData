using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MockingData.Model
{
    public class Street
    {
        /// <summary>
        /// The city that this street is in
        /// </summary>
        public City City { get; set; }

        /// <summary>
        /// Name of street
        /// </summary>
        public string Name { get; set; }

        private string _postalCode;

        /// <summary>
        /// Postal (zip) code for address. If none is specified for this address then the postal (zip)
        /// code for the city will be used. Postal code for city is guaranteed so this value here will
        /// always return something.
        /// </summary>
        public string PostalCode {
            get
            {
                return _postalCode ?? City.PostalCode;
            }
            set { _postalCode = value; }
        }

        /// <summary>
        /// How the street number is calculated. Default is a random value between a min and max value
        /// </summary>
        public StreetNumberStyle NumberStyle { get; set; }

        /// <summary>
        /// A list of street numbers that a random value can be picked from
        /// </summary>
        public IList<int> NumberList { get; set; }

        /// <summary>
        /// Min and max value to pick a random one from
        /// </summary>
        public RangeBetween NumberMinMax { get; set; }

        public Street(string name = "", string postalCode = "")
        {
            Name = name;
            PostalCode = postalCode;
            NumberStyle = StreetNumberStyle.RandomInterval;
            NumberList = new List<int>();
            NumberMinMax = new RangeBetween { Min = 1, Max = 10 };
        }
    }

    public enum StreetNumberStyle
    {
        FromList = 1,
        RandomInterval = 2
    }
}
