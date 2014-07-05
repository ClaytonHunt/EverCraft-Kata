namespace EmptyProject
{
    public class CharacterLeveler
    {
        private const int ExperiencePerLevel = 1000;

        public void AddLevel(Character character)
        {
            if (CanLevel(character))
                LevelUp(character);
        }

        private bool CanLevel(Character character)
        {
            var levelAcheivable = character.Experience/ExperiencePerLevel + 1;
            return character.Level < levelAcheivable;
        }

        private static void LevelUp(Character character)
        {
            character.Level += 1;
            character.HitPoints += 5;
        }
    }
}