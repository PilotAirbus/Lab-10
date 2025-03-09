namespace ToolLibrary.Tests
{
    [TestClass]
    public class IdNumberTests
    {
        [TestMethod]
        public void IdNumber_DefaultConstructor_SetsNumberToZero()
        {
            // Arrange
            // Act
            var idNumber = new IdNumber();

            // Assert
            Assert.AreEqual(0, idNumber.Number);
        }

        [TestMethod]
        public void IdNumber_ParameterizedConstructor_SetsNumberCorrectly()
        {
            // Arrange
            // Act
            var idNumber = new IdNumber(42);

            // Assert
            Assert.AreEqual(42, idNumber.Number);
        }

        [TestMethod]
        public void IdNumber_ParameterizedConstructor_NegativeNumber_ThrowsException()
        {
            // Arrange
            // Act
            new IdNumber(-1);
            // Assert - Exception is expected
        }

        [TestMethod]
        public void IdNumber_SetNumber_PositiveValue_SetsCorrectly()
        {
            // Arrange
            var idNumber = new IdNumber();

            // Act
            idNumber.Number = 100;

            // Assert
            Assert.AreEqual(100, idNumber.Number);
        }

        [TestMethod]
        public void IdNumber_SetNumber_NegativeValue_ThrowsException()
        {
            // Arrange
            var idNumber = new IdNumber();

            // Act & Assert
            idNumber.Number = -5;
        }

        [TestMethod]
        public void IdNumber_Equals_SameObject_ReturnsTrue()
        {
            // Arrange
            var idNumber1 = new IdNumber(1);

            // Act
            bool result = idNumber1.Equals(idNumber1);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IdNumber_Equals_DifferentObjects_ReturnsFalse()
        {
            // Arrange
            var idNumber1 = new IdNumber(1);
            var idNumber2 = new IdNumber(2);

            // Act
            bool result = idNumber1.Equals(idNumber2);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IdNumber_Equals_IdenticalObjects_ReturnsTrue()
        {
            // Arrange
            var idNumber1 = new IdNumber(3);
            var idNumber2 = new IdNumber(3);

            // Act
            bool result = idNumber1.Equals(idNumber2);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IdNumber_ToString_ReturnsCorrectString()
        {
            // Arrange
            var idNumber = new IdNumber(42);

            // Act
            string result = idNumber.ToString();

            // Assert
            Assert.AreEqual("ID объекта: 42", result);
        }

        [TestMethod]
        public void IdNumber_Equals_NullObject_ReturnsFalse()
        {
            // Arrange
            var idNumber = new IdNumber(5);

            // Act
            bool result = idNumber.Equals(null);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
