using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace CallbackSampleImplementation.Models
{
    public partial class PushTrackingDataV2: BaseCallbackResponse
    {
        #region Properties

        /// <summary>
        /// Optional but required for Functional Acknowledegment Usage
        ///     contains message key and id
        /// </summary>
        [JsonProperty("functionalacknowledgment")]
        public FunctionalAcknowledgmentReference functionalacknowledgment { get; set; }

        /// <summary>
        /// MVOCC or NVOCC Carrier Bill of Lading Number
        /// Format: SCAC plus Manifest Number/Booking Number
        /// </summary>
        /// <remarks>
        /// e.g.: WHLC0348507266
        /// </remarks>
        [JsonProperty("cbl")]
        public string cbl { get; set; }

        /// <summary>
        /// Container Number 
        /// Format: 11 Alpha Numeric Characters
        /// </summary>
        /// <remarks>
        /// e.g.: MSCU9070828
        /// </remarks>
        [JsonProperty("cnt")]
        public string cnt { get; set; }

        /// <summary>
        /// Client Shipment References
        ///     fitted for e2open BlueJay
        ///     contains message key and id
        /// </summary>
        [JsonProperty("references")]
        public SRQReference references { get; set; }

        /// <summary>
        /// Tracking Results for the CBL (Carrier Bill of Lading) and/or CNT (Container)
        /// </summary>
        /// <remarks>
        /// If a CNT value (Container) is not provided or is incorrect in the request method, all CNT(S) (Containers) details are returned.
        /// </remarks>
        [JsonProperty("result")]
        public TrackingResult result { get; set; }

        #endregion
    }
}
