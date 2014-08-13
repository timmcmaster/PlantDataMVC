using PlantDataMvc3.DAL.Interfaces;
using PlantDataMvc3.DAL.Repositories;
using PlantDataMvc3.DAL.TestData;
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