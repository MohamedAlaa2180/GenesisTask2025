using System.Linq;
using Task_Environment;
using Task_Player;
using UnityEngine;

public static class Task
{
    /// <summary>
    /// Consider this example to test your methods for a pair of attacking and defending players.
    /// </summary>
    public static void Test()
    {
        var attacker = new Player();
        attacker.AttackPower = 0;
        attacker.WeaponStrength = 100;
        attacker.ActiveBuffs.Add(new StatusEffect("Determined", 1.2f));
        attacker.ActiveBuffs.Add(new StatusEffect("Determined", 1.1f));
        attacker.ActiveDebuffs.Add(new StatusEffect("Dizzy", 0.8f));

        var defender = new Player();
        defender.Resistances.FirstOrDefault(r => r.Type == DamageType.Fire)?.SetResistance(56f);
        defender.Resistances.FirstOrDefault(r => r.Type == DamageType.Ice)?.SetResistance(78f);

        Debug.Log($"Final Damage: {CalculateFinalDamage(attacker, defender, EnvironmentType.Desert, DamageType.Ice)}");
        Debug.Log($"Environmental Damage: {CalculateEnvironmentalDamage(attacker, defender, EnvironmentType.Forest)}");
        Debug.Log($"Base Damage: {CalculateBaseDamage(attacker, defender)}");
        Debug.Log($"Pure Damage: {CalculatePureDamage(attacker, defender)}");
    }

    /// <summary>
    /// Implement this method, knowing that an attacking player is about to attack a defending player in a given environment.
    /// Take into consideration: Player attack power, weapon strength, status effects, current environment, and player resistances.
    /// </summary>
    public static float CalculateFinalDamage(Player attacker, Player defender, EnvironmentType environment, DamageType damageType)
    {
        PlayerCombat combat = new PlayerCombat(attacker, defender);
        return combat.CalculateFinalDamage(environment, damageType);
    }

    /// <summary>
    /// Implement this method, knowing that an attacking player is about to attack a defending player in a given environment.
    /// Take into consideration: Player attack power, weapon strength, status effects, and current environment.
    /// Do not take into consideration: Player resistances.
    /// </summary>
    public static float CalculateEnvironmentalDamage(Player attacker, Player defender, EnvironmentType environment)
    {
        PlayerCombat combat = new PlayerCombat(attacker, defender);
        return combat.CalculateEnvironmentalDamage(environment);
    }

    /// <summary>
    /// Implement this method, knowing that an attacking player is about to attack a defending player.
    /// Take into consideration: Player attack power, weapon strength, and status effects.
    /// Do not take into consideration: Player resistances or environmental factors.
    /// </summary>
    public static float CalculateBaseDamage(Player attacker, Player defender)
    {
        PlayerCombat combat = new PlayerCombat(attacker, defender);
        return combat.CalculateBaseDamage();
    }

    /// <summary>
    /// Implement this method, knowing that an attacking player is about to attack a defending player.
    /// Take into consideration: Player attack power and weapon strength.
    /// Do not take into consideration: Player resistances, status effects, or environmental factors.
    /// </summary>
    public static float CalculatePureDamage(Player attacker, Player defender)
    {
        PlayerCombat combat = new PlayerCombat(attacker, defender);
        return combat.CalculatePureDamage();
    }
}