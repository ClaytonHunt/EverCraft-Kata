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
        public void CharacterDoesNotGainLevelIfExperienceIsNotEnough()
        {
            // Arrange
            var player = new Character();
            var leveler = new CharacterLeveler();

            // Act
            leveler.AddLevel(player);

            // Assert
            Assert.AreEqual(1, player.Level);
        }

        [TestMethod]
        public void CharacterGainsLevelTwoAtOneThousandExperiencePoints()
        {
            // Arrange
            var player = new Character();
            var leveler = new CharacterLeveler();

            // Act
            player.AddExperience(1000);
            leveler.AddLevel(player);

            // Assert
            Assert.AreEqual(2, player.Level);
        }

        [TestMethod]
        public void CharacterGainsLevelThreeAtTwoThousandExperiencePoints()
        {
            // Arrange
            var player = new Character();
            var leveler = new CharacterLeveler();

            // Act
            player.AddExperience(2000);
            leveler.AddLevel(player);
            leveler.AddLevel(player);

            // Assert
            Assert.AreEqual(3, player.Level);
        }        
    }
}
