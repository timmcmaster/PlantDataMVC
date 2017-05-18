using PlantDataMvc3.DAL.EF.Entities;
using PlantDataMvc3.DAL.EF.Infrastructure;
using PlantDataMvc3.DAL.EF.Repositories;
using PlantDataMvc3.DAL.Interfaces;
using System;
using Xunit;

namespace PlantDataMvc3.Tests.DAL
{
    public class EFGenusRepositoryFacts : BaseGenusRepositoryFacts, IDisposable, IClassFixture<EFMappingFixture>
    {
        private EFMappingFixture m_mapping;

        public EFGenusRepositoryFacts(EFMappingFixture mapping)
        {
            m_mapping = mapping;
            m_mapping.Configure();
        }

        protected override IGenusRepository CreateGenusRepository()
        {
            return new EFGenusRepository(new PlantDbContext());
        }

        public void Dispose()
        {
        }

    }

}