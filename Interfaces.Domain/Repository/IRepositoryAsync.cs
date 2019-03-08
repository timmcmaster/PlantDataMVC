using Interfaces.Domain.Entity;

namespace Interfaces.Domain.Repository
{
    public interface IRepositoryAsync<TEntity>:IRepository<TEntity> where TEntity : class, IEntity
    {
        // TODO: Add async methods - seem to be only relevant for queryable OData services
    }
}
