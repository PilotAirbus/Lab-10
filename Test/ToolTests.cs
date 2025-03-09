using ToolLibrary;

namespace ToolLibraryTests
{
    [TestClass]
    public class ToolTests
    {
        [TestMethod]
        public void TestToolConstructor1()
        {
            var tool = new Tool();
            Assert.AreEqual("перфоратор", tool.Name);
            Assert.AreEqual(0, tool.ID.Number);
        }

        [TestMethod]
        public void TestToolConstructor2()
        {
            var tool = new Tool("дрель", 123);
            Assert.AreEqual("дрель", tool.Name);
            Assert.AreEqual(123, tool.ID.Number);
        }

        [TestMethod]
        public void TestToolConstructor3()
        {
            var tool1 = new Tool("отбойный молоток", 456);
            var tool2 = new Tool(tool1);
            Assert.AreEqual(tool1.Name, tool2.Name);
            Assert.AreEqual(tool1.ID.Number, tool2.ID.Number);
        }

        [TestMethod]
        public void TestShowMethod()
        {
            var tool = new Tool("пилка", 789);
            var result = tool.Show();
            Assert.AreEqual("Ќазвание инструмента - пилка, ID объекта: 789", result);
        }

        [TestMethod]
        public void TestVirtualShowMethod()
        {
            var tool = new Tool("молоток", 10);
            var result = tool.VirtualShow();
            Assert.AreEqual("Ќазвание инструмента - молоток", result);
        }

        [TestMethod]
        public void TestNameLengthProperty()
        {
            var tool = new Tool("шуруповерт", 1);
            Assert.AreEqual(10, tool.NameLength);
        }

        [TestMethod]
        public void TestEqualsMethod_True()
        {
            var tool1 = new Tool("дрель", 1);
            var tool2 = new Tool("дрель", 1);
            Assert.IsTrue(tool1.Equals(tool2));
        }

        [TestMethod]
        public void TestEqualsMethod_False_DifferentName()
        {
            var tool1 = new Tool("дрель", 1);
            var tool2 = new Tool("отвертка", 1);
            Assert.IsFalse(tool1.Equals(tool2));
        }

        [TestMethod]
        public void TestEqualsMethod_False_DifferentID()
        {
            var tool1 = new Tool("дрель", 1);
            var tool2 = new Tool("дрель", 2);
            Assert.IsFalse(tool1.Equals(tool2));
        }

        [TestMethod]
        public void TestEqualsMethod_Null()
        {
            var tool1 = new Tool("дрель", 1);
            Assert.IsFalse(tool1.Equals(null));
        }

        [TestMethod]
        public void TestCompareToMethod()
        {
            var tool1 = new Tool("A", 1);
            var tool2 = new Tool("B", 2);
            var tool3 = new Tool("A", 3);

            Assert.AreEqual(-1, tool1.CompareTo(tool2));
            Assert.AreEqual(0, tool1.CompareTo(tool3));
            Assert.AreEqual(1, tool2.CompareTo(tool1));
            Assert.AreEqual(0, tool1.CompareTo(new Tool("A", 1)));
            Assert.AreEqual(-1, tool1.CompareTo(null));
        }

        [TestMethod]
        public void TestCloneMethod()
        {
            var tool1 = new Tool("лопата", 111);
            var tool2 = (Tool)tool1.Clone();

            Assert.AreEqual(tool1.Name, tool2.Name);
            Assert.AreEqual(tool1.ID.Number, tool2.ID.Number);
            Assert.AreNotSame(tool1, tool2);
        }

        [TestMethod]
        public void TestShallowCopyMethod()
        {
            var tool1 = new Tool("пила", 222);
            var tool2 = (Tool)tool1.ShallowCopy();

            Assert.AreEqual(tool1.Name, tool2.Name);
            Assert.AreEqual(tool1.ID.Number, tool2.ID.Number);
        }
    }
}
