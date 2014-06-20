using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmptyProject.Tests
{
    [TestClass]
    public class CharacterAbilityModifiersModifyAttributesTests
    {
        [TestMethod]
        public void StrengthModifierIsAddedToAttackRoll()
        {
            // Arrange
            var abilities = new Abilities {
                Strength = 12
            };

            var player = new Character(abilities); 
            var enemy = new Character();

            // Act
            var isHit = player.Attack(9, enemy);

            // Assert
            Assert.IsTrue(isHit);
        }
    }
}
