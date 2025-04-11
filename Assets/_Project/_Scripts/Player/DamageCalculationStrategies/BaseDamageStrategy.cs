using Task_Environment;
using Task_Player;
using UnityEngine;

public class BaseDamageStrategy : IDamageCalculationStrategy
{
    public virtual float CalculateDamage(Player attacker, Player defender, EnvironmentType environmentType = EnvironmentType.Desert, DamageType damageType = DamageType.Fire)
    {
        float effectMultiplier = 0f;

        foreach (var buff in attacker.ActiveBuffs)
        {
            effectMultiplier += buff.GetEffectValue;
        }

        foreach (var debuff in attacker.ActiveDebuffs)
        {
            effectMultiplier -= debuff.GetEffectValue;
        }

        return attacker.PureDamage + (attacker.PureDamage * effectMultiplier);
    }
}
