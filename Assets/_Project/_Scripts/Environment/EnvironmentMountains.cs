using System.Collections.Generic;
using Task_Player;
using UnityEngine;

public class EnvironmentMountains : Environment
{
    public override EnvironmentType Type => EnvironmentType.Mountains;
    public override Player ApplyEffect(Player player)
    {
        player.Resistance.BuffResistanceByValue(ResistanceType.Physical, 50f);
        player.Resistance.BuffResistanceByValue(ResistanceType.Fire, 50f);
        player.Resistance.BuffResistanceByValue(ResistanceType.Ice, 50f);
        player.Resistance.BuffResistanceByValue(ResistanceType.Poison, 50f);
        return player;
    }

    public override List<Damage> ApplyEffect(Damage damage)
    {
        damage.DamageAmount = damage.Type == DamageType.Ice ? 0 : damage.DamageAmount;

        return new List<Damage>
        {
            damage
        };
    }
    public override float ApplyEffect(float damage)
    {
        return damage;
    }
}
