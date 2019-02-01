using System.Runtime.Serialization;
using Interfaces.WcfService;
using Interfaces.WcfService.Responses;

namespace Framework.WcfService.Responses
{
    [DataContract]
    public abstract class Response : IResponse
    {
        #region IResponse Members
        [DataMember] public ServiceActionStatus Status { get; set; }
        #endregion
    }
}