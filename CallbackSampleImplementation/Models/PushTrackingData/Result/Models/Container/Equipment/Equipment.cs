namespace CallbackSampleImplementation.Models
{
    /// <summary>
    /// Container Type
    /// </summary>
    public class Equipment
    {

        #region Properties

        /// <summary>
        /// AES Assigned Container Code
        /// </summary>
        /// <example>
        /// 40HC
        /// </example>
        public string Tag { get; set; }
        /// <summary>
        /// Container Type Short Name
        /// </summary>
        /// <example>
        /// 40’ High Cube Container
        /// </example>
        public string ShortName { get; set; }
        /// <summary>
        /// Container Type Long Name
        /// </summary>
        /// <example>
        /// 40’ High Cube Container
        /// </example>
        public string LongName { get; set; }
        /// <summary>
        /// Alternative Names
        /// </summary>
        public string AlternativeNamesText { get; set; }
        /// <summary>
        /// Length in feet
        /// </summary>
        public double? LengthInFeet { get; set; }
        /// <summary>
        /// Width in feet
        /// </summary>   
        public double? WidthInFeet { get; set; }
        /// <summary>
        /// Height in feet
        /// </summary>
        public double? HeightInFeet { get; set; }
        /// <summary>
        /// Capacity in cubic feet
        /// </summary>   
        public double? CapacityInCubicFeet { get; set; }
        /// <summary>
        /// Type Description
        /// </summary>       
        public string Description { get; set; }

        #endregion
    }
}
