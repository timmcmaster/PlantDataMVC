using System.ComponentModel.DataAnnotations.Schema;

namespace Interfaces.DAL.Infrastructure
{
    public interface IObjectState
    {
        [NotMapped]
        ObjectState ObjectState { get; set; }
    }
}