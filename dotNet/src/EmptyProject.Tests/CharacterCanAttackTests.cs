using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmptyProject.Tests
{
    [TestClass]
    public class CharacterCanAttackTests
    {
        private Character _player;
        private Character _enemy;

        [TestInitialize]
        public void Setup()
        {
            // Arrange
            _player = new Character();
            _enemy = new Character();            
        }

        [TestMethod]
        public void CharacterCanAttackEnemy()
        {
            // Act
            var isHit = _player.Attack(11, _enemy);

            // Assert
            Assert.IsTrue(isHit);
        }

        [TestMethod]
        public void LowRollToAttackDoesNotHit()
        {
            // Act
            var isHit = _player.Attack(9, _enemy);

            // Assert
            Assert.IsFalse(isHit);
        }

        [TestMethod]
        public void EqualRollToAttackHits()
        {
            // Act
            var isHit = _player.Attack(10, _enemy);

            // Assert
            Assert.IsTrue(isHit);
        }
    }
}
