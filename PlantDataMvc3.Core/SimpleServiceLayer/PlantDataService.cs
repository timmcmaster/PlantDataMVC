using System;
using System.Collections.Generic;
using System.Linq;
using PlantDataMvc3.Core.DataAccess;
using PlantDataMvc3.Core.Domain.BusinessObjects;
using PlantDataMvc3.DAL.Entities;
using PlantDataMvc3.DAL.Interfaces;
using AutoMapper;

namespace PlantDataMvc3.Core.SimpleServiceLayer
{
    public class PlantDataService : BasicDataService<Plant>
    {
        public PlantDataService(IUnitOfWorkManager uowManager)
            : base(uowManager)
        {
        }

        //TODO: Implement Commit method and transactions on unit of work

        /// <summary>
        /// Service method to create a new plant item
        /// (i.e. a genus-species definition, not an individual plant) 
        /// </summary>
        /// <param name="requestItem"></param>
        /// <returns></returns>
        protected override Plant CreateItem(IUnitOfWork uow, Plant requestItem)
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


        public Genus GetGenus(IUnitOfWork uow, Plant requestItem)
        {
            // search in list by name
            Genus requiredGenus = uow.GenusRepository.GetItemByLatinName(requestItem.GenusLatinName);

            return requiredGenus;
        }

        public Genus CreateGenus(IUnitOfWork uow, Plant requestItem)
        {
            // map plant to genus
            Genus requestGenus = Mapper.Map<Plant, Genus>(requestItem);

            // add genus
            Genus requiredGenus = uow.GenusRepository.Add(requestGenus);

            return requiredGenus;
        }

        private Species CreateSpecies(IUnitOfWork uow, Plant requestItem, Genus parentGenus)
        {
            // map plant to species
            Species requestSpecies = Mapper.Map<Plant, Species>(requestItem);

            // add genus id (and latin name?)
            requestSpecies.GenusId = parentGenus.Id;
            requestSpecies.GenusLatinName = parentGenus.LatinName;

            // create species
            Species requiredSpecies = uow.SpeciesRepository.Add(requestSpecies);

            return requiredSpecies;
        }

        private Species UpdateSpecies(IUnitOfWork uow, Plant requestItem, Genus parentGenus)
        {
            // map plant to species
            Species requestSpecies = Mapper.Map<Plant, Species>(requestItem);

            // add genus id (and latin name?)
            requestSpecies.GenusId = parentGenus.Id;
            requestSpecies.GenusLatinName = parentGenus.LatinName;

            // create species
            Species savedSpecies = uow.SpeciesRepository.Save(requestSpecies);

            return savedSpecies;
        }



        protected override Plant SelectItem(IUnitOfWork uow, int id)
        {
            // map plant to species
            //Species requestSpecies = Mapper.Map<Plant, Species>(requestItem);

            //Species species = uow.SpeciesRepository.GetItemById(id);

            // HACK: Quick and dirty property list
            List<string> includeProperties = new List<string>() { "Genus" };

            //Species species = uow.SpeciesRepository.GetItemById(id, includeProperties);
            Species species = uow.SpeciesRepository.GetItemById(id, s => s.GenusId);

            Plant plant = Mapper.Map<Species, Plant>(species);

            return plant;
        }

        protected override Plant UpdateItem(IUnitOfWork uow, Plant requestItem)
        {
            // get genus
            Genus requiredGenus = GetGenus(uow, requestItem);

            if (requiredGenus == null)
            {
                // create genus and return it
                requiredGenus = CreateGenus(uow, requestItem);
            }

            Species savedSpecies = UpdateSpecies(uow, requestItem, requiredGenus);

            uow.Commit();

            Plant plant = Mapper.Map<Species, Plant>(savedSpecies);

            return plant;
        }

        protected override void DeleteItem(IUnitOfWork uow, int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException("id");
            }
            // map plant to species
            //Species requestSpecies = Mapper.Map<Plant, Species>(requestItem);

            uow.SpeciesRepository.Delete(uow.SpeciesRepository.GetItemById(id));

            uow.Commit();
        }

        protected override IList<Plant> ListItems(IUnitOfWork uow)
        {
            IList<Species> allSpecies = uow.SpeciesRepository.GetAll();

            IList<Plant> plants = Mapper.Map<IList<Species>, IList<Plant>>(allSpecies);
            plants = plants.OrderBy(p => p.LatinName).ToList();

            return plants;
        }
    }
}
