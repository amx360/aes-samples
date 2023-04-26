using System;

namespace CallbackSampleImplementation.Models

{

    /// <summary>
    /// Entity for Routing (Depreciated)
    /// </summary> 
    [Obsolete("Depreciated (to be replaced with DCSA equivalent)",false)]
    public class Route
    {
        /// <summary>
        /// Route sequence
        /// </summary>
        public int? Sequence { get; set; }

        /// <summary>
        /// Route Bound Type (import/inbound or export/outbound)
        /// </summary>  
        public RouteTypeDto Type { get; set; }

        /// <summary>
        /// Origin or Start Point
        /// </summary>      
        public Location Origin { get; set; }

        /// <summary>
        /// Destination or End Point
        /// </summary> 
        public Location Destination { get; set; }

        #region Vessel

        /// <summary>
        /// Vessel Name
        /// </summary>
        /// <example>
        /// MSC MARGARITA 
        /// </example>   
        public string VESSEL { get; set; }

        /// <summary>
        /// Vessel IMO Number
        /// The International Maritime Organization (IMO) number is a unique reference for vessels.
        /// </summary>
        /// <example>
        /// 9238741
        /// </example>     
        public string VSLIMO { get; set; }

        /// <summary>
        /// Vessel Maritime Mobile Service Identity (MMSI) Number
        /// </summary>
        /// <example>
        /// 636016429
        /// </example>    
        public string VSLMMSI { get; set; }

        /// <summary>
        /// Voyage Number
        /// </summary>
        /// <example>
        /// 811R
        /// </example>
        public string VOYAGE { get; set; }

        #endregion

        #region Estimates

        /// <summary>
        /// Estimated Time Departure (Local Time)
        /// </summary>  
        public DateTime? ETD { get; set; }

        /// <summary>
        /// Estimated Time of Arrival (Local Time)
        /// </summary>      
        public DateTime? ETA { get; set; }

        #endregion

        #region Actual

        /// <summary>
        /// Actual Time of Departure (Local Time)
        /// </summary>      
        public DateTime? ATD { get; set; }

        /// <summary>
        /// Actual Time of Arrival (Local Time)
        /// </summary>        
        public DateTime? ATA { get; set; }

        #endregion

    }
}
