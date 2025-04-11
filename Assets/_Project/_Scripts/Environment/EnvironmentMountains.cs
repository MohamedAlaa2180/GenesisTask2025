using System.Collections.Generic;
using System.Linq;
using Task_Player;
using UnityEngine;

public class EnvironmentMountains : Environment
{
    public override EnvironmentType Type => EnvironmentType.Mountains;
    public override Player ApplyEffect(Player player)
    {
        player.Resistances.FirstOrDefault(r => r.Type == DamageType.Physical)?.IncreaseByValue(50f);
        player.Resistances.FirstOrDefault(r => r.Type == DamageType.Fire)?.IncreaseByValue(50f);
        player.Resistances.FirstOrDefault(r => r.Type == DamageType.Ice)?.IncreaseByValue(50f);
        player.Resistances.FirstOrDefault(r => r.Type == DamageType.Poison)?.IncreaseByValue(50f);

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
