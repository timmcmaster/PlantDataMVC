using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using PlantDataMVC.Api.Models;

namespace PlantDataMVC.Api.Helpers
{
    public static class DataShaping_Original
    {
        /// <summary>
        ///     Creates the data shaped object.
        /// </summary>
        /// <typeparam name="TDataModel">The type of the dataModel.</typeparam>
        /// <param name="mainDataModel">The main dataModel.</param>
        /// <param name="fieldList">The field list.</param>
        /// <returns></returns>
        public static object CreateDataShapedObject<TDataModel>(TDataModel mainDataModel, List<string> fieldList) where TDataModel : IDataModel
        {
            // Take a new copy of fields to manipulate
            var fieldsToWorkWith = new List<string>(fieldList);

            if (!fieldsToWorkWith.Any())
            {
                return mainDataModel;
            }

            // Get PropertyInfo objects of child DTOs or collections for given type of DataModel
            var dataModelPropInfos = GetRelatedDataModelPropInfos<TDataModel>();

            // create a new ExpandoObject & dynamically create the properties for this object
            var objectToReturn = new ExpandoObject();

            // Determine fields for each specific child object
            foreach (var propInfo in dataModelPropInfos)
            {
                // get fields for just this object (start with property name)
                var childDataModelFields =
                    fieldsToWorkWith.Where(f => f.ToLower().StartsWith(propInfo.Name.ToLower())).ToList();

                // if fields contains name of full child object, return full object by keeping property in main list
                var returnFullObject = childDataModelFields.Any(f => f.ToLower().Equals(propInfo.Name.ToLower()));

                if (returnFullObject)
                {
                    // Remove all fields but full object from main list
                    var fullDataModelField = childDataModelFields.Where(f => f.ToLower().Equals(propInfo.Name.ToLower())).ToList();
                    childDataModelFields = childDataModelFields.Except(fullDataModelField).ToList();
                    fieldsToWorkWith.RemoveItems(childDataModelFields);
                }
                else
                {
                    // Remove all fields from main list and deal with them in child object
                    fieldsToWorkWith.RemoveItems(childDataModelFields);

                    // Strip childName and "." from list of fields
                    childDataModelFields = childDataModelFields.Select(f => f.Substring(f.IndexOf(".") + 1)).ToList();

                    // Get DTO for child object or collection
                    if (propInfo.GetValue(mainDataModel, null) is IEnumerable<IDataModel> dataModelCollection)
                    {
                        var outputCollection = new List<object>();

                        foreach (var childDataModel in dataModelCollection)
                        {
                            // Create data shaped object for child and add to corresponding collection for this object
                            var childShapedObject = CreateDataShapedObject(childDataModel, childDataModelFields);
                            outputCollection.Add(childShapedObject);
                        }

                        ((IDictionary<string, object>) objectToReturn).Add(propInfo.Name, outputCollection);
                    }
                    else if (propInfo.GetValue(mainDataModel, null) is IDataModel)
                    {
                        var childDataModel = propInfo.GetValue(mainDataModel, null) as IDataModel;

                        // Create data shaped object for child and add to corresponding collection for this object
                        var childShapedObject = CreateDataShapedObject(childDataModel, childDataModelFields);

                        ((IDictionary<string, object>) objectToReturn).Add(propInfo.Name, childShapedObject);
                    }
                }
            }

            foreach (var field in fieldsToWorkWith)
            {
                // need to include public and instance, b/c specifying a binding flag overwrites the
                // already-existing binding flags.
                var fieldPropInfo = mainDataModel.GetType().GetProperty(field,
                                                                  BindingFlags.IgnoreCase | BindingFlags.Public |
                                                                  BindingFlags.Instance);

                if (fieldPropInfo != null)
                {
                    var fieldValue = fieldPropInfo.GetValue(mainDataModel, null);

                    // add the field to the ExpandoObject with the actual property name from the object
                    ((IDictionary<string, object>) objectToReturn).Add(fieldPropInfo.Name, fieldValue);
                }
            }

            return objectToReturn;
        }

        /// <summary>
        ///     Gets the included object names.
        /// </summary>
        /// <typeparam name="TDataModel">The type of the dataModel.</typeparam>
        /// <param name="lstOfFields">The LST of fields.</param>
        /// <returns></returns>
        public static List<string> GetIncludedObjectNames<TDataModel>(List<string> lstOfFields) where TDataModel : IDataModel
        {
            var dataModelNames = GetRelatedDataModelPropInfos<TDataModel>().Select(p => p.Name);

            var childObjectsToInclude = new List<string>();

            // quick check for included child DTOs
            foreach (var childName in dataModelNames)
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
        public static List<PropertyInfo> GetRelatedDataModelPropInfos<TDataModel>() where TDataModel : IDataModel
        {
            var relatedDataModelObjects = new List<PropertyInfo>();

            // Scan all properties and get those which implement IDataModel or ICollection of IDataModel
            var fieldType = typeof(TDataModel);

            foreach (var propInfo in fieldType.GetProperties())
            {
                // if property implements IDataModel
                if (typeof(IDataModel).IsAssignableFrom(propInfo.PropertyType))
                {
                    relatedDataModelObjects.Add(propInfo);
                }

                // if property is IEnumerable of type that implements IDataModel
                bool IsDataModelEnumerable(Type t)
                {
                    return t.IsGenericType &&
                           t.GetInterface(typeof(IEnumerable<>).FullName) != null &&
                           t.GetGenericArguments().Any(a => typeof(IDataModel).IsAssignableFrom(a));
                }

                if (IsDataModelEnumerable(propInfo.PropertyType))
                {
                    relatedDataModelObjects.Add(propInfo);
                }
            }

            return relatedDataModelObjects;
        }
    }
}