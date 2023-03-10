using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CallbackSampleImplementation.Models
{
    /// <summary>
    /// PushTracking Callback Payload Data Model
    /// </summary>
    public class PushTrackingData: BaseCallbackResponse
    {

        #region Functional Acknowledegment Usage

        /// <summary>
        /// Optional but required for Functional Acknowledegment Usage
        /// Message Routing Key
        /// This is also provided in the message header
        /// </summary>
        /// <remarks>
        /// e.g.: api/pushtracking
        /// </remarks>
        [JsonProperty("msgkey")]
        public string MSGKEY { get; set; }

        /// <summary>
        /// Optional but required for Functional Acknowledegment Usage
        /// Unique Message ID
        /// This is also provided in the message header
        /// </summary>
        /// <remarks>
        /// e.g.: b03f5f7f11d50a3a
        /// </remarks>
        [JsonProperty("msgid")]
        public string MSGID { get; set; }

        #endregion

        /// <summary>
        /// MVOCC Carrier Bill of Lading Number from the  <c>GetTracking</c> request method.
        /// Format: SCAC plus Manifest Number/Booking Number
        /// </summary>
        /// <remarks>
        /// e.g.: WHLC0348507266
        /// </remarks>
        [JsonProperty("cbl")]
        public string CBL { get; set; }

        /// <summary>
        /// Container Number from the  <c>GetTracking</c> request method.
        /// Format: 11 Alpha Numeric Characters
        /// </summary>
        /// <remarks>
        /// e.g.: MSCU9070828
        /// </remarks>
        [JsonProperty("cnt")]
        public string CNT { get; set; }

        /// <summary>
        /// Tracking Results for the CBL (Carrier Bill of Lading) and/or CNT (Container)
        /// </summary>
        /// <remarks>
        /// If a CNT value (Container) is not provided or is incorrect in the request method, all CNT(S) (Containers) details are returned.
        /// </remarks>
        [JsonProperty("result")]
        public TrackingResult RESULT { get; set; }


        /// <summary>
        /// Array of Client References
        /// Format: Alpha Numeric Characters
        /// </summary>
        /// <remarks>
        /// e.g.: C5756799
        /// </remarks>
        [JsonProperty("cref")]
        public IList<string> CREFERENCES { get; set; }



    }


}
