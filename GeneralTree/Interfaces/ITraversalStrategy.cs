namespace GeneralTree.Interfaces
{
    public interface ITraversalStrategy
    {
        void Traverse<T>(IGeneralTree<T> tree, IVisitor visitor);
    }
}