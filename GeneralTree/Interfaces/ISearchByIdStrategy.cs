using GeneralTree.TraversalStrategies;

namespace GeneralTree.Interfaces
{
    public interface ISearchByIdStrategy
    {
        INode<T> TrySearch<T>(IGeneralTree<T> tree, int nodeId, ITraversalStrategy traverser);
    }
}