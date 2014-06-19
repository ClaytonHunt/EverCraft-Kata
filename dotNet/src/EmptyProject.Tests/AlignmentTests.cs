using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmptyProject.Tests
{
    [TestClass]
    public class AlignmentTests
    {
        private Character _character;

        [TestInitialize]
        public void Setup()
        {
            // Arrange
            _character = new Character();
        }

        [TestMethod]
        public void GoodAlignmentExists()
        {
            // Assert
            Assert.IsNotNull(Alignment.Good);
        }

        [TestMethod]
        public void NeutralAlignmentExists()
        {
            // Assert
            Assert.IsNotNull(Alignment.Neutral);
        }

        [TestMethod]
        public void EvilAlignmentExists()
        {
            // Assert
            Assert.IsNotNull(Alignment.Evil);
        }

        [TestMethod]
        public void CharacterHasAlignment()
        {
            // Assert
            Assert.IsNotNull(_character.Alignment);
        }

        [TestMethod]
        public void CharacterCanChangeAlignment()
        {
            // Act
            _character.Alignment = Alignment.Good;

            // Assert
            Assert.AreEqual(Alignment.Good, _character.Alignment);
        }
    }
}
