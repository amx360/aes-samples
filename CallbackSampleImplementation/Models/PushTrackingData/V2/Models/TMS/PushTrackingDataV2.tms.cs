using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;


namespace CallbackSampleImplementation.Models
{
    public partial class PushTrackingDataV2
    {
        /// <summary>
        /// Client TMS references fitted for e2open BlueJay, cwo, descartes etc.
        /// </summary>
        public partial class TMS
        {
            #region Properties

            /// <summary>
            /// TMS type
            /// </summary>
            public Type type { get; set; }
                = Type.none;

            /// <summary>
            /// used for group publication grouping
            /// </summary>
            public Group group { get; set; }

            /// <summary>
            /// shipment or search request records
            /// </summary>
            public IList<SRQ> srqs { get; set; }


            #endregion


            #region Nested Classes

            public enum Type
            {
                [Description("None")]
                none = 0,
                [Description("Generic")]
                generic = 1,
                [Description("E2Open BluJay")]
                e2oblujay = 2,
                [Description("Cargowise CWO")]
                cwo = 3
            }

            /// <summary>
            /// Callback Group ID
            /// </summary>
            public class Group
            {
                #region Properties

                /// <summary>
                /// unique id assigned by client
                /// </summary>
                public string id { get; set; }

                /// <summary>
                /// references or ids the group id is related to
                /// </summary>
                public IList<string> references { get; set; }

                #endregion


            }

            /// <summary>
            /// Shipment or TMS Search Request Record
            /// </summary>
            public class SRQ
            {
                #region Properties


                /// <summary>
                /// client primary reference or record id
                /// use caution this field can be null
                /// </summary>
                public string id { get; set; }

                /// <summary>
                /// future usage
                /// </summary>
                public Type type { get; set; }
                    = Type.unspecified;

                /// <summary>
                /// Bill of Lading
                /// </summary>
                public string bol { get; set; }

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


                #region Nested Classes

                /// <summary>
                /// Search Request Record Type
                /// </summary>
                public enum Type
                {
                    /// <summary>
                    /// Unspecified
                    /// </summary>
                    [Description("Unspecified")]
                    unspecified = 0
                }

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
                public string key { get; set; }

                /// <summary>
                /// party type:
                ///     shipper
                ///     importer
                ///     notify
                ///     forwarder
                ///     broker
                ///     buyer
                ///     seller
                ///     other
                ///     etc.
                /// </summary>
                public Type type { get; set; }
                     = Type.none;

                /// <summary>
                /// when type = other
                /// </summary>
                public string other { get; set; }

                #endregion


                #region Nested Classes

                public enum Type
                {
                    [Description("None")]
                    none = 0,
                    [Description("Exporter (Shipper)")]
                    exporter = 1,
                    [Description("Importer (Consignee)")]
                    importer = 2,
                    [Description("Notify Party (Any 3rd Party)")]
                    notify = 3,
                    [Description("Forwarder")]
                    forwarder = 4,
                    [Description("Broker (Customs)")]
                    broker = 5,
                    [Description("Seller")]
                    seller = 6,
                    [Description("Buyer")]
                    buyer = 7,
                    [Description("Customer or Client")]
                    customer = 8,
                    [Description("Container Freight Station (CFS)")]
                    cfs = 8,
                    [Description("Trucker (Drayage)")]
                    trucker = 9,
                    [Description("Other")]
                    other = 99
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
                /// branch id assigned by the tms
                /// </summary>
                public string id { get; set; }
                /// <summary>
                /// branch type 
                /// </summary>
                public Type type { get; set; }
                    = Type.unspecified;

                #endregion


                #region Nested Classes

                /// <summary>
                /// Branch Type
                /// </summary>
                public enum Type
                {
                    /// <summary>
                    /// Unspecified
                    /// </summary>
                    [Description("Unspecified")]
                    unspecified = 0,
                    /// <summary>
                    /// Export
                    /// </summary>
                    [Description("Export")]
                    export = 1,
                    /// <summary>
                    /// Import
                    /// </summary>
                    [Description("Import")]
                    import = 2
                }

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
