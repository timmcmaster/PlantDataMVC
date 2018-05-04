using Interfaces.Service;
using System.Runtime.Serialization;

namespace Framework.Service.ServiceLayer
{
    [DataContract]
    public class CreateResponse<T>: Response, ICreateResponse<T>
    {
        [DataMember]
        public int Id { get; set; }
        
        [DataMember]
        public T Item { get; set; }

        public CreateResponse(int id, T item):base()
        {
            Id = id;
            Item = item;
        }
    }
}