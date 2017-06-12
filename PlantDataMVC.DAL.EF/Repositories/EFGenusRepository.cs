using System.Data.Entity;
using System.Linq;
using PlantDataMVC.DAL.EF.Entities;
using PlantDataMVC.DAL.Interfaces;

namespace PlantDataMVC.DAL.EF.Repositories
{
    public class EFGenusRepository : EFRepositoryBase<Genus>, IGenusRepository<Genus>
    {
        public EFGenusRepository(DbContext context)
            : base(context)
        {
            //this.DefaultOrderBy = (q => q.OrderBy(g => g.LatinName));
        }

        /// <summary>
        /// Get an item by its latin name.
        /// This method is specific to this repository, so is implemented here rather than in the base.
        /// </summary>
        /// <param name="latinName"></param>
        /// <returns></returns>
        public Genus GetItemByLatinName(string latinName)
        {
            return this.DbSet.FirstOrDefault(p => p.LatinName == latinName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="latinName"></param>
        /// <returns></returns>
        public EF.Entities.Genus SelectItem(string latinName)
        {
            //return this.DbSet.Single(p => p.LatinName == latinName);
            return this.DbSet.FirstOrDefault(p => p.LatinName == latinName);
        }
    }
}
