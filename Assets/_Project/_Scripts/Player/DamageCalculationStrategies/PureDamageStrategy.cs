using Task_DamageCORPattern;
using Task_Environment;
using Task_Player;

namespace Task_DamageStrategyPattern
{
    public class PureDamageStrategy : ChainedDamageCalculationStrategy
    {
        private PureDamageHandler _pureDamageHandler;

        public PureDamageStrategy()
        {
            _pureDamageHandler = new PureDamageHandler();

            _chainHead = _pureDamageHandler;
        }

        public override float CalculateDamage(Player attacker, Player defender, EnvironmentType environmentType = EnvironmentType.Desert, DamageType damageType = DamageType.Fire)
        {
            return _chainHead.Handle(attacker, defender, new DamageResult(0,0), environmentType, damageType).TotalDamage;
        }
    }
}