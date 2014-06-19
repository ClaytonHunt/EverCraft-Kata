using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmptyProject.Tests
{
    [TestClass]
    public class CharacterCanBeDamagedTests
    {
        [TestMethod]
        public void CharacterLooses1HitpointWhenHit()
        {
            // Arrange
            var player = new Character();
            var enemy = new Character();

            // Act
            player.Attack(10, enemy);

            // Assert
            Assert.AreEqual(4, enemy.HitPoints);
        }

        [TestMethod]
        public void DoubleDamageIsDealtOnACriticalHit()
        {
            // Arrange
            const int natural20 = 20;
            var player = new Character();
            var enemy = new Character();

            // Act            
            player.Attack(natural20, enemy);

            // Assert
            Assert.AreEqual(3, enemy.HitPoints);
        }

        [TestMethod]
        public void CharacterIsAlive()
        {
            // Arrange
            var player = new Character();

            // Assert
            Assert.IsTrue(player.IsAlive);
        }

        [TestMethod]
        public void CharacterIsDeadWhenHitPointsAreZero()
        {
            // Arrange
            var player = new Character();
            var enemy = new Character();

            // Act
            player.Attack(10, enemy);
            player.Attack(10, enemy);
            player.Attack(10, enemy);
            player.Attack(10, enemy);
            player.Attack(10, enemy);

            // Assert
            Assert.AreEqual(0, enemy.HitPoints);
            Assert.IsFalse(enemy.IsAlive);
        }

        [TestMethod]
        public void CharacterIsDeadWhenHitPointsAreLessThanZero()
        {
            // Arrange
            var player = new Character();
            var enemy = new Character();

            // Act
            player.Attack(10, enemy);
            player.Attack(10, enemy);
            player.Attack(10, enemy);
            player.Attack(10, enemy);
            player.Attack(20, enemy);

            // Assert
            Assert.AreEqual(-1, enemy.HitPoints);
            Assert.IsFalse(enemy.IsAlive);
        }
    }
}
