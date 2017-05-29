using AutoMapper;
using PlantDataMVC.DAL.Entities;
using PlantDataMVC.DAL.Interfaces;
using PlantDataMVC.DAL.LocalInterfaces;

namespace PlantDataMVC.DAL.MappingRepositories
{
    /// <summary>
    /// This class derives from MappingRepository to provide generic mapping from ILocalGenus to Genus.
    /// It also provides a mapping implementation of specific IGenusRepository methods
    /// </summary>
    /// <typeparam name="TLocalEntity"></typeparam>
    public class GenusMappingRepository<TLocalEntity> : MappingRepository<Genus, TLocalEntity>, IGenusRepository
        where TLocalEntity : ILocalGenus
    {

        public GenusMappingRepository(ILocalGenusRepository<TLocalEntity> localRepository)
            : base(localRepository)
        {
        }


        public Genus GetItemByLatinName(string latinName)
        {
            // Create a temp Genus entity
            Genus tempItem = new Genus() { LatinName = latinName };

            // Use mapper to map latin name in Genus entity to local LatinName
            TLocalEntity localItem = Mapper.Map<Genus, TLocalEntity>(tempItem);

            TLocalEntity selectedItem = ((ILocalGenusRepository<TLocalEntity>)this.LocalRepository).GetItemByLatinName(localItem.LatinName);

            Genus interfaceItem = Mapper.Map<TLocalEntity, Genus>(selectedItem);

            return interfaceItem;
        }
    }
}
