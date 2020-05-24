using System.Collections.Generic;
using System.Linq;
using GeneralTree;
using GeneralTree.Interfaces;
using GeneralTree.TraversalStrategies;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestGeneralTree.TestTraversalStrategies
{
    [TestClass]
    public class TestLevelorderTraversalStrategy
    {
        private GeneralTree<object> _tree;
        private MockVisitor _visitor;

        [TestInitialize]
        public void TestInit()
        {
            _tree = new GeneralTree<object>();
            _visitor = new MockVisitor();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _tree = null;
            _visitor = null;
        }

        [TestMethod]
        public void Test_Traverse_RootNode_Has_No_Children_RootNode_Visited()
        {
            var rootNode = new MockNode();
            _tree.RootNode = rootNode;

            var traverser = new LevelorderTraversalStrategy();
            traverser.Traverse<object>(_tree, _visitor);

            Assert.IsTrue(rootNode.WasVisisted);
            Assert.IsTrue(_visitor.NodesVisited.Count == 1);
        }

        [TestMethod]
        public void Test_Traverse_RootNode_Has_Children_Tree_Visited_In_Preorder_Order()
        {
            //Preorder pattern is 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11

            var expected = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10,11};

            BuildTreeForTest();

            var traverser = new LevelorderTraversalStrategy();
            traverser.Traverse<object>(_tree, _visitor);

            Assert.IsTrue(_visitor.NodesVisited.SequenceEqual(expected));
        }

        private void BuildTreeForTest()
        {
            //               1
            //             /\  \
            //            2  3  4
            //           /\  /\  \
            //          5 6  7 8  9
            //         /           \
            //        10            11

            var rootNode = new MockNode { Id = 1 };
            var nodeFour = new MockNode
            {
                Id = 4,
                Parent = rootNode
            };

            var nodeThree = new MockNode
            {
                Id = 3,
                Parent = rootNode
            };

            var nodeTwo = new MockNode
            {
                Id = 2,
                Parent = rootNode
            };
            var nodeSix = new MockNode
            {
                Id = 6,
                Parent = nodeTwo
            };
            var nodeTen = new MockNode
            {
                Id = 10,
                Parent = nodeSix
            };
            var nodeNine = new MockNode
            {
                Id = 9,
                Parent = nodeFour
            };
            var nodeEight = new MockNode
            {
                Id = 8,
                Parent = nodeThree
            };
            var nodeSeven = new MockNode
            {
                Id = 7,
                Parent = nodeThree
            };

            var nodeFive = new MockNode
            {
                Id = 5,
                Parent = nodeTwo
            };
            var nodeEleven = new MockNode
            {
                Id = 11,
                Parent = nodeNine
            };

            nodeFive.Children.Add(nodeTen);
            nodeTwo.Children.Add(nodeFive);
            nodeTwo.Children.Add(nodeSix);
            nodeThree.Children.Add(nodeSeven);
            nodeThree.Children.Add(nodeEight);
            nodeFour.Children.Add(nodeNine);
            nodeNine.Children.Add(nodeEleven);
            rootNode.Children.Add(nodeTwo);
            rootNode.Children.Add(nodeThree);
            rootNode.Children.Add(nodeFour);

            _tree.RootNode = rootNode;
        }

        private class MockNode : INode<object>
        {
            public MockNode()
            {
                Children = new List<INode<object>>();
            }

            public bool WasVisisted { get; set; }
            public void Accept(IVisitor visitor)
            {
                visitor.Visit(this);
            }

            public int Id { get; set; }
            public object Payload { get; set; }
            public INode<object> Parent { get; set; }
            public IList<INode<object>> Children { get; set; }
        }

        private class MockVisitor : IVisitor
        {
            public List<int> NodesVisited { get; set; } = new List<int>();

            public void Visit(IVisitable element)
            {
                var mockNode = (MockNode)element;

                mockNode.WasVisisted = true;
                NodesVisited.Add(mockNode.Id);
            }
        }
    }
}