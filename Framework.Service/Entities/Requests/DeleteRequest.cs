using Interfaces.Service;
using System.Runtime.Serialization;

namespace Framework.Service.Entities
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