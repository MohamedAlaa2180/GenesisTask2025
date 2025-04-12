using Task_Environment;

namespace Task_Player
{
    public class PlayerCombat
    {
        private Player attacker;
        private Player defender;

        private IDamageCalculationStrategy _pureDamageStrategy;
        private IDamageCalculationStrategy _baseDamageStrategy;
        private IDamageCalculationStrategy _environmentalDamageStrategy;
        private IDamageCalculationStrategy _finalDamageStrategy;

        public PlayerCombat(Player attacker, Player defender)
        {
            this.attacker = attacker.Clone();
            this.defender = defender.Clone();

            _pureDamageStrategy = new PureDamageStrategy();
            _baseDamageStrategy = new BaseDamageStrategy();
            _environmentalDamageStrategy = new EnvironmentalDamageStrategy();
            _finalDamageStrategy = new FinalDamageStrategy();
        }

        public float CalculatePureDamage()
        {
            return _pureDamageStrategy.CalculateDamage(attacker, defender);
        }

        public float CalculateBaseDamage()
        {
            return _baseDamageStrategy.CalculateDamage(attacker, defender);
        }

        public float CalculateEnvironmentalDamage(EnvironmentType environmentType)
        {
            return _environmentalDamageStrategy.CalculateDamage(attacker, defender, environmentType);
        }

        public float CalculateFinalDamage(EnvironmentType environmentType, DamageType damageType)
        {
            return _finalDamageStrategy.CalculateDamage(attacker, defender, environmentType, damageType);
        }
    }
}