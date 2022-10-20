using System;
using System.Collections.Generic;
using System.Dynamic;
using PlantDataMVC.WebApiCore.Helpers;

namespace PlantDataMVC.WebApiCore.Classes
{
    public class PropertyDataTraversalVisitor : TraversalVisitor<PropertyData>
    {
        private IDictionary<string, object> _currentDict = null;

        public IDictionary<string, object> RootDictionary { get; set; }

        public PropertyDataTraversalVisitor(TraversalMode mode) : base(mode)
        {
        }

        public override void VisitAction(TreeNode<PropertyData> node)
        {
            if (node.IsRootNode)
            {
                ExpandoObject o = new ExpandoObject();
                RootDictionary = o;
                _currentDict = RootDictionary;
            }

            if (node.IsLeafNode)
            {
                var kvp = GetKVPFromPropertyLeafNode(node.Value);
                _currentDict.Add(kvp);
            }
        }

        private static KeyValuePair<string, object> GetKVPFromPropertyLeafNode(PropertyData propertyData)
        {
            if (propertyData.Type != null)
            {
                var name = propertyData?.PropertyInfo?.Name ?? "(unnamed)";
                Console.WriteLine($"Called GetKVPFromProperty for {name}");

                if (propertyData.IsDto)
                {
                    // Get all properties of the dto
                    var dtoProperties = new ExpandoObject();
                    // for each property, add key value pair
                    //foreach (var property in propertyData.PropertyInfo)
                    //{
                    //    dtoProperties.Add(kvpfromproperty(property))
                    //}
                    // return collection
                    return new KeyValuePair<string, object>(propertyData.PropertyInfo.Name, dtoProperties);
                }
                else if (propertyData.IsDtoCollection)
                {
                    var dtoCollection = new List<ExpandoObject>();

                    // for each item get property collection
                    //foreach (var item in propertyData)
                    //{
                    // Get all properties of the dto
                    var propertyCollection = new ExpandoObject();
                    // for each property, add key value pair
                    //foreach (var property in propertyData.PropertyInfo)
                    //{
                    //    dtoProperties.Add(kvpfromproperty(property))
                    //}
                    dtoCollection.Add(propertyCollection);
                    //}
                    // Get array of all properties of all items in the collection
                    return new KeyValuePair<string, object>(propertyData.PropertyInfo.Name, dtoCollection);
                }
                else
                {
                    // Get this property
                    return new KeyValuePair<string, object>(propertyData.PropertyInfo.Name, propertyData.Object);
                }
            }

            return new KeyValuePair<string, object>();
        }
    }
}
