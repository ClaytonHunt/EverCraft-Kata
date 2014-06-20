﻿namespace EmptyProject
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

        public Character(int strength = 10)
        {
            SetupVitals();
            SetupAbilities(strength);
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

        private void SetupAbilities(int strength)
        {
            Strength = new Ability(strength);
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