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
        public void CharacterDoesNotGainsExperienceOnFailedAttack()
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
        public void CharacterGainsExperienceOnSuccessfulAttack()
        {
            
        }
    }
}
