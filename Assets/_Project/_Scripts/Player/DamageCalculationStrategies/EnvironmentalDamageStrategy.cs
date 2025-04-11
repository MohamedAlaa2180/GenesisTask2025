using Task_Environment;
using Task_Player;

public class EnvironmentalDamageStrategy : IDamageCalculationStrategy
{
    private readonly BaseDamageStrategy _baseStrategy;
    private readonly FactoryBase<EnvironmentType, Environment> _environmentFactory;
    public EnvironmentalDamageStrategy(BaseDamageStrategy baseStrategy)
    {
        _baseStrategy = baseStrategy;
        _environmentFactory = new EnvironmentFactory();
    }

    public float CalculateDamage(Player attacker, Player defender, EnvironmentType environmentType = EnvironmentType.Desert, DamageType damageType = DamageType.Fire)
    {
        var environment = _environmentFactory.Create(environmentType);

        attacker = environment.ApplyEffectOnPlayer(attacker);

        float baseDamage = _baseStrategy.CalculateDamage(attacker, defender);

        float environmentalDamage = environment.ApplyEffectOnDamageValue(baseDamage);

        return environmentalDamage;
    }
}