using PlantDataMVC.DAL.Entities;
using PlantDataMVC.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace PlantDataMVC.DAL.TestData
{
    public class TestSpeciesRepository : TestRepositoryBase<Species>, ISpeciesRepository
    {
        public TestSpeciesRepository()
            : base()
        { }

        public override Species CreateItem(Species requestItem)
        {
            requestItem.Id = _randomGen.Next();

            return requestItem;
        }

        public override Species SelectItem(int id)
        {
            return new Species()
            {
                Id = id,
                GenusId = 1,
                LatinName = String.Format("T {0}", id),
                CommonName = "None",
                Description = "None",
                Native = true,
                PropagationTime = 7
            };
        }

        public override Species UpdateItem(Species requestItem)
        {
            return requestItem;
        }

        public override void DeleteItem(int id)
        {
            throw new NotImplementedException();
        }

        public override IList<Species> ListItems()
        {
            List<Species> species = new List<Species>();
            species.Add(new Species() { Id = 1, GenusId = 1, LatinName = "fimbriata", CommonName = "Brisbane Wattle", Description = "", Native = true, PropagationTime = 14 });
            species.Add(new Species() { Id = 1, GenusId = 2, LatinName = "citrinus", CommonName = "Bottle Brush", Description = "Lovely red flowers", Native = true, PropagationTime = 28 });
            species.Add(new Species() { Id = 1, GenusId = 3, LatinName = "banksii", CommonName = "", Description = "", Native = true, PropagationTime = 21 });
            species.Add(new Species() { Id = 1, GenusId = 4, LatinName = "nesophila", CommonName = "", Description = "", Native = true, PropagationTime = 21 });

            return species;
        }
    }
}
