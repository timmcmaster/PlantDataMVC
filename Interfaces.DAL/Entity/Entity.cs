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

        public override bool Equals(object obj)
        {
            var other = obj as EntityBase;

            if (ReferenceEquals(other, null))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (this.GetType() != other.GetType())
            {
                return false;
            }

            if (Id == 0 || other.Id == 0)
            {
                return false;
            }

            return Id == other.Id;
        }

        public static bool operator ==(EntityBase a, EntityBase b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
            {
                return true;
            }

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            {
                return false;
            }

            return a.Equals(b);
        }

        public static bool operator !=(EntityBase a, EntityBase b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().ToString() + Id).GetHashCode();
        }
    }
}
