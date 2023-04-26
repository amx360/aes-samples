using System.Runtime.Serialization;

namespace CallbackSampleImplementation.Models
{
    public partial class Disposition
    {
        public partial class Anticipation
        {

            /// <summary>
            /// Anticipation failure 
            /// </summary>
            public class Failure
            {
                #region Properties

                /// <summary>
                /// see ancticipation-failure-code list
                /// </summary>
                public string code { get; set; }
                /// <summary>
                /// code description
                /// </summary>
                public string description { get; set; }

                #endregion

            }
        }
    }
}
