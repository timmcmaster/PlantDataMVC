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
            List<Type> knownTypes = new List<Type>();

            // Add any types to include here.
            //knownTypes.Add(typeof(CreateRequest<T>));
            //knownTypes.Add(typeof(ViewRequest<T>));
            //knownTypes.Add(typeof(UpdateRequest<T>));
            //knownTypes.Add(typeof(DeleteRequest<T>));
            //knownTypes.Add(typeof(ListRequest<T>));

            knownTypes.Add(typeof(CreateResponse<T>));
            knownTypes.Add(typeof(ViewResponse<T>));
            knownTypes.Add(typeof(UpdateResponse<T>));
            knownTypes.Add(typeof(DeleteResponse<T>));
            knownTypes.Add(typeof(ListResponse<T>));

            return knownTypes;
        }
    }
}
