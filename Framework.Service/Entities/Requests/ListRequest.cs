using Interfaces.Service;
using System.Runtime.Serialization;

namespace Framework.Service.Entities
{
    [DataContract]
    public class ListRequest<T> : IListRequest<T>
    {
        public ListRequest() : base()
        {
        }
    }
}