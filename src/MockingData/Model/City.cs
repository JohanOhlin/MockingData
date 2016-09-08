using System.Collections.Generic;
using NodaTime;

namespace MockingData.Model
{
    public class City
    {
        /// <summary>
        /// Name of the city (English version)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Population in the city
        /// </summary>
        public int Population { get; set; }

        /// <summary>
        /// If this is the capital of the country
        /// </summary>
        public bool IsCountryCapital { get; set; } = false;

        /// <summary>
        /// If this is the capital of the state
        /// </summary>
        public bool IsStateCapital { get; set; } = false;

        /// <summary>
        /// The phone area code for this city. This value should be without the leading 0, in the way
        /// you combine it when put together with the phone country code
        /// 
        /// This value isn't complete in the country lists
        /// </summary>
        public string PhoneAreaCode { get; set; }

        /// <summary>
        /// The length used for generating random phone numbers
        /// </summary>
        public int LocalPhoneNumberLength { get; set; } = 6;

        /// <summary>
        /// This value isn't complete in the country lists
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// A list of potential streets in the city
        /// 
        /// This value isn't complete in the country list and is thus not guaranteed.
        /// </summary>
        public IList<Street> Streets { get; set; }

        /// <summary>
        /// State this city is connected to
        /// </summary>
        public State State { get; set; }

        /// <summary>
        /// TimeZone this city belongs to
        /// </summary>
        public DateTimeZone TimeZone { get; set; }
    }
}
