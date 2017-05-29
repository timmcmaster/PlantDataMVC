using AutoMapper;
using PlantDataMvc3.DAL.Entities;
using PlantDataMvc3.DAL.Interfaces;

namespace PlantDataMvc3.DAL.Repositories
{
    /// <summary>
    /// </summary>
    public abstract class GenusRepository : Repository<Genus>, IGenusRepository
    {
        public GenusRepository()
            : base()
        {
        }

        public abstract Genus GetItemByLatinName(string latinName);
    }
}
