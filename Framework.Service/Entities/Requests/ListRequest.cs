using Interfaces.Service;
using System.Runtime.Serialization;

namespace Framework.Service.Entities
{
    [DataContract(Name = "ListRequestUsing{0}")]
    public class ListRequest<T> : IListRequest<T>
    {
        public ListRequest() : base()
        {
        }
    }
}