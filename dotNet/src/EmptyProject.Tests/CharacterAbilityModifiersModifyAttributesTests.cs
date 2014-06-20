using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmptyProject.Tests
{
    [TestClass]
    public class CharacterAbilityModifiersModifyAttributesTests
    {
        private Abilities _abilities;
        private Character _player;
        private Character _enemy;

        [TestMethod]
        public void StrengthModifierIsAddedToAttackRoll()
        {
            // Arrange
            _abilities = new Abilities { Strength = 12 };
            CreatePlayerAndEnemy();

            // Act
            var isHit = _player.Attack(9, _enemy);

            // Assert
            Assert.IsTrue(isHit);
        }

        [TestMethod]
        public void StrengthModifierIsAddedToDamageOnSuccessfulAttack()
        {
            // Arrange
            _abilities = new Abilities { Strength = 12 };
            CreatePlayerAndEnemy();

            // Act
            _player.Attack(9, _enemy);

            // Assert
            Assert.AreEqual(3, _enemy.HitPoints);
        }

        [TestMethod]
        public void StrengthModifierIsAddedToDamageOnCriticalAttack()
        {
            // Arrange
            _abilities = new Abilities { Strength = 12 };
            CreatePlayerAndEnemy();

            // Act
            _player.Attack(20, _enemy);

            // Assert
            Assert.AreEqual(1, _enemy.HitPoints);
        }

        [TestMethod]
        public void MinimumDamageIsOne()
        {
            // Arrange
            _abilities = new Abilities { Strength = 8 };
            CreatePlayerAndEnemy();

            // Act
            _player.Attack(19, _enemy);

            // Assert
            Assert.AreEqual(4, _enemy.HitPoints);
        }

        [TestMethod]
        public void MinimumDamageOnCriticalHitIsOne()
        {
            // Arrange
            _abilities = new Abilities { Strength = 8 };
            CreatePlayerAndEnemy();

            // Act
            _player.Attack(20, _enemy);

            // Assert
            Assert.AreEqual(4, _enemy.HitPoints);
        }

        [TestMethod]
        public void DexterityIsAddedToArmorClass()
        {
            // Arrange
            _abilities = new Abilities { Dexterity = 12 };
            CreatePlayerAndEnemy();

            Assert.AreEqual(11, _player.ArmorClass);
        }

        [TestMethod]
        public void ConstitutionIsAddedToHitPoints()
        {
            // Arrange
            _abilities = new Abilities { Constitution = 12 };
            CreatePlayerAndEnemy();

            Assert.AreEqual(6, _player.HitPoints);
        }

        private void CreatePlayerAndEnemy()
        {
            _player = new Character(_abilities);
            _enemy = new Character();
        }
    }
}
