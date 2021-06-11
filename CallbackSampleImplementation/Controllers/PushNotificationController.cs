using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CallbackSampleImplementation.Models;
using System.Net;

namespace CallbackSampleImplementation.Controllers
{
    /// <summary>
    /// - .NET CORE [Lastest Version] Hosting Bundle must be installed
    ///   https://dotnet.microsoft.com/download/dotnet-core/thank-you/runtime-aspnetcore-5.0.2-windows-hosting-bundle-installer
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class PushNotificationController : Controller
    {

        #region Constructor

        public IConfiguration configuration { get; }

        public PushNotificationController(IConfiguration config)
            => configuration = config;

        #endregion

        #region GET [FOR DEBUGGING]

        [Route("")]
        [HttpGet]
        public string GET() => true.ToString();

        #endregion


        #region POST

        /// <summary>
        /// This is a sample method implementation for the push notification payload data callback. 
        /// </summary>
        /// <param name="data">payload</param>
        /// <returns>HTTP RESPONSE</returns>
        [HttpPost]
        public async Task<ActionResult> POST(PushNotificationData data)
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

                HttpStatusCode? httpcode = null;

                switch (data.Acknowledge)
                {
                    case AcknowledgeType.Failure:
                       if (!await processFailure(messagekey, messageid, data, httpcode))
                            return this.StatusCode((int)httpcode.GetValueOrDefault());
                        break;

                    case AcknowledgeType.Success:
                        if (!await processSuccess(messagekey, messageid, data, httpcode))
                            return this.StatusCode((int)httpcode.GetValueOrDefault());

                        break;
                }

            }
            catch (Exception)
            {
                //CLIENT SIDE PROCESSING EXCEPTION
                return this.StatusCode((int)HttpStatusCode.InternalServerError);
            }

            return this.Ok();
        }

        #endregion


        #region Protected or Internal Methods

        public async Task<bool> processFailure(string messagekey,string messageid,PushNotificationData data, HttpStatusCode? httpcode)
        {
            string clientbol = data.CBL;  // BILL OF LADING NUMBER PROVIDED BY CLIENT
            string reference = data.CREFERENCES?.FirstOrDefault(); // CLIENT REFERENCES
            string clientcnt = data.CNT;

            //CHECK EXCEPTIONS FOR FAILURE DETAILS
            if (data.hasExceptions())
            {
                foreach (var excep in data.ResponseExceptions.ToList())
                {
                    //check for Suggestions as well
                    //excep.Suggestion
                    //SEE 'ERROR-CODE' List in API Documentation 'aes-api-enum-codes.xlsx' on github
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

                //Some Async Operation 
                await Task.Delay(100);
            }
            else
            {
                //SHOULD NOT HAPPEN THERE SHOULD ALWAYS BE A REASON FOR A FAILURE
                //PLEASE ALERT AES WITH RESPONSE
                httpcode = HttpStatusCode.Ambiguous;

                //Some Async Operation 
                await Task.Delay(100);

                return false;
            }

            return true;
        }

        public async Task<bool> processSuccess(string messagekey, string messageid, PushNotificationData data, HttpStatusCode? httpcode)
        {
            string clientbol = data.CBL;  // BILL OF LADING NUMBER PROVIDED BY CLIENT
            string reference = data.CREFERENCES?.FirstOrDefault(); // CLIENT REFERENCES
            string clientcnt = data.CNT;


            switch (data.NotifyType())
            {
                case PushNotificationData.NotifictionType.UPDATE:
                    // call get tracking api method to get updated payloads
                    break;

                case PushNotificationData.NotifictionType.ERROR:
                    //Check for reasons
                    if (data.hasExceptions())
                    {
                        foreach (var excep in data.ResponseExceptions.ToList())
                        {
                            //check for Suggestions as well
                            //excep.Suggestion
                            //SEE 'ERROR-CODE' List in API Documentation 'aes-api-enum-codes.xlsx' on github
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

                        //Some Async Operation 
                        await Task.Delay(100);
                    }
                    else
                    {
                        //SHOULD NOT HAPPEN THERE SHOULD ALWAYS BE A REASON FOR AN ERROR
                        //PLEASE ALERT AES WITH RESPONSE
                        httpcode = HttpStatusCode.Ambiguous;

                        //Some Async Operation 
                        await Task.Delay(100);

                        return false;
                    }

                    break;

                case PushNotificationData.NotifictionType.NORESULTS:
                    //wait or try again or wait for an additional push notification
                    //this maybe an early booking that has not been manifested to the carrier
                    break;

                case PushNotificationData.NotifictionType.PENDING:
                    //wait or try again or wait for an additional push notification
                    //this maybe an early booking that has not been manifested to the carrier
                    break;

                case PushNotificationData.NotifictionType.UNKNOWN:
                    //SHOULD NOT HAPPEN THERE SHOULD ALWAYS BE A FINITE STRING VALUE FOR NOTIFICATION TYPE
                    //PLEASE ALERT AES WITH RESPONSE
                    httpcode = HttpStatusCode.Ambiguous;
                    return false;
            }


            //Some Async Operation 
            await Task.Delay(100);

            return true;
        }

        #endregion



    }
}
