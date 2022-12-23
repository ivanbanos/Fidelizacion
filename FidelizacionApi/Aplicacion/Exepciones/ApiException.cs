using System.Net;
using System.Runtime.Serialization;

namespace Aplicacion.Exepciones
{
    [Serializable]
    public class ApiException : Exception
    {
        public ApiException()
        {
        }

        public ApiException(string? message) : base(message)
        {
        }

        public ApiException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ApiException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public string ExceptionMessage { get; internal set; }
        public HttpStatusCode StatusCode { get; internal set; }
    }
}