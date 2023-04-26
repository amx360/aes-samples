using System.ComponentModel;
using System.Runtime.Serialization;

namespace CallbackSampleImplementation.Models
{
    public partial class Disposition
    {

        #region Properties

        /// <summary>
        /// Event Classifer [DCSA]
        /// </summary>
        public ClassiferType classifer { get; set; }
            = ClassiferType.actual;

        /// <summary>
        /// Disposition Type
        /// </summary>
        public Type type { get; set; }
            = Type.unspecified;

        /// <summary>
        /// Data Source
        /// </summary>
        public Source source { get; set; }

        /// <summary>
        /// Anticiapted Event Details for [classifer = anticipation]
        /// Used for type = movement only
        /// </summary>
        public Anticipation anticipation { get; set; }

        /// <summary>
        /// TBN
        /// Actual Movement Event Classification
        /// type = movement
        /// </summary>
        public Movement movement { get; set; }

        /// <summary>
        /// TBN
        /// Actual Document Event Classification
        /// type = document (or non movement related)
        /// </summary>
        public Document document { get; set; }

        #endregion


        #region Nested Classes

        /// <summary>
        /// Event Classifer  [DCSA]
        /// </summary>
        public enum ClassiferType
        {
            /// <summary>
            /// [DCSA] Actual Event
            /// </summary>
            [Description("Actual")]
            actual = 1,
            /// <summary>
            /// [DCSA] Anticipated or Estimated Event
            /// </summary>
            [Description("Anticipation")]
            anticipation = 2,
            /// <summary>
            /// [DCSA] Planned Event 
            /// </summary>
            [Description("Planned")]
            planned = 3,
            /// <summary>
            /// [DCSA]  Requested
            /// </summary>
            [Description("Requested")]
            requested = 4,
            /// <summary>
            /// [Not DCSA] An Event that occured but the provided timestamp is either an estimate or arbitrary 
            /// </summary>
            [Description("Circa")]
            circa = 5
        }

        /// <summary>
        /// Disposition Type
        /// </summary>
        public enum Type
        {
            /// <summary>
            /// Unspecified
            /// </summary>
            [Description("Unspecified")]
            unspecified = 0,
            /// <summary>
            /// Movement
            /// </summary>
            [Description("Movement")]
            movement = 1,
            /// <summary>
            /// Document
            /// </summary>
            [Description("Document")]
            document = 2
        }

        #endregion

    }
}
