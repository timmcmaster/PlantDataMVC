using Interfaces.DAL.Entity;

namespace Interfaces.DAL.Repository
{
    public interface IRepositoryFactory
    {
        IRepositoryAsync<TEntity> Create<TEntity>() where TEntity : class, IEntity;
    }
}