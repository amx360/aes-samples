namespace CallbackSampleImplementation.Models
{ 
    public partial class Disposition
    {
        /// <summary>
        /// Disposition Document  [DCSA]
        /// </summary>
        public partial class Document
        {
            #region Properties

            /// <summary>
            /// Document Type
            /// </summary>
            public Type type { get; set; }
                = Type.none;

            #endregion


            #region Nested Classes

            /// <summary>
            /// Document Type [DCSA]
            /// </summary>
            public enum Type
            {
                /// <summary>
                /// None [Not DCSA]
                /// </summary>
                none = 0,
                /// <summary>
                /// CBR Carrier Booking Reques [DCSA]
                /// </summary>
                booking_request = 1,
                /// <summary>
                /// BKG	Booking [DCSA]
                /// </summary>
                booking = 2,
                /// <summary>
                /// SHI	Shipping Instruction [DCSA]
                /// </summary>
                shipping_instruction = 3,
                /// <summary>
                /// /TRD Transport Document [DCSA]
                /// </summary>
                transport_document = 4,
                /// <summary>
                /// DEI	Delivery Instructions [DCSA]
                /// </summary>
                delivery_instructions = 5,
                /// <summary>
                /// DEO	Delivery Order [DCSA]
                /// </summary>
                delivery_order = 6,
                /// <summary>
                /// TRO	Transport Order [DCSA]
                /// </summary>
                transport_order = 7,
                /// <summary>
                /// CRO	Container Release Order	[DCSA]
                /// </summary>
                container_release_order = 8,
                /// <summary>
                /// ARN	Arrival Notice [DCSA]
                /// </summary>
                arrival_notice = 9,
                /// <summary>
                /// VGM	Verified Gross Mass [DCSA]
                /// </summary>
                verified_gross_mass = 10,
                /// <summary>
                /// CAS	Cargo Survey [DCSA]
                /// </summary>
                cargo_survey = 11,
                /// <summary>
                /// CUC	Customs Clearance [DCSA]
                /// </summary>
                customs_clearance = 12,
                /// <summary>
                /// DGD	Dangerous Goods Declaration [DCSA]
                /// </summary>
                dangerous_goods_declaration = 13,
                /// <summary>
                /// OOG Out of Gauge [DCSA]
                /// </summary>
                out_of_gauge = 14,
                /// <summary>
                /// CQU	Contract Quotation [DCSA]
                /// </summary>
                contract_quotation = 15,
                /// <summary>
                /// INV	Invoice [DCSA]
                /// </summary>
                invoice = 16
            }

            #endregion
        }
    }
}
