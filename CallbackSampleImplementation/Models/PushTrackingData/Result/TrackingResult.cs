using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CallbackSampleImplementation.Models
{


    public class TrackingResult
    {

        #region Properties

        /// <summary>
        /// AES GUID
        /// Unique Value assigned to the BOL transaction
        /// </summary>
        /// <example>
        /// 0f8fad5b-d9cb469f-a165-70867728950e
        /// </example>
        public string UNIQUEID { get; set; }

        /// <summary>
        /// MVOCC CBL Carrier Billing of Lading Number (CBL)
        /// SCAC plus Manifest Number
        /// </summary>
        /// <example>
        /// WHLC0348507266
        /// (where 'WHLC' is the SCAC and '0348507266' is the manifest number)
        /// </example>
        public string CBL { get; set; }

        /// <summary>
        /// Booking Number
        /// SCAC plus Manifest Number
        /// </summary>
        /// <example>
        /// APLU0348507266
        /// (where 'APLU' is the SCAC and '0348507266' is the manifest number)
        /// </example>
        public string BKG { get; set; }

        /// <summary>
        /// Bill of Lading Type or Terms of Bill of Lading. 
        /// </summary>
        [Obsolete("Depreciating",false)]
        public WaybillType? BILLTYPE { get; set; }

        /// <summary>
        /// Shipment References
        /// </summary>
        /// <example>
        /// PO24535214
        /// </example>
        public IList<string> REFERENCES { get; set; }

        /// <summary>
        /// MVOCC Ocean Carrier
        /// </summary>
        public Carrier CARRIER { get; set; }

        /// <summary>
        /// List of containers
        /// </summary>
        public IList<Container> CONTAINERS { get; set; }

        #endregion

    }


}
