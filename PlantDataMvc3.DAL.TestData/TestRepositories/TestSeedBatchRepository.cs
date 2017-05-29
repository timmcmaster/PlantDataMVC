using PlantDataMVC.DAL.Entities;
using PlantDataMVC.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace PlantDataMVC.DAL.TestData
{
    public class TestSeedBatchRepository : TestRepositoryBase<SeedBatch>, ISeedBatchRepository
    {
        public TestSeedBatchRepository()
            : base()
        { }

        public override SeedBatch CreateItem(SeedBatch requestItem)
        {
            requestItem.Id = _randomGen.Next();

            return requestItem;
        }

        public override SeedBatch SelectItem(int id)
        {
            return new SeedBatch()
            {
                Id = id,
                SpeciesId = 0,
                DateCollected = DateTime.Now,
                Location = "Secret Spot",
                Notes = ""
            };
        }

        public override SeedBatch UpdateItem(SeedBatch requestItem)
        {
            return requestItem;
        }

        public override void DeleteItem(int id)
        {
            throw new NotImplementedException();
        }

        public override IList<SeedBatch> ListItems()
        {
            List<SeedBatch> seeds = new List<SeedBatch>();
            seeds.Add(new SeedBatch() { Id = 1, SpeciesId = 11, DateCollected = new DateTime(2011, 01, 11), Location = "Home", Notes = "" });
            seeds.Add(new SeedBatch() { Id = 2, SpeciesId = 12, DateCollected = new DateTime(2011, 01, 12), Location = "Home", Notes = "" });
            seeds.Add(new SeedBatch() { Id = 3, SpeciesId = 13, DateCollected = new DateTime(2011, 01, 13), Location = "Home", Notes = "" });
            seeds.Add(new SeedBatch() { Id = 4, SpeciesId = 14, DateCollected = new DateTime(2011, 01, 14), Location = "Home", Notes = "" });

            return seeds;
        }
    }
}
