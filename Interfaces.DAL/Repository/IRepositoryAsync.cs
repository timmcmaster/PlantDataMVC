using Interfaces.DAL.Entity;

namespace Interfaces.DAL.Repository
{
    public interface IRepositoryAsync<TEntity>:IRepository<TEntity> where TEntity : class, IEntity
    {
        // TODO: Add async methods - seem to be only relevant for queryable OData services
    }
}
