using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Linq;
using PlantDataMVC.Api.Helpers;

namespace PlantDataMVC.Api.Classes
{
    public class TreeNode<T> : ITreeNode<T>
    {
        private readonly T _value;
        private readonly List<TreeNode<T>> _children = new List<TreeNode<T>>();

        public TreeNode(T value)
        {
            _value = value;
        }

        public TreeNode<T> this[int i]
        {
            get { return _children[i]; }
        }

        #region Properties
        public TreeNode<T> Parent { get; private set; }

        public T Value { get { return _value; } }

        public ReadOnlyCollection<TreeNode<T>> Children
        {
            get { return _children.AsReadOnly(); }
        }
        #endregion

        #region Methods
        public bool IsLeafNode => Children.Count == 0;

        public bool IsRootNode => Parent == null;

        public void Accept(ITreeVisitor<T> visitor)
        {
            visitor.Visit(this);
        }

        public TreeNode<T> AddChild(T value)
        {
            var node = new TreeNode<T>(value) { Parent = this };
            _children.Add(node);
            return node;
        }

        public TreeNode<T>[] AddChildren(params T[] values)
        {
            return values.Select(AddChild).ToArray();
        }

        public bool RemoveChild(TreeNode<T> node)
        {
            return _children.Remove(node);
        }


        public object TraverseWithObject(Func<T, KeyValuePair<string, object>> propertyFunc)
        {
            // HACK: check type to get name/info to identify node
            var propData = Value as PropertyData;
            var name = propData?.PropertyInfo?.Name ?? "(unnamed)";

            Console.WriteLine($"Called TraverseWithObject {name}");

            ExpandoObject o = new ExpandoObject();

            foreach (var child in _children)
            {
                var childObj = child.TraverseWithObject(propertyFunc);
                bool x = true;
            }

            var myKvp = propertyFunc(Value);

            ((IDictionary<string, object>)o).Add(myKvp);

            return o;
        }


        public IEnumerable<T> Flatten()
        {
            return new[] { Value }.Concat(_children.SelectMany(x => x.Flatten()));
        }
        #endregion
    }
}
