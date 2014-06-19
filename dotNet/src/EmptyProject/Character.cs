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

        public Character()
        {
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

        private void SetupCombat()
        {
            CriticalRoll = 20;
        }

        private void SetupStats()
        {
            ArmorClass = 10;
        }

        private void SetupVitals()
        {
            Name = "";

            IsAlive = true;
            HitPoints = 5;
            Strength = new Ability();
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

    }
}