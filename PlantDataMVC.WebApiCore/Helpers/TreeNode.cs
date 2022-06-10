using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PlantDataMVC.WebApiCore.Helpers
{
    public enum TraversalMode
    {
        Preorder = 0,
        Inorder
    }

    public class TreeNode<T>
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

        public TreeNode<T> Parent { get; private set; }

        public T Value { get { return _value; } }

        public ReadOnlyCollection<TreeNode<T>> Children
        {
            get { return _children.AsReadOnly(); }
        }

        public bool IsLeafNode => Children.Count == 0;


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


        // Preorder traversal = Parent first, Inorder = children first
        public void Traverse(TraversalMode mode, Action<T> action)
        {
            if (mode == TraversalMode.Preorder)
                action(Value);

            foreach (var child in _children)
                child.Traverse(mode, action);

            if (mode == TraversalMode.Inorder)
                action(Value);
        }

        public TreeNode<T> Clone()
        {
            var clone = CloneChildren(new TreeNode<T>(Value));

            return clone;
        }

        private TreeNode<T> CloneChildren(TreeNode<T> cloneTo)
        {
            foreach (var child in _children)
            {
                var newChild = cloneTo.AddChild(child.Value);
                if (!child.IsLeafNode)
                {
                    child.CloneChildren(newChild);
                }
            }

            return cloneTo;
        }

        public TreeNode<U> CloneAndTransform<U>(Func<T, TreeNode<U>, U> dataFunction)
        {
            var clone = CloneAndTransformChildren(new TreeNode<U>(dataFunction(Value, null)), dataFunction);

            return clone;
        }

        private TreeNode<U> CloneAndTransformChildren<U>(TreeNode<U> cloneTo, Func<T, TreeNode<U>, U> dataFunction)
        {
            foreach (var child in _children)
            {
                var newChild = cloneTo.AddChild(dataFunction(Value, cloneTo));
                if (!child.IsLeafNode)
                {
                    child.CloneAndTransformChildren(newChild, dataFunction);
                }
            }

            return cloneTo;
        }

        public IEnumerable<T> Flatten()
        {
            return new[] { Value }.Concat(_children.SelectMany(x => x.Flatten()));
        }
    }
}
