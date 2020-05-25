using System;
using System.Collections.Generic;
using GeneralTree.Interfaces;
using GeneralTree.Visitors;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestGeneralTree.TestVisitors
{
    [TestClass]
    public class TestSearchByNodeIdVisitor
    {
        [TestMethod]
        public void Test_Visit_Element_Is_Not_Node_FoundNode_Is_Null()
        {
            var visitor = new SearchByNodeIdVisitor<object> {SearchId = 1};
            visitor.Visit(new MockVisitable());

            Assert.IsNull(visitor.FoundNode);
        }

        [TestMethod]
        public void Test_Visit_Element_Is_Node_Element_Id_Is_Not_SearchId_FoundNode_Is_Null()
        {
            var mockElement = new MockNode<object>
            {
                Id = 2
            };

            var visitor = new SearchByNodeIdVisitor<object> {SearchId = 1};
            visitor.Visit(mockElement);

            Assert.IsNull(visitor.FoundNode);
        }

        [TestMethod]
        public void Test_Visit_Element_Is_Node_Element_Id_Is_SearchId_FoundNode_Is_Element()
        {
            var mockElement = new MockNode<object>
            {
                Id = 1
            };

            var visitor = new SearchByNodeIdVisitor<object> {SearchId = 1};
            visitor.Visit(mockElement);

            Assert.IsNotNull(visitor.FoundNode);
            Assert.IsTrue(visitor.FoundNode.Id == 1);
        }

        private class MockVisitable : IVisitable
        {
            
            public void Accept(IVisitor visitor)
            {
                
            }
        }

        private class MockNode<T> : INode<T>
        {
            public MockNode()
            {
                Children = new List<INode<T>>();
            }

            public int Id { get; set; }
            public T Payload { get; set; }
            public INode<T> Parent { get; set; }
            public IList<INode<T>> Children { get; set; }
            public void Accept(IVisitor visitor)
            {
                
            }
        }
    }
}