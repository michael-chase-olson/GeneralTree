namespace GeneralTree.Interfaces
{
    public interface IGeneralTree<T>
    {
        INode<T> RootNode { get; set; }
    }
}