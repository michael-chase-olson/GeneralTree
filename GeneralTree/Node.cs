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
        public IEnumerable<INode<T>> Children { get; set; }
    }
}