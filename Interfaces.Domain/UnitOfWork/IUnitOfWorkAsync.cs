using System.Threading;
using System.Threading.Tasks;
using Interfaces.Domain.Entity;
using Interfaces.Domain.Repository;

namespace Interfaces.Domain.UnitOfWork
{
    /// <summary>
    /// This is the base interface for the unit of work object that is exposed from the DAL to the business layer.
    /// </summary>
    public interface IUnitOfWorkAsync: IUnitOfWork
    {
        IRepositoryAsync<TEntity> RepositoryAsync<TEntity>() where TEntity : class, IEntity;
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
