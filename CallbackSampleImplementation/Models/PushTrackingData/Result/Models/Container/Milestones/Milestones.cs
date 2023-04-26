using System;
using System.Runtime.Serialization;

namespace CallbackSampleImplementation.Models
{
    public class Milestones
    {

        #region Properties
        /// <summary>
        /// POR: Place of Receipt
        /// The UNLOCODE/Location where the Ocean Carrier
        /// Company/Affiliate/Sub-Contractor took procession of
        /// the Cargo/Container/FCL/LCL.
        /// NOTE: Only applicable for shipments originating at a
        /// location other than a Marine port.
        /// </summary>
        /// <example>
        /// VNBDU
        /// </example>
        public string POR { get; set; }

        /// <summary>
        /// POL: Port of Lading (First Marine Port)
        /// The first UNLOCODE/Location Marine Port where the
        /// Feeder or Mother Vessel departs from.
        /// </summary>
        /// <example>
        /// VNSGN
        /// </example>
        public string POL { get; set; }

        /// <summary>
        /// POD: Port of Discharge (Last Marine Port or Port of
        /// Unlading)
        /// The last UNLOCODE/Location Marine Port where the
        /// last Feeder or Mother Vessel unloads.
        /// </summary>
        /// <example>
        /// USNYC
        /// </example>
        public string POD { get; set; }

        /// <summary>
        /// DEL: Final Destination
        /// The last UNLOCODE/Location where the Cargo is no
        /// longer the responsibility of the Ocean Carrier.
        /// NOTE: This value does not always have a UNLOCODE
        /// </summary>
        /// <example>
        /// USMKC
        /// Exception Value: LONDONDERRY, US (exceptions always contain a comma)
        /// </example>
        public string DEL { get; set; }

        /// <summary>
        /// This field indicates the terms of the bill of lading or
        /// the ownership responsibility of the consignee’s
        /// ownership in the destination country.The values are
        /// as follows:
        /// PORT: Marine Port destination 
        /// RAMP: Inland Rail Ramp destination
        /// DOOR: Ocean Carrier Haulage Delivery to the door of
        /// the consignee.
        /// INLAND: Inland Truck destination other than Ocean
        /// Carrier Haulage.
        /// UNKNOWN: Indicator used as an in-term when destination 
        /// haulage terms are unknown.
        /// </summary>
        /// <example>
        /// PORT
        /// </example>
        public string SHIPMENTTERMS { get; set; }

        /// <summary>
        /// VESSEL
        /// </summary>
        /// <example>
        /// MSC MARGARITA
        /// </example>
        public string VESSEL { get; set; }

        /// <summary>
        /// VOYAGE
        /// </summary>
        /// <example>
        /// E345
        /// </example>
        public string VOYAGE { get; set; }


        /// <summary>
        /// VESSEL IMO
        /// </summary>
        /// <example>
        /// 9238741
        /// </example>
        public string IMO { get; set; }


        /// <summary>
        /// VESSEL MMSI
        /// </summary>
        /// <example>
        /// 636016429
        /// </example>
        public string MMSI { get; set; }

        /// <summary>
        /// Actual Time of Arrival
        /// </summary>
        public DateTime? ATA { get; set; }

        /// <summary>
        /// Actual Time of Departure
        /// </summary>
        public DateTime? ATD { get; set; }

        /// <summary>
        /// Estimated Time of Departure
        /// </summary>
        public DateTime? ETD { get; set; }

        /// <summary>
        /// Estimated Time of Arrival
        /// </summary>
        public DateTime? ETA { get; set; }

        /// <summary>
        /// Latest DEL Estimated Arrival Date and Time.
        /// Only applicable when DEL is other than POD and the
        /// Ocean Carrier or Railway Carrier or Integrated
        /// Haulage Carrier provided verified estimates.
        /// </summary>
        public DateTime? ETAFINAL { get; set; }

        /// <summary>
        /// Latest or Updated Estimated Time of Departure
        /// </summary>
        public DateTime? UpdatedETD { get; set; }

        /// <summary>
        /// Latest or Updated Estimated Time of Arrival
        /// </summary>
        public DateTime? UpdatedETA { get; set; }

        /// <summary>
        /// Latest or Updated Estimated Time of Arrival
        /// </summary>
        public DateTime? UpdatedETAFINAL { get; set; }

        /// <summary>
        /// Name of the inbound discharge or rail ramp terminal.
        /// </summary>
        /// <example>
        /// APM PORT ELIZABETH
        /// </example>
        public string TERMINAL { get; set; }

        /// <summary>
        /// FIRMS CODE of the discharge or rail ramp terminal.
        /// This is only applicable for the United States.
        /// </summary>
        /// <example>
        /// W185
        /// </example>
        public string FIRMS { get; set; }

        /// <summary>
        /// INTERNAL TERMINAL CODE
        /// </summary>
        /// <example>
        /// PNCT
        /// </example>
        public string TERMINALCODE { get; set; }

        /// <summary>
        /// POD Discharge Date
        /// </summary>
        public DateTime? PODDISCHARGE { get; set; }

        /// <summary>
        /// NAME OF THE EMPTY RETURNS FACILITY 
        /// IF DIFFERENT FROM DICHARGE OR DERAMP TERMINAL
        /// </summary>
        /// <example>
        /// GCT NEW YORK
        /// </example>
        public string EMPTYRETURNFACILITY { get; set; }

        /// <summary>
        /// INTERNAL EMPTY RETURNS FACILITY CODE OR THE FIRMS CODE 
        /// NOTE: ONLY BONDED FACILITIES IN THE U.S.A HAVE FIRMS CODES
        /// </summary>
        /// <example>
        /// GCTNY
        /// </example>
        public string EMPTYRETURNFACILITYCODE { get; set; }


        /// <summary>
        /// Last Free Date for Inbound full Container Pick Ups.
        /// NOTE: Only applies for Merchant Haulage with PORT
        /// or RAMP shipment terms.
        /// </summary>
        public DateTime? LFD { get; set; }

        /// <summary>
        /// Last Free Date for Empty Container Returns.
        /// NOTE: Only applies for NON-STREET-TURN and nonleased Ocean Containers.
        /// </summary>
        public DateTime? LFDDETENTION { get; set; }

        /// <summary>
        /// Date and time of Container discharge at POD
        /// Terminal.
        /// </summary>
        public DateTime? DISCHARGE { get; set; }

        /// <summary>
        /// Date and time of Container offloading at the
        /// destination Rail Ramp(Terminal).
        /// NOTE: Only for RAMP(or Rail Destination) shipments.
        /// </summary>
        public DateTime? DERAMPED { get; set; }

        /// <summary>
        /// Date and time the Full Container is available for
        /// Merchant Haulage Pick Up.
        /// </summary>
        public DateTime? AVAILABLE { get; set; }

        /// <summary>
        /// Date and time the Full Container was picked up by
        /// Merchant Haulage
        /// </summary>
        public DateTime? PICKEDUP { get; set; }

        /// <summary>
        /// Date and time the Full Container was delivered 
        /// to the door of the consignee.
        /// </summary>
        public DateTime? DELIVERED { get; set; }

        /// <summary>
        /// Date and time empty container was returned
        /// to owner or street turned.
        /// </summary>
        public DateTime? EMPTYRETURN { get; set; }

        /// <summary>
        /// OBL (Original Bill of Lading Status) for shipments that
        /// are not under a Sea Waybill.Typical holds are due to
        /// payment collections.
        /// </summary>
        /// <example>
        /// RELEASED
        /// </example>
        public string OBL { get; set; }

        /// <summary>
        /// Inbound Customs clearance status. Typical holds are
        /// due to customs exam holds.
        /// </summary>
        /// <example>
        /// ON HOLD
        /// </example>
        public string CUSTOMS { get; set; }

        /// <summary>
        /// Ocean Carrier Freight Release Status. Typical holds
        /// are due to payment collections.
        /// </summary>
        /// <example>
        /// RELEASED
        /// </example>
        public string FREIGHT { get; set; }

        /// <summary>
        /// Shipment Notes
        /// </summary>
        /// <example>
        /// Wild card
        /// </example>
        public string NOTES { get; set; }

        /// <summary>
        /// Last Milestone
        /// </summary>
        /// <example>
        /// ON THE WATER
        /// </example>
        public string MILESTONEINDICATOR { get; set; }

        #endregion
    }
}
