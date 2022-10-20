namespace PlantDataMVC.WebApiCore.Classes
{
    public interface ITreeNode<T>
    {
        void Accept(ITreeVisitor<T> visitor);
    }

}
