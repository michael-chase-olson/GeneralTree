using System.Linq;
using GeneralTree;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestGeneralTree
{
    [TestClass]
    public class TestNode
    {
        [TestMethod]
        public void Test_Constructor_Children_Initialized_To_Empty_List()
        {
            var node = new Node<object>();

            Assert.IsFalse(node.Children == null);
            Assert.IsFalse(node.Children.Any());
        }
    }
}