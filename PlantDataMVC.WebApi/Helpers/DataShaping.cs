using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using Interfaces.DTO;

namespace PlantDataMVC.WebApi.Helpers
{
    public static class DataShaping
    {
        /// <summary>
        ///     Creates the data shaped object.
        /// </summary>
        /// <typeparam name="TDto">The type of the dto.</typeparam>
        /// <param name="mainDto">The main dto.</param>
        /// <param name="fieldList">The field list.</param>
        /// <returns></returns>
        public static object CreateDataShapedObject<TDto>(TDto mainDto, List<string> fieldList) where TDto : IDto
        {
            // Take a new copy of fields to manipulate
            var fieldsToWorkWith = new List<string>(fieldList);

            if (!fieldsToWorkWith.Any())
            {
                return mainDto;
            }

            // Get PropertyInfo objects of child DTOs or collections for given type of Dto
            var dtoPropInfos = GetRelatedDtoPropInfos<TDto>();

            // create a new ExpandoObject & dynamically create the properties for this object
            var objectToReturn = new ExpandoObject();

            // Determine fields for each specific child object
            foreach (var propInfo in dtoPropInfos)
            {
                // get fields for just this object (start with property name)
                var childDtoFields =
                    fieldsToWorkWith.Where(f => f.ToLower().StartsWith(propInfo.Name.ToLower())).ToList();

                // if fields contains name of full child object, return full object by keeping property in main list
                var returnFullObject = childDtoFields.Any(f => f.ToLower().Equals(propInfo.Name.ToLower()));

                if (returnFullObject)
                {
                    // Remove all fields but full object from main list
                    var fullDtoField = childDtoFields.Where(f => f.ToLower().Equals(propInfo.Name.ToLower())).ToList();
                    childDtoFields = childDtoFields.Except(fullDtoField).ToList();
                    fieldsToWorkWith.RemoveRange(childDtoFields);
                }
                else
                {
                    // Remove all fields from main list and deal with them in child object
                    fieldsToWorkWith.RemoveRange(childDtoFields);

                    // Strip childName and "." from list of fields
                    childDtoFields = childDtoFields.Select(f => f.Substring(f.IndexOf(".") + 1)).ToList();

                    // Get DTO for child object or collection
                    if (propInfo.GetValue(mainDto, null) is IEnumerable<IDto> dtoCollection)
                    {
                        var outputCollection = new List<object>();

                        foreach (var childDto in dtoCollection)
                        {
                            // Create data shaped object for child and add to corresponding collection for this object
                            var childShapedObject = CreateDataShapedObject(childDto, childDtoFields);
                            outputCollection.Add(childShapedObject);
                        }

                        ((IDictionary<string, object>) objectToReturn).Add(propInfo.Name, outputCollection);
                    }
                    else if (propInfo.GetValue(mainDto, null) is IDto)
                    {
                        var childDto = propInfo.GetValue(mainDto, null) as IDto;

                        // Create data shaped object for child and add to corresponding collection for this object
                        var childShapedObject = CreateDataShapedObject(childDto, childDtoFields);

                        ((IDictionary<string, object>) objectToReturn).Add(propInfo.Name, childShapedObject);
                    }
                }
            }

            foreach (var field in fieldsToWorkWith)
            {
                // need to include public and instance, b/c specifying a binding flag overwrites the
                // already-existing binding flags.
                var fieldPropInfo = mainDto.GetType().GetProperty(field,
                                                                  BindingFlags.IgnoreCase | BindingFlags.Public |
                                                                  BindingFlags.Instance);

                if (fieldPropInfo != null)
                {
                    var fieldValue = fieldPropInfo.GetValue(mainDto, null);

                    // add the field to the ExpandoObject with the actual property name from the object
                    ((IDictionary<string, object>) objectToReturn).Add(fieldPropInfo.Name, fieldValue);
                }
            }

            return objectToReturn;
        }

        /// <summary>
        ///     Gets the included object names.
        /// </summary>
        /// <typeparam name="TDto">The type of the dto.</typeparam>
        /// <param name="lstOfFields">The LST of fields.</param>
        /// <returns></returns>
        public static List<string> GetIncludedObjectNames<TDto>(List<string> lstOfFields) where TDto : IDto
        {
            var dtoNames = GetRelatedDtoPropInfos<TDto>().Select(p => p.Name);

            var childObjectsToInclude = new List<string>();

            // quick check for included child DTOs
            foreach (var childName in dtoNames)
            {
                if (lstOfFields.Any(f => f.ToLower().Contains(childName.ToLower())))
                {
                    childObjectsToInclude.Add(childName);
                }
            }

            return childObjectsToInclude;
        }

        /// <summary>
        ///     Gets the child objects to include
        /// </summary>
        /// <returns></returns>
        public static List<PropertyInfo> GetRelatedDtoPropInfos<TDto>() where TDto : IDto
        {
            var relatedDtoObjects = new List<PropertyInfo>();

            // Scan all properties and get those which implement IDto or ICollection of IDto
            var fieldType = typeof(TDto);

            foreach (var propInfo in fieldType.GetProperties())
            {
                // if property implements IDto
                if (typeof(IDto).IsAssignableFrom(propInfo.PropertyType))
                {
                    relatedDtoObjects.Add(propInfo);
                }

                // if property is IEnumerable of type that implements IDto
                bool IsDtoEnumerable(Type t)
                {
                    return t.IsGenericType &&
                           t.GetInterface(typeof(IEnumerable<>).FullName) != null &&
                           t.GetGenericArguments().Any(a => typeof(IDto).IsAssignableFrom(a));
                }

                if (IsDtoEnumerable(propInfo.PropertyType))
                {
                    relatedDtoObjects.Add(propInfo);
                }
            }

            return relatedDtoObjects;
        }
    }
}