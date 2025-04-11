using System.Collections.Generic;
using Task_Player;
using UnityEngine;

public class EnvironmentHills : Environment
{
    public override EnvironmentType Type => EnvironmentType.Hills;
    public override Player ApplyEffect(Player player)
    {
        player.ActiveDebuffs.Clear();
        foreach (var buff in player.ActiveBuffs)
        {
            buff.ModifyMultiplierByRatio(1f);
        }
        return player;
    }

    public override List<Damage> ApplyEffect(Damage damage)
    {
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
