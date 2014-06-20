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
    }
}
