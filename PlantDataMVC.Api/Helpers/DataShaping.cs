using PlantDataMVC.Api.Models;
using PlantDataMVC.Api.Classes;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;

namespace PlantDataMVC.Api.Helpers
{

    public static class DataShaping
    {
        // Simplification in progress, referring to https://code-maze.com/data-shaping-aspnet-core-webapi/

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

            // Convert field list to tree
            var fieldNameTree = GetFieldTree(fieldList);

            // Convert field tree to PropertyData tree
            var propertyTree = GetPropertyTree(mainDataModel, fieldNameTree);

            // Traverse tree to get data
            //var dataShapedObject = new ExpandoObject();
            var dataShapedObject = propertyTree.TraverseWithObject(GetKVPFromProperty);

            return dataShapedObject;













            var mainDataModelProperties = typeof(TDataModel).GetProperties(BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);


            //// Get Properties from main DataModel
            //var requiredProperties = GetRequiredProperties(mainDataModelProperties, fieldsToWorkWith);

            // Get values
            //var shapedObject = FetchDataForEntity(mainDataModel, requiredProperties);

            //return shapedObject;


            // Child DataModel/collection handling

            // Get PropertyInfo objects describing child DTOs or DTO collections for current main DataModel
            var propertiesUsingDataModel = mainDataModelProperties.WhereUsingDataModel();

            // create a new ExpandoObject & dynamically create the properties for this object
            var objectToReturn = new ExpandoObject();

            // Determine fields for each specific child object
            foreach (var propertyUsingDataModel in propertiesUsingDataModel)
            {
                // get fields for just this object (start with property name)
                var childDataModelFields = fieldsToWorkWith.Where(f => f.ToLower().StartsWith(propertyUsingDataModel.Name.ToLower())).ToList();

                // if fields contains name of full child object, return full object by keeping property in main list
                var returnFullObject = childDataModelFields.Any(f => f.ToLower().Equals(propertyUsingDataModel.Name.ToLower()));

                if (returnFullObject)
                {
                    // Remove all fields but full object from main list
                    var fullDataModelField = childDataModelFields.Where(f => f.ToLower().Equals(propertyUsingDataModel.Name.ToLower())).ToList();
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
                    if (propertyUsingDataModel.GetValue(mainDataModel, null) is IEnumerable<IDataModel> dataModelCollection)
                    {
                        var outputCollection = new List<object>();

                        foreach (var childDataModel in dataModelCollection)
                        {
                            // Create data shaped object for child and add to corresponding collection for this object
                            var childShapedObject = CreateDataShapedObject(childDataModel, childDataModelFields);
                            outputCollection.Add(childShapedObject);
                        }

                        ((IDictionary<string, object>)objectToReturn).Add(propertyUsingDataModel.Name, outputCollection);
                    }
                    else if (propertyUsingDataModel.GetValue(mainDataModel, null) is IDataModel)
                    {
                        var childDataModel = propertyUsingDataModel.GetValue(mainDataModel, null) as IDataModel;

                        // Create data shaped object for child and add to corresponding collection for this object
                        var childShapedObject = CreateDataShapedObject(childDataModel, childDataModelFields);

                        ((IDictionary<string, object>)objectToReturn).Add(propertyUsingDataModel.Name, childShapedObject);
                    }
                }
            }




        }

        public static KeyValuePair<string, object> GetKVPFromProperty(PropertyData propertyData)
        {
            if (propertyData.Type != null)
            {
                var name = propertyData?.PropertyInfo?.Name ?? "(unnamed)";
                Console.WriteLine($"Called GetKVPFromProperty for {name}");

                if (propertyData.IsDataModel)
                {
                    return new KeyValuePair<string, object>("dataModel", "");
                }
                else if (propertyData.IsDataModelCollection)
                {
                    return new KeyValuePair<string, object>("dataModelCollection", "");
                }
                else
                {
                    return new KeyValuePair<string, object>(propertyData.PropertyInfo.Name, propertyData.Object);
                }
            }

            return new KeyValuePair<string, object>();
            /*
            if (propertyData.Type != null)
            { }

            if (propertyData.PropertyInfo != null)
            {
                var parentObject = currentNode?.Parent?.Value?.Object;

                // Get property value against parent object
                //var propValue = propertyData.PropertyInfo.GetValue(parentObject)
            }
                            // If is leaf node, add property value

                            // If is enumerable of DTO type

                            // If is single dataModel type
                            if (propertyUsingDataModel.GetValue(mainDataModel, null) is IEnumerable<IDataModel> dataModelCollection)
                            {
                                var outputCollection = new List<object>();

                                foreach (var childDataModel in dataModelCollection)
                                {
                                    // Create data shaped object for child and add to corresponding collection for this object
                                    var childShapedObject = CreateDataShapedObject(childDataModel, childDataModelFields);
                                    outputCollection.Add(childShapedObject);
                                }

                                ((IDictionary<string, object>)objectToReturn).Add(propertyUsingDataModel.Name, outputCollection);
                            }
                            else if (propertyUsingDataModel.GetValue(mainDataModel, null) is IDataModel)
                            {
                                var childDataModel = propertyUsingDataModel.GetValue(mainDataModel, null) as IDataModel;

                                // Create data shaped object for child and add to corresponding collection for this object
                                var childShapedObject = CreateDataShapedObject(childDataModel, childDataModelFields);

                                ((IDictionary<string, object>)objectToReturn).Add(propertyUsingDataModel.Name, childShapedObject);
                            }
            */

        }

        internal static List<string> GetTrimmedFieldList(List<string> fieldList)
        {
            // Take a new copy of fields to manipulate
            var trimmedFieldList = new List<string>(fieldList);

            // Trim the field list (which allows for shaping sub-objects)
            // so that if we have an item for the entire object, ignore items for individual fields of that object
            var objectPropertyFields = trimmedFieldList.Where(s => s.Contains('.')).ToList();
            var fullObjectFields = trimmedFieldList.Where(s => !s.Contains('.')).ToList();

            if (!objectPropertyFields.Any())
            {
                return trimmedFieldList;
            }
            else
            {
                foreach (var fullObjectField in fullObjectFields)
                {
                    // Get any property fields for this object
                    var myObjectPropertyFields = objectPropertyFields.Where(f => f.ToLower().StartsWith($"{fullObjectField.ToLower()}.")).ToList();
                    // if any, remove from list
                    if (myObjectPropertyFields.Any())
                    {
                        trimmedFieldList.RemoveItems(myObjectPropertyFields);
                    }
                }
            }

            return trimmedFieldList;
        }

        internal static TreeNode<string> GetFieldTree(List<string> fieldList)
        {
            // Trim the field list to remove any fields that are redundant
            var trimmedFields = GetTrimmedFieldList(fieldList);

            // Convert field list to tree
            var rootNode = new TreeNode<string>("");
            foreach (var field in trimmedFields)
            {
                var levels = field.Split('.');
                var node = rootNode;

                for (int i = 0; i < levels.Length; i++)
                {
                    if (string.IsNullOrEmpty(levels[i]))
                        break;
                    // get node matching field
                    var childNode = node.Children.FirstOrDefault(n => n.Value == levels[i]);
                    // or add it
                    node = childNode ?? node.AddChild(levels[i]);
                }
            }

            return rootNode;
        }


        internal static TreeNode<PropertyData> GetPropertyTree<TDataModel>(TDataModel mainDataModel, TreeNode<string> fieldNameTree)
        {
            var transformVisitor = new CloneAndTransformVisitor<string, PropertyData>((fieldNode, parentPropertyNode) =>
            {
                if (fieldNode.IsRootNode)
                    return new PropertyData(typeof(TDataModel)) { Object = mainDataModel };
                else 
                    return ConvertFieldToPropertyData(fieldNode, parentPropertyNode);
            });

            fieldNameTree.Accept(transformVisitor);
            var transformedTree = transformVisitor.CloneRoot;

            return transformedTree;
        }

        public static PropertyData ConvertFieldToPropertyData(TreeNode<string> fieldNode, TreeNode<PropertyData> targetParent)
        {
            // blank field name = root node
            //if (fieldNode.IsRootNode)
            //{
            //    // TODO : Fix getting root node object
            //    return new PropertyData(typeof(string));
            //    //return new PropertyData() { Type = typeof(TDataModel), Object = mainDataModel, IsDataModel = true, IsDataModelCollection = false };
            //}
            //else
            {
                PropertyData propertyData = null;

                // if parent is IEnumerable<IDataModel>
                if (targetParent.Value.IsDataModelCollection)
                {
                    var parentPropertyType = targetParent.Value.Type;
                    var iEnumerables = parentPropertyType.GetInterfaces().Where(
                        i => i.IsGenericType
                        && i.GetGenericTypeDefinition() == typeof(IEnumerable<>));

                    var iEnumerableOfIDataModel = iEnumerables.FirstOrDefault(
                        i => i.GetGenericArguments().Count() == 1
                        && i.GetGenericArguments().Any(a => typeof(IDataModel).IsAssignableFrom(a)));

                    // Property does not come from parent node but from elements of parent node collection
                    var genericArgument = iEnumerableOfIDataModel.GetGenericArguments().First(a => typeof(IDataModel).IsAssignableFrom(a));
                    var itemProperties = genericArgument.GetProperties(BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                    var property = itemProperties.FirstOrDefault(pi => pi.Name.ToLower() == fieldNode.Value.ToLower());
                    if (property != null)
                    {
                        var propertyType = property.PropertyType;
                        //var propertyValue = property.GetValue(targetParent.Value.Object);
                        
                        // add PropertyInfo to new tree 
                        propertyData = new PropertyData(propertyType)
                        {
                            PropertyInfo = property//,
                            //Object = propertyValue
                        };
                    }
                }
                else
                {
                    // find property by name
                    var parentProperties = targetParent.Value.Type.GetProperties(BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                    var property = parentProperties.FirstOrDefault(pi => pi.Name.ToLower() == fieldNode.Value.ToLower());
                    if (property != null)
                    {
                        var propEnumerables = property.PropertyType.GetInterfaces().Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEnumerable<>));
                        bool isDataModelCollection = propEnumerables.Any(
                            i => i.GetGenericArguments().Count() == 1
                            && i.GetGenericArguments().Any(a => typeof(IDataModel).IsAssignableFrom(a)));

                        propertyData = new PropertyData(property.PropertyType) 
                        { 
                            PropertyInfo = property, 
                            Object = property.GetValue(targetParent.Value.Object)        
                        };
                    }
                }

                return propertyData;
            }
        }

        /*
            internal static TreeNode<PropertyData> FieldToPropertyDataTransform(string field, TreeNode<PropertyData> parentPropertyNode)
            {
                var propertyData = new PropertyData() { Type = typeof(TDataModel), Object = mainDataModel, IsDataModel = true, IsDataModelCollection = false };

                // blank field name = root node
                if ((field != "") && (parentPropertyNode?.Value?.Type != null))
                {
                    //var isDataModel = 
                    var parentPropertyType = parentPropertyNode.Value.Type;
                    // if type is Ienumerable<> where defined generic is of type IDataModel
                    var iEnumerables = parentPropertyType.GetInterfaces().Where(
                        i => i.IsGenericType
                        && i.GetGenericTypeDefinition() == typeof(IEnumerable<>));

                    var iEnumerableOfIDataModel = iEnumerables.FirstOrDefault(
                        i => i.GetGenericArguments().Count() == 1
                        && i.GetGenericArguments().Any(a => typeof(IDataModel).IsAssignableFrom(a)));

                    // if parent is IEnumerable<IDataModel>
                    if (iEnumerableOfIDataModel != null)
                    {
                        // Property does not come from parent node but from elements of parent node collection
                        var genericArgument = iEnumerableOfIDataModel.GetGenericArguments().First(a => typeof(IDataModel).IsAssignableFrom(a));
                        var itemProperties = genericArgument.GetProperties(BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                        var property = itemProperties.FirstOrDefault(pi => pi.Name.ToLower() == field.ToLower());
                        if (property != null)
                        {
                            // add PropertyInfo to new tree 
                            propertyData = new PropertyData()
                            {
                                Type = property.PropertyType,
                                PropertyInfo = property
                                //, Object = property.GetValue(parentPropertyNode.Value.Object)
                            };
                        }
                    }
                    else
                    {
                        // find property by name
                        var parentProperties = parentPropertyNode.Value.Type.GetProperties(BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                        var property = parentProperties.FirstOrDefault(pi => pi.Name.ToLower() == field.ToLower());
                        if (property != null)
                        {
                            // add PropertyInfo to new tree 
                            propertyData = new PropertyData() { Type = property.PropertyType, PropertyInfo = property, Object = property.GetValue(parentPropertyNode.Value.Object) };
                        }
                    }
                }
                return propertyData;
            }
            */



        /*
                private static ExpandoObject FetchData<TDataModel>(TDataModel mainDataModel, TreeNode<string> startingFieldNode)
                {
                    var shapedObject = new ExpandoObject();

                    if (startingFieldNode.IsLeafNode)
                    {
                        // Get ALL node properties (except virtual ones?)

                        var propData = startingFieldNode.Value;
                        // add object to expando
                        ((IDictionary<string, object>)shapedObject).Add(propData.PropertyInfo.Name, propData.Object);
                    }
                    if (startingFieldNode.IsLeafNode)
                    { 

                    }

                    // Traverse the field tree and provided the current node is a DataModel or IEnumerable<dataModel>, add property definitions
                    var propertyTree = fieldNameTree.CloneAndTransform<PropertyData>((field, parentPropertyNode) =>
                    {
                        var propertyData = new PropertyData() { Type = typeof(TDataModel), Object = mainDataModel };

                        // blank field name = root node
                        if ((field != "") && (parentPropertyNode?.Value?.Type != null))
                        {
                            // find property by name
                            var parentProperties = parentPropertyNode.Value.Type.GetProperties(BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                            var property = parentProperties.FirstOrDefault(pi => pi.Name.ToLower() == field.ToLower());
                            if (property != null)
                            {
                                // add PropertyInfo to new tree 
                                propertyData = new PropertyData() { Type = property.PropertyType, PropertyInfo = property, Object = property.GetValue(parentPropertyNode.Value.Object) };
                            }
                        }
                        return propertyData;
                    });

                    return propertyTree;
                }

                private static ExpandoObject FetchDataForEntity<TDataModel>(TDataModel entity, TreeNode<PropertyData> startingNode) where TDataModel : IDataModel
                {
                    var shapedObject = new ExpandoObject();

                    if (startingNode.IsLeafNode)
                    {
                        // Get ALL node properties (except virtual ones?)

                        var propData = startingNode.Value;
                        // add object to expando
                        ((IDictionary<string, object>)shapedObject).Add(propData.PropertyInfo.Name, propData.Object);
                    }
                    else
                    {
                        // Only get defined child node properties

                        var propData = startingNode.Value;

                        // If this is enumerable, recognise child fields as properties of the ELEMENTS of enumerable, not enumerable itself
                        if (propData.Object is IEnumerable<IDataModel> dataModelCollection)
                        {
                            FetchData
                        }
                    }


                    foreach (var property in requiredProperties)
                    {
                        var propertyValue = property.GetValue(entity, null);

                        // add the field to the ExpandoObject with the actual property name from the object
                        ((IDictionary<string, object>)shapedObject).Add(property.Name, propertyValue);
                    }

                    return shapedObject;
                }

                private static ExpandoObject FetchData<TDataModel>(IEnumerable<TDataModel> entities, TreeNode<PropertyData> startingNode) where TDataModel : IDataModel
                {
                    var shapedData = new List<ExpandoObject>();

                    foreach (var entity in entities)
                    {
                        var propertyValue = property.GetValue(entity, null);

                        // add the field to the ExpandoObject with the actual property name from the object
                        ((IDictionary<string, object>)shapedObject).Add(property.Name, propertyValue);
                    }

                    return shapedObject;
                }

                private static ExpandoObject FetchDataForEntity<TDataModel>(TDataModel entity, IEnumerable<PropertyInfo> requiredProperties) where TDataModel : IDataModel
                {
                    var shapedObject = new ExpandoObject();

                    foreach (var property in requiredProperties)
                    {
                        var propertyValue = property.GetValue(entity, null);

                        // add the field to the ExpandoObject with the actual property name from the object
                        ((IDictionary<string, object>)shapedObject).Add(property.Name, propertyValue);
                    }

                    return shapedObject;
                }
        */
        /// <summary>
        ///     Gets the included object names.
        /// </summary>
        /// <typeparam name="TDataModel">The type of the dataModel.</typeparam>
        /// <param name="lstOfFields">The LST of fields.</param>
        /// <returns></returns>
        public static List<string> GetIncludedObjectNames<TDataModel>(List<string> lstOfFields) where TDataModel : IDataModel
        {
            var mainDataModelProperties = typeof(TDataModel).GetProperties(BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

            // Get PropertyInfo objects describing child DTOs or DTO collections for current main DataModel
            var propertiesUsingDataModel = mainDataModelProperties.WhereUsingDataModel();

            var dataModelNames = propertiesUsingDataModel.Select(p => p.Name);

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
        private static IEnumerable<PropertyInfo> WhereUsingDataModel(this IEnumerable<PropertyInfo> properties)
        {
            return properties.Where(pi => typeof(IDataModel).IsAssignableFrom(pi.PropertyType) || IsDataModelEnumerable(pi.PropertyType));
        }

        private static IEnumerable<PropertyInfo> GetRequiredProperties(IEnumerable<PropertyInfo> mainDataModelProperties, IEnumerable<string> fieldsToWorkWith)
        {
            // Get Properties 
            var requiredProperties = new List<PropertyInfo>();

            foreach (var field in fieldsToWorkWith)
            {
                var property = mainDataModelProperties.FirstOrDefault(pi => pi.Name == field);
                if (property != null)
                {
                    requiredProperties.Add(property);
                }
            }

            return requiredProperties;
        }


        // if property is IEnumerable of type that implements IDataModel
        private static bool IsDataModelEnumerable(Type t)
        {
            return t.IsGenericType &&
                   t.GetInterface(typeof(IEnumerable<>).FullName) != null &&
                   t.GetGenericArguments().Any(a => typeof(IDataModel).IsAssignableFrom(a));
        }
    }
}