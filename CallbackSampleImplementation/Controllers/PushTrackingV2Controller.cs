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
        /// </summary>
        /// <param name="data">payload</param>
        /// <returns>HTTP RESPONSE</returns>
        [HttpPost]
        public async Task<ActionResult> POST(PushTrackingDataV2 data)
        {
            if (data.IsNull())
                return new BadRequestResult();



            return this.Ok();
        }

        #endregion
    }
}
