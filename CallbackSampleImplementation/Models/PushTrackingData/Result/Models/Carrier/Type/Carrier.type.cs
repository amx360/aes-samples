using System.ComponentModel;
using System.Runtime.Serialization;

namespace CallbackSampleImplementation.Models
{
    public partial class Carrier
    {
        public enum CarrierType
        {
            [Description("Steamship Line")]
            Ocean = 1,
            [Description("Drayage Trucker")]
            Truck = 2,
            [Description("Railway")]
            Rail = 3
        }
    }
}
