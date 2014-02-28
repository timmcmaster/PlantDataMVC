using PlantDataMvc3.DAL.Interfaces;
using PlantDataMvc3.DAL.EF.Repositories;
using PlantDataMvc3.DAL.EF.Entities;
using PlantDataMvc3.DAL.EF.Infrastructure;
using Xunit;
using System;

namespace PlantDataMvc3.Tests.DAL
{
    public class EFGenusRepositoryFacts : BaseGenusRepositoryFacts, IDisposable, IUseFixture<EFMappingFixture>
    {
        protected override IGenusRepository CreateGenusRepository()
        {
            return new EFGenusRepository(new PlantDbContext());
        }

        public void Dispose()
        {
        }

        public void SetFixture(EFMappingFixture mapping)
        {
            mapping.Configure();
        }
    }

}