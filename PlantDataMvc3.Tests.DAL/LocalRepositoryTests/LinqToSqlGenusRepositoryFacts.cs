using System;
using PlantDataMvc3.DAL.Interfaces;
using PlantDataMvc3.DAL.LinqToSql.Infrastructure;
using PlantDataMvc3.DAL.LinqToSql.Repositories;
using Xunit;

namespace PlantDataMvc3.Tests.DAL
{
    public class LinqToSqlGenusRepositoryFacts : BaseGenusRepositoryFacts, IDisposable, IUseFixture<LinqToSqlMappingFixture>
    {
        protected override IGenusRepository CreateGenusRepository()
        {
            return new LinqToSqlUnitOfWork().GenusRepository;
        }

        public void Dispose()
        {
        }

        public void SetFixture(LinqToSqlMappingFixture mapping)
        {
            mapping.Configure();
        }
    }


}