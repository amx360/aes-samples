using System.Runtime.Serialization;

namespace CallbackSampleImplementation.Models
{
    public partial class Carrier
    {

        #region Properties

        /// <summary>
        /// Carrier SCAC
        /// </summary>
        /// <example>
        /// MSCU
        /// </example>
        public string SCAC { get; set; }

        /// <summary>
        /// Carrier Short Name
        /// </summary>
        /// <example>
        /// MSC
        /// </example>
        public string Name { get; set; }

        /// <summary>
        /// Carrier Common Name
        /// </summary>
        /// <example>
        /// Mediterranean Shipping Company
        /// </example>
        public string CommonName { get; set; }

        /// <summary>
        /// Carrier Type
        /// </summary>
        /// <example>
        /// OCEAN | TRUCK | RAIL
        /// </example>
        public CarrierType? Type { get; set; }

        #endregion

    }
}
