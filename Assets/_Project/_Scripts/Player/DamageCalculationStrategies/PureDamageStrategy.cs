using Task_Environment;
using Task_Player;
using UnityEngine;

public class PureDamageStrategy : ChainedDamageCalculationStrategy
{
    public PureDamageStrategy()
    {
        var pureDamageHandler = new PureDamageHandler();

        _chainHead = pureDamageHandler;
    }
    public override float CalculateDamage(Player attacker, Player defender, EnvironmentType environmentType = EnvironmentType.Desert, DamageType damageType = DamageType.Fire)
    {
        return _chainHead.Handle(attacker,defender,0f,environmentType,damageType);
    }
}
