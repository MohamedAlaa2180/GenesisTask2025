using Task_Environment;
using Task_Player;

public class EnvironmentalDamageStrategy : ChainedDamageCalculationStrategy
{
    public EnvironmentalDamageStrategy()
    {
        var environmentalDamageHandler = new EnvironmentalDamageHandler();
        var pureDamageHandler = new PureDamageHandler();
        var baseDamageHander = new BaseDamageHandler();


        environmentalDamageHandler.SetNext(pureDamageHandler);
        pureDamageHandler.SetNext(baseDamageHander);

        _chainHead = environmentalDamageHandler;
    }

    public override float CalculateDamage(Player attacker, Player defender, EnvironmentType environmentType = EnvironmentType.Desert, DamageType damageType = DamageType.Fire)
    {
        return _chainHead.Handle(attacker,defender,0f,environmentType, damageType);
    }
}