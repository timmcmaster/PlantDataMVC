using Interfaces.DAL.Entity;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Interfaces.Service
{
    public interface IService<TEntity> where TEntity : IEntity
    {
        // Basically just wraps all IRepository/IRepositoryAsync methods

        IQueryable<TEntity> GetAll();

        TEntity GetItemById(int id);

        TEntity Add(TEntity item);

        TEntity Save(TEntity item);

        void Delete(TEntity item);

        IQueryable<TEntity> Queryable();
    }
}