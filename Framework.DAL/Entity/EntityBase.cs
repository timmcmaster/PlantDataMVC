using Interfaces.DAL.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;

namespace Interfaces.DAL.Entity
{
    /// <summary>
    /// Do we even need this class?
    /// </summary>
    public abstract class EntityBase : IObjectState, IEntity
    {
        public abstract int Id { get; set; }

        [NotMapped]
        public ObjectState ObjectState { get; set; }

    }
}
