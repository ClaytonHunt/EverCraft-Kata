using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmptyProject.Tests
{
    [TestClass]
    public class CharacterTests
    {
        private Character _character;

        [TestInitialize]
        public void Setup()
        {
            // Arrange
            _character = new Character();
        }

        [TestMethod]
        public void ItExists()
        {
            // Assert
            Assert.IsNotNull(_character);
        }

        [TestMethod]
        public void ItHasName()
        {
            // Assert
            Assert.AreEqual(string.Empty, _character.Name);
        }

        [TestMethod]
        public void ItCanChangeName()
        {
            // Act
            _character.Name = "Test Name";

            // Assert
            Assert.AreEqual("Test Name", _character.Name);
        }
    }
}
