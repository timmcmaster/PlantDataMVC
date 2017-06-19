using Framework.DAL.Repository;
using PlantDataMVC.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantDataMVC.Repository.Repositories
{
    public static class GenusRepository
    {
        public static Genus GetItemByLatinName(this IRepository<Genus> repository, string latinName)
        {
            return repository.Queryable().FirstOrDefault(p => p.LatinName == latinName);
            ;
        }
    }
}
