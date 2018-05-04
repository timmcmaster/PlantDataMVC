using Interfaces.DAL.DataContext;
using Interfaces.DAL.Entity;
using System.Data.Entity;

namespace Framework.DAL.EF
{
    public interface IFakeDbContext : IDataContextAsync
    {
        DbSet<T> Set<T>() where T : class;

        void AddFakeDbSet<TEntity, TFakeDbSet>()
            where TEntity : class, IEntity, new()
            where TFakeDbSet : FakeDbSet<TEntity>, IDbSet<TEntity>, new();
    }
}
