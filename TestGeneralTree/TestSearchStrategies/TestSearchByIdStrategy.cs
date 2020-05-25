﻿using System.Collections.Generic;
using GeneralTree;
using GeneralTree.Interfaces;
using GeneralTree.SearchStrategies;
using GeneralTree.TraversalStrategies;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestGeneralTree.TestSearchStrategies
{
    [TestClass]
    public class TestSearchByIdStrategy
    {
        [TestMethod]
        public void Test_TrySearch_Traverser_Was_Traversed()
        {
            var searchStrategy = new SearchByIdStrategy();
            var traverser = new MockTraverser();

            searchStrategy.TrySearch(new GeneralTree<object>(), 1, traverser);

            Assert.IsTrue(traverser.WasTraversed);
        }

        [TestMethod]
        public void Test_TrySearch_SearchId_Not_In_Tree_Returns_Null()
        {
            var tree = BuildTreeForTest();
            var traverser = new LevelorderTraversalStrategy();

            var searchStrategy = new SearchByIdStrategy();
            var result = searchStrategy.TrySearch(tree, 22, traverser);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void Test_TrySearch_SearchId_In_Tree_Returns_Corresponding_Node()
        {
            var tree = BuildTreeForTest();
            var traverser = new LevelorderTraversalStrategy();

            var searchStrategy = new SearchByIdStrategy();
            var result = searchStrategy.TrySearch(tree, 5, traverser);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Id == 5);
        }

        private IGeneralTree<object> BuildTreeForTest()
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

            return new GeneralTree<object>
            {
                RootNode = rootNode
            };
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

        private class MockTraverser : ITraversalStrategy
        {
            public bool WasTraversed { get; set; }
            public void Traverse<T>(IGeneralTree<T> tree, IVisitor visitor)
            {
                WasTraversed = true;
            }
        }
    }
}