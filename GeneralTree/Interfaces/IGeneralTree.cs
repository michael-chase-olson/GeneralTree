namespace GeneralTree.Interfaces
{
    public interface IGeneralTree<T> : ISearchableTree<T>
    {
        INode<T> RootNode { get; set; }
    }
}