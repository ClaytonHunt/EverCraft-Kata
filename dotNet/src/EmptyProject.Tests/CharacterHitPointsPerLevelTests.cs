using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmptyProject.Tests
{
    [TestClass]
    public class CharacterHitPointsPerLevelTests
    {
        [TestMethod]
        public void CharacterHitPointsIncreaseByFiveAtLevelTwo()
        {
            // Arrange
            var player = new Character();
            var leveler = new CharacterLeveler();

            // Act
            player.AddExperience(1000);
            leveler.AddLevel(player);

            // Assert
            Assert.AreEqual(10, player.HitPoints);
        }

        [TestMethod]
        public void CharacterHitPointsIncreaseByFivePlusConstitutionModifierAtLevelTwo()
        {
            // Arrange
            var player = new Character(new Abilities { Constitution = 12 });
            var leveler = new CharacterLeveler();

            // Act
            player.AddExperience(1000);
            leveler.AddLevel(player);

            // Assert
            Assert.AreEqual(12, player.HitPoints);
        }

        [TestMethod]
        public void CharacterHitPointsIncreaseByFivePlusConstitutionModifierEachLevel()
        {
            // Arrange
            var player = new Character(new Abilities { Constitution = 12 });
            var leveler = new CharacterLeveler();

            // Act
            player.AddExperience(2000);
            leveler.AddLevel(player);
            leveler.AddLevel(player);

            // Assert
            Assert.AreEqual(18, player.HitPoints);
        }
    }
}