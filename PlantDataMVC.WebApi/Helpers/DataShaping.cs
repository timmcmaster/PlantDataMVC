using System;
using Interfaces.DTO;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;

namespace PlantDataMVC.WebApi.Helpers
{
    public static class DataShaping
    {
        /// <summary>
        /// Creates the data shaped object.
        /// </summary>
        /// <typeparam name="TDto">The type of the dto.</typeparam>
        /// <param name="dto">The dto.</param>
        /// <param name="fieldList">The field list.</param>
        /// <param name="childrenToInclude"></param>
        /// <returns></returns>
        public static object CreateDataShapedObject<TDto>(TDto dto, List<string> fieldList/*, List<string> childrenToInclude*/) where TDto : IDto
        {
            if (!fieldList.Any())
            {
                return dto;
            }
            else
            {
                var relatedObjects = GetRelatedDtoObjects(dto);

                var childrenToInclude =
                    GetChildObjectsToInclude(relatedObjects.Select(p => p.Name).ToList(), fieldList);

                // TODO: get DTO for 
                // Strip out any child fields from list of fields
                List<string> fieldsOfChildren = fieldList.Where(f => f.Contains('.')).ToList();

                //// Determine fields for each specific child object
                //foreach (string childName in childrenToInclude)
                //{
                //    List<string> thisChildFields = fieldsOfChildren.Where(f => f.ToLower().StartsWith(childName.ToLower())).ToList();

                //    // Strip childName and "." from list of fields
                //    thisChildFields = thisChildFields.Select(f => f.Substring(f.IndexOf(".") + 1)).ToList();

                //    // Get DTO for child object

                //    // Create data shaped object for child and add to corresponding collection for this object
                //    var childShapedObject = CreateDataShapedObject<TDto>()
                //}

                // create a new ExpandoObject & dynamically create the properties for this object
                ExpandoObject objectToReturn = new ExpandoObject();
                foreach (var field in fieldList)
                {
                    var fieldType = dto.GetType();

                    // need to include public and instance, b/c specifying a binding flag overwrites the
                    // already-existing binding flags.
                    var fieldPropInfo = fieldType.GetProperty(field,
                        BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

                    var fieldValue = fieldPropInfo.GetValue(dto, null);

                    // add the field to the ExpandoObject with the actual property name from the object
                    ((IDictionary<string, object>)objectToReturn).Add(fieldPropInfo.Name, fieldValue);
                }

                return objectToReturn;
            }
        }

        /// <summary>
        /// Gets the child objects to include, given a list of all fields and a list of child objects
        /// </summary>
        /// <param name="childObjects">The child objects.</param>
        /// <param name="lstOfFields">The LST of fields.</param>
        /// <returns></returns>
        public static List<string> GetChildObjectsToInclude(List<string> childObjects, List<string> lstOfFields)
        {
            var childObjectsToInclude = new List<string>();

            // quick check for included child DTOs
            foreach (var childName in childObjects)
            {
                if (lstOfFields.Any(f => f.Contains(childName)))
                {
                    childObjectsToInclude.Add(childName);
                }
            }

            return childObjectsToInclude;
        }

        /// <summary>
        /// Gets the child objects to include, given a list of all fields and a list of child objects
        /// </summary>
        /// <param name="childObjects">The child objects.</param>
        /// <param name="lstOfFields">The LST of fields.</param>
        /// <returns></returns>
        public static List<PropertyInfo> GetRelatedDtoObjects<TDto>(TDto dto) where TDto : IDto
        {
            var relatedDtoObjects = new List<PropertyInfo>();

            // Scan all properties and get those which implement IDto or ICollection of IDto
            var fieldType = typeof(TDto);

            foreach (var propInfo in fieldType.GetProperties())
            {
                var propertyInterfaces = propInfo.PropertyType.GetInterfaces();

                // if property implements IDto
                if (typeof(IDto).IsAssignableFrom(propInfo.PropertyType))
                {
                    relatedDtoObjects.Add(propInfo);
                }

                // if property is ICollection of type that implements IDto
                bool IsDtoCollection(Type t) => t.IsGenericType && typeof(ICollection<>).IsAssignableFrom(t.GetGenericTypeDefinition()) && t.GetGenericArguments().Any(a => typeof(IDto).IsAssignableFrom(a));

                if (IsDtoCollection(propInfo.PropertyType))
                {
                    relatedDtoObjects.Add(propInfo);
                }
           }

            return relatedDtoObjects;
        }
    }
}