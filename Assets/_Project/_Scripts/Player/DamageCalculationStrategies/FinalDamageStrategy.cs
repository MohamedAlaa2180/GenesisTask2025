using System.Linq;
using Task_Environment;
using Task_Player;

public class FinalDamageStrategy : IDamageCalculationStrategy
{
    private readonly EnvironmentalDamageStrategy _environmentalStrategy;
    private readonly FactoryBase<EnvironmentType, Environment> _environmentFactory;
    private readonly FactoryBase<DamageType, Damage> _damageFactory;

    public FinalDamageStrategy(EnvironmentalDamageStrategy environmentalStrategy)
    {
        _environmentalStrategy = environmentalStrategy;
        _environmentFactory = new EnvironmentFactory();
        _damageFactory = new DamageFactory();
    }

    public float CalculateDamage(Player attacker, Player defender, EnvironmentType environmentType = EnvironmentType.Desert, DamageType damageType = DamageType.Fire)
    {
        float damageAmount = _environmentalStrategy.CalculateDamage(attacker, defender, environmentType, damageType);

        // Create the base damage type object based on the damage type
        Damage baseDamageType = _damageFactory.Create(damageType, damageAmount);

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

        return totalDamageRecieved;
    }

    private Damage ApplyResistance(Player defender, Damage damage)
    {
        float resistanceValue = defender.Resistances.FirstOrDefault(r => r.Type == damage.Type)?.GetResistance() ?? 0f;
        float blockedDamage = damage.DamageAmount * resistanceValue;
        damage.DamageAmount -= blockedDamage;
        return damage;
    }
}
