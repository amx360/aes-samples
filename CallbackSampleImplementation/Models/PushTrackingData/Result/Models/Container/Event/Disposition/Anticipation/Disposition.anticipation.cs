using System.ComponentModel;
using System.Runtime.Serialization;

namespace CallbackSampleImplementation.Models
{
    public partial class Disposition
    {
        /// <summary>
        /// Anticipated Event Details
        /// </summary>
        public partial class Anticipation
        {
            #region Properties

            /// <summary>
            /// Is the anticipated event current or already took place in the past
            /// </summary>
            public Status status { get; set; }
                = Status.current;

            /// <summary>
            /// Group Identifier Key the event.code + location for movement dispostions. Groups anticipations for an event that has not occured. 
            /// </summary>
            public string key { get; set; }

            /// <summary>
            /// For Anticipation.source = 'aes'. Value that indicates the methodology used to the compute the event's estimated date.
            /// </summary>
            public Computation computation { get; set; }

            /// <summary>
            /// Date of synchronization and failure details (mostly used for failures)
            /// </summary>
            public Synchronization synchronization { get; set; }

            #endregion


            #region Nested Classes

            /// <summary>
            /// Anticipation status
            /// </summary>
            public enum Status
            {
                /// <summary>
                /// Event is the latest or most current anticipation
                /// </summary>
                [Description("Current")]
                current = 1,
                /// <summary>
                /// Event has been overriden
                /// </summary>
                [Description("Passed")]
                passed = 2
            }

            #endregion
        }
    }
}
