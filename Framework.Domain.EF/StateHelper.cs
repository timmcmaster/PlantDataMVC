using System;
using System.Data.Entity;
using Interfaces.Domain.Infrastructure;

namespace Framework.Domain.EF
{
    /// <summary>
    ///     Provides conversions between generic ObjectState values and EF-specific EntityState values
    /// </summary>
    public class StateHelper
    {
        /// <summary>
        ///     Map generic object states to EF specific states
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public static EntityState ConvertState(ObjectState state)
        {
            switch (state)
            {
                case ObjectState.Added:
                    return EntityState.Added;

                case ObjectState.Modified:
                    return EntityState.Modified;

                case ObjectState.Deleted:
                    return EntityState.Deleted;

                default:
                    return EntityState.Unchanged;
            }
        }

        /// <summary>
        ///     Map EF specific states to generic object states
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public static ObjectState ConvertState(EntityState state)
        {
            switch (state)
            {
                case EntityState.Detached:
                    return ObjectState.Unchanged;

                case EntityState.Unchanged:
                    return ObjectState.Unchanged;

                case EntityState.Added:
                    return ObjectState.Added;

                case EntityState.Deleted:
                    return ObjectState.Deleted;

                case EntityState.Modified:
                    return ObjectState.Modified;

                default:
                    throw new ArgumentOutOfRangeException(nameof(state));
            }
        }
    }
}