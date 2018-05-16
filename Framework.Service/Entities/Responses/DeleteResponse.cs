using Interfaces.Service;
using System.Runtime.Serialization;


namespace Framework.Service.Entities
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