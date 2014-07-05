using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmptyProject.Tests
{
    [TestClass]
    public class CharacterAttackPerLevelTests
    {
        [TestMethod]
        public void CharacterAttackIncreaseByOneAtEvenLevels()
        {
            // Arrange
            var player = new Character();
            player.AddExperience(1000);
            var leveler = new CharacterLeveler();
            leveler.AddLevel(player);
            var enemy = new Character();
            
            // Act            
            var isHitSuccessful = player.Attack(9, enemy);

            // Assert
            Assert.IsTrue(isHitSuccessful);
        }

        [TestMethod]
        public void CharacterAttackDoesNotIncreaseByOneAtOddLevels()
        {
            // Arrange
            var player = new Character();
            player.AddExperience(2000);
            var leveler = new CharacterLeveler();
            leveler.AddLevel(player);
            leveler.AddLevel(player);
            var enemy = new Character();

            // Act            
            var isHitSuccessful = player.Attack(8, enemy);

            // Assert
            Assert.IsFalse(isHitSuccessful);
        }
    }
}