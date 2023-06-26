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

        public void Visit(TreeNode<T> node)
        {
            if (node.IsRootNode)
            {
                var dataValue = _transformFunction(node, null);
                CloneRoot = new TreeNode<U>(dataValue);
                _currentParent = CloneRoot;
            }
            else
            {
                var dataValue = _transformFunction(node, _currentParent);
                _currentParent = _currentParent.AddChild(dataValue);
            }

            foreach (var sourceChild in node.Children)
            {
                sourceChild.Accept(this);
            }

            _currentParent = _currentParent.Parent;
        }


    }
}
