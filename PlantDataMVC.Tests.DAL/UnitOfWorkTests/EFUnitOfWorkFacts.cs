using PlantDataMVC.DAL.EF.Infrastructure;
using PlantDataMVC.DAL.LocalInterfaces;
using System;

namespace PlantDataMvc3.Tests.DAL
{
    public class EFUnitOfWorkFacts : BaseUnitOfWorkFacts, IDisposable
    {
        protected override ILocalUnitOfWork CreateUnitOfWork()
        {
            return new EFUnitOfWork();
        }
    }

}