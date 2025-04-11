using System.Collections.Generic;
using System.Linq;
using Task_Player;
using UnityEngine;

public class EnvironmentForest : Environment
{
    public override EnvironmentType Type => EnvironmentType.Forest;
    public override Player ApplyEffect(Player player)
    {
        player.WeaponStrength -= player.WeaponStrength * 0.18f;
        player.Resistances.FirstOrDefault(r => r.Type == DamageType.Fire)?.SetResistance(0f);
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
