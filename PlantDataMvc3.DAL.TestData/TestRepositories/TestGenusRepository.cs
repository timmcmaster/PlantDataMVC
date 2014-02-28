using PlantDataMvc3.DAL.Entities;
using PlantDataMvc3.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace PlantDataMvc3.DAL.TestData
{
    public class TestGenusRepository : TestRepositoryBase<Genus>, IGenusRepository
    {

        public TestGenusRepository()
            : base()
        { }

        public Genus GetItemByLatinName(string latinName)
        {
            return SelectItem(latinName);
        }

        public override Genus CreateItem(Genus requestItem)
        {
            requestItem.Id = _randomGen.Next();

            return requestItem;
        }

        public override Genus SelectItem(int id)
        {
            return new Genus() { Id = id, LatinName = String.Format("Genus {0}", id) };
        }

        public Genus SelectItem(string latinName)
        {
            return new Genus() { Id = _randomGen.Next(), LatinName = latinName };
        }

        public override Genus UpdateItem(Genus requestItem)
        {
            return requestItem;
        }

        public override void DeleteItem(int id)
        {
            throw new NotImplementedException();
        }

        public override IList<Genus> ListItems()
        {
            List<Genus> genuses = new List<Genus>();
            genuses.Add(new Genus() { Id = 1, LatinName = "Acacia" });
            genuses.Add(new Genus() { Id = 2, LatinName = "Callistemon" });
            genuses.Add(new Genus() { Id = 3, LatinName = "Grevillea" });
            genuses.Add(new Genus() { Id = 4, LatinName = "Melaleuca" });

            return genuses;
        }
    }
}
