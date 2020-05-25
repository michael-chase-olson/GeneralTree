using GeneralTree.Interfaces;

namespace GeneralTree.Visitors
{
    public class SearchByNodeIdVisitor<T> : IVisitor
    {
        public int SearchId { get; set; }
        public INode<T> FoundNode { get; private set; }
        public void Visit(IVisitable element)
        {
            if(!(element is INode<T> node))
                return;

            if (node.Id == SearchId)
                FoundNode = node;
        }
    }
}