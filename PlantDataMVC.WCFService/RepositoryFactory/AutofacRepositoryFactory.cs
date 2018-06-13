using System;
using Autofac;
using Interfaces.DAL.Repository;
using Interfaces.DAL.Entity;

namespace PlantDataMVC.WCFService
{
    /// <summary>
    /// TODO: I don't think this class is actually necessary.
    /// I'm pretty sure I can do the same with Autofac directly, just haven't yet worked out how.
    /// </summary>
    public class AutofacRepositoryFactory: IRepositoryFactory
    {
        private readonly IComponentContext _c;

        public AutofacRepositoryFactory(IComponentContext c)
        {
            _c = c;
        }

        public IRepositoryAsync<TEntity> Create<TEntity>() where TEntity: class, IEntity
        {
            // Create repo by resolving it from context
            // Data service parameter for formhandler will also be resolved from IoC (I think?)
            IRepositoryAsync<TEntity> repo = _c.Resolve<IRepositoryAsync<TEntity>>();
            return repo;
        }
    }
}