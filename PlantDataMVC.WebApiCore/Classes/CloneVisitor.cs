namespace PlantDataMVC.WebApiCore.Classes
{
    public class CloneVisitor<T> : ITreeVisitor<T>
    {
        private TreeNode<T> _currentParent = null;

        public TreeNode<T> CloneRoot { get; set; } = null;

        public CloneVisitor()
        {

        }

        public void Visit(TreeNode<T> sourceNode)
        {
            if (sourceNode.IsRootNode)
            {
                CloneRoot = new TreeNode<T>(sourceNode.Value);
                _currentParent = CloneRoot;
            }
            else
            {
                _currentParent = _currentParent.AddChild(sourceNode.Value);
            }

            foreach (var sourceChild in sourceNode.Children)
            {
                sourceChild.Accept(this);
            }

            _currentParent = _currentParent.Parent;
        }
    }
}
