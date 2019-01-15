using Interfaces.WCFService;
using PlantDataMVC.DTO.Entities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.ServiceModel;

namespace PlantDataMVC.WCFService.ServiceContracts
{
    [ServiceKnownType("GetKnownTypes", typeof(GenusDTODSHelper))]
    [ServiceContract]
    public interface IGenusWcfService : IWcfService<GenusDTO>
    {
    }

    // This class has the method named GetKnownTypes that returns a generic IEnumerable.
    static class GenusDTODSHelper
    {
        public static IEnumerable<Type> GetKnownTypes(ICustomAttributeProvider provider)
        {
            return DTOHelper.GetKnownTypes<GenusDTO>(provider);
        }
    }
}