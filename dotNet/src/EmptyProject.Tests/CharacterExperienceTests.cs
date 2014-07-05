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
        public void CharacterGainsExperienceAwarded()
        {
            // Arrange
            var player = new Character();

            // Act
            player.AddExperience(100);

            // Assert
            Assert.AreEqual(100, player.Experience);
        }
    }
}
