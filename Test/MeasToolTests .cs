namespace ToolLibrary.Tests
{
    [TestClass]
    public class MeasToolTests
    {
        [TestMethod]
        public void MeasTool_Constructor_ValidValues_CreatesObjectCorrectly()
        {
            // Arrange
            // Act
            var tool = new MeasTool("TestTool", "cm", 0.1, 1);

            // Assert
            Assert.AreEqual("TestTool", tool.Name);
            Assert.AreEqual("cm", tool.Units);
            Assert.AreEqual(0.1, tool.Accuracy);
            Assert.AreEqual(1, tool.ID.Number);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MeasTool_Constructor_NegativeAccuracy_ThrowsException()
        {
            // Arrange
            // Act
            new MeasTool("TestTool", "cm", -0.1, 1);
            // Assert - Exception is expected
        }

        [TestMethod]
        public void MeasTool_SetAccuracy_NegativeValue_ThrowsException()
        {
            // Arrange
            var tool = new MeasTool();

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => tool.Accuracy = -0.5);
        }

        [TestMethod]
        public void MeasTool_SetAccuracy_PositiveValue_SetsCorrectly()
        {
            // Arrange
            var tool = new MeasTool();

            // Act
            tool.Accuracy = 0.05;

            // Assert
            Assert.AreEqual(0.05, tool.Accuracy);
        }

        [TestMethod]
        public void MeasTool_DefaultConstructor_CreatesObjectWithDefaults()
        {
            // Arrange
            // Act
            var tool = new MeasTool();

            // Assert
            Assert.AreEqual("мм", tool.Units);
            Assert.AreEqual(0.01, tool.Accuracy);
        }

        [TestMethod]
        public void MeasTool_CopyConstructor_ValidValues_CreatesObjectCorrectly()
        {
            // Arrange
            var originalTool = new MeasTool("OriginalTool", "kg", 0.001, 2);

            // Act
            var copiedTool = new MeasTool(originalTool);

            // Assert
            Assert.AreEqual("OriginalTool", copiedTool.Name);
            Assert.AreEqual("kg", copiedTool.Units);
            Assert.AreEqual(0.001, copiedTool.Accuracy);
            Assert.AreEqual(2, copiedTool.ID.Number);
        }


        [TestMethod]
        public void MeasTool_Show_ReturnsCorrectString()
        {
            // Arrange
            var tool = new MeasTool("MyTool", "inches", 0.02, 3);

            // Act
            string result = tool.Show();

            // Assert
            Assert.AreEqual("Ќазвание инструмента - MyTool, единицы измерени€ - inches, точность измерени€ - 0,02", result);
        }


        [TestMethod]
        public void MeasTool_VirtualShow_ReturnsCorrectString()
        {
            // Arrange
            var tool = new MeasTool("AnotherTool", "meters", 0.1, 4);
            tool.ID.Number = 42; // Set ID for testing

            // Act
            string result = tool.VirtualShow();

            // Assert
            Assert.AreEqual($"Ќазвание инструмента - AnotherTool, единицы измерени€ - meters, точность измерени€ - 0,1", result);
        }

        [TestMethod]
        public void MeasTool_Equals_SameObject_ReturnsTrue()
        {
            // Arrange
            var tool1 = new MeasTool("ToolA", "mm", 0.01, 1);

            // Act
            bool result = tool1.Equals(tool1);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void MeasTool_Equals_DifferentObjects_ReturnsFalse()
        {
            // Arrange
            var tool1 = new MeasTool("ToolA", "mm", 0.01, 1);
            var tool2 = new MeasTool("ToolB", "cm", 0.1, 2);

            // Act
            bool result = tool1.Equals(tool2);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void MeasTool_Equals_IdenticalObjects_ReturnsTrue()
        {
            // Arrange
            var tool1 = new MeasTool("ToolC", "m", 0.001, 3);
            var tool2 = new MeasTool("ToolC", "m", 0.001, 3);

            // Act
            bool result = tool1.Equals(tool2);

            // Assert
            Assert.IsTrue(result);
        }


        [TestMethod]
        public void MeasTool_Clone_CreatesDeepClone()
        {
            // Arrange
            var originalTool = new MeasTool("ToolD", "km", 1, 4);

            // Act
            var clonedTool = (MeasTool)originalTool.Clone();

            // Assert - Check if it's a deep clone.  Modifying one shouldn't affect the other.
            clonedTool.Name = "ClonedTool";
            Assert.AreNotEqual(originalTool.Name, clonedTool.Name);
        }


        [TestMethod]
        public void MeasTool_ShallowCopy_CreatesShallowCopy()
        {
            // Arrange
            var originalTool = new MeasTool("ToolE", "mm", 0.01, 5);

            // Act
            var shallowCopy = (MeasTool)originalTool.ShallowCopy();

            // Assert
            Assert.AreEqual("ToolE", shallowCopy.Name);
        }

        [TestMethod]
        public void MeasTool_Equals()
        {
            // Arrange
            var originalTool = new MeasTool("ToolE", "mm", 0.01, 5);
            MeasTool tool = null;

            // Act
            bool isSame = originalTool.Equals(tool);

            // Assert
            Assert.AreEqual(isSame, false);
        }
    }
}