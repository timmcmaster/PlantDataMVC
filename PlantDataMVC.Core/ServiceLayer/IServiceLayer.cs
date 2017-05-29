using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PlantDataMVC.Core.Domain.BusinessObjects;

namespace PlantDataMVC.Core.ServiceLayer
{
    public interface IServiceLayer
    {
        /// <summary>
        /// Get the data service for the given type of object.
        /// Again, might be a place for IoC in future?
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IBasicDataService<T> GetDataService<T>() where T : DomainEntity;
    }
}