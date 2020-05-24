using System.Collections.Generic;
using System.Linq;
using GeneralTree.Interfaces;

namespace GeneralTree.TraversalStrategies
{
    public class PreorderTraversalStrategy : ITraversalStrategy
    {
        public void Traverse<T>(IGeneralTree<T> tree, IVisitor visitor)
        {
            if(!tree.RootNode.Children.Any())
            {
                tree.RootNode.Accept(visitor);
                return;
            }

            var nodeStack = new Stack<INode<T>>();

            nodeStack.Push(tree.RootNode);

            while (nodeStack.Any())
            {
                var node = nodeStack.Pop();
                node.Accept(visitor);

                foreach (var nodeChild in node.Children.Reverse())
                {
                    nodeStack.Push(nodeChild);
                }
            }
        }
    }
}