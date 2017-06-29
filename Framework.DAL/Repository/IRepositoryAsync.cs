using Framework.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Framework.DAL.Repository
{
    public interface IRepositoryAsync<TEntity>:IRepository<TEntity> where TEntity : class, IEntity
    {
        // TODO: Add async methods
    }
}
