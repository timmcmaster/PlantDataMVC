using PlantDataMVC.DAL.Interfaces;
using PlantDataMVC.DAL.TestData;
using System;

namespace PlantDataMvc3.Tests.DAL
{
    public class TestGenusRepositoryFacts : BaseGenusRepositoryFacts, IDisposable
    {
        protected override IGenusRepository CreateGenusRepository()
        {
            return new TestGenusRepository();
        }

        public void Dispose()
        {
        }
    }
}