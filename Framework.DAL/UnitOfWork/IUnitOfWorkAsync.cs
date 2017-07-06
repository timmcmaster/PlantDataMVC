using Framework.DAL.Entity;
using Framework.DAL.Repository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Framework.DAL.UnitOfWork
{
    /// <summary>
    /// This is the base interface for the unit of work object that is exposed from the DAL to the business layer.
    /// If a new repository type is added to the model, an interface get property should be added here.
    /// </summary>
    public interface IUnitOfWorkAsync: IUnitOfWork
    {
        IRepositoryAsync<TEntity> RepositoryAsync<TEntity>() where TEntity : class, IEntity;
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
