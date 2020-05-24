using GeneralTree.Interfaces;

namespace GeneralTree
{
    public class GeneralTree<T> : IGeneralTree<T>
    {
        public INode<T> RootNode { get; set; }
    }
}