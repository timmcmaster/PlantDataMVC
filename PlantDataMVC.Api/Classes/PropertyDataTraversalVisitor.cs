using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using PlantDataMVC.Api.Models;
using PlantDataMVC.Api.Helpers;

namespace PlantDataMVC.Api.Classes
{
    public class PropertyDataTraversalVisitor : ITreeVisitor<PropertyData>
    {
        //private Stack<IDictionary<string, object>> _dictionaryStack;
        private IDictionary<string, object> _currentDict = null;

        public IDictionary<string, object> RootDictionary { get; set; }

        public PropertyDataTraversalVisitor()
        {
        }

        public void Visit(TreeNode<PropertyData> node)
        {
            if (node.IsRootNode)
            {
                RootDictionary = new ExpandoObject();
                _currentDict = RootDictionary;

                foreach (var child in node.Children)
                    child.Accept(this);
            }
            else if (node.IsLeafNode)
            {
                var kvp = GetKVPFromPropertyLeafNode(node);
                _currentDict.Add(kvp);
            }
            else
            {
                // If not a leaf node, it must be DataModel or DataModelCollection
                var nodeValue = node.Value;
                if (nodeValue.IsDataModel)
                {
                    var propertyName = node.Value.PropertyInfo.Name;
                    var propertyValue = new ExpandoObject();

                    _currentDict.Add(propertyName, propertyValue);
                    _currentDict = propertyValue;

                    foreach (var child in node.Children)
                        child.Accept(this);
                }
                else if (nodeValue.IsDataModelCollection)
                {
                    var propertyName = node.Value.PropertyInfo.Name;
                    var propertyValueList = new List<ExpandoObject>();

                    _currentDict.Add(propertyName, propertyValueList);
                    // Visit child node for each item in value of object
                    // Get collection type from 
                    //var propEnumerables = nodeValue.Type.GetInterfaces().Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEnumerable<>));
                    //var genericType = propEnumerables.Where(
                    //    i => i.GetGenericArguments().Count() == 1
                    //    && i.GetGenericArguments().Any(a => typeof(IDataModel).IsAssignableFrom(a))
                    //    ).SelectMany(x => x.GetGenericArguments()).FirstOrDefault();

                    foreach (var item in nodeValue.Object as IEnumerable<object>)
                    {
                        var itemValue = new ExpandoObject();
                        propertyValueList.Add(itemValue);
                        _currentDict = itemValue;

                        // Visit children to get property values
                        foreach (var child in node.Children)
                            child.Accept(this);

                    }

                }
            }
        }

        private static KeyValuePair<string, object> GetKVPFromPropertyLeafNode(TreeNode<PropertyData> node)
        {
            var propertyData = node.Value;
            var propertyName = propertyData.PropertyInfo.Name;

            if (propertyData.Type != null)
            {
                var name = propertyData?.PropertyInfo?.Name ?? "(unnamed)";
                Console.WriteLine($"Called GetKVPFromProperty for {name}");

                if (propertyData.IsDataModel)
                {
                    // Get all properties of the dataModel
                    var dataModelProperties = new ExpandoObject();
                    // for each property, add key value pair
                    //foreach (var property in propertyData.PropertyInfo)
                    //{
                    //    dataModelProperties.Add(kvpfromproperty(property))
                    //}
                    // return collection
                    return new KeyValuePair<string, object>(propertyName, dataModelProperties);
                }
                else if (propertyData.IsDataModelCollection)
                {
                    var dataModelCollection = new List<ExpandoObject>();

                    // for each item get property collection
                    //foreach (var item in propertyData)
                    //{
                    // Get all properties of the dataModel
                    var propertyCollection = new ExpandoObject();
                    // for each property, add key value pair
                    //foreach (var property in propertyData.PropertyInfo)
                    //{
                    //    dataModelProperties.Add(kvpfromproperty(property))
                    //}
                    dataModelCollection.Add(propertyCollection);
                    //}
                    // Get array of all properties of all items in the collection
                    return new KeyValuePair<string, object>(propertyName, dataModelCollection);
                }
                else
                {
                    if (node.Parent.Value.IsDataModelCollection) 
                    {
                        
                    }
                    else 
                    {
                        // Get this property
                        return new KeyValuePair<string, object>(propertyName, propertyData.Object);
                    }
                }
            }

            return new KeyValuePair<string, object>();
        }
    }
}
