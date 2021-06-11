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

    /// <summary>
    /// Base or Abstract Class (This does not work using 'abstract class' so use caution)  inherited by all Concrete Response Classes
    /// </summary>
    public class BaseCallbackResponse: BaseCallbackResponse.IResponse
    {
        /// <summary>
        /// Functional Acknowledgement: success or failure
        /// </summary>
        [JsonProperty("ack")]
        public AcknowledgeType Acknowledge { get; set; } = AcknowledgeType.Failure;


        /// <summary>
        /// List of Exceptions
        /// </summary>
        [JsonProperty("exceptions")]
        public IList<ResponseException> ResponseExceptions { get; set; }

        /// <summary>
        /// Optional Client Token
        /// </summary>
        [JsonProperty("ctoken")]
        public string ClientToken { get; set; }


        #region Methods

        public bool hasExceptions()
            => !this.ResponseExceptions.IsNullOrEmpty();

        #endregion

        #region Nested Interface

        /// <summary>
        /// Usage: Arguments, Delegates, type casting etc.
        /// </summary>
        internal interface IResponse
        {
            AcknowledgeType Acknowledge { get; set; }
            IList<ResponseException> ResponseExceptions { get; set; }
            string ClientToken { get; set; }

            bool hasExceptions();
        }

        #endregion


    }

    #endregion

}
