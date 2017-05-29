using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using PlantDataMvc3.DAL.Interfaces;

namespace PlantDataMvc3.DAL.EF.Infrastructure
{
    public class EFRepositoryContext : IRepositoryContext

    {
        public DbContext DbContext
        {
            get
            {
                return ContextManager.Instance().GetDbContext();
            }
        }

        /// <summary>
        /// Save all changes to all repositories
        /// </summary>
        /// <returns>Integer with number of objects affected</returns>
        public int SaveChanges()
        {
            return this.DbContext.SaveChanges();
        }

        /// <summary>
        /// Terminate this context
        /// </summary>
        public void Terminate()
        {
            
        }
    }
}
