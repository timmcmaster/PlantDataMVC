using PlantDataMVC.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PlantDataMVC.WebApiCore.Helpers
{
    public class PropertyData
    {
        public PropertyData(Type type)
        {
            Type = type;
            IsDto = type.GetInterfaces().Contains(typeof(IDto));
            IsDtoCollection = CheckDtoCollection(type);
        }

        public bool IsDto { get; }

        public bool IsDtoCollection { get; }

        public Type? Type { get;  }

        public object? Object { get; set; }

        public PropertyInfo? PropertyInfo { get; set; }

        public bool CheckDtoCollection(Type type)
        {
            var propEnumerables = type.GetInterfaces().Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEnumerable<>));
            bool isDtoCollection = propEnumerables.Any(
                i => i.GetGenericArguments().Count() == 1
                && i.GetGenericArguments().Any(a => typeof(IDto).IsAssignableFrom(a)));

            return isDtoCollection;
        }
    }
}