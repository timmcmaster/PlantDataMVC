namespace PlantDataMVC.Api.Classes
{
    public abstract class TraversalVisitor<T> : ITreeVisitor<T>
    {
        private TraversalMode _mode;

        public TraversalVisitor(TraversalMode mode)
        {
            _mode = mode;
        }

        public void Visit(TreeNode<T> node)
        {
            if (_mode == TraversalMode.Preorder)
                VisitAction(node);

            foreach (var child in node.Children)
                child.Accept(this);

            if (_mode == TraversalMode.Postorder)
                VisitAction(node);
        }

        public abstract void VisitAction(TreeNode<T> node);
    }
}
