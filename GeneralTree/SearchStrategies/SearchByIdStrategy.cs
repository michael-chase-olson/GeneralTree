using GeneralTree.Interfaces;
using GeneralTree.TraversalStrategies;
using GeneralTree.Visitors;

namespace GeneralTree.SearchStrategies
{
    public class SearchByIdStrategy : ISearchByIdStrategy
    {
        public INode<T> TrySearch<T>(IGeneralTree<T> tree, int nodeId, ITraversalStrategy traverser)
        {
            var searchVisitor = new SearchByNodeIdVisitor<T>
            {
                SearchId = nodeId
            };

            traverser.Traverse(tree, searchVisitor);

            return searchVisitor.FoundNode;
        }
    }
}