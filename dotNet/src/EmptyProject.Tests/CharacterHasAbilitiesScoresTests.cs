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

        [TestMethod]
        public void AbilityModifierIsRelativeToScore()
        {
            CheckModifierForScore(1, -5);
            CheckModifierForScore(2, -4);
            CheckModifierForScore(3, -4);
            CheckModifierForScore(4, -3);
            CheckModifierForScore(5, -3);
            CheckModifierForScore(6, -2);
            CheckModifierForScore(7, -2);
            CheckModifierForScore(8, -1);
            CheckModifierForScore(9, -1);
            CheckModifierForScore(10, 0);
            CheckModifierForScore(11, 0);
            CheckModifierForScore(12, 1);
            CheckModifierForScore(13, 1);
            CheckModifierForScore(14, 2);
            CheckModifierForScore(15, 2);
            CheckModifierForScore(16, 3);
            CheckModifierForScore(17, 3);
            CheckModifierForScore(18, 4);
            CheckModifierForScore(19, 4);
            CheckModifierForScore(20, 5);
        }

        private static void CheckModifierForScore(int score, int expected)
        {
            // Act
            var ability = new Ability(score);

            // Assert
            Assert.AreEqual(expected, ability.Modifier);
        }

        private static void AssertAbility(object ability)
        {
            Assert.IsNotNull(ability);
            Assert.IsInstanceOfType(ability, typeof(Ability));
        }
    }
}
