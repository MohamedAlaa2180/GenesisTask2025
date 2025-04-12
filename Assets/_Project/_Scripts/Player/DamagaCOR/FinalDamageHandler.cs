using System.Linq;
using Task_Environment;
using Task_Player;
using UnityEngine;

public class FinalDamageHandler : DamageHandler
{
    private readonly FactoryBase<DamageType, Damage> _damageFactory;
    private readonly FactoryBase<EnvironmentType, Environment> _environmentFactory;

    public FinalDamageHandler()
    {
        _damageFactory = new DamageFactory();
        _environmentFactory = new EnvironmentFactory();
    }
    public override float Handle(Player attacker, Player defender, float inputDamage, EnvironmentType environmentType, DamageType damageType)
    {
        Damage baseDamageType = _damageFactory.Create(damageType, inputDamage - attacker.FlatDamage);
        var environment = _environmentFactory.Create(environmentType);

        // Apply the environment effect to the damage
        var damageList = environment.ApplyEffectOnDamageType(baseDamageType);
        float totalDamageRecieved = 0f;
        for (int i = 0; i < damageList.Count; i++)
        {
            var damage = damageList[i];
            damage = ApplyResistance(defender, damage);
            damage.ApplyEffect(defender);
            totalDamageRecieved += damage.DamageAmount;

        }

        totalDamageRecieved += attacker.FlatDamage;

        return _next?.Handle(attacker, defender, totalDamageRecieved, environmentType, damageType) ?? totalDamageRecieved;
    }

    private Damage ApplyResistance(Player defender, Damage damage)
    {
        float resistanceValue = defender.Resistances.FirstOrDefault(r => r.Type == damage.Type)?.GetResistance() ?? 0f;
        float blockedDamage = damage.DamageAmount * resistanceValue;
        damage.DamageAmount -= blockedDamage;
        return damage;
    }
}
