using System.Collections.Generic;

namespace PlantDataMVC.Api.Classes
{
    public class StringTraversalVisitor : ITreeVisitor<string>
    {
        private TraversalMode _mode;
        private List<string> _traversalList = new List<string>();

        public StringTraversalVisitor(TraversalMode mode)
        {
            _mode = mode;
        }

        public void Visit(TreeNode<string> node)
        {
            if (_mode == TraversalMode.Preorder)
                VisitAction(node);
            
            for (int i = 0; i < node.Children.Count; i++)
            {
                // '[' indicates next depth down 
                if (i == 0) _traversalList.Add("[");

                node.Children[i].Accept(this);

                if (i < node.Children.Count - 1) _traversalList.Add(",");

                // ']' indicates next depth up 
                if (i == node.Children.Count - 1) _traversalList.Add("]");
            }

            if (_mode == TraversalMode.Postorder)
                VisitAction(node);
        }

        public void VisitAction(TreeNode<string> node)
        {
            _traversalList.Add(node.Value);
        }

        public string TraversalString => string.Join("", _traversalList);
    }
}
