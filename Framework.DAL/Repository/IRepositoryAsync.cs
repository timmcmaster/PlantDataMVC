using Interfaces.DAL.Entity;

namespace Interfaces.DAL.Repository
{
    public interface IRepositoryAsync<TEntity>:IRepository<TEntity> where TEntity : class, IEntity
    {
        // TODO: Add async methods
    }
}
