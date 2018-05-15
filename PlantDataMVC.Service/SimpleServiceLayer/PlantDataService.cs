using AutoMapper;
using Framework.Service;
using Interfaces.DAL.UnitOfWork;
using PlantDataMVC.Domain.Entities;
using PlantDataMVC.Entities.Models;
using PlantDataMVC.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlantDataMVC.Service.SimpleServiceLayer
{
    public class PlantDataService : BasicDataService<Plant>
    {
        public PlantDataService(IUnitOfWorkAsync uow)
            : base(uow)
        {
        }

        /// <summary>
        /// Service method to create a new plant item
        /// (i.e. a genus-species definition, not an individual plant) 
        /// </summary>
        /// <param name="requestItem"></param>
        /// <returns></returns>
        protected override Plant CreateItem(IUnitOfWorkAsync uow, Plant requestItem)
        {
            // get genus
            Genus requiredGenus = GetGenus(uow, requestItem);

            if (requiredGenus == null)
            {
                // create genus and return it
                requiredGenus = CreateGenus(uow, requestItem);
            }

            // create species
            Species item = CreateSpecies(uow, requestItem, requiredGenus);

            Plant newPlant = Mapper.Map<Species, Plant>(item);

            return newPlant;

            // handle errors from responses
        }


        public Genus GetGenus(IUnitOfWorkAsync uow, Plant requestItem)
        {
            // search in list by name
            Genus requiredGenus = uow.Repository<Genus>().GetItemByLatinName(requestItem.GenericName);

            return requiredGenus;
        }

        public Genus CreateGenus(IUnitOfWorkAsync uow, Plant requestItem)
        {
            // map plant to genus
            Genus requestGenus = Mapper.Map<Plant, Genus>(requestItem);

            // add genus
            Genus requiredGenus = uow.Repository<Genus>().Add(requestGenus);

            return requiredGenus;
        }

        private Species CreateSpecies(IUnitOfWorkAsync uow, Plant requestItem, Genus parentGenus)
        {
            // map plant to species
            Species requestSpecies = Mapper.Map<Plant, Species>(requestItem);

            // add genus id (and latin name?)
            // TODO: At this stage, Genus.Id is not yet set by DB
            requestSpecies.GenusId = parentGenus.Id;
            //requestSpecies.GenusLatinName = parentGenus.LatinName;

            // create species
            Species requiredSpecies = uow.Repository<Species>().Add(requestSpecies);

            return requiredSpecies;
        }

        private Species UpdateSpecies(IUnitOfWorkAsync uow, Plant requestItem, Genus parentGenus)
        {
            // map plant to species
            Species requestSpecies = Mapper.Map<Plant, Species>(requestItem);

            // add genus id (and latin name?)
            requestSpecies.GenusId = parentGenus.Id;
            //requestSpecies.GenusLatinName = parentGenus.LatinName;

            // create species
            Species savedSpecies = uow.Repository<Species>().Save(requestSpecies);

            return savedSpecies;
        }



        protected override Plant SelectItem(IUnitOfWorkAsync uow, int id)
        {
            // map plant to species
            //Species requestSpecies = Mapper.Map<Plant, Species>(requestItem);

            //Species species = uow.SpeciesRepository.GetItemById(id);

            // HACK: Quick and dirty property list
            List<string> includeProperties = new List<string>() { "Genus" };

            //Species species = uow.SpeciesRepository.GetItemById(id, includeProperties);
            //Species species = uow.Repository<Species>().GetItemById(id, s => s.Genus);
            Species species = uow.Repository<Species>().GetItemById(id);

            Plant plant = Mapper.Map<Species, Plant>(species);

            return plant;
        }

        protected override Plant UpdateItem(IUnitOfWorkAsync uow, Plant requestItem)
        {
            // get genus
            Genus requiredGenus = GetGenus(uow, requestItem);

            if (requiredGenus == null)
            {
                // create genus and return it
                requiredGenus = CreateGenus(uow, requestItem);
            }

            Species savedSpecies = UpdateSpecies(uow, requestItem, requiredGenus);

            uow.SaveChanges();

            Plant plant = Mapper.Map<Species, Plant>(savedSpecies);

            return plant;
        }

        protected override void DeleteItem(IUnitOfWorkAsync uow, int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException("id");
            }
            // map plant to species
            //Species requestSpecies = Mapper.Map<Plant, Species>(requestItem);

            uow.Repository<Species>().Delete(uow.Repository<Species>().GetItemById(id));

            uow.SaveChanges();
        }

        protected override IList<Plant> ListItems(IUnitOfWorkAsync uow)
        {
            //var context = uow.Repository<Species>().Queryable();
            //// TODO: This projection fails on use of GenericName and Binomial calculated properties.
            //var itemQuery = context.ProjectTo<Plant>().OrderBy(p => p.Binomial);
            //IList<Plant> items = itemQuery.ToList();

            IList<Species> allItems = uow.Repository<Species>().GetAll();
            IList<Plant> items = Mapper.Map<IList<Species>, IList<Plant>>(allItems);
            items = items.OrderBy(p => p.Binomial).ToList();

            return items;
        }
    }
}
