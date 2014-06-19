using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmptyProject.Tests
{
    [TestClass]
    public class CharacterHasAbilitiesScoresTests
    {
        [TestMethod]
        public void CharacterHasBaseAbilities()
        {
            // Arrange
            var player = new Character();

            // Assert            
            AssertAbility(player.Strength);
            AssertAbility(player.Dexterity);
            AssertAbility(player.Constitution);
            AssertAbility(player.Wisdom);
            AssertAbility(player.Intelligence);
            AssertAbility(player.Charisma);
        }

        private static void AssertAbility(object ability)
        {
            Assert.IsNotNull(ability);
            Assert.IsInstanceOfType(ability, typeof (Ability));
        }        
    }    
}
