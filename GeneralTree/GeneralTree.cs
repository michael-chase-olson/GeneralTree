using GeneralTree.Interfaces;
using GeneralTree.SearchStrategies;
using GeneralTree.TraversalStrategies;

namespace GeneralTree
{
    public class GeneralTree<T> : IGeneralTree<T>
    {
        public INode<T> RootNode { get; set; }
        public INode<T> TrySearchById(int id)
        {
            var searchStrategy = new SearchByIdStrategy();
            return searchStrategy.TrySearch(this, id, new LevelorderTraversalStrategy());
        }
    }
}