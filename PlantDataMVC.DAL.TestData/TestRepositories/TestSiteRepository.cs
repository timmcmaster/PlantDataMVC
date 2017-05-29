using PlantDataMVC.DAL.Entities;
using PlantDataMVC.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace PlantDataMVC.DAL.TestData
{
    public class TestSiteRepository : TestRepositoryBase<Site>, ISiteRepository
    {
        public TestSiteRepository()
            : base()
        { }

        public override Site CreateItem(Site requestItem)
        {
            requestItem.Id = _randomGen.Next();

            return requestItem;
        }

        public override Site SelectItem(int id)
        {
            return new Site()
            {
                Id = id,
                SiteName = "Unknown",
                Suburb = "Unknown",
                Latitude = 0,
                Longitude = 0
            };
        }

        public override Site UpdateItem(Site requestItem)
        {
            return requestItem;
        }

        public override void DeleteItem(int id)
        {
            throw new NotImplementedException();
        }

        public override IList<Site> ListItems()
        {
            List<Site> sites = new List<Site>();
            sites.Add(new Site() { Id = 1, SiteName = "Site 1", Suburb = "Annerley", Latitude = 0, Longitude = 0 });
            sites.Add(new Site() { Id = 1, SiteName = "Site 2", Suburb = "Tarragindi", Latitude = 0, Longitude = 0 });
            sites.Add(new Site() { Id = 1, SiteName = "Site 3", Suburb = "Moorooka", Latitude = 0, Longitude = 0 });
            sites.Add(new Site() { Id = 1, SiteName = "Site 4", Suburb = "Kenmore", Latitude = 0, Longitude = 0 });

            return sites;
        }

    }
}
