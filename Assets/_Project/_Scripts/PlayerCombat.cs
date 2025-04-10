using System.Collections.Generic;
using Task_Player;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerCombat
{
    public float CalculatePureDamage(Player attacker, Player defender)
    {
        return attacker.AttackPower + attacker.WeaponStrength;
    }

    public float CalculateDamage(Player player, EnvironmentType environmentType)
    {
        var environment = EnvironmentFactory.Create(environmentType);

        player = environment.ApplyEffect(player);

        float raw = player.AttackPower + player.WeaponStrength;

        float buffMultiplier = 1f;
        foreach (var buff in player.ActiveBuffs)
            buffMultiplier *= buff.DamageMultiplier;

        float debuffMultiplier = 1f;
        foreach (var debuff in player.ActiveDebuffs)
            debuffMultiplier *= debuff.DamageMultiplier;

        float finalAmount = raw * buffMultiplier * debuffMultiplier;

        return finalAmount;
    }

    public List<Damage> DealDamage(Player player,EnvironmentType environmentType, DamageType damageType)
    {
        // Calculate the damage amount
        float damageAmount = CalculateDamage(player, environmentType);

        // Create the base damage object based on the damage type
        Damage baseDamage = DamageFactory.Create(damageType, damageAmount);

        var environment = EnvironmentFactory.Create(environmentType);

        // Apply the environment effect to the damage
        var damageList = environment.ApplyEffect(baseDamage);

        return damageList;
    }

    public float TakeDamage(Player target, List<Damage> damageList)
    {
        float totalDamageRecieved = 0f;
        for (int i = 0; i < damageList.Count; i++)
        {
            var damage = damageList[i];
            damage = ApplyResistance(target, damage);
            damage.ApplyEffect(target);
            totalDamageRecieved += damage.DamageAmount;
        }    
        
        return totalDamageRecieved;
    }

    private Damage ApplyResistance(Player target, Damage damage)
    {
        float resistanceValue = target.Resistance.GetResistance(damage.Type);
        damage.DamageAmount *= 1 - resistanceValue;
        return damage;
    }
}