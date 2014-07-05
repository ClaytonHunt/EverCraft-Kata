namespace EmptyProject
{
    public class CharacterLeveler
    {
        private Character _character;
        private const int ExperiencePerLevel = 1000;

        public void AddLevel(Character character)
        {
            _character = character;

            if (CanLevel()) LevelUp();
        }

        private bool CanLevel()
        {            
            return _character.Level < LevelCharacterCanAcheive();
        }

        private int LevelCharacterCanAcheive()
        {
            return _character.Experience/ExperiencePerLevel + 1;
        }

        private void LevelUp()
        {
            _character.Level += 1;
            _character.HitPoints += CalculateModifiedHitPoints();
            if(LevelIsEven())
            _character.AttackRollModifier += 1;
        }

        private bool LevelIsEven()
        {
            return _character.Level%2 == 0;
        }

        private int CalculateModifiedHitPoints()
        {
            return 5 + _character.Constitution.Modifier;
        }
    }
}