using Framework.DAL.DataContext;
using Framework.DAL.Entity;
using PlantDataMVC.Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantDataMVC.Entities.Context
{
    public interface IFakeDbContext : IDataContextAsync
    {
        DbSet<T> Set<T>() where T : class;

        void AddFakeDbSet<TEntity, TFakeDbSet>()
            where TEntity : class, IEntity, new()
            where TFakeDbSet : MyFakeDbSet<TEntity>, IDbSet<TEntity>, new();
    }
}
