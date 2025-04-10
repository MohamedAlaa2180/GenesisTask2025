using System.Collections.Generic;
using Task_Player;
using UnityEngine;

public class EnvironmentDesert : Environment
{
    private float fireDamageConvertionRate = 0.15f;
    public override EnvironmentType Type => EnvironmentType.Desert;
    public override Player ApplyEffect(Player player)
    {
        // Implement the effect of the desert environment on the player
        return player;
    }

    public override List<Damage> ApplyEffect(Damage damage)
    {
        float totalAttackValue = damage.DamageAmount;

        DamageFire fireDamage = new DamageFire(totalAttackValue * fireDamageConvertionRate);
        damage.DamageAmount -= fireDamage.DamageAmount;

        return new List<Damage>
        {
            fireDamage,damage
        };
    }
}

