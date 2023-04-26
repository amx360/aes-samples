using System.Runtime.Serialization;

namespace CallbackSampleImplementation.Models
{
    public partial class Disposition
    {
        /// <summary>
        /// Movement [Based on DCSA Equipment Event]
        /// </summary>
        public partial class Movement
        {
            #region Properties

            /// <summary>
            /// Asset
            /// </summary>
            public AssetType asset { get; set; }
                = AssetType.equipment;

            /// <summary>
            /// Subject to change 
            /// Equipment movement [asset = equipment]
            /// </summary>
            public Equipment equipment { get; set; }

            /// <summary>
            /// TBN
            /// Vessel movement [asset = vessel]
            /// </summary>
            public Vessel vessel { get; set; }

            /// <summary>
            /// TBN
            /// Cargo movement [asset = cargo]
            /// </summary>
            public Cargo cargo { get; set; }

            #endregion



            #region Nested Classes

            /// <summary>
            /// Equipment Movement 
            /// </summary>
            public class Equipment
            {

                #region Properties

                /// <summary>
                /// DCSA Equipment Event 
                /// </summary>
                public Type type { get; set; }
                    = Type.none;

                #endregion

                #region Nested Classes

                /// <summary>
                /// DCSA Equipment Event
                /// </summary>
                public enum Type
                {
                    /// <summary>
                    /// None [Not DCSA]
                    /// </summary>
                    none = 0,
                    /// <summary>
                    /// [DCSA] LOAD Load: The action of lifting cargo or a container on board of the mode of transportation. Load is complete once the cargo or container has been lifted on board the mode of transport and secured.
                    /// </summary>
                    load = 1,
                    /// <summary>
                    ///[DCSA] DISC Discharge: The action of lifting cargo or containers off a mode of transport. Discharge is the opposite of load.
                    /// </summary>
                    discharge = 2,
                    /// <summary>
                    ///[DCSA] GTIN Gate in: The action when a container is introduced into a controlled area like a port - or inland terminal. Gate in has been completed once the operator of the area is legally in possession of the container.
                    /// </summary>
                    gate_in = 3,
                    /// <summary>
                    ///[DCSA] GTOT Gate out: The action when a container is removed from a controlled area like a port – or inland terminal. Gate-out has been completed once the possession of the container has been transferred from the operator of the terminal to the entity who is picking up the container.
                    /// </summary>
                    gate_out = 4,
                    /// <summary>
                    ///[DCSA] STUF Stuffing: The process of loading the cargo in a container or in/onto another piece of equipment.
                    /// </summary>
                    stuffing = 5,
                    /// <summary>
                    ///[DCSA] STRP Stripping: The action of unloading cargo from containers or equipment.
                    /// </summary>
                    stripping = 6,
                    /// <summary>
                    ///[DCSA] PICK Pick-up: The action of collecting the container at customer location.
                    /// </summary>
                    pick_up = 7,
                    /// <summary>
                    ///[DCSA] DROP Drop-off: The action of delivering the container at customer location.
                    /// </summary>
                    drop_off = 8,
                    /// <summary>
                    ///[DCSA] AVPU Available for Pick-up: Identifies that shipment/ Container is ready to be picked up / collection at a facility.
                    /// </summary>
                    available_pick_up = 9,
                    /// <summary>
                    ///[DCSA] AVDO Available for Drop-off: Identifies that shipment/ container is ready to be dropped off / delivered at a facility.
                    /// </summary>
                    available_drop_off = 10,
                    /// <summary>
                    ///[DCSA] WAYP Way Point Crossed: A waypoint is an intermediate point or place during transit of shipment, waypoint crossed indicates that the equipment has crossed the particular waypoint on its transit.
                    /// </summary>
                    way_point_crossed = 11

                }


                #endregion
            }

            /// <summary>
            /// TBN
            /// Vessel Movement 
            /// </summary>
            public class Vessel
            {
                #region Properties

                /// <summary>
                /// Vessel Movement Type
                /// </summary>
                public Type type { get; set; }
                    = Type.none;

                #endregion


                #region Nested Classes

                /// <summary>
                /// Vessel Movement Type
                /// </summary>
                public enum Type
                {
                    /// <summary>
                    /// None
                    /// </summary>
                    none = 0
                }

                #endregion

            }

            /// <summary>
            /// TBN
            /// Cargo Movement 
            /// </summary>
            public class Cargo
            {
                #region Properties

                /// <summary>
                /// Cargo Movement Type
                /// </summary>
                public Type type { get; set; }
                    = Type.none;

                #endregion


                #region Nested Classes

                /// <summary>
                /// Cargo Movement Type
                /// </summary>
                public enum Type
                {
                    /// <summary>
                    /// None
                    /// </summary>
                    none = 0
                }

                #endregion
            }

            /// <summary>
            /// Movement Asset
            /// </summary>
            public enum AssetType
            {
                /// <summary>
                /// Cargo
                /// </summary>
                cargo = 1,
                /// <summary>
                /// Equipment [Container for the most part]
                /// </summary>
                equipment = 2,
                /// <summary>
                /// Vessel
                /// </summary>
                vessel = 3
            }

            #endregion

        }
    }
}
