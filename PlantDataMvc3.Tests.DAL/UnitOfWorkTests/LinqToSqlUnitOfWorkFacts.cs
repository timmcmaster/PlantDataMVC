using PlantDataMvc3.DAL.Interfaces;
using PlantDataMvc3.DAL.LinqToSql.Infrastructure;
using System;

namespace PlantDataMvc3.Tests.DAL
{
    public class LinqToSqlUnitOfWorkFacts : BaseUnitOfWorkFacts, IDisposable
    {
        protected override IUnitOfWork CreateUnitOfWork()
        {
            return new LinqToSqlUnitOfWork();
        }
    }

}