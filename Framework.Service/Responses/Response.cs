using Interfaces.Service;
using Interfaces.Service.Responses;
using System.Runtime.Serialization;

namespace Framework.Service.Responses
{
    [DataContract]
    public abstract class Response : IResponse
    {
        [DataMember]
        public int ErrorCode { get; set; }

        [DataMember]
        public ServiceActionStatus Status { get; set; }

        public Response()
        {
        }
    }
}