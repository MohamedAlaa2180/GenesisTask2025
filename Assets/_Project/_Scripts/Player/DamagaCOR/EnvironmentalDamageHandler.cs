using Task_Environment;
using Task_Player;
using UnityEngine;

public class EnvironmentalDamageHandler : DamageHandler
{
    private readonly FactoryBase<EnvironmentType, Environment> _environmentFactory;
    public EnvironmentalDamageHandler()
    {
        _environmentFactory = new EnvironmentFactory();
    }
    public override float Handle(Player attacker, Player defender, float inputDamage, EnvironmentType environmentType, DamageType dmgType)
    {
        var environment = _environmentFactory.Create(environmentType);

        attacker = environment.ApplyEffectOnPlayer(attacker);
        defender = environment.ApplyEffectOnPlayer(defender);

        var environmentalDamage = inputDamage + attacker.FlatDamage;

        return _next?.Handle(attacker, defender, environmentalDamage, environmentType, dmgType) ?? environmentalDamage;
    }
}
