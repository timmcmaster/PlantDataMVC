using AutoMapper;
using AutoMapper.QueryableExtensions;
using Framework.Service;
using Interfaces.DAL.UnitOfWork;
using PlantDataMVC.Domain.Entities;
using PlantDataMVC.Entities.Models;
using PlantDataMVC.Service.ServiceContracts;
using System.Collections.Generic;
using System.Linq;

namespace PlantDataMVC.Service.SimpleServiceLayer
{
    public class PlantSeedTrayDataService : DataServiceBase<PlantSeedTray>, IPlantSeedTrayDataService
    {
        public PlantSeedTrayDataService(IUnitOfWorkAsync uow)
            : base(uow)
        {
        }

        protected override PlantSeedTray CreateItem(IUnitOfWorkAsync uow, PlantSeedTray requestItem)
        {
            // map 
            SeedTray mappedItem = Mapper.Map<PlantSeedTray, SeedTray>(requestItem);
            SeedTray item = uow.Repository<SeedTray>().Add(mappedItem);
            PlantSeedTray finalItem = Mapper.Map<SeedTray, PlantSeedTray>(item);

            return finalItem;
        }

        protected override PlantSeedTray SelectItem(IUnitOfWorkAsync uow, int id)
        {
            // map 
            //SeedTray mappedItem = Mapper.Map<PlantSeedTray, SeedTray>(requestItem);
            SeedTray item = uow.Repository<SeedTray>().GetItemById(id);
            PlantSeedTray finalItem = Mapper.Map<SeedTray, PlantSeedTray>(item);

            return finalItem;
        }

        protected override PlantSeedTray UpdateItem(IUnitOfWorkAsync uow, PlantSeedTray requestItem)
        {
            // map 
            SeedTray mappedItem = Mapper.Map<PlantSeedTray, SeedTray>(requestItem);
            SeedTray item = uow.Repository<SeedTray>().Save(mappedItem);
            PlantSeedTray finalItem = Mapper.Map<SeedTray, PlantSeedTray>(item);

            return finalItem;
        }

        protected override void DeleteItem(IUnitOfWorkAsync uow, int id)
        {
            // map 
            //SeedTray mappedItem = Mapper.Map<PlantSeedTray, SeedTray>(requestItem);
            uow.Repository<SeedTray>().Delete(uow.Repository<SeedTray>().GetItemById(id));
        }

        protected override IList<PlantSeedTray> ListItems(IUnitOfWorkAsync uow)
        {
            var context = uow.Repository<SeedTray>().Queryable();
            IList<PlantSeedTray> items = context.ProjectTo<PlantSeedTray>().ToList();

            return items;
        }
    }
}
