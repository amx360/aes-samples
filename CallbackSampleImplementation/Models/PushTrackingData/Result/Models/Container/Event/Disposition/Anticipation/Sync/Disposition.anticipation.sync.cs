using System.Runtime.Serialization;
using System;
using System.ComponentModel;

namespace CallbackSampleImplementation.Models
{
    public partial class Disposition
    {
        public partial class Anticipation
        {
            /// <summary>
            /// Structure for resolving duplicated key values
            /// </summary>
            public class Synchronization
            {

                #region Properties

                /// <summary>
                /// Flag for describing the validity of the event. In the case race conditions occur during an api request call.
                /// </summary>
                public Status status { get; set; }
                    = Status.success;


                /// <summary>
                /// Date the event was synchronized
                /// </summary>
                [DataMember]
                public DateTime? date { get; set; }

                /// <summary>
                /// status = failure
                /// Failure
                /// </summary>
                [DataMember]
                public Failure failure { get; set; }

                #endregion


                #region Nested

                /// <summary>
                /// Synchronization Status
                /// </summary>
                public enum Status
                {
                    /// <summary>
                    /// Failure
                    /// </summary>
                    [Description("Failure")]
                    failure = 0,
                    /// <summary>
                    /// Success
                    /// </summary>
                    [Description("Success")]
                    success = 1,
                    /// <summary>
                    /// Busy
                    /// </summary>
                    [Description("Busy")]
                    busy = 2
                }

                #endregion

            }
        }
    }
}
