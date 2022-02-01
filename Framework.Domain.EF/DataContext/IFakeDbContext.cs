using System.Data.Entity;
using Interfaces.Domain.DataContext;
using Interfaces.Domain.Entity;

namespace Framework.Domain.EF
{
    public interface IFakeDbContext : IDataContextAsync
    {
        DbSet<T> Set<T>() where T : class;

        void AddFakeDbSet<TEntity, TFakeDbSet>()
            where TEntity : class, IEntity, new()
            where TFakeDbSet : FakeDbSet<TEntity>, IDbSet<TEntity>, new();
    }
}