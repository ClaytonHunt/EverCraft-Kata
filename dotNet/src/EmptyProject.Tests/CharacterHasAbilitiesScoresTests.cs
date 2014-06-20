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

        [TestMethod]
        public void AbilitiesDefaultToTen()
        {
            // Arrange
            var ability = new Ability();

            // Assert
            Assert.AreEqual(10, ability.Score);
        }

        [TestMethod]
        public void AbilitiesHaveAValueThatIsSet()
        {
            // Arrange
            var ability = new Ability(5);

            // Assert
            Assert.AreEqual(5, ability.Score);
        }

        [TestMethod]
        public void AbilitiesHaveAMinimumValueOfOne()
        {
            // Arrange
            var ability = new Ability(0);

            // Assert
            Assert.AreEqual(1, ability.Score);
        }

        [TestMethod]
        public void AbilitiesHaveAMaximumValueOfTwenty()
        {
            // Arrange
            var ability = new Ability(21);

            // Assert
            Assert.AreEqual(20, ability.Score);
        }

        private static void AssertAbility(object ability)
        {
            Assert.IsNotNull(ability);
            Assert.IsInstanceOfType(ability, typeof(Ability));
        }
    }
}
