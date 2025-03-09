namespace ToolLibrary.Tests
{
    [TestClass]
    public class SortByNameLengthTests
    {
        [TestMethod]
        public void Compare_XIsNull_ReturnsNegativeOne()
        {
            // Arrange
            var comparer = new SortByNameLength();
            Tool y = new Tool("Hammer", 1);

            // Act
            int result = comparer.Compare(null, y);

            // Assert
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void Compare_YIsNull_ReturnsNegativeOne()
        {
            // Arrange
            var comparer = new SortByNameLength();
            Tool x = new Tool("Hammer", 1);

            // Act
            int result = comparer.Compare(x, null);

            // Assert
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void Compare_BothNull_ReturnsNegativeOne()
        {
            // Arrange
            var comparer = new SortByNameLength();

            // Act
            int result = comparer.Compare(null, null);

            // Assert
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void Compare_XNameLengthLessThanY_ReturnsNegativeOne()
        {
            // Arrange
            var comparer = new SortByNameLength();
            Tool x = new Tool("Saw", 1);
            Tool y = new Tool("Hammer", 2);

            // Act
            int result = comparer.Compare(x, y);

            // Assert
            Assert.AreEqual(-1, result); // Or < 0, depending on desired behavior
        }

        [TestMethod]
        public void Compare_XNameLengthGreaterThanY_ReturnsPositiveOne()
        {
            // Arrange
            var comparer = new SortByNameLength();
            Tool x = new Tool("Hammer", 1);
            Tool y = new Tool("Saw", 2);

            // Act
            int result = comparer.Compare(x, y);

            // Assert
            Assert.AreEqual(1, result); //Or > 0, depending on desired behavior
        }

        [TestMethod]
        public void Compare_XNameLengthEqualsY_ReturnsZero()
        {
            // Arrange
            var comparer = new SortByNameLength();
            Tool x = new Tool("Hammer", 1);
            Tool y = new Tool("Wrench", 2);

            // Act
            int result = comparer.Compare(x, y);

            // Assert
            Assert.AreEqual(0, result);
        }
    }
}

