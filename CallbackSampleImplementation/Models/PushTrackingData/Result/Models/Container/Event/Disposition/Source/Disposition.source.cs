
namespace CallbackSampleImplementation.Models
{
    public partial class Disposition
    {
        /// <summary>
        /// Data Source
        /// </summary>
        public class Source
        {
            #region Properties

            /// <summary>
            /// Description of Data Source
            /// </summary>
            /// <example>
            /// aes | carrier | terminal etc.
            /// </example>
            public Type type { get; set; }
                = Type.aes;

            #endregion



            #region Nested Classes

            /// <summary>
            /// Description of Data Source
            /// </summary>
            public enum Type
            {
                /// <summary>
                /// AES
                /// </summary>
                aes = 1,
                /// <summary>
                /// Carrier
                /// </summary>
                carrier = 3,
                /// <summary>
                /// AIS Vessel Provider
                /// </summary>
                ais = 4,
                /// <summary>
                /// Terminal Operator or Port Authority
                /// </summary>
                terminal = 5,
                /// <summary>
                /// Intermodal Container Depot (includes North American Rail) 
                /// </summary>
                icd = 6,
                /// <summary>
                /// CFS or Depot
                /// </summary>
                depot = 7,
                /// <summary>
                /// Other
                /// </summary>
                other = 20
            }

            #endregion

        }
    }
}
