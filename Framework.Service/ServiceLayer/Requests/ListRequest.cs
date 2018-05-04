using Interfaces.Service;
using System.Runtime.Serialization;

namespace Framework.Service.ServiceLayer
{
    [DataContract]
    public class ListRequest<T>: IListRequest<T>
    {
        public ListRequest(): base()
        {
        }
    }
}