using Interfaces.WCFService;
using PlantDataMVC.DTO.Entities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.ServiceModel;

namespace PlantDataMVC.WCFService.ServiceContractsWCF
{
    //[ServiceKnownType("GetKnownTypes", typeof(PlantSeedSiteDSHelper))]
    [ServiceContract]
    public interface ISiteWcfService : IWcfService<SiteDTO>
    {
    }

    // This class has the method named GetKnownTypes that returns a generic IEnumerable.
    static class SiteDTODSHelper
    {
        public static IEnumerable<Type> GetKnownTypes(ICustomAttributeProvider provider)
        {
            return DTOHelper.GetKnownTypes<SiteDTO>(provider);
        }
    }
}