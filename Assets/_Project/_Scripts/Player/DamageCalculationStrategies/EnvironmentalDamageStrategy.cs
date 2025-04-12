using Task_DamageCORPattern;
using Task_Environment;
using Task_Player;

namespace Task_DamageStrategyPattern
{
    public class EnvironmentalDamageStrategy : ChainedDamageCalculationStrategy
    {
        private EnvironmentalDamageHandler _environmentalDamageHandler;
        private PureDamageHandler _pureDamageHandler;
        private BaseDamageHandler _baseDamageHandler;

        public EnvironmentalDamageStrategy()
        {
            _environmentalDamageHandler = new EnvironmentalDamageHandler();
            _pureDamageHandler = new PureDamageHandler();
            _baseDamageHandler = new BaseDamageHandler();

            _environmentalDamageHandler.SetNext(_pureDamageHandler);
            _pureDamageHandler.SetNext(_baseDamageHandler);

            _chainHead = _environmentalDamageHandler;
        }

        public override float CalculateDamage(Player attacker, Player defender, EnvironmentType environmentType = EnvironmentType.Desert, DamageType damageType = DamageType.Fire)
        {
            return _chainHead.Handle(attacker, defender, 0f, environmentType, damageType);
        }
    }
}