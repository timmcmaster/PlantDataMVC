using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using PlantDataMvc3.DAL.Interfaces;
using PlantDataMvc3.DAL.LocalInterfaces;
using PlantDataMvc3.DAL.Entities;
using System;

namespace PlantDataMvc3.DAL.Repositories
{
    /*
    public class GenusMappingRepository<TLocalEntity> : MappingRepository<Genus,TLocalEntity>, IGenusRepository
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
    */
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
