using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CallbackSampleImplementation.Models
{
    public partial class PushTrackingDataV2
    {
        /// <summary>
        /// Client TMS references fitted for e2open BlueJay
        /// </summary>
        [DataContract]
        public class SRQReference
        {
            #region Properties

            /// <summary>
            /// used for group publication grouping
            /// </summary>
            [DataMember]
            public Group group { get; set; }

            /// <summary>
            /// shipment or search request records
            /// </summary>
            [DataMember]
            public IList<SRQ> srqs { get; set; }


            #endregion


            #region Nested Classes

            /// <summary>
            /// Callback Grouping
            /// </summary>
            public class Group
            {
                #region Properties

                /// <summary>
                /// unique id assigned by client
                /// </summary>
                public string id { get; set; }

                #endregion
            }

            /// <summary>
            /// Shipment or Search Request Record
            /// </summary>
            [DataContract]
            public class SRQ
            {
                #region Properties


                /// <summary>
                /// client primary reference or record id
                /// </summary>
                public string id { get; set; }


                /// <summary>
                /// Container Number
                /// </summary>
                public string cnt { get; set; }

                /// <summary>
                /// House Bill Number
                /// </summary>
                public string hbl { get; set; }


                /// <summary>
                /// Array of Shipment Parties
                /// </summary>
                public IList<Party> parties { get; set; }


                /// <summary>
                /// Array of Shipment Parties
                /// </summary>
                public IList<Branch> branches { get; set; }

                /// <summary>
                /// Client's customer references
                /// </summary>
                public ReferenceValues customerreferences { get; set; }


                /// <summary>
                /// Purchase Orders
                /// </summary>
                public ReferenceValues purchaseorders { get; set; }


                #endregion

            }

            /// <summary>
            /// Shipment Party
            /// </summary>
            public class Party
            {
                #region Properties

                /// <summary>
                /// party key assigned by client
                /// </summary>
                [DataMember]
                public string key { get; set; }

                /// <summary>
                /// party type:
                ///     shipper
                ///     importer
                ///     notify
                ///     forwarder
                ///     broker
                ///     other
                /// </summary>
                [DataMember]
                public string type { get; set; }

                #endregion


                #region Nested Classes

                public enum Type
                {
                    shipper,
                    importer,
                    notify,
                    forwarder,
                    broker,
                    other
                }

                #endregion

            }
            /// <summary>
            /// Shipment Branch
            /// </summary>
            public class Branch
            {
                #region Properties

                /// <summary>
                /// branch key assigned by client
                /// </summary>
                public string key { get; set; }

                #endregion
            }

            /// <summary>
            /// Shipment Reference Values
            /// </summary>
            public class ReferenceValues
            {
                #region Properties

                /// <summary>
                /// array of string reference values
                /// </summary>
                public IList<string> values { get; set; }

                #endregion
            }

            #endregion

        }

    }
}
