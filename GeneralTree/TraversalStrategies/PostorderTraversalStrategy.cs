using System.Collections.Generic;
using System.Linq;
using GeneralTree.Interfaces;

namespace GeneralTree.TraversalStrategies
{
    public class PostorderTraversalStrategy : ITraversalStrategy
    {
        public void Traverse<T>(IGeneralTree<T> tree, IVisitor visitor)
        {
            if (!tree.RootNode.Children.Any())
            {
                tree.RootNode.Accept(visitor);
                return;
            }

            var workingStack = new Stack<INode<T>>();
            var stackForVisit = new Stack<INode<T>>();

            workingStack.Push(tree.RootNode);

            while (workingStack.Any())
            {
                var node = workingStack.Pop();
                stackForVisit.Push(node);

                foreach (var nodeChild in node.Children)
                {
                    workingStack.Push(nodeChild);
                }
            }

            while (stackForVisit.Any())
            {
                var node = stackForVisit.Pop();
                node.Accept(visitor);
            }
        }
    }
}