using System.Data.Linq;
using PlantDataMVC.DAL.Interfaces;

namespace PlantDataMVC.DAL.LinqToSql.Infrastructure
{
    public class LinqToSqlRepositoryContext : IRepositoryContext

    {
        public ITable<T> GetTable<T>()
            where T : class
        {
            return this.DataContext.GetTable<T>();
        }

        /// <summary>
        /// Returns the active object context
        /// </summary>
        public DataContext DataContext
        {
            get
            {
                return ContextManager.Instance().GetDataContext();
            }
        }

        /// <summary>
        /// Save all changes to all repositories
        /// </summary>
        /// <returns>Integer with number of objects affected</returns>
        public int SaveChanges()
        {
            this.DataContext.SubmitChanges();
            return 0; // HACK: for now
        }

        /// <summary>
        /// Terminate this context
        /// </summary>
        public void Terminate()
        {
        }
    }
}
