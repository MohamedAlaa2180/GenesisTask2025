using Task_Environment;

namespace Task_Player
{
    public class PlayerCombat
    {
        private Player _attacker;
        private Player _defender;

        private IDamageCalculationStrategy _pureDamageStrategy;
        private IDamageCalculationStrategy _baseDamageStrategy;
        private IDamageCalculationStrategy _environmentalDamageStrategy;
        private IDamageCalculationStrategy _finalDamageStrategy;

        public PlayerCombat(Player attacker, Player defender)
        {
            _attacker = attacker.Clone();
            _defender = defender.Clone();

            _pureDamageStrategy = new PureDamageStrategy();
            _baseDamageStrategy = new BaseDamageStrategy();
            _environmentalDamageStrategy = new EnvironmentalDamageStrategy();
            _finalDamageStrategy = new FinalDamageStrategy();
        }

        public float CalculatePureDamage()
        {
            return _pureDamageStrategy.CalculateDamage(_attacker, _defender);
        }

        public float CalculateBaseDamage()
        {
            return _baseDamageStrategy.CalculateDamage(_attacker, _defender);
        }

        public float CalculateEnvironmentalDamage(EnvironmentType environmentType)
        {
            return _environmentalDamageStrategy.CalculateDamage(_attacker, _defender, environmentType);
        }

        public float CalculateFinalDamage(EnvironmentType environmentType, DamageType damageType)
        {
            return _finalDamageStrategy.CalculateDamage(_attacker, _defender, environmentType, damageType);
        }
    }
}