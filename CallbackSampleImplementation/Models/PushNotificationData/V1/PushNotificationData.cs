using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CallbackSampleImplementation.Models
{
    /// <summary>
    /// PushNotification Callback Payload Data Model
    /// </summary>
    public class PushNotificationData : BaseCallbackResponse
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
        /// Notification Type Possible Values: UPDATE|ERROR|NORESULTS|PENDING
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

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
        /// Client References
        /// First entry is the primary reference and should be unique within the client's scope
        /// </summary>
        [JsonProperty("cref")]
        public IList<string> CREFERENCES { get; set; }


        #region Methods

        public bool hasClientReferences()
            => !this.CREFERENCES.IsNullOrEmpty();

        public NotifictionType NotifyType()
            => this.Type.FromStringToEnum<NotifictionType>();

        #endregion


        #region Nested Classes

        public enum NotifictionType
        {
            UNKNOWN = 0,
            UPDATE = 1,
            ERROR = 2,
            NORESULTS = 3,
            PENDING = 4
        }

        #endregion

    }
}
