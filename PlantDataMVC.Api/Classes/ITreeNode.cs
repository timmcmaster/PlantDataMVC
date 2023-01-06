namespace PlantDataMVC.Api.Classes
{
    public interface ITreeNode<T>
    {
        void Accept(ITreeVisitor<T> visitor);
    }

}
