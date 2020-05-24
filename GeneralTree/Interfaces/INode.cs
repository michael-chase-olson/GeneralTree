using System.Collections.Generic;

namespace GeneralTree.Interfaces
{
    public interface INode<T>
    {
        int Id { get; set; }
        T Payload { get; set; }
        INode<T> Parent { get; set; }
        IEnumerable<INode<T>> Children { get; set; }
    }
}