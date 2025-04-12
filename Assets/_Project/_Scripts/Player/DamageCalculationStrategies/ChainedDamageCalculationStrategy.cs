using Task_Environment;
using Task_Player;
using UnityEngine;

public abstract class ChainedDamageCalculationStrategy : IDamageCalculationStrategy
{
    protected DamageHandler _chainHead;

    public abstract float CalculateDamage(Player attacker, Player defender, EnvironmentType environmentType, DamageType damageType);
}
