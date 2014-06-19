using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmptyProject.Tests
{
    [TestClass]
    public class ArmorClassAndHitPointsTests
    {
        private Character _character;

        [TestInitialize]
        public void Setup()
        {
            // Arrange
            _character = new Character();
        }

        [TestMethod]
        public void CharacterHasArmorClass()
        {
            // Assert
            Assert.IsNotNull(_character.ArmorClass);
        }

        [TestMethod]
        public void ArmorClassDefaultsTo10()
        {
            // Assert
            Assert.AreEqual(10, _character.ArmorClass);
        }

        [TestMethod]
        public void CharacterHasHitPoints()
        {
            // Assert
            Assert.IsNotNull(_character.HitPoints);
        }

        [TestMethod]
        public void HitPointsDefaultsTo5()
        {
            // Assert
            Assert.AreEqual(5, _character.HitPoints);
        }
    }
}
