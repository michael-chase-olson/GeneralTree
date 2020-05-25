using GeneralTree.TraversalStrategies;

namespace GeneralTree.Interfaces
{
    public interface ISearchableTree<T>
    {
        INode<T> TrySearchById(int id);
    }
}