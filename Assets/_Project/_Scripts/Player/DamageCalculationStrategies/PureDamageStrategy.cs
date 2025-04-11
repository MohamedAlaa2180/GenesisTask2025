using Task_Environment;
using Task_Player;
using UnityEngine;

public class PureDamageStrategy : IDamageCalculationStrategy
{
    public float CalculateDamage(Player attacker, Player defender, EnvironmentType environmentType = EnvironmentType.Desert, DamageType damageType = DamageType.Fire)
    {
        return attacker.PureDamage;
    }
}
