using System.ComponentModel.DataAnnotations.Schema;
using Interfaces.DAL.Infrastructure;

namespace Interfaces.DAL.Entity
{
    public abstract class ValueObjectBase<T> where T : ValueObjectBase<T>
    {
        public override bool Equals(object obj)
        {
            var valueObject = obj as T;

            if (ReferenceEquals(valueObject, null))
            {
                return false;
            }

            return EqualsCore(valueObject);
        }

        protected abstract bool EqualsCore(T valueObject);

        public static bool operator ==(ValueObjectBase<T> a, ValueObjectBase<T> b)
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

        public static bool operator !=(ValueObjectBase<T> a, ValueObjectBase<T> b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return GetHashCodeCore();
        }

        protected abstract int GetHashCodeCore();
    }
}