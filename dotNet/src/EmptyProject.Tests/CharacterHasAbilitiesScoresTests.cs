﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}
