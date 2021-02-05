using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CallbackSampleImplementation.Models
{

    #region Enums

    /// <summary>
    /// Bill of Lading Type Enum
    /// </summary>    
    public enum BillOfLadingTypeDto
    {
        /// <summary>
        /// Unknown BOL type.
        /// </summary>
        UnKnown = 0,
        /// <summary>
        /// Sea Waybill
        /// </summary>
        Straight = 1,
        /// <summary>
        /// OBL is required
        /// </summary>
        Negotiable = 2,
        /// <summary>
        /// Other than the above
        /// </summary>
        NotApplicable = 3
    }

    /// <summary>
    /// Data Source
    /// </summary>    
    public enum CarrierProviderTypeDto
    {
        /// <summary>
        /// Ocean Carrier
        /// </summary>
        Ocean = 1,
        /// <summary>
        /// Drayage Company
        /// </summary>
        Truck = 2,
        /// <summary>
        /// Railway
        /// </summary>
        Rail = 3
    }

    /// <summary>
    /// Logistics Bound or Direction of the Route
    /// </summary>   
    public enum RouteTypeDto
    {
        /// <summary>
        /// Inbound or import
        /// </summary>
        Inbound = 0,
        /// <summary>
        /// Outbound or Export
        /// </summary>
        Outbound = 1
    }

    #endregion

    /// <summary>
    /// Entity for MVOCC or NVOCC CBL Carrier Billing of Lading Tracking Result 
    /// </summary>    
    public class TrackingResult
    {
        /// <summary>
        /// AES GUID
        /// Unique Value assigned to the BOL transaction
        /// </summary>
        /// <example>
        /// 0f8fad5b-d9cb469f-a165-70867728950e
        /// </example>
        public string UNIQUEID { get; set; }

        /// <summary>
        /// MVOCC CBL Carrier Billing of Lading Number (CBL)
        /// SCAC plus Manifest Number
        /// </summary>
        /// <example>
        /// WHLC0348507266
        /// (where 'WHLC' is the SCAC and '0348507266' is the manifest number)
        /// </example>
        public string CBL { get; set; }

        /// <summary>
        /// Booking Number
        /// SCAC plus Manifest Number
        /// </summary>
        /// <example>
        /// APLU0348507266
        /// (where 'APLU' is the SCAC and '0348507266' is the manifest number)
        /// </example>
        public string BKG { get; set; }

        /// <summary>
        /// Bill of Lading Type or Terms of Bill of Lading. 
        /// </summary>
        public BillOfLadingTypeDto? BILLTYPE { get; set; }

        /// <summary>
        /// Shipment References
        /// </summary>
        /// <example>
        /// PO24535214
        /// </example>
        public IList<string> REFERENCES { get; set; }

        /// <summary>
        /// MVOCC Ocean Carrier
        /// </summary>  
        public Carrier CARRIER { get; set; }

        /// <summary>
        /// List of containers
        /// </summary>
        public IList<OceanContainer> CONTAINERS { get; set; }

    }

    /// <summary>
    /// Entity for an Ocean Container (CNT)
    /// </summary>
    public class OceanContainer
    {
        /// <summary>
        /// Container Number
        /// </summary>
        /// <example>
        /// MSCU9070828
        /// </example>
        public string CNT { get; set; }

        /// <summary>
        /// Container Type
        /// </summary>
        public OceanContainerType CNTTYPE { get; set; }

        /// <summary>
        /// Place of Receipt 
        /// </summary>
        public Location POR { get; set; }

        /// <summary>
        /// Port of Lading
        /// </summary>
        public Location POL { get; set; }

        /// <summary>
        /// Port of Discharge
        /// </summary>
        public Location POD { get; set; }

        /// <summary>
        /// Final Destination
        /// </summary>
        public Location DEL { get; set; }

        /// <summary>
        /// Shipment Milestone or Summary Record
        /// </summary>
        public OceanContainerMileStones MILESTONES { get; set; }

        /// <summary>
        /// List of Container Tracking Events
        /// </summary>
        public IList<TrackingEvent> EVENTS { get; set; }

        /// <summary>
        /// Depreciated
        /// </summary>
        public IList<Route> ROUTING { get; set; }
    }

    /// <summary>
    /// Entity for flat Container Milestone Records.
    /// </summary>
    public class OceanContainerMileStones
    {
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

    }


    /// <summary>
    /// Ocean Container Type
    /// </summary>
    public class OceanContainerType
    {
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

    }

    /// <summary>
    /// Entity for a Tracking Event 
    /// </summary>
    public class TrackingEvent
    {
        /// <summary>
        /// Event Sequence
        /// </summary>       
        public int? Sequence { get; set; }
        /// <summary>
        /// Event Code
        /// </summary>    
        public string EventCode { get; set; }
        /// <summary>
        /// Event Description
        /// </summary>        
        public string Description { get; set; }

        /// <summary>
        /// Vessel Name
        /// </summary>
        /// <example>
        /// MSC MARGARITA
        /// </example>        
        public string VesselName { get; set; }

        /// <summary>
        /// Voyage Number
        /// </summary>
        /// <example>
        /// 811R
        /// </example>        
        public string VoyageNumber { get; set; }

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
        /// Rail Car Number
        /// </summary>   
        public string RailCar { get; set; }

        /// <summary>
        /// Mode of Transportation
        /// </summary>  
        public string Mode { get; set; }
        /// <summary>
        /// Estimate or Actual 
        /// </summary>
        public bool? IsEstimate { get; set; }
        /// <summary>
        /// Event Date
        /// </summary>
        public DateTime? EventDate { get; set; }

        /// <summary>
        /// MS Time Zone 
        /// </summary>
        public string TimeZone { get; set; }

        /// <summary>
        /// IANA or Olsen Time Zone 
        /// </summary>
        public string IANATZ { get; set; }

        /// <summary>
        /// Location of Event
        /// </summary>
        public Location EventLocation { get; set; }
        /// <summary>
        /// Facility Name
        /// </summary>
        /// <example>
        /// </example>
        public string Facility { get; set; }
        /// <summary>
        /// AES Facility Code
        /// </summary>
        public string FacilityCode { get; set; }

        /// <summary>
        /// WildCard
        /// </summary>
        public string Reference { get; set; }

    }


    /// <summary>
    /// Entity for Routing (Depreciated)
    /// </summary> 
    public class Route
    {
        /// <summary>
        /// Route sequence
        /// </summary>
        public int? Sequence { get; set; }

        /// <summary>
        /// Route Bound Type (import/inbound or export/outbound)
        /// </summary>  
        public RouteTypeDto Type { get; set; }

        /// <summary>
        /// Origin or Start Point
        /// </summary>      
        public Location Origin { get; set; }

        /// <summary>
        /// Destination or End Point
        /// </summary> 
        public Location Destination { get; set; }

        #region Vessel

        /// <summary>
        /// Vessel Name
        /// </summary>
        /// <example>
        /// MSC MARGARITA 
        /// </example>   
        public string VESSEL { get; set; }

        /// <summary>
        /// Vessel IMO Number
        /// The International Maritime Organization (IMO) number is a unique reference for vessels.
        /// </summary>
        /// <example>
        /// 9238741
        /// </example>     
        public string VSLIMO { get; set; }

        /// <summary>
        /// Vessel Maritime Mobile Service Identity (MMSI) Number
        /// </summary>
        /// <example>
        /// 636016429
        /// </example>    
        public string VSLMMSI { get; set; }

        /// <summary>
        /// Voyage Number
        /// </summary>
        /// <example>
        /// 811R
        /// </example>
        public string VOYAGE { get; set; }

        #endregion

        #region Estimates

        /// <summary>
        /// Estimated Time Departure (Local Time)
        /// </summary>  
        public DateTime? ETD { get; set; }

        /// <summary>
        /// Estimated Time of Arrival (Local Time)
        /// </summary>      
        public DateTime? ETA { get; set; }

        #endregion

        #region Actual

        /// <summary>
        /// Actual Time of Departure (Local Time)
        /// </summary>      
        public DateTime? ATD { get; set; }

        /// <summary>
        /// Actual Time of Arrival (Local Time)
        /// </summary>        
        public DateTime? ATA { get; set; }

        #endregion

    }

    /// <summary>
    /// UN Locode entity
    /// </summary>
    public class Location
    {
        /// <summary>
        /// Location Name
        /// </summary>
        /// <example>
        /// New York
        /// </example>
        public string LocationText { get; set; }
        /// <summary>
        /// Unlocode 5 character code
        /// </summary>
        /// <example>
        /// USNYC
        /// </example>    
        public string UnLocode { get; set; }
        /// <summary>
        /// City Name
        /// </summary>
        /// <example>
        /// New York
        /// </example>
        /// <seealso cref="http://www.unece.org/cefact/locode/service/location.html)"/>     
        public string City { get; set; }
        /// <summary>
        /// Province or State  2nd Level Administration Abbreviation Code assigned by the UN.
        /// </summary>
        /// <example>
        /// NY
        /// </example>
        
        public string Province { get; set; }
        /// <summary>
        /// ISO 2 Character Country Code
        /// </summary>
        /// <example>
        /// US
        /// </example>      
        public string CountryCode { get; set; }
        /// <summary>
        /// Latitude and Longitude 
        /// </summary>
        /// <example>
        /// 3715N 08641W
        /// </example> 
        public string GeoWayPoints { get; set; }

        /// <summary>
        /// IANA TIMEZONE
        /// </summary>   
        public string OLSENTZ { get; set; }

        /// <summary>
        /// TIMEZONE
        /// </summary>
        public string MSTZ { get; set; }
    }



    /// <summary>
    /// Carrier 
    /// </summary>
    public class Carrier
    {
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
        public CarrierProviderTypeDto? Type { get; set; }

    }
}
