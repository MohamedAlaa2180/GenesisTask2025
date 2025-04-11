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
            this.attacker = attacker;
            this.defender = defender;

            _pureDamageStrategy = new PureDamageStrategy();
            _baseDamageStrategy = new BaseDamageStrategy();
            _environmentalDamageStrategy = new EnvironmentalDamageStrategy(_baseDamageStrategy as BaseDamageStrategy);
            _finalDamageStrategy = new FinalDamageStrategy(_environmentalDamageStrategy as EnvironmentalDamageStrategy);
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