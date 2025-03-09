using ToolLibrary;

namespace ToolLibraryTests
{
    [TestClass]
    public class HandToolTests
    {
        [TestMethod]
        public void TestHandToolConstructor1()
        {
            var tool = new HandTool();

            Assert.AreEqual("железо", tool.Material);
            Assert.AreEqual("перфоратор", tool.Name);
            Assert.AreEqual(0, tool.ID.Number);
        }

        [TestMethod]
        public void TestHandToolConstructor2()
        {
            var tool = new HandTool("молоток", "дерево", 123);

            Assert.AreEqual("дерево", tool.Material);
            Assert.AreEqual("молоток", tool.Name);
            Assert.AreEqual(123, tool.ID.Number);
        }

        [TestMethod]
        public void TestHandToolConstructor3()
        {
            var tool1 = new HandTool("пилка", "металл", 456);
            var tool2 = new HandTool(tool1);

            Assert.AreEqual(tool1.Material, tool2.Material);
            Assert.AreEqual(tool1.Name, tool2.Name);
            Assert.AreEqual(tool1.ID.Number, tool2.ID.Number);
        }

        [TestMethod]
        public void TestShowMethod()
        {
            var tool = new HandTool("отвертка", "пластик", 789);
            string result = tool.Show();
            Assert.AreEqual("Ќазвание инструмента - отвертка, материал инструмента - пластик", result);
        }

        [TestMethod]
        public void TestVirtualShowMethod()
        {
            var tool = new HandTool("кусачки", "сталь", 10);
            string result = tool.VirtualShow();
            Assert.AreEqual("Ќазвание инструмента - кусачки, материал инструмента - сталь", result);
        }

        [TestMethod]
        public void TestEqualsMethod_True()
        {
            var tool1 = new HandTool("лопата", "железо", 1);
            var tool2 = new HandTool("лопата", "железо", 2); //–азный ID, но должно быть равно
            Assert.IsTrue(tool1.Equals(tool2));
        }

        [TestMethod]
        public void TestEqualsMethod_False_DifferentName()
        {
            var tool1 = new HandTool("лопата", "железо", 1);
            var tool2 = new HandTool("грабли", "железо", 1);
            Assert.IsFalse(tool1.Equals(tool2));
        }

        [TestMethod]
        public void TestEqualsMethod_False_DifferentMaterial()
        {
            var tool1 = new HandTool("лопата", "железо", 1);
            var tool2 = new HandTool("лопата", "дерево", 1);
            Assert.IsFalse(tool1.Equals(tool2));
        }

        [TestMethod]
        public void TestEqualsMethod_Null()
        {
            var tool1 = new HandTool("лопата", "железо", 1);
            Assert.IsFalse(tool1.Equals(null));
        }

        [TestMethod]
        public void TestCloneMethod()
        {
            var tool1 = new HandTool("топор", "сталь", 111);
            var tool2 = (HandTool)tool1.Clone();

            Assert.AreEqual(tool1.Material, tool2.Material);
            Assert.AreEqual(tool1.Name, tool2.Name);
            Assert.AreEqual(tool1.ID.Number, tool2.ID.Number);
        }

        [TestMethod]
        public void TestShallowCopyMethod()
        {
            var tool1 = new HandTool("ножницы", "нержавейка", 222);
            var tool2 = (HandTool)tool1.ShallowCopy();
            Assert.AreEqual(tool1.Material, tool2.Material);
            Assert.AreEqual(tool1.Name, tool2.Name);
            Assert.AreEqual(tool1.ID.Number, tool2.ID.Number);
        }
    }
}

