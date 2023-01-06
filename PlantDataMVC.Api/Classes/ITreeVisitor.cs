namespace PlantDataMVC.Api.Classes
{
    public interface ITreeVisitor<T>
    {
        void Visit(TreeNode<T> node);
    }
}
