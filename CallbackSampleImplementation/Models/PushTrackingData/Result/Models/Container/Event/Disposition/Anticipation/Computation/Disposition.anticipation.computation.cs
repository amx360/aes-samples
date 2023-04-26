using System.Runtime.Serialization;

namespace CallbackSampleImplementation.Models
{
    public partial class Disposition
    {
        public partial class Anticipation
        {
            public partial class Computation
            {
                #region Properties

                /// <summary>
                /// The methodology type code used to the compute the event's estimated date.
                /// </summary>
                /// <example>
                /// e.g.: ac1 
                /// </example>
                public Type type { get; set; }
                    = Type.ac0;

                #endregion


                #region Nested Classes

                /// <summary>
                /// Method Type
                /// </summary>
                public enum Type
                {
                    /// <summary>
                    /// Unspecified or Not Applicable
                    /// </summary>
                    [EnumMember]
                    ac0 = 0,
                    /// <summary>
                    /// Average (emperical) calendar days in transit from port to port at the time of 'Sync.date'
                    /// </summary>
                    [EnumMember]
                    ac1 = 1,
                    /// <summary>
                    /// Best central tendancy computation using more than 1 source for average calendar days in transit from port to port at the time of 'Sync.date' [Note: stochastic models, processed are not applied to this method]
                    /// </summary>
                    [EnumMember]
                    ac2 = 2,
                    /// <summary>
                    /// Using terminal and carrier vessel schedules and Best central tendancy computation using more than 1 source for average calendar days in transit from port to port at the time of 'Sync.date'  [Note: stochastic models, processed are not applied to this method]
                    /// </summary>
                    [EnumMember]
                    ac3 = 3
                }

                #endregion
            }
        }
    }
}
