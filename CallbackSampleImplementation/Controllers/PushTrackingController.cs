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
    /// <summary>
    /// - .NET CORE [Lastest Version] Hosting Bundle must be installed
    ///   https://dotnet.microsoft.com/download/dotnet-core/thank-you/runtime-aspnetcore-5.0.2-windows-hosting-bundle-installer
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class PushTrackingController : ControllerBase
    {


        #region Constructor

        public IConfiguration configuration { get; }

        public PushTrackingController(IConfiguration config)
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
        /// </summary>
        /// <param name="data">payload</param>
        /// <returns>HTTP RESPONSE</returns>
        [HttpPost]
        public async Task<ActionResult> POST(PushTrackingData data)
        {
            if (data.IsNull())
                return new BadRequestResult();

            try
            {

                //Store MSGKEY for Functional Acknowledgement Reporting
                string messagekey = Request.Headers["MSGKEY"].FirstOrDefault();
                //Store MSGID for Functional Acknowledgement Reporting
                string messageid = Request.Headers["MSGID"].FirstOrDefault();

                //OPTIONAL 
                //CHECK CLIENT TOKEN 
                //string clientToken = string.Empty;
                //if (data.ClientToken != clientToken)
                //    return this.StatusCode((int)HttpStatusCode.Forbidden);

                //Some Async Operation 
                await Task.Delay(100);

                string clientbol = data.CBL;  // BILL OF LADING NUMBER PROVIDED BY CLIENT
                string reference = data.CREFERENCES?.FirstOrDefault(); // CLIENT REFERENCES
                if (data.Acknowledge == AcknowledgeType.Failure)
                {
                    //CHECK EXCEPTIONS FOR FAILURE DETAILS
                    if (data.hasExceptions())
                    {
                        foreach (var excep in data.ResponseExceptions.ToList())
                        {
                            //SEE 'ERROR-CODE' List in API Documentation 'aes-api-enum-codes.xlsx'
                            switch (excep.ErrorCode)
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
                    }
                    else
                    {
                        //SHOULD NOT HAPPEN THERE SHOULD ALWAYS BE A REASON FOR A FAILURE
                        //PLEASE ALERT AES WITH RESPONSE
                        return this.StatusCode((int)HttpStatusCode.Ambiguous);
                    }
                }
                else // SUCCESS
                {
                    // BILL OF LADING NUMBER USED BY AES (clientbol should be the same as bol in 99% of cases)
                    string bol = data.RESULT.CBL;
                    // Booking Number
                    string bkg = data.RESULT.BKG;


                    string scac = data.RESULT.CARRIER.SCAC; //CARRIER SCAC CODE e.g.: MSCU
                    string carrierShortName = data.RESULT.CARRIER.Name; //CARRIER SHORT NAME e.g.: MSC

                    //Check if BOL has containers
                    //NOTE: Not all BOLS will have containers; early bookings will 
                    //      not have container information manifested.
                    if (data.RESULT.CONTAINERS != null)
                    {
                        foreach (var cnt in data.RESULT.CONTAINERS.ToList())
                        {
                            //CONTAINER NUMBER | NVOCC LCL Shipments will have a Shipment Number
                            string containernumber = cnt.CNT;
                            //CONTAINER TYPE
                            string containerType = cnt.CNTTYPE?.Tag;

                            var por = cnt.POR; // Port of Reciept
                            var pol = cnt.POL; // Port of Lading
                            var pod = cnt.POD; // Port of Discharge
                            var del = cnt.DEL; // Port of Destination or Delivery

                            //SEE 'MILESTONES' List in API Documentation 'aes-api-enum-codes.xlsx'
                            string milestoneStatus = cnt.MILESTONES.MILESTONEINDICATOR;


                            //CONTAINER EVENTS
                            if (cnt.EVENTS != null)
                            {
                                foreach (var evt in cnt.EVENTS.ToList())
                                {
                                    //SEE 'EVENT-CODES' List in API Documentation 'aes-api-enum-codes.xlsx'
                                    string eventcode = evt.EventCode;

                                    //Check if the event is a prediction or actual
                                    bool isestimate = evt.IsEstimate.GetValueOrDefault();

                                    //if you prefer to skip 
                                    if (isestimate) continue;
                                }
                            }
                        }
                    }
                }


                //IMPLEMENT PROCESSING LOGIC HERE or STORE THE MESSAGE AND PROCESS LATER
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
