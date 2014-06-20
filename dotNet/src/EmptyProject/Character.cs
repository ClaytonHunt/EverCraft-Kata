namespace EmptyProject
{
    public class Character
    {
        public string Name { get; set; }
        public Alignment Alignment { get; set; }
        public int ArmorClass { get; private set; }
        public int HitPoints { get; private set; }
        public bool IsAlive { get; private set; }

        private const int BaseArmorClass = 10;

        private int CriticalRoll { get; set; }
        private int CriticalHitMultiplier { get; set; }

        private static readonly Abilities Abilities = new Abilities();

        public Ability Strength { get; private set; }
        public Ability Dexterity { get; private set; }
        public Ability Constitution { get; private set; }
        public Ability Wisdom { get; private set; }
        public Ability Intelligence { get; private set; }
        public Ability Charisma { get; private set; }

        public Character() : this(Abilities) { }

        public Character(Abilities abilities)
        {
            SetupAbilities(abilities);
            SetupVitals();
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
            HitPoints = 5 + Constitution.Modifier;            
        }

        private void SetupAbilities(Abilities abilities)
        {
            Strength = new Ability(abilities.Strength);
            Dexterity = new Ability(abilities.Dexterity);
            Constitution = new Ability(abilities.Constitution);
            Wisdom = new Ability();
            Intelligence = new Ability();
            Charisma = new Ability();
        }

        private void SetupStats()
        {
            ArmorClass = BaseArmorClass + Dexterity.Modifier;
        }

        private void SetupCombat()
        {
            CriticalRoll = 20;
            CriticalHitMultiplier = 2;
        }

        private bool AttackHits(int attackRoll, Character enemy)
        {
            return AttackTotal(attackRoll) >= enemy.ArmorClass;            
        }

        private int AttackTotal(int attackRoll)
        {
            return attackRoll + Strength.Modifier;
        }

        private void TakeDamage(int amount)
        {
            HitPoints -= amount;

            if (HitPoints <= 0)
                IsAlive = false;
        }

        private int DamageToDeal(int attackRoll)
        {
            return PreventNegativeDamage(
                AddCriticalDamage(
                    attackRoll, 
                    CalculateNormalDamage()
                )
            );
        }

        private int AddCriticalDamage(int attackRoll, int damage)
        {
            if (attackRoll == CriticalRoll)
                damage *= CriticalHitMultiplier;
            return damage;
        }

        private int PreventNegativeDamage(int damage)
        {
            if (damage < 1)
                damage = 1;

            return damage;
        }

        private int CalculateNormalDamage()
        {
            return 1 + Strength.Modifier;            
        }
    }

    public class Abilities
    {
        private int _strength = 10;

        public int Strength
        {
            get { return _strength; }
            set { _strength = value; }
        }

        private int _dexterity = 10;

        public int Dexterity
        {
            get { return _dexterity; }
            set { _dexterity = value; }
        }

        private int _constitution = 10;
        public int Constitution
        {
            get { return _constitution; }
            set { _constitution = value; }
        }
    }

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