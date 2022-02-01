using Interfaces.Domain.Entity;
using System.Data.Entity;

namespace Framework.Domain.EF
{
    public interface IFakeDbContext : IDbContext
    {
        //DbSet<T> Set<T>() where T : class;

        void AddFakeDbSet<TEntity, TFakeDbSet>()
            where TEntity : class, IEntity, new()
            where TFakeDbSet : FakeDbSet<TEntity>, IDbSet<TEntity>, new();
    }
}