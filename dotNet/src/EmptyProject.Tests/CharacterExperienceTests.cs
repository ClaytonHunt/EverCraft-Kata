using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmptyProject.Tests
{
    [TestClass]
    public class CharacterExperienceTests
    {
        [TestMethod]
        public void CharacterStartsWithZeroExperience()
        {
            // Arrange
            var player = new Character();

            // Assert
            Assert.AreEqual(0, player.Experience);
        }

        [TestMethod]
        public void CharacterDoesNotGainsExperienceIfEnemyIsStillAlive()
        {
            // Arrange
            var player = new Character();
            var enemy = new Character();

            // Act
            player.Attack(9, enemy);

            // Assert
            Assert.AreEqual(0, player.Experience);
        }

        [TestMethod]
        public void CharacterGainsExperienceOnEnemyDeath()
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
            Assert.AreEqual(50, player.Experience);
        }

        [TestMethod]
        public void CharacterGainsSameExperienceOnEnemyDeathWithCriticalHits()
        {
            // Arrange
            var player = new Character();
            var enemy = new Character();

            // Act
            player.Attack(20, enemy);
            player.Attack(20, enemy);
            player.Attack(20, enemy);

            // Assert
            Assert.AreEqual(50, player.Experience);
        }
    }
}
