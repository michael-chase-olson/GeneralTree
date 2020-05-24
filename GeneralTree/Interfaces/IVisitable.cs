namespace GeneralTree.Interfaces
{
    public interface IVisitable
    {
        void Accept(IVisitor visitor);
    }
}