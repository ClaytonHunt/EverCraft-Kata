namespace EmptyProject
{
    public class Ability
    {
        private const int LowerLimit = 1;
        private const int UpperLimit = 20;
        private const int ModifierRange = 2;

        public int Score { get; private set; }

        public int Modifier
        {
            get
            {
                return (Score / ModifierRange) - (UpperLimit / (ModifierRange * 2));
            }
        }

        public Ability()
        {
            Score = 10;
        }

        public Ability(int score)
        {
            SetScoreWithLimits(score);
        }

        private void SetScoreWithLimits(int score)
        {
            score = ScoreOrLowerLimit(score);
            Score = ScoreOrUpperLimit(score);
        }

        private static int ScoreOrUpperLimit(int score)
        {
            return score > UpperLimit ? UpperLimit : score;
        }

        private static int ScoreOrLowerLimit(int score)
        {
            return score < LowerLimit ? LowerLimit : score;
        }
    }
}