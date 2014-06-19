using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmptyProject.Tests
{
    [TestClass]
    public class CharacterHasAbilitiesScoresTests
    {
        [TestMethod]
        public void CharacterHasStrengthAbility()
        {
            // Arrange
            var player = new Character();

            // Act

            // Assert            
            Assert.IsNotNull(player.Strength);
        }

        [TestMethod]
        public void CharacterStrengthIsAnAbility()
        {
            // Arrange
            var player = new Character();

            // Act

            // Assert            
            Assert.IsInstanceOfType(player.Strength, typeof(Ability));
        }

        [TestMethod]
        public void CharacterHasDexterityAbility()
        {
            // Arrange
            var player = new Character();

            // Act

            // Assert            
            Assert.IsNotNull(player.Dexterity);
        }

        [TestMethod]
        public void CharacterDexterityIsAnAbility()
        {
            // Arrange
            var player = new Character();

            // Act

            // Assert            
            Assert.IsInstanceOfType(player.Dexterity, typeof(Ability));
        }
    }    
}
