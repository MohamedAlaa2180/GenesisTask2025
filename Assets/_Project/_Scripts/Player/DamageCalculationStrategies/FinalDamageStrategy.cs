using Task_DamageCORPattern;
using Task_Environment;
using Task_Player;

namespace Task_DamageStrategyPattern
{
    public class FinalDamageStrategy : ChainedDamageCalculationStrategy
    {
        private PureDamageHandler _pureDamageHandler;
        private BaseDamageHandler _baseDamageHandler;
        private EnvironmentalDamageHandler _environmentalDamageHandler;
        private FinalDamageHandler _finalDamageHandler;

        public FinalDamageStrategy()
        {
            _pureDamageHandler = new PureDamageHandler();
            _baseDamageHandler = new BaseDamageHandler();
            _environmentalDamageHandler = new EnvironmentalDamageHandler();
            _finalDamageHandler = new FinalDamageHandler();

            // Set up the chain
            _pureDamageHandler.SetNext(_baseDamageHandler);
            _baseDamageHandler.SetNext(_environmentalDamageHandler);
            _environmentalDamageHandler.SetNext(_finalDamageHandler);

            _chainHead = _pureDamageHandler;
        }

        public override float CalculateDamage(Player attacker, Player defender, EnvironmentType environmentType = EnvironmentType.Desert, DamageType damageType = DamageType.Fire)
        {
            return _chainHead.Handle(attacker, defender, new DamageResult(0, 0), environmentType, damageType).TotalDamage;
        }
    }
}