using AutoMapper;
using Common.Logging;
using Framework.Service;
using Interfaces.DAL.UnitOfWork;
using PlantDataMVC.Domain.Entities;
using PlantDataMVC.Entities.Models;
using PlantDataMVC.Repository.Repositories;
using PlantDataMVC.Service.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlantDataMVC.Service.SimpleServiceLayer
{
    public class PlantDataService : DataServiceBase<Plant>, IPlantDataService
    {
        private static readonly ILog _log = LogManager.GetLogger<PlantDataService>();

        public PlantDataService(IUnitOfWorkAsync uow)
            : base(uow)
        {
        }

        #region DataServiceBase overrides
        /// <summary>
        /// Service method to create a new plant item
        /// (i.e. a genus-species definition, not an individual plant) 
        /// </summary>
        /// <param name="requestItem"></param>
        /// <returns></returns>
        protected override Plant CreateItem(IUnitOfWorkAsync uow, Plant requestItem)
        {
            _log.Debug(m => m("Entering {0}", System.Reflection.MethodBase.GetCurrentMethod().Name.ToString()));

            // get genus
            Genus retrievedGenus = RetrieveGenus(uow, requestItem);

            Species item = null;

            if (retrievedGenus == null)
            {
                // create species
                item = CreateGenusAndCreateSpecies(uow, requestItem);
            }
            else
            {
                // create species
                item = CreateSpecies(uow, requestItem, retrievedGenus);
            }

            Plant newPlant = Mapper.Map<Species, Plant>(item);

            return newPlant;

            // handle errors from responses
        }

        protected override Plant SelectItem(IUnitOfWorkAsync uow, int id)
        {
            _log.Debug(m => m("Entering {0}", System.Reflection.MethodBase.GetCurrentMethod().Name.ToString()));

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
            _log.Debug(m => m("Entering {0}", System.Reflection.MethodBase.GetCurrentMethod().Name.ToString()));

            // get genus
            Genus retrievedGenus = RetrieveGenus(uow, requestItem);

            Species savedSpecies = null;

            if (retrievedGenus == null)
            {
                // create species
                savedSpecies = CreateGenusAndUpdateSpecies(uow, requestItem);
            }
            else
            {
                // create species
                savedSpecies = UpdateSpecies(uow, requestItem, retrievedGenus);
            }

            Plant plant = Mapper.Map<Species, Plant>(savedSpecies);

            return plant;
        }

        protected override void DeleteItem(IUnitOfWorkAsync uow, int id)
        {
            _log.Debug(m => m("Entering {0}", System.Reflection.MethodBase.GetCurrentMethod().Name.ToString()));

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
            _log.Debug(m => m("Entering {0}", System.Reflection.MethodBase.GetCurrentMethod().Name.ToString()));

            //var context = uow.Repository<Species>().Queryable();
            //// TODO: This projection fails on use of GenericName and Binomial calculated properties.
            //var itemQuery = context.ProjectTo<Plant>().OrderBy(p => p.Binomial);
            //IList<Plant> items = itemQuery.ToList();

            IList<Species> allItems = uow.Repository<Species>().GetAll();
            IList<Plant> items = Mapper.Map<IList<Species>, IList<Plant>>(allItems);
            items = items.OrderBy(p => p.Binomial).ToList();

            return items;
        }
        #endregion

        #region Local methods
        // TODO: I think these need to be refactored, simplified or removed
        private Genus RetrieveGenus(IUnitOfWorkAsync uow, Plant requestItem)
        {
            _log.Debug(m => m("Entering {0}", System.Reflection.MethodBase.GetCurrentMethod().Name.ToString()));

            // search in list by name
            //Genus retrievedGenus = uow.Repository<Genus>().GetItemByLatinName(requestItem.GenericName);
            Genus retrievedGenus = uow.Repository<Genus>().GenusExtensions().GetItemByLatinName(requestItem.GenericName);

            return retrievedGenus;
        }

        private Species CreateGenusAndCreateSpecies(IUnitOfWorkAsync uow, Plant requestItem)
        {
            _log.Debug(m => m("Entering {0}", System.Reflection.MethodBase.GetCurrentMethod().Name.ToString()));

            // map plant to genus
            Genus requestGenus = Mapper.Map<Plant, Genus>(requestItem);

            // add genus
            Genus requiredGenus = uow.Repository<Genus>().Add(requestGenus);

            // HACK: testing if this helps with problem of non-existent genus id (not a good fix though)
            uow.SaveChanges();

            // map plant to species
            Species requestSpecies = Mapper.Map<Plant, Species>(requestItem);

            // add genus ID
            requestSpecies.GenusId = requiredGenus.Id;

            // create species
            Species requiredSpecies = uow.Repository<Species>().Add(requestSpecies);

            return requiredSpecies;
        }
        
        //// Version using navigation properties
        //private Species CreateGenusAndCreateSpecies(IUnitOfWorkAsync uow, Plant requestItem)
        //{
        //    _log.Debug(m => m("Entering {0}", System.Reflection.MethodBase.GetCurrentMethod().Name.ToString()));

        //    // map plant to genus
        //    Genus requestGenus = Mapper.Map<Plant, Genus>(requestItem);

        //    // map plant to species
        //    Species requestSpecies = Mapper.Map<Plant, Species>(requestItem);

        //    // add genus via navigation property
        //    requestSpecies.Genus = requestGenus;

        //    // create species
        //    Species requiredSpecies = uow.Repository<Species>().Add(requestSpecies);

        //    return requiredSpecies;
        //}


        private Species CreateSpecies(IUnitOfWorkAsync uow, Plant requestItem, Genus parentGenus)
        {
            _log.Debug(m => m("Entering {0}", System.Reflection.MethodBase.GetCurrentMethod().Name.ToString()));

            // map plant to species
            Species requestSpecies = Mapper.Map<Plant, Species>(requestItem);

            // Genus.Id should be set, because this is only called if genus is retrieved OK
            requestSpecies.GenusId = parentGenus.Id;

            // create species
            Species requiredSpecies = uow.Repository<Species>().Add(requestSpecies);

            return requiredSpecies;
        }

        private Species UpdateSpecies(IUnitOfWorkAsync uow, Plant requestItem, Genus parentGenus)
        {
            _log.Debug(m => m("Entering {0}", System.Reflection.MethodBase.GetCurrentMethod().Name.ToString()));

            // map plant to species
            Species requestSpecies = Mapper.Map<Plant, Species>(requestItem);

            // add genus id (and latin name?)
            requestSpecies.GenusId = parentGenus.Id;

            // create species
            Species savedSpecies = uow.Repository<Species>().Save(requestSpecies);

            return savedSpecies;
        }

        private Species CreateGenusAndUpdateSpecies(IUnitOfWorkAsync uow, Plant requestItem)
        {
            _log.Debug(m => m("Entering {0}", System.Reflection.MethodBase.GetCurrentMethod().Name.ToString()));

            // map plant to genus
            Genus requestGenus = Mapper.Map<Plant, Genus>(requestItem);

            // add genus
            Genus requiredGenus = uow.Repository<Genus>().Add(requestGenus);

            // HACK: testing if this helps with problem of non-existent genus id (not a good fix though)
            uow.SaveChanges();
            
            // map plant to species
            Species requestSpecies = Mapper.Map<Plant, Species>(requestItem);

            // add genus ID
            requestSpecies.GenusId = requiredGenus.Id;

            // create species
            Species requiredSpecies = uow.Repository<Species>().Save(requestSpecies);

            return requiredSpecies;
        }

        //// Version using navigation properties
        //private Species CreateGenusAndUpdateSpecies(IUnitOfWorkAsync uow, Plant requestItem)
        //{
        //    _log.Debug(m => m("Entering {0}", System.Reflection.MethodBase.GetCurrentMethod().Name.ToString()));

        //    // map plant to genus
        //    Genus requestGenus = Mapper.Map<Plant, Genus>(requestItem);

        //    // map plant to species
        //    Species requestSpecies = Mapper.Map<Plant, Species>(requestItem);

        //    // add genus via navigation property
        //    requestSpecies.Genus = requestGenus;

        //    // create species
        //    Species requiredSpecies = uow.Repository<Species>().Save(requestSpecies);

        //    return requiredSpecies;
        //}
        #endregion

    }
}
