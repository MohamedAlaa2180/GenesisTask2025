using Task_DamageCORPattern;
using Task_Environment;
using Task_Player;

namespace Task_DamageStrategyPattern
{
    public class BaseDamageStrategy : ChainedDamageCalculationStrategy
    {
        private PureDamageHandler _pureDamageHandler;
        private BaseDamageHandler _baseDamageHandler;

        public BaseDamageStrategy()
        {
            _pureDamageHandler = new PureDamageHandler();
            _baseDamageHandler = new BaseDamageHandler();

            _pureDamageHandler.SetNext(_baseDamageHandler);

            _chainHead = _pureDamageHandler;
        }

        public override float CalculateDamage(Player attacker, Player defender, EnvironmentType environmentType = EnvironmentType.Desert, DamageType damageType = DamageType.Fire)
        {
            return _chainHead.Handle(attacker, defender, new DamageResult(0,0), environmentType, damageType).TotalDamage;
        }
    }
}