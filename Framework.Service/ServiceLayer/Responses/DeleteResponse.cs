using Interfaces.Service;
using System.Runtime.Serialization;


namespace Framework.Service.ServiceLayer
{
    [DataContract]
    public class DeleteResponse<T> : Response, IDeleteResponse<T>
    {
        public DeleteResponse()
            : base()
        {
        }
    }
}