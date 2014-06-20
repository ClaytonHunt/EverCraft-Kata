namespace EmptyProject
{
    public class Character
    {
        public string Name { get; set; }
        public Alignment Alignment { get; set; }
        public int ArmorClass { get; private set; }
        public int HitPoints { get; private set; }
        public bool IsAlive { get; private set; }

        private int CriticalRoll { get; set; }

        public Ability Strength { get; private set; }
        public Ability Dexterity { get; private set; }
        public Ability Constitution { get; private set; }
        public Ability Wisdom { get; private set; }
        public Ability Intelligence { get; private set; }
        public Ability Charisma { get; private set; }

        public Character()
        {
            SetupVitals();
            SetupAbilities();
            SetupStats();
            SetupCombat();
        }

        public bool Attack(int attackRoll, Character enemy)
        {
            var hitIsSuccessful = AttackHits(attackRoll, enemy);

            if (hitIsSuccessful)
                enemy.TakeDamage(DamageToDeal(attackRoll));

            return hitIsSuccessful;
        }

        private void SetupVitals()
        {
            Name = "";

            IsAlive = true;
            HitPoints = 5;            
        }

        private void SetupAbilities()
        {
            Strength = new Ability();
            Dexterity = new Ability();
            Constitution = new Ability();
            Wisdom = new Ability();
            Intelligence = new Ability();
            Charisma = new Ability();
        }

        private void SetupStats()
        {
            ArmorClass = 10;
        }

        private void SetupCombat()
        {
            CriticalRoll = 20;
        }

        private static bool AttackHits(int attackRoll, Character enemy)
        {
            return attackRoll >= enemy.ArmorClass;            
        }

        private void TakeDamage(int amount)
        {
            HitPoints -= amount;

            if (HitPoints <= 0)
                IsAlive = false;
        }

        private int DamageToDeal(int attackRoll)
        {
            var damage = 1;
            if (attackRoll == CriticalRoll)
                damage *= 2;

            return damage;
        }
    }

    public class Ability
    {
        private const int LowerLimit = 1;
        private const int UpperLimit = 20;

        public int Score { get; private set; }

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