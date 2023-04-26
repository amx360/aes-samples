using System;
using System.Collections.Generic;

namespace CallbackSampleImplementation.Models
{
    public class Container
    {


        #region Properties

        /// <summary>
        /// Container Number
        /// </summary>
        /// <example>
        /// MSCU9070828
        /// </example>
        public string CNT { get; set; }

        /// <summary>
        /// Container Type (Equipment)
        /// </summary>
        public Equipment CNTTYPE { get; set; }

        /// <summary>
        /// Place of Receipt 
        /// </summary>
        public Location POR { get; set; }

        /// <summary>
        /// Port of Lading
        /// </summary>
        public Location POL { get; set; }

        /// <summary>
        /// Port of Discharge
        /// </summary>
        public Location POD { get; set; }

        /// <summary>
        /// Final Destination
        /// </summary>
        public Location DEL { get; set; }

        /// <summary>
        /// Shipment Milestones
        /// </summary>
        public Milestones MILESTONES { get; set; }

        /// <summary>
        /// List of Container Events
        /// </summary>
        public IList<Event> EVENTS { get; set; }

        /// <summary>
        /// Depreciated
        /// </summary>
        [Obsolete("Depreciated (to be replaced with a DCSA equivalent)",false)]
        public IList<Route> ROUTING { get; set; }

        #endregion
    }
}
