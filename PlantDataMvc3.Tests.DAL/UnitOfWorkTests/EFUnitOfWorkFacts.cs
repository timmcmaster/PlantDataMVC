using PlantDataMvc3.DAL.Interfaces;
using PlantDataMvc3.DAL.EF.Infrastructure;
using System;

namespace PlantDataMvc3.Tests.DAL
{
    public class EFUnitOfWorkFacts : BaseUnitOfWorkFacts, IDisposable
    {
        protected override IUnitOfWork CreateUnitOfWork()
        {
            return new EFUnitOfWork();
        }
    }

}