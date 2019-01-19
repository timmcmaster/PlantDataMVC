using Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Reflection;
using Framework.WcfService.Responses;

namespace PlantDataMVC.WCFService.ServiceContracts
{
    // This class has the method named GetKnownTypes that returns a generic IEnumerable.
    static class DtoHelper
    {
        public static IEnumerable<Type> GetKnownTypes<T>(ICustomAttributeProvider provider) where T: IDto 
        {
            List<Type> knownTypes = new List<Type>
            {
                typeof(CreateResponse<T>),
                typeof(ViewResponse<T>),
                typeof(UpdateResponse<T>),
                typeof(DeleteResponse<T>),
                typeof(ListResponse<T>)
            };

            return knownTypes;
        }
    }
}
