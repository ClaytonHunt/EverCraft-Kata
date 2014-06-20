using System;
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
            var player = new Character(strength:12); 
            var enemy = new Character();

            // Act
            var isHit = player.Attack(9, enemy);

            // Assert
            Assert.IsTrue(isHit);
        }
    }
}
