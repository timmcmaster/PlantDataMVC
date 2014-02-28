using PlantDataMvc3.DAL.Entities;
using PlantDataMvc3.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace PlantDataMvc3.DAL.TestData
{
    public class TestSeedTrayRepository : TestRepositoryBase<SeedTray>, ISeedTrayRepository
    {
        public TestSeedTrayRepository()
            : base()
        { }

        public override SeedTray CreateItem(SeedTray requestItem)
        {
            requestItem.Id = _randomGen.Next();

            return requestItem;
        }

        public override SeedTray SelectItem(int id)
        {
            return new SeedTray()
            {
                Id = id,
                SeedBatchId = 0,
                DatePlanted = DateTime.Now,
                Treatment = "",
                ThrownOut = false
            };
        }

        public override SeedTray UpdateItem(SeedTray requestItem)
        {
            return requestItem;
        }

        public override void DeleteItem(int id)
        {
            throw new NotImplementedException();
        }

        public override IList<SeedTray> ListItems()
        {
            List<SeedTray> trays = new List<SeedTray>();
            trays.Add(new SeedTray() { Id = 1, SeedBatchId = 11, DatePlanted = new DateTime(2011, 01, 11), Treatment = "", ThrownOut = false });
            trays.Add(new SeedTray() { Id = 2, SeedBatchId = 11, DatePlanted = new DateTime(2011, 01, 11), Treatment = "", ThrownOut = false });
            trays.Add(new SeedTray() { Id = 3, SeedBatchId = 11, DatePlanted = new DateTime(2011, 02, 12), Treatment = "", ThrownOut = false });
            trays.Add(new SeedTray() { Id = 4, SeedBatchId = 14, DatePlanted = new DateTime(2011, 04, 14), Treatment = "", ThrownOut = false });

            return trays;
        }
    }
}
