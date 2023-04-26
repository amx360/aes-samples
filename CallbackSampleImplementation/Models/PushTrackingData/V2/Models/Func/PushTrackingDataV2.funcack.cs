using System.Runtime.Serialization;
using System.Xml.Linq;

namespace CallbackSampleImplementation.Models
{
    public partial class PushTrackingDataV2
    {
        /// <summary>
        /// Message Functional Acknowledgment References 
        /// 
        /// </summary>
        public class FunctionalAcknowledgmentReference
        {
            #region Properties

            /// <summary>
            /// Optional but required for Functional Acknowledegment Usage
            /// Unique Message ID
            /// </summary>
            /// <remarks>
            /// e.g.: b03f5f7f11d50a3a
            /// </remarks>
            public string id { get; set; }


            /// <summary>
            /// Optional but required for Functional Acknowledegment Usage
            /// Message Routing Key
            /// </summary>
            /// <remarks>
            /// e.g.: api/pushtrackingv2
            /// </remarks>
            public string key { get; set; }

            #endregion

        }
    }
}
