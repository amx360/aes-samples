namespace CallbackSampleImplementation.Models
{
    public class Location
    {

        #region Properties

        /// <summary>
        /// Location Name
        /// </summary>
        /// <example>
        /// New York
        /// </example>
        public string LocationText { get; set; }
        /// <summary>
        /// Unlocode 5 character code
        /// </summary>
        /// <example>
        /// USNYC
        /// </example>    
        public string UnLocode { get; set; }
        /// <summary>
        /// City Name
        /// </summary>
        /// <example>
        /// New York
        /// </example>
        /// <seealso cref="http://www.unece.org/cefact/locode/service/location.html)"/>     
        public string City { get; set; }
        /// <summary>
        /// Province or State  2nd Level Administration Abbreviation Code assigned by the UN.
        /// </summary>
        /// <example>
        /// NY
        /// </example>

        public string Province { get; set; }
        /// <summary>
        /// ISO 2 Character Country Code
        /// </summary>
        /// <example>
        /// US
        /// </example>      
        public string CountryCode { get; set; }
        /// <summary>
        /// Latitude and Longitude 
        /// </summary>
        /// <example>
        /// 3715N 08641W
        /// </example> 
        public string GeoWayPoints { get; set; }

        /// <summary>
        /// IANA TIMEZONE
        /// </summary>   
        public string OLSENTZ { get; set; }

        /// <summary>
        /// TIMEZONE
        /// </summary>
        public string MSTZ { get; set; }

        #endregion

    }
}
