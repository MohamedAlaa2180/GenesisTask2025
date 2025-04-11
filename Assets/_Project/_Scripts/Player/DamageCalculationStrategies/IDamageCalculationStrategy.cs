using Task_Environment;
using Task_Player;
using UnityEngine;

public interface IDamageCalculationStrategy
{
    float CalculateDamage(Player attacker, Player defender, EnvironmentType environmentType = EnvironmentType.Desert, DamageType damageType = DamageType.Fire);
}
