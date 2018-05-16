using Interfaces.Service;
using System.Runtime.Serialization;

namespace Framework.Service.Entities
{
    /// <summary>
    /// A request is the basic unit for communication with a data service.
    /// A data service action takes a Request object and returns a Response object. 
    /// </summary>
    [DataContract]
    public abstract class Request : IRequest
    {
        public Request()
        {
        }
    }
}