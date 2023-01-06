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

            // Convert field list to tree
            var fieldNameTree = GetFieldTree(fieldList);

            // Convert field tree to PropertyData tree
            var propertyTree = GetPropertyTree(mainDto, fieldNameTree);

            // Traverse tree to get data
            //var dataShapedObject = new ExpandoObject();
            var dataShapedObject = propertyTree.TraverseWithObject(GetKVPFromProperty);

            return dataShapedObject;













            var mainDtoProperties = typeof(TDto).GetProperties(BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);


            //// Get Properties from main Dto
            //var requiredProperties = GetRequiredProperties(mainDtoProperties, fieldsToWorkWith);

            // Get values
            //var shapedObject = FetchDataForEntity(mainDto, requiredProperties);

            //return shapedObject;


            // Child Dto/collection handling

            // Get PropertyInfo objects describing child DTOs or DTO collections for current main Dto
            var propertiesUsingDto = mainDtoProperties.WhereUsingDto();

            // create a new ExpandoObject & dynamically create the properties for this object
            var objectToReturn = new ExpandoObject();

            // Determine fields for each specific child object
            foreach (var propertyUsingDto in propertiesUsingDto)
            {
                // get fields for just this object (start with property name)
                var childDtoFields = fieldsToWorkWith.Where(f => f.ToLower().StartsWith(propertyUsingDto.Name.ToLower())).ToList();

                // if fields contains name of full child object, return full object by keeping property in main list
                var returnFullObject = childDtoFields.Any(f => f.ToLower().Equals(propertyUsingDto.Name.ToLower()));

                if (returnFullObject)
                {
                    // Remove all fields but full object from main list
                    var fullDtoField = childDtoFields.Where(f => f.ToLower().Equals(propertyUsingDto.Name.ToLower())).ToList();
                    childDtoFields = childDtoFields.Except(fullDtoField).ToList();
                    fieldsToWorkWith.RemoveItems(childDtoFields);
                }
                else
                {
                    // Remove all fields from main list and deal with them in child object
                    fieldsToWorkWith.RemoveItems(childDtoFields);

                    // Strip childName and "." from list of fields
                    childDtoFields = childDtoFields.Select(f => f.Substring(f.IndexOf(".") + 1)).ToList();

                    // Get DTO for child object or collection
                    if (propertyUsingDto.GetValue(mainDto, null) is IEnumerable<IDto> dtoCollection)
                    {
                        var outputCollection = new List<object>();

                        foreach (var childDto in dtoCollection)
                        {
                            // Create data shaped object for child and add to corresponding collection for this object
                            var childShapedObject = CreateDataShapedObject(childDto, childDtoFields);
                            outputCollection.Add(childShapedObject);
                        }

                        ((IDictionary<string, object>)objectToReturn).Add(propertyUsingDto.Name, outputCollection);
                    }
                    else if (propertyUsingDto.GetValue(mainDto, null) is IDto)
                    {
                        var childDto = propertyUsingDto.GetValue(mainDto, null) as IDto;

                        // Create data shaped object for child and add to corresponding collection for this object
                        var childShapedObject = CreateDataShapedObject(childDto, childDtoFields);

                        ((IDictionary<string, object>)objectToReturn).Add(propertyUsingDto.Name, childShapedObject);
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

                if (propertyData.IsDto)
                {
                    return new KeyValuePair<string, object>("dto", "");
                }
                else if (propertyData.IsDtoCollection)
                {
                    return new KeyValuePair<string, object>("dtoCollection", "");
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

                            // If is single dto type
                            if (propertyUsingDto.GetValue(mainDto, null) is IEnumerable<IDto> dtoCollection)
                            {
                                var outputCollection = new List<object>();

                                foreach (var childDto in dtoCollection)
                                {
                                    // Create data shaped object for child and add to corresponding collection for this object
                                    var childShapedObject = CreateDataShapedObject(childDto, childDtoFields);
                                    outputCollection.Add(childShapedObject);
                                }

                                ((IDictionary<string, object>)objectToReturn).Add(propertyUsingDto.Name, outputCollection);
                            }
                            else if (propertyUsingDto.GetValue(mainDto, null) is IDto)
                            {
                                var childDto = propertyUsingDto.GetValue(mainDto, null) as IDto;

                                // Create data shaped object for child and add to corresponding collection for this object
                                var childShapedObject = CreateDataShapedObject(childDto, childDtoFields);

                                ((IDictionary<string, object>)objectToReturn).Add(propertyUsingDto.Name, childShapedObject);
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


        internal static TreeNode<PropertyData> GetPropertyTree<TDto>(TDto mainDto, TreeNode<string> fieldNameTree)
        {
            var transformVisitor = new CloneAndTransformVisitor<string, PropertyData>((fieldNode, parentPropertyNode) =>
            {
                if (fieldNode.IsRootNode)
                    return new PropertyData(typeof(TDto)) { Object = mainDto };
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
            //    //return new PropertyData() { Type = typeof(TDto), Object = mainDto, IsDto = true, IsDtoCollection = false };
            //}
            //else
            {
                PropertyData propertyData = null;

                // if parent is IEnumerable<IDto>
                if (targetParent.Value.IsDtoCollection)
                {
                    var parentPropertyType = targetParent.Value.Type;
                    var iEnumerables = parentPropertyType.GetInterfaces().Where(
                        i => i.IsGenericType
                        && i.GetGenericTypeDefinition() == typeof(IEnumerable<>));

                    var iEnumerableOfIDto = iEnumerables.FirstOrDefault(
                        i => i.GetGenericArguments().Count() == 1
                        && i.GetGenericArguments().Any(a => typeof(IDto).IsAssignableFrom(a)));

                    // Property does not come from parent node but from elements of parent node collection
                    var genericArgument = iEnumerableOfIDto.GetGenericArguments().First(a => typeof(IDto).IsAssignableFrom(a));
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
                        bool isDtoCollection = propEnumerables.Any(
                            i => i.GetGenericArguments().Count() == 1
                            && i.GetGenericArguments().Any(a => typeof(IDto).IsAssignableFrom(a)));

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
                var propertyData = new PropertyData() { Type = typeof(TDto), Object = mainDto, IsDto = true, IsDtoCollection = false };

                // blank field name = root node
                if ((field != "") && (parentPropertyNode?.Value?.Type != null))
                {
                    //var isDto = 
                    var parentPropertyType = parentPropertyNode.Value.Type;
                    // if type is Ienumerable<> where defined generic is of type IDto
                    var iEnumerables = parentPropertyType.GetInterfaces().Where(
                        i => i.IsGenericType
                        && i.GetGenericTypeDefinition() == typeof(IEnumerable<>));

                    var iEnumerableOfIDto = iEnumerables.FirstOrDefault(
                        i => i.GetGenericArguments().Count() == 1
                        && i.GetGenericArguments().Any(a => typeof(IDto).IsAssignableFrom(a)));

                    // if parent is IEnumerable<IDto>
                    if (iEnumerableOfIDto != null)
                    {
                        // Property does not come from parent node but from elements of parent node collection
                        var genericArgument = iEnumerableOfIDto.GetGenericArguments().First(a => typeof(IDto).IsAssignableFrom(a));
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
                private static ExpandoObject FetchData<TDto>(TDto mainDto, TreeNode<string> startingFieldNode)
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

                    // Traverse the field tree and provided the current node is a Dto or IEnumerable<dto>, add property definitions
                    var propertyTree = fieldNameTree.CloneAndTransform<PropertyData>((field, parentPropertyNode) =>
                    {
                        var propertyData = new PropertyData() { Type = typeof(TDto), Object = mainDto };

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

                private static ExpandoObject FetchDataForEntity<TDto>(TDto entity, TreeNode<PropertyData> startingNode) where TDto : IDto
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
                        if (propData.Object is IEnumerable<IDto> dtoCollection)
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

                private static ExpandoObject FetchData<TDto>(IEnumerable<TDto> entities, TreeNode<PropertyData> startingNode) where TDto : IDto
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

                private static ExpandoObject FetchDataForEntity<TDto>(TDto entity, IEnumerable<PropertyInfo> requiredProperties) where TDto : IDto
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
        /// <typeparam name="TDto">The type of the dto.</typeparam>
        /// <param name="lstOfFields">The LST of fields.</param>
        /// <returns></returns>
        public static List<string> GetIncludedObjectNames<TDto>(List<string> lstOfFields) where TDto : IDto
        {
            var mainDtoProperties = typeof(TDto).GetProperties(BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

            // Get PropertyInfo objects describing child DTOs or DTO collections for current main Dto
            var propertiesUsingDto = mainDtoProperties.WhereUsingDto();

            var dtoNames = propertiesUsingDto.Select(p => p.Name);

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
        private static IEnumerable<PropertyInfo> WhereUsingDto(this IEnumerable<PropertyInfo> properties)
        {
            return properties.Where(pi => typeof(IDto).IsAssignableFrom(pi.PropertyType) || IsDtoEnumerable(pi.PropertyType));
        }

        private static IEnumerable<PropertyInfo> GetRequiredProperties(IEnumerable<PropertyInfo> mainDtoProperties, IEnumerable<string> fieldsToWorkWith)
        {
            // Get Properties 
            var requiredProperties = new List<PropertyInfo>();

            foreach (var field in fieldsToWorkWith)
            {
                var property = mainDtoProperties.FirstOrDefault(pi => pi.Name == field);
                if (property != null)
                {
                    requiredProperties.Add(property);
                }
            }

            return requiredProperties;
        }


        // if property is IEnumerable of type that implements IDto
        private static bool IsDtoEnumerable(Type t)
        {
            return t.IsGenericType &&
                   t.GetInterface(typeof(IEnumerable<>).FullName) != null &&
                   t.GetGenericArguments().Any(a => typeof(IDto).IsAssignableFrom(a));
        }
    }
}