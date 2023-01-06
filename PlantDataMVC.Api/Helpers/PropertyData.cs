using PlantDataMVC.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PlantDataMVC.Api.Helpers
{
    public class PropertyData
    {
        public PropertyData(Type type)
        {
            Type = type;
            IsDataModel = type.GetInterfaces().Contains(typeof(IDataModel));
            IsDataModelCollection = CheckDataModelCollection(type);
        }

        public bool IsDataModel { get; }

        public bool IsDataModelCollection { get; }

        public Type? Type { get;  }

        public object? Object { get; set; }

        public PropertyInfo? PropertyInfo { get; set; }

        public bool CheckDataModelCollection(Type type)
        {
            var propEnumerables = type.GetInterfaces().Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEnumerable<>));
            bool isDataModelCollection = propEnumerables.Any(
                i => i.GetGenericArguments().Count() == 1
                && i.GetGenericArguments().Any(a => typeof(IDataModel).IsAssignableFrom(a)));

            return isDataModelCollection;
        }
    }
}