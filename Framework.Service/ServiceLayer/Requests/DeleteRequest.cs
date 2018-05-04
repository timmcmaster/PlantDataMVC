using Interfaces.Service;
using System.Runtime.Serialization;

namespace Framework.Service.ServiceLayer
{
    [DataContract]
    public class DeleteRequest<T> : IDeleteRequest<T>
    {
        [DataMember]
        public int Id { get; set; }

        public DeleteRequest(int id)
            : base()
        {
            Id = id;
        }
    }
}