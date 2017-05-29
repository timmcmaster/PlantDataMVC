using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlantDataMVC.DAL.Interfaces;
using PlantDataMVC.DAL.MappingRepositories;
//using PlantDataMVC.DAL.TestRepositories;
//using PlantDataMVC.DAL.LinqToSql.Repositories;
using PlantDataMVC.DAL.EF.Repositories;
using PlantDataMVC.DAL.EF.Infrastructure;


namespace PlantDataMVC.Core.DataAccess
{
    /// <summary>
    /// This is the central class for managing access to the DAL.
    /// This will be replaced by IoC once I work out how that works.
    /// Implements the singleton pattern to ensure we only ever have one manager and RepositorySet.
    /// </summary>
    public class UnitOfWorkManager: IUnitOfWorkManager
    {
        private static UnitOfWorkManager _manager;

        private UnitOfWorkManager()
        {
        }

        public static UnitOfWorkManager Instance()
        {
            if (_manager == null)
            {
                _manager = new UnitOfWorkManager();
            }

            return _manager;
        }

        /// <summary>
        /// Implements the actual type of repository set we want to use.
        /// </summary>
        /// <returns></returns>
        public IUnitOfWork GetUnitOfWork()
        {
            //return new TestUnitOfWork();
            //return new LinqToSqlUnitOfWork();
            return new MappingUnitOfWork(new EFUnitOfWork());
        }
    }
}

