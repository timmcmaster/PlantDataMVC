using Interfaces.DAL.DataContext;
using Interfaces.DAL.Entity;
using Interfaces.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.DAL.EF
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private IDataContextAsync _dataContext;

        public RepositoryFactory(IDataContextAsync dataContext)
        {
            _dataContext = dataContext;
        }

        
        public IRepositoryAsync<TEntity> Create<TEntity>() where TEntity : class, IEntity
        {
            var repositoryType = typeof(Repository<>);

            // Use reflection to create repository of given type
            var repo = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _dataContext, this);

            return (IRepositoryAsync<TEntity>)repo;
        }
    }
}
