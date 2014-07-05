namespace EmptyProject
{
    public class Character
    {
        private const int BaseArmorClass = 10;

        private int CriticalRoll { get; set; }
        private int CriticalHitMultiplier { get; set; }
        private static readonly Abilities Abilities = new Abilities();

        public string Name { get; set; }
        public Alignment Alignment { get; set; }
        public bool IsAlive { get; private set; }
        public int Level { get; internal set; }
        public int HitPoints { get; internal set; }
        public int Experience { get; private set; }
        public int ArmorClass { get; private set; }

        public Ability Strength { get; private set; }
        public Ability Dexterity { get; private set; }
        public Ability Constitution { get; private set; }
        public Ability Wisdom { get; private set; }
        public Ability Intelligence { get; private set; }
        public Ability Charisma { get; private set; }        

        public Character() : this(Abilities)
        {
            
        }

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
            DamageEnemy(attackRoll, enemy, hitIsSuccessful);

            return hitIsSuccessful;
        }

        private void DamageEnemy(int attackRoll, Character enemy, bool hitIsSuccessful)
        {
            if (hitIsSuccessful)
                enemy.TakeDamage(DamageToDeal(attackRoll));
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

        private void SetupVitals()
        {
            Name = "";
            IsAlive = true;
            Level = 1;
            HitPoints = CalculateStartingHitPoints();
        }

        private int CalculateStartingHitPoints()
        {
            return PreventBelowLimitHitPoints(
                CalculateModifiedHitPoints()
            );
        }

        private int CalculateModifiedHitPoints()
        {
            return 5 + Constitution.Modifier;
        }

        private static int PreventBelowLimitHitPoints(int hp)
        {
            if (hp < 1)
                hp = 1;
            return hp;
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

        public void AddExperience(int experience)
        {
            Experience += experience;
        }
    }
}