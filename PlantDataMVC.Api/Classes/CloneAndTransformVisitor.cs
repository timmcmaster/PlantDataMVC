using System;

namespace PlantDataMVC.Api.Classes
{
    public class CloneAndTransformVisitor<T, U> : ITreeVisitor<T>
    {
        private TreeNode<U> _currentParent;

        public TreeNode<U> CloneRoot { get; set; }

        private Func<TreeNode<T>, TreeNode<U>, U> _transformFunction;

        public CloneAndTransformVisitor(Func<TreeNode<T>, TreeNode<U>, U> transformFunction)
        {
            _transformFunction = transformFunction;
        }

        public void Visit(TreeNode<T> sourceNode)
        {
            if (sourceNode.IsRootNode)
            {
                var dataValue = _transformFunction(sourceNode, null);
                CloneRoot = new TreeNode<U>(dataValue);
                _currentParent = CloneRoot;
            }
            else
            {
                var dataValue = _transformFunction(sourceNode, _currentParent);
                _currentParent = _currentParent.AddChild(dataValue);
            }

            foreach (var sourceChild in sourceNode.Children)
            {
                sourceChild.Accept(this);
            }

            _currentParent = _currentParent.Parent;
        }


    }
}
