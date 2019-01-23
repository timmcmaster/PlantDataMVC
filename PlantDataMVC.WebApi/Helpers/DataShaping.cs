using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using Interfaces.DTO;

namespace PlantDataMVC.WebApi.Helpers
{
    public static class DataShaping
    {
        public static object CreateDataShapedObject<TDto>(TDto dto, List<string> fieldList) where TDto : IDto
        {
            if (!fieldList.Any())
            {
                return dto;
            }
            else
            {
                // create a new ExpandoObject & dynamically create the properties for this object

                ExpandoObject objectToReturn = new ExpandoObject();
                foreach (var field in fieldList)
                {
                    // need to include public and instance, b/c specifying a binding flag overwrites the
                    // already-existing binding flags.

                    var fieldType = dto.GetType();
                    var fieldPropInfo = fieldType.GetProperty(field,
                        BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

                    var fieldValue = fieldPropInfo.GetValue(dto, null);

                    // add the field to the ExpandoObject with the actual property name from the object
                    ((IDictionary<string, object>) objectToReturn).Add(fieldPropInfo.Name, fieldValue);
                }

                return objectToReturn;
            }
        }
    }
}