using System.ComponentModel;

namespace CallbackSampleImplementation.Models
{
    /// <summary>
    /// most waybills are either a sea waybill or an obl
    /// </summary>
    public enum WaybillType
    {
        [Description("Unspecified")]
        unspecified = 0,
        [Description("Sea Waybill")]
        seawaybill = 1,
        /// <summary>
        /// Negotiable Original Bill of Lading
        /// </summary>
        [Description("OBL")]
        obl = 2,
        /// <summary>
        /// Other than the above
        /// </summary>
        [Description("Other")]
        other = 3
    }
}
