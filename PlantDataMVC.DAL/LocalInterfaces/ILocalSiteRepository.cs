using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlantDataMVC.DAL.LocalInterfaces
{
    //public interface ILocalSiteRepository : ILocalSiteRepository<ILocalSite> { }

    public interface ILocalSiteRepository<T> : ILocalRepository<T>
        where T : ILocalSite
    {
    }
}
