using System.Runtime.Serialization;
using System;

namespace CallbackSampleImplementation.Models
{
    public class Event
    {
        #region Properties

        /// <summary>
        /// Event Sequence
        /// Depreciating (to be replaced with order)
        /// </summary>
        [Obsolete("Depreciating (to be replaced with order)",false)]
        public int? Sequence { get; set; }
        /// <summary>
        /// Event Code
        /// </summary>
        public string EventCode { get; set; }
        /// <summary>
        /// Event Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Vessel Name
        /// </summary>
        /// <example>
        /// MSC MARGARITA
        /// </example>
        public string VesselName { get; set; }

        /// <summary>
        /// Voyage Number
        /// </summary>
        /// <example>
        /// 811R
        /// </example>
        public string VoyageNumber { get; set; }

        /// <summary>
        /// VESSEL IMO
        /// </summary>
        /// <example>
        /// 9238741
        /// </example>
        public string IMO { get; set; }


        /// <summary>
        /// VESSEL MMSI
        /// </summary>
        /// <example>
        /// 636016429
        /// </example>
        public string MMSI { get; set; }

        /// <summary>
        /// Rail Car Number
        /// </summary>
        public string RailCar { get; set; }

        /// <summary>
        /// Mode of Transportation
        /// </summary>
        public string Mode { get; set; }
        /// <summary>
        /// Estimate or Actual 
        /// </summary>
        public bool? IsEstimate { get; set; }
        /// <summary>
        /// Event Date
        /// </summary>
        public DateTime? EventDate { get; set; }

        /// <summary>
        /// MS Time Zone 
        /// </summary>
        public string TimeZone { get; set; }

        /// <summary>
        /// IANA or Olsen Time Zone 
        /// </summary>
        public string IANATZ { get; set; }

        /// <summary>
        /// Location of Event
        /// </summary>
        public Location EventLocation { get; set; }
        /// <summary>
        /// Facility
        /// </summary>
        public string Facility { get; set; }
        /// <summary>
        /// AES Facility Code
        /// </summary>
        public string FacilityCode { get; set; }

        /// <summary>
        /// Internal
        /// </summary>
        public string Reference { get; set; }

        #endregion



        #region New Properties


        /// <summary>
        /// [New Beta Release] Replaces property 'sequence'. Value is adjusted for anticipations
        /// </summary>
        public int order { get; set; }
            = -1;

        /// <summary>
        /// [New Beta Release] Contains event classification, data source, and anticipation detials.
        /// </summary>
        public Disposition disposition { get; set; }

        #endregion
    }
}
