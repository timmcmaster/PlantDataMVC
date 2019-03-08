using System.ComponentModel.DataAnnotations.Schema;

namespace Interfaces.Domain.Infrastructure
{
    public interface IObjectState
    {
        [NotMapped]
        ObjectState ObjectState { get; set; }
    }
}