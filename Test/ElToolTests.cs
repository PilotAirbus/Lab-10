using ToolLibrary;

namespace ToolLibraryTests
{
    [TestClass]
    public class ElToolTests
    {
        [TestMethod]
        public void TestElToolConstructor1()
        {
            var tool = new ElTool();
            Assert.AreEqual("аккумул€тор", tool.Supply);
            Assert.AreEqual(60, tool.SupplyTime);
            Assert.AreEqual("перфоратор", tool.Name); //ѕровер€ем унаследованное свойство
            Assert.AreEqual(0, tool.ID.Number); //ѕровер€ем унаследованное свойство
        }

        [TestMethod]
        public void TestElToolConstructor2()
        {
            var tool = new ElTool("дрель", "розетка", 60, 123);
            Assert.AreEqual("розетка", tool.Supply);
            Assert.AreEqual(60, tool.SupplyTime);
            Assert.AreEqual("дрель", tool.Name);
            Assert.AreEqual(123, tool.ID.Number);
        }

        [TestMethod]
        public void TestElToolConstructor3()
        {
            var tool1 = new ElTool("пилка", "аккумул€тор", 90, 456);
            var tool2 = new ElTool(tool1);
            Assert.AreEqual(tool1.Supply, tool2.Supply);
            Assert.AreEqual(tool1.SupplyTime, tool2.SupplyTime);
            Assert.AreEqual(tool1.Name, tool2.Name);
            Assert.AreEqual(tool1.ID.Number, tool2.ID.Number);
        }

        [TestMethod]
        public void TestShowMethod()
        {
            var tool = new ElTool("отвертка", "батарейки", 30, 789);
            string result = tool.Show();
            Assert.AreEqual("Ќазвание инструмента - отвертка, тип питани€ - батарейки, врем€ работы аккумул€тора - 30", result);
        } 

        [TestMethod]
        public void TestVirtualShowMethod()
        {
            var tool = new ElTool("кусачки", "солнечна€ батаре€", 120, 10);
            string result = tool.VirtualShow();
            Assert.AreEqual("Ќазвание инструмента - кусачки, тип питани€ - солнечна€ батаре€, врем€ работы аккумул€тора - 120", result);
        }
 
        [TestMethod]
        public void TestEqualsMethod_True()
        {
            var tool1 = new ElTool("лопата", "аккумул€тор", 60, 1);
            var tool2 = new ElTool("лопата", "аккумул€тор", 60, 2);
            Assert.IsTrue(tool1.Equals(tool2));
        }

        [TestMethod]
        public void TestEqualsMethod_False_DifferentName()
        {
            var tool1 = new ElTool("лопата", "аккумул€тор", 60, 1);
            var tool2 = new ElTool("грабли", "аккумул€тор", 60, 1);
            Assert.IsFalse(tool1.Equals(tool2));
        }

        [TestMethod]
        public void TestEqualsMethod_False_DifferentSupply()
        {
            var tool1 = new ElTool("лопата", "аккумул€тор", 60, 1);
            var tool2 = new ElTool("лопата", "розетка", 60, 1);
            Assert.IsFalse(tool1.Equals(tool2));
        }

        [TestMethod]
        public void TestEqualsMethod_False_DifferentSupplyTime()
        {
            var tool1 = new ElTool("лопата", "аккумул€тор", 60, 1);
            var tool2 = new ElTool("лопата", "аккумул€тор", 30, 1);
            Assert.IsFalse(tool1.Equals(tool2));
        }

        [TestMethod]
        public void TestEqualsMethod_Null()
        {
            var tool1 = new ElTool("лопата", "аккумул€тор", 60, 1);
            Assert.IsFalse(tool1.Equals(null));
        }

        [TestMethod]
        public void TestCloneMethod()
        {
            var tool1 = new ElTool("топор", "батаре€", 111, 111);
            var tool2 = (ElTool)tool1.Clone();

            Assert.AreEqual(tool1.Supply, tool2.Supply);
            Assert.AreEqual(tool1.SupplyTime, tool2.SupplyTime);
            Assert.AreEqual(tool1.Name, tool2.Name);
            Assert.AreEqual(tool1.ID.Number, tool2.ID.Number);
        }

        [TestMethod]
        public void TestShallowCopyMethod()
        {
            var tool1 = new ElTool("ножницы", "сеть", 222, 222);
            var tool2 = (ElTool)tool1.ShallowCopy();

            Assert.AreEqual(tool1.Supply, tool2.Supply);
            Assert.AreEqual(tool1.SupplyTime, tool2.SupplyTime);
            Assert.AreEqual(tool1.Name, tool2.Name);
            Assert.AreEqual(tool1.ID.Number, tool2.ID.Number);
        }

        [TestMethod]
        public void ElTool_SetSupplyTime_NegativeValue_ThrowsException()
        {
            // Arrange
            var tool = new ElTool();

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => tool.SupplyTime = -5);
        }

        [TestMethod]
        public void ElTool_SetSupplyTime_PositiveValue_SetsCorrectly()
        {
            // Arrange
            var tool = new ElTool();

            // Act
            tool.SupplyTime = 60;

            // Assert
            Assert.AreEqual(60, tool.SupplyTime);
        }

        [TestMethod]
        public void ElTool_Constructor_ValidValues_CreatesObjectCorrectly()
        {
            // Arrange
            // Act
            var tool = new ElTool("TestTool", "Battery", 60, 1);

            // Assert
            Assert.AreEqual("TestTool", tool.Name);
            Assert.AreEqual("Battery", tool.Supply);
            Assert.AreEqual(60, tool.SupplyTime);
            Assert.AreEqual(1, tool.ID.Number);
        }

        [TestMethod]
        public void ElTool_CopyConstructor_ValidValues_CreatesObjectCorrectly()
        {
            // Arrange
            var originalTool = new ElTool("OriginalTool", "Battery", 120, 2);

            // Act
            var copiedTool = new ElTool(originalTool);

            // Assert
            Assert.AreEqual("OriginalTool", copiedTool.Name);
            Assert.AreEqual("Battery", copiedTool.Supply);
            Assert.AreEqual(120, copiedTool.SupplyTime);
            Assert.AreEqual(2, copiedTool.ID.Number);
        }

        [TestMethod]
        public void ElTool_DefaultConstructor_CreatesObjectWithDefaults()
        {
            // Arrange
            // Act
            var tool = new ElTool();

            // Assert
            Assert.AreEqual("аккумул€тор", tool.Supply);
            Assert.AreEqual(60, tool.SupplyTime);
        }
    }
}

