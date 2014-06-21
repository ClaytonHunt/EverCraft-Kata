using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmptyProject.Tests
{
    [TestClass]
    public class CharacterLevelTests
    {
        [TestMethod]
        public void CharacterStartsAtLevelOne()
        {
            // Arrange
            var player = new Character();

            // Assert
            Assert.AreEqual(1, player.Level);
        }

        [TestMethod]
        public void CharacterGainsLevelTwoAtOneThousandExperiencePoints()
        {
            // Arrange
            var player = new Character();

            // Act
            VanquishTwentyFoes(player);

            // Assert
            Assert.AreEqual(2, player.Level);
        }

        private void VanquishTwentyFoes(Character player)
        {
            for (var i = 0; i < 20; i++)
                KillEnemy(player, new Character());
        }

        private static void KillEnemy(Character player, Character enemy)
        {
            while (enemy.IsAlive)
                player.Attack(10, enemy);
        }
    }
}
