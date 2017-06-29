using System.ComponentModel.DataAnnotations.Schema;

namespace Framework.DAL.Infrastructure
{
    public interface IObjectState
    {
        [NotMapped]
        ObjectState ObjectState { get; set; }
    }
}