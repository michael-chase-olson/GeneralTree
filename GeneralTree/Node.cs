using System.Collections.Generic;
using GeneralTree.Interfaces;

namespace GeneralTree
{
    public class Node<T> : INode<T>
    {
        public Node()
        {
            Children = new List<INode<T>>();
        }

        public int Id { get; set; }
        public T Payload { get; set; }
        public INode<T> Parent { get; set; }
        public IList<INode<T>> Children { get; set; }
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}