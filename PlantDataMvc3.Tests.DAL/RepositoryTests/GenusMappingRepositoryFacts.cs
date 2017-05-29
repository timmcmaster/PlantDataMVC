using PlantDataMVC.DAL.Interfaces;
using PlantDataMVC.DAL.MappingRepositories;
using PlantDataMVC.DAL.TestData;
using System;

namespace PlantDataMvc3.Tests.DAL
{
    public class GenusMappingRepositoryFacts : BaseGenusRepositoryFacts, IDisposable
    {
        protected override IGenusRepository CreateGenusRepository()
        {
            return new GenusMappingRepository();
        }

        public void Dispose()
        {
        }
    }
}