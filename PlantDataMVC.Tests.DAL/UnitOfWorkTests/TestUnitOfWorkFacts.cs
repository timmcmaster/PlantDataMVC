using PlantDataMVC.DAL.Interfaces;
using PlantDataMVC.DAL.TestData;
using System;

namespace PlantDataMvc3.Tests.DAL
{
    public class TestUnitOfWorkFacts : BaseUnitOfWorkFacts, IDisposable
    {
        protected override IUnitOfWork CreateUnitOfWork()
        {
            return new TestUnitOfWork();
        }
    }

}