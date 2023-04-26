using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CallbackSampleImplementation.Models;
using Microsoft.Extensions.Configuration;
using System.Net;

namespace CallbackSampleImplementation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PushTrackingV2Controller : ControllerBase
    {
        #region Constructor

        public IConfiguration configuration { get; }

        public PushTrackingV2Controller(IConfiguration config)
            => configuration = config;

        #endregion


        #region GET [FOR DEBUGGING]

        [Route("")]
        [HttpGet]
        public string GET() => true.ToString();

        #endregion


        #region POST


        /// <summary>
        /// This is a sample method implementation for the push tracking payload data callback. 
        /// TODO blujay event message transformation
        /// </summary>
        /// <param name="data">payload</param>
        /// <returns>HTTP RESPONSE</returns>
        [HttpPost]
        public async Task<ActionResult> POST(PushTrackingDataV2 data)
        {
            if (data.IsNull())
                return new BadRequestResult();

            try
            {
                if (data.tms.IsNull())
                    return new BadRequestResult();

                var tms = data.tms; //TMS referenc data
                switch (tms.type)
                {
                    case PushTrackingDataV2.TMS.Type.e2oblujay:
                        if (tms.IsNull())
                            break;  //should never happen but just in case
                        if (tms.srqs.IsNullOrEmpty())
                            break; //should never happen but just in case

                        
                        foreach (var srq in tms.srqs.ToList())
                        {
                            //blujay file id
                            //note: this can be null
                            //srq.id

                            //blujay shipment master bill 
                            //note: this can be null
                            //srq.bol

                            //blujay shipment house bill 
                            //note: this can be null
                            //srq.hbl

                            //blujay shipment container 
                            //note: this can be null
                            //if not null then it must match data.result.CONTAINERS.FirstOrDefault(o => o.CNT == srq.cnt)
                            //srq.cnt 
                        }
                        break;
                    case PushTrackingDataV2.TMS.Type.cwo:
                        break;
                    case PushTrackingDataV2.TMS.Type.generic:
                        break;
                    case PushTrackingDataV2.TMS.Type.none:
                    default:
                        //do nothing
                        break;
                }

                switch (data.Acknowledge)
                {
                    case AcknowledgeType.Failure:
                        switch (data.hasExceptions())
                        {
                            case true:
                                foreach (var error in data.ResponseExceptions.ToList())
                                {
                                    //SEE 'ERROR-CODE' List in API Documentation 'aes-api-enum-codes.xlsx'
                                    switch (error.ErrorCode)
                                    {
                                        case "ER000": //UNHANDLED EXCEPTION
                                                      //never happens
                                            break;
                                        case "ER002": //BOL NOT REGISTERED
                                                      //call the register method to resolve this error
                                            break;
                                        case "ER103": //INVALID BOL ACCORDING TO CARRIER
                                                      //alert operations to correct CBL number
                                            break;
                                    }
                                }
                                break;
                            default:
                                //SHOULD NOT HAPPEN THERE SHOULD ALWAYS BE A REASON FOR A FAILURE
                                //PLEASE ALERT AES WITH RESPONSE
                                return this.StatusCode((int)HttpStatusCode.Ambiguous);
                        }
                        break;
                    case AcknowledgeType.Success:
                    default:
                        //Check if BOL has containers
                        //NOTE: Not all BOLS will have containers; early bookings will 
                        //      not have container information manifested.
                        if (data.result.CONTAINERS.IsNullOrEmpty())
                            break;

                        foreach (var cnt in data.result.CONTAINERS.ToList())
                        {
                            //CONTAINER NUMBER | NVOCC LCL Shipments will have a Shipment Number
                            var containernumber = cnt.CNT;
                            //CONTAINER TYPE
                            var containerType = cnt.CNTTYPE?.Tag;

                            var por = cnt.POR; // Port of Reciept
                            var pol = cnt.POL; // Port of Lading
                            var pod = cnt.POD; // Port of Discharge
                            var del = cnt.DEL; // Port of Destination or Delivery

                            //SEE 'MILESTONES' List in API Documentation 'aes-api-enum-codes.xlsx'
                            var milestoneStatus = cnt.MILESTONES.MILESTONEINDICATOR;

                            //not a discrepency not all containers have events 
                            if (cnt.EVENTS.IsNullOrEmpty())
                                continue;

                            foreach (var evt in cnt.EVENTS.ToList())
                            {
                                //SEE 'EVENT-CODES' List in API Documentation 'aes-api-enum-codes.xlsx'
                                var eventcode = evt.EventCode;

                                //Check if the event is a prediction or actual
                                bool isestimate = evt.IsEstimate.GetValueOrDefault();

                                //TODO
                                switch (isestimate)
                                {
                                    case true:
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                        break;

                }


                //IMPLEMENT PROCESSING LOGIC HERE or STORE THE MESSAGE AND PROCESS LATER
                await Task.Delay(100);

            }
            catch (Exception)
            {
                //CLIENT SIDE PROCESSING EXCEPTION
                return this.StatusCode((int)HttpStatusCode.InternalServerError);
            }

            return this.Ok();
        }

        #endregion
    }
}
