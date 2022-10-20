namespace PlantDataMVC.WebApiCore.Classes
{
    public interface ITreeVisitor<T>
    {
        void Visit(TreeNode<T> node);
    }
}
