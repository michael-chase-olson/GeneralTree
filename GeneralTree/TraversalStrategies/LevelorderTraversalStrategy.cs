using System.Collections.Generic;
using System.Linq;
using GeneralTree.Interfaces;

namespace GeneralTree.TraversalStrategies
{
    public class LevelorderTraversalStrategy : ITraversalStrategy
    {
        public void Traverse<T>(IGeneralTree<T> tree, IVisitor visitor)
        {
            if (!tree.RootNode.Children.Any())
            {
                tree.RootNode.Accept(visitor);
                return;
            }

            var nodeQueue = new Queue<INode<T>>();

            nodeQueue.Enqueue(tree.RootNode);

            while (nodeQueue.Any())
            {
                var node = nodeQueue.Dequeue();
                node.Accept(visitor);

                foreach (var nodeChild in node.Children)
                {
                    nodeQueue.Enqueue(nodeChild);
                }
            }
        }
    }
}