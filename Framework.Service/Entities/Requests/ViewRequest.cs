using Interfaces.Service;
using System.Runtime.Serialization;

namespace Framework.Service.Entities
{
    [DataContract(Name = "ViewRequestUsing{0}")]
    public class ViewRequest<T> : IViewRequest<T>
    {
        [DataMember]
        public int Id { get; set; }

        public ViewRequest(int id) : base()
        {
            Id = id;
        }
    }
}