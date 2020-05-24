using System.Collections.Generic;

namespace GeneralTree.Interfaces
{
    public interface INode<T> : IVisitable
    {
        int Id { get; set; }
        T Payload { get; set; }
        INode<T> Parent { get; set; }
        IList<INode<T>> Children { get; set; }
    }
}