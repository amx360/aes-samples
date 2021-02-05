using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CallbackSampleImplementation.Models
{
    #region Core


    /// <summary>
    /// Enumeration of message response acknowledgements. This is a simple
    /// enumerated values indicating success of failure.
    /// </summary>
    public enum AcknowledgeType
    {
        /// <summary>
        /// Represents a failed response.
        /// </summary>
        Failure = 0,

        /// <summary>
        /// Represents a successful response.
        /// </summary>
        Success = 1
    }

    /// <summary>
    /// An entity that contains web-service related error information.
    /// </summary>
    public class ResponseException
    {
        /// <summary>
        /// Exception Error Code
        /// </summary>
        /// <example>
        /// ER001
        /// </example>
        [JsonProperty("errorcode")]
        public string ErrorCode { get; set; }

        /// <summary>
        /// Exception Error Message
        /// </summary>
        /// <example>
        /// CBL cannot be null.
        /// </example>
        [JsonProperty("msg")]
        public string Message { get; set; }

        /// <summary>
        /// Pipe Delimited Validation Codes
        /// </summary>
        [JsonProperty("validationcodes")]
        public string ValidationCodes { get; set; }

        /// <summary>
        /// Validation Suggestion Message
        /// </summary>
        [JsonProperty("suggestion")]
        public string Suggestion { get; set; }

      
    }

    #endregion


    #region Base Response

    public class BaseCallbackResponse
    {
        /// <summary>
        /// A flag indicating success or failure of the web service response back to the 
        /// client. Default is failure. 
        /// </summary>
        [JsonProperty("ack")]
        public AcknowledgeType Acknowledge { get; set; } = AcknowledgeType.Failure;


        /// <summary>
        /// Message back to client. Mostly used when a web service failure occurs. 
        /// </summary>
        [JsonProperty("exceptions")]
        public IList<ResponseException> ResponseExceptions { get; set; }

        /// <summary>
        /// Optional Client Token
        /// </summary>
        [JsonProperty("ctoken")]
        public string ClientToken { get; set; }

    }

    #endregion

}
